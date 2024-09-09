using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System;
using 异步同步多线程_1.Datas;

namespace 异步同步多线程_1.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		#region 属性
		private string _title = "同步、异步、并行";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private string showText;
		public string ShowText
		{
			get { return showText; }
			set { RaisePropertyChanged(nameof(ShowText)); SetProperty(ref showText, value); }
		}

		public DelegateCommand SearchCommand { get; set; }
		public DelegateCommand SearchAsyncCommand { get; set; }
		public DelegateCommand SrearchConcurrentAsyncCommand { get; set; }
		public DelegateCommand SrearchEventCommand { get; set; }

		public DelegateCommand TaskStartCommand { get; set; }
		public DelegateCommand TaskPauseCommand { get; set; }
		public DelegateCommand TaskContinueCommand { get; set; }
		public DelegateCommand TaskStopCommand { get; set; }

		private CancellationTokenSource? TokenSource;
		private ManualResetEvent? ManualReset;//ManualResetEvent可以对所有进行等待的线程进行统一控制
		#endregion



		public MainWindowViewModel()
		{
			SearchCommand = new DelegateCommand(Search);
			SearchAsyncCommand = new DelegateCommand(SearchAsync);
			SrearchConcurrentAsyncCommand = new DelegateCommand(SrearchConcurrentAsync);
			SrearchEventCommand = new DelegateCommand(SrearchEvent);


			TaskStartCommand = new DelegateCommand(TaskStart);
			TaskPauseCommand = new DelegateCommand(TaskPause);
			TaskContinueCommand = new DelegateCommand(TaskContinue);
			TaskStopCommand = new DelegateCommand(TaskStop);
		}

		public void TaskStart()
		{
			TokenSource = new CancellationTokenSource();
			ManualReset = new ManualResetEvent(true);//true-初始状态为发出信号；false-初始状态为未发出信号
			int i = 0;
			Task.Run(() =>
			{
				while (!TokenSource.Token.IsCancellationRequested)//如果令牌没有发取消信号
				{
					ManualReset.WaitOne();//根据是否收到信号判断是否阻塞当前线程（为true就不会阻塞，为false就会阻塞）
					Thread.Sleep(200);
					ShowText += "\r\n" + $"线程{Environment.CurrentManagedThreadId}正在运行第{++i}次{Environment.NewLine}";
				}

			}, TokenSource.Token);//可以通过CancellationTokenSource令牌来对线程进行操作
		}
		public void TaskPause()
		{
			ManualReset?.Reset(); //Reset方法重置该值为False(即未发出信号，让线程阻塞在WaitOne处)
		}
		public void TaskContinue()
		{
			ManualReset.Set();//将该值置为true发出信号。即释放信号，所有等待信号的线程都将获得信号，开始执行WaitOne()后面的语句
		}
		public void TaskStop()
		{
			TokenSource?.Cancel(); //令牌发送取消信号，以取消其他地方的线程运行
		}
		#region
		/// <summary>
		/// 并行方式
		/// </summary>
		private async void SrearchConcurrentAsync()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			ShowText = string.Empty;
			ShowText += "\r\n" + ("并行检索开始");
			int index = 0;
			List<Task<string>> Tasks = new List<Task<string>>();
			Data.books.ForEach(book =>
			{
				Tasks.Add(Task.Run(book.Search));
			});
			var tasks = await Task.WhenAll(Tasks);
			foreach (var result in tasks)
			{
				ShowText += "\r\n" + ($"{++index},{result}");
			}
			stopwatch.Stop();
			ShowText += "\r\n" + ($"并行检索完成:{Convert.ToSingle(stopwatch.ElapsedMilliseconds / 1000)}秒");

		}
		/// <summary>
		/// 异步方式
		/// </summary>
		private async void SearchAsync()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			ShowText = string.Empty;
			ShowText += "\r\n" + ("异步检索开始");
			int index = 0;
			foreach (var book in Data.books)
			{
				var task = await Task.Run(book.Search);
				ShowText += "\r\n" + ($"{++index},{task}");
			}
			stopwatch.Stop();
			ShowText += "\r\n" + ($"异步检索完成:{Convert.ToSingle(stopwatch.ElapsedMilliseconds) / 1000}秒");
		}

		/// <summary>
		/// 同步方式
		/// </summary>
		private void Search()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			ShowText = string.Empty;
			ShowText += "\r\n" + ("同步检索开始");
			int index = 0;
			Data.books.ForEach(book => ShowText += "\r\n" + ($"{++index},{book.Search()}"));
			ShowText += "\r\n" + ($"同步检索完成:{Convert.ToSingle(stopwatch.ElapsedMilliseconds) / 1000}秒");
		}

		public async void SrearchEvent()
		{
			Stopwatch sw = Stopwatch.StartNew();
			ShowText = string.Empty;
			ShowText += "\r\n" + ("事件检索开始");

			List<Task> tasks = new List<Task>();
			foreach (var book in Data.books)
			{
				book.EventCompleted += Book_EventCompleted;//事件触发后的执行方法
				tasks.Add(Task.Run(book.SearchEvent));//SearchEvent方法中的invoke方法来触发该事件
			}

			await Task.WhenAll(tasks);
			sw.Stop();
			ShowText += "\r\n" + ($"事件检索完成:{Convert.ToSingle(sw.ElapsedMilliseconds) / 1000}秒");
		}

		private void Book_EventCompleted(object sender, BookEventArgs e)
		{
			ShowText += "\r\n" + e.Result;
		}
		#endregion


	}
}
