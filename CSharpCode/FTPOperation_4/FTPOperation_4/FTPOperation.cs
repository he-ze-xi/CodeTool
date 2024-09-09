
using System.IO;
using System.Net;
using System.Windows;

namespace FTPOperation_4
{
	//FTP���������ļ���ת�����ز�����������ߣ�����, southeastofstar@163.com��
	/// <summary>
	/// FTP���������ļ���ת�����ز�����������ߣ�����, southeastofstar@163.com��
	/// </summary>
	class FTPOperation
	{

		// �ϴ��ļ���FTP������
		/// <summary>
		/// �ϴ��ļ���FTP������
		/// </summary>
		/// <param name="fileinfo">��Ҫ�ϴ����ļ�</param>
		/// <param name="targetDir">FTP������Ŀ��·��</param>
		/// <param name="hostname">FTP��������ַ</param>
		/// <param name="username">FTP�������û���¼��</param>
		/// <param name="password">FTP�������û���¼����</param>
		public static void UploadFile(FileInfo fileinfo, string targetDir, string hostname, string username, string password)
		{
			//1. check target
			string target;
			if (targetDir.Trim() == "")
			{
				return;
			}
			target = Guid.NewGuid().ToString();  //ʹ����ʱ�ļ���


			string URI = "FTP://" + hostname + "/" + targetDir + "/" + target;
			//WebClient webcl = new WebClient();
			System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);

			//����FTP���� ������Ҫִ�е�FTP���
			//ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectoryDetails;//����˴�Ϊ��ʾָ��·���µ��ļ��б�
			ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
			//ָ���ļ��������������
			ftp.UseBinary = true;
			ftp.UsePassive = true;

			//����ftp�ļ���С
			ftp.ContentLength = fileinfo.Length;
			//�����С����Ϊ2KB
			const int BufferSize = 2048;
			byte[] content = new byte[BufferSize - 1 + 1];
			int dataRead;

			//��һ���ļ��� (System.IO.FileStream) ȥ���ϴ����ļ�
			using (FileStream fs = fileinfo.OpenRead())
			{
				try
				{
					//���ϴ����ļ�д����
					using (Stream rs = ftp.GetRequestStream())
					{
						do
						{
							//ÿ�ζ��ļ�����2KB
							dataRead = fs.Read(content, 0, BufferSize);
							rs.Write(content, 0, dataRead);
						} while (!(dataRead < BufferSize));
						rs.Close();
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					fs.Close();
				}

			}

			ftp = null;
			//����FTP����
			ftp = GetRequest(URI, username, password);
			ftp.Method = System.Net.WebRequestMethods.Ftp.Rename; //����
			ftp.RenameTo = fileinfo.Name;
			try
			{
				ftp.GetResponse();
			}
			catch (Exception ex)
			{
				ftp = GetRequest(URI, username, password);
				ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile; //ɾ��
				ftp.GetResponse();
				throw ex;
			}
			finally
			{
				//fileinfo.Delete();
			}

			// ���Լ�¼һ����־  "�ϴ�" + fileinfo.FullName + "�ϴ���" + "FTP://" + hostname + "/" + targetDir + "/" + fileinfo.Name + "�ɹ�." );
			ftp = null;

			#region
			/*****
             *FtpWebResponse
             * ****/
			//FtpWebResponse ftpWebResponse = (FtpWebResponse)ftp.GetResponse();
			#endregion
		}

