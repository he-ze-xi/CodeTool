using System.Collections.Concurrent;

namespace Log_2
{
	//自定义日志版本，不依赖任何库，特点如下：
	//线程安全，日志异步写入文件不影响业务逻辑；
	//支持过期文件自动清理，也可自定义清理逻辑；
	//缓存队列有内存上限防呆，防止异常情况下内存爆满；
	//提供默认的静态日志记录器，也支持自定义多个日志记录器；
	//通过委托方法支持日志文件名、日志记录格式的自定义，更加自由


	/// <summary>
	/// 
	/// </summary>
	public class CustomLog
	{
		static void Test(string[] args)
		{
			//自定义日志保存路径，默认保存到程序启动目录下的Log文件夹
			LogManage.CustomLogPath = () => AppDomain.CurrentDomain.BaseDirectory + "\\CustomLogs";
			//自定义日志文件名称，默认文件名为 DateTime.Now.ToString("yyyy-MM-dd") + ".log"
			LogManage.CustomLogFileName = () => "MyLog_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
			//日志保存天数，默认30天
			LogManage.SaveDays = 10;
			//日志记录的格式，默认为 $"[{Time:yyyy-MM-dd HH:mm:ss ffff}] [{Level.ToString().ToUpper()}] [{ThreadId}] {Message}"
			LogManage.LogFormatter = (item) =>
			{
				//可以在这里做日志等级筛选，如果返回string.Empty这该条日志不会记录到文件
				return $"{item.Time:yyyy/MM/dd HH:mm:ss.fff} | {item.Level} | T{item.ThreadId:0000} | {item.Message}";
			};
			//日志回调，可用于界面实时显示日志或日志保存其它存储介质
			LogManage.OnWriteLog = (item) => Console.WriteLine("An event was logged: " + item.ToString());



			//正常写入日志
			LogManage.Info("This is an info message: {0}", "TestInfo");
			LogManage.Debug("This is a debug message: {0}", "TestDebug");
			LogManage.Warn("This is an warning message: {0}", "TestInfo");
			LogManage.Error("This is a error message: {0}", "TestDebug");

			//自定义写入日志，一般情况下使用枚举定义日志记录器的名称
			var logger = LogManage.GetLogger("测试日志");
			logger.Info("This is an info message: {0}", "TestInfo");
			logger.Debug("This is a debug message: {0}", "TestDebug");
			logger.Warn("This is an warning message: {0}", "TestInfo");
			logger.Error("This is a error message: {0}", "TestDebug");

			// 在程序退出前关闭所有日志记录器，默认超时时间是3秒
			LogManage.Close(5);

			//调试时偶尔使用
			if (LogManage.LastException != null)
			{
				Console.WriteLine("日志异常:" + LogManage.LastException);
			}
		}
	}

	/// <summary>
	/// 日志组件，内部维护了一个静态日志记录类
	/// </summary>
	public static class LogManage
	{
		/// <summary>
		/// 日志等级
		/// </summary>
		public enum LogLevel
		{ Debug, Info, Warn, Error, Fatal }

		/// <summary>
		/// 日志数据
		/// </summary>
		public class LogItem
		{
			public LogItem(LogLevel level, string message)
			{
				Level = level;
				Message = message;
				Time = DateTime.Now;
				ThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			public DateTime Time { get; private set; }
			public LogLevel Level { get; private set; }
			public int ThreadId { get; private set; }
			public string Message { get; private set; }

			public override string ToString()
			{
				return $"[{Time:yyyy-MM-dd HH:mm:ss ffff}] [{Level.ToString().ToUpper()}] [{ThreadId}] {Message}";
			}
		}

		/// <summary>
		/// 线程安全异步日志基础类，默认缓存10000条日志，超出时日志会阻塞
		/// </summary>
		public class Logger
		{
			/// <summary>
			/// 日志文件存储路径的委托
			/// </summary>
			public Func<string> CustomLogPath { get; set; }

			/// <summary>
			/// 日志文件名的委托，文件扩展名必须是log，否则会影响日志文件的自动清理（可以自定义清理的方法）
			/// </summary>
			public Func<string> CustomLogFileName { get; set; }

			/// <summary>
			/// 日志文件保存时间
			/// </summary>
			public int SaveDays { get; set; } = 30;

