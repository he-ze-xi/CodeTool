using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoogolTechGTSCard_6.GTS
{
	#region 固高官方API
	public class mc_la
	{
		public const short LA_AXIS_NUM = 8;
		public const short LA_WORK_AXIS_NUM = 6;
		public const short LA_MACHINE_AXIS_NUM = 5;
		public const short AXIS_LIMIT_NONE = 0;
		public const short AXIS_LIMIT_MAX_VEL = 1;
		public const short AXIS_LIMIT_MAX_ACC = 2;
		public const short AXIS_LIMIT_MAX_DV = 4;
		public const short KIN_MSG_BUFFER_SIZE = 32;

		//工件坐标系下轨迹是否限制速度模式
		public enum EWorkLimitMode
		{
			WORK_LIMIT_INVALID = 0,     //不限制
			WORK_LIMIT_VALID = 1,           //限制生效
		};

		//设置的速度定义规则
		public enum EVelSettingDef
		{
			NORMAL_DEF_VEL = 0,         //输入为轴坐标系所有轴的合成速度
			NUM_DEF_VEL = 1,                //以NUM系统的规则定义
			CUT_DEF_VEL = 2,                //速度为切削速度
		};

		//设置的加速度定义规则
		public enum EAccSettingDef
		{
			NORMAL_DEF_ACC = 0,             //输入即输出
			LONG_AXIS_ACC = 1,                //长轴最大速度
		};

		//机床类型
		public enum EMachineMode
		{
			NORMAL_THREE_AXIS = 0,      //标准三轴机床模式
			MULTI_AXES = 1,                 //多轴联动模式
			FIVE_AXIS = 2,                  //五轴机床模式，轴坐标系为主，工件坐标系为辅
			FIVE_AXIS_WORK = 3,             //五轴机床模式，工件坐标系为主，轴坐标系为辅
			ROBOT = 4,
		};
		//前瞻参数结构体
		public struct TLookAheadParameter
		{
			public int lookAheadNum;                    //前瞻段数
			public double time;                     //时间常数
			public double radiusRatio;                  //曲率限制调节参数
			public double vMax1;            //各轴的最大速度
			public double vMax2;
			public double vMax3;
			public double vMax4;
			public double vMax5;
			public double vMax6;
			public double vMax7;
			public double vMax8;
			public double aMax1;            //各轴的最大加速度
			public double aMax2;
			public double aMax3;
			public double aMax4;
			public double aMax5;
			public double aMax6;
			public double aMax7;
			public double aMax8;
			public double DVMax1;           //各轴的最大速度变化量（在时间常数内）
			public double DVMax2;
			public double DVMax3;
			public double DVMax4;
			public double DVMax5;
			public double DVMax6;
			public double DVMax7;
			public double DVMax8;
			public double scale1;           //各轴的脉冲当量
			public double scale2;
			public double scale3;
			public double scale4;
			public double scale5;
			public double scale6;
			public double scale7;
			public double scale8;
			public short axisRelation1; //输入坐标和内部坐标的对应关系
			public short axisRelation2;
			public short axisRelation3;
			public short axisRelation4;
			public short axisRelation5;
			public short axisRelation6;
			public short axisRelation7;
			public short axisRelation8;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string machineCfgFileName;       //机床配置文件名
		};

		//////////////////////////////////////
		public struct RC_KIN_CONFIG
		{
			public short RobotType;
			public short reserved1;

			public short KinParUse1;
			public short KinParUse2;
			public short KinParUse3;
			public short KinParUse4;
			public short KinParUse5;
			public short KinParUse6;
			public short KinParUse7;
			public short KinParUse8;
			public short KinParUse9;
			public short KinParUse10;
			public short KinParUse11;
			public short KinParUse12;
			public short KinParUse13;
			public short KinParUse14;
			public short KinParUse15;
			public short KinParUse16;
			public short KinParUse17;
			public short KinParUse18;
			public double KinPar1;
			public double KinPar2;
			public double KinPar3;
			public double KinPar4;
			public double KinPar5;
			public double KinPar6;
			public double KinPar7;
			public double KinPar8;
			public double KinPar9;
			public double KinPar10;
			public double KinPar11;
			public double KinPar12;
			public double KinPar13;
			public double KinPar14;
			public double KinPar15;
			public double KinPar16;
			public double KinPar17;
			public double KinPar18;
			public short KinLimitUse1;
			public short KinLimitUse2;
			public short KinLimitUse3;
			public short KinLimitUse4;
			public short KinLimitUse5;
			public short KinLimitUse6;
			public short KinLimitUse7;
			public short KinLimitUse8;
			public short KinLimitUse9;
			public short KinLimitUse10;
			public short KinLimitUse11;
			public short KinLimitUse12;
			public double KinLimitMin1;
			public double KinLimitMin2;
			public double KinLimitMin3;
			public double KinLimitMin4;
			public double KinLimitMin5;
			public double KinLimitMin6;
			public double KinLimitMin7;
			public double KinLimitMin8;
			public double KinLimitMin9;
			public double KinLimitMin10;
			public double KinLimitMin11;
			public double KinLimitMin12;
			public double KinLimitMax1;
			public double KinLimitMax2;
			public double KinLimitMax3;
			public double KinLimitMax4;
			public double KinLimitMax5;
			public double KinLimitMax6;
			public double KinLimitMax7;
			public double KinLimitMax8;
			public double KinLimitMax9;
			public double KinLimitMax10;
			public double KinLimitMax11;
			public double KinLimitMax12;
			public double KinLimitMinShift1;
			public double KinLimitMinShift2;
			public double KinLimitMinShift3;
			public double KinLimitMinShift4;
			public double KinLimitMinShift5;
			public double KinLimitMinShift6;
			public double KinLimitMinShift7;
			public double KinLimitMinShift8;
			public double KinLimitMinShift9;
			public double KinLimitMinShift11;
			public double KinLimitMinShift12;
			public double KinLimitMaxShift1;
			public double KinLimitMaxShift2;
			public double KinLimitMaxShift3;
			public double KinLimitMaxShift4;
			public double KinLimitMaxShift5;
			public double KinLimitMaxShift6;
			public double KinLimitMaxShift7;
			public double KinLimitMaxShift8;
			public double KinLimitMaxShift9;
			public double KinLimitMaxShift10;
			public double KinLimitMaxShift11;
			public double KinLimitMaxShift12;

			public short AxisUse1;
			public short AxisUse2;
			public short AxisUse3;
			public short AxisUse4;
			public short AxisUse6;
			public short AxisUse7;
			public short AxisUse8;
			public char AxisPosSignSwitch1;
			public char AxisPosSignSwitch2;
			public char AxisPosSignSwitch3;
			public char AxisPosSignSwitch4;
			public char AxisPosSignSwitch5;
			public char AxisPosSignSwitch6;
			public char AxisPosSignSwitch7;
			public char AxisPosSignSwitch8;
			public double AxisPosOffset1;
			public double AxisPosOffset2;
			public double AxisPosOffset3;
			public double AxisPosOffset4;
			public double AxisPosOffset5;
			public double AxisPosOffset6;
			public double AxisPosOffset7;
			public double AxisPosOffset8;

			public short CartUnitUse1;
			public short CartUnitUse2;
			public short CartUnitUse3;
			public short CartUnitUse4;
			public short CartUnitUse5;
			public short CartUnitUse6;
			public char CartPosKCSSignSwitch1;
			public char CartPosKCSSignSwitch2;
			public char CartPosKCSSignSwitch3;
			public char CartPosKCSSignSwitch4;
			public char CartPosKCSSignSwitch5;
			public char CartPosKCSSignSwitch6;
			public short reserved21;
			public short reserved22;
			public short reserved23;
			public double CartPosKCSOffset1;
			public double CartPosKCSOffset2;
			public double CartPosKCSOffset3;
			public double CartPosKCSOffset4;
			public double CartPosKCSOffset5;
			public double CartPosKCSOffset6;
		};

		public struct RC_ERROR_INTERFACE
		{
			public char Error;
			public short ErrorID;
			public string Message;
		};

		public struct RC_MSG_BUFFER_ELEMENT
		{
			public short ErrorID;
			public string Message;
			public string LogTime;
			public int InternalID;
		};

		public struct RC_MSG_BUFFER
		{
			public short LastMsgIndex;
			public RC_MSG_BUFFER_ELEMENT MsgElement1;
			public RC_MSG_BUFFER_ELEMENT MsgElement2;
			public RC_MSG_BUFFER_ELEMENT MsgElement3;
			public RC_MSG_BUFFER_ELEMENT MsgElement4;
			public RC_MSG_BUFFER_ELEMENT MsgElement5;
			public RC_MSG_BUFFER_ELEMENT MsgElement6;
			public RC_MSG_BUFFER_ELEMENT MsgElement7;
			public RC_MSG_BUFFER_ELEMENT MsgElement8;
			public RC_MSG_BUFFER_ELEMENT MsgElement9;
			public RC_MSG_BUFFER_ELEMENT MsgElement10;
			public RC_MSG_BUFFER_ELEMENT MsgElement11;
			public RC_MSG_BUFFER_ELEMENT MsgElement12;
			public RC_MSG_BUFFER_ELEMENT MsgElement13;
			public RC_MSG_BUFFER_ELEMENT MsgElement14;
			public RC_MSG_BUFFER_ELEMENT MsgElement15;
			public RC_MSG_BUFFER_ELEMENT MsgElement16;
			public RC_MSG_BUFFER_ELEMENT MsgElement17;
			public RC_MSG_BUFFER_ELEMENT MsgElement18;
			public RC_MSG_BUFFER_ELEMENT MsgElement19;
			public RC_MSG_BUFFER_ELEMENT MsgElement20;
			public RC_MSG_BUFFER_ELEMENT MsgElement21;
			public RC_MSG_BUFFER_ELEMENT MsgElement22;
			public RC_MSG_BUFFER_ELEMENT MsgElement23;
			public RC_MSG_BUFFER_ELEMENT MsgElement24;
			public RC_MSG_BUFFER_ELEMENT MsgElement25;
			public RC_MSG_BUFFER_ELEMENT MsgElement26;
			public RC_MSG_BUFFER_ELEMENT MsgElement27;
			public RC_MSG_BUFFER_ELEMENT MsgElement28;
			public RC_MSG_BUFFER_ELEMENT MsgElement29;
			public RC_MSG_BUFFER_ELEMENT MsgElement30;
			public RC_MSG_BUFFER_ELEMENT MsgElement31;
			public RC_MSG_BUFFER_ELEMENT MsgElement32;
			public int LastMsgID;
		};

		//旋转轴范围设置
		public struct TRotationAxisRange
		{
			public int primaryAxisRangeOn;              //第一旋转轴限定范围是否生效，0：不生效，1：生效
			public int slaveAxisRangeOn;                //第二旋转轴限定范围是否生效，0：不生效，1：生效
			public double maxPrimaryAngle;              //第一旋转轴最大值
			public double minPrimaryAngle;              //第一旋转轴最小值
			public double maxSlaveAngle;                //第二旋转轴最大值
			public double minSlaveAgnle;                //第二旋转轴最小值
		};

		//选解参数
		public enum EGroupSelect
		{
			Continuous = 0,
			Group_1,
			Group_2,
		};

		public struct TPos
		{
			public double machinePos1;
			public double machinePos2;
			public double machinePos3;
			public double machinePos4;
			public double machinePos5;
			public double workPos1;
			public double workPos2;
			public double workPos3;
			public double workPos4;
			public double workPos5;
			public double workPos6;
		};

		//速度规划模式
		public enum EVelMode
		{
			T_CURVE = 0,
			S_CURVE = 1,
			S_CURVE_NEW = 2,                  //根据加加速度、最大加速度进行S曲线速度前瞻，2015.11.16

			VEL_MODE_MAX = 0x10000,         //确保长度为4Byte
		};

		//////////////////////////////////
		public enum OptimizeState
		{
			OPT_OFF = 0,
			OPT_ON = 1
		};

		public enum OptimizeMethod
		{
			NO_OPT = 0,
			OPT_BLENDING = 1,
			OPT_CIRCLEFITTING = 2,
			OPT_CUBICSPLINE = 3,
			OPT_BSPLINE = 4
		};

		public enum ErrorID
		{
			INIT_ERROR = 1,     //没有进行参数初始化
			PASSWORD_ERROR = 2,     //密码错误，请在固高运动控制平台上运行
			INDATA_ERROR = 3,       //输入数据错误（检查圆弧数据是否正确）
			PRE_PROCESS_ERROR = 4,  //
			TOOL_RADIUS_COMPENSATE_ERROR_INOUT = 5,     //刀具半径补偿错误：进入/结束刀补处不能是圆弧
			TOOL_RADIUS_COMPENSATE_ERROR_NOCROSS = 6,   //刀具半径补偿错误：数据不合理，无法计算交点
			USERDATA_ERROR = 7,
		};

		//轨迹优化参数结构体
		public struct TOptimizeParamUser
		{
			public OptimizeState usePathOptimize;   //是否使用路径优化：OPT_OFF:不使用	OPT_ON:使用

			public float tolerance;             //公差(suggest: rough:0.1, pre-finish:0.05, finish:0.01)

			public OptimizeMethod optimizeMethod;   //选择曲线优化方式

			public OptimizeState keepLargeArc;      //是否保留大圆弧：OPT_OFF：不保留， OPT_ON：保留

			public float blendingMinError;          //blending的最小设定误差

			public float blendingMaxAngle;          //blending的最大角度限制（即当线段向量角度大于该角度时，不做blending，单位：度）

		};

		public struct TErrorInfo
		{
			public ErrorID errorID;     //错误号(INIT_ERROR:未初始化参数；PRE_PROCESS_ERROR:预处理模块错误；
										//TOOL_RADIUS_COMPENSATE_ERROR:刀具半径补偿错误；)
			public int errorRowNum;     //错误行号
		};

		public struct TPreStartPos
		{
			public double Pos1;
			public double Pos2;
			public double Pos3;
			public double Pos4;
			public double Pos5;
			public double Pos6;
			public double Pos7;
			public double Pos8;
		};

		public struct TBufIoDelayData
		{
			public ushort doType;
			public ushort doMask;
			public ushort doValue;
			public ushort delayTime;
			public short fifo;
		};

		public struct TBufDoBitPulseData
		{
			public short doType;
			public short doIndex;
			public ushort highLevelTime;
			public ushort lowLevelTime;
			public long pulseNum;
			public short firstLevel;
			public short fifo;
		};

		public struct TBufDaData
		{
			public short channel;
			public short daValue;
			public short fifo;
		};

		public struct TBufLaserData
		{
			public short channel;
			public short fifo;
			public short source;
			public double laserPower;
			public double ratio;
			public double minPower;
			public double maxPower;
			public short tableId;
		};

		public struct TBufGearData
		{
			public short axis;
			public double deltaPos;
			public short fifo;
			public short smoothFlag;
			public short accPercent;
			public short decPercent;
		};

		public struct TBufMoveData
		{
			public short axis;
			public double pos;
			public double vel;
			public short modal;
			public short fifo;
		};

		public struct TBufSegNumData
		{
			public long segNum;
			public short fifo;
		};

		//Look ahead Ex
		[DllImport("gts.dll")]
		public static extern short GT_SetupLookAheadCrd(short cardNum, short crd, EMachineMode machineMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetFollowAxisParaEx(short cardNum, short crd, ref short pAxisLimitMode, ref double pVmax, ref double pAmax, ref double pDVmax);
		[DllImport("gts.dll")]
		public static extern short GT_SetVelDefineModeLa(short cardNum, short crd, EVelSettingDef velDefMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisLimitModeLa(short cardNum, short crd, ref int pAxisLimitMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetWorkLimitModeLa(short cardNum, short crd, EWorkLimitMode workLimitMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisVelValidModeLa(short cardNum, short crd, int velValidAxis);
		[DllImport("gts.dll")]
		public static extern short GT_SetVelSmoothMode(short cardNum, int crd, int smoothMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetArcAllowErrorLa(short cardNum, short crd, double error);
		[DllImport("gts.dll")]
		public static extern short GT_InitLookAheadEx(short cardNum, short crd, ref TLookAheadParameter pLookAheadPara, short fifo, short motionMode, ref TPreStartPos pPreStartPos);
		[DllImport("gts.dll")]
		public static extern short GT_PrintLACmdLa(short cardNum, short crd, int printFlag, int clearFile);

		[DllImport("gts.dll")]
		public static extern short GT_LnXYEx(short cardNum, short crd, double x, double y, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYG0Ex(short cardNum, short crd, double x, double y, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZEx(short cardNum, short crd, double x, double y, double z, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZG0Ex(short cardNum, short crd, double x, double y, double z, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAEx(short cardNum, short crd, double x, double y, double z, double a, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAG0Ex(short cardNum, short crd, double x, double y, double z, double a, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZACEx(short cardNum, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZACG0Ex(short cardNum, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZACUVWEx(short cardNum, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZACUVWG0Ex(short cardNum, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYREx(short cardNum, short crd, double x, double y, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZREx(short cardNum, short crd, double y, double z, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXREx(short cardNum, short crd, double z, double x, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYCEx(short cardNum, short crd, double x, double y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZCEx(short cardNum, short crd, double y, double z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXCEx(short cardNum, short crd, double z, double x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYZEx(short cardNum, short crd, double x, double y, double z, double interX, double interY, double interZ, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYRZEx(short cardNum, short crd, double x, double y, double z, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYCZEx(short cardNum, short crd, double x, double y, double z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufDelayEx(short cardNum, short crd, ushort delayTime, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufGearEx(short cardNum, short crd, short gearAxis, double deltaPos, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufGearPercentEx(short cardNum, short crd, short gearAxis, double deltaPos, short accPercent, short decPercent, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufMoveEx(short cardNum, short crd, short moveAxis, double pos, double vel, double acc, short modal, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufIOEx(short cardNum, short crd, ushort doType, ushort doMask, ushort doValue, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufDAEx(short cardNum, short crd, short chn, short daValue, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_SetUserSegNumEx(short cardNum, short crd, int segNum, short fifo);

		//Add By lin.ga 20150330
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserOnEx(short cardNum, short crd, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserOffEx(short cardNum, short crd, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserPrfCmdEx(short cardNum, short crd, double laserPower, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowRatioEx(short cardNum, short crd, double ratio, double minPower, double maxPower, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowModeEx(short cardNum, short crd, short source, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowSplineEx(short cardNum, short crd, short tableId, double minPower, double maxPower, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowOffEx(short cardNum, short crd, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufDisableDoBitPulseEx(short cardNum, short crd, short doType, short doIndex, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufEnableDoBitPulseEx(short cardNum, short crd, short doType, short doIndex, ushort highLevelTime, ushort lowLevelTime, int pulseNum, short firstLevel, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_CrdDataEx(short cardNum, short crd, System.IntPtr pCrdData, short fifo);  //调用时传入 IntPtr.Zero GT_CrdDataEx(1, System.IntPtr.Zero, 0);
		[DllImport("gts.dll")]
		public static extern short GT_CrdDataExEx(short cardNum, short crd, System.IntPtr pCrdData, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetLookAheadSegCountEx(short cardNum, short crd, out int pSegCount, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetMotionTimeEx(short cardNum, short crd, out double pTime, short fifo);

		/////////////////////////////////////////////////////////////////////////////////////////
		/////////////////lin.ga 20150701 Add PathOpt Fuction/////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////
		[DllImport("gts.dll")]
		public static extern short GT_SetPathOptPara(short cardNum, short crd, ref TOptimizeParamUser optPrm, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetPathOptErrorInfo(short cardNum, short crd, ref TErrorInfo errorInfo, short fifo);


		//5 Axis
		[DllImport("gts.dll")]
		public static extern short GT_CrdRTCPOn(short cardNum, short crd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_CrdRTCPOff(short cardNum, short crd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_UpdateMachineBuildingFile(short cardNum, short crd, int update);
		[DllImport("gts.dll")]
		public static extern short GT_InitialMachineBuilding(short cardNum, short crd, string pMachineCfgFileName, ref double machineCoordCenter, ref double workCoordCenter, double toolLength);
		[DllImport("gts.dll")]
		public static extern short GT_SetRotationAxisRange(short cardNum, short crd, ref TRotationAxisRange pRotationAxisRange);
		[DllImport("gts.dll")]
		public static extern short GT_SetInverseSolutionSelectPara(short cardNum, short crd, EGroupSelect groupSelect, int priorAxisSet);
		[DllImport("gts.dll")]
		public static extern short GT_MachineForwardTrans(short cardNum, short crd, ref double pMachinePos, out double pWorkPos);
		[DllImport("gts.dll")]
		public static extern short GT_MachineRTCPTrans(short cardNum, short crd, ref double pInputPos, ref double pMachinePos, ref double pWorkPos);
		[DllImport("gts.dll")]
		public static extern short GT_MachineTransformation(short cardNum, short crd, int posType, ref double pPrePos, ref double pPos, ref int pPosNum, ref TPos pReturnPos);
		[DllImport("gts.dll")]
		public static extern short GT_SetCompToolLength(short cardNum, short crd, double compToolLength);
		[DllImport("gts.dll")]
		public static extern short GT_SetCompWorkCoordOffset(short cardNum, short crd, ref double pCompWorkOffset);
		[DllImport("gts.dll")]
		public static extern short GT_SetNonlinearErrorControl(short cardNum, short crd, int enable, double nonlinearError);
		[DllImport("gts.dll")]
		public static extern short GT_EnableDiscreateArc(short cardNum, short crd, short enable, double arcError);
		[DllImport("gts.dll")]
		public static extern short GT_StartXYCMachineMode(short cardNum, short crd, short dir, double contactAngle, double rotationAngle, ref double pTranslation, double aValue, short fifo);//启动XYC模式
		[DllImport("gts.dll")]
		public static extern short GT_EndXYCMachineMode(short cardNum, short crd, short fifo);                                                   //退出XYC模式
		[DllImport("gts.dll")]
		public static extern short GT_SetWorkCrdPlane(short cardNum, short crd, short enable, ref double pNormVector, ref double pPoint, short fifo);    //设置玻璃加工平面参数
		[DllImport("gts.dll")]
		public static extern short GT_SetStartPointProcessMode(short cardNum, short crd, short enable, double z, short fifo);                      //预处理第一段xyc数据
		[DllImport("gts.dll")]
		public static extern short GT_InitialMachineBuildingEx(short cardNum, short crd, string pMachineCfgFileName, ref double machineCoordCenter, ref double workCoordCenter, double toolLength);
		[DllImport("gts.dll")]
		public static extern short GT_SetWorkCrdLaserFollowMode(short cardNum, short crd, short enbale, short fifo, short chn);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYRACEx(short cardNum, short crd, double x, double y, double a, double c, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYCACEx(short cardNum, short crd, double x, double y, double a, double c, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYZACEx(short cardNum, short crd, double x, double y, double z, double a, double c, double interX, double interY, double interZ, double interA, double interC, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXRACEx(short cardNum, short crd, double z, double x, double a, double c, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZRACEx(short cardNum, short crd, double y, double z, double a, double c, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZCACEx(short cardNum, short crd, double y, double z, double a, double c, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXCACEx(short cardNum, short crd, double z, double x, double a, double c, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	}
	public class mc
	{
		public const short DLL_VERSION_0 = 2;
		public const short DLL_VERSION_1 = 1;
		public const short DLL_VERSION_2 = 0;

		public const short DLL_VERSION_3 = 1;
		public const short DLL_VERSION_4 = 5;
		public const short DLL_VERSION_5 = 0;
		public const short DLL_VERSION_6 = 6;
		public const short DLL_VERSION_7 = 0;
		public const short DLL_VERSION_8 = 7;

		public const short MC_NONE = -1;

		public const short MC_LIMIT_POSITIVE = 0;
		public const short MC_LIMIT_NEGATIVE = 1;
		public const short MC_ALARM = 2;
		public const short MC_HOME = 3;
		public const short MC_GPI = 4;
		public const short MC_ARRIVE = 5;
		public const short MC_MPG = 6;

		public const short MC_ENABLE = 10;
		public const short MC_CLEAR = 11;
		public const short MC_GPO = 12;

		public const short MC_DAC = 20;
		public const short MC_STEP = 21;
		public const short MC_PULSE = 22;
		public const short MC_ENCODER = 23;
		public const short MC_ADC = 24;

		public const short MC_AXIS = 30;
		public const short MC_PROFILE = 31;
		public const short MC_CONTROL = 32;

		public const short CAPTURE_HOME = 1;
		public const short CAPTURE_INDEX = 2;
		public const short CAPTURE_PROBE = 3;
		public const short CAPTURE_HSIO0 = 6;
		public const short CAPTURE_HSIO1 = 7;
		public const short CAPTURE_HOME_GPI = 8;

		public const short PT_MODE_STATIC = 0;
		public const short PT_MODE_DYNAMIC = 1;

		public const short PT_SEGMENT_NORMAL = 0;
		public const short PT_SEGMENT_EVEN = 1;
		public const short PT_SEGMENT_STOP = 2;

		public const short GEAR_MASTER_ENCODER = 1;
		public const short GEAR_MASTER_PROFILE = 2;
		public const short GEAR_MASTER_AXIS = 3;

		public const short FOLLOW_MASTER_ENCODER = 1;
		public const short FOLLOW_MASTER_PROFILE = 2;
		public const short FOLLOW_MASTER_AXIS = 3;

		public const short FOLLOW_EVENT_START = 1;
		public const short FOLLOW_EVENT_PASS = 2;

		public const short GEAR_EVENT_START = 1;
		public const short GEAR_EVENT_PASS = 2;
		public const short GEAR_EVENT_AREA = 5;

		public const short FOLLOW_SEGMENT_NORMAL = 0;
		public const short FOLLOW_SEGMENT_EVEN = 1;
		public const short FOLLOW_SEGMENT_STOP = 2;
		public const short FOLLOW_SEGMENT_CONTINUE = 3;

		public const short INTERPOLATION_AXIS_MAX = 4;
		public const short CRD_FIFO_MAX = 4096;
		public const short FIFO_MAX = 2;
		public const short CRD_MAX = 2;
		public const short CRD_OPERATION_DATA_EXT_MAX = 2;

		public const short CRD_OPERATION_TYPE_NONE = 0;
		public const short CRD_OPERATION_TYPE_BUF_IO_DELAY = 1;
		public const short CRD_OPERATION_TYPE_LASER_ON = 2;
		public const short CRD_OPERATION_TYPE_LASER_OFF = 3;
		public const short CRD_OPERATION_TYPE_BUF_DA = 4;
		public const short CRD_OPERATION_TYPE_LASER_CMD = 5;
		public const short CRD_OPERATION_TYPE_LASER_FOLLOW = 6;
		public const short CRD_OPERATION_TYPE_LMTS_ON = 7;
		public const short CRD_OPERATION_TYPE_LMTS_OFF = 8;
		public const short CRD_OPERATION_TYPE_SET_STOP_IO = 9;
		public const short CRD_OPERATION_TYPE_BUF_MOVE = 10;
		public const short CRD_OPERATION_TYPE_BUF_GEAR = 11;
		public const short CRD_OPERATION_TYPE_SET_SEG_NUM = 12;
		public const short CRD_OPERATION_TYPE_STOP_MOTION = 13;
		public const short CRD_OPERATION_TYPE_SET_VAR_VALUE = 14;
		public const short CRD_OPERATION_TYPE_JUMP_NEXT_SEG = 15;
		public const short CRD_OPERATION_TYPE_SYNCH_PRF_POS = 16;
		public const short CRD_OPERATION_TYPE_VIRTUAL_TO_ACTUAL = 17;
		public const short CRD_OPERATION_TYPE_SET_USER_VAR = 18;
		public const short CRD_OPERATION_TYPE_SET_DO_BIT_PULSE = 19;
		public const short CRD_OPERATION_TYPE_BUF_COMPAREPULSE = 20;
		public const short CRD_OPERATION_TYPE_LASER_ON_EX = 21;
		public const short CRD_OPERATION_TYPE_LASER_OFF_EX = 22;
		public const short CRD_OPERATION_TYPE_LASER_CMD_EX = 23;
		public const short CRD_OPERATION_TYPE_LASER_FOLLOW_RATIO_EX = 24;
		public const short CRD_OPERATION_TYPE_LASER_FOLLOW_MODE = 25;
		public const short CRD_OPERATION_TYPE_LASER_FOLLOW_OFF = 26;
		public const short CRD_OPERATION_TYPE_LASER_FOLLOW_OFF_EX = 27;
		public const short CRD_OPERATION_TYPE_LASER_FOLLOW_SPLINE = 28;
		public const short CRD_OPERATION_TYPE_MOTION_DATA = 29;

		public const short CRD_OPERATION_TYPE_BUF_TREND = 50;

		public const short CRD_OPERATION_TYPE_BUF_EVENT_ON = 70;
		public const short CRD_OPERATION_TYPE_BUF_EVENT_OFF = 71;

		public const short INTERPOLATION_MOTION_TYPE_LINE = 0;
		public const short INTERPOLATION_MOTION_TYPE_CIRCLE = 1;
		public const short INTERPOLATION_MOTION_TYPE_HELIX = 2;
		public const short INTERPOLATION_MOTION_TYPE_CIRCLE_3D = 3;

		public const short INTERPOLATION_CIRCLE_PLAT_XY = 0;
		public const short INTERPOLATION_CIRCLE_PLAT_YZ = 1;
		public const short INTERPOLATION_CIRCLE_PLAT_ZX = 2;

		public const short INTERPOLATION_HELIX_CIRCLE_XY_LINE_Z = 0;
		public const short INTERPOLATION_HELIX_CIRCLE_YZ_LINE_X = 1;
		public const short INTERPOLATION_HELIX_CIRCLE_ZX_LINE_Y = 2;

		public const short INTERPOLATION_CIRCLE_DIR_CW = 0;
		public const short INTERPOLATION_CIRCLE_DIR_CCW = 1;

		public const short COMPARE_PORT_HSIO = 0;
		public const short COMPARE_PORT_GPO = 1;

		public const short COMPARE2D_MODE_2D = 1;
		public const short COMPARE2D_MODE_1D = 0;

		public const short INTERFACEBOARD20 = 2;
		public const short INTERFACEBOARD30 = 3;

		public const short AXIS_LASER = 7;
		public const short AXIS_LASER_EX = 8;

		public const short LASER_CTRL_MODE_PWM1 = 0;
		public const short LASER_CTRL_FREQUENCY = 1;
		public const short LASER_CTRL_VOLTAGE = 2;
		public const short LASER_CTRL_MODE_PWM2 = 3;

		public const short CRD_BUFFER_MODE_DYNAMIC_DEFAULT = 0;
		public const short CRD_BUFFER_MODE_DYNAMIC_KEEP = 1;
		public const short CRD_BUFFER_MODE_STATIC_INPUT = 11;
		public const short CRD_BUFFER_MODE_STATIC_READY = 12;
		public const short CRD_BUFFER_MODE_STATIC_START = 13;

		public const short CRD_SMOOTH_MODE_NONE = 0;
		public const short CRD_SMOOTH_MODE_PERCENT = 1;
		public const short CRD_SMOOTH_MODE_JERK = 2;

		public struct TTrapPrm
		{
			public double acc;
			public double dec;
			public double velStart;
			public short smoothTime;
		}

		public struct TJogPrm
		{
			public double acc;
			public double dec;
			public double smooth;
		}

		public struct TPid
		{
			public double kp;
			public double ki;
			public double kd;
			public double kvff;
			public double kaff;

			public int integralLimit;
			public int derivativeLimit;
			public short limit;
		}

		public struct TThreadSts
		{
			public short run;
			public short error;
			public double result;
			public short line;
		}

		public struct TVarInfo
		{
			public short id;
			public short dataType;
			public double dumb0;
			public double dumb1;
			public double dumb2;
			public double dumb3;
		}
		public struct TCompileInfo
		{
			public string pFileName;
			public short pLineNo1;
			public short pLineNo2;
			public string pMessage;
		}
		public struct TCrdPrm
		{
			public short dimension;
			public short profile1;
			public short profile2;
			public short profile3;
			public short profile4;
			public short profile5;
			public short profile6;
			public short profile7;
			public short profile8;

			public double synVelMax;
			public double synAccMax;
			public short evenTime;
			public short setOriginFlag;
			public int originPos1;
			public int originPos2;
			public int originPos3;
			public int originPos4;
			public int originPos5;
			public int originPos6;
			public int originPos7;
			public int originPos8;
		}

		public struct TCrdBufOperation
		{
			public short flag;
			public ushort delay;
			public short doType;
			public ushort doMask;
			public ushort doValue;
			public ushort dataExt1;
			public ushort dataExt2;
		}

		public struct TCrdData
		{
			public short motionType;
			public short circlePlat;
			public int pos1;
			public int pos2;
			public int pos3;
			public int pos4;
			public int pos5;
			public int pos6;
			public int pos7;
			public int pos8;
			public double radius;
			public short circleDir;
			public double lCenterX;
			public double lCenterY;
			public double lCenterZ;
			public double vel;
			public double acc;
			public short velEndZero;
			public TCrdBufOperation operation;

			public double cos1;
			public double cos2;
			public double cos3;
			public double cos4;
			public double cos5;
			public double cos6;
			public double cos7;
			public double cos8;
			public double velEnd;
			public double velEndAdjust;
			public double r;
		}

		public struct TTrigger
		{
			public short encoder;
			public short probeType;
			public short probeIndex;
			public short offset;
			public short windowOnly;
			public int firstPosition;
			public int lastPosition;
		}

		public struct TTriggerStatus
		{
			public short execute;
			public short done;
			public int position;
		}

		public struct TTriggerStatusEx
		{
			public short execute;
			public short done;
			public int position;
			public int clock;
			public int loopCount;
		}

		public struct T2DCompareData
		{
			public int px;
			public int py;
		}

		public struct T2DComparePrm
		{
			public short encx;
			public short ency;
			public short source;
			public short outputType;
			public short startLevel;
			public short time;
			public short maxerr;
			public short threshold;
		}

		public struct TCrdTime
		{
			public double time;
			public int segmentUsed;
			public int segmentHead;
			public int segmentTail;
		}

		public struct TCrdSmoothInfo
		{
			public short enable;
			public short smoothMode;
			public short percent;
			public short accStartPercent;
			public short decEndPercent;
			public double jerkMax;
		}

		public struct TCrdSmooth
		{
			public short percent;
			public short accStartPercent;
			public short decEndPercent;
			public double reserve;
		}

		public struct TBufFollowMaster
		{
			public short crdAxis;
			public short masterIndex;
			public short masterType;
		}
		public struct TBufFollowEventCross
		{
			public int masterPos;
			public int pad;
		}
		public struct TBufFollowEventTrigger
		{
			public short triggerIndex;
			public int triggerOffset;
			public int pad;
		}
		public struct TCrdFollowStatus
		{
			public short stage;
			public double slavePos;
			public double slaveVel;
			public uint loopCount;
		}
		public struct TCrdFollowPrm
		{
			public double velRatioMax;
			public double accRatioMax;
			public int masterLead;
			public int masterEven;
			public int slaveEven;
			public short dir;
			public short smoothPercent;
			public short synchAlign;
		}
		[DllImport("gts.dll")]
		public static extern short GT_GetDllVersion(short cardNum, out string pDllVersion);
		[DllImport("gts.dll")]
		public static extern short GT_SetCardNo(short cardNum, short index);
		[DllImport("gts.dll")]
		public static extern short GT_GetCardNo(short cardNum, out short index);

		[DllImport("gts.dll")]
		public static extern short GT_GetVersion(short cardNum, out string pVersion);
		[DllImport("gts.dll")]
		public static extern short GT_GetInterfaceBoardSts(short cardNum, out short pStatus);
		[DllImport("gts.dll")]
		public static extern short GT_SetInterfaceBoardSts(short cardNum, short type);

		[DllImport("gts.dll")]
		public static extern short GT_Open(short cardNum, short channel, short param);
		[DllImport("gts.dll")]
		public static extern short GT_Close(short cardNum);

		[DllImport("gts.dll")]
		public static extern short GT_LoadConfig(short cardNum, string pFile);

		[DllImport("gts.dll")]
		public static extern short GT_AlarmOff(short cardNum, short axis);
		[DllImport("gts.dll")]
		public static extern short GT_AlarmOn(short cardNum, short axis);
		[DllImport("gts.dll")]
		public static extern short GT_LmtsOn(short cardNum, short axis, short limitType);
		[DllImport("gts.dll")]
		public static extern short GT_LmtsOff(short cardNum, short axis, short limitType);
		[DllImport("gts.dll")]
		public static extern short GT_ProfileScale(short cardNum, short axis, short alpha, short beta);
		[DllImport("gts.dll")]
		public static extern short GT_EncScale(short cardNum, short axis, short alpha, short beta);
		[DllImport("gts.dll")]
		public static extern short GT_StepDir(short cardNum, short step);
		[DllImport("gts.dll")]
		public static extern short GT_StepPulse(short cardNum, short step);
		[DllImport("gts.dll")]
		public static extern short GT_SetMtrBias(short cardNum, short dac, short bias);
		[DllImport("gts.dll")]
		public static extern short GT_GetMtrBias(short cardNum, short dac, out short pBias);
		[DllImport("gts.dll")]
		public static extern short GT_SetMtrLmt(short cardNum, short dac, short limit);
		[DllImport("gts.dll")]
		public static extern short GT_GetMtrLmt(short cardNum, short dac, out short pLimit);
		[DllImport("gts.dll")]
		public static extern short GT_EncSns(short cardNum, ushort sense);
		[DllImport("gts.dll")]
		public static extern short GT_EncOn(short cardNum, short encoder);
		[DllImport("gts.dll")]
		public static extern short GT_EncOff(short cardNum, short encoder);
		[DllImport("gts.dll")]
		public static extern short GT_SetPosErr(short cardNum, short control, int error);
		[DllImport("gts.dll")]
		public static extern short GT_GetPosErr(short cardNum, short control, out int pError);
		[DllImport("gts.dll")]
		public static extern short GT_SetStopDec(short cardNum, short profile, double decSmoothStop, double decAbruptStop);
		[DllImport("gts.dll")]
		public static extern short GT_GetStopDec(short cardNum, short profile, out double pDecSmoothStop, out double pDecAbruptStop);
		[DllImport("gts.dll")]
		public static extern short GT_LmtSns(short cardNum, ushort sense);
		[DllImport("gts.dll")]
		public static extern short GT_CtrlMode(short cardNum, short axis, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_SetStopIo(short cardNum, short axis, short stopType, short inputType, short inputIndex);
		[DllImport("gts.dll")]
		public static extern short GT_GpiSns(short cardNum, ushort sense);
		[DllImport("gts.dll")]
		public static extern short GT_SetAdcFilter(short cardNum, short adc, short filterTime);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisPrfVelFilter(short cardNum, short axis, short filterNumExp);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisPrfVelFilter(short cardNum, short axis, out short pFilterNumExp);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisEncVelFilter(short cardNum, short axis, short filterNumExp);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisEncVelFilter(short cardNum, short axis, out short pFilterNumExp);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisInputShaping(short cardNum, short axis, short enable, short count, double k);

		[DllImport("gts.dll")]
		public static extern short GT_SetDo(short cardNum, short doType, int value);
		[DllImport("gts.dll")]
		public static extern short GT_SetDoBit(short cardNum, short doType, short doIndex, short value);
		[DllImport("gts.dll")]
		public static extern short GT_GetDo(short cardNum, short doType, out int pValue);
		[DllImport("gts.dll")]
		public static extern short GT_SetDoBitReverse(short cardNum, short doType, short doIndex, short value, short reverseTime);
		[DllImport("gts.dll")]
		public static extern short GT_SetDoMask(short cardNum, short doType, ushort doMask, int value);
		[DllImport("gts.dll")]
		public static extern short GT_EnableDoBitPulse(short cardNum, short doType, short doIndex, ushort highLevelTime, ushort lowLevelTime, int pulseNum, short firstLevel);
		[DllImport("gts.dll")]
		public static extern short GT_DisableDoBitPulse(short cardNum, short doType, short doIndex);

		[DllImport("gts.dll")]
		public static extern short GT_GetDi(short cardNum, short diType, out int pValue);
		[DllImport("gts.dll")]
		public static extern short GT_GetDiReverseCount(short cardNum, short diType, short diIndex, out uint reverseCount, short count);
		[DllImport("gts.dll")]
		public static extern short GT_SetDiReverseCount(short cardNum, short diType, short diIndex, ref uint reverseCount, short count);
		[DllImport("gts.dll")]
		public static extern short GT_GetDiRaw(short cardNum, short diType, out int pValue);

		[DllImport("gts.dll")]
		public static extern short GT_SetDac(short cardNum, short dac, ref short value, short count);
		[DllImport("gts.dll")]
		public static extern short GT_GetDac(short cardNum, short dac, out short value, short count, out uint pClock);

		[DllImport("gts.dll")]
		public static extern short GT_GetAdc(short cardNum, short adc, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetAdcValue(short cardNum, short adc, out short pValue, short count, out uint pClock);

		[DllImport("gts.dll")]
		public static extern short GT_SetEncPos(short cardNum, short encoder, int encPos);
		[DllImport("gts.dll")]
		public static extern short GT_GetEncPos(short cardNum, short encoder, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetEncPosPre(short cardNum, short encoder, out double pValue, short count, uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetEncVel(short cardNum, short encoder, out double pValue, short count, out uint pClock);

		[DllImport("gts.dll")]
		public static extern short GT_SetCaptureMode(short cardNum, short encoder, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_GetCaptureMode(short cardNum, short encoder, out short pMode, short count);
		[DllImport("gts.dll")]
		public static extern short GT_GetCaptureStatus(short cardNum, short encoder, out short pStatus, out int pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_SetCaptureSense(short cardNum, short encoder, short mode, short sense);
		[DllImport("gts.dll")]
		public static extern short GT_ClearCaptureStatus(short cardNum, short encoder);
		[DllImport("gts.dll")]
		public static extern short GT_SetCaptureRepeat(short cardNum, short encoder, short count);
		[DllImport("gts.dll")]
		public static extern short GT_GetCaptureRepeatStatus(short cardNum, short encoder, out short pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetCaptureRepeatPos(short cardNum, short encoder, out int pValue, short startNum, short count);
		[DllImport("gts.dll")]
		public static extern short GT_SetCaptureEncoder(short cardNum, short trigger, short encoder);
		[DllImport("gts.dll")]
		public static extern short GT_GetCaptureWidth(short cardNum, short trigger, out short pWidth, short count);
		[DllImport("gts.dll")]
		public static extern short GT_GetCaptureHomeGpi(short cardNum, short trigger, out short pHomeSts, out short pHomePos, out short pGpiSts, out short pGpiPos, short count);

		[DllImport("gts.dll")]
		public static extern short GT_Reset(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_GetClock(short cardNum, out uint pClock, out uint pLoop);
		[DllImport("gts.dll")]
		public static extern short GT_GetClockHighPrecision(short cardNum, out uint pClock);

		[DllImport("gts.dll")]
		public static extern short GT_GetSts(short cardNum, short axis, out int pSts, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_ClrSts(short cardNum, short axis, short count);
		[DllImport("gts.dll")]
		public static extern short GT_AxisOn(short cardNum, short axis);
		[DllImport("gts.dll")]
		public static extern short GT_AxisOff(short cardNum, short axis);
		[DllImport("gts.dll")]
		public static extern short GT_Stop(short cardNum, int mask, int option);
		[DllImport("gts.dll")]
		public static extern short GT_SetPrfPos(short cardNum, short profile, int prfPos);
		[DllImport("gts.dll")]
		public static extern short GT_SynchAxisPos(short cardNum, int mask);
		[DllImport("gts.dll")]
		public static extern short GT_ZeroPos(short cardNum, short axis, short count);

		[DllImport("gts.dll")]
		public static extern short GT_SetSoftLimit(short cardNum, short axis, int positive, int negative);
		[DllImport("gts.dll")]
		public static extern short GT_GetSoftLimit(short cardNum, short axis, out int pPositive, out int pNegative);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisBand(short cardNum, short axis, int band, int time);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisBand(short cardNum, short axis, out int pBand, out int pTime);
		[DllImport("gts.dll")]
		public static extern short GT_SetBacklash(short cardNum, short axis, int compValue, double compChangeValue, int compDir);
		[DllImport("gts.dll")]
		public static extern short GT_GetBacklash(short cardNum, short axis, out int pCompValue, out double pCompChangeValue, out int pCompDir);
		[DllImport("gts.dll")]
		public static extern short GT_SetLeadScrewComp(short cardNum, short axis, short n, int startPos, int lenPos, out int pCompPos, out int pCompNeg);
		[DllImport("gts.dll")]
		public static extern short GT_EnableLeadScrewComp(short cardNum, short axis, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_GetCompensate(short cardNum, short axis, out double pPitchError, out double pCrossError, out double pBacklashError, out double pEncPos, out double pPrfPos);

		[DllImport("gts.dll")]
		public static extern short GT_EnableGantry(short cardNum, short gantryMaster, short gantrySlave, double masterKp, double slaveKp);
		[DllImport("gts.dll")]
		public static extern short GT_DisableGantry(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_SetGantryErrLmt(short cardNum, int gantryErrLmt);
		[DllImport("gts.dll")]
		public static extern short GT_GetGantryErrLmt(short cardNum, out int pGantryErrLmt);
		[DllImport("gts.dll")]
		public static extern short GT_ZeroGantryPos(short cardNum, short gantryMaster, short gantrySlave);

		[DllImport("gts.dll")]
		public static extern short GT_GetPrfPos(short cardNum, short profile, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetPrfVel(short cardNum, short profile, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetPrfAcc(short cardNum, short profile, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetPrfMode(short cardNum, short profile, out int pValue, short count, out uint pClock);

		[DllImport("gts.dll")]
		public static extern short GT_GetAxisPrfPos(short cardNum, short axis, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisPrfVel(short cardNum, short axis, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisPrfAcc(short cardNum, short axis, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisEncPos(short cardNum, short axis, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisEncVel(short cardNum, short axis, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisEncAcc(short cardNum, short axis, out double pValue, short count, out uint pClock);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisError(short cardNum, short axis, out double pValue, short count, out uint pClock);

		[DllImport("gts.dll")]
		public static extern short GT_SetLongVar(short cardNum, short index, int value);
		[DllImport("gts.dll")]
		public static extern short GT_GetLongVar(short cardNum, short index, out int pValue);
		[DllImport("gts.dll")]
		public static extern short GT_SetDoubleVar(short cardNum, short index, double pValue);
		[DllImport("gts.dll")]
		public static extern short GT_GetDoubleVar(short cardNum, short index, out double pValue);

		[DllImport("gts.dll")]
		public static extern short GT_SetControlFilter(short cardNum, short control, short index);
		[DllImport("gts.dll")]
		public static extern short GT_GetControlFilter(short cardNum, short control, out short pIndex);

		[DllImport("gts.dll")]
		public static extern short GT_SetPid(short cardNum, short control, short index, ref TPid pPid);
		[DllImport("gts.dll")]
		public static extern short GT_GetPid(short cardNum, short control, short index, out TPid pPid);

		[DllImport("gts.dll")]
		public static extern short GT_SetKvffFilter(short cardNum, short control, short index, short kvffFilterExp, double accMax);
		[DllImport("gts.dll")]
		public static extern short GT_GetKvffFilter(short cardNum, short control, short index, out short pKvffFilterExp, out double pAccMax);

		[DllImport("gts.dll")]
		public static extern short GT_Update(short cardNum, int mask);
		[DllImport("gts.dll")]
		public static extern short GT_SetPos(short cardNum, short profile, int pos);
		[DllImport("gts.dll")]
		public static extern short GT_GetPos(short cardNum, short profile, out int pPos);
		[DllImport("gts.dll")]
		public static extern short GT_SetVel(short cardNum, short profile, double vel);
		[DllImport("gts.dll")]
		public static extern short GT_GetVel(short cardNum, short profile, out double pVel);

		[DllImport("gts.dll")]
		public static extern short GT_PrfTrap(short cardNum, short profile);
		[DllImport("gts.dll")]
		public static extern short GT_SetTrapPrm(short cardNum, short profile, ref TTrapPrm pPrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetTrapPrm(short cardNum, short profile, out TTrapPrm pPrm);

		[DllImport("gts.dll")]
		public static extern short GT_PrfJog(short cardNum, short profile);
		[DllImport("gts.dll")]
		public static extern short GT_SetJogPrm(short cardNum, short profile, ref TJogPrm pPrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetJogPrm(short cardNum, short profile, out TJogPrm pPrm);

		[DllImport("gts.dll")]
		public static extern short GT_PrfPt(short cardNum, short profile, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_SetPtLoop(short cardNum, short profile, int loop);
		[DllImport("gts.dll")]
		public static extern short GT_GetPtLoop(short cardNum, short profile, out int pLoop);
		[DllImport("gts.dll")]
		public static extern short GT_PtSpace(short cardNum, short profile, out short pSpace, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_PtData(short cardNum, short profile, double pos, int time, short type, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_PtDataWN(short cardNum, short profile, double pos, int time, short type, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_PtClear(short cardNum, short profile, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_PtStart(short cardNum, int mask, int option);
		[DllImport("gts.dll")]
		public static extern short GT_SetPtMemory(short cardNum, short profile, short memory);
		[DllImport("gts.dll")]
		public static extern short GT_GetPtMemory(short cardNum, short profile, out short pMemory);
		[DllImport("gts.dll")]
		public static extern short GT_PtGetSegNum(short cardNum, short profile, out int pSegNum);
		[DllImport("gts.dll")]
		public static extern short GT_SetPtPrecisionMode(short cardNum, short profile, short precisionMode);
		[DllImport("gts.dll")]
		public static extern short GT_GetPtPrecisionMode(short cardNum, short profile, out short pPrecisionMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetPtVel(short cardNum, short profile, double velLast, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_SetPtLink(short cardNum, short profile, short fifo, short list);
		[DllImport("gts.dll")]
		public static extern short GT_GetPtLink(short cardNum, short profile, short fifo, out short pList);
		[DllImport("gts.dll")]
		public static extern short GT_PtDoBit(short cardNum, short profile, short doType, short index, short value, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_PtAo(short cardNum, short profile, short aoType, short index, double value, short fifo);

		[DllImport("gts.dll")]
		public static extern short GT_PrfGear(short cardNum, short profile, short dir);
		[DllImport("gts.dll")]
		public static extern short GT_SetGearMaster(short cardNum, short profile, short masterIndex, short masterType, short masterItem);
		[DllImport("gts.dll")]
		public static extern short GT_GetGearMaster(short cardNum, short profile, out short pMasterIndex, out short pMasterType, out short pMasterItem);
		[DllImport("gts.dll")]
		public static extern short GT_SetGearRatio(short cardNum, short profile, int masterEven, int slaveEven, int masterSlope);
		[DllImport("gts.dll")]
		public static extern short GT_GetGearRatio(short cardNum, short profile, out int pMasterEven, out int pSlaveEven, out int pMasterSlope);
		[DllImport("gts.dll")]
		public static extern short GT_GearStart(short cardNum, int mask);
		[DllImport("gts.dll")]
		public static extern short GT_SetGearEvent(short cardNum, short profile, short gearEvent, int startPara0, int startPara1);
		[DllImport("gts.dll")]
		public static extern short GT_GetGearEvent(short cardNum, short profile, out short pEvent, out int pStartPara0, out int pStartPara1);

		[DllImport("gts.dll")]
		public static extern short GT_PrfFollow(short cardNum, short profile, short dir);
		[DllImport("gts.dll")]
		public static extern short GT_SetFollowMaster(short cardNum, short profile, short masterIndex, short masterType, short masterItem);
		[DllImport("gts.dll")]
		public static extern short GT_GetFollowMaster(short cardNum, short profile, out short pMasterIndex, out short pMasterType, out short pMasterItem);
		[DllImport("gts.dll")]
		public static extern short GT_SetFollowLoop(short cardNum, short profile, int loop);
		[DllImport("gts.dll")]
		public static extern short GT_GetFollowLoop(short cardNum, short profile, out int pLoop);
		[DllImport("gts.dll")]
		public static extern short GT_SetFollowEvent(short cardNum, short profile, short followEvent, short masterDir, int pos);
		[DllImport("gts.dll")]
		public static extern short GT_GetFollowEvent(short cardNum, short profile, out short pFollowEvent, out short pMasterDir, out int pPos);
		[DllImport("gts.dll")]
		public static extern short GT_FollowSpace(short cardNum, short profile, out short pSpace, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_FollowData(short cardNum, short profile, int masterSegment, double slaveSegment, short type, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_FollowClear(short cardNum, short profile, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_FollowStart(short cardNum, int mask, int option);
		[DllImport("gts.dll")]
		public static extern short GT_FollowSwitch(short cardNum, int mask);
		[DllImport("gts.dll")]
		public static extern short GT_SetFollowMemory(short cardNum, short profile, short memory);
		[DllImport("gts.dll")]
		public static extern short GT_GetFollowMemory(short cardNum, short profile, out short memory);
		[DllImport("gts.dll")]
		public static extern short GT_GetFollowStatus(short cardNum, short profile, out short pFifoNum, out short pSwitchStatus);
		[DllImport("gts.dll")]
		public static extern short GT_SetFollowPhasing(short cardNum, short profile, short profilePhasing);
		[DllImport("gts.dll")]
		public static extern short GT_GetFollowPhasing(short cardNum, short profile, out short pProfilePhasing);

		[DllImport("gts.dll")]
		public static extern short GT_BufFollowMaster(short cardNum, short crd, ref TBufFollowMaster pBufFollowMaster, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufFollowEventCross(short cardNum, short crd, ref TBufFollowEventCross pEventCross, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufFollowEventTrigger(short cardNum, short crd, ref TBufFollowEventTrigger pEventTrigger, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufFollowStart(short cardNum, short crd, int masterSegment, int slaveSegment, int masterFrameWidth, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufFollowReturn(short cardNum, short crd, double vel, double acc, short smoothPercent, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufFollowNext(short cardNum, short crd, int width, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdFollowStatus(short cardNum, short crd, out TCrdFollowStatus pStatus);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdFollowLoop(short cardNum, short crd, uint loop);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdFollowLoop(short cardNum, short crd, out uint pLoop);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdFollowPrm(short cardNum, short crd, ref TCrdFollowPrm pPrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdFollowPrm(short cardNum, short crd, out TCrdFollowPrm pPrm);
		[DllImport("gts.dll")]
		public static extern short GT_Compile(short cardNum, string pFileName, out TCompileInfo pWrongInfo);
		[DllImport("gts.dll")]
		public static extern short GT_Download(short cardNum, string pFileName);

		[DllImport("gts.dll")]
		public static extern short GT_GetFunId(short cardNum, string pFunName, out short pFunId);
		[DllImport("gts.dll")]
		public static extern short GT_Bind(short cardNum, short thread, short funId, short page);

		[DllImport("gts.dll")]
		public static extern short GT_RunThread(short cardNum, short thread);
		[DllImport("gts.dll")]
		public static extern short GT_StopThread(short cardNum, short thread);
		[DllImport("gts.dll")]
		public static extern short GT_PauseThread(short cardNum, short thread);

		[DllImport("gts.dll")]
		public static extern short GT_GetThreadSts(short cardNum, short thread, out TThreadSts pThreadSts);

		[DllImport("gts.dll")]
		public static extern short GT_GetVarId(short cardNum, string pFunName, string pVarName, out TVarInfo pVarInfo);
		[DllImport("gts.dll")]
		public static extern short GT_SetVarValue(short cardNum, short page, ref TVarInfo pVarInfo, ref double pValue, short count);
		[DllImport("gts.dll")]
		public static extern short GT_GetVarValue(short cardNum, short page, ref TVarInfo pVarInfo, out double pValue, short count);

		[DllImport("gts.dll")]
		public static extern short GT_SetCrdMapBase(short cardNum, short crd, short mapBase);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdMapBase(short cardNum, short crd, out short pMapBase);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdSmooth(short cardNum, short crd, ref TCrdSmooth pCrdSmooth);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdSmooth(short cardNum, short crd, out TCrdSmooth pCrdSmooth);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdJerk(short cardNum, short crd, double jerkMax);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdJerk(short cardNum, short crd, out double pJerkMax);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdPrm(short cardNum, short crd, ref TCrdPrm pCrdPrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdPrm(short cardNum, short crd, out TCrdPrm pCrdPrm);
		[DllImport("gts.dll")]
		public static extern short GT_SetArcAllowError(short cardNum, short crd, double error);
		[DllImport("gts.dll")]
		public static extern short GT_CrdSpace(short cardNum, short crd, out int pSpace, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_CrdData(short cardNum, short crd, System.IntPtr pCrdData, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_CrdDataCircle(short cardNum, short crd, ref TCrdData pCrdData, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXY(short cardNum, short crd, int x, int y, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZ(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZA(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYG0(short cardNum, short crd, int x, int y, double synVel, double synAcc, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZG0(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAG0(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYR(short cardNum, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYC(short cardNum, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZR(short cardNum, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZC(short cardNum, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXR(short cardNum, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXC(short cardNum, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYZ(short cardNum, short crd, int x, int y, int z, double interX, double interY, double interZ, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYOverride2(short cardNum, short crd, int x, int y, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZOverride2(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAOverride2(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYG0Override2(short cardNum, short crd, int x, int y, double synVel, double synAcc, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZG0Override2(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAG0Override2(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYROverride2(short cardNum, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYCOverride2(short cardNum, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZROverride2(short cardNum, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZCOverride2(short cardNum, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXROverride2(short cardNum, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXCOverride2(short cardNum, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYRZ(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYCZ(short cardNum, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZRX(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZCX(short cardNum, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXRY(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXCY(short cardNum, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYRZOverride2(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYCZOverride2(short cardNum, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZRXOverride2(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZCXOverride2(short cardNum, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXRYOverride2(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXCYOverride2(short cardNum, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYWN(short cardNum, short crd, int x, int y, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZWN(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAWN(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYG0WN(short cardNum, short crd, int x, int y, double synVel, double synAcc, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZG0WN(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAG0WN(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYRWN(short cardNum, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYCWN(short cardNum, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZRWN(short cardNum, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZCWN(short cardNum, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXRWN(short cardNum, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXCWN(short cardNum, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYZWN(short cardNum, short crd, int x, int y, int z, double interX, double interY, double interZ, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYOverride2WN(short cardNum, short crd, int x, int y, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZOverride2WN(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAOverride2WN(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYG0Override2WN(short cardNum, short crd, int x, int y, double synVel, double synAcc, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZG0Override2WN(short cardNum, short crd, int x, int y, int z, double synVel, double synAcc, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_LnXYZAG0Override2WN(short cardNum, short crd, int x, int y, int z, int a, double synVel, double synAcc, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYROverride2WN(short cardNum, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcXYCOverride2WN(short cardNum, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZROverride2WN(short cardNum, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcYZCOverride2WN(short cardNum, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXROverride2WN(short cardNum, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_ArcZXCOverride2WN(short cardNum, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYRZWN(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYCZWN(short cardNum, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZRXWN(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZCXWN(short cardNum, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXRYWN(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXCYWN(short cardNum, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYRZOverride2WN(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixXYCZOverride2WN(short cardNum, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZRXOverride2WN(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixYZCXOverride2WN(short cardNum, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXRYOverride2WN(short cardNum, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_HelixZXCYOverride2WN(short cardNum, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufTrend(short cardNum, short crd, uint trendSegNum, double trendDistance, double trendVelEnd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufIO(short cardNum, short crd, ushort doType, ushort doMask, ushort doValue, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufEnableDoBitPulse(short cardNum, short crd, short doType, short doIndex, ushort highLevelTime, ushort lowLevelTime, int pulseNum, short firstLevel, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufDisableDoBitPulse(short cardNum, short crd, short doType, short doIndex, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufDelay(short cardNum, short crd, ushort delayTime, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufComparePulse(short cardNum, short crd, short level, short outputType, short time, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufDA(short cardNum, short crd, short chn, short daValue, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufLmtsOn(short cardNum, short crd, short axis, short limitType, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufLmtsOff(short cardNum, short crd, short axis, short limitType, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufSetStopIo(short cardNum, short crd, short axis, short stopType, short inputType, short inputIndex, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufMove(short cardNum, short crd, short moveAxis, int pos, double vel, double acc, short modal, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufGear(short cardNum, short crd, short gearAxis, int pos, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufGearPercent(short cardNum, short crd, short gearAxis, int pos, short accPercent, short decPercent, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufStopMotion(short cardNum, short crd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufSetVarValue(short cardNum, short crd, short pageId, out TVarInfo pVarInfo, double value, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufJumpNextSeg(short cardNum, short crd, short axis, short limitType, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufSynchPrfPos(short cardNum, short crd, short encoder, short profile, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufVirtualToActual(short cardNum, short crd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufSetLongVar(short cardNum, short crd, short index, int value, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufSetDoubleVar(short cardNum, short crd, short index, double value, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_CrdStart(short cardNum, short mask, short option);
		[DllImport("gts.dll")]
		public static extern short GT_CrdStartStep(short cardNum, short mask, short option);
		[DllImport("gts.dll")]
		public static extern short GT_CrdStepMode(short cardNum, short mask, short option);
		[DllImport("gts.dll")]
		public static extern short GT_SetOverride(short cardNum, short crd, double synVelRatio);
		[DllImport("gts.dll")]
		public static extern short GT_SetOverride2(short cardNum, short crd, double synVelRatio);
		[DllImport("gts.dll")]
		public static extern short GT_InitLookAhead(short cardNum, short crd, short fifo, double T, double accMax, short n, ref TCrdData pLookAheadBuf);
		[DllImport("gts.dll")]
		public static extern short GT_GetLookAheadSpace(short cardNum, short crd, out int pSpace, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetLookAheadSegCount(short cardNum, short crd, out int pSegCount, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_CrdClear(short cardNum, short crd, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_CrdStatus(short cardNum, short crd, out short pRun, out int pSegment, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_SetUserSegNum(short cardNum, short crd, int segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetUserSegNum(short cardNum, short crd, out int pSegment, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetUserSegNumWN(short cardNum, short crd, out int pSegment, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetRemainderSegNum(short cardNum, short crd, out int pSegment, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdStopDec(short cardNum, short crd, double decSmoothStop, double decAbruptStop);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdStopDec(short cardNum, short crd, out double pDecSmoothStop, out double pDecAbruptStop);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdLmtStopMode(short cardNum, short crd, short lmtStopMode);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdLmtStopMode(short cardNum, short crd, out short pLmtStopMode);
		[DllImport("gts.dll")]
		public static extern short GT_GetUserTargetVel(short cardNum, short crd, out double pTargetVel);
		[DllImport("gts.dll")]
		public static extern short GT_GetSegTargetPos(short cardNum, short crd, out int pTargetPos);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdPos(short cardNum, short crd, out double pPos);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdVel(short cardNum, short crd, out double pSynVel);
		[DllImport("gts.dll")]
		public static extern short GT_SetCrdSingleMaxVel(short cardNum, short crd, ref double pMaxVel);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdSingleMaxVel(short cardNum, short crd, out double pMaxVel);
		[DllImport("gts.dll")]
		public static extern short GT_GetCmdCount(short cardNum, short crd, out short pResult, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserOn(short cardNum, short crd, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserOff(short cardNum, short crd, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserPrfCmd(short cardNum, short crd, double laserPower, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowRatio(short cardNum, short crd, double ratio, double minPower, double maxPower, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowMode(short cardNum, short crd, short source, short fifo, short channel, double startPower);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowOff(short cardNum, short crd, short fifo, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_BufLaserFollowSpline(short cardNum, short crd, short tableId, double minPower, double maxPower, short fifo, short channel);

		[DllImport("gts.dll")]
		public static extern short GT_PrfPvt(short cardNum, short profile);
		[DllImport("gts.dll")]
		public static extern short GT_SetPvtLoop(short cardNum, short profile, int loop);
		[DllImport("gts.dll")]
		public static extern short GT_GetPvtLoop(short cardNum, short profile, out int pLoopCount, out int pLoop);
		[DllImport("gts.dll")]
		public static extern short GT_PvtStatus(short cardNum, short profile, out short pTableId, out double pTime, short count);
		[DllImport("gts.dll")]
		public static extern short GT_PvtStart(short cardNum, int mask);
		[DllImport("gts.dll")]
		public static extern short GT_PvtTableSelect(short cardNum, short profile, short tableId);

		[DllImport("gts.dll")]
		public static extern short GT_PvtTable(short cardNum, short tableId, int count, ref double pTime, ref double pPos, ref double pVel);
		[DllImport("gts.dll")]
		public static extern short GT_PvtTableEx(short cardNum, short tableId, int count, ref double pTime, ref double pPos, ref double pVelBegin, ref double pVelEnd);
		[DllImport("gts.dll")]
		public static extern short GT_PvtTableComplete(short cardNum, short tableId, int count, ref double pTime, ref double pPos, ref double pA, ref double pB, ref double pC, double velBegin, double velEnd);
		[DllImport("gts.dll")]
		public static extern short GT_PvtTablePercent(short cardNum, short tableId, int count, ref double pTime, ref double pPos, ref double pPercent, double velBegin);
		[DllImport("gts.dll")]
		public static extern short GT_PvtPercentCalculate(short cardNum, int n, ref double pTime, ref double pPos, ref double pPercent, double velBegin, ref double pVel);
		[DllImport("gts.dll")]
		public static extern short GT_PvtTableContinuous(short cardNum, short tableId, int count, ref double pPos, ref double pVel, ref double pPercent, ref double pVelMax, ref double pAcc, ref double pDec, double timeBegin);
		[DllImport("gts.dll")]
		public static extern short GT_PvtContinuousCalculate(short cardNum, int n, ref double pPos, ref double pVel, ref double pPercent, ref double pVelMax, ref double pAcc, ref double pDec, ref double pTime);
		[DllImport("gts.dll")]
		public static extern short GT_PvtTableMovePercent(short cardNum, short tableId, int distance, double vm, double acc, double pa1, double pa2, double dec, double pd1, double pd2, out double pVel, out double pAcc, out double pDec, out double pTime);
		[DllImport("gts.dll")]
		public static extern short GT_PvtTableMovePercentEx(short cardNum, short tableId, int distance, double vm, double acc, double pa1, double pa2, double ma, double dec, double pd1, double pd2, double md, out double pVel, out double pAcc, out double pDec, out double pTime);

		[DllImport("gts.dll")]
		public static extern short GT_HomeInit(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_Home(short cardNum, short axis, int pos, double vel, double acc, int offset);
		[DllImport("gts.dll")]
		public static extern short GT_Index(short cardNum, short axis, int pos, int offset);
		[DllImport("gts.dll")]
		public static extern short GT_HomeStop(short cardNum, short axis, int pos, double vel, double acc);
		[DllImport("gts.dll")]
		public static extern short GT_HomeSts(short cardNum, short axis, out ushort pStatus);

		[DllImport("gts.dll")]
		public static extern short GT_HandwheelInit(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_SetHandwheelStopDec(short cardNum, short slave, double decSmoothStop, double decAbruptStop);
		[DllImport("gts.dll")]
		public static extern short GT_StartHandwheel(short cardNum, short slave, short master, short masterEven, short slaveEven, short intervalTime, double acc, double dec, double vel, short stopWaitTime);
		[DllImport("gts.dll")]
		public static extern short GT_EndHandwheel(short cardNum, short slave);

		[DllImport("gts.dll")]
		public static extern short GT_SetTrigger(short cardNum, short i, ref TTrigger pTrigger);
		[DllImport("gts.dll")]
		public static extern short GT_GetTrigger(short cardNum, short i, out TTrigger pTrigger);
		[DllImport("gts.dll")]
		public static extern short GT_GetTriggerStatus(short cardNum, short i, out TTriggerStatus pTriggerStatus, short count);
		[DllImport("gts.dll")]
		public static extern short GT_GetTriggerStatusEx(short cardNum, short i, out TTriggerStatusEx pTriggerStatusEx, short count);
		[DllImport("gts.dll")]
		public static extern short GT_ClearTriggerStatus(short cardNum, short i);

		[DllImport("gts.dll")]
		public static extern short GT_SetComparePort(short cardNum, short channel, short hsio0, short hsio1);

		[DllImport("gts.dll")]
		public static extern short GT_ComparePulse(short cardNum, short level, short outputType, short time);
		[DllImport("gts.dll")]
		public static extern short GT_CompareStop(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_CompareStatus(short cardNum, out short pStatus, out int pCount);
		[DllImport("gts.dll")]
		public static extern short GT_CompareData(short cardNum, short encoder, short source, short pulseType, short startLevel, short time, int[] pBuf1, short count1, int[] pBuf2, short count2);
		[DllImport("gts.dll")]
		public static extern short GT_CompareLinear(short cardNum, short encoder, short channel, int startPos, int repeatTimes, int interval, short time, short source);
		[DllImport("gts.dll")]
		public static extern short GT_CompareContinuePulseMode(short cardNum, short mode, short count, short standTime);

		[DllImport("gts.dll")]
		public static extern short GT_SetEncResponseCheck(short cardNum, short control, short dacThreshold, double minEncVel, int time);
		[DllImport("gts.dll")]
		public static extern short GT_GetEncResponseCheck(short cardNum, short control, out short pDacThreshold, out double pMinEncVel, out int pTime);
		[DllImport("gts.dll")]
		public static extern short GT_EnableEncResponseCheck(short cardNum, short control);
		[DllImport("gts.dll")]
		public static extern short GT_DisableEncResponseCheck(short cardNum, short control);

		[DllImport("gts.dll")]
		public static extern short GT_2DCompareMode(short cardNum, short chn, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_2DComparePulse(short cardNum, short chn, short level, short outputType, short time);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareStop(short cardNum, short chn);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareClear(short cardNum, short chn);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareStatus(short cardNum, short chn, out short pStatus, out int pCount, out short pFifo, out short pFifoCount, out short pBufCount);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareSetPrm(short cardNum, short chn, ref T2DComparePrm pPrm);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareData(short cardNum, short chn, short count, ref T2DCompareData pBuf, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareStart(short cardNum, short chn);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareClearData(short cardNum, short chn);
		[DllImport("gts.dll")]
		public static extern short GT_2DCompareSetPreOutTime(short cardNum, short chn, double preOutputTime);

		[DllImport("gts.dll")]
		public static extern short GT_SetAxisMode(short cardNum, short axis, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisMode(short cardNum, short axis, out short pMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetHSIOOpt(short cardNum, ushort value, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_GetHSIOOpt(short cardNum, out ushort pValue, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_LaserPowerMode(short cardNum, short laserPowerMode, double maxValue, double minValue, short channel, short delaymode);
		[DllImport("gts.dll")]
		public static extern short GT_LaserPrfCmd(short cardNum, double outputCmd, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_LaserOutFrq(short cardNum, double outFrq, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetPulseWidth(short cardNum, uint width, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetWaitPulse(short cardNum, ushort mode, double waitPulseFrq, double waitPulseDuty, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetPreVltg(short cardNum, ushort mode, double voltageValue, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetLevelDelay(short cardNum, ushort offDelay, ushort onDelay, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_EnaFPK(short cardNum, ushort time1, ushort time2, ushort laserOffDelay, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_DisFPK(short cardNum, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserDisMode(short cardNum, short mode, short source, ref int pPos, ref double pScale, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserDisRatio(short cardNum, ref double pRatio, double minPower, double maxPower, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetWaitPulseEx(short cardNum, ushort mode, double waitPulseFrq, double waitPulseDuty);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserMode(short cardNum, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserFollowSpline(short cardNum, short tableId, int n, ref double pX, ref double pY, double beginValue, double endValue, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_GetLaserFollowSpline(short cardNum, short tableId, int n, out double pX, out double pY, out double pA, out double pB, out double pC, out int pCount, short channel);

		//ExtMdl
		[DllImport("gts.dll")]
		public static extern short GT_OpenExtMdl(short cardNum, string pDllName);
		[DllImport("gts.dll")]
		public static extern short GT_CloseExtMdl(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_SwitchtoCardNoExtMdl(short cardNum, short card);
		[DllImport("gts.dll")]
		public static extern short GT_ResetExtMdl(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_LoadExtConfig(short cardNum, string pFileName);
		[DllImport("gts.dll")]
		public static extern short GT_SetExtIoValue(short cardNum, short mdl, ushort value);
		[DllImport("gts.dll")]
		public static extern short GT_GetExtIoValue(short cardNum, short mdl, out ushort pValue);
		[DllImport("gts.dll")]
		public static extern short GT_SetExtIoBit(short cardNum, short mdl, short index, ushort value);
		[DllImport("gts.dll")]
		public static extern short GT_GetExtIoBit(short cardNum, short mdl, short index, out ushort pValue);
		[DllImport("gts.dll")]
		public static extern short GT_GetExtAdValue(short cardNum, short mdl, short chn, out ushort pValue);
		[DllImport("gts.dll")]
		public static extern short GT_GetExtAdVoltage(short cardNum, short mdl, short chn, out double pValue);
		[DllImport("gts.dll")]
		public static extern short GT_SetExtDaValue(short cardNum, short mdl, short chn, ushort value);
		[DllImport("gts.dll")]
		public static extern short GT_SetExtDaVoltage(short cardNum, short mdl, short chn, double value);
		[DllImport("gts.dll")]
		public static extern short GT_GetStsExtMdl(short cardNum, short mdl, short chn, out ushort pStatus);
		[DllImport("gts.dll")]
		public static extern short GT_GetExtDoValue(short cardNum, short mdl, out ushort pValue);
		[DllImport("gts.dll")]
		public static extern short GT_GetExtMdlMode(short cardNum, out short pMode);
		[DllImport("gts.dll")]
		public static extern short GT_SetExtMdlMode(short cardNum, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_UploadConfig(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_DownloadConfig(short cardNum);

		[DllImport("gts.dll")]
		public static extern short GT_GetUuid(short cardNum, out char pCode, short count);
		[DllImport("gts.dll")]
		public static extern short GT_SetUuid(short cardNum, ref char pCode, short count);

		//2D Compensate
		public struct TCompensate2DTable
		{
			public short count1;
			public short count2;
			public int posBegin1;
			public int posBegin2;
			public int step1;
			public int step2;
		}
		public struct TCompensate2D
		{
			public short enable;
			public short tableIndex;
			public short axisType1;
			public short axisType2;
			public short axisIndex1;
			public short axisIndex2;
		}
		[DllImport("gts.dll")]
		public static extern short GT_SetCompensate2DTable(short cardNum, short tableIndex, ref TCompensate2DTable pTable, ref int pData, short externComp);
		[DllImport("gts.dll")]
		public static extern short GT_GetCompensate2DTable(short cardNum, short tableIndex, out TCompensate2DTable pTable, out short pExternComp);
		[DllImport("gts.dll")]
		public static extern short GT_SetCompensate2D(short cardNum, short axis, ref TCompensate2D pComp2d);
		[DllImport("gts.dll")]
		public static extern short GT_GetCompensate2D(short cardNum, short axis, out TCompensate2D pComp2d);
		[DllImport("gts.dll")]
		public static extern short GT_GetCompensate2DValue(short cardNum, short axis, out double pValue);

		//Smart Home
		public const short HOME_STAGE_IDLE = 0;
		public const short HOME_STAGE_START = 1;
		public const short HOME_STAGE_ON_HOME_LIMIT_ESCAPE = 2;
		public const short HOME_STAGE_SEARCH_LIMIT = 10;
		public const short HOME_STAGE_SEARCH_LIMIT_STOP = 11;
		public const short HOME_STAGE_SEARCH_LIMIT_ESCAPE = 13;
		public const short HOME_STAGE_SEARCH_LIMIT_RETURN = 15;
		public const short HOME_STAGE_SEARCH_LIMIT_RETURN_STOP = 16;
		public const short HOME_STAGE_SEARCH_HOME = 20;
		public const short HOME_STAGE_SEARCH_HOME_STOP = 22;
		public const short HOME_STAGE_SEARCH_HOME_RETURN = 25;
		public const short HOME_STAGE_SEARCH_INDEX = 30;
		public const short HOME_STAGE_SEARCH_GPI = 40;
		public const short HOME_STAGE_SEARCH_GPI_RETURN = 45;
		public const short HOME_STAGE_GO_HOME = 80;
		public const short HOME_STAGE_END = 100;
		public const short HOME_ERROR_NONE = 0;
		public const short HOME_ERROR_NOT_TRAP_MODE = 1;
		public const short HOME_ERROR_DISABLE = 2;
		public const short HOME_ERROR_ALARM = 3;
		public const short HOME_ERROR_STOP = 4;
		public const short HOME_ERROR_STAGE = 5;
		public const short HOME_ERROR_HOME_MODE = 6;
		public const short HOME_ERROR_SET_CAPTURE_HOME = 7;
		public const short HOME_ERROR_NO_HOME = 8;
		public const short HOME_ERROR_SET_CAPTURE_INDEX = 9;
		public const short HOME_ERROR_NO_INDEX = 10;
		public const short HOME_MODE_LIMIT = 10;
		public const short HOME_MODE_LIMIT_HOME = 11;
		public const short HOME_MODE_LIMIT_INDEX = 12;
		public const short HOME_MODE_LIMIT_HOME_INDEX = 13;
		public const short HOME_MODE_HOME = 20;
		public const short HOME_MODE_HOME_INDEX = 22;
		public const short HOME_MODE_INDEX = 30;
		public const short HOME_MODE_FORCED_HOME = 40;
		public const short HOME_MODE_FORCED_HOME_INDEX = 41;

		public struct THomePrm
		{
			public short mode;
			public short moveDir;
			public short indexDir;
			public short edge;
			public short triggerIndex;
			public short pad1_1;
			public short pad1_2;
			public short pad1_3;
			public double velHigh;
			public double velLow;
			public double acc;
			public double dec;
			public short smoothTime;
			public short pad2_1;
			public short pad2_2;
			public short pad2_3;
			public int homeOffset;
			public int searchHomeDistance;
			public int searchIndexDistance;
			public int escapeStep;
			public int pad3_1;
			public int pad3_2;
			public int pad3_3;
		}
		public struct THomeStatus
		{
			public short run;
			public short stage;
			public short error;
			public short pad1;
			public int capturePos;
			public int targetPos;
		}
		[DllImport("gts.dll")]
		public static extern short GT_GoHome(short cardNum, short axis, ref THomePrm pHomePrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetHomePrm(short cardNum, short axis, out THomePrm pHomePrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetHomeStatus(short cardNum, short axis, out THomeStatus pHomeStatus);

		//Extern Control
		public struct TControlConfigEx
		{
			public short refType;
			public short refIndex;
			public short feedbackType;
			public short feedbackIndex;
			public int errorLimit;
			public short feedbackSmooth;
			public short controlSmooth;
		}
		[DllImport("gts.dll")]
		public static extern short GT_SetControlConfigEx(short cardNum, short control, ref TControlConfigEx pControl);
		[DllImport("gts.dll")]
		public static extern short GT_GetControlConfigEx(short cardNum, short control, out TControlConfigEx pControl);

		//Adc filter
		public struct TAdcConfig
		{
			public short active;
			public short reverse;
			public double a;
			public double b;
			public short filterMode;
		}
		[DllImport("gts.dll")]
		public static extern short GT_SetAdcConfig(short cardNum, short adc, ref TAdcConfig pAdc);
		[DllImport("gts.dll")]
		public static extern short GT_GetAdcConfig(short cardNum, short adc, out TAdcConfig pAdc);
		[DllImport("gts.dll")]
		public static extern short GT_SetAdcFilterPrm(short cardNum, short adc, double k);
		[DllImport("gts.dll")]
		public static extern short GT_GetAdcFilterPrm(short cardNum, short adc, out double pk);

		//Superimposed
		[DllImport("gts.dll")]
		public static extern short GT_SetControlSuperimposed(short cardNum, short control, short superimposedType, short superimposedIndex);
		[DllImport("gts.dll")]
		public static extern short GT_GetControlSuperimposed(short cardNum, short control, out short pSuperimposedType, out short pSuperimposedIndex);

		////////////////////
		[DllImport("gts.dll")]
		public static extern short GT_ZeroLaserOnTime(short cardNum, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_GetLaserOnTime(short cardNum, short channel, out uint pTime);

		[DllImport("gts.dll")]
		public static extern short GT_SetProfileScale(short cardNum, short axis, int alpha, int beta);
		[DllImport("gts.dll")]
		public static extern short GT_GetProfileScale(short cardNum, short axis, out int pAlpha, out int pBeta);
		[DllImport("gts.dll")]
		public static extern short GT_SetEncoderScale(short cardNum, short encoder, int alpha, int beta);
		[DllImport("gts.dll")]
		public static extern short GT_GetEncoderScale(short cardNum, short encoder, out int pAlpha, out int pBeta);
		[DllImport("gts.dll")]
		public static extern short GT_MultiAxisOn(short cardNum, uint mask);
		[DllImport("gts.dll")]
		public static extern short GT_MultiAxisOff(short cardNum, uint mask);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisOnDelayTime(short cardNum, ushort ms);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisOnDelayTime(short cardNum, out ushort pMs);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserDisTable1D(short cardNum, short count, ref double pRatio, ref int pPos, double minPower, double maxPower, ref double pLimitPower, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserDisTable2D(short cardNum, short[] axisIndex, short[] count, ref double pRatio, ref int pXPos, ref int pYPos,
																													 double minPower, double maxPower, ref double pLimitPower, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserDisTable2DEx(short cardNum, short[] axisIndex, short[] count, ref double pRatio, int[] posBegin, int[] posStep,
																													   double minPower, double maxPower, ref double pLimitPower, short channel);
		[DllImport("gts.dll")]
		public static extern short GT_SetLaserCrdMap(short cardNum, short channel, short map);
		[DllImport("gts.dll")]
		public static extern short GT_GetLaserCrdMap(short cardNum, short channel, ref short pMap);

		//////////////////////////////////////////////////////////////////////////
		//AutoFocus
		//////////////////////////////////////////////////////////////////////////
		[DllImport("gts.dll")]
		public static extern short GT_AutoFocus(short cardNum, ushort mode, double kp, short reverse, short chanel);
		[DllImport("gts.dll")]
		public static extern short GT_SetAutoFocusRefVol(short cardNum, double refVol, double maxVol, double minVol, short chanel);
		[DllImport("gts.dll")]
		public static extern short GT_GetAutoFocusStatus(short cardNum, out ushort pStatus, short count);
		[DllImport("gts.dll")]
		public static extern short GT_ConfigAutoFocus(short cardNum, short chnAdc, short chanel);
		[DllImport("gts.dll")]
		public static extern short GT_SetAutoFocusAuxPrm(short cardNum, double kf, double kd, double limitKd, short chanel);


		[DllImport("gts.dll")]
		public static extern short GT_Delay(short cardNum, ushort time);
		[DllImport("gts.dll")]
		public static extern short GT_DelayHighPrecision(short cardNum, ushort time);

		[DllImport("gts.dll")]
		public static extern short GT_SetCrdBufferMode(short cardNum, short crd, short bufferMode, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdBufferMode(short cardNum, short crd, out short pBufferMode, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdSegmentTime(short cardNum, short crd, int segmentIndex, out double pSegmentTime, out int pSegmentNumber, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_GetCrdTime(short cardNum, short crd, out TCrdTime pTime, short fifo);

		[DllImport("gts.dll")]
		public static extern short GT_SetLeadScrewLink(short cardNum, short axis, short link);
		[DllImport("gts.dll")]
		public static extern short GT_GetLeadScrewLink(short cardNum, short axis, out short pLink);
		public const short GANTRY_MODE_NONE = -1;
		public const short GANTRY_MODE_OPEN_LOOP_GANTRY = 1;
		public const short GANTRY_MODE_DECOUPLE_POSITION_LOOP = 2;
		[DllImport("gts.dll")]
		public static extern short GT_SetGantryMode(short cardNum, short group, short master, short slave, short mode, int syncErrorLimit);
		[DllImport("gts.dll")]
		public static extern short GT_GetGantryMode(short cardNum, short group, out short pMaster, out short pSlave, out short pMode, out int pSyncErrorLimit);
		[DllImport("gts.dll")]
		public static extern short GT_SetGantryPid(short cardNum, short group, ref TPid pGantryPid, ref TPid pYawPid);
		[DllImport("gts.dll")]
		public static extern short GT_GetGantryPid(short cardNum, short group, out TPid pGantryPid, out TPid pYawPid);
		[DllImport("gts.dll")]
		public static extern short GT_GantryAxisOn(short cardNum, short group);
		[DllImport("gts.dll")]
		public static extern short GT_GantryAxisOff(short cardNum, short group);
		[DllImport("gts.dll")]
		public static extern short GT_GantryHoming(short cardNum);

		//////////////////////////////////////////////////////////////////////////
		//Standard Home
		//////////////////////////////////////////////////////////////////////////

		public const short STANDARD_HOME_STAGE_IDLE = 0;
		public const short STANDARD_HOME_STAGE_START = 1;
		public const short STANDARD_HOME_STAGE_SEARCH_HOME = 20;
		public const short STANDARD_HOME_STAGE_SEARCH_INDEX = 30;
		public const short STANDARD_HOME_STAGE_GO_HOME = 80;
		public const short STANDARD_HOME_STAGE_END = 100;
		public const short STANDARD_HOME_STAGE_START_CHECK = -1;
		public const short STANDARD_HOME_STAGE_CHECKING = -2;


		public const short STANDARD_HOME_ERROR_NONE = 0;
		public const short STANDARD_HOME_ERROR_DISABLE = 10;
		public const short STANDARD_HOME_ERROR_ALARM = 20;
		public const short STANDARD_HOME_ERROR_STOP = 30;
		public const short STANDARD_HOME_ERROR_ON_LIMIT = 40;
		public const short STANDARD_HOME_ERROR_NO_HOME = 50;
		public const short STANDARD_HOME_ERROR_NO_INDEX = 60;
		public const short STANDARD_HOME_ERROR_NO_LIMIT = 70;
		public const short STANDARD_HOME_ERROR_ENCODER_DIR_SCALE = -1;


		public struct TStandardHomePrm
		{
			public short mode;       // 回原点模式取值范围1~36
			public double highSpeed; // 搜索Home的速度，单位pulse/ms
			public double lowSpeed;  // 搜索Index的速度，单位pulse/ms
			public double acc;       // 回零加速度，单位pulse/ms^2
			public int offset;       // 回零偏移量，单位pulse
			public short check; // 是否启用自检功能，1-启用，其它值-不启用
			public short autoZeroPos; // 回零完毕是否自动清零，1-自动清零，其它值-不清零
			public int motorStopDelay; //电机到位延时，单位：控制周期
			public short pad1;   // 保留（不需要设置）
			public short pad2;
			public short pad3;
		};

		public struct TStandardHomeStatus
		{
			public short run;     // 是正在进行回原点，0—已停止运动，1-正在回原点
			public short stage;   // 回原点运动的阶段
			public short error;    // 回原点过程的发生的错误
			public short pad1;       // 保留（无具体含义）
			public short pad2;
			public short pad3;
			public int capturePos;  // 捕获到Home或Index时刻的编码器位置
			public int targetPos;    // 需要运动到的目标位置（原点位置或者原点位置+偏移量），在搜索Limit时或者搜索Home或Index时，设置的搜索距离为0，那么该值显示为805306368
		};

		[DllImport("gts.dll")]
		public static extern short GT_ExecuteStandardHome(short cardNum, short axis, ref TStandardHomePrm pHomePrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetStandardHomePrm(short cardNum, short axis, out TStandardHomePrm pHomePrm);
		[DllImport("gts.dll")]
		public static extern short GT_GetStandardHomeStatus(short cardNum, short axis, out TStandardHomeStatus pHomeStatus);

		//DMA
		[DllImport("gts.dll")]
		public static extern short GT_CrdHsOn(short cardNum, short crd, short fifo, short link, ushort threshold, short lookAheadInMc);
		[DllImport("gts.dll")]
		public static extern short GT_CrdHsOff(short cardNum, short crd, short fifo);

		[DllImport("gts.dll")]
		public static extern short GT_SetFlagVar(short cardNum, short index, short mode, short value);
		[DllImport("gts.dll")]
		public static extern short GT_GetFlagVar(short cardNum, short index, out short pMode, out short pValue);

		//////////////////////////////////////////////////////////////////////////
		//椭圆插补
		//////////////////////////////////////////////////////////////////////////

		public const short ELLIPSE_AUX_POINT_COUNT = 5;

		public const short ELLIPSE_MODE_AUX_POINT_2D = 0;
		public const short ELLIPSE_MODE_STANDARD_2D = 1;
		//-------------------------------------------------------
		//功能说明：椭圆插补描述参数,模式：ELLIPSE_MODE_AUX_POINT_2D
		//plane-------------椭圆平面选择，INTERPOLATION_CIRCLE_PLAT_XY(0)：XY；INTERPOLATION_CIRCLE_PLAT_YZ(1)：YZ；INTERPOLATION_CIRCLE_PLAT_ZX(2)：ZX
		//dir---------------椭圆方向，0：顺时针；1：逆时针
		//overrideSelect----速度倍率选择，0：第1组倍率；1：第2组倍率
		//pad---------------占位变量，不需要传入
		//endPoint1----------终点坐标1,意义根据plane来定，如果palne为XY平面，则endPoint1、pos1为X坐标，endPoint2、pos2为Y坐标
		//endPoint2----------终点坐标2
		//pos1--------------椭圆上辅助点坐标1
		//pos2--------------椭圆上辅助点坐标2
		//-------------------------------------------------------
		public struct TEllipseAuxPoint2D
		{
			public short plane;
			public short dir;
			public short overrideSelect;
			public short pad;

			public double endPoint1;
			public double endPoint2;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = ELLIPSE_AUX_POINT_COUNT)]
			public double[] pos1;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = ELLIPSE_AUX_POINT_COUNT)]
			public double[] pos2;
		};

		//-------------------------------------------------------
		//功能说明：椭圆插补描述参数,模式：ELLIPSE_MODE_STANDARD_2D
		//plane--------------椭圆平面选择，INTERPOLATION_CIRCLE_PLAT_XY(0)：XY；INTERPOLATION_CIRCLE_PLAT_YZ(1)：YZ；INTERPOLATION_CIRCLE_PLAT_ZX(2)：ZX
		//dir----------------椭圆方向，0：顺时针；1：逆时针
		//overrideSelect-----速度倍率选择，0：第1组倍率；1：第2组倍率
		//pad----------------占位变量，不需要传入
		//endPoint1----------终点坐标1,意义根据plane来定，如果palne为XY平面，则endPoint1为X坐标，endPoint2为Y坐标
		//endPoint2----------终点坐标2
		//centerPoint1-------椭圆圆心坐标1，意义根据plane来定，如果palne为XY平面，则centerPoint1为X坐标，centerPoint2为Y坐标
		//centerPoint2-------椭圆圆心坐标2
		//theta--------------椭圆旋转角度，单位：度
		//a------------------椭圆长轴
		//b------------------椭圆短轴，短轴必须比长轴短
		//-------------------------------------------------------
		public struct TEllipseStandard2D
		{
			public short plane;
			public short dir;
			public short overrideSelect;
			public short pad;

			public double endPoint1;
			public double endPoint2;

			public double centerPoint1;
			public double centerPoint2;

			public double theta;
			public double a;
			public double b;
		};

		//-------------------------------------------------------
		//功能说明：椭圆插补
		//input：crd-------坐标系号
		//input：mode------椭圆描述模式，椭圆模式
		//input：pData-----椭圆描述的参数，mode = ELLIPSE_MODE_AUX_POINT_2D，传入TEllipseAuxPoint2D,mode = ELLIPSE_MODE_STANDARD_2D，传入TEllipseStandard2D
		//input：synVel----椭圆插补合成速度
		//input：synAcc----椭圆插补合成加速度
		//input：velEnd----椭圆插补终点速度
		//input：segNum----椭圆插补段号
		//input：fifo------椭圆插补缓冲区号
		//-------------------------------------------------------
		[DllImport("gts.dll")]
		public static extern short GT_EllipsePro(short cardNum, short crd, short mode, System.IntPtr pData, double synVel, double synAcc, double velEnd, long segNum, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_EllipseProEx(short cardNum, short crd, short mode, System.IntPtr pData, double synVel, double synAcc, double velEnd, long segNum, short fifo);
	}
	public class mc_cfg
	{

		public const short RES_LIMIT = 8;
		public const short RES_ALARM = 8;
		public const short RES_HOME = 8;
		public const short RES_GPI = 16;
		public const short RES_ARRIVE = 8;
		public const short RES_MPG = 7;

		public const short RES_ENABLE = 8;
		public const short RES_CLEAR = 8;
		public const short RES_GPO = 16;

		public const short RES_DAC = 12;
		public const short RES_STEP = 8;
		public const short RES_PULSE = 8;
		public const short RES_ENCODER = 11;
		public const short RES_LASER = 2;

		public const short AXIS_MAX = 8;
		public const short PROFILE_MAX = 8;
		public const short CONTROL_MAX = 8;

		public const short PRF_MAP_MAX = 2;
		public const short ENC_MAP_MAX = 2;

		public const short STEP_DIR = 0;
		public const short STEP_PULSE = 1;

		public const short CRD_BUF_DATA_NULL = 0;

		public struct TDiConfig
		{
			public short active;
			public short reverse;
			public short filterTime;
		}

		public struct TCountConfig
		{
			public short active;
			public short reverse;
			public short filterType;

			public short captureSource;
			public short captureHomeSense;
			public short captureIndexSense;
		}

		public struct TDoConfig
		{
			public short active;
			public short axis;
			public short axisItem;
			public short reverse;
		}

		public struct TStepConfig
		{
			public short active;
			public short axis;
			public short mode;
			public short parameter;
			public short reverse;
		}

		public struct TDacConfig
		{
			public short active;
			public short control;
			public short reverse;
			public short bias;
			public short limit;
		}

		public struct TControlConfig
		{
			public short active;
			public short axis;
			public short encoder1;
			public short encoder2;
			public long errorLimit;
			public short filterType1;
			public short filterType2;
			public short filterType3;
			public short encoderSmooth;
			public short controlSmooth;
		}

		public struct TProfileConfig
		{
			public short active;
			public double decSmoothStop;
			public double decAbruptStop;
		}

		public struct TAxisConfig
		{
			public short active;
			public short alarmType;
			public short alarmIndex;
			public short limitPositiveType;
			public short limitPositiveIndex;
			public short limitNegativeType;
			public short limitNegativeIndex;
			public short smoothStopType;
			public short smoothStopIndex;
			public short abruptStopType;
			public short abruptStopIndex;
			public int prfMap;
			public int encMap;
			public short prfMapAlpha1;
			public short prfMapAlpha2;
			public short prfMapBeta1;
			public short prfMapBeta2;
			public short encMapAlpha1;
			public short encMapAlpha2;
			public short encMapBeta1;
			public short encMapBeta2;
		}

		public struct TMcConfig
		{
			public TProfileConfig profile1;
			public TProfileConfig profile2;
			public TProfileConfig profile3;
			public TProfileConfig profile4;
			public TProfileConfig profile5;
			public TProfileConfig profile6;
			public TProfileConfig profile7;
			public TProfileConfig profile8;
			public TAxisConfig axis1;
			public TAxisConfig axis2;
			public TAxisConfig axis3;
			public TAxisConfig axis4;
			public TAxisConfig axis5;
			public TAxisConfig axis6;
			public TAxisConfig axis7;
			public TAxisConfig axis8;
			public TControlConfig control1;
			public TControlConfig control2;
			public TControlConfig control3;
			public TControlConfig control4;
			public TControlConfig control5;
			public TControlConfig control6;
			public TControlConfig control7;
			public TControlConfig control8;
			public TDacConfig dac1;
			public TDacConfig dac2;
			public TDacConfig dac3;
			public TDacConfig dac4;
			public TDacConfig dac5;
			public TDacConfig dac6;
			public TDacConfig dac7;
			public TDacConfig dac8;
			public TDacConfig dac9;
			public TDacConfig dac10;
			public TDacConfig dac11;
			public TDacConfig dac12;
			public TStepConfig step1;
			public TStepConfig step2;
			public TStepConfig step3;
			public TStepConfig step4;
			public TStepConfig step5;
			public TStepConfig step6;
			public TStepConfig step7;
			public TStepConfig step8;
			public TCountConfig encoder1;
			public TCountConfig encoder2;
			public TCountConfig encoder3;
			public TCountConfig encoder4;
			public TCountConfig encoder5;
			public TCountConfig encoder6;
			public TCountConfig encoder7;
			public TCountConfig encoder8;
			public TCountConfig encoder9;
			public TCountConfig encoder10;
			public TCountConfig encoder11;
			public TCountConfig pulse1;
			public TCountConfig pulse2;
			public TCountConfig pulse3;
			public TCountConfig pulse4;
			public TCountConfig pulse5;
			public TCountConfig pulse6;
			public TCountConfig pulse7;
			public TCountConfig pulse8;
			public TDoConfig enable1;
			public TDoConfig enable2;
			public TDoConfig enable3;
			public TDoConfig enable4;
			public TDoConfig enable5;
			public TDoConfig enable6;
			public TDoConfig enable7;
			public TDoConfig enable8;
			public TDoConfig clear1;
			public TDoConfig clear2;
			public TDoConfig clear3;
			public TDoConfig clear4;
			public TDoConfig clear5;
			public TDoConfig clear6;
			public TDoConfig clear7;
			public TDoConfig clear8;
			public TDoConfig gpo1;
			public TDoConfig gpo2;
			public TDoConfig gpo3;
			public TDoConfig gpo4;
			public TDoConfig gpo5;
			public TDoConfig gpo6;
			public TDoConfig gpo7;
			public TDoConfig gpo8;
			public TDoConfig gpo9;
			public TDoConfig gpo10;
			public TDoConfig gpo11;
			public TDoConfig gpo12;
			public TDoConfig gpo13;
			public TDoConfig gpo14;
			public TDoConfig gpo15;
			public TDoConfig gpo16;
			public TDiConfig limitPositive1;
			public TDiConfig limitPositive2;
			public TDiConfig limitPositive3;
			public TDiConfig limitPositive4;
			public TDiConfig limitPositive5;
			public TDiConfig limitPositive6;
			public TDiConfig limitPositive7;
			public TDiConfig limitPositive8;
			public TDiConfig limitNegative1;
			public TDiConfig limitNegative2;
			public TDiConfig limitNegative3;
			public TDiConfig limitNegative4;
			public TDiConfig limitNegative5;
			public TDiConfig limitNegative6;
			public TDiConfig limitNegative7;
			public TDiConfig limitNegative8;
			public TDiConfig alarm1;
			public TDiConfig alarm2;
			public TDiConfig alarm3;
			public TDiConfig alarm4;
			public TDiConfig alarm5;
			public TDiConfig alarm6;
			public TDiConfig alarm7;
			public TDiConfig alarm8;
			public TDiConfig home1;
			public TDiConfig home2;
			public TDiConfig home3;
			public TDiConfig home4;
			public TDiConfig home5;
			public TDiConfig home6;
			public TDiConfig home7;
			public TDiConfig home8;
			public TDiConfig gpi1;
			public TDiConfig gpi2;
			public TDiConfig gpi3;
			public TDiConfig gpi4;
			public TDiConfig gpi5;
			public TDiConfig gpi6;
			public TDiConfig gpi7;
			public TDiConfig gpi8;
			public TDiConfig arrive1;
			public TDiConfig arrive2;
			public TDiConfig arrive3;
			public TDiConfig arrive4;
			public TDiConfig arrive5;
			public TDiConfig arrive6;
			public TDiConfig arrive7;
			public TDiConfig arrive8;
			public TDiConfig mpg1;
			public TDiConfig mpg2;
			public TDiConfig mpg3;
			public TDiConfig mpg4;
			public TDiConfig mpg5;
			public TDiConfig mpg6;
			public TDiConfig mpg7;
		}

		[DllImport("gts.dll")]
		public static extern short GT_SetDiConfig(short cardNum, short diType, short diIndex, ref TDiConfig pDi);
		[DllImport("gts.dll")]
		public static extern short GT_GetDiConfig(short cardNum, short diType, short diIndex, out TDiConfig pDi);
		[DllImport("gts.dll")]
		public static extern short GT_SetDoConfig(short cardNum, short doType, short doIndex, ref TDoConfig pDo);
		[DllImport("gts.dll")]
		public static extern short GT_GetDoConfig(short cardNum, short doType, short doIndex, out TDoConfig pDo);
		[DllImport("gts.dll")]
		public static extern short GT_SetStepConfig(short cardNum, short step, ref TStepConfig pStep);
		[DllImport("gts.dll")]
		public static extern short GT_GetStepConfig(short cardNum, short step, out TStepConfig pStep);
		[DllImport("gts.dll")]
		public static extern short GT_SetDacConfig(short cardNum, short dac, ref TDacConfig pDac);
		[DllImport("gts.dll")]
		public static extern short GT_GetDacConfig(short cardNum, short dac, out TDacConfig pDac);
		[DllImport("gts.dll")]
		public static extern short GT_SetCountConfig(short cardNum, short countType, short countIndex, ref TCountConfig pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetCountConfig(short cardNum, short countType, short countIndex, out TCountConfig pCount);
		[DllImport("gts.dll")]
		public static extern short GT_SetControlConfig(short cardNum, short control, ref TControlConfig pControl);
		[DllImport("gts.dll")]
		public static extern short GT_GetControlConfig(short cardNum, short control, out TControlConfig pControl);
		[DllImport("gts.dll")]
		public static extern short GT_SetProfileConfig(short cardNum, short profile, ref TProfileConfig pProfile);
		[DllImport("gts.dll")]
		public static extern short GT_GetProfileConfig(short cardNum, short profile, out TProfileConfig pProfile);
		[DllImport("gts.dll")]
		public static extern short GT_SetAxisConfig(short cardNum, short axis, ref TAxisConfig pAxis);
		[DllImport("gts.dll")]
		public static extern short GT_GetAxisConfig(short cardNum, short axis, out TAxisConfig pAxis);
		[DllImport("gts.dll")]
		public static extern short GT_GetConfigTable(short cardNum, short type, out short pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetConfigTableAll(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_SetMcConfig(short cardNum, ref TMcConfig pMc);
		[DllImport("gts.dll")]
		public static extern short GT_GetMcConfig(short cardNum, out TMcConfig pMc);
		[DllImport("gts.dll")]
		public static extern short GT_SetMcConfigToFile(short cardNum, ref TMcConfig pMc, ref char pFile);
		[DllImport("gts.dll")]
		public static extern short GT_GetMcConfigFromFile(short cardNum, out TMcConfig pMc, out char pFile);
		[DllImport("gts.dll")]
		public static extern short GT_SaveConfig(short cardNum, out char pFile);
		[DllImport("gts.dll")]
		public static extern short GT_GetInterruptTime(short cardNum, out double pServoRunTime, out double pProfileRunTime);
		[DllImport("gts.dll")]
		public static extern short GT_GetInterruptTimeMax(short cardNum, out double pServoRunTimeMax, out double pProfileRunTimeMax);

		//////////////////////////////////////////////////////////////////////////
		//New Watch
		//////////////////////////////////////////////////////////////////////////
		public const short WATCH_MODE_STATIC = 0;
		public const short WATCH_MODE_LOOP = 1;
		public const short WATCH_MODE_DYNAMIC = 2;

		public const short WATCH_MODE_STATIC_BACKGROUND = 10;
		public const short WATCH_MODE_LOOP_BACKGROUND = 11;
		public const short WATCH_MODE_DYNAMIC_BACKGROUND = 12;

		public const short WATCH_EVENT_RUN = 1;
		public const short WATCH_EVENT_START = 10;
		public const short WATCH_EVENT_STOP = 20;
		public const short WATCH_EVENT_OFF = 30;

		public const short WATCH_CONDITION_EQ = 1;
		public const short WATCH_CONDITION_NE = 2;
		public const short WATCH_CONDITION_GE = 3;
		public const short WATCH_CONDITION_LE = 4;

		public const short WATCH_CONDITION_CHANGE_TO = 11;
		public const short WATCH_CONDITION_CHANGE = 12;
		public const short WATCH_CONDITION_UP = 13;
		public const short WATCH_CONDITION_DOWN = 14;

		public const short WATCH_CONDITION_REMAIN_AT = 21;
		public const short WATCH_CONDITION_REMAIN = 22;

		public const long WATCH_VAR_CLOCK = 1200;
		public const long WATCH_VAR_PRF_LOOP = 1201;

		public const long WATCH_VAR_COMMAND_CODE = 1220;
		public const long WATCH_VAR_COMMAND_DATA = 1221;
		public const long WATCH_VAR_COMMAND_COUNT = 1222;
		public const long WATCH_VAR_COMMAND_READ_FLAG = 1223;

		public const long WATCH_VAR_PRF_POS = 6000;
		public const long WATCH_VAR_PRF_VEL = 6001;
		public const long WATCH_VAR_PRF_ACC = 6002;

		public const long WATCH_VAR_PRF_RUN = 6200;

		public const long WATCH_VAR_CRD_PRF_POS = 8000;
		public const long WATCH_VAR_CRD_PRF_VEL = 8001;
		public const long WATCH_VAR_CRD_PRF_ACC = 8002;

		public const long WATCH_VAR_CRD_RUN = 8200;

		public const long WATCH_VAR_CRD_SEGMENT_NUMBER = 8202;
		public const long WATCH_VAR_CRD_SEGMENT_NUMBER_USER = 8203;
		public const long WATCH_VAR_CRD_COMMAND_RECEIVE = 8204;
		public const long WATCH_VAR_CRD_COMMAND_EXECUTE = 8205;

		public const long WATCH_VAR_CRD_FOLLOW_SLAVE_POS = 8600;
		public const long WATCH_VAR_CRD_FOLLOW_SLAVE_VEL = 8601;

		public const long WATCH_VAR_CRD_FOLLOW_STAGE = 8610;

		public const long WATCH_VAR_SCAN_PRF_POS = 18000;
		public const long WATCH_VAR_SCAN_PRF_VEL = 18001;
		public const long WATCH_VAR_SCAN_PRF_ACC = 18002;

		public const long WATCH_VAR_SCAN_PRF_POS_X = 18010;
		public const long WATCH_VAR_SCAN_PRF_POS_Y = 18020;

		public const long WATCH_VAR_SCAN_RUN = 18200;

		public const long WATCH_VAR_SCAN_SEGMENT_NUMBER = 18202;


		public const long WATCH_VAR_LASER_HSIO = 18600;
		public const long WATCH_VAR_LASER_POWER = 18601;

		public const long WATCH_VAR_AXIS_PRF_POS = 20000;
		public const long WATCH_VAR_AXIS_PRF_VEL = 20001;
		public const long WATCH_VAR_AXIS_PRF_ACC = 20002;
		public const long WATCH_VAR_AXIS_ENC_POS = 20003;

		public const long WATCH_VAR_AXIS_PRF_VEL_FILTER = 20011;

		public const long WATCH_VAR_ENC_POS = 30000;

		public const long WATCH_VAR_ENC_VEL = 30001;

		public const long WATCH_VAR_GPI = 31000;

		public const long WATCH_VAR_GPO = 32000;

		public const long WATCH_VAR_AI = 33000;

		public const long WATCH_VAR_AO = 34000;

		public const long WATCH_VAR_AUTO_FOCUS_OUT = 34006;

		public const long WATCH_VAR_TRIGGER_EXECUTE = 38000;
		public const long WATCH_VAR_TRIGGER_STATUS = 38001;
		public const long WATCH_VAR_TRIGGER_POSITION = 38002;
		public const long WATCH_VAR_TRIGGER_COUNT = 38010;

		public const long WATCH_VAR_POS_LOOP_ERROR = 40000;

		public const long WATCH_VAR_CONTROL_REF_VEL = 41000;

		public const long WATCH_VAR_WATCH_TIME = 52001;

		public const long WATCH_VAR_INT32 = 52020;
		public const long WATCH_VAR_INT64 = 52021;
		public const long WATCH_VAR_FLOAT = 52022;
		public const long WATCH_VAR_DOUBLE = 52023;
		public const long WATCH_VAR_BOOL = 52024;


		public struct TWatchVar
		{
			public ushort type;
			public ushort index;
			public ushort id;
		}

		public struct TWatchEvent
		{
			public ushort type;
			public ushort loop;
			public ushort watchCount;
			public TWatchVar var;
			public ushort condition;
			public double value;
		}

		[DllImport("gts.dll")]
		public static extern short GT_ClearWatch(short cardNum, short mode);
		[DllImport("gts.dll")]
		public static extern short GT_AddWatchVar(short cardNum, ref TWatchVar pVar);
		[DllImport("gts.dll")]
		public static extern short GT_AddWatchEvent(short cardNum, ref TWatchEvent pEvent);
		[DllImport("gts.dll")]
		public static extern short GT_WatchOn(short cardNum, short interval, short mode, ushort count);
		[DllImport("gts.dll")]
		public static extern short GT_WatchOff(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_PrintWatch(short cardNum, string pFileName, int start, uint printCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetMcVar(short cardNum, out TWatchVar pVar, out double pValue);
		[DllImport("gts.dll")]
		public static extern short GT_SetWatchGroup(short cardNum, short group);
		[DllImport("gts.dll")]
		public static extern short GT_GetWatchGroup(short cardNum, out short pGroup);
		[DllImport("gts.dll")]
		public static extern short GT_LoadWatchConfig(short cardNum, ref char pFile);
		[DllImport("gts.dll")]
		public static extern short GT_SaveWatchConfig(short cardNum, short group, out char pFile);
		[DllImport("gts.dll")]
		public static extern short GT_ReadWatch(short cardNum, short varIndex, out double pBuffer, uint bufferSize, out uint pReadCount);

		public struct TWatchInfo
		{
			public short enable;                        // 采集使能
			public short run;                           // 采集状态
			public uint time;                   // 采集次数
			public uint head;                   // 头指针
			public uint threshold;          // 最多容纳采集次数

			public short interval;                      // 采集间隔
			public short mode;                          // 采集模式
			public ushort countBeforeEvent; // 事件触发之前的采集数量
			public ushort countAfterEvent;      // 事件触发以后的采集数量
			public ushort varCount;         // 采集变量数量
			public ushort eventCount;           // 采集事件数量
		}

		public struct TWatchVarInfo
		{
			public uint pAddress;
			public ushort length;
			public short fraction;
			public ushort format;
			public ushort hex;
			public ushort sign;
			public ushort bit;
		}

		public struct TWatchFormat
		{
			public short width;
			public short precision;
			public char seperator;
			public short hex;
		}

		[DllImport("gts.dll")]
		public static extern short GT_GetWatchInfo(short cardNum, out TWatchInfo pInfo);
		[DllImport("gts.dll")]
		public static extern short GT_GetWatchVar(short cardNum, short index, out TWatchVar pVar, out TWatchVarInfo pVarInfo);
		[DllImport("gts.dll")]
		public static extern short GT_GetWatchEvent(short cardNum, short index, out TWatchEvent pEvent);
		[DllImport("gts.dll")]
		public static extern short GT_SetWatchFormat(short cardNum, ref TWatchFormat pFormat);
		[DllImport("gts.dll")]
		public static extern short GT_GetWatchFormat(short cardNum, out TWatchFormat pFormat);

		//Event and Task
		public const long TASK_SET_DO_BIT = 0x1101;
		public const long TASK_CRD_START = 0x4004;
		public const long TASK_CRD_STOP = 0x4005;
		public const long TASK_CRD_OVERRIDE = 0x4006;

		public struct TTaskSetDoBit
		{
			public short doType;
			public short doIndex;
			public short doValue;
			public short mode;
			public long parameter1;
			public long parameter2;
			public long parameter3;
			public long parameter4;
			public long parameter5;
			public long parameter6;
			public long parameter7;
			public long parameter8;
		}

		public struct TTaskCrdStart
		{
			public short mask;
			public short option;
		}

		public struct TTaskCrdStop
		{
			public short mask;
			public short option;
		}

		public struct TTaskCrdOverride
		{
			public short crd;
			public double synVelOverride;
		}

		public struct TEvent
		{
			public long loop;
			public TWatchVar var;
			public ushort condition;
			public double value;
		}
		[DllImport("gts.dll")]
		public static extern short GT_ClearEvent(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_ClearTask(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_ClearEventTaskLink(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_AddEvent(short cardNum, ref TEvent pEvent, ref short pEventIndex);
		[DllImport("gts.dll")]
		public static extern short GT_AddTask(short cardNum, short taskType, System.IntPtr pTaskData, ref short pTaskIndex);
		[DllImport("gts.dll")]
		public static extern short GT_AddEventTaskLink(short cardNum, short eventIndex, short taskIndex, ref short pLinkIndex);
		[DllImport("gts.dll")]
		public static extern short GT_GetEventCount(short cardNum, out short pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetEvent(short cardNum, short eventIndex, out TEvent pEvent);
		[DllImport("gts.dll")]
		public static extern short GT_GetEventLoop(short cardNum, short eventIndex, out long pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetTaskCount(short cardNum, out short pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetTask(short cardNum, short taskIndex, out short pTaskType, System.IntPtr pTaskData);
		[DllImport("gts.dll")]
		public static extern short GT_GetEventTaskLinkCount(short cardNum, out short pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetEventTaskLink(short cardNum, short linkIndex, out short pEventIndex, out short pTaskIndex);
		[DllImport("gts.dll")]
		public static extern short GT_EventOn(short cardNum, short eventIndex, short count);
		[DllImport("gts.dll")]
		public static extern short GT_EventOff(short cardNum, short eventIndex, short count);
		[DllImport("gts.dll")]
		public static extern short GT_BufEventOn(short cardNum, short crd, short eventIndex, short count, short fifo);
		[DllImport("gts.dll")]
		public static extern short GT_BufEventOff(short cardNum, short crd, short eventIndex, short count, short fifo);

		public const long VAR_CALCULATE_NONE = 0;
		public const long VAR_CALCULATE_OR = 1;
		public const long VAR_CALCULATE_AND = 3;
		public const long VAR_CALCULATE_NOT = 5;

		public const long VAR_CALCULATE_ADD = 11;
		public const long VAR_CALCULATE_SUB = 12;
		public const long VAR_CALCULATE_MUL = 13;
		public const long VAR_CALCULATE_DIV = 14;

		public struct TWatchCondition
		{
			public TWatchVar var;
			public ushort condition;
			public double value;
		}

		public struct TVarCalculate
		{
			public ushort operation;
			public ushort varType;
			public ushort result;
			public ushort lhs;
			public ushort rhs;
		}

		[DllImport("gts.dll")]
		public static extern short GT_ClearVar(short cardNum);
		[DllImport("gts.dll")]
		public static extern short GT_SetVarBoolCondition(short cardNum, short varIndex, ref TWatchCondition pWatchCondition);
		[DllImport("gts.dll")]
		public static extern short GT_GetVarBoolCondition(short cardNum, short varIndex, out TWatchCondition pWatchCondition);
		[DllImport("gts.dll")]
		public static extern short GT_AddVarCalculate(short cardNum, ref TVarCalculate pVarCalculate, ref short pIndex);
		[DllImport("gts.dll")]
		public static extern short GT_GetVarCalculateCount(short cardNum, out short pCount);
		[DllImport("gts.dll")]
		public static extern short GT_GetVarCalculate(short cardNum, short index, out TVarCalculate pVarCalculate);
	}
	#endregion

	#region 二次开发API

	#endregion
	public class GoogolTechGTSCard_v2
	{
		/// <summary>
		/// 控制卡卡号
		/// </summary>
		public short CardNo { get; set; }

		/// <summary>
		/// 控制卡最大轴数
		/// </summary>
		public short AxisNum { get; set; }

		/// <summary>
		/// 规划位置
		/// </summary>
		public double[] PrfPosition { get; private set; }

		/// <summary>
		/// 实际位置
		/// </summary>
		public double[] EncPosition { get; private set; }

		/// <summary>
		/// 捕获状态
		/// </summary>
		public short[] CaptureStatus { get; private set; }

		/// <summary>
		/// 捕获值
		/// </summary>
		public int[] CapturePositionValue { get; private set; }

		/// <summary>
		///回零状态 
		/// </summary>
		public short[] HomeRunning { get; private set; }

		/// <summary>
		/// 回零阶段
		/// </summary>
		public short[] HomeStage { get; private set; }

		/// <summary>
		/// 回零错误
		/// </summary>
		public short[] HomeError { get; private set; }

		/// <summary>
		/// 回零捕获位置
		/// </summary>
		public int[] HomeCapturePos { get; private set; }

		/// <summary>
		/// 回零目标位置
		/// </summary>
		public int[] HomeTargetPos { get; private set; }


		public GoogolTechGTSCard_v2(short card, short cardAxisNum)  //构造函数
		{
			this.CardNo = card;  //传入卡号
			this.AxisNum = cardAxisNum;  //传入轴数
			this.CaptureStatus = new short[AxisNum];//初始化捕获状态数组
			this.CapturePositionValue = new int[AxisNum];//初始化捕获位置数组

			this.EncPosition = new double[AxisNum];//初始化实际位置数组
			this.PrfPosition = new double[AxisNum];//初始化规划位置数组

			this.HomeRunning = new short[AxisNum];
			this.HomeStage = new short[AxisNum];
			this.HomeError = new short[AxisNum];
			this.HomeCapturePos = new int[AxisNum];
			this.HomeTargetPos = new int[AxisNum];
		}

		#region 控制卡初始化
		/// <summary>
		/// 初始化控制卡
		/// </summary>
		/// <param name="configFile">配置文件</param>
		/// <returns></returns>
		public bool CardInit(string configFile)
		{
			short sRtn = 0;
			sRtn += mc.GT_Open(CardNo, 0, 1);//channel 0:正常打开；1：内部模式（用户不使用）。 param默认为1有效。
			sRtn += mc.GT_Reset(CardNo);     //复位控制器，恢复所有状态标志。会复位本地IO输出。
			sRtn += mc.GT_LoadConfig(CardNo, configFile);//加载配置文件.cfg格式文件。 放在应用程序目录使用文件名或使用绝对路径加载。
			sRtn += mc.GT_ClrSts(CardNo, 1, AxisNum);    //加载配置文件后复位所有轴状态
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region 使能控制
		/// <summary>
		/// 单轴使能
		/// </summary>
		/// <param name="axis">轴号（从1开始）</param>
		public short AxisServoOn(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_ClrSts(CardNo, 1, 1);
			sRtn += mc.GT_AxisOn(CardNo, axis);
			if (sRtn == 0)
			{
				return 0;
			}
			else
			{
				return axis;
			}
		}

		/// <summary>
		/// 单轴下使能
		/// </summary>
		/// <param name="axis">轴号（从1开始）</param>
		/// <returns></returns>
		public short AxisServoOff(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_ClrSts(CardNo, 1, 1);
			sRtn += mc.GT_AxisOff(CardNo, axis);
			if (sRtn == 0)
			{
				return 0;
			}
			else
			{
				return axis;
			}
		}

		/// <summary>
		/// 全部轴使能
		/// </summary>
		/// <returns>指令执行情况</returns>
		public List<short> AnyAxisServoOn()
		{
			short sRtn = 0;
			sRtn += mc.GT_ClrSts(CardNo, 1, AxisNum);
			List<short> a = new List<short>();
			for (short i = 0; i < AxisNum; i++)
			{
				sRtn += mc.GT_AxisOn(CardNo, (short)(i + 1));
				if (sRtn != 0)
				{
					a.Add((short)(i + 1));
				}
			}
			return a;
		}

		/// <summary>
		/// 全部轴下使能
		/// </summary>
		/// <returns>指令执行情况</returns>
		public List<short> AnyAxisServoOff()
		{
			short sRtn = 0;
			sRtn += mc.GT_ClrSts(CardNo, 1, AxisNum);
			List<short> a = new List<short>();
			for (short i = 0; i < AxisNum; i++)
			{
				sRtn += mc.GT_AxisOff(CardNo, (short)(i + 1));
				if (sRtn != 0)
				{
					a.Add((short)(i + 1));
				}
			}
			return a;
		}
		#endregion

		#region 轴停止控制
		/// <summary>
		/// 单轴平滑停止
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <returns></returns>
		public short AxisStopSoomth(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_Stop(CardNo, 1 << (axis - 1), 0);
			if (sRtn == 0)
			{
				return 0;
			}
			else
			{
				return axis;
			}
		}

		/// <summary>
		///单轴紧急停止
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <returns></returns>
		public bool AxisStopAbrupt(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_Stop(CardNo, 1 << (axis - 1), 1 << (axis - 1));
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region 基本运动
		public bool SetPrfTrap(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_Stop(CardNo, 1 << (axis - 1), 0);//先停止运动，再切换模式
			sRtn += mc.GT_PrfTrap(CardNo, axis);     //设置为点位运动，模式切换需要停止轴运动。
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 绝对位置运动（回零后）
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <param name="velP">速度</param>
		/// <param name="acc">加速度</param>
		/// <param name="dec">减速度</param>
		/// <param name="posP">目标位置</param>
		/// <returns></returns>
		public bool P2PAbs(short axis, double velP, double acc, short smoothTimeA, int posP)  //单轴绝对位置点位运动
		{
			short sRtn = 0;//返回值
			mc.TTrapPrm trap;
			sRtn += mc.GT_PrfTrap(CardNo, axis);     //设置为点位运动，模式切换需要停止轴运动。
														 //若返回值为 1：若当前轴在规划运动，请调用GT_Stop停止运动再调用该指令。
			sRtn += mc.GT_GetTrapPrm(CardNo, axis, out trap);       /*读取点位运动参数（不一定需要）。若返回值为 1：请检查当前轴是否为 Trap 模式
                                                                    若不是，请先调用 GT_PrfTrap 将当前轴设置为 Trap 模式。*/
			trap.acc = acc;              //单位pulse/ms2
			trap.dec = acc;              //单位pulse/ms2
			trap.velStart = 0;           //起跳速度，默认为0。
			trap.smoothTime = smoothTimeA;         //平滑时间，使加减速更为平滑。范围[0,50]单位ms。

			sRtn += mc.GT_SetTrapPrm(CardNo, axis, ref trap);//设置点位运动参数。

			sRtn += mc.GT_SetVel(CardNo, axis, velP);        //设置目标速度
			sRtn += mc.GT_SetPos(CardNo, axis, posP);        //设置目标位置
			sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));   //更新轴运动
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 增量点位运动
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <param name="velP">速度</param>
		/// <param name="acc">加速度</param>
		/// <param name="dec">减速度</param>
		/// <param name="posP">位置</param>
		/// <returns></returns>
		public bool P2PInc(short axis, double velP, double acc, short smoothTimeI, int posP)  //单轴增量位置点位运动
		{
			short sRtn = 0;     //返回值
			double prfPos; //规划脉冲
			uint pClock;    //时钟信号
			mc.TTrapPrm trap;
			sRtn += mc.GT_PrfTrap(CardNo, axis);     //设置为点位运动，模式切换需要停止轴运动。
														 //若返回值为 1：若当前轴在规划运动，请调用GT_Stop停止运动再调用该指令。
			sRtn += mc.GT_GetTrapPrm(CardNo, axis, out trap);       /*读取点位运动参数（不一定需要）。若返回值为 1：请检查当前轴是否为 Trap 模式
                                                                    若不是，请先调用 GT_PrfTrap 将当前轴设置为 Trap 模式。*/
			trap.acc = acc;              //单位pulse/ms2
			trap.dec = acc;              //单位pulse/ms2
			trap.velStart = 0;           //起跳速度，默认为0。
			trap.smoothTime = smoothTimeI;         //平滑时间，使加减速更为平滑。范围[0,50]单位ms。

			sRtn += mc.GT_SetTrapPrm(CardNo, axis, ref trap);//设置点位运动参数。
			sRtn += mc.GT_GetPrfPos(CardNo, axis, out prfPos, 1, out pClock);//读取规划位置
			sRtn += mc.GT_SetVel(CardNo, axis, velP);        //设置目标速度
			sRtn += mc.GT_SetPos(CardNo, axis, (int)(posP + prfPos));        //设置目标位置
			sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));   //更新轴运动
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool P2PInterval(short axis, double velP, int interval, int time, int delayTime, int startPos)  //单轴增量位置点位运动
		{
			short sRtn = 0;     //返回值
			int pStatus;        //轴状态字
			double prfPos;      //规划脉冲
			uint pClock;        //时钟信号
			mc.TTrapPrm trap;
			sRtn += mc.GT_PrfTrap(CardNo, axis);     //设置为点位运动，模式切换需要停止轴运动。
														 //若返回值为 1：若当前轴在规划运动，请调用GT_Stop停止运动再调用该指令。
			sRtn += mc.GT_GetTrapPrm(CardNo, axis, out trap);       /*读取点位运动参数（不一定需要）。若返回值为 1：请检查当前轴是否为 Trap 模式
                                                                    若不是，请先调用 GT_PrfTrap 将当前轴设置为 Trap 模式。*/
			trap.acc = 1;              //单位pulse/ms2
			trap.dec = 1;              //单位pulse/ms2
			trap.velStart = 0;           //起跳速度，默认为0。
			trap.smoothTime = 0;         //平滑时间，使加减速更为平滑。范围[0,50]单位ms。

			sRtn += mc.GT_SetTrapPrm(CardNo, axis, ref trap);//设置点位运动参数。
			sRtn += mc.GT_GetPrfPos(CardNo, axis, out prfPos, 1, out pClock);//读取规划位置
			sRtn += mc.GT_SetVel(CardNo, axis, velP);        //设置目标速度
			sRtn += mc.GT_SetPos(CardNo, axis, startPos);
			sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));   //更新轴运动
			do
			{
				sRtn = mc.GT_GetSts(CardNo, axis, out pStatus, 1, out pClock);
			} while ((pStatus & 0x0400) != 0);
			Thread.Sleep(delayTime);

			for (int i = 0; i < time; i++)
			{
				sRtn += mc.GT_SetPos(CardNo, axis, interval * (i + 1));        //设置目标位置
				sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));   //更新轴运动
				do
				{
					sRtn = mc.GT_GetSts(CardNo, axis, out pStatus, 1, out pClock);
				} while ((pStatus & 0x0400) != 0);
				Thread.Sleep(delayTime);
			}

			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// JOG运动
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <param name="velJ">速度</param>
		/// <param name="acc">加速度</param>
		/// <param name="dec">减速度</param>
		/// <returns></returns>
		public bool JOG(short axis, double velJ, double acc, double dec, double smoothTime)     //jog运动模式
		{
			short sRtn = 0;
			mc.TJogPrm pJog;
			sRtn += mc.GT_PrfJog(CardNo, axis);
			pJog.acc = acc;
			pJog.dec = dec;
			pJog.smooth = smoothTime;//平滑系数,取值范围[0, 1),平滑系数的数值越大，加减速过程越平稳。
			sRtn += mc.GT_SetJogPrm(CardNo, axis, ref pJog);//设置jog运动参数
			sRtn += mc.GT_SetVel(CardNo, axis, velJ);//设置目标速度,velJd的符号决定JOG运动方向
			sRtn += mc.GT_Update(CardNo, 1 << (axis - 1));//更新轴运动
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		/// <summary>
		/// Gear模式
		/// </summary>
		/// <param name="axisM">主轴轴号</param>
		/// <param name="axisS">从轴轴号</param>
		/// <param name="gearDir">跟随方向</param>
		/// <param name="gearType">跟随类型</param>
		/// <param name="ratio"></param>
		/// <param name="slope"></param>
		/// <returns></returns>
		public bool Gear(short axisM, short axisS, short gearDir, short gearType, int ratio, int slope, short filter)//电子齿轮模式
		{
			short sRtn = 0;
			//sRtn = mc.GT_SetAxisPrfVelFilter(CardNo, axisS, filter);//滤波
			sRtn += mc.GT_PrfGear(CardNo, axisS, gearDir);                  //从轴跟随模式
			sRtn += mc.GT_SetGearMaster(CardNo, axisS, axisM, gearType, 0); //  gearType 1：编码器 2：规划器 3：轴输出
			sRtn += mc.GT_SetGearRatio(CardNo, axisS, 1, ratio, slope);     //slope不能小于0或=1，离合区位移 ratio/1 表示齿轮比；
			sRtn += mc.GT_GearStart(CardNo, 1 << (axisS - 1));              //开启Gear运动
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// follow运动
		/// </summary>
		/// <param name="axisM">主轴</param>
		/// <param name="axisF">跟随轴</param>
		/// <param name="follow">位移跟随方式</param>
		/// <param name="followDir">跟随方向</param>
		/// <param name="masterPostion">主轴位移</param>
		/// <param name="followPostion">从轴位移</param>
		/// <param name="filter">滤波时间</param>
		/// <returns></returns>
		public bool Follow(short axisM, short axisF, short follow, short followDir, int masterPostion, double followPostion, short filter = 3)
		{
			short sRtn = 0;
			sRtn = mc.GT_PrfFollow(CardNo, axisF, followDir);   //双向跟随followDir 0:双向跟随 1：正向跟随 -1：负向跟随
			sRtn = mc.GT_FollowClear(CardNo, axisF, 0);         //清空缓存区数据，这里默认使用fifo0
																//sRtn = mc.GT_SetAxisPrfVelFilter(CardNo, axisF, filter); //设置滤波，消除可能的电机杂音一般0-10 单位 250us
			sRtn = mc.GT_SetFollowMaster(CardNo, axisF, axisM, follow, 0);//Follow运动下主轴设置 follow参数 1：编码器 2：规划器 3：轴输出
			sRtn = mc.GT_FollowData(CardNo, axisF, masterPostion, followPostion, mc.FOLLOW_SEGMENT_NORMAL, 0);//压入数据
			sRtn = mc.GT_SetFollowEvent(CardNo, axisF, mc.FOLLOW_EVENT_START, 1, 0);//设定为FollowStart启动，后两个参数设置不生效
			sRtn = mc.GT_FollowStart(CardNo, 1 << (axisF - 1), 0);   //启动Follow运动，使用fifo0缓存区数据
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region 回零
		public bool SetHomeMode(short axis, short homeMode, double vel1, double vel2, short searchDir, short zDir)
		{
			short sRtn = 0;
			mc.THomePrm tHomePrm;
			mc.THomeStatus pHomeStatus;
			//使用home回零或home+index回零，若轴停止在home点则需要先移开home点在开启回零。由实际情况确认。
			sRtn += mc.GT_ClrSts(CardNo, axis, AxisNum);
			sRtn += mc.GT_ZeroPos(CardNo, axis, 1);
			sRtn += mc.GT_GetHomePrm(CardNo, axis, out tHomePrm);
			tHomePrm.mode = homeMode;           //回零方式
			tHomePrm.searchHomeDistance = 0;    //搜索限位距离，0为无限大
			tHomePrm.searchIndexDistance = 0;   //搜索index距离，0为无限大
			tHomePrm.moveDir = searchDir;       //回零方向
			tHomePrm.indexDir = zDir;           //index搜索方向
			tHomePrm.velHigh = vel1;            //搜索限位的速度
			tHomePrm.velLow = vel2;             //搜索原点、index的速度
			tHomePrm.smoothTime = 10;
			tHomePrm.acc = vel1 / 100;    //经验值
			tHomePrm.dec = vel2 / 100;
			tHomePrm.escapeStep = 10000;//限位回零后方式时第一次找到限位反向移动距离
			tHomePrm.homeOffset = 0;    //原点偏移 = 0
			tHomePrm.edge = 1;
			sRtn += mc.GT_GoHome(CardNo, axis, ref tHomePrm);//启动SmartHome回原点
			do
			{
				sRtn += mc.GT_GetHomeStatus(CardNo, axis, out pHomeStatus);//获取回原点状态
			} while (pHomeStatus.run == 1 || pHomeStatus.stage != 100); // 等待搜索原点停止
			Thread.Sleep(1000);     //等待电机完全停止，时间由电机调试效果确定
			sRtn += mc.GT_ZeroPos(CardNo, axis, 1);  //回零完成手动清零
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void GetHomeStatus(short axis)
		{
			short sRtn = 0;
			mc.THomeStatus tHomeStatus = new mc.THomeStatus();
			sRtn += mc.GT_GetHomeStatus(CardNo, axis, out tHomeStatus);
			HomeRunning[axis - 1] = tHomeStatus.run;
			HomeStage[axis - 1] = tHomeStatus.stage;
			HomeError[axis - 1] = tHomeStatus.error;
			HomeCapturePos[axis - 1] = tHomeStatus.capturePos;
			HomeTargetPos[axis - 1] = tHomeStatus.targetPos;
		}
		#endregion

		#region 捕获功能
		/// <summary>
		/// 设置捕获模式及捕获边沿
		/// </summary>
		/// <param name="axis">需要捕获轴</param>
		/// <param name="captureMode">捕获模式</param>
		/// <param name="sense">捕获沿设置</param>
		/// <returns></returns>
		public bool SetCaptureMode(short axis, short captureMode, short sense)   //设置捕获模式、参数
		{
			short sRtn = 0;
			sRtn += mc.GT_SetCaptureSense(CardNo, axis, captureMode, sense);//设置捕获边沿 0：下降沿 1：上升沿
			sRtn += mc.GT_SetCaptureMode(CardNo, axis, captureMode); //设置捕获模式 1：home捕获 2：index捕获 3：探针捕获
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 读取捕获状态
		/// </summary>
		/// <param name="count"></param>
		/// <param name="status"></param>
		/// <param name="position"></param>
		/// <returns></returns>
		public void GetCaptureStatus()
		{
			short sRtn = 0;
			uint pClock;
			sRtn += mc.GT_GetCaptureStatus(CardNo, 1, out CaptureStatus[0], out CapturePositionValue[0], AxisNum, out pClock);
			//读取最大轴数的捕获位置，通过数组索引

		}

		public bool ClearCaptureStatus(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_ClearCaptureStatus(CardNo, axis);
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region IO状态
		/// <summary>
		/// 清除报警信号
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <returns></returns>
		public short ClearAlarmOn(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_SetDoBit(CardNo, mc.MC_CLEAR, axis, 0);//报警清除信号未取反是0表示输出低电平。
			if (sRtn == 0)
			{
				return 0;
			}
			else
			{
				return axis;
			}
		}
		/// <summary>
		/// 关闭报警清除信号
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <returns></returns>
		public bool ClearAlarmOff(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_SetDoBit(CardNo, mc.MC_CLEAR, axis, 1);//报警清除信号未取反是1表示关闭输出。
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region 轴卡状态信息
		/// <summary>
		/// 读取所有轴规划位置
		/// </summary>
		/// <returns></returns>
		public bool GetPrfPosition()
		{
			short sRtn = 0;
			short axisStart = 1;    //读取起始轴1
			uint pClock;            //时钟信号
			sRtn += mc.GT_GetPrfPos(CardNo, axisStart, out PrfPosition[0], AxisNum, out pClock);    //一般由1轴开始读取4轴或8轴
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 读取所有轴的实际位置
		/// </summary>
		/// <returns></returns>
		public bool GetEncPosition()
		{
			short sRtn = 0;
			short axisStart = 1;    //读取起始轴1
			uint pClock;    //时钟信号
			sRtn += mc.GT_GetEncPos(CardNo, axisStart, out EncPosition[0], AxisNum, out pClock);    //一般由1轴开始读取4轴或8轴
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 清除单轴状态
		/// </summary>
		/// <param name="axis"></param>
		/// <returns></returns>
		public bool ClearStatus(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_ClrSts(CardNo, axis, 1);  //清除单轴状态
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 清除单轴规划位置和实际位置
		/// </summary>
		/// <param name="axis">轴号</param>
		/// <returns></returns>
		public short ClearPosition(short axis)
		{
			short sRtn = 0;
			sRtn += mc.GT_ZeroPos(CardNo, axis, 1);//清除单轴规划位置和实际位置，必须在轴静止状态下才可以清除位置，否则返回值1。
			if (sRtn == 0)
			{
				return 0;
			}
			else
			{
				return axis;
			}
		}
		#endregion

		#region NewWatch功能
		/// <summary>
		/// 添加watch变量
		/// </summary>
		/// <param name="watchType">watch种类</param>
		/// <param name="varIndex">watch索引</param>
		/// <returns></returns>
		public bool AddWatchVar(ushort watchType, ushort varIndex)
		{
			short sRtn = 0;
			mc_cfg.TWatchVar tWatchVar = new mc_cfg.TWatchVar();
			tWatchVar.type = watchType;    //对照说明填写
			tWatchVar.index = varIndex;    //x轴轴号
			sRtn += mc_cfg.GT_AddWatchVar(CardNo, ref tWatchVar);//添加watch变量
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 添加watch事件
		/// </summary>
		/// <param name="watchType"></param>
		/// <param name="varIndex"></param>
		/// <returns></returns>
		public bool AddWatchEvent(ushort watchType, ushort varIndex, short eventType, short eventCondition, short conditionValue)
		{
			short sRtn = 0;
			//设置启动watch条件
			mc_cfg.TWatchEvent tWatchEvent = new mc_cfg.TWatchEvent();
			mc_cfg.TWatchVar tWatchVar = new mc_cfg.TWatchVar();
			tWatchVar.type = watchType;    //对照说明填写
			tWatchVar.index = varIndex;    //变量索引

			tWatchEvent.type = (ushort)mc_cfg.WATCH_EVENT_START;    //满足条件时开启
			tWatchEvent.var = tWatchVar;                            //变量作为条件
			tWatchEvent.loop = 0;//循环次数 0：无限
			tWatchEvent.condition = (ushort)mc_cfg.WATCH_CONDITION_EQ;//条件等于
			tWatchEvent.watchCount = 10000;//watch数据次数
			tWatchEvent.value = conditionValue;//WATCH_VAR_PRF_RUN值 = 1 开始watch数据，即1轴规划运动中开始watch功能
			sRtn = mc_cfg.GT_AddWatchEvent(CardNo, ref tWatchEvent);
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region 位置比较输出
		public bool CompareSingleOutput(short outputSet, short outputType, short pulseWidth, short index)
		{
			short sRtn = 0;
			sRtn += mc.GT_CompareStop(CardNo);  //停止位置比较输出
			sRtn += mc.GT_ComparePulse(CardNo, outputSet, outputType, pulseWidth);
			if (sRtn == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

	}
}