		//�����ļ�
		/// <summary>
		/// �����ļ�
		/// </summary>
		/// <param name="localDir">����������·��</param>
		/// <param name="FtpDir">ftpĿ���ļ�·��</param>
		/// <param name="FtpFile">��ftpҪ���ص��ļ���</param>
		/// <param name="hostname">ftp��ַ��IP</param>
		/// <param name="username">ftp�û���</param>
		/// <param name="password">ftp����</param>
		public static void DownloadFile(string localDir, string FtpDir, string FtpFile, string hostname, string username, string password)
		{
			string URI = "FTP://" + hostname + "/" + FtpDir + "/" + FtpFile;
			string tmpname = Guid.NewGuid().ToString();
			string localfile = localDir + @"\" + tmpname;

			System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
			ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
			ftp.UseBinary = true;
			ftp.UsePassive = false;

			using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
			{
				using (Stream responseStream = response.GetResponseStream())
				{
					//loop to read & write to file
					using (FileStream fs = new FileStream(localfile, FileMode.CreateNew))
					{
						try
						{
							byte[] buffer = new byte[2048];
							int read = 0;
							do
							{
								read = responseStream.Read(buffer, 0, buffer.Length);
								fs.Write(buffer, 0, read);
							} while (!(read == 0));
							responseStream.Close();
							fs.Flush();
							fs.Close();
						}
						catch (Exception)
						{
							//catch error and delete file only partially downloaded
							fs.Close();
							//delete target file as it's incomplete
							File.Delete(localfile);
							throw;
						}
					}

					responseStream.Close();
				}

				response.Close();
			}



			try
			{
				File.Delete(localDir + @"\" + FtpFile);
				File.Move(localfile, localDir + @"\" + FtpFile);


				ftp = null;
				ftp = GetRequest(URI, username, password);
				ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile;
				ftp.GetResponse();

			}
			catch (Exception ex)
			{
				File.Delete(localfile);
				throw ex;
			}

			// ��¼��־ "��" + URI.ToString() + "���ص�" + localDir + @"\" + FtpFile + "�ɹ�." );
			ftp = null;
		}

		//����Զ���ļ�
		/// <summary>
		/// ����Զ���ļ�
		/// </summary>
		/// <param name="targetDir"></param>
		/// <param name="hostname"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="SearchPattern"></param>
		/// <returns></returns>
		public static List<string> ListDirectory(string targetDir, string hostname, string username, string password, string SearchPattern)
		{
			List<string> result = new List<string>();
			try
			{
				string URI = "FTP://" + hostname + "/" + targetDir + "/" + SearchPattern;

				System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
				ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;
				ftp.UsePassive = true;
				ftp.UseBinary = true;


				string str = GetStringResponse(ftp);
				str = str.Replace("\r\n", "\r").TrimEnd('\r');
				str = str.Replace("\n", "\r");
				if (str != string.Empty)
					result.AddRange(str.Split('\r'));

				return result;
			}
			catch { }
			return null;
		}

		//��ȡFTP�������ķ�������
		/// <summary>
		/// ��ȡFTP�������ķ�������
		/// </summary>
		/// <param name="ftp"></param>
		/// <returns></returns>
		private static string GetStringResponse(FtpWebRequest ftp)
		{
			//Get the result, streaming to a string
			string result = "";
			using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
			{
				long size = response.ContentLength;
				using (Stream datastream = response.GetResponseStream())
				{
					using (StreamReader sr = new StreamReader(datastream, System.Text.Encoding.Default))
					{
						result = sr.ReadToEnd();
						sr.Close();
					}

					datastream.Close();
				}

				response.Close();
			}

			return result;
		}

		//��ftp�������ϴ���Ŀ¼
		/// <summary>
		/// ��ftp�������ϴ���Ŀ¼
		/// </summary>
		/// <param name="dirName">������Ŀ¼����</param>
		/// <param name="ftpHostIP">ftp��ַ</param>
		/// <param name="username">�û���</param>
		/// <param name="password">����</param>
		public void MakeDir(string dirName, string ftpHostIP, string username, string password)
		{
			try
			{
				string uri = "ftp://" + ftpHostIP + "/" + dirName;
				System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
				ftp.Method = WebRequestMethods.Ftp.MakeDirectory;

				FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
				response.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		//ɾ��Ŀ¼
		/// <summary>
		/// ɾ��Ŀ¼
		/// </summary>
		/// <param name="dirName">������Ŀ¼����</param>
		/// <param name="ftpHostIP">ftp��ַ</param>
		/// <param name="username">�û���</param>
		/// <param name="password">����</param>
		public void delDir(string dirName, string ftpHostIP, string username, string password)
		{
			try
			{
				string uri = "ftp://" + ftpHostIP + "/" + dirName;
				System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
				ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
				FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
				response.Close();
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

		//�ļ�������
		/// <summary>
		/// �ļ�������
		/// </summary>
		/// <param name="currentFilename">��ǰĿ¼����</param>
		/// <param name="newFilename">������Ŀ¼����</param>
		/// <param name="ftpServerIP">ftp��ַ</param>
		/// <param name="username">�û���</param>
		/// <param name="password">����</param>
		public void Rename(string currentFilename, string newFilename, string ftpServerIP, string username, string password)
		{
			try
			{

				FileInfo fileInf = new FileInfo(currentFilename);
				string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
				System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
				ftp.Method = WebRequestMethods.Ftp.Rename;

				ftp.RenameTo = newFilename;
				FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();

				response.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="URI"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		private static FtpWebRequest GetRequest(string URI, string username, string password)
		{
			//���ݷ�������ϢFtpWebRequest������Ķ���
			FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
			//�ṩ�����֤��Ϣ
			result.Credentials = new System.Net.NetworkCredential(username, password);
			//�����������֮���Ƿ񱣳ֵ�FTP�������Ŀ������ӣ�Ĭ��ֵΪtrue
			result.KeepAlive = false;
			return result;
		}

		///// <summary>
		///// ��Ftp�������ϴ��ļ��������ͱ�����ͬ��Ŀ¼�ṹ
		///// ����Ŀ¼����Ŀ¼���ļ�
		///// </summary>
		///// <param name="file"></param>
		//private void GetFileSystemInfos(FileSystemInfo file)
		//    {
		//    string getDirecName = file.Name;
		//    if (!ftpIsExistsFile(getDirecName, "192.168.0.172", "Anonymous", "") && file.Name.Equals(FileName))
		//        {
		//        MakeDir(getDirecName, "192.168.0.172", "Anonymous", "");
		//        }
		//    if (!file.Exists) return;
		//    DirectoryInfo dire = file as DirectoryInfo;
		//    if (dire == null) return;
		//    FileSystemInfo[] files = dire.GetFileSystemInfos();

		//    for (int i = 0; i < files.Length; i++)
		//        {
		//        FileInfo fi = files[i] as FileInfo;
		//        if (fi != null)
		//            {
		//            DirectoryInfo DirecObj = fi.Directory;
		//            string DireObjName = DirecObj.Name;
		//            if (FileName.Equals(DireObjName))
		//                {
		//                UploadFile(fi, DireObjName, "192.168.0.172", "Anonymous", "");
		//                }
		//            else
		//                {
		//                Match m = Regex.Match(files[i].FullName, FileName + "+.*" + DireObjName);
		//                //UploadFile(fi, FileName+"/"+DireObjName, "192.168.0.172", "Anonymous", "");
		//                UploadFile(fi, m.ToString(), "192.168.0.172", "Anonymous", "");
		//                }
		//            }
		//        else
		//            {
		//            string[] ArrayStr = files[i].FullName.Split('\\');
		//            string finame = files[i].Name;
		//            Match m = Regex.Match(files[i].FullName, FileName + "+.*" + finame);
		//            //MakeDir(ArrayStr[ArrayStr.Length - 2].ToString() + "/" + finame, "192.168.0.172", "Anonymous", "");
		//            MakeDir(m.ToString(), "192.168.0.172", "Anonymous", "");
		//            GetFileSystemInfos(files[i]);
		//            }
		//        }
		//    }

		//�ж�ftp�������ϸ�Ŀ¼�Ƿ����
		/// <summary>
		/// �ж�ftp�������ϸ�Ŀ¼�Ƿ����
		/// </summary>
		/// <param name="dirName"></param>
		/// <param name="ftpHostIP"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		private bool FTPFileExist(string dirName, string ftpHostIP, string username, string password)
		{
			bool flag = true;
			try
			{
				string uri = "ftp://" + ftpHostIP + "/" + dirName;
				System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
				ftp.Method = WebRequestMethods.Ftp.ListDirectory;

				FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
				response.Close();
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

	}//class

}