			/// <summary>
			/// 日志格式化委托实例
			/// </summary>
			public Func<LogItem, string> LogFormatter { get; set; }

			/// <summary>
			/// 写日志事件
			/// </summary>
			public Action<LogItem> OnWriteLog { get; set; }

			/// <summary>
			/// 日志清理委托实例，传入日志保存时间
			/// </summary>
			public Action<int> LogCleanup { get; set; }

			/// <summary>
			/// 最后一次异常（仅调试时用，不用于正常业务流程）
			/// </summary>
			public Exception LastException { get; set; }

			// 线程安全的日志队列
			private BlockingCollection<string> logQueue = new BlockingCollection<string>(10000);

			// 标识是否允许写入新日志
			private bool allowNewLogs = true;

			public Logger()
			{
				Task.Factory.StartNew(WriteToFile, TaskCreationOptions.LongRunning);
			}

			// 添加日志至队列方法
			public void EnqueueLog(LogLevel level, string message)
			{
				if (!allowNewLogs) return;
				LogItem item = new LogItem(level, message);

				string logMessage;
				if (LogFormatter != null)
				{
					logMessage = LogFormatter(item);
				}
				else
				{
					logMessage = item.ToString();
				}
				if (!string.IsNullOrWhiteSpace(logMessage))
				{
					logQueue.Add(logMessage);
				}
				OnWriteLog?.Invoke(item);
			}

			// 循环写入写日志到文件
			private void WriteToFile()
			{
				string logPath = CustomLogPath?.Invoke() ?? AppDomain.CurrentDomain.BaseDirectory + "\\Log";
				DirectoryInfo logDir = Directory.CreateDirectory(logPath);

				while (true)
				{
					try
					{
						if (!allowNewLogs && logQueue.Count == 0) break;

						string logMessage;
						if (logQueue.TryTake(out logMessage, TimeSpan.FromSeconds(1)))
						{
							string fileName = CustomLogFileName?.Invoke() ?? DateTime.Now.ToString("yyyy-MM-dd") + ".log";
							if (!File.Exists(fileName))
							{
								// 清理旧日志
								if (LogCleanup != null)
								{
									LogCleanup(SaveDays);
								}
								else
								{
									CleanUpOldLogs(logDir, SaveDays);
								}
							}
							File.AppendAllText(Path.Combine(logPath, fileName), logMessage + Environment.NewLine);
						}
					}
					catch (Exception ex)
					{
						LastException = ex;
						Console.WriteLine("Logger Exception - WriteToFile : " + ex.Message);
					}
				}


			}

			/// <summary>
			/// 关闭日志器方法，指定超时时间（秒）
			/// </summary>
			/// <param name="waitTimeInSeconds">等待时间</param>
			public void Close(int waitTimeInSeconds = 3)
			{
				allowNewLogs = false;
				CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSeconds));
				try
				{
					CancellationToken token = cts.Token;
					// 标识队列已完成添加
					logQueue.CompleteAdding();

					while (!token.IsCancellationRequested)
					{
						if (logQueue.Count == 0) break; // 提前退出

						// 短暂休眠以降低 CPU 占用
						Task.Delay(100, token).Wait();
					}
				}
				catch (OperationCanceledException)
				{
					// 等待时间到，退出方法，不传播异常
				}
				catch (Exception ex)
				{
					Console.WriteLine("An unexpected exception occurred in the Close method: " + ex.Message);
				}
			}

			/// <summary>
			/// 默认的清理过期日志的方法
			/// </summary>
			/// <param name="logDir"></param>
			/// <param name="saveDays"></param>
			public static void CleanUpOldLogs(DirectoryInfo logDir, int saveDays)
			{
				FileInfo[] logFiles = logDir.GetFiles("*.log");
				foreach (FileInfo file in logFiles)
				{
					if (DateTime.Now - file.CreationTime >= TimeSpan.FromDays(saveDays))
					{
						file.Delete();
					}
				}
			}

			/// <summary>
			/// 记录Info等级日志
			/// </summary>
			/// <param name="message"></param>
			/// <param name="args"></param>
			public void Info(string message, params object[] args)
			{
				EnqueueLog(LogLevel.Info, string.Format(message, args));
			}

			/// <summary>
			/// 记录Debug等级日志
			/// </summary>
			/// <param name="message"></param>
			/// <param name="args"></param>
			public void Debug(string message, params object[] args)
			{
				EnqueueLog(LogLevel.Debug, string.Format(message, args));
			}

