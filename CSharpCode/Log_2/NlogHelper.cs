using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Wrappers;
using System.Collections.Concurrent;

namespace Log_2
{
	/// <summary>
	/// Nlog版本，需要依赖于Nlog包
	/// </summary>
	public class NlogHelper
	{
		static void Main(string[] args)
		{
			//可以指定日志保存天数，默认30天
			Logger.Init();
			//订阅写日志事件
			Logger.GetLogEventTarget().LogReceived += Logger_LogWrite;
			//记录日志
			Logger.Info("软件启动");
		}

		private static void Logger_LogWrite(object? sender, string e)
		{

		}
	}


	/// <summary>
	/// 全局日志类
	/// </summary>
	public static class Logger
	{
		#region 私有字段方法

		private static ILogger logger;

		private static void ConfigureNLog(int saveDays = 30)
		{
			var config = new LoggingConfiguration();

			// 创建目标（这里是 FileTarget 用于写入文件）
			var fileTarget = new FileTarget("logfile")
			{
				FileName = "${basedir}/Log/${date:format=yyyy-MM-dd}.log",
				Layout = "${longdate} ${uppercase:${level}} ${message}  ${exception:format=tostring}",
				ArchiveOldFileOnStartup = true,
				ArchiveEvery = FileArchivePeriod.Day,
				MaxArchiveFiles = saveDays,
			};

			// 使用 AsyncTargetWrapper 实现异步写日志
			var asyncFileTarget = new AsyncTargetWrapper(fileTarget, 1000, AsyncTargetWrapperOverflowAction.Discard);
			// 设置规则
			var rule = new LoggingRule("*", LogLevel.Debug, asyncFileTarget);
			config.LoggingRules.Add(rule);

			// 创建自定义Target
			var logEventTarget = new LogEventTarget
			{
				Name = "logEvent",
				MessageLayout = "${longdate}  ${uppercase:${level}} ${message}  ${exception:format=tostring}"
			};
			config.AddTarget(logEventTarget);

			// 添加规则
			var eventRule = new LoggingRule("*", LogLevel.Debug, logEventTarget);
			config.LoggingRules.Add(eventRule);

			// 应用配置
			LogManager.Configuration = config;
		}

		#endregion 私有字段方法

		#region 公共字段方法

		/// <summary>
		/// 初始化日志，程序初始化时启动
		/// </summary>
		/// <param name="saveDays"></param>
		public static void Init(int saveDays = 30)
		{
			ConfigureNLog(saveDays);
			logger = LogManager.GetCurrentClassLogger();
		}

		/// <summary>
		/// 获取日志回调Target
		/// </summary>
		/// <returns></returns>
		public static LogEventTarget GetLogEventTarget()
		{
			return (LogEventTarget)LogManager.Configuration.FindTargetByName("logEvent");
		}

		/// <summary>
		/// 关闭日志，程序退出时调用
		/// </summary>
		public static void Close()
		{
			LogManager.Flush();
			LogManager.Shutdown();
		}

		#endregion 公共字段方法

		#region 日志接口

		/// <summary>
		/// 跟踪日志级别：最详细的级别，用于开发，很少用于生产。
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Trace(string message, params object[] args)
		{
			logger.Trace(message, args);
		}

		/// <summary>
		/// 调试日志级别：根据感兴趣的内部事件调试应用程序行为。
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Debug(string message, params object[] args)
		{
			logger.Debug(message, args);
		}

		/// <summary>
		/// 信息日志级别：突出显示进度或应用程序生存期事件的信息。
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Info(string message, params object[] args)
		{
			logger.Info(message, args);
		}

		/// <summary>
		/// 警告日志级别：关于可以恢复的验证问题或临时故障的警告。
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Warn(string message, params object[] args)
		{
			logger.Warn(message, args);
		}

		/// <summary>
		/// 错误日志级别：功能失败或捕捉到System.Exception的错误。
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Error(string message, params object?[] args)
		{
			logger.Error(message, args);
		}

		/// <summary>
		/// 致命日志级别：最关键级别，应用程序即将中止。
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Fatal(string message, params object[] args)
		{
			logger.Fatal(message, args);
		}

		#endregion 日志接口
	}

	/// <summary>
	/// 日志事件目标
	/// </summary>
	public class LogEventTarget : Target
	{
		/// <summary>
		/// 日志事件
		/// </summary>
		public event EventHandler<string> LogReceived;
		/// <summary>
		/// 日志布局
		/// </summary>
		[RequiredParameter]
		public Layout MessageLayout { get; set; }
		protected override void Write(LogEventInfo logEvent)
		{
			string logMessage = MessageLayout.Render(logEvent);
			OnLogReceived(logMessage);
		}
		private void OnLogReceived(string message)
		{
			LogReceived?.Invoke(this, message);
		}
	}

}
