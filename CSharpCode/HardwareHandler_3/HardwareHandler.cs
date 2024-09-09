﻿using System.Management;
using System.Net;

namespace HardwareHandler
{
	/// <summary>
	/// 获取客户端计算机硬件及系统信息帮助类
	/// </summary>
	public class HardwareHandler
	{
		public HardwareHandler()
		{
		}
		/// <summary>
		/// Cpu信息
		/// </summary>
		/// <returns></returns>
		public void CpuInfo()
		{
			try
			{
				ManagementClass mc = new ManagementClass(WMIPath.Win32_Processor.ToString());
				ManagementObjectCollection moc = mc.GetInstances();
				foreach (ManagementObject mo in moc)
				{
					Console.WriteLine("CPU编号：" + mo.Properties["ProcessorId"].Value);
					Console.WriteLine("CPU型号：" + mo.Properties["Name"].Value);
					Console.WriteLine("CPU状态：" + mo.Properties["Status"].Value);
					Console.WriteLine("主机名称：" + mo.Properties["SystemName"].Value);
				}
			}
			catch
			{
				Console.WriteLine("Erroe");
			}
		}

		/// <summary>
		/// 主板信息
		/// </summary>
		public void MainBoardInfo()
		{
			try
			{
				ManagementClass mc = new ManagementClass(WMIPath.Win32_BaseBoard.ToString());
				ManagementObjectCollection moc = mc.GetInstances();
				foreach (ManagementObject mo in moc)
				{
					Console.WriteLine("主板ID：" + mo.Properties["SerialNumber"].Value);
					Console.WriteLine("制造商：" + mo.Properties["Manufacturer"].Value);
					Console.WriteLine("型号：" + mo.Properties["Product"].Value);
					Console.WriteLine("版本：" + mo.Properties["Version"].Value);
				}
			}
			catch
			{
				Console.WriteLine("Erroe");
			}
		}

		/// <summary>
		/// 硬盘信息
		/// </summary>
		public void DiskDriveInfo()
		{
			try
			{
				ManagementClass mc = new ManagementClass(WMIPath.Win32_DiskDrive.ToString());
				ManagementObjectCollection moc = mc.GetInstances();
				foreach (ManagementObject mo in moc)
				{
					Console.WriteLine("硬盘SN：" + mo.Properties["SerialNumber"].Value);
					Console.WriteLine("型号：" + mo.Properties["Model"].Value);
					Console.WriteLine("大小：" + Convert.ToDouble(mo.Properties["Size"].Value) / (1024 * 1024 * 1024));
				}
			}
			catch
			{
				Console.WriteLine("Erroe");
			}
		}

		/// <summary>
		/// 获取当前服务器或本地电脑的默认ip信息
		/// </summary>
		/// <returns></returns>
		public void GetDefaultIP()
		{
			try
			{
				IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
				IPAddress ipAddr = ipHost.AddressList[0];
				Console.WriteLine("本机IP地址：" + ipAddr.ToString());
			}
			catch (Exception exp)
			{ }
		}
		/// <summary>
		/// 操作系统信息 
		/// </summary>
		public void OsInfo()
		{
			try
			{
				ManagementClass mc = new ManagementClass(WMIPath.Win32_OperatingSystem.ToString());
				ManagementObjectCollection moc = mc.GetInstances();
				foreach (ManagementObject mo in moc)
				{
					Console.WriteLine("操作系统：" + mo.Properties["Name"].Value);
					Console.WriteLine("版本：" + mo.Properties["Version"].Value);
					Console.WriteLine("系统目录：" + mo.Properties["SystemDirectory"].Value);
				}
			}
			catch
			{
				Console.WriteLine("Erroe");
			}
		}
	}
	public enum WMIPath
	{
		// 硬件 
		Win32_Processor,         // CPU 处理器 
		Win32_PhysicalMemory,    // 物理内存条 
		Win32_Keyboard,          // 键盘 
		Win32_PointingDevice,    // 点输入设备，包括鼠标。 
		Win32_FloppyDrive,       // 软盘驱动器 
		Win32_DiskDrive,         // 硬盘驱动器 
		Win32_CDROMDrive,        // 光盘驱动器 
		Win32_BaseBoard,         // 主板 
		Win32_BIOS,              // BIOS 芯片 
		Win32_ParallelPort,      // 并口 
		Win32_SerialPort,        // 串口 
		Win32_SerialPortConfiguration, // 串口配置 
		Win32_SoundDevice,       // 多媒体设置，一般指声卡。 
		Win32_SystemSlot,        // 主板插槽 (ISA & PCI & AGP) 
		Win32_USBController,     // USB 控制器 
		Win32_NetworkAdapter,    // 网络适配器 
		Win32_NetworkAdapterConfiguration, // 网络适配器设置 
		Win32_Printer,           // 打印机 
		Win32_PrinterConfiguration, // 打印机设置 
		Win32_PrintJob,          // 打印机任务 
		Win32_TCPIPPrinterPort,  // 打印机端口 
		Win32_POTSModem,         // MODEM 
		Win32_POTSModemToSerialPort, // MODEM 端口 
		Win32_DesktopMonitor,    // 显示器 
		Win32_DisplayConfiguration, // 显卡 
		Win32_DisplayControllerConfiguration, // 显卡设置 
		Win32_VideoController,  // 显卡细节。 
		Win32_VideoSettings,    // 显卡支持的显示模式。 

		// 操作系统 
		Win32_TimeZone,         // 时区 
		Win32_SystemDriver,     // 驱动程序 
		Win32_DiskPartition,    // 磁盘分区 
		Win32_LogicalDisk,      // 逻辑磁盘 
		Win32_LogicalDiskToPartition,     // 逻辑磁盘所在分区及始末位置。 
		Win32_LogicalMemoryConfiguration, // 逻辑内存配置 
		Win32_PageFile,         // 系统页文件信息 
		Win32_PageFileSetting,  // 页文件设置 
		Win32_BootConfiguration, // 系统启动配置 
		Win32_ComputerSystem,   // 计算机信息简要 
		Win32_OperatingSystem,  // 操作系统信息 
		Win32_StartupCommand,   // 系统自动启动程序 
		Win32_Service,          // 系统安装的服务 
		Win32_Group,            // 系统管理组 
		Win32_GroupUser,        // 系统组帐号 
		Win32_UserAccount,      // 用户帐号 
		Win32_Process,          // 系统进程 
		Win32_Thread,           // 系统线程 
		Win32_Share,            // 共享 
		Win32_NetworkClient,    // 已安装的网络客户端 
		Win32_NetworkProtocol,  // 已安装的网络协议 
	}


	public class Client
	{
		public static void Main()
		{
			HardwareHandler hardwareHandler = new HardwareHandler();
			hardwareHandler.CpuInfo();
			hardwareHandler.MainBoardInfo();
			hardwareHandler.DiskDriveInfo();
			hardwareHandler.GetDefaultIP();
			hardwareHandler.OsInfo();
		}
	}
}
