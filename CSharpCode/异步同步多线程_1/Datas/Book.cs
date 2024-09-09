using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 异步同步多线程_1.Datas
{

	public class BookEventArgs : EventArgs
	{
        public string? Name { get; set;}
        public string? Result { get; set; }
        public BookEventArgs(string name,string result)
        {
            this.Name=name;
			this.Result=result;
        }
    }

	public class Book
    {
		public event Action<object?, BookEventArgs> EventCompleted;
		/// <summary>
		/// 书名
		/// </summary>
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// 查询时间
		/// </summary>
		private int duration;
		public int Duration
		{
			get { return duration; }
			set { duration = value; }
		}

		public Book( string name,int duration)
		{
			this.name = name;
			this.duration = duration;
		}

		public string Result(long millionSeconds)
		{
			return $"{Name.PadRight(12,'-')}用时:{Convert.ToSingle(millionSeconds/1000)}秒";
		}

		public string Search()
		{
			Stopwatch stopwatch	= Stopwatch.StartNew();
			Thread.Sleep(Duration * 1000);
			stopwatch.Stop();
			return Result(stopwatch.ElapsedMilliseconds);
		}

		/// <summary>
		/// 带事件的检索方法
		/// </summary>
		/// <returns></returns>
		public void SearchEvent()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			Thread.Sleep(Duration * 1000);
			stopwatch.Stop();
			EventCompleted?.Invoke(this, new BookEventArgs(Name, Result(stopwatch.ElapsedMilliseconds)));
		}

		#region 注释
		//public async Task<string> SearchAsync()
		//{
		//	Stopwatch stopwatch = new Stopwatch();
		//	await Task.Delay(Duration * 1000);
		//	stopwatch.Stop();
		//	return Result(stopwatch.ElapsedMilliseconds);
		//}
		#endregion

	}
}