			/// <summary>
			/// 记录Warning等级日志
			/// </summary>
			/// <param name="message"></param>
			/// <param name="args"></param>
			public void Warn(string message, params object[] args)
			{
				EnqueueLog(LogLevel.Warn, string.Format(message, args));
			}

			/// <summary>
			/// 记录Error等级日志
			/// </summary>
			/// <param name="message"></param>
			/// <param name="args"></param>
			public void Error(string message, params object[] args)
			{
				EnqueueLog(LogLevel.Error, string.Format(message, args));
			}

			/// <summary>
			/// 记录Fatal等级日志
			/// </summary>
			/// <param name="message"></param>
			/// <param name="args"></param>
			public void Fatal(string message, params object[] args)
			{
				EnqueueLog(LogLevel.Fatal, string.Format(message, args));
			}
		}


		private static Logger logger = new Logger();
		private static ConcurrentDictionary<string, Logger> logDic = new ConcurrentDictionary<string, Logger>();

		/// <summary>
		/// 获取自定义的日志记录类
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Logger GetLogger(string name)
		{
			return logDic.GetOrAdd(name, key =>
			{
				var log = new Logger();
				log.CustomLogPath = () => AppDomain.CurrentDomain.BaseDirectory + "\\Log\\" + key;
				return log;
			});
		}

		/// <summary>
		/// 日志文件存储路径的委托
		/// </summary>
		public static Func<string> CustomLogPath
		{
			get => logger.CustomLogPath;
			set => logger.CustomLogPath = value;
		}

		/// <summary>
		/// 日志文件名的委托，文件扩展名必须是log，否则会影响日志文件的自动清理（可以自定义清理的方法）
		/// </summary>
		public static Func<string> CustomLogFileName
		{
			get => logger.CustomLogFileName;
			set => logger.CustomLogFileName = value;
		}

		/// <summary>
		/// 日志文件保存时间
		/// </summary>
		public static int SaveDays
		{
			get => logger.SaveDays;
			set => logger.SaveDays = value;
		}

		/// <summary>
		/// 日志格式化委托实例
		/// </summary>
		public static Func<LogItem, string> LogFormatter
		{
			get => logger.LogFormatter;
			set => logger.LogFormatter = value;
		}

		/// <summary>
		/// 写日志事件
		/// </summary>
		public static Action<LogItem> OnWriteLog
		{
			get => logger.OnWriteLog;
			set => logger.OnWriteLog = value;
		}

		/// <summary>
		/// 日志清理委托实例，传入日志保存时间
		/// </summary>
		public static Action<int> LogCleanup
		{
			get => logger.LogCleanup;
			set => logger.LogCleanup = value;
		}

		/// <summary>
		/// 最后一次异常（仅调试时用，不用于正常业务流程）
		/// </summary>
		public static Exception LastException
		{
			get => logger.LastException;
			set => logger.LastException = value;
		}

		/// <summary>
		/// 关闭所有日志记录器，指定超时时间（秒），日志记录器较多时可能耗时较久
		/// </summary>
		/// <param name="waitTimeInSeconds">等待时间</param>
		public static void Close(int waitTimeInSeconds = 3)
		{
			logger.Close(waitTimeInSeconds);
			foreach (var item in logDic.Values)
			{
				item.Close(waitTimeInSeconds);
			}
		}

		/// <summary>
		/// 记录Info等级日志
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Info(string message, params object[] args)
		{
			logger.EnqueueLog(LogLevel.Info, string.Format(message, args));
		}

		/// <summary>
		/// 记录Debug等级日志
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Debug(string message, params object[] args)
		{
			logger.EnqueueLog(LogLevel.Debug, string.Format(message, args));
		}

		/// <summary>
		/// 记录Warning等级日志
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Warn(string message, params object[] args)
		{
			logger.EnqueueLog(LogLevel.Warn, string.Format(message, args));
		}

		/// <summary>
		/// 记录Error等级日志
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Error(string message, params object[] args)
		{
			logger.EnqueueLog(LogLevel.Error, string.Format(message, args));
		}

		/// <summary>
		/// 记录Fatal等级日志
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Fatal(string message, params object[] args)
		{
			logger.EnqueueLog(LogLevel.Fatal, string.Format(message, args));
		}
	}

}
