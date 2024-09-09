
using Microsoft.VisualBasic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using ComboBox = System.Windows.Forms.ComboBox;
using Control = System.Windows.Forms.Control;
using Image = System.Drawing.Image;
using ListBox = System.Windows.Forms.ListBox;
using ListView = System.Windows.Forms.ListView;
using TreeView = System.Windows.Forms.TreeView;

namespace FileHelper
{
	public class FileHelper
	{

		/// <summary>
		/// 程序运行过程中的错误信息提示
		/// </summary>
		public string ErrorMessage = "";

		Microsoft.VisualBasic.Devices.Computer PC = new Microsoft.VisualBasic.Devices.Computer();


		/// <summary>
		/// 检查目录是否存在，如果目录不存在，是否创建目录
		/// </summary>
		/// <param name="TargetPath">目录路径字符串，如果不指定带盘符的绝对路径，就会在当前程序的目录下创建目录</param>
		/// <param name="CreateDirectoryIfNotExist">如果目录不存在，是否创建目录(默认创建)</param>
		/// <returns>目录是否存在</returns>
		public static bool VerifyPathExist(string TargetPath, bool CreateDirectoryIfNotExist = true)
		{
			try
			{
				if (null == TargetPath || "" == TargetPath)
				{
					return false;
				}

				string sPath = Path.GetDirectoryName(TargetPath);
				if (null == sPath || "" == sPath)
				{
					return false;
				}

				if (Directory.Exists(sPath) == false)
				{
					if (CreateDirectoryIfNotExist == false)
					{
						return false;
					}
					else
					{
						System.IO.Directory.CreateDirectory(TargetPath);
					}
				}

				//下面的方法有缺陷
				//System.IO.DirectoryInfo PathInfo = new DirectoryInfo(TargetPath);
				//if (PathInfo.Exists == false)
				//{
				//if (CreateDirectoryIfNotExist == false)
				//{
				//    return false;
				//}
				//else
				//{
				//    System.IO.Directory.CreateDirectory(TargetPath);
				//}
				//}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		/// <summary>
		/// 保存记录到 txt 文件
		/// </summary>
		/// <param name="TargetTextFileName">目标 txt 文件名称和路径(必须带.txt扩展名)</param>
		/// <param name="ContentsToBeWrote">需要保存到文件的内容</param>
		/// <param name="AddDateAsPrefix">是否添加日期前缀到记录</param>
		/// <returns></returns>
		public static bool SaveTxtFile(string TargetTextFileName, string ContentsToBeWrote, bool AddDateAsPrefix = false)
		{
			try
			{
				if (null == TargetTextFileName || null == ContentsToBeWrote
					|| "" == TargetTextFileName || "" == ContentsToBeWrote)
				{
					return false;
				}

				if (VerifyPathExist(TargetTextFileName) == false)
				{
					return false;
				}

				FileInfo tempInfo = new FileInfo(TargetTextFileName);
				if (tempInfo.Extension.ToUpper() != ".TXT")
				{
					return false;
				}
				if (tempInfo.Exists == false)
				{
					FileStream tempStream = tempInfo.Create();
					tempStream.Close();
					tempStream.Dispose();
				}

				tempInfo = null;

				string[] sTempArray = new string[1];
				if (AddDateAsPrefix == true)
				{
					sTempArray[0] = DateAndTime.Now.ToString() + "\t" + ContentsToBeWrote;
				}
				else
				{
					sTempArray[0] = ContentsToBeWrote;
				}

				File.AppendAllLines(TargetTextFileName, sTempArray, Encoding.Unicode);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 保存Winforms下的的控件名字到 txt 文件
		/// </summary>
		/// <param name="TargetTextFileName">目标 txt 文件名称和路径(必须带.txt扩展名)</param>
		/// <param name="TargetControl">目标控件</param>
		public static void SaveAllControlNamesAndItsText(string TargetTextFileName, Control TargetControl)
		{
			try
			{
				//SaveTxtFile(TargetTextFileName, TargetControl.Name + "\t" + TargetControl.Text);

				if (TargetControl is MenuStrip)
				{
					//菜单
					MenuStrip tempMenu = TargetControl as MenuStrip;
					SaveTxtFile(TargetTextFileName, tempMenu.Name + "\t" + tempMenu.Text);
					foreach (ToolStripMenuItem item in tempMenu.Items)
					{
						if (null != item)
						{
							SaveTxtFile(TargetTextFileName, item.Name + "\t" + item.Text);
							if (null != item.DropDownItems && item.DropDownItems.Count > 0)
							{
								foreach (ToolStripMenuItem subitem in item.DropDownItems)
								{
									if (null != subitem)
									{
										SaveTxtFile(TargetTextFileName, subitem.Name + "\t" + subitem.Text);
									}
								}
							}
						}
					}
				}
				else if (TargetControl is StatusStrip)
				{
					//状态栏
					StatusStrip tempStatusStrip = TargetControl as StatusStrip;
					SaveTxtFile(TargetTextFileName, tempStatusStrip.Name + "\t" + tempStatusStrip.Text);
					foreach (ToolStripStatusLabel item in tempStatusStrip.Items)
					{
						if (null != item)
						{
							SaveTxtFile(TargetTextFileName, item.Name + "\t" + item.Text);
						}
					}
				}
				else if (TargetControl is ToolStrip)//如果传入的控件是StatusStrip，这里的判断条件也是 true，这可能是因为继承的关系
				{
					//工具栏按钮
					ToolStrip tempToolStrip = TargetControl as ToolStrip;
					SaveTxtFile(TargetTextFileName, tempToolStrip.Name + "\t" + tempToolStrip.Text);
					foreach (ToolStripButton item in tempToolStrip.Items)
					{
						if (null != item)
						{
							SaveTxtFile(TargetTextFileName, item.Name + "\t" + item.Text);
						}
					}
				}
				else if (TargetControl is Form)
				{
					//窗体
					SaveTxtFile(TargetTextFileName, TargetControl.Name + "\t" + TargetControl.Text);
					foreach (Control item in TargetControl.Controls)
					{
						if (null != item)
						{
							if (item.HasChildren == true)
							{
								SaveTxtFile(TargetTextFileName, item.Name + "\t" + item.Text);
								SaveAllControlNamesAndItsText(TargetTextFileName, item);
							}
							else
							{
								SaveTxtFile(TargetTextFileName, item.Name + "\t" + item.Text);
							}
						}
					}
				}
				else if (TargetControl is DataGridView)
				{
					//DataGridView
					DataGridView tempDataGridView = TargetControl as DataGridView;
					SaveTxtFile(TargetTextFileName, tempDataGridView.Name + "\t" + tempDataGridView.Text);
					foreach (DataGridViewColumn item in tempDataGridView.Columns)
					{
						if (null != item)
						{
							SaveTxtFile(TargetTextFileName, item.Name + "\t" + item.HeaderText);
						}
					}
				}
				else if (TargetControl is TreeView)
				{
					//TreeView
					TreeView tempTreeView = TargetControl as TreeView;
					SaveTxtFile(TargetTextFileName, tempTreeView.Name + "\t" + tempTreeView.Text);
					if (tempTreeView.Nodes.Count > 0)
					{
						tempTreeView.SuspendLayout();
						TreeNode[] tempTreeNodes = new TreeNode[tempTreeView.Nodes.Count];
						for (int i = 0; i < tempTreeView.Nodes.Count; i++)
						{
							SaveTxtFile(TargetTextFileName, tempTreeView.Nodes[i].Name + "\t" + tempTreeView.Nodes[i].Text);
						}
					}
				}
				else if (TargetControl is CheckedListBox)
				{
					//CheckedListBox
					CheckedListBox tempCheckedListBox = TargetControl as CheckedListBox;
					SaveTxtFile(TargetTextFileName, tempCheckedListBox.Name + "\t" + tempCheckedListBox.Text);
					if (tempCheckedListBox.Items.Count > 0)
					{
						for (int i = 0; i < tempCheckedListBox.Items.Count; i++)
						{
							SaveTxtFile(TargetTextFileName, tempCheckedListBox.Items[i].ToString());
						}
					}
				}
				else if (TargetControl is ListBox)
				{
					//ListBox
					ListBox tempListBox = TargetControl as ListBox;
					SaveTxtFile(TargetTextFileName, tempListBox.Name + "\t" + tempListBox.Text);
					if (tempListBox.Items.Count > 0)
					{
						//发生错误：值不能为 null。
						//参数名: item;    在 System.Windows.Forms.ListBox.ObjectCollection.AddInternal(Object item)

						for (int i = 0; i < tempListBox.Items.Count; i++)
						{
							SaveTxtFile(TargetTextFileName, tempListBox.Items[i] + "\t");
						}
					}
				}
				else if (TargetControl is ListView)
				{
					//ListView
					ListView tempListView = TargetControl as ListView;
					SaveTxtFile(TargetTextFileName, tempListView.Name + "\t" + tempListView.Text);
					if (tempListView.Items.Count > 0)
					{
						//ListViewItem[] tempTreeNodes = new ListViewItem[tempListView.Items.Count];
						for (int i = 0; i < tempListView.Items.Count; i++)
						{
							SaveTxtFile(TargetTextFileName, tempListView.Items[i].Name + "\t" + tempListView.Items[i].Text);
						}
					}
					else if (TargetControl is ComboBox)
					{
						//ComboBox
						ComboBox tempComboBox = TargetControl as ComboBox;
						SaveTxtFile(TargetTextFileName, tempComboBox.Name + "\t" + tempComboBox.Text);
						if (tempComboBox.Items.Count > 0)
						{
							// 发生错误：值不能为 null。
							// 参数名: item;    在 System.Windows.Forms.ComboBox.ObjectCollection.AddInternal(Object item)

							for (int i = 0; i < tempComboBox.Items.Count; i++)
							{
								SaveTxtFile(TargetTextFileName, tempComboBox.Items[i].ToString() + "\t");
							}
						}
					}
					else
					{
						if (TargetControl.HasChildren == true)
						{
							SaveTxtFile(TargetTextFileName, TargetControl.Name + "\t" + TargetControl.Text);
							foreach (Control item in TargetControl.Controls)
							{
								if (null != item)
								{
									SaveTxtFile(TargetTextFileName, item.Name + "\t" + item.Text);
									if (item.HasChildren == true)
									{
										SaveAllControlNamesAndItsText(TargetTextFileName, item);
									}
								}
							}
						}
						else
						{
							SaveTxtFile(TargetTextFileName, TargetControl.Name + "\t" + TargetControl.Text);
						}
					}
				}
			}
			catch (Exception)
			{
				//throw ex;
				//ErrorMessage.Enqueue(DateTime.Now.ToString() + "*-*" + "发生错误：" + ex.Message + "; " + ex.StackTrace);
			}

		}


		/// <summary>
		/// 将源文件夹下的文件含子文件夹复制到目标文件夹中
		/// </summary>
		/// <param name="SourcePath"></param>
		/// <param name="TargetPath"></param>
		/// <returns></returns>
		public static bool CopyDirectory(string SourcePath, string TargetPath)
		{
			try
			{
				// 检查目标目录是否以目录分割字符结束如果不是则添加
				if (TargetPath[TargetPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
				{
					TargetPath += System.IO.Path.DirectorySeparatorChar;
				}

				// 判断目标目录是否存在如果不存在则新建
				if (System.IO.Directory.Exists(TargetPath) == false)
				{
					System.IO.Directory.CreateDirectory(TargetPath);
				}

				// 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
				// 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
				// string[] fileList = Directory.GetFiles（SourcePath）；
				string[] fileList = System.IO.Directory.GetFileSystemEntries(SourcePath);

				// 遍历所有的文件和目录
				foreach (string file in fileList)
				{
					// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
					if (System.IO.Directory.Exists(file) == true)
					{
						CopyDirectory(file, TargetPath + System.IO.Path.GetFileName(file));
					}
					// 否则直接Copy文件
					else
					{
						System.IO.File.Copy(file, TargetPath + System.IO.Path.GetFileName(file), true);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("备份参数文件发生错误：" + ex.Message + " ;" + ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;
		}


		//保存Image图像至BMP文件
		/// <summary>
		/// 保存Image图像至BMP文件
		/// </summary>
		/// <param name="TargetImage">目标图像Image对象</param>
		/// <param name="FileName">文件名称</param>
		/// <returns>是否成功保存</returns>
		public bool SaveImageToFile(Image TargetImage, string FileName)//, System.Drawing.Imaging.ImageFormat【不能继承】 TargetImageFormat=System.Drawing.Imaging.ImageFormat.Bmp)
		{
			Image TempImage = null;
			try
			{
				if (TargetImage == null)
				{
					ErrorMessage = "The parameter 'TargetImage' is null";
					return false;
				}

				if (FileName == "")
				{
					ErrorMessage = "The parameter 'FileName' can't be empty";
					return false;
				}

				if (FileName.ToUpper().IndexOf(".BMP") == -1)
				{
					FileName = FileName + ".BMP";
				}

				TempImage = new System.Drawing.Bitmap(TargetImage);
				TempImage.Save(FileName, System.Drawing.Imaging.ImageFormat.Bmp);
				TempImage.Dispose();
				return true;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return false;
			}
		}

		//Ping服务器并指定超时
		/// <summary>
		/// Ping服务器并指定超时
		/// </summary>
		/// <param name="TargetRemoteServer">服务器IP地址或者URI或者计算机名称</param>
		/// <param name="PingOverTime">连接超时【单位：毫秒】</param>
		/// <returns>是否连接成功</returns>
		public bool Ping(string TargetRemoteServer, uint PingOverTime = 10)
		{
			try
			{
				if (PC.Network.Ping(TargetRemoteServer, (int)PingOverTime) == true)
				{
					return true;
				}
				else
				{
					ErrorMessage = "没有建立网络连接，或者服务器IP地址/URI/计算机名称不正确";
					return false;
				}
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return false;
			}
		}

		//复制源文件到目标文件【写2进制方式】
		/// <summary>
		/// 复制源文件到目标文件【写2进制方式】
		/// </summary>
		/// <param name="SourceFile">源文件</param>
		/// <param name="TargetFile">目标文件</param>
		/// <param name="OverWrite">是否覆盖</param>
		/// <returns>是否执行成功</returns>
		public bool CopyFileByBinary(string SourceFile, string TargetFile,
			bool OverWrite = false)
		{
			try
			{
				if (SourceFile == "")
				{
					ErrorMessage = "The parameter 'SourceFile' can't be empty, please check and revise it.";
					return false;
				}

				if (TargetFile == "")
				{
					ErrorMessage = "The parameter 'TargetFile' can't be empty, please check and revise it.";
					return false;
				}

				if (System.IO.File.Exists(SourceFile) == false)
				{
					ErrorMessage = "The source file '" + SourceFile + "' doesn't exist, please check.";
					return false;
				}

				//执行覆盖写操作，所以先删除原有目标文件
				if (OverWrite == true && System.IO.File.Exists(TargetFile) == true)
				{
					System.IO.File.Delete(TargetFile);
				}

				//如果不是执行覆盖写操作，且目标文件不存在就新建文件
				if (OverWrite == false && System.IO.File.Exists(TargetFile) == false)
				{
					System.IO.File.Create(TargetFile);
				}

				byte[] WriteBuffer = new byte[1024];
				FileStream OpenFileStream = System.IO.File.Open(SourceFile, FileMode.Open);

				//按照一定长度读取源文件的字节并写入到目标文件中
				while (OpenFileStream.Read(WriteBuffer, 0, 1024) > 0)
				{
					PC.FileSystem.WriteAllBytes(TargetFile, WriteBuffer, true);
				}
				OpenFileStream.Close();
				OpenFileStream.Dispose();
				return true;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return false;
			}
		}

		//弹出“打开文件”对话框，从TXT文本文件读取字符串，以行为单位，跳过空行
		/// <summary>
		/// 弹出“打开文件”对话框，从TXT文本文件读取字符串，以行为单位，跳过空行
		/// </summary>
		/// <param name="TXTFileName">TXT文本文件名称</param>
		/// <returns></returns>
		public string[] ReadLinesFromTXTFile()
		{
			string[] ReadLines = { "" };
			string TXTFileName = "";
			try
			{
				OpenFileDialog TempOpenFile = new OpenFileDialog();
				TempOpenFile.Title = "打开文本文件";
				TempOpenFile.DefaultExt = "txt";
				TempOpenFile.Filter = "TXT文本文件|*.TXT";
				TempOpenFile.CheckFileExists = true;

				if (TempOpenFile.ShowDialog() == DialogResult.No || TempOpenFile.FileName == "")
				{
					return null;
				}

				TXTFileName = TempOpenFile.FileName;

				if (TXTFileName == "")
				{
					ErrorMessage = "需要保存的文本名称不能为空";
					return null;
				}

				//如果文件名称中没有".TXT"，就添加
				if (TXTFileName.ToUpper().IndexOf(".TXT") == -1)
				{
					TXTFileName = TXTFileName + ".txt";
				}

				if (PC.FileSystem.FileExists(TXTFileName) == false)
				{
					ErrorMessage = "指定的文本文件 " + TXTFileName + " 不存在";
					return null;
				}
				object LockObject = new object();

				////**************************
				//【不支持中文】
				//Microsoft.VisualBasic.FileIO.TextFieldParser TempTXTReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(TXTFileName);

				//lock (LockObject) 
				//    {
				//    //字段是分隔的
				//    //TempTXTReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;//.FixedWidth固定宽度的

				//    //以空格为分格符读取
				//    //TempTXTReader.SetDelimiters(" ");

				//    int Lines = 0;
				//    string TempStr = "";

				//    //如果在当前光标位置到文件末尾之间没有非空、非注释行，则返回 True。
				//    while (!TempTXTReader.EndOfData) 
				//        {
				//        TempStr = TempTXTReader.ReadLine();
				//        if (TempStr != null && TempStr != "\r\n" 
				//            && TempStr != "\r" && TempStr != "\n"
				//            && TempStr != "")
				//            {
				//            //重新设置数组大小，之前的值保留
				//            Array.Resize<string>(ref ReadLines, Lines + 1);

				//            ReadLines[Lines] = TempStr;
				//            Lines += 1;
				//            }                        
				//        }
				//    }

				//**************************
				//【支持中文】
				StreamReader TempSteamReader = new StreamReader(TXTFileName, Encoding.GetEncoding(936));
				lock (LockObject)
				{
					int Lines = 0;
					string TempStr = "";

					//如果在当前光标位置到文件末尾之间没有非空、非注释行，则返回 True。
					while (!TempSteamReader.EndOfStream)
					{
						TempStr = TempSteamReader.ReadLine();
						if (TempStr != null && TempStr != "\r\n"
							&& TempStr != "\r" && TempStr != "\n"
							&& TempStr != "")
						{
							//重新设置数组大小，之前的值保留
							Array.Resize<string>(ref ReadLines, Lines + 1);

							ReadLines[Lines] = TempStr;
							Lines += 1;
						}
					}
				}

				TempOpenFile.Dispose();
				LockObject = null;
				TempSteamReader.Close();
				TempSteamReader.Dispose();
				return ReadLines;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return ReadLines;
			}
		}

		//从TXT文本文件读取字符串，以行为单位，跳过空行
		/// <summary>
		/// 从TXT文本文件读取字符串，以行为单位，跳过空行
		/// </summary>
		/// <param name="TXTFileName">TXT文本文件名称</param>
		/// <returns></returns>
		public string[] ReadLinesFromTXTFile(string TXTFileName)
		{
			string[] ReadLines = { "" };
			try
			{
				if (TXTFileName == "")
				{
					ErrorMessage = "需要保存的文本名称不能为空";
					return null;
				}

				//如果文件名称中没有".TXT"，就添加
				if (TXTFileName.ToUpper().IndexOf(".TXT") == -1)
				{
					TXTFileName = TXTFileName + ".txt";
				}

				if (PC.FileSystem.FileExists(TXTFileName) == false)
				{
					ErrorMessage = "指定的文本文件 " + TXTFileName + " 不存在";
					return null;
				}
				object LockObject = new object();

				////**************************
				//【不支持中文】
				//Microsoft.VisualBasic.FileIO.TextFieldParser TempTXTReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(TXTFileName);

				//lock (LockObject) 
				//    {
				//    //字段是分隔的
				//    //TempTXTReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;//.FixedWidth固定宽度的

				//    //以空格为分格符读取
				//    //TempTXTReader.SetDelimiters(" ");

				//    int Lines = 0;
				//    string TempStr = "";

				//    //如果在当前光标位置到文件末尾之间没有非空、非注释行，则返回 True。
				//    while (!TempTXTReader.EndOfData) 
				//        {
				//        TempStr = TempTXTReader.ReadLine();
				//        if (TempStr != null && TempStr != "\r\n" 
				//            && TempStr != "\r" && TempStr != "\n"
				//            && TempStr != "")
				//            {
				//            //重新设置数组大小，之前的值保留
				//            Array.Resize<string>(ref ReadLines, Lines + 1);

				//            ReadLines[Lines] = TempStr;
				//            Lines += 1;
				//            }                        
				//        }
				//    }

				//**************************
				//【支持中文】
				StreamReader TempSteamReader = new StreamReader(TXTFileName, Encoding.GetEncoding(936));
				lock (LockObject)
				{
					int Lines = 0;
					string TempStr = "";

					//如果在当前光标位置到文件末尾之间没有非空、非注释行，则返回 True。
					while (!TempSteamReader.EndOfStream)
					{
						TempStr = TempSteamReader.ReadLine();
						if (TempStr != null && TempStr != "\r\n"
							&& TempStr != "\r" && TempStr != "\n"
							&& TempStr != "")
						{
							//重新设置数组大小，之前的值保留
							Array.Resize<string>(ref ReadLines, Lines + 1);

							ReadLines[Lines] = TempStr;
							Lines += 1;
						}
					}
				}
				LockObject = null;
				TempSteamReader.Close();
				TempSteamReader.Dispose();
				return ReadLines;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return ReadLines;
			}
		}

		//弹出“保存文件”对话框，将字符串数组写入到文本文件，会自动添加文件扩展名和回车换行符
		/// <summary>
		/// 弹出“保存文件”对话框，将字符串数组写入到文本文件，会自动添加文件扩展名
		/// </summary>
		/// <param name="TXTToBeSaved">需要被保存的文本字符串数组</param>
		/// <param name="TXTFileName">文本文件名称，可以不包括 '.TXT' 文件扩展名</param>
		/// <param name="AddToOriginalFile">是否添加到原有文件，默认是</param>
		/// <returns>是否执行成功</returns>
		public bool SaveStringToTXTFile(string[] TXTToBeSaved, bool AddToOriginalFile = true)
		{
			string TXTFileName = "";
			try
			{
				if (TXTToBeSaved == null)
				{
					ErrorMessage = "需要被保存的文本字符串数组不能为空";
					return false;
				}

				OpenFileDialog TempOpenFile = new OpenFileDialog();
				TempOpenFile.Title = "保存文本文件";
				TempOpenFile.DefaultExt = "txt";
				TempOpenFile.Filter = "TXT文本文件|*.TXT";
				TempOpenFile.CheckFileExists = true;

				if (TempOpenFile.ShowDialog() == DialogResult.No || TempOpenFile.FileName == "")
				{
					return false;
				}

				TXTFileName = TempOpenFile.FileName;

				//TXTToBeSaved += "\r\n";

				if (TXTFileName == "")
				{
					ErrorMessage = "需要保存的文本名称不能为空";
					return false;
				}

				//如果文件名称中没有".TXT"，就添加
				if (TXTFileName.ToUpper().IndexOf(".TXT") == -1)
				{
					TXTFileName = TXTFileName + ".txt";
				}

				//**********************
				//WriteLine(String)	将后跟行结束符的字符串写入文本流。 （继承自 TextWriter。）
				System.IO.StreamWriter TempStreamWriter = new StreamWriter(TXTFileName, AddToOriginalFile, Encoding.GetEncoding(936));//与Encoding.GetEncoding("GB2312")等效
				for (int a = 0; a < TXTToBeSaved.Length; a++)
				{
					//此处不添加判断某个[]是否为""，这样对于处理有规律数据在读取的时候有很大好处
					TempStreamWriter.WriteLine(TXTToBeSaved[a]);
				}

				TempStreamWriter.Flush();
				TempStreamWriter.Close();
				TempStreamWriter.Dispose();
				TempOpenFile.Dispose();
				return true;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return false;
			}
		}

		//将字符串写入到文本文件，会自动添加文件扩展名和回车换行符
		/// <summary>
		/// 将字符串写入到文本文件，会自动添加文件扩展名
		/// </summary>
		/// <param name="TXTToBeSaved">需要被保存的文本字符串</param>
		/// <param name="TXTFileName">文本文件名称，可以不包括 '.TXT' 文件扩展名</param>
		/// <param name="AddToOriginalFile">是否添加到原有文件，默认是</param>
		/// <returns>是否执行成功</returns>
		public bool SaveStringToTXTFile(string TXTToBeSaved, string TXTFileName, bool AddToOriginalFile = true)
		{
			try
			{
				if (TXTToBeSaved == "")
				{
					ErrorMessage = "需要被保存的文本字符串不能为空";
					return false;
				}

				//TXTToBeSaved += "\r\n";

				if (TXTFileName == "")
				{
					ErrorMessage = "需要保存的文本名称不能为空";
					return false;
				}

				//如果文件名称中没有".TXT"，就添加
				if (TXTFileName.ToUpper().IndexOf(".TXT") == -1)
				{
					TXTFileName = TXTFileName + ".txt";
				}

				//**********************
				//FileSystemProxy .WriteAllText 方法 (String, String, Boolean)
				//FileSystemProxy .WriteAllText 方法 (String, String, Boolean, Encoding)
				//向文件写入文本
				//使用 UTF-8 编码方式来写入此文件。若要指定其他编码，请使用 WriteAllText () 方法的其他重载。

				//如果指定的文件不存在，则创建该文件。

				//如果指定的编码方式与文件的现有编码方式不匹配，则忽略指定的编码方式。
				//WriteAllText 方法将打开一个文件，向其写入内容，然后将其关闭。 
				//使用 WriteAllText 方法的代码比使用 StreamWriter 对象的代码更加简单。 
				//但是，如果您使用循环将字符串添加到文件中，则 StreamWriter 对象能够提供更优异的性能，因为您只需打开和关闭该文件一次。

				////用中文GB2312保存，或者UTF-8也行
				//PC.FileSystem.WriteAllText(TXTFileName, TXTToBeSaved, AddToOriginalFile,Encoding.GetEncoding("GB2312"));
				////PC.FileSystem.WriteAllText(TXTFileName, TXTToBeSaved, AddToOriginalFile, Encoding.UTF8);

				//**********************
				//WriteLine(String)	将后跟行结束符的字符串写入文本流。 （继承自 TextWriter。）
				System.IO.StreamWriter TempStreamWriter = new StreamWriter(TXTFileName, AddToOriginalFile, Encoding.GetEncoding(936));//与Encoding.GetEncoding("GB2312")等效
				TempStreamWriter.WriteLine(TXTToBeSaved);
				TempStreamWriter.Flush();
				TempStreamWriter.Close();
				return true;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return false;
			}
		}

		//弹出“保存文件”对话框，将字符串写入到文本文件，会自动添加文件扩展名和回车换行符
		/// <summary>
		/// 弹出“保存文件”对话框，将字符串写入到文本文件，会自动添加文件扩展名
		/// </summary>
		/// <param name="TXTToBeSaved">需要被保存的文本字符串</param>
		/// <param name="TXTFileName">文本文件名称，可以不包括 '.TXT' 文件扩展名</param>
		/// <param name="AddToOriginalFile">是否添加到原有文件，默认是</param>
		/// <returns>是否执行成功</returns>
		public bool SaveStringToTXTFile(string TXTToBeSaved, bool AddToOriginalFile = true)
		{
			string TXTFileName = "";
			try
			{
				if (TXTToBeSaved == "")
				{
					ErrorMessage = "需要被保存的文本字符串不能为空";
					return false;
				}

				//TXTToBeSaved += "\r\n";

				OpenFileDialog TempOpenFile = new OpenFileDialog();
				TempOpenFile.Title = "保存文本文件";
				TempOpenFile.DefaultExt = "txt";
				TempOpenFile.Filter = "TXT文本文件|*.TXT";
				TempOpenFile.CheckFileExists = true;

				if (TempOpenFile.ShowDialog() == DialogResult.No || TempOpenFile.FileName == "")
				{
					return false;
				}

				TXTFileName = TempOpenFile.FileName;

				if (TXTFileName == "")
				{
					ErrorMessage = "需要保存的文本名称不能为空";
					return false;
				}

				//如果文件名称中没有".TXT"，就添加
				if (TXTFileName.ToUpper().IndexOf(".TXT") == -1)
				{
					TXTFileName = TXTFileName + ".txt";
				}

				//**********************
				//FileSystemProxy .WriteAllText 方法 (String, String, Boolean)
				//FileSystemProxy .WriteAllText 方法 (String, String, Boolean, Encoding)
				//向文件写入文本
				//使用 UTF-8 编码方式来写入此文件。若要指定其他编码，请使用 WriteAllText () 方法的其他重载。

				//如果指定的文件不存在，则创建该文件。

				//如果指定的编码方式与文件的现有编码方式不匹配，则忽略指定的编码方式。
				//WriteAllText 方法将打开一个文件，向其写入内容，然后将其关闭。 
				//使用 WriteAllText 方法的代码比使用 StreamWriter 对象的代码更加简单。 
				//但是，如果您使用循环将字符串添加到文件中，则 StreamWriter 对象能够提供更优异的性能，因为您只需打开和关闭该文件一次。

				////用中文GB2312保存，或者UTF-8也行
				//PC.FileSystem.WriteAllText(TXTFileName, TXTToBeSaved, AddToOriginalFile,Encoding.GetEncoding("GB2312"));
				////PC.FileSystem.WriteAllText(TXTFileName, TXTToBeSaved, AddToOriginalFile, Encoding.UTF8);

				//**********************
				//WriteLine(String)	将后跟行结束符的字符串写入文本流。 （继承自 TextWriter。）
				System.IO.StreamWriter TempStreamWriter = new StreamWriter(TXTFileName, AddToOriginalFile, Encoding.GetEncoding(936));//与Encoding.GetEncoding("GB2312")等效
				TempStreamWriter.WriteLine(TXTToBeSaved);
				TempStreamWriter.Flush();
				TempStreamWriter.Close();
				TempStreamWriter.Dispose();
				TempOpenFile.Dispose();
				return true;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return false;
			}
		}

	}

}
