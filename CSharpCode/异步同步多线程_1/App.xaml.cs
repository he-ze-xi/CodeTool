using 异步同步多线程_1.Views;
using Prism.Ioc;
using System.Windows;

namespace _1.异步同步多线程
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}
	}
}
