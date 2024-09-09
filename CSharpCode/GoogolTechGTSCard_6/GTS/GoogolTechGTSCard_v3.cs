using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogolTechGTSCard_6.GTS.GoogolTechGTSCard_v1.GTSAxisControl;
using System.Windows.Media.Imaging;
using static System.Windows.Forms.AxHost;

namespace GoogolTechGTSCard_6.GTS
{
//	class MoSionContrl
//	{
//		/// <summary>
//		/// 根据卡号和轴号获取轴参数
//		/// </summary>
//		public static AXISParsa GetAXISParsa(short card, short axis)
//		{
//			try
//			{
//				return SystemPara.Instance.dicaxisparas[$"card{card}axis{axis}"];
//			}
//			catch
//			{
//				return new AXISParsa();
//			}
//		}
//		/// <summary>
//		/// 按顺序移动轴
//		/// </summary>
//		public static void MoveAxis(this MoStation MoStation, params int[] index)
//		{
//			foreach (var item in index)
//			{
//				AxisPoint point = MoStation.Points[item];
//				AXISParsa aXISParsa = GetAXISParsa(point.Card, point.Axis);
//				MoSionContrl.Instance.P2PAbs(point.Card, point.Axis, point.Speed * SystemPara.Instance.PSpeed / 100, aXISParsa.Acc, aXISParsa.SmoothTime, (int)(point.Post / aXISParsa.Units));
//			}
//		}
//		/// <summary>
//		/// 同时移动轴
//		/// </summary>
//		public static void MoveAxisTog(this MoStation MoStation, params int[] index)
//		{
//			List<Task> tasks = new List<Task>();
//			foreach (var item in index)
//			{
//				AxisPoint point = MoStation.Points[item];
//				AXISParsa aXISParsa = GetAXISParsa(point.Card, point.Axis);
//				Task t = Task.Run(() => { MoSionContrl.Instance.P2PAbs(point.Card, point.Axis, point.Speed * SystemPara.Instance.PSpeed / 100, aXISParsa.Acc, aXISParsa.SmoothTime, (int)(point.Post / aXISParsa.Units)); });
//				tasks.Add(t);
//			}
//			Task.WaitAll(tasks.ToArray());
//		}
//		public static void MoveAxisTogOffset(this MoStation MoStation, double[] offset, params int[] index)
//		{
//			try
//			{
//				List<Task> tasks = new List<Task>();
//				for (int i = 0; i < index.Length; i++)
//				{
//					AxisPoint point = MoStation.Points[index[i]];
//					AXISParsa aXISParsa = GetAXISParsa(point.Card, point.Axis);
//					try
//					{
//						point.Post += offset[i];
//					}
//					catch
//					{
//					}
//					Task t = Task.Run(() => { MoSionContrl.Instance.P2PAbs(point.Card, point.Axis, point.Speed * SystemPara.Instance.PSpeed / 100, aXISParsa.Acc, aXISParsa.SmoothTime, (int)(point.Post / aXISParsa.Units)); });
//					tasks.Add(t);
//				}
//				Task.WaitAll(tasks.ToArray());
//			}
//			catch (Exception ex)
//			{

//				FileHelper.WriteLog(ex.Message);
//			}
//		}
//		/// <summary>
//		///移动pointpath单轴,indexAxsi轴号1-3对应XYZ
//		/// </summary>
//		/// <param name="MoStation"></param>
//		/// <param name="point"></param>
//		/// <returns></returns>
//		public static void MoveAxisPP(this MoStation MoStation, int index, int indexAxsi)
//		{

//			Point3DP point = MoStation.PointsPath[index];
//			short card;
//			short axis = 0;
//			double p = 0;
//			card = MoStation.CCard;
//			switch (indexAxsi)
//			{
//				case 1:
//					axis = MoStation.AxisX;
//					p = point.X;
//					break;
//				case 2:

//					axis = MoStation.AxisY;
//					p = point.Y;
//					break;
//				case 3:
//					axis = MoStation.AxisZ;
//					p = point.Z;
//					break;
//				default:
//					break;
//			}
//			AXISParsa aXISParsa = GetAXISParsa(card, axis);
//			if (aXISParsa == null)
//			{
//				Error(point, "运动参数错误！");
//				return;
//			}
//			MoSionContrl.Instance.P2PAbs(card, axis, aXISParsa.Velp * SystemPara.Instance.PSpeed / 100, aXISParsa.Acc, aXISParsa.SmoothTime, (int)(p / aXISParsa.Units));
//		}
//		/// <summary>
//		/// 移动pointpath点位,XYZ同时移动
//		/// </summary>
//		/// <param name="MoStation"></param>
//		/// <param name="point"></param>
//		/// <returns></returns>
//		public static void MoveAxisTogPP(this MoStation MoStation, int index)
//		{

//			Point3DP point = MoStation.PointsPath[index];
//			AXISParsa aXISParsa = GetAXISParsa(MoStation.CCard, MoStation.AxisX);
//			AXISParsa aXISParsa1 = GetAXISParsa(MoStation.CCard, MoStation.AxisY);
//			AXISParsa aXISParsa2 = GetAXISParsa(MoStation.CCard, MoStation.AxisZ);
//			Task t1 = Task.Run(() =>
//			{
//				MoSionContrl.Instance.P2PAbs(aXISParsa.Card, aXISParsa.Axis, aXISParsa.Velp * SystemPara.Instance.PSpeed / 100, aXISParsa.Acc,
//aXISParsa.SmoothTime, (int)(point.X / aXISParsa.Units));
//			});
//			Task t2 = Task.Run(() =>
//			{
//				MoSionContrl.Instance.P2PAbs(aXISParsa2.Card, aXISParsa2.Axis, aXISParsa2.Velp * SystemPara.Instance.PSpeed / 100, aXISParsa2.Acc,
//aXISParsa2.SmoothTime, (int)(point.X / aXISParsa2.Units));
//			}); ;
//			MoSionContrl.Instance.P2PAbs(aXISParsa1.Card, aXISParsa1.Axis, aXISParsa1.Velp * SystemPara.Instance.PSpeed / 100, aXISParsa1.Acc,
//aXISParsa1.SmoothTime, (int)(point.Y / aXISParsa1.Units));
//			Task.WaitAll(t1, t2);
//		}
//		/// <summary>
//		/// 移动pointpath点位,XYZ同时移动
//		/// </summary>
//		/// <param name="MoStation"></param>
//		/// <param name="point"></param>
//		/// <returns></returns>
//		public static void MoveAxisTogOffsetX_YPP(this MoStation MoStation, int index, double offsetx = 0, double offsety = 0)
//		{

//			Point3DP point = MoStation.PointsPath[index];
//			AXISParsa aXISParsa = GetAXISParsa(MoStation.CCard, MoStation.AxisX);
//			AXISParsa aXISParsa1 = GetAXISParsa(MoStation.CCard, MoStation.AxisY);
//			Task t1 = Task.Run(() =>
//			{
//				MoSionContrl.Instance.P2PAbs(aXISParsa.Card, aXISParsa.Axis, aXISParsa.Velp * SystemPara.Instance.PSpeed / 100, aXISParsa.Acc,
//aXISParsa.SmoothTime, (int)((point.X + offsetx) / aXISParsa.Units));
//			});
//			MoSionContrl.Instance.P2PAbs(aXISParsa1.Card, aXISParsa1.Axis, aXISParsa1.Velp * SystemPara.Instance.PSpeed / 100, aXISParsa1.Acc,
//aXISParsa1.SmoothTime, (int)((point.Y + offsety) / aXISParsa1.Units));
//			Task.WaitAll(t1);
//		}
//		public static void StartGluePath(this MoStation moStation, bool s, string io, int path)
//		{
//			int i = 0;
//			foreach (var item in moStation.PointsPath)
//			{

//				if (item.Value.ON)
//				{
//					if (item.Value.Name.Contains("起点"))
//					{
//						i++;
//						if (i == path)
//							moStation.CreatCoordinate();

//					}
//					else if (item.Value.Name.Contains("直线") && i == path)
//					{
//						moStation.LnXYZ(item.Key);
//					}
//					else if (item.Value.Name.Contains("圆终点") && i == path)
//					{
//						moStation.ArcXYZ(item.Key);
//					}
//					else if (item.Value.Name.Contains("整圆点") && i == path)
//					{
//						moStation.CircleXYZ(item.Key);
//					}
//				}

//			}
//			moStation.MoveLnX_Y_Z(s, io, moStation.CCard);
//		}
//		/// <summary>
//		/// 直线插补段
//		/// </summary>
//		/// <param name="MoStation"></param>
//		/// <param name="index"></param>
//		public static void LnXYZ(this MoStation MoStation, int index, short card = 0, double offsetx = 0, double offsety = 0, double u = 0)
//		{

//			Point3DP point = MoStation.PointsPath[index];
//			GetAfterRotationPoint(MoStation, ref point.X, ref point.Y, MoStation.Points[MoStation.MarkX].Post - MoStation.针头相机差值x, MoStation.Points[MoStation.MarkY].Post - MoStation.针头相机差值y, u);
//			//GetRoffsetPoint(MoStation, ref point.X, ref point.Y);
//			point.X += offsetx;
//			point.Y += offsety;
//			double v;
//			if (SystemPara.Instance.IsDispensVelp)
//			{
//				v = SystemPara.Instance.DispensVelp + SystemPara.Instance.SVelp;
//			}
//			else
//			{
//				v = point.Velp + SystemPara.Instance.SVelp;
//			}
//			mc.GT_LnXYZ(
//				card,
//			1, // 该插补段的坐标系是坐标系1
//		  (int)(point.X / GetAXISParsa(MoStation.CCard, MoStation.AxisX).Units),
//		  (int)(point.Y / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//		  (int)(point.Z / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//			v, // 该插补段的目标速度：100pulse/ms
//			SystemPara.Instance.DispensAcc, // 插补段的加速度：0.1pulse/ms^2
//			SystemPara.Instance.EndVelp, // 终点速度为0
//			0); // 向坐标系1的FIFO0缓存区传递该直线插补数据
//		}
//		/// <summary>
//		/// 整圆插补段
//		/// </summary>
//		public static void CircleXYZ(this MoStation MoStation, int index, short card = 0, double offsetx = 0, double offsety = 0, double u = 0)
//		{
//			Point3DP point = MoStation.PointsPath[index];
//			Point3DP point1 = MoStation.PointsPath[index - 1];
//			Point3DP point2 = MoStation.PointsPath[index - 2];
//			double v;
//			if (SystemPara.Instance.IsDispensVelp)
//			{
//				v = SystemPara.Instance.DispensVelp + SystemPara.Instance.SVelp;
//			}
//			else
//			{
//				v = point.Velp + SystemPara.Instance.SVelp;
//			}

//			double x1 = point.X;
//			double x2 = point1.X;
//			double x3 = point2.X;
//			double y1 = point.Y;
//			double y2 = point1.Y;
//			double y3 = point2.Y;
//			double a = x1 - x2;

//			double b = y1 - y2;

//			double c = x1 - x3;

//			double d = y1 - y3;

//			double e = ((x1 * x1 - x2 * x2) + (y1 * y1 - y2 * y2)) / 2.0;

//			double f = ((x1 * x1 - x3 * x3) + (y1 * y1 - y3 * y3)) / 2.0;

//			double det = b * c - a * d;

//			double x0 = 0;
//			double y0 = 0;
//			if (Math.Abs(det) > 0.001)

//			{

//				//x0,y0为计算得到的原点

//				x0 = -(d * e - b * f) / det;

//				y0 = -(a * f - c * e) / det;
//			}
//			else
//			{
//				return;
//			}
//			Point3DP point3 = new Point3DP() { X = 2 * x0 - point1.X, Y = 2 * y0 - point1.Y, Z = point1.Z };
//			GetAfterRotationPoint(MoStation, ref point.X, ref point.Y, MoStation.Points[MoStation.MarkX].Post - MoStation.针头相机差值x, MoStation.Points[MoStation.MarkY].Post - MoStation.针头相机差值y, u);

//			GetAfterRotationPoint(MoStation, ref point1.X, ref point1.Y, MoStation.Points[MoStation.MarkX].Post - MoStation.针头相机差值x, MoStation.Points[MoStation.MarkY].Post - MoStation.针头相机差值y, u);
//			//  GetRoffsetPoint(MoStation, ref point.X, ref point.Y);
//			//  GetRoffsetPoint(MoStation, ref point1.X, ref point1.Y);
//			point.X += offsetx;
//			point.Y += offsety;
//			point1.X += offsetx;
//			point1.Y += offsety;
//			GetAfterRotationPoint(MoStation, ref point2.X, ref point2.Y, MoStation.Points[MoStation.MarkX].Post - MoStation.针头相机差值x, MoStation.Points[MoStation.MarkY].Post - MoStation.针头相机差值y, u);

//			GetAfterRotationPoint(MoStation, ref point3.X, ref point3.Y, MoStation.Points[MoStation.MarkX].Post - MoStation.针头相机差值x, MoStation.Points[MoStation.MarkY].Post - MoStation.针头相机差值y, u);
//			//  GetRoffsetPoint(MoStation, ref point.X, ref point.Y);
//			//  GetRoffsetPoint(MoStation, ref point1.X, ref point1.Y);
//			point2.X += offsetx;
//			point2.Y += offsety;
//			point3.X += offsetx;
//			point3.Y += offsety;
//			mc.GT_ArcXYZ(card,
//						1, // 坐标系是坐标系1
//		  (int)(point.X / GetAXISParsa(MoStation.CCard, MoStation.AxisX).Units),
//		  (int)(point.Y / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//		  (int)(point.Z / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//		  point1.X / GetAXISParsa(MoStation.CCard, MoStation.AxisX).Units,
//		  point1.Y / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units,
//		  point1.Z / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units,
//						v, // 该插补段的目标速度：100pulse/ms
//						SystemPara.Instance.DispensAcc, // 该插补段的加速度：0.1pulse/ms^2
//						SystemPara.Instance.EndVelp, // 终点速度为0
//						0); // 向坐标系1的FIFO0缓存区传递该直线插补数据
//			mc.GT_ArcXYZ(card,
//			1, // 坐标系是坐标系1
//		  (int)(point2.X / GetAXISParsa(MoStation.CCard, MoStation.AxisX).Units),
//		  (int)(point2.Y / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//		  (int)(point2.Z / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//		  point3.X / GetAXISParsa(MoStation.CCard, MoStation.AxisX).Units,
//		  point3.Y / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units,
//		  point3.Z / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units,
//			v, // 该插补段的目标速度：100pulse/ms
//			SystemPara.Instance.DispensAcc, // 该插补段的加速度：0.1pulse/ms^2
//			SystemPara.Instance.EndVelp, // 终点速度为0
//			0); // 向坐标系1的FIFO0缓存区传递该直线插补数据
//		}
//		/// <summary>
//		/// 圆弧插补段
//		/// </summary>
//		public static void ArcXYZ(this MoStation MoStation, int index, short card = 0, double offsetx = 0, double offsety = 0, double u = 0)
//		{
//			Point3DP point = MoStation.PointsPath[index];
//			Point3DP point1 = MoStation.PointsPath[index - 1];
//			GetAfterRotationPoint(MoStation, ref point.X, ref point.Y, MoStation.Points[MoStation.MarkX].Post - MoStation.针头相机差值x, MoStation.Points[MoStation.MarkY].Post - MoStation.针头相机差值y, u);

//			GetAfterRotationPoint(MoStation, ref point1.X, ref point1.Y, MoStation.Points[MoStation.MarkX].Post - MoStation.针头相机差值x, MoStation.Points[MoStation.MarkY].Post - MoStation.针头相机差值y, u);
//			//  GetRoffsetPoint(MoStation, ref point.X, ref point.Y);
//			//  GetRoffsetPoint(MoStation, ref point1.X, ref point1.Y);
//			point.X += offsetx;
//			point.Y += offsety;
//			point1.X += offsetx;
//			point1.Y += offsety;
//			double v;
//			if (SystemPara.Instance.IsDispensVelp)
//			{
//				v = SystemPara.Instance.DispensVelp + SystemPara.Instance.SVelp;
//			}
//			else
//			{
//				v = point.Velp + SystemPara.Instance.SVelp;
//			}
//			mc.GT_ArcXYZ(card,
//						1, // 坐标系是坐标系1
//		  (int)(point.X / GetAXISParsa(MoStation.CCard, MoStation.AxisX).Units),
//		  (int)(point.Y / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//		  (int)(point.Z / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units),
//		  point1.X / GetAXISParsa(MoStation.CCard, MoStation.AxisX).Units,
//		  point1.Y / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units,
//		  point1.Z / GetAXISParsa(MoStation.CCard, MoStation.AxisY).Units,
//						v, // 该插补段的目标速度：100pulse/ms
//						SystemPara.Instance.DispensAcc, // 该插补段的加速度：0.1pulse/ms^2
//						SystemPara.Instance.EndVelp, // 终点速度为0
//			0); // 向坐标系1的FIFO0缓存区传递该直线插补数据
//		}
//		/// <summary>
//		/// 平面插补XY移动,需要先插入插补段
//		/// </summary>
//		public static void MoveLnX_Y_Z(this MoStation MoStation, bool s, string io, short card = 0)
//		{
//		Res:
//			if (s)
//				IOControl.Instance.WriteIoBit(true, io);
//			Thread.Sleep(SystemPara.Instance.StartDelayGlue);
//			// 指令返回值变量
//			short sRtn;
//			// 坐标系运动状态查询变量
//			short run;
//			// 坐标系运动完成段查询变量
//			int segment;
//			// 坐标系的缓存区剩余空间查询变量
//			int space;
//			// 查询坐标系1的FIFO0所剩余的空间
//			sRtn = mc.GT_CrdSpace(card, 1, out space, 0);

//			//将前瞻缓存区中的数据压入控制器
//			sRtn = mc.GT_CrdData(0, 1, System.IntPtr.Zero, 0);
//			// 启动运动
//			// 启动坐标系1的FIFO0的插补运动
//			sRtn = mc.GT_CrdStart(card, 1, 0);
//			// 等待运动完成
//			sRtn = mc.GT_CrdStatus(card, 1, out run, out segment, 0);
//			do
//			{
//				if (FormMain.Instance.STState == STState.STATE_EMG)
//				{
//					IOControl.Instance.WriteIoBit(false, io, false, false);
//					return;
//				}
//				if (FormMain.Instance.STState == STState.STATE_ERROR || FormMain.Instance.STState == STState.STATE_PAUSE)
//				{
//					break;
//				}
//				// 查询坐标系1的FIFO的插补运动状态
//				sRtn = mc.GT_CrdStatus(card,
//				1, // 坐标系是坐标系1
//				out run, // 读取插补运动状态
//				out segment, // 读取当前已经完成的插补段数
//				0); // 查询坐标系1的FIFO0缓存区
//					// 坐标系在运动, 查询到的run的值为1
//			} while (run == 1);
//			if (FormMain.Instance.STState == STState.STATE_ERROR
//		   || FormMain.Instance.STState == STState.STATE_PAUSE)
//			{
//				sRtn = mc.GT_Stop(card, 1 << 8, 1 << 8);
//				IOControl.Instance.WriteIoBit(false, io, false);
//				do
//				{
//					if (FormMain.Instance.STState == STState.STATE_EMG)
//					{
//						return;
//					}
//					if (FormMain.Instance.STState == STState.STATE_PAUSE && FormMain.Instance.temst == STState.STATE_READY)
//					{
//						return;
//					}
//					Thread.Sleep(10);
//				} while (FormMain.Instance.STState == STState.STATE_ERROR || FormMain.Instance.STState == STState.STATE_PAUSE);
//				goto Res;
//			}
//			Thread.Sleep(SystemPara.Instance.StopDelayGlue);
//			IOControl.Instance.WriteIoBit(false, io, false, false);
//		}


//		/// <summary>
//		/// 加载点位，index为键
//		/// </summary>
//		/// <param name="strFile"></param>
//		/// <returns></returns>
//		public Dictionary<int, AxisPoint> LoadPointFile(string strFile)
//		{
//			Dictionary<int, AxisPoint> points = new Dictionary<int, AxisPoint>();
//			List<AxisPoint> Axispoints = new List<AxisPoint>() { new AxisPoint() { Name = "" } };
//			Axispoints = Axispoints.XmlDeSeria(strFile);
//			foreach (var item in Axispoints)
//			{
//				points.Add(item.Index, item);
//			}
//			return points;
//		}
//		/// <summary>
//		/// 加载点位，index为键
//		/// </summary>
//		/// <param name="strFile"></param>
//		/// <returns></returns>
//		public Dictionary<int, Point3DP> LoadPathFile(string strFile)
//		{
//			Dictionary<int, Point3DP> pointPath = new Dictionary<int, Point3DP>();
//			List<Point3DP> point3DPs = new List<Point3DP>() { new Point3DP() { Name = "" } };
//			point3DPs = point3DPs.XmlDeSeria(strFile);
//			foreach (var item in point3DPs)
//			{
//				pointPath.Add(item.Index, item);
//			}
//			return pointPath;
//		}
//		#region 控制卡初始化
//		/// <summary>
//		/// 初始化控制卡
//		/// </summary>
//		/// <param name="configFile">配置文件</param>
//		/// <returns></returns>
//		public void CardInit(string configFile, short CardNo = 0, short AxisNum = 8)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_Open(CardNo, 0, 1);//channel 0:正常打开；1：内部模式（用户不使用）。 param默认为1有效。
//											 //sRtn += mc.GT_OpenExtMdl(0, "dll");
//											 //sRtn += mc.GT_LoadExtConfig(0, "ExtModule.cfg");
//			sRtn += mc.GT_Reset(CardNo);     //复位控制器，恢复所有状态标志。会复位本地IO输出。
//			sRtn += mc.GT_LoadConfig(CardNo, configFile);//加载配置文件.cfg格式文件。 放在应用程序目录使用文件名或使用绝对路径加载。
//			sRtn += mc.GT_ClrSts(CardNo, 1, AxisNum);    //加载配置文件后复位所有轴状态
//														 //mc.GT_SetExtIoBit(0, 3, 1, 1);
//														 //mc.GT_SetExtIoBit(0, 2, 1, 1);
//														 //mc.GT_SetExtIoBit(0, 1, 1, 1);
//														 //mc.GT_SetExtIoBit(0, 0, 1, 1);
//														 //mc.GT_SetDoBit(0, 12, 1, 1);//固高bug需要输入复位
//			if (sRtn == 0)
//			{
//				FormMain.Instance.WriteLog($"板卡：{CardNo}，初始化成功！");
//			}
//			else
//			{
//				FileHelper.WriteLog($"板卡：{CardNo}，初始化失败！");
//			}
//		}
//		#endregion
//		public void ExtInital(string configfile, short cardNo = 0)
//		{
//			short sRtn = 0;
//			sRtn += gts.mc.GT_OpenExtMdl(cardNo, "gts.dll");  //拓展模块与gts卡函数都在gts.dll其中
//			sRtn += gts.mc.GT_ResetExtMdl(cardNo);            //复位拓展模块
//			sRtn += gts.mc.GT_LoadExtConfig(cardNo, configfile);//加载拓展模块配置文件
//			sRtn += gts.mc.GT_ClrSts(cardNo, 1, 8);
//			if (sRtn == 0)
//			{
//				FormMain.Instance.WriteLog("IO扩展模块加载成功！");
//			}
//			else
//			{
//				FileHelper.WriteLog("IO扩展模块加载失败！");
//			}
//		}
//		#region 使能控制
//		/// <summary>
//		/// 单轴使能
//		/// </summary>
//		/// <param name="axis">轴号（从1开始）</param>
//		public void AxisServoOn(short CardNo, short axis)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_ClrSts(CardNo, axis, 1);
//			sRtn += mc.GT_AxisOn(CardNo, axis);
//			if (sRtn != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，上使能失败！");
//			}
//		}

//		/// <summary>
//		/// 单轴下使能
//		/// </summary>
//		public void AxisServoOff(short CardNo, short axis)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_ClrSts(CardNo, axis, 1);
//			sRtn += mc.GT_AxisOff(CardNo, axis);
//			if (sRtn != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，下使能失败！");
//			}
//		}
//		#endregion

//		#region 轴停止控制
//		/// <summary>
//		/// 单轴平滑停止
//		/// </summary>
//		public void AxisStopSoomth(short CardNo, short axis)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_Stop(CardNo, 1 << (axis - 1), 0);
//			if (sRtn != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，缓停失败！");
//			}
//		}

//		/// <summary>
//		///单轴紧急停止
//		/// </summary>
//		public void AxisStopAbrupt(short CardNo, short axis)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_Stop(CardNo, 1 << (axis - 1), 1 << (axis - 1));
//			if (sRtn != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，急停失败！");
//			}
//		}
//		#endregion

//		#region 基本运动
//		/// <summary>
//		/// 绝对位置运动（回零后）
//		/// </summary>
//		public bool P2PAbs(short CardNo, short axis, double velP, double acc, short smoothTimeA, int PosP)  //单轴绝对位置点位运动
//		{
//		Res:
//			if (FormMain.Instance.STState == STState.STATE_EMG)
//				return false;
//			int status;
//			uint pClock;
//			//状态字查询
//			mc.GT_GetSts(CardNo, axis, out status, 1, out pClock);
//			if ((status & 0x0400) != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，正在规划运动！");
//			}
//			if ((status & 0x0200) == 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，未使能！");
//				return false;
//			}
//			if ((status & 0x0020) != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，正限位报警！");
//				return false;
//			}
//			if ((status & 0x0040) != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，负限位报警！");
//				return false;
//			}
//			double pvalue1;
//			uint p1;
//			short sRtn = 0;//返回值
//			mc.TTrapPrm trap;
//			sRtn += mc.GT_PrfTrap(CardNo, axis);     //设置为点位运动，模式切换需要停止轴运动。
//													 //若返回值为 1：若当前轴在规划运动，请调用GT_Stop停止运动再调用该指令。
//			sRtn += mc.GT_GetTrapPrm(CardNo, axis, out trap);       /*读取点位运动参数（不一定需要）。若返回值为 1：请检查当前轴是否为 Trap 模式
//                                                                    若不是，请先调用 GT_PrfTrap 将当前轴设置为 Trap 模式。*/
//			trap.acc = acc;              //单位pulse/ms2
//			trap.dec = acc;              //单位pulse/ms2
//			trap.velStart = 0;           //起跳速度，默认为0。
//			trap.smoothTime = smoothTimeA;         //平滑时间，使加减速更为平滑。范围[0,50]单位ms。

//			sRtn += mc.GT_SetTrapPrm(CardNo, axis, ref trap);//设置点位运动参数。

//			sRtn += mc.GT_SetVel(CardNo, axis, velP);        //设置目标速度
//			sRtn += mc.GT_SetPos(CardNo, axis, PosP);        //设置目标位置
//			sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));   //更新轴运动
//			double pvalue;
//			uint p;
//			DateTime now = DateTime.Now;
//			int ispan;
//			do
//			{

//				TimeSpan span = DateTime.Now - now;
//				ispan = Convert.ToInt32(span.TotalSeconds);
//				Thread.Sleep(10);

//				mc.GT_GetAxisEncPos(CardNo, axis, out pvalue, 1, out p);
//				mc.GT_GetSts(CardNo, axis, out status, 1, out pClock);
//				if (FormMain.Instance.STState == STState.STATE_ERROR || FormMain.Instance.STState == STState.STATE_PAUSE)
//					break;
//				if (FormMain.Instance.STState == STState.STATE_EMG)
//				{
//					return false;
//				}
//				if (ispan > 60)
//				{
//					this.Error("卡号" + CardNo + "，轴" + axis + "误差超限，可能原因是未找到原点");
//				}
//				if (Math.Abs((int)pvalue - PosP) < 10 && (status & 0x0400) == 0)
//				{
//					break;
//				}
//			} while (true);
//			if (FormMain.Instance.STState == STState.STATE_ERROR
//			 || FormMain.Instance.STState == STState.STATE_PAUSE)
//			{
//				AxisStopSoomth(CardNo, axis);
//				do
//				{
//					if (FormMain.Instance.STState == STState.STATE_EMG)
//						return false;
//					if (FormMain.Instance.STState == STState.STATE_PAUSE && FormMain.Instance.temst == STState.STATE_READY)
//						return false;
//					if (FormMain.Instance.STState == STState.STATE_PAUSE && SystemPara.Instance.Manual)
//						return false;
//					if (FormMain.Instance.STState == STState.STATE_PAUSE && FormMain.Instance.temst == STState.STATE_NULL)
//						return false;
//					Thread.Sleep(10);
//					if (FormMain.Instance.STState != STState.STATE_ERROR
//			&& FormMain.Instance.STState != STState.STATE_PAUSE)
//					{
//						break;
//					}
//				} while (true);
//				goto Res;
//			}
//			if (sRtn == 0)
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//		/// <summary>
//		/// 增量点位运动
//		/// </summary>
//		public bool P2PInc(short CardNo, short axis, double velP, double acc, short smoothTimeI, int PosP)  //单轴增量位置点位运动
//		{
//		Res:
//			if (FormMain.Instance.STState == STState.STATE_EMG)
//				return false;
//			int status;
//			uint Clock;
//			//状态字查询
//			mc.GT_GetSts(CardNo, axis, out status, 1, out Clock);
//			if ((status & 0x0400) != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，正在规划运动！");
//			}
//			if ((status & 0x0200) == 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，未使能！");
//				return false;
//			}
//			if ((status & 0x0020) != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，正限位报警！");
//				return false;
//			}
//			if ((status & 0x0040) != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，负限位报警！");
//				return false;
//			}
//			short sRtn = 0;     //返回值
//			double prfPos; //规划脉冲
//			uint pClock;    //时钟信号
//			mc.TTrapPrm trap;
//			sRtn += mc.GT_PrfTrap(CardNo, axis);     //设置为点位运动，模式切换需要停止轴运动。
//													 //若返回值为 1：若当前轴在规划运动，请调用GT_Stop停止运动再调用该指令。
//			sRtn += mc.GT_GetTrapPrm(CardNo, axis, out trap);       /*读取点位运动参数（不一定需要）。若返回值为 1：请检查当前轴是否为 Trap 模式
//                                                                    若不是，请先调用 GT_PrfTrap 将当前轴设置为 Trap 模式。*/
//			trap.acc = acc;              //单位pulse/ms2
//			trap.dec = acc;              //单位pulse/ms2
//			trap.velStart = 0;           //起跳速度，默认为0。
//			trap.smoothTime = smoothTimeI;         //平滑时间，使加减速更为平滑。范围[0,50]单位ms。

//			sRtn += mc.GT_SetTrapPrm(CardNo, axis, ref trap);//设置点位运动参数。
//			sRtn += mc.GT_GetPrfPos(CardNo, axis, out prfPos, 1, out pClock);//读取规划位置
//			sRtn += mc.GT_SetVel(CardNo, axis, velP);        //设置目标速度
//			sRtn += mc.GT_SetPos(CardNo, axis, (int)(PosP + prfPos));        //设置目标位置
//			sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));   //更新轴运动
//			double pvalue;
//			uint p;
//			DateTime now = DateTime.Now;
//			int ispan;
//			do
//			{
//				TimeSpan span = DateTime.Now - now;
//				ispan = Convert.ToInt32(span.TotalSeconds);
//				Thread.Sleep(10);
//				mc.GT_GetSts(CardNo, axis, out status, 1, out pClock);
//				if (FormMain.Instance.STState == STState.STATE_ERROR || FormMain.Instance.STState == STState.STATE_PAUSE)
//					break;
//				if (FormMain.Instance.STState == STState.STATE_EMG)
//				{
//					return false;
//				}
//				if (ispan > 60)
//				{
//					this.Error("卡号" + CardNo + "，轴" + axis + "运动超时，原因不明");
//					AxisStopSoomth(axis, CardNo);
//					return false;
//				}
//				if ((status & 0x0400) == 0)
//				{
//					break;
//				}
//			} while (true);
//			if (FormMain.Instance.STState == STState.STATE_ERROR
//			|| FormMain.Instance.STState == STState.STATE_PAUSE)
//			{
//				AxisStopSoomth(axis, CardNo);
//				do
//				{
//					if (FormMain.Instance.STState == STState.STATE_EMG)
//					{
//						return false;
//					}
//					if (FormMain.Instance.STState == STState.STATE_PAUSE && FormMain.Instance.temst == STState.STATE_READY)
//					{
//						return false;
//					}
//					if (FormMain.Instance.STState != STState.STATE_ERROR && FormMain.Instance.STState != STState.STATE_PAUSE)
//					{
//						break;
//					}
//					Thread.Sleep(10);
//				} while (true);
//				goto Res;
//			}
//			if (sRtn == 0)
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//		/// <summary>
//		/// JOG运动,direction运动方向1正，-1反
//		/// </summary>
//		public void JOG(short CardNo, short axis, double velJ, double acc, double dec)     //jog运动模式
//		{
//			int status;
//			uint Clock;
//			//状态字查询
//			mc.GT_GetSts(CardNo, axis, out status, 1, out Clock);
//			if (FormMain.Instance.STState == STState.STATE_EMG)
//				return;
//			if ((status & 0x0400) != 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，正在规划运动！");
//			}
//			if ((status & 0x0200) == 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，未使能！");
//				return;
//			}
//			//if ((status & 0x0020) != 0)
//			//{
//			//    FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，正限位报警！");
//			//}
//			//if ((status & 0x0040) != 0)
//			//{
//			//    FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，负限位报警！");
//			//}
//			short sRtn = 0;
//			mc.TJogPrm pJog;
//			sRtn += mc.GT_PrfJog(CardNo, axis);
//			pJog.acc = acc;
//			pJog.dec = dec;
//			pJog.smooth = 0;//平滑系数,取值范围[0, 1),平滑系数的数值越大，加减速过程越平稳。
//			sRtn += mc.GT_SetJogPrm(CardNo, axis, ref pJog);//设置jog运动参数
//			sRtn += mc.GT_SetVel(CardNo, axis, velJ);//设置目标速度,velJd的符号决定JOG运动方向
//			sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));//更新轴运动
//			if (sRtn == 0)
//			{
//				return;
//			}
//			else
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，JOG运动失败！");
//				return;
//			}

//		}
//		#endregion

//		#region 回零
//		public bool SetHomeMode(short CardNo, short axis, short homeMode, short zDir, short searchDir, int homeoffset, double acc, double dcc, short smoothtime, double vel1 = 10, double vel2 = 10)
//		{
//			if (axis == 0)
//			{
//				return true;
//			}
//			int status;
//			uint pClock;
//			//状态字查询
//			mc.GT_GetSts(CardNo, axis, out status, 1, out pClock);
//			if ((status & 0x0200) == 0)
//			{
//				FileHelper.WriteLog($"卡号：{CardNo}轴：{axis}，未使能！");
//				return false;
//			}
//			mc.THomeStatus pHomeStatus;
//			mc.THomePrm tHomePrm;
//			short sRtn = 0;
//			sRtn += mc.GT_GetHomeStatus(CardNo, axis, out pHomeStatus);//获取回原点状态
//			if (pHomeStatus.run == 1)//确认是否正在做回零运动
//			{
//				return true;
//			}
//		Res:
//			//使用home回零或home+index回零，若轴停止在home点则需要先移开home点在开启回零。由实际情况确认。
//			sRtn += mc.GT_ClrSts(CardNo, axis, 1);
//			sRtn += mc.GT_ZeroPos(CardNo, axis, 1);
//			sRtn += mc.GT_GetHomePrm(CardNo, axis, out tHomePrm);
//			tHomePrm.mode = homeMode;           //回零方式
//			tHomePrm.searchHomeDistance = 0;    //搜索限位距离，0为无限大
//			tHomePrm.searchIndexDistance = 0;   //搜索index距离，0为无限大
//			tHomePrm.moveDir = zDir;       //回零方向
//			tHomePrm.indexDir = searchDir;           //index搜索方向
//			tHomePrm.velHigh = vel1;            //搜索限位的速度
//			tHomePrm.velLow = vel2;             //搜索原点、index的速度
//			tHomePrm.smoothTime = smoothtime;
//			tHomePrm.acc = acc;    //经验值
//			tHomePrm.dec = dcc;
//			tHomePrm.escapeStep = 10000;//限位回零后方式时第一次找到限位反向移动距离
//			tHomePrm.homeOffset = homeoffset;    //原点偏移 = 0
//			tHomePrm.edge = 1;
//			sRtn += mc.GT_GoHome(CardNo, axis, ref tHomePrm);//启动SmartHome回原点
//			DateTime now = DateTime.Now;
//			int ispan;
//			do
//			{
//				TimeSpan span = DateTime.Now - now;
//				ispan = Convert.ToInt32(span.TotalSeconds);
//				Thread.Sleep(10);
//				if (FormMain.Instance.STState == STState.STATE_ERROR || FormMain.Instance.STState == STState.STATE_PAUSE)
//					break;
//				if (FormMain.Instance.STState == STState.STATE_EMG)
//				{
//					return false;
//				}
//				if (ispan > 60)
//				{
//					this.Error("卡号" + CardNo + "，轴" + axis + "回原点超时");
//					return false;
//				}
//				sRtn += mc.GT_GetHomeStatus(CardNo, axis, out pHomeStatus);//获取回原点状态
//				if (pHomeStatus.run != 1 && pHomeStatus.stage == 100)
//				{
//					break;
//				}
//			} while (true); // 等待搜索原点停止
//			if (FormMain.Instance.STState == STState.STATE_ERROR
//|| FormMain.Instance.STState == STState.STATE_PAUSE)
//			{
//				AxisStopSoomth(axis, CardNo);
//				do
//				{
//					if (FormMain.Instance.STState == STState.STATE_EMG)
//					{
//						return false;
//					}
//					if (FormMain.Instance.STState == STState.STATE_PAUSE && FormMain.Instance.temst == STState.STATE_READY)
//					{
//						return false;
//					}
//					if (FormMain.Instance.STState != STState.STATE_ERROR && FormMain.Instance.STState != STState.STATE_PAUSE)
//					{
//						break;
//					}
//					Thread.Sleep(10);
//				} while (true);
//				goto Res;
//			}
//			Thread.Sleep(1000);     //等待电机完全停止，时间由电机调试效果确定
//			sRtn += mc.GT_ZeroPos(CardNo, axis, 1);  //回零完成手动清零
//			ClearStatus(CardNo, axis);
//			if (sRtn == 0)
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//		/// <summary>
//		/// 工站回原点
//		/// </summary>
//		/// <param name="MoStation"></param>
//		/// <returns></returns>
//		public bool GoHome()
//		{
//			bool S = true;
//			List<Task> tasks = new List<Task>();
//			var query = from n in SystemPara.Instance.aXISParsas
//						orderby n.HomeIndex ascending
//						group n by n.HomeIndex;
//			foreach (var i in query)
//			{
//				foreach (var j in i)
//				{
//					Task th = Task.Run(() =>
//					{
//						AxisServoOn(j.Card, j.Axis);
//						S = S & SetHomeMode(j.Card, j.Axis, (short)j.HomeMode, j.ZDir, j.SDir, (int)(j.HomeOffset / j.Units), j.Acc, j.Dcc, j.SmoothTime);
//					});
//					tasks.Add(th);
//				}
//				Task.WaitAll(tasks.ToArray());
//			}
//			Task.WaitAll(tasks.ToArray());
//			return S;
//		}
//		#endregion

//		/// <summary>
//		/// 清除报警信号
//		/// </summary>
//		/// <param name="axis">轴号</param>
//		/// <returns></returns>
//		public short ClearAlarmOn(short CardNo, short axis)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_SetDoBit(CardNo, mc.MC_CLEAR, axis, 0);//报警清除信号未取反是0表示输出低电平。
//			if (sRtn == 0)
//			{
//				return 0;
//			}
//			else
//			{
//				return axis;
//			}
//		}
//		/// <summary>
//		/// 关闭报警清除信号
//		/// </summary>
//		/// <param name="axis">轴号</param>
//		/// <returns></returns>
//		public bool ClearAlarmOff(short CardNo, short axis)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_SetDoBit(CardNo, mc.MC_CLEAR, axis, 1);//报警清除信号未取反是1表示关闭输出。
//			if (sRtn == 0)
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}

//		/// <summary>
//		/// 读取所有轴的实际位置
//		/// </summary>
//		/// <returns></returns>
//		public double[] GetEncPosition(short CardNo = 0, short AxisNum = 8)
//		{
//			double[] EncPosition = new double[AxisNum];
//			short sRtn = 0;
//			short axisStart = 1;    //读取起始轴1
//			uint pClock;    //时钟信号
//			sRtn += mc.GT_GetEncPos(CardNo, axisStart, out EncPosition[0], AxisNum, out pClock);    //一般由1轴开始读取4轴或8轴
//			return EncPosition;
//		}
//		/// <summary>
//		/// 清除单轴状态
//		/// </summary>
//		/// <param name="axis"></param>
//		/// <returns></returns>
//		public bool ClearStatus(short CardNo, short axis)
//		{
//			short sRtn = 0;
//			sRtn += mc.GT_ClrSts(CardNo, axis, 1);  //清除单轴状态
//			if (sRtn == 0)
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//	}
}
