using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static GoogolTechGTSCard_6.GTS.GoogolTechGTSCard_v1.GTSAxisControl;
using static GoogolTechGTSCard_6.GTS.mc;

namespace GoogolTechGTSCard_6.GSN
{
	//SF平台轴代码

	//#region 固高官方
	//class Stop
	//{
	//	//回零
	//	public void AxisStop(short core, short axis)
	//	{
	//		short Z;
	//		Z = GTN_Stop(core, 1 << axis - 1, 0);
	//	}
	//}
	//class GSNCard
	//{
	//	short Z;
	//	//回零
	//	public void SmartHome(short core, short axis, THomePrm homePrm, out THomeStatus pHomeStatus)
	//	{
	//		int pStatus;
	//		uint pClock;
	//		THomePrm tHomePrm;
	//		//回零前停止轴运动，清除一下状态和位置
	//		Z = GTN_Stop(core, 1 << axis - 1, 0);
	//		Z = GTN_ClrSts(core, axis, 1);
	//		Z = GTN_ZeroPos(core, axis, 1);
	//		tHomePrm = homePrm;//传参
	//		Z = GTN_GoHome(core, axis, ref tHomePrm);//回零
	//		do
	//		{
	//			Z = GTN_GetHomeStatus(core, axis, out pHomeStatus);//获取回原点状态
	//		} while (pHomeStatus.run == 1 || pHomeStatus.stage != 100); //等待搜索原点停止
	//		do
	//		{
	//			Z = GTN_GetSts(core, axis, out pStatus, 1, out pClock);
	//		} while ((pStatus & 0x800) == 0);//等待轴到位
	//		Thread.Sleep(1);
	//		Z = GTN_ZeroPos(core, axis, 1);//到位后位置清零
	//	}
	//	//单轴清零
	//	public void AxisZeroPos(short core, short axis)
	//	{
	//		Z = GTN_ZeroPos(core, axis, 1);
	//	}

	//	public void ScanData(short Scan)
	//	{

	//		Z = GTN_ScanMark(1, -365, 564, 126, Scan);
	//		Z = GTN_ScanMark(1, -390, 563, 78, Scan);
	//		Z = GTN_ScanMark(1, -410, 572, 78, Scan);
	//		Z = GTN_ScanMark(1, -423, 588, 78, Scan);
	//		Z = GTN_ScanMark(1, -425, 607, 78, Scan);
	//		Z = GTN_ScanMark(1, -417, 626, 78, Scan);
	//		Z = GTN_ScanMark(1, -400, 639, 78, Scan);
	//		Z = GTN_ScanMark(1, -377, 643, 78, Scan);
	//		Z = GTN_ScanMark(1, -352, 636, 78, Scan);
	//		Z = GTN_ScanMark(1, -328, 619, 78, Scan);
	//		Z = GTN_ScanMark(1, -311, 593, 78, Scan);
	//		Z = GTN_ScanMark(1, -304, 562, 78, Scan);
	//		Z = GTN_ScanMark(1, -306, 529, 78, Scan);
	//		Z = GTN_ScanMark(1, -319, 500, 78, Scan);
	//		Z = GTN_ScanMark(1, -340, 479, 78, Scan);
	//		Z = GTN_ScanMark(1, -365, 467, 78, Scan);
	//		Z = GTN_ScanMark(1, -365, 460, 78, Scan);
	//		Z = GTN_ScanMark(1, -390, 459, 78, Scan);
	//		Z = GTN_ScanMark(1, -411, 468, 78, Scan);
	//		Z = GTN_ScanMark(1, -423, 484, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, 503, 78, Scan);
	//		Z = GTN_ScanMark(1, -418, 521, 78, Scan);
	//		Z = GTN_ScanMark(1, -401, 534, 78, Scan);
	//		Z = GTN_ScanMark(1, -378, 538, 78, Scan);
	//		Z = GTN_ScanMark(1, -352, 531, 78, Scan);
	//		Z = GTN_ScanMark(1, -329, 514, 78, Scan);
	//		Z = GTN_ScanMark(1, -312, 489, 78, Scan);
	//		Z = GTN_ScanMark(1, -304, 458, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, 426, 78, Scan);
	//		Z = GTN_ScanMark(1, -320, 397, 78, Scan);
	//		Z = GTN_ScanMark(1, -341, 375, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 363, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 357, 78, Scan);
	//		Z = GTN_ScanMark(1, -391, 356, 78, Scan);
	//		Z = GTN_ScanMark(1, -411, 365, 78, Scan);
	//		Z = GTN_ScanMark(1, -424, 380, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, 400, 78, Scan);
	//		Z = GTN_ScanMark(1, -418, 418, 78, Scan);
	//		Z = GTN_ScanMark(1, -401, 430, 78, Scan);
	//		Z = GTN_ScanMark(1, -378, 434, 78, Scan);
	//		Z = GTN_ScanMark(1, -353, 428, 78, Scan);
	//		Z = GTN_ScanMark(1, -330, 411, 78, Scan);
	//		Z = GTN_ScanMark(1, -312, 385, 78, Scan);
	//		Z = GTN_ScanMark(1, -305, 354, 78, Scan);
	//		Z = GTN_ScanBufDA(1, 0, 32767, 1);
	//		Z = GTN_ScanMark(1, -308, 322, 78, Scan);
	//		Z = GTN_ScanMark(1, -321, 293, 78, Scan);
	//		Z = GTN_ScanMark(1, -342, 271, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 259, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 252, 78, Scan);
	//		Z = GTN_ScanMark(1, -391, 251, 78, Scan);
	//		Z = GTN_ScanMark(1, -412, 260, 78, Scan);
	//		Z = GTN_ScanMark(1, -424, 276, 78, Scan);
	//		Z = GTN_ScanMark(1, -427, 296, 78, Scan);
	//		Z = GTN_ScanMark(1, -419, 314, 78, Scan);
	//		Z = GTN_ScanMark(1, -402, 327, 78, Scan);
	//		Z = GTN_ScanMark(1, -379, 331, 78, Scan);
	//		Z = GTN_ScanMark(1, -353, 324, 78, Scan);
	//		Z = GTN_ScanMark(1, -330, 307, 78, Scan);
	//		Z = GTN_ScanMark(1, -313, 281, 78, Scan);
	//		Z = GTN_ScanMark(1, -305, 250, 78, Scan);
	//		Z = GTN_ScanMark(1, -308, 217, 78, Scan);
	//		Z = GTN_ScanMark(1, -321, 188, 78, Scan);
	//		Z = GTN_ScanMark(1, -342, 166, 78, Scan);
	//		Z = GTN_ScanMark(1, -367, 154, 78, Scan);
	//		Z = GTN_ScanMark(1, -367, 148, 78, Scan);
	//		Z = GTN_ScanMark(1, -392, 147, 78, Scan);
	//		Z = GTN_ScanMark(1, -412, 155, 78, Scan);
	//		Z = GTN_ScanMark(1, -425, 172, 78, Scan);
	//		Z = GTN_ScanMark(1, -427, 191, 78, Scan);
	//		Z = GTN_ScanMark(1, -419, 209, 78, Scan);
	//		Z = GTN_ScanMark(1, -402, 222, 78, Scan);
	//		Z = GTN_ScanMark(1, -379, 226, 78, Scan);
	//		Z = GTN_ScanMark(1, -354, 220, 78, Scan);
	//		Z = GTN_ScanMark(1, -331, 203, 78, Scan);
	//		Z = GTN_ScanMark(1, -314, 177, 78, Scan);
	//		Z = GTN_ScanMark(1, -306, 145, 78, Scan);
	//		Z = GTN_ScanMark(1, -309, 113, 78, Scan);
	//		Z = GTN_ScanMark(1, -322, 84, 78, Scan);
	//		Z = GTN_ScanMark(1, -343, 62, 78, Scan);
	//		Z = GTN_ScanMark(1, -367, 50, 78, Scan);
	//		Z = GTN_ScanMark(1, -367, 43, 78, Scan);
	//		Z = GTN_ScanMark(1, -392, 42, 78, Scan);
	//		Z = GTN_ScanMark(1, -413, 51, 78, Scan);
	//		Z = GTN_ScanMark(1, -425, 67, 78, Scan);
	//		Z = GTN_ScanMark(1, -428, 86, 78, Scan);
	//		Z = GTN_ScanMark(1, -420, 105, 78, Scan);
	//		Z = GTN_ScanMark(1, -403, 118, 78, Scan);
	//		Z = GTN_ScanMark(1, -380, 122, 78, Scan);
	//		Z = GTN_ScanMark(1, -354, 115, 78, Scan);
	//		Z = GTN_ScanMark(1, -331, 98, 78, Scan);
	//		Z = GTN_ScanMark(1, -314, 72, 78, Scan);
	//		Z = GTN_ScanMark(1, -306, 41, 78, Scan);
	//		Z = GTN_ScanMark(1, -309, 8, 78, Scan);
	//		Z = GTN_ScanMark(1, -322, -21, 78, Scan);
	//		Z = GTN_ScanMark(1, -343, -43, 78, Scan);
	//		Z = GTN_ScanMark(1, -368, -55, 78, Scan);
	//		Z = GTN_ScanMark(1, -368, -61, 78, Scan);
	//		Z = GTN_ScanMark(1, -393, -62, 78, Scan);
	//		Z = GTN_ScanMark(1, -413, -54, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, -38, 78, Scan);
	//		Z = GTN_ScanMark(1, -428, -18, 78, Scan);
	//		Z = GTN_ScanMark(1, -420, 0, 78, Scan);
	//		Z = GTN_ScanMark(1, -403, 13, 78, Scan);
	//		Z = GTN_ScanMark(1, -380, 17, 78, Scan);
	//		Z = GTN_ScanMark(1, -355, 11, 78, Scan);
	//		Z = GTN_ScanMark(1, -332, -7, 78, Scan);
	//		Z = GTN_ScanMark(1, -315, -33, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, -64, 78, Scan);
	//		Z = GTN_ScanMark(1, -310, -96, 78, Scan);
	//		Z = GTN_ScanMark(1, -322, -125, 78, Scan);
	//		Z = GTN_ScanMark(1, -343, -147, 78, Scan);
	//		Z = GTN_ScanMark(1, -368, -159, 78, Scan);
	//		Z = GTN_ScanMark(1, -368, -166, 78, Scan);
	//		Z = GTN_ScanMark(1, -393, -167, 78, Scan);
	//		Z = GTN_ScanMark(1, -413, -158, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, -142, 78, Scan);
	//		Z = GTN_ScanMark(1, -429, -123, 78, Scan);
	//		Z = GTN_ScanMark(1, -421, -104, 78, Scan);
	//		Z = GTN_ScanMark(1, -404, -92, 78, Scan);
	//		Z = GTN_ScanMark(1, -381, -87, 78, Scan);
	//		Z = GTN_ScanMark(1, -355, -94, 78, Scan);
	//		Z = GTN_ScanMark(1, -332, -111, 78, Scan);
	//		Z = GTN_ScanMark(1, -315, -137, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, -168, 78, Scan);
	//		Z = GTN_ScanMark(1, -310, -201, 78, Scan);
	//		Z = GTN_ScanMark(1, -323, -229, 78, Scan);
	//		Z = GTN_ScanMark(1, -344, -251, 78, Scan);
	//		Z = GTN_ScanMark(1, -368, -263, 78, Scan);
	//		Z = GTN_ScanMark(1, -368, -269, 78, Scan);
	//		Z = GTN_ScanMark(1, -393, -270, 78, Scan);
	//		Z = GTN_ScanMark(1, -414, -262, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, -246, 78, Scan);
	//		Z = GTN_ScanMark(1, -429, -227, 78, Scan);
	//		Z = GTN_ScanMark(1, -421, -209, 78, Scan);
	//		Z = GTN_ScanMark(1, -404, -196, 78, Scan);
	//		Z = GTN_ScanMark(1, -381, -192, 78, Scan);
	//		Z = GTN_ScanMark(1, -356, -198, 78, Scan);
	//		Z = GTN_ScanMark(1, -332, -215, 78, Scan);
	//		Z = GTN_ScanMark(1, -315, -241, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, -272, 78, Scan);
	//		Z = GTN_ScanMark(1, -310, -304, 78, Scan);
	//		Z = GTN_ScanMark(1, -323, -333, 78, Scan);
	//		Z = GTN_ScanMark(1, -344, -354, 78, Scan);
	//		Z = GTN_ScanMark(1, -369, -366, 78, Scan);
	//		Z = GTN_ScanMark(1, -369, -373, 78, Scan);
	//		Z = GTN_ScanMark(1, -394, -374, 78, Scan);
	//		Z = GTN_ScanMark(1, -414, -365, 78, Scan);
	//		Z = GTN_ScanBufDA(1, 0, 16384, 1);
	//		Z = GTN_ScanMark(1, -427, -349, 78, Scan);
	//		Z = GTN_ScanMark(1, -429, -330, 78, Scan);
	//		Z = GTN_ScanMark(1, -421, -312, 78, Scan);
	//		Z = GTN_ScanMark(1, -404, -299, 78, Scan);
	//		Z = GTN_ScanMark(1, -381, -295, 78, Scan);
	//		Z = GTN_ScanMark(1, -356, -301, 78, Scan);
	//		Z = GTN_ScanMark(1, -333, -318, 78, Scan);
	//		Z = GTN_ScanMark(1, -316, -344, 78, Scan);
	//		Z = GTN_ScanMark(1, -308, -375, 78, Scan);
	//		Z = GTN_ScanMark(1, -310, -408, 78, Scan);
	//		Z = GTN_ScanMark(1, -323, -437, 78, Scan);
	//		Z = GTN_ScanMark(1, -344, -459, 78, Scan);
	//		Z = GTN_ScanMark(1, -369, -471, 78, Scan);
	//		Z = GTN_ScanMark(1, -369, -477, 78, Scan);
	//		Z = GTN_ScanMark(1, -394, -479, 78, Scan);
	//		Z = GTN_ScanMark(1, -414, -470, 78, Scan);
	//		Z = GTN_ScanMark(1, -427, -454, 78, Scan);
	//		Z = GTN_ScanMark(1, -430, -434, 78, Scan);
	//		Z = GTN_ScanMark(1, -422, -416, 78, Scan);
	//		Z = GTN_ScanMark(1, -405, -403, 78, Scan);
	//		Z = GTN_ScanMark(1, -382, -399, 78, Scan);
	//		Z = GTN_ScanMark(1, -356, -405, 78, Scan);
	//		Z = GTN_ScanMark(1, -333, -423, 78, Scan);
	//		Z = GTN_ScanMark(1, -316, -449, 78, Scan);
	//		Z = GTN_ScanMark(1, -308, -480, 78, Scan);
	//		Z = GTN_ScanMark(1, -311, -513, 78, Scan);
	//		Z = GTN_ScanMark(1, -324, -542, 78, Scan);
	//		Z = GTN_ScanMark(1, -345, -563, 78, Scan);
	//		Z = GTN_ScanMark(1, -369, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -369, -581, 78, Scan);
	//		Z = GTN_ScanMark(1, -394, -583, 78, Scan);
	//		Z = GTN_ScanMark(1, -415, -574, 78, Scan);
	//		Z = GTN_ScanMark(1, -427, -558, 78, Scan);
	//		Z = GTN_ScanMark(1, -430, -539, 78, Scan);
	//		Z = GTN_ScanMark(1, -422, -521, 78, Scan);
	//		Z = GTN_ScanMark(1, -405, -508, 78, Scan);
	//		Z = GTN_ScanMark(1, -382, -504, 78, Scan);
	//		Z = GTN_ScanMark(1, -357, -510, 78, Scan);
	//		Z = GTN_ScanMark(1, -333, -527, 78, Scan);
	//		Z = GTN_ScanMark(1, -316, -553, 78, Scan);
	//		Z = GTN_ScanMark(1, -308, -584, 78, Scan);
	//		Z = GTN_ScanMark(1, -311, -616, 78, Scan);
	//		Z = GTN_ScanMark(1, -324, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -345, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -370, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -363, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -382, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, -396, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -402, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -398, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, -384, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, -361, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -331, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, -299, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, -269, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -245, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, -231, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, -227, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -234, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -248, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, -267, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -261, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -279, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, -294, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -300, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -296, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, -282, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, -258, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -228, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, -196, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, -166, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -143, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, -129, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, -125, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -132, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -146, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, -164, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -158, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -176, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, -190, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -197, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -193, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, -178, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, -155, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -126, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, -94, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, -65, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -42, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, -28, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, -25, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -31, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -45, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, -63, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -57, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, -75, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, -89, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, -96, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, -92, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, -78, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, -55, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, -25, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 6, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 36, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, 59, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, 73, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, 77, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, 70, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, 56, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 38, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 44, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 26, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 11, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, 5, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, 9, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, 23, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, 47, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, 76, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 108, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 138, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, 161, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, 175, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, 179, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, 172, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, 158, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 140, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 146, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 127, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 113, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, 107, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, 111, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, 125, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, 149, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, 178, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 210, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 239, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, 263, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, 277, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, 280, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, 274, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, 260, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 241, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 248, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 229, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 215, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, 209, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, 213, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, 227, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, 250, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, 280, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 312, -565, 78, Scan);
	//		Z = GTN_ScanMark(1, 341, -575, 78, Scan);
	//		Z = GTN_ScanMark(1, 365, -595, 78, Scan);
	//		Z = GTN_ScanMark(1, 379, -619, 78, Scan);
	//		Z = GTN_ScanMark(1, 383, -645, 78, Scan);
	//		Z = GTN_ScanMark(1, 376, -667, 78, Scan);
	//		Z = GTN_ScanMark(1, 362, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 343, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 350, -688, 78, Scan);
	//		Z = GTN_ScanMark(1, 341, -682, 78, Scan);
	//		Z = GTN_ScanMark(1, 321, -661, 78, Scan);
	//		Z = GTN_ScanMark(1, 308, -632, 78, Scan);
	//		Z = GTN_ScanMark(1, 305, -600, 78, Scan);
	//		Z = GTN_ScanMark(1, 313, -569, 78, Scan);
	//		Z = GTN_ScanMark(1, 330, -543, 78, Scan);
	//		Z = GTN_ScanMark(1, 354, -526, 78, Scan);
	//		Z = GTN_ScanMark(1, 379, -520, 78, Scan);
	//		Z = GTN_ScanMark(1, 403, -524, 78, Scan);
	//		Z = GTN_ScanMark(1, 420, -536, 78, Scan);
	//		Z = GTN_ScanMark(1, 428, -554, 78, Scan);
	//		Z = GTN_ScanMark(1, 425, -574, 78, Scan);
	//		Z = GTN_ScanMark(1, 412, -589, 78, Scan);
	//		Z = GTN_ScanMark(1, 392, -598, 78, Scan);
	//		Z = GTN_ScanMark(1, 366, -597, 78, Scan);
	//		Z = GTN_ScanMark(1, 366, -591, 78, Scan);
	//		Z = GTN_ScanMark(1, 341, -579, 78, Scan);
	//		Z = GTN_ScanMark(1, 321, -557, 78, Scan);
	//		Z = GTN_ScanMark(1, 308, -528, 78, Scan);
	//		Z = GTN_ScanMark(1, 306, -496, 78, Scan);
	//		Z = GTN_ScanMark(1, 314, -465, 78, Scan);
	//		Z = GTN_ScanMark(1, 331, -439, 78, Scan);
	//		Z = GTN_ScanMark(1, 354, -421, 78, Scan);
	//		Z = GTN_ScanMark(1, 380, -415, 78, Scan);
	//		Z = GTN_ScanMark(1, 403, -419, 78, Scan);
	//		Z = GTN_ScanMark(1, 420, -432, 78, Scan);
	//		Z = GTN_ScanMark(1, 428, -450, 78, Scan);
	//		Z = GTN_ScanMark(1, 426, -470, 78, Scan);
	//		Z = GTN_ScanMark(1, 413, -486, 78, Scan);
	//		Z = GTN_ScanMark(1, 392, -494, 78, Scan);
	//		Z = GTN_ScanMark(1, 367, -493, 78, Scan);
	//		Z = GTN_ScanMark(1, 367, -487, 78, Scan);
	//		Z = GTN_ScanBufDA(1, 0, 32767, 1);
	//		Z = GTN_ScanMark(1, 342, -475, 78, Scan);
	//		Z = GTN_ScanMark(1, 321, -453, 78, Scan);
	//		Z = GTN_ScanMark(1, 308, -424, 78, Scan);
	//		Z = GTN_ScanMark(1, 306, -391, 78, Scan);
	//		Z = GTN_ScanMark(1, 314, -360, 78, Scan);
	//		Z = GTN_ScanMark(1, 331, -334, 78, Scan);
	//		Z = GTN_ScanMark(1, 354, -317, 78, Scan);
	//		Z = GTN_ScanMark(1, 380, -311, 78, Scan);
	//		Z = GTN_ScanMark(1, 404, -315, 78, Scan);
	//		Z = GTN_ScanMark(1, 421, -327, 78, Scan);
	//		Z = GTN_ScanMark(1, 429, -345, 78, Scan);
	//		Z = GTN_ScanMark(1, 426, -365, 78, Scan);
	//		Z = GTN_ScanMark(1, 413, -381, 78, Scan);
	//		Z = GTN_ScanMark(1, 392, -390, 78, Scan);
	//		Z = GTN_ScanMark(1, 367, -389, 78, Scan);
	//		Z = GTN_ScanMark(1, 367, -382, 78, Scan);
	//		Z = GTN_ScanMark(1, 342, -370, 78, Scan);
	//		Z = GTN_ScanMark(1, 321, -348, 78, Scan);
	//		Z = GTN_ScanMark(1, 309, -319, 78, Scan);
	//		Z = GTN_ScanMark(1, 306, -287, 78, Scan);
	//		Z = GTN_ScanMark(1, 314, -256, 78, Scan);
	//		Z = GTN_ScanMark(1, 331, -231, 78, Scan);
	//		Z = GTN_ScanMark(1, 355, -214, 78, Scan);
	//		Z = GTN_ScanMark(1, 380, -208, 78, Scan);
	//		Z = GTN_ScanMark(1, 404, -212, 78, Scan);
	//		Z = GTN_ScanMark(1, 421, -224, 78, Scan);
	//		Z = GTN_ScanMark(1, 429, -242, 78, Scan);
	//		Z = GTN_ScanMark(1, 426, -261, 78, Scan);
	//		Z = GTN_ScanMark(1, 413, -277, 78, Scan);
	//		Z = GTN_ScanMark(1, 392, -286, 78, Scan);
	//		Z = GTN_ScanMark(1, 367, -285, 78, Scan);
	//		Z = GTN_ScanMark(1, 367, -278, 78, Scan);
	//		Z = GTN_ScanMark(1, 342, -267, 78, Scan);
	//		Z = GTN_ScanMark(1, 322, -245, 78, Scan);
	//		Z = GTN_ScanMark(1, 309, -216, 78, Scan);
	//		Z = GTN_ScanMark(1, 307, -184, 78, Scan);
	//		Z = GTN_ScanMark(1, 314, -153, 78, Scan);
	//		Z = GTN_ScanMark(1, 331, -127, 78, Scan);
	//		Z = GTN_ScanMark(1, 355, -110, 78, Scan);
	//		Z = GTN_ScanMark(1, 381, -103, 78, Scan);
	//		Z = GTN_ScanMark(1, 404, -107, 78, Scan);
	//		Z = GTN_ScanMark(1, 421, -120, 78, Scan);
	//		Z = GTN_ScanMark(1, 429, -139, 78, Scan);
	//		Z = GTN_ScanMark(1, 426, -158, 78, Scan);
	//		Z = GTN_ScanMark(1, 414, -174, 78, Scan);
	//		Z = GTN_ScanMark(1, 393, -183, 78, Scan);
	//		Z = GTN_ScanMark(1, 368, -182, 78, Scan);
	//		Z = GTN_ScanMark(1, 368, -175, 78, Scan);
	//		Z = GTN_ScanMark(1, 342, -163, 78, Scan);
	//		Z = GTN_ScanMark(1, 322, -141, 78, Scan);
	//		Z = GTN_ScanMark(1, 309, -112, 78, Scan);
	//		Z = GTN_ScanMark(1, 307, -80, 78, Scan);
	//		Z = GTN_ScanMark(1, 315, -48, 78, Scan);
	//		Z = GTN_ScanMark(1, 332, -23, 78, Scan);
	//		Z = GTN_ScanMark(1, 355, -5, 78, Scan);
	//		Z = GTN_ScanMark(1, 381, 1, 78, Scan);
	//		Z = GTN_ScanMark(1, 404, -3, 78, Scan);
	//		Z = GTN_ScanMark(1, 422, -16, 78, Scan);
	//		Z = GTN_ScanMark(1, 429, -34, 78, Scan);
	//		Z = GTN_ScanMark(1, 427, -53, 78, Scan);
	//		Z = GTN_ScanMark(1, 414, -70, 78, Scan);
	//		Z = GTN_ScanMark(1, 393, -78, 78, Scan);
	//		Z = GTN_ScanMark(1, 368, -77, 78, Scan);
	//		Z = GTN_ScanMark(1, 368, -71, 78, Scan);
	//		Z = GTN_ScanMark(1, 343, -59, 78, Scan);
	//		Z = GTN_ScanMark(1, 322, -37, 78, Scan);
	//		Z = GTN_ScanMark(1, 310, -8, 78, Scan);
	//		Z = GTN_ScanMark(1, 307, 25, 78, Scan);
	//		Z = GTN_ScanMark(1, 315, 56, 78, Scan);
	//		Z = GTN_ScanMark(1, 332, 82, 78, Scan);
	//		Z = GTN_ScanMark(1, 356, 99, 78, Scan);
	//		Z = GTN_ScanMark(1, 381, 106, 78, Scan);
	//		Z = GTN_ScanMark(1, 405, 102, 78, Scan);
	//		Z = GTN_ScanMark(1, 422, 89, 78, Scan);
	//		Z = GTN_ScanMark(1, 430, 70, 78, Scan);
	//		Z = GTN_ScanMark(1, 427, 51, 78, Scan);
	//		Z = GTN_ScanMark(1, 414, 35, 78, Scan);
	//		Z = GTN_ScanMark(1, 393, 26, 78, Scan);
	//		Z = GTN_ScanMark(1, 368, 27, 78, Scan);
	//		Z = GTN_ScanMark(1, 368, 34, 78, Scan);
	//		Z = GTN_ScanMark(1, 343, 46, 78, Scan);
	//		Z = GTN_ScanMark(1, 323, 68, 78, Scan);
	//		Z = GTN_ScanMark(1, 310, 97, 78, Scan);
	//		Z = GTN_ScanMark(1, 308, 129, 78, Scan);
	//		Z = GTN_ScanMark(1, 316, 161, 78, Scan);
	//		Z = GTN_ScanMark(1, 333, 187, 78, Scan);
	//		Z = GTN_ScanMark(1, 356, 204, 78, Scan);
	//		Z = GTN_ScanMark(1, 382, 210, 78, Scan);
	//		Z = GTN_ScanMark(1, 405, 206, 78, Scan);
	//		Z = GTN_ScanMark(1, 423, 193, 78, Scan);
	//		Z = GTN_ScanMark(1, 430, 175, 78, Scan);
	//		Z = GTN_ScanMark(1, 428, 156, 78, Scan);
	//		Z = GTN_ScanMark(1, 415, 140, 78, Scan);
	//		Z = GTN_ScanMark(1, 394, 131, 78, Scan);
	//		Z = GTN_ScanMark(1, 369, 132, 78, Scan);
	//		Z = GTN_ScanMark(1, 369, 138, 78, Scan);
	//		Z = GTN_ScanMark(1, 344, 150, 78, Scan);
	//		Z = GTN_ScanMark(1, 323, 172, 78, Scan);
	//		Z = GTN_ScanMark(1, 311, 201, 78, Scan);
	//		Z = GTN_ScanMark(1, 308, 234, 78, Scan);
	//		Z = GTN_ScanMark(1, 316, 265, 78, Scan);
	//		Z = GTN_ScanMark(1, 333, 291, 78, Scan);
	//		Z = GTN_ScanMark(1, 357, 308, 78, Scan);
	//		Z = GTN_ScanMark(1, 383, 315, 78, Scan);
	//		Z = GTN_ScanMark(1, 406, 311, 78, Scan);
	//		Z = GTN_ScanMark(1, 423, 298, 78, Scan);
	//		Z = GTN_ScanMark(1, 431, 280, 78, Scan);
	//		Z = GTN_ScanMark(1, 428, 260, 78, Scan);
	//		Z = GTN_ScanMark(1, 415, 244, 78, Scan);
	//		Z = GTN_ScanMark(1, 394, 235, 78, Scan);
	//		Z = GTN_ScanMark(1, 369, 236, 78, Scan);
	//		Z = GTN_ScanMark(1, 369, 243, 78, Scan);
	//		Z = GTN_ScanMark(1, 344, 255, 78, Scan);
	//		Z = GTN_ScanMark(1, 324, 277, 78, Scan);
	//		Z = GTN_ScanMark(1, 311, 306, 78, Scan);
	//		Z = GTN_ScanMark(1, 309, 339, 78, Scan);
	//		Z = GTN_ScanMark(1, 317, 370, 78, Scan);
	//		Z = GTN_ScanMark(1, 334, 395, 78, Scan);
	//		Z = GTN_ScanMark(1, 357, 412, 78, Scan);
	//		Z = GTN_ScanMark(1, 383, 419, 78, Scan);
	//		Z = GTN_ScanMark(1, 407, 415, 78, Scan);
	//		Z = GTN_ScanMark(1, 424, 402, 78, Scan);
	//		Z = GTN_ScanMark(1, 432, 384, 78, Scan);
	//		Z = GTN_ScanMark(1, 429, 365, 78, Scan);
	//		Z = GTN_ScanMark(1, 416, 349, 78, Scan);
	//		Z = GTN_ScanMark(1, 395, 340, 78, Scan);
	//		Z = GTN_ScanMark(1, 370, 341, 78, Scan);
	//		Z = GTN_ScanMark(1, 370, 348, 78, Scan);
	//		Z = GTN_ScanMark(1, 345, 360, 78, Scan);
	//		Z = GTN_ScanMark(1, 324, 381, 78, Scan);
	//		Z = GTN_ScanMark(1, 312, 410, 78, Scan);
	//		Z = GTN_ScanMark(1, 309, 442, 78, Scan);
	//		Z = GTN_ScanMark(1, 317, 473, 78, Scan);
	//		Z = GTN_ScanMark(1, 334, 499, 78, Scan);
	//		Z = GTN_ScanMark(1, 358, 515, 78, Scan);
	//		Z = GTN_ScanMark(1, 384, 522, 78, Scan);
	//		Z = GTN_ScanMark(1, 407, 518, 78, Scan);
	//		Z = GTN_ScanMark(1, 424, 505, 78, Scan);
	//		Z = GTN_ScanMark(1, 432, 487, 78, Scan);
	//		Z = GTN_ScanMark(1, 429, 468, 78, Scan);
	//		Z = GTN_ScanMark(1, 416, 452, 78, Scan);
	//		Z = GTN_ScanMark(1, 396, 443, 78, Scan);
	//		Z = GTN_ScanMark(1, 370, 445, 78, Scan);
	//		Z = GTN_ScanMark(1, 370, 451, 78, Scan);
	//		Z = GTN_ScanMark(1, 345, 463, 78, Scan);
	//		Z = GTN_ScanMark(1, 325, 484, 78, Scan);
	//		Z = GTN_ScanMark(1, 312, 513, 78, Scan);
	//		Z = GTN_ScanMark(1, 310, 546, 78, Scan);
	//		Z = GTN_ScanMark(1, 318, 577, 78, Scan);
	//		Z = GTN_ScanMark(1, 335, 603, 78, Scan);
	//		Z = GTN_ScanMark(1, 358, 620, 78, Scan);
	//		Z = GTN_ScanMark(1, 384, 627, 78, Scan);
	//		Z = GTN_ScanMark(1, 408, 623, 78, Scan);
	//		Z = GTN_ScanMark(1, 425, 610, 78, Scan);
	//		Z = GTN_ScanMark(1, 433, 591, 78, Scan);
	//		Z = GTN_ScanMark(1, 430, 572, 78, Scan);
	//		Z = GTN_ScanMark(1, 417, 556, 78, Scan);
	//		Z = GTN_ScanMark(1, 396, 547, 78, Scan);
	//		Z = GTN_ScanMark(1, 371, 548, 78, Scan);
	//		Z = GTN_ScanMark(1, 371, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, 339, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, 313, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, 294, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, 285, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, 286, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, 297, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 314, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, 333, 688, 78, Scan);
	//		Z = GTN_ScanMark(1, 350, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 361, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, 362, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, 353, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, 333, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, 306, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, 275, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, 269, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, 238, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, 211, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, 192, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, 183, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, 185, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, 195, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 212, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, 231, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, 248, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 259, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, 260, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, 251, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, 232, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, 205, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, 174, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, 167, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, 136, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, 109, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, 90, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, 81, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, 83, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, 94, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 111, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, 130, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, 146, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 157, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, 158, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, 149, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, 130, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, 103, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, 72, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, 65, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, 34, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, 7, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -12, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, -20, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, -19, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, -8, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 9, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, 28, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, 44, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, 55, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, 56, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, 47, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, 28, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, 1, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -30, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -36, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -67, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -93, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -112, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, -121, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, -119, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, -109, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, -92, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, -73, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, -57, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, -46, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, -45, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, -54, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, -73, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -100, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -130, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -137, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -167, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -195, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -214, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, -223, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, -221, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, -210, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, -193, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, -174, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, -157, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, -147, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, -145, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, -154, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, -173, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -201, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -233, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -239, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -271, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -298, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -317, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, -326, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, -324, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, -313, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, -296, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, -277, 689, 78, Scan);
	//		Z = GTN_ScanMark(1, -260, 678, 78, Scan);
	//		Z = GTN_ScanMark(1, -249, 658, 78, Scan);
	//		Z = GTN_ScanMark(1, -248, 634, 78, Scan);
	//		Z = GTN_ScanMark(1, -257, 608, 78, Scan);
	//		Z = GTN_ScanMark(1, -277, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -304, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -336, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -342, 564, 78, Scan);
	//		Z = GTN_ScanMark(1, -373, 570, 78, Scan);
	//		Z = GTN_ScanMark(1, -410, 585, 78, Scan);
	//		Z = GTN_ScanMark(1, -423, 601, 78, Scan);
	//		Z = GTN_ScanMark(1, -425, 620, 78, Scan);
	//		Z = GTN_ScanMark(1, -417, 639, 78, Scan);
	//		Z = GTN_ScanMark(1, -400, 652, 78, Scan);
	//		Z = GTN_ScanMark(1, -377, 656, 78, Scan);
	//		Z = GTN_ScanMark(1, -352, 649, 78, Scan);
	//		Z = GTN_ScanMark(1, -328, 632, 78, Scan);
	//		Z = GTN_ScanMark(1, -311, 606, 78, Scan);
	//		Z = GTN_ScanMark(1, -303, 575, 78, Scan);
	//		Z = GTN_ScanMark(1, -306, 542, 78, Scan);
	//		Z = GTN_ScanMark(1, -319, 513, 78, Scan);
	//		Z = GTN_ScanMark(1, -340, 491, 78, Scan);
	//		Z = GTN_ScanMark(1, -365, 480, 78, Scan);
	//		Z = GTN_ScanMark(1, -365, 473, 78, Scan);
	//		Z = GTN_ScanMark(1, -390, 472, 78, Scan);
	//		Z = GTN_ScanMark(1, -410, 481, 78, Scan);
	//		Z = GTN_ScanMark(1, -423, 497, 78, Scan);
	//		Z = GTN_ScanMark(1, -425, 516, 78, Scan);
	//		Z = GTN_ScanMark(1, -417, 534, 78, Scan);
	//		Z = GTN_ScanMark(1, -400, 547, 78, Scan);
	//		Z = GTN_ScanMark(1, -377, 551, 78, Scan);
	//		Z = GTN_ScanMark(1, -352, 544, 78, Scan);
	//		Z = GTN_ScanMark(1, -329, 527, 78, Scan);
	//		Z = GTN_ScanMark(1, -311, 502, 78, Scan);
	//		Z = GTN_ScanMark(1, -304, 471, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, 439, 78, Scan);
	//		Z = GTN_ScanMark(1, -320, 410, 78, Scan);
	//		Z = GTN_ScanMark(1, -340, 388, 78, Scan);
	//		Z = GTN_ScanMark(1, -365, 376, 78, Scan);
	//		Z = GTN_ScanMark(1, -365, 370, 78, Scan);
	//		Z = GTN_ScanMark(1, -390, 369, 78, Scan);
	//		Z = GTN_ScanMark(1, -411, 378, 78, Scan);
	//		Z = GTN_ScanMark(1, -423, 393, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, 413, 78, Scan);
	//		Z = GTN_ScanMark(1, -418, 431, 78, Scan);
	//		Z = GTN_ScanMark(1, -401, 443, 78, Scan);
	//		Z = GTN_ScanMark(1, -377, 447, 78, Scan);
	//		Z = GTN_ScanMark(1, -352, 441, 78, Scan);
	//		Z = GTN_ScanMark(1, -329, 424, 78, Scan);
	//		Z = GTN_ScanMark(1, -312, 398, 78, Scan);
	//		Z = GTN_ScanMark(1, -304, 367, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, 335, 78, Scan);
	//		Z = GTN_ScanMark(1, -320, 306, 78, Scan);
	//		Z = GTN_ScanMark(1, -341, 284, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 272, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 266, 78, Scan);
	//		Z = GTN_ScanMark(1, -390, 264, 78, Scan);
	//		Z = GTN_ScanMark(1, -411, 273, 78, Scan);
	//		Z = GTN_ScanMark(1, -423, 289, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, 309, 78, Scan);
	//		Z = GTN_ScanMark(1, -418, 327, 78, Scan);
	//		Z = GTN_ScanMark(1, -401, 340, 78, Scan);
	//		Z = GTN_ScanMark(1, -378, 344, 78, Scan);
	//		Z = GTN_ScanMark(1, -352, 337, 78, Scan);
	//		Z = GTN_ScanMark(1, -329, 320, 78, Scan);
	//		Z = GTN_ScanMark(1, -312, 294, 78, Scan);
	//		Z = GTN_ScanMark(1, -304, 263, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, 230, 78, Scan);
	//		Z = GTN_ScanMark(1, -320, 201, 78, Scan);
	//		Z = GTN_ScanMark(1, -341, 179, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 167, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 161, 78, Scan);
	//		Z = GTN_ScanMark(1, -391, 160, 78, Scan);
	//		Z = GTN_ScanMark(1, -411, 169, 78, Scan);
	//		Z = GTN_ScanMark(1, -424, 185, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, 204, 78, Scan);
	//		Z = GTN_ScanMark(1, -418, 222, 78, Scan);
	//		Z = GTN_ScanMark(1, -401, 235, 78, Scan);
	//		Z = GTN_ScanMark(1, -378, 239, 78, Scan);
	//		Z = GTN_ScanMark(1, -353, 233, 78, Scan);
	//		Z = GTN_ScanMark(1, -329, 216, 78, Scan);
	//		Z = GTN_ScanMark(1, -312, 190, 78, Scan);
	//		Z = GTN_ScanMark(1, -305, 158, 78, Scan);
	//		Z = GTN_ScanMark(1, -307, 126, 78, Scan);
	//		Z = GTN_ScanMark(1, -320, 97, 78, Scan);
	//		Z = GTN_ScanMark(1, -341, 75, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 63, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, 56, 78, Scan);
	//		Z = GTN_ScanMark(1, -391, 55, 78, Scan);
	//		Z = GTN_ScanMark(1, -411, 64, 78, Scan);
	//		Z = GTN_ScanMark(1, -424, 80, 78, Scan);
	//		Z = GTN_ScanMark(1, -426, 99, 78, Scan);
	//		Z = GTN_ScanMark(1, -419, 118, 78, Scan);
	//		Z = GTN_ScanMark(1, -402, 131, 78, Scan);
	//		Z = GTN_ScanMark(1, -378, 135, 78, Scan);
	//		Z = GTN_ScanMark(1, -353, 128, 78, Scan);
	//		Z = GTN_ScanMark(1, -330, 111, 78, Scan);
	//		Z = GTN_ScanMark(1, -313, 85, 78, Scan);
	//		Z = GTN_ScanMark(1, -305, 54, 78, Scan);
	//		Z = GTN_ScanMark(1, -308, 21, 78, Scan);
	//		Z = GTN_ScanMark(1, -321, -8, 78, Scan);
	//		Z = GTN_ScanMark(1, -342, -30, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, -42, 78, Scan);
	//		Z = GTN_ScanMark(1, -366, -48, 78, Scan);
	//		Z = GTN_ScanMark(1, -391, -49, 78, Scan);
	//		Z = GTN_ScanMark(1, -412, -41, 78, Scan);
	//		Z = GTN_ScanMark(1, -424, -24, 78, Scan);
	//		Z = GTN_ScanMark(1, -427, -5, 78, Scan);
	//		Z = GTN_ScanMark(1, -419, 13, 78, Scan);
	//		Z = GTN_ScanMark(1, -402, 26, 78, Scan);
	//		Z = GTN_ScanMark(1, -379, 30, 78, Scan);
	//		Z = GTN_ScanMark(1, -353, 24, 78, Scan);
	//		Z = GTN_ScanMark(1, -330, 6, 78, Scan);
	//		Z = GTN_ScanMark(1, -313, -19, 78, Scan);
	//		Z = GTN_ScanMark(1, -305, -51, 78, Scan);
	//		Z = GTN_ScanMark(1, -308, -83, 78, Scan);
	//		Z = GTN_ScanMark(1, -32708, -32767, 5, Scan);
	//		Z = GTN_ScanMark(1, -321, -119, 78, Scan);
	//		Z = GTN_ScanBufDA(1, 0, 16384, 1);
	//	}
	//}
	///*-----------------------------------------------------------*/
	///*ԭgts.cs����������ָ��                                      */
	///*-----------------------------------------------------------*/
	//public class mc
	//{
	//	/*-----------------------------------------------------------*/
	//	/* Channel of Command                                        */
	//	/*-----------------------------------------------------------*/
	//	public const short CHANNEL_HOST = 0;
	//	public const short CHANNEL_UART = 1;
	//	public const short CHANNEL_SIM = 2;
	//	public const short CHANNEL_ETHER = 3;
	//	public const short CHANNEL_RS232 = 4;
	//	public const short CHANNEL_PCIE = 5;
	//	public const short CHANNEL_RINGNET = 6;
	//	/*-----------------------------------------------------------*/
	//	/* Error Code                                                */
	//	/*-----------------------------------------------------------*/

	//	public const short CMD_SUCCESS = 0;

	//	public const short CMD_ERROR_READ_LEN = -2;                 /* read data length error */
	//	public const short CMD_ERROR_READ_CHECKSUM = -3;            /* checksum error */

	//	public const short CMD_ERROR_WRITE_BLOCK = -4;              /* write pci fail */
	//	public const short CMD_ERROR_READ_BLOCK = -5;               /* read pci fail */

	//	public const short CMD_ERROR_OPEN = -6;                     /* error to open device */
	//	public const short CMD_ERROR_CLOSE = -6;                    /* error to close device */
	//	public const short CMD_ERROR_DSP_BUSY = -7;                 /* DSP busy */

	//	public const short CMD_LOCK_ERROR = -8;                     /* multi-thread lock error */
	//	public const short CMD_DMA_ERROR = -9;                      /* dma transmission error */
	//	public const short CMD_COMM_ERROR = -10;                    /* pcie comm error */
	//	public const short CMD_LOAD_RINGNET_DLL_ERROR = -11;        /* load ringnet dll error */
	//	public const short CMD_RINGNET_STIME_ERROR = -12;           /* load ringnet dll error */

	//	public const short CMD_RINGNET_ENC0_ERROR = -13;            /* core1 encoder initial error */
	//	public const short CMD_RINGNET_ENC1_ERROR = -14;            /* core2 encoder initial error */

	//	public const short CMD_LOAD_RINGNET_ERROR = -17;             /* ringnet API load error */
	//	public const short CMD_MCVERSION_MATCH_ERROR = -15;          /* dll error,need to update dll */
	//	public const short CMD_LOCK_NULL = -20;                      /* multithreading open handle error */
	//	public const short CMD_MCVERSION_MATCH_WARNING = 15;         /* dll error,without some functions */
	//	public const short CMD_DSPVERSION_MATCH_WARNING = 16;        /* dsp is too old */

	//	public const short CMD_FILE_MATCH_WARNING = 17;              /* config file format or data error */

	//	public const short CMD_ERROR_EXECUTE = 1;
	//	public const short CMD_ERROR_VERSION_NOT_MATCH = 3;
	//	public const short CMD_ERROR_PARAMETER = 7;
	//	public const short CMD_ERROR_UNKNOWN = 8;                    /* unspported command */

	//	public const short MC_NONE = -1;

	//	public const short MC_LIMIT_POSITIVE = 0;
	//	public const short MC_LIMIT_NEGATIVE = 1;
	//	public const short MC_ALARM = 2;
	//	public const short MC_HOME = 3;
	//	public const short MC_GPI = 4;
	//	public const short MC_ARRIVE = 5;
	//	public const short MC_EGPI0 = 6;
	//	//      public const short MC_EGPI1 = 7;
	//	//      public const short MC_EGPI2 = 8;
	//	public const short MC_MPG = 9;

	//	public const short MC_ENABLE = 10;
	//	public const short MC_CLEAR = 11;
	//	public const short MC_GPO = 12;
	//	//      public const short MC_EGPO0 = 13;
	//	//      public const short MC_EGPO1 = 14;
	//	public const short MC_AU_ADC = 17;
	//	public const short MC_HSO = 18;
	//	public const short MC_AU_DAC = 19;

	//	public const short MC_DAC = 20;
	//	public const short MC_STEP = 21;
	//	public const short MC_PULSE = 22;
	//	public const short MC_ENCODER = 23;
	//	public const short MC_ADC = 24;

	//	public const short MC_AU_ENCODER = 26;

	//	public const short MC_ABS_ENCODER = 29;

	//	public const short MC_AXIS = 30;
	//	public const short MC_PROFILE = 31;
	//	public const short MC_CONTROL = 32;

	//	public const short MC_TRIGGER = 40;

	//	public const short MC_AU_TRIGGER = 44;

	//	public const short MC_TERMINAL = 50;
	//	public const short MC_MPG_ENCODER = 53;
	//	public const short MC_EXT_MODULE = 60;
	//	public const short MC_EXT_DI = 61;
	//	public const short MC_EXT_DO = 62;
	//	public const short MC_EXT_AI = 63;
	//	public const short MC_EXT_AO = 64;

	//	public const short MC_SCAN_CRD = 70;
	//	public const short MC_LASER = 71;
	//	public const short MC_LASER_AO = 72;

	//	public const short MC_POS_COMPARE = 80;

	//	public const short MC_WATCH_VAR = 200;
	//	public const short MC_WATCH_EVENT = 201;
	//	public struct TVersion
	//	{
	//		public short year;
	//		public short month;
	//		public short day;
	//		public short version;
	//		public short user;
	//		public short reserve1;
	//		public short reserve2;
	//		public short chip;
	//	}
	//	public const short CORE_MODE_TIMER = 0;
	//	public const short CORE_MODE_SYNCH = 1;
	//	public const short CORE_MODE_EXTERNAL = 2;

	//	public const short CORE_TASK_DEFAULT = 0;
	//	public const short CORE_TASK_DLM = 1;

	//	public const short SKIP_MODULE_SCAN = 0x001;
	//	public const short SKIP_MODULE_POS_COMPARE = 0x002;
	//	public const short SKIP_MODULE_CRD = 0x004;

	//	public const short SKIP_MODULE_PLC = 0x010;
	//	public const short SKIP_MODULE_DLM = 0x020;

	//	public const short SKIP_MODULE_AXIS_CALCULATE = 0x100;

	//	public const short SKIP_MODULE_WATCH = 0x800;

	//	public enum ETimeElapse
	//	{
	//		TIME_ELAPSE_PROFILE = 1000,

	//		TIME_ELAPSE_HOST_COMMAND_EXECUTE = 1220,
	//		TIME_ELAPSE_ETHER_COMMAND_EXECUTE,

	//		TIME_ELAPSE_PROFILE_CALCULATE = 6000,

	//		TIME_ELAPSE_SCAN = 18000,

	//		TIME_ELAPSE_AXIS_CHECK = 20000,
	//		TIME_ELAPSE_AXIS_CALCULATE,

	//		TIME_ELAPSE_ENCODER = 30000,

	//		TIME_ELAPSE_DI = 31000,

	//		TIME_ELAPSE_DO = 32000,

	//		TIME_ELAPSE_AI = 33000,

	//		TIME_ELAPSE_AO = 34000,

	//		TIME_ELAPSE_TRIGGER = 38000,

	//		TIME_ELAPSE_CONTROL = 40000,

	//		TIME_ELAPSE_WATCH = 52000,

	//		TIME_ELAPSE_TERMINAL = 53000,
	//		TIME_ELAPSE_TERMINALDET = 54000,
	//	}

	//	public struct TPid
	//	{
	//		public double kp;
	//		public double ki;
	//		public double kd;
	//		public double kvff;
	//		public double kaff;
	//		public int IntegralLimit;
	//		public int derivativeLimit;
	//		public short limit;
	//	}
	//	/*-----------------------------------------------------------*/
	//	/* Basic function                                            */
	//	/*-----------------------------------------------------------*/
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetUuid(short core, out byte pCode, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_OpenCard(short channel, string pPrm, string pFileName);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_NetInit(short mode, string pFileName, short overTime, out long pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDeviceShareMax(short core, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Open(short channel, short param);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_OpenRingNet(short channel, short param, string pFile, short index, int count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Close();
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetChannel(out short pChannel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetVersion(short core, out IntPtr pVersion);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetVersionEx(short core, short type, out TVersion pVersion);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetVersion(short core, short type, ref TVersion pVersion);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Reset(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetClock(short core, out uint pClock, out uint pLoop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetClockHighPrecision(short core, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearTime(short core, ETimeElapse item);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTime(short core, ETimeElapse item, out uint pTime, out uint pTimeMax, out uint pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCoreMode(short core, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCoreMode(short core, out short pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCoreShare(short core, short type, short index, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCoreShare(short core, short type, out short pIndex, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCoreTask(short core, short task);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCoreTask(short core, out short pTask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetResMax(short core, short type, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetResCount(short core, short type, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetResCount(short core, short type, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetSts(short core, short axis, out int pSts, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClrSts(short core, short axis, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AxisOn(short core, short axis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AxisOff(short core, short axis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MultiAxisOn(short core, uint mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MultiAxisOff(short core, uint mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisOnDelayTime(short core, ushort delayTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisOnDelayTime(short core, out ushort pDelayTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Stop(short core, int mask, int option);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPrfPos(short core, short profile, int prfPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SynchAxisPos(short core, int mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ZeroPos(short core, short axis, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLimitStatus(short core, short axis, out short pLimitPositive, out short pLimitNegative);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetSoftLimitMode(short core, short axis, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetSoftLimitMode(short core, short axis, out short pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetSoftLimit(short core, short axis, int positive, int negative);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetSoftLimit(short core, short axis, out int pPositive, out int pNegative);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetSoftLimitEx(short core, short axis, double positive, double negative);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetSoftLimitEx(short core, short axis, out double pPositive, out double pNegative);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisBand(short core, short axis, int band, int time);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisBand(short core, short axis, out int pBand, out int pTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPrfPos(short core, short profile, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPrfVel(short core, short profile, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPrfAcc(short core, short profile, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPrfMode(short core, short profile, out int pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPrfPos(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPrfPosCompensate(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPrfVel(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPrfAcc(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisEncPos(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisEncVel(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisEncAcc(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisError(short core, short axis, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetControlFilter(short core, short control, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetControlFilter(short core, short control, out short pIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetControlSuperimposed(short core, short control, short superimposedType, short superimposedIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetControlSuperimposed(short core, short control, out short pSuperimposedType, out short pSuperimposedIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPid(short core, short control, short index, ref TPid pPid);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPid(short core, short control, short index, out TPid pPid);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetKvffFilter(short core, short control, short index, short kvffFilterExp, double accMax);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetKvffFilter(short core, short control, short index, out short pKvffFilterExp, out double pAccMax);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Delay(short core, ushort ms);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DelayHighPrecision(short core, ushort profile);

	//	public const short STEP_DIR = 0;
	//	public const short STEP_PULSE = 1;
	//	public const short STEP_ORTHOGONAL = 2;

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AlarmOn(short core, short axis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AlarmOff(short core, short axis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LmtsOn(short core, short axis, short limitType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LmtsOff(short core, short axis, short limitType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StepDir(short core, short step);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StepPulse(short core, short step);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StepOrthogonal(short core, short step);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMtrBias(short core, short dac, short bias);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMtrBias(short core, short dac, out short pBias);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMtrLmt(short core, short dac, short limit);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMtrLmt(short core, short dac, out short pLimit);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetSense(short core, short dataType, short dataIndex, short value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetSense(short core, short dataType, short dataIndex, out short pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EncOn(short core, short encoder);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EncOff(short core, short encoder);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosErr(short core, short control, int error);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosErr(short core, short control, out int pError);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetStopDec(short core, short profile, double decSmoothStop, double decAbruptStop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetStopDec(short core, short profile, out double pDecSmoothStop, out double pDecAbruptStop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CtrlMode(short core, short axis, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetStopIo(short core, short axis, short stopType, short inputType, short inputIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAdcFilterPrm(short core, short adc, double k);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAdcFilterPrm(short core, short adc, out double pk);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisPrfVelFilter(short core, short axis, short filterNumExp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPrfVelFilter(short core, short axis, out short pFilterNumExp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisEncVelFilter(short core, short axis, short filterNumExp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisEncVelFilter(short core, short axis, out short pFilterNumExp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetProfileScale(short core, short i, int alpha, int beta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetProfileScale(short core, short i, out int pAlhpa, out int pBeta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetEncoderScale(short core, short i, int alpha, int beta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncoderScale(short core, short i, out int pAlhpa, out int pBeta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAuEncoderScale(short core, short i, int alpha, int beta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuEncoderScale(short core, short i, out int pAlhpa, out int pBeta);

	//	/*-----------------------------------------------------------*/
	//	/* Capture and Triggr                                        */
	//	/*-----------------------------------------------------------*/
	//	public const short CAPTURE_HOME = 1;
	//	public const short CAPTURE_INDEX = 2;
	//	public const short CAPTURE_PROBE = 3;
	//	public const short CAPTURE_HSIO0 = 6;
	//	public const short CAPTURE_HSIO1 = 7;

	//	public struct TTrigger
	//	{
	//		public short encoder;
	//		public short probeType;
	//		public short probeIndex;
	//		public short sense;
	//		public int offset;
	//		public uint loop;
	//		public short windowOnly;
	//		public int firstPosition;
	//		public int lastPosition;
	//	}
	//	public struct TTriggerEx
	//	{
	//		public short latchType;
	//		public short latchIndex;
	//		public short probeType;
	//		public short probeIndex;
	//		public short sense;
	//		public int offset;
	//		public uint loop;
	//		public short windowOnly;
	//		public int firstPosition;
	//		public int lastPosition;
	//	}
	//	public struct TTriggerAlign
	//	{
	//		public short encoder;
	//		public short probeType;
	//		public short probeIndex;
	//		public short sense;
	//		public int offset;
	//		public uint loop;
	//		public short windowOnly;
	//		public short pad2;
	//		public int firstPosition;
	//		public int lastPosition;
	//	}

	//	public struct TTriggerStatus
	//	{
	//		public short execute;
	//		public short done;
	//		public int position;
	//	}

	//	public struct TTriggerStatusEx
	//	{
	//		public short execute;
	//		public short done;
	//		public int position;
	//		public uint clock;
	//		public uint loopCount;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAuTrigger(short core, short i, ref TTriggerEx pTrigger);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuTrigger(short core, short i, out TTriggerEx pTrigger);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearAuTriggerStatus(short core, short i);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuTriggerStatus(short core, short i, out TTriggerStatusEx pTriggerStatusEx, short count);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTrigger(short core, short i, ref TTrigger pTrigger);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTrigger(short core, short i, out TTrigger pTrigger);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTriggerEx(short core, short i, ref TTriggerEx pTrigger);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerEx(short core, short i, out TTriggerEx pTrigger);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerStatus(short core, short i, out TTriggerStatus pTriggerStatus, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerStatusEx(short core, short i, out TTriggerStatusEx pTriggerStatusEx, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearTriggerStatus(short core, short i);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DisableTrigger(short core, short i);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCaptureMode(short core, short encoder, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCaptureMode(short core, short encoder, out short pMode, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCaptureStatus(short core, short encoder, out short pStatus, out int pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCaptureSense(short core, short encoder, short mode, short sense);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearCaptureStatus(short core, short encoder);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCaptureRepeat(short core, short encoder, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCaptureRepeatStatus(short core, short encoder, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCaptureRepeatPos(short core, short encoder, out int pValue, short startNum, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCaptureRepeatFifoMode(short core, short encoder, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCaptureRepeatFifoMode(short core, short encoder, out short pMode);


	//	public struct TLatchValueInfo
	//	{
	//		public short fifoFull;
	//		public short pad1_1;
	//		public short pad1_2;
	//		public short pad1_3;
	//		public double pad2_1;
	//		public double pad2_2;
	//	};

	//	public struct TTriggerPrm
	//	{
	//		public short latchType;
	//		public short latchIndex;
	//		public short probeType;
	//		public short probeIndex;
	//		public short sense;
	//		public short loopType;
	//		public int offset;
	//		public uint loop;
	//		public short windowOnly;
	//		public short pad1;
	//		public int firstPosition;
	//		public int lastPosition;
	//		public short fifoMode;
	//		public short pad2_1;
	//		public short pad2_2;
	//		public short pad2_3;
	//		public double pad3;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTriggerPrm(short core, short i, ref TTriggerPrm pTriggerPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerPrm(short core, short i, out TTriggerPrm pTriggerPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerLatchValue(short core, short i, int count, out int pValue, out int pCount, ref TLatchValueInfo pInfo);

	//	public const short TRIGGER_DELTA_MODE_DEFAULT = 0;
	//	public const short TRIGGER_DELTA_CHECKPOINT_MODE_AUTO = 0;
	//	public const short TRIGGER_DELTA_CHECKPOINT_MODE_MANUAL = 1;
	//	public struct TCheckpoint
	//	{
	//		public short mode;
	//		public int offset;
	//		public short fifoIndex;
	//		public uint crossCount;
	//		public short fifoDataCount;
	//		public short dataReady;
	//		public int data;
	//		public short dataIndex;
	//	}
	//	public struct TTriggerDeltaPrm
	//	{
	//		public short mode;
	//		public short dir;
	//		public short triggerIndex0;
	//		public short triggerIndex1;
	//	}

	//	public struct TTriggerDeltaInfo
	//	{
	//		public short enable;
	//		public short checkpointCount;
	//		public short fifoDataCount;
	//		public short lostCount;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearTriggerDelta(short core, short index, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AddTriggerDeltaCheckpoint(short core, short index, short mode, int offset, short fifo, ref short pIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadTriggerDeltaCheckpointData(short core, short index, short checkpointIndex, out int pBuf, short count, out short pReadCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteTriggerDeltaCheckpointData(short core, short index, short checkpointIndex, ref int pBuf, short count, ref short pWriteCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTriggerDeltaPrm(short core, short index, ref TTriggerDeltaPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerDeltaPrm(short core, short index, out TTriggerDeltaPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerDeltaCheckpoint(short core, short index, short checkpointIndex, out TCheckpoint pCheckpoint);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerDeltaInfo(short core, short index, out TTriggerDeltaInfo pTriggerDelta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_TriggerDeltaOn(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_TriggerDeltaOff(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LinkCaptureOffset(short core, short encoder, short source);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCaptureOffset(short core, short encoder, ref int pOffset, short count, int loop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCaptureOffset(short core, short encoder, out int pOffset, out short pCount, out int pLoop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCaptureOffsetStatus(short core, short encoder, out short pCount, out int pLoop, out int pCapturePos);

	//	/*-----------------------------------------------------------*/
	//	/* Basic Motion                                              */
	//	/*-----------------------------------------------------------*/

	//	public struct TTrapPrm
	//	{
	//		public double acc;
	//		public double dec;
	//		public double velStart;
	//		public short smoothTime;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Update(short core, int mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPos(short core, short profile, int pos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPos(short core, short profile, out int pPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetVel(short core, short profile, double vel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetVel(short core, short profile, out double pVel);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_PrfTrap(short core, short profile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTrapPrm(short core, short profile, ref TTrapPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTrapPrm(short core, short profile, out TTrapPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTrapSts(short core, short profile, out short prfsts);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearTrapSts(short core, short profile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosEx(short core, short profile, double pos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosEx(short core, short profile, out double pos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetEncPosEx(short core, short encoder, double pos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncPosEx(short core, short encoder, out double pos);


	//	public struct TJogPrm
	//	{
	//		public double acc;
	//		public double dec;
	//		public double smooth;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrfJog(short core, short profile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetJogPrm(short core, short profile, ref TJogPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetJogPrm(short core, short profile, out TJogPrm pPrm);

	//	public const short PT_MODE_STATIC = 0;
	//	public const short PT_MODE_DYNAMIC = 1;

	//	public const short PT_SEGMENT_NORMAL = 0;
	//	public const short PT_SEGMENT_EVEN = 1;
	//	public const short PT_SEGMENT_STOP = 2;

	//	public struct TPtInfo
	//	{
	//		public double prfPos;
	//		public int loop;
	//		public short mode;
	//		public short fifoUse;
	//		public short fifoPlace;
	//		public short segmentNumber;
	//		public uint segmentReceive1;
	//		public uint segmentReceive2;
	//		public uint segmentExecute1;
	//		public uint segmentExecute2;
	//		public uint bufferReceive1;
	//		public uint bufferReceive2;
	//		public uint bufferExecute1;
	//		public uint bufferExecute2;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrfPt(short core, short profile, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPtLoop(short core, short profile, int loop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPtLoop(short core, short profile, out int pLoop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PtSpace(short core, short profile, out short pSpace, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PtSpaceEx(short core, short profile, out short pSpace, out short pListSpace, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PtData(short core, short profile, double pos, int time, short type, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PtClear(short core, short profile, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PtStart(short core, int mask, int option);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPtMemory(short core, short profile, short memory);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPtMemory(short core, short profile, out short pMemory);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPtPrecisionMode(short core, short profile, short precisionMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPtPrecisionMode(short core, short profile, out short pPrecisionMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPtInfo(short core, short profile, out TPtInfo pPtInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPtLink(short core, short profile, short fifo, short list);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPtLink(short core, short profile, short fifo, out short pList);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PtDoBit(short core, short profile, short doType, short index, short value, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PtAo(short core, short profile, short aoType, short index, double value, short fifo);



	//	public struct TPvtTableMovePrm
	//	{
	//		public short tableId;
	//		public int distance;
	//		public double vm;
	//		public double am;
	//		public double jm;
	//		public double time;
	//	}

	//	public struct TPvtLinePrm
	//	{
	//		public short mode;  //������Чģʽ
	//		public short smoothTimer;  //ƽ��ʱ��
	//		public long moveTime;  //�˶�ʱ��
	//		public long pad;       //����λ
	//		public double synVel;   //�ϳ�Ŀ���ٶ�
	//		public double synAcc;  //�ϳɼ��ٶ�
	//		public double synJeck; //�ϳɼӼ��ٶ�
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtLine(short core, short axisCount, ref short moveAxis, ref long pos, ref TPvtLinePrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrfPvt(short core, short profile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPvtLoop(short core, short profile, int loop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPvtLoop(short core, short profile, out int pLoopCount, out int pLoop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtStatus(short core, short profile, out short pTableId, out double pTime, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtStart(short core, int mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableSelect(short core, short profile, short tableId);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_PvtTable(short core, short tableId, int count, ref double pTime, ref double pPos, ref double pVel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableEx(short core, short tableId, int count, ref double pTime, ref double pPos, ref double pVelBegin, ref double pVelEnd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableComplete(short core, short tableId, int count, ref double pTime, ref double pPos, ref double pA, ref double pB, ref double pC, double velBegin, double velEnd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTablePercent(short core, short tableId, int count, ref double pTime, ref double pPos, ref double pPercent, double velBegin);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtPercentCalculate(short core, int n, ref double pTime, ref double pPos, ref double pPercent, double velBegin, ref double pVel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableContinuous(short core, short tableId, int count, ref double pPos, ref double pVel, ref double pPercent, ref double pVelMax, ref double pAcc, ref double pDec, double timeBegin);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtContinuousCalculate(short core, int n, ref double pPos, ref double pVel, ref double pPercent, ref double pVelMax, ref double pAcc, ref double pDec, ref double pTime);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableMove(short core, short tableId, int distance, double vm, double am, double jm, ref double pTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableMove2(short core, short tableId, int distance, double vm, double am, double jm, ref double pTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableMovePercent(short core, short tableId, int distance, double vm,
	//	double acc, double pa1, double pa2,
	//	double dec, double pd1, double pd2,
	//	ref double pVel, ref double pAcc, ref double pDec, ref double pTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableMovePercentEx(short core, short tableId, int distance, double vm,
	//	double acc, double pa1, double pa2, double ma,
	//	double dec, double pd1, double pd2, double md,
	//	ref double pVel, ref double pAcc, ref double pDec, ref double pTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableMoveTogether(short core, short tableCount, ref TPvtTableMovePrm pPvtTableMovePrm);
	//	public const short GEAR_MASTER_ENCODER = 1;
	//	public const short GEAR_MASTER_PROFILE = 2;
	//	public const short GEAR_MASTER_AXIS = 3;
	//	public const short GEAR_MASTER_AU_ENCODER = 4;
	//	public const short GEAR_MASTER_MPG_ENCODER = 5;
	//	public const short GEAR_MASTER_ENCODER_OTHER = 101;
	//	public const short GEAR_MASTER_AXIS_OTHER = 103;
	//	public const short GEAR_MASTER_AU_ENCODER_OTHER = 104;
	//	public const short GEAR_MASTER_MPG_ENCODER_OTHER = 105;
	//	public const short GEAR_EVENT_START = 1;
	//	public const short GEAR_EVENT_PASS = 2;
	//	public const short GEAR_EVENT_AREA = 5;

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrfGear(short core, short profile, short dir);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGearMaster(short core, short profile, short masterIndex, short masterType, short masterItem);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGearMaster(short core, short profile, out short pMasterIndex, out short pMasterType, out short pMasterItem);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGearRatio(short core, short profile, int masterEven, int slaveEven, int masterSlope);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGearRatio(short core, short profile, out int pMasterEven, out int pSlaveEven, out int pMasterSlope);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GearStart(short core, int mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGearEvent(short core, short profile, short gearevent, int startPara0, int startPara1);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGearEvent(short core, short profile, out short pEvent, out int pStartPara0, out int pStartPara1);

	//	public const short FOLLOW_SWITCH_SEGMENT = 1;
	//	public const short FOLLOW_SWITCH_TABLE = 2;

	//	public const short FOLLOW_MASTER_ENCODER = 1;
	//	public const short FOLLOW_MASTER_PROFILE = 2;
	//	public const short FOLLOW_MASTER_AXIS = 3;
	//	public const short FOLLOW_MASTER_AU_ENCODER = 4;

	//	public const short FOLLOW_MASTER_ENCODER_OTHER = 101;
	//	public const short FOLLOW_MASTER_AXIS_OTHER = 103;

	//	public const short FOLLOW_EVENT_START = 1;
	//	public const short FOLLOW_EVENT_PASS = 2;

	//	public const short FOLLOW_SEGMENT_NORMAL = 0;
	//	public const short FOLLOW_SEGMENT_EVEN = 1;
	//	public const short FOLLOW_SEGMENT_STOP = 2;
	//	public const short FOLLOW_SEGMENT_CONTINUE = 3;
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrfFollow(short core, short profile, short dir);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowMaster(short core, short profile, short masterIndex, short masterType, short masterItem);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowMaster(short core, short profile, out short pMasterIndex, out short pMasterType, out short pMasterItem);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowLoop(short core, short profile, int loop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowLoop(short core, short profile, out int pLoop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowEvent(short core, short profile, short followevent, short masterDir, int pos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowEvent(short core, short profile, out short pEvent, out short pMasterDir, out int pPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowSpace(short core, short profile, out short pSpace, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowData(short core, short profile, int masterSegment, double slaveSegment, short type, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowClear(short core, short profile, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowStart(short core, int mask, int option);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowSwitch(short core, int mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowMemory(short core, short profile, short memory);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowMemory(short core, short profile, out short pMemory);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowStatus(short core, short profile, out short pFifoNum, out short pSwitchStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowPhasing(short core, short profile, short profilePhasing);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowPhasing(short core, short profile, out short pProfilePhasing);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_PrfFollowEx(short core, short profile, short dir);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowMasterEx(short core, short profile, short masterIndex, short masterType, short masterItem);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowMasterEx(short core, short profile, out short pMasterIndex, out short pMasterType, out short pMasterItem);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowLoopEx(short core, short profile, int loop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowLoopEx(short core, short profile, out int pLoop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowEventEx(short core, short profile, short followevent, short masterDir, int pos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowEventEx(short core, short profile, out short pEvent, out short pMasterDir, out int pPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowSpaceEx(short core, short profile, out short pSpace, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowDataPercentEx(short core, short profile, double masterSegment, double slaveSegment, short type, short percent, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowClearEx(short core, short profile, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowStartEx(short core, int mask, int option);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowSwitchEx(short core, int mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowMemoryEx(short core, short profile, short memory);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowMemoryEx(short core, short profile, out short pMemory);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowStatusEx(short core, short profile, out short pFifoNum, out short pSwitchStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowPhasingEx(short core, short profile, short profilePhasing);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowPhasingEx(short core, short profile, out short pProfilePhasing);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowSwitchNowEx(short core, short profile, short method, short buffer, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowDataPercent2Ex(short core, short profile, double masterSegment, double slaveSegment, double velBeginRatio, double velEndRatio, short percent, out short pPercent1, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFollowDataPercent2Ex(short core, double masterPos, double v1, double v2, double p, double p1, out double pSlavePos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowDoBitEx(short core, short profile, short doType, short index, short value, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowDelayEx(short core, short profile, uint delayTime, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FollowDiBitEx(short core, short profile, short diType, short index, short value, uint time, short fifo);

	//	public struct TMoveAbsolutePrm
	//	{
	//		public int pos;
	//		public double vel;
	//		public double acc;
	//		public double dec;
	//		public short percent;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveAbsolute(short core, short profile, ref TMoveAbsolutePrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMoveAbsolute(short core, short profile, out TMoveAbsolutePrm pPrm);

	//	public struct TTransformOrthogonal
	//	{
	//		public short source;
	//		public short enable;
	//		public short x;
	//		public short y;
	//		public double theta;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTransformOrthogonal(short core, short index, ref TTransformOrthogonal pOrthogonal);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTransformOrthogonal(short core, short index, out TTransformOrthogonal pOrthogonal);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTransformOrthogonalPosition(short core, short index, out double pPositionX, out double pPositionY);

	//	/*-----------------------------------------------------------*/
	//	/* Comp                                                      */
	//	/*-----------------------------------------------------------*/
	//	public struct TCoordTransformPrm
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] translateion;                         //��������ϵ���ԭʼ����ϵ��ƽ��
	//		public double theta;                                  //��������ϵ���ԭʼ����ϵ����ת
	//	}

	//	public struct TCoordSyncCompPrm
	//	{
	//		public short enable;                                  //�Ƿ�ʹ������ϵת������
	//		public short refType;                                 //�ο����ͣ���������ΪMC_CRD��MC_GROUP��MC_PROFILE��
	//		public short index;                                   //����ο�����ΪMC_CRD��д������ϵ��
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] refIndex;                               //�ο���ţ�ָ������ϵ�е�ĳ�����ᣬ����profile��������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] offset;                                //������X2��Y2�����Բο�����ϵX1��Y1����ƫ��
	//		public TCoordTransformPrm refTrans;                    //�ο���������ϵ���ԭ����ϵ��ƽ�ƺ���ת
	//		public TCoordTransformPrm syncTrans;                   //ͬ����������ϵ���ԭ����ϵ��ƽ�ƺ���ת
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve2;
	//	}

	//	public struct TPrfComp
	//	{
	//		public short type;                      //�������ͣ�����ͬ��������
	//		public short index;                     //һ������������ͬ������֧�����������������ϵ����������ʾ�ڼ���ͬ������
	//		public short subIndex;                  //���������������һ��ͬ�������ĵ�һ����
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve2;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrfComp(short core, short profile, ref TPrfComp pComp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrfCompEnable(short core, short profile, short enable, short enableType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPrfCompEnable(short core, short crd, short fifo, short profile, short enable, short enableType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCoordSyncCompPrm(short core, short index, ref TCoordSyncCompPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCoordSyncCompPrm(short core, short index, out TCoordSyncCompPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCoordSyncCompValue(short core, short index, double x, double y, out double pCompX, out double pCompY);

	//	/*-----------------------------------------------------------*/
	//	/* Home                                                      */
	//	/*-----------------------------------------------------------*/
	//	public const short HOME_STAGE_IDLE = 0;
	//	public const short HOME_STAGE_START = 1;

	//	public const short HOME_STAGE_SEARCH_LIMIT = 10;
	//	public const short HOME_STAGE_SEARCH_LIMIT_STOP = 11;

	//	public const short HOME_STAGE_SEARCH_LIMIT_ESCAPE = 13;

	//	public const short HOME_STAGE_SEARCH_LIMIT_RETURN = 15;
	//	public const short HOME_STAGE_SEARCH_LIMIT_RETURN_STOP = 16;

	//	public const short HOME_STAGE_SEARCH_HOME = 20;

	//	public const short HOME_STAGE_SEARCH_HOME_RETURN = 25;

	//	public const short HOME_STAGE_SEARCH_INDEX = 30;

	//	public const short HOME_STAGE_SEARCH_GPI = 40;

	//	public const short HOME_STAGE_SEARCH_GPI_RETURN = 45;

	//	public const short HOME_STAGE_GO_HOME = 80;

	//	public const short HOME_STAGE_END = 100;

	//	public const short HOME_ERROR_NONE = 0;
	//	public const short HOME_ERROR_NOT_TRAP_MODE = 1;
	//	public const short HOME_ERROR_DISABLE = 2;
	//	public const short HOME_ERROR_ALARM = 3;
	//	public const short HOME_ERROR_STOP = 4;
	//	public const short HOME_ERROR_STAGE = 5;
	//	public const short HOME_ERROR_HOME_MODE = 6;
	//	public const short HOME_ERROR_SET_CAPTURE_HOME = 7;
	//	public const short HOME_ERROR_NO_HOME = 8;
	//	public const short HOME_ERROR_SET_CAPTURE_INDEX = 9;
	//	public const short HOME_ERROR_NO_INDEX = 10;

	//	public const short HOME_MODE_LIMIT = 10;
	//	public const short HOME_MODE_LIMIT_HOME = 11;
	//	public const short HOME_MODE_LIMIT_INDEX = 12;
	//	public const short HOME_MODE_LIMIT_HOME_INDEX = 13;

	//	public const short HOME_MODE_HOME = 20;

	//	public const short HOME_MODE_HOME_INDEX = 22;

	//	public const short HOME_MODE_INDEX = 30;

	//	public struct THomePrm
	//	{
	//		public short mode;                      // ����ģʽ
	//		public short moveDir;                   // �����������ʱ���˶�����
	//		public short indexDir;                  // ����Index��������
	//		public short edge;                      // ���ò�����
	//		public short triggerIndex;              // �������ô�����
	//		public short pad10;                     // ����1
	//		public short pad11;                     // ����1
	//		public short pad12;                     // ����1
	//		public double velHigh;                  // Home�����ٶ�
	//		public double velLow;                   // Index�����ٶ�
	//		public double acc;
	//		public double dec;
	//		public short smoothTime;
	//		public short pad20;                     // ����2
	//		public short pad21;                     // ����2
	//		public short pad22;                     // ����2
	//		public int homeOffset;                // ԭ��ƫ��
	//		public int searchHomeDistance;        // Home����������룬Ϊ0��ʾ������
	//		public int searchIndexDistance;       // Index����������룬Ϊ0��ʾ������
	//		public int escapeStep;                // ���벽��
	//		public int pad31;                       // ����3
	//		public int pad32;                       // ����3
	//	}

	//	public struct THomePrmPro
	//	{
	//		public short mode;                      // 回零模式
	//		public short moveDir;                   // 启动时搜索方向
	//		public short indexDir;                  // index搜索方向
	//		public short edge;                      // 设置捕获沿，1,0
	//		public short triggerIndex;              // 设置触发器
	//		public short pad10;                     // 保留
	//		public short pad11;                     // 
	//		public short pad12;                     // 
	//		public double velHigh;                  // Home搜索速度
	//		public double velLow;                   // index搜索速度
	//		public double acc;                      //回零加速度
	//		public double dec;                      //回零减速度
	//		public short smoothTime;                //平滑时间
	//		public short pad20;                     // ����2
	//		public short pad21;                     // ����2
	//		public short pad22;                     // ����2
	//		public double homeOffset;                // 原点偏移
	//		public double searchHomeDistance;        // Home最大搜索距离，0表示不限制搜索位置
	//		public double searchIndexDistance;       // Index最大搜索距离
	//		public double escapeStep;                // 如果在限位的话，反向脱离步长
	//		public int pad31;                       // ����3
	//		public int pad32;                       // ����3
	//	}

	//	public struct THomeStatus
	//	{
	//		public short run;
	//		public short stage;
	//		public short error;
	//		public short pad1;
	//		public int capturePos;
	//		public int targetPos;
	//	}

	//	public struct THomeStatusPro
	//	{
	//		public short run;       //0-停止运动。1-正在回原点
	//		public short stage;     //回原点阶段
	//		public short error;     //回零过程中发生的错误
	//		public short pad1;
	//		public double capturePos;//捕获到home或者index时的编码器位置
	//		public double targetPos; //需要运动到的目标位置，原点位置+偏移量
	//	}



	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GoHome(short core, short axis, ref THomePrm pHomePrm);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GoHomePro(short core, short axis, ref THomePrmPro pHomePrmPro);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetHomePrm(short core, short axis, out THomePrm pHomePrm);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetHomePrmPro(short core, short axis, out THomePrmPro pHomePrm);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetHomeStatusPro(short core, short axis, out THomeStatusPro pHomeStatus);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetHomeStatus(short core, short axis, out THomeStatus pHomeStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HandwheelInit(short core, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetHandwheelStopDec(short core, short slave, double decSmoothStop, double decAbruptStop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StartHandwheel(short core, short slave, short master, short masterEven, short slaveEven, short intervalTime, double acc, double dec, double vel, short stopWaitTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EndHandwheel(short core, short slave);

	//	/*-----------------------------------------------------------*/
	//	/* PLC                                                       */
	//	/*-----------------------------------------------------------*/
	//	public const short PLC_THREAD_MAX = 32;
	//	public const short PLC_PAGE_MAX = 32;
	//	public const short PLC_LOCAL_VAR_MAX = 1024;
	//	public const short PLC_ACCESS_VAR_COUNT_MAX = 8;

	//	public const short PLC_TIMER_TT = 0;
	//	public const short PLC_TIMER_TF = 1;
	//	public const short PLC_TIMER_TTF = 2;

	//	public const short PLC_COUNTER_EQ = 0;
	//	public const short PLC_COUNTER_LE = 1;
	//	public const short PLC_COUNTER_GE = 2;

	//	public const short PLC_COUNTER_EDGE_UP = 0;
	//	public const short PLC_COUNTER_EDGE_DOWN = 1;
	//	public const short PLC_COUNTER_EDGE_UP_DOWN = 2;

	//	public const short PLC_FLANK_UP = 0;
	//	public const short PLC_FLANK_DOWN = 1;
	//	public const short PLC_FLANK_UP_DOWN = 2;

	//	public enum EPlcBind
	//	{
	//		PLC_BIND_NONE,
	//		PLC_BIND_DI,
	//		PLC_BIND_DO,
	//		PLC_BIND_TIMER,
	//		PLC_BIND_COUNTER,
	//		PLC_BIND_FLANK,
	//		PLC_BIND_SRFF,
	//	}

	//	public struct TVarInfo
	//	{
	//		public short id;
	//		public short dataType;
	//		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	//		public string name;
	//	}

	//	public struct TBindDi
	//	{
	//		public short diType;
	//		public short index;
	//		public short reverse;
	//	}

	//	public struct TBindDo
	//	{
	//		public short doType;
	//		public short index;
	//		public short reverse;
	//	}

	//	public struct TBindTimer
	//	{
	//		public short timerType;
	//		public int delay;
	//		public short inputVarId;
	//	}

	//	public struct TBindCounter
	//	{
	//		public short counterType;
	//		public short edge;
	//		public int init;
	//		public int target;
	//		public int begin;
	//		public int end;
	//		public short dir;
	//		public int unit;
	//		public short inputVarId;
	//		public short resetVarId;
	//	}

	//	public struct TBindFlank
	//	{
	//		public short flankType;
	//		public short inputVarId;
	//	}

	//	public struct TBindSrff
	//	{
	//		public short setVarId;
	//		public short resetVarId;
	//	}

	//	public struct TCompileInfo
	//	{
	//		public string pFileName;
	//		public short pLineNo;
	//		public string pMessage;
	//	}

	//	public struct TThreadSts
	//	{
	//		public short run;
	//		public short error;
	//		public double result;
	//		public short line;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Compile(string pFileName, ref TCompileInfo pWrongInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Download(short core, string pFileName);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFunId(string pFunName, out short pFunId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetVarId(string pFunName, string pVarName, out TVarInfo pVarInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Bind(short core, short thread, short funId, short page);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RunThread(short core, short thread);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RunThreadPeriod(short core, short thread, short ms, short priority);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StopThread(short core, short thread);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PauseThread(short core, short thread);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetThreadSts(short core, short thread, out TThreadSts pThreadSts);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetThreadTime(short core, short thread, out short pPeriod, out double pExecuteTime, out double pExecuteTimeMax);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetVarValue(short core, short page, ref TVarInfo pVarInfo, ref double pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetVarValue(short core, short page, ref TVarInfo pVarInfo, out double pValue, short count);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_UnbindVar(short core, short thread);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BindDi(short core, short thread, ref TVarInfo pVarInfo, ref TBindDi pBindDi);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BindDo(short core, short thread, ref TVarInfo pVarInfo, ref TBindDo pBindDo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BindTimer(short core, short thread, ref TVarInfo pVarInfo, ref TBindTimer pBindTimer);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BindCounter(short core, short thread, ref TVarInfo pVarInfo, ref TBindCounter pBindCounter);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BindFlank(short core, short thread, ref TVarInfo pVarInfo, ref TBindFlank pBindFlank);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BindSrff(short core, short thread, ref TVarInfo pVarInfo, ref TBindSrff pBindSrff);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_GetBindDi(short core, out TVarInfo pVarInfo, out TBindDi pBindDi);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindDo(short core, out TVarInfo pVarInfo, out TBindDo pBindDo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindTimer(short core, out TVarInfo pVarInfo, out TBindTimer pBindTimer, out int pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindCounter(short core, out TVarInfo pVarInfo, out TBindCounter pBindCounter, out int pUnitCount, out int pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindFlank(short core, out TVarInfo pVarInfo, out TBindFlank pBindFlank);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindSrff(short core, out TVarInfo pVarInfo, out TBindSrff pBindSrff);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_GetBindDiCount(short core, short thread, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindDoCount(short core, short thread, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindTimerCount(short core, short thread, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindCounterCount(short core, short thread, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindFlankCount(short core, short thread, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindSrffCount(short core, short thread, out short pCount);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_GetBindDiInfo(short core, short thread, short index, out short pVar, out TBindDi pBindDi);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindDoInfo(short core, short thread, short index, out short pVar, out TBindDo pBindDo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindTimerInfo(short core, short thread, short index, out short pVar, out TBindTimer pBindTimer);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindCounterInfo(short core, short thread, short index, out short pVar, out TBindCounter pBindCounter);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindFlankInfo(short core, short thread, short index, out short pVar, out TBindFlank pBindFlank);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBindSrffInfo(short core, short thread, short index, out short pVar, out TBindSrff pBindSrff);

	//	public struct TThreadStatus
	//	{
	//		public short link;
	//		public uint address;
	//		public short size;
	//		public uint page;
	//		public short delay;
	//		public short priority;
	//		public short ptr;
	//		public short status;
	//		public short error;
	//		public short result1;
	//		public short result2;
	//		public short result3;
	//		public short result4;
	//		public short resultType;
	//		public short breakpoint;
	//		public short period;
	//		public short count;
	//		public short function;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StepThread(short core, short thread);
	//	/*-----------------------------------------------------------*/
	//	/* Interpolation                                             */
	//	/*-----------------------------------------------------------*/

	//	public const short INTERPOLATION_AXIS_MAX = 8;

	//	public const short CRD_OPERATION_DATA_EXT_MAX = 2;


	//	public const short CRD_BUFFER_MODE_DYNAMIC_DEFAULT = 0;
	//	public const short CRD_BUFFER_MODE_DYNAMIC_KEEP = 1;
	//	public const short CRD_BUFFER_MODE_STATIC_INPUT = 11;
	//	public const short CRD_BUFFER_MODE_STATIC_READY = 12;
	//	public const short CRD_BUFFER_MODE_STATIC_START = 1;

	//	public const short INTERPOLATION_CIRCLE_PLAT_XY = 0;
	//	public const short INTERPOLATION_CIRCLE_PLAT_YZ = 1;
	//	public const short INTERPOLATION_CIRCLE_PLAT_ZX = 2;

	//	public const short INTERPOLATION_HELIX_CIRCLE_XY_LINE_Z = 0;
	//	public const short INTERPOLATION_HELIX_CIRCLE_YZ_LINE_X = 1;
	//	public const short INTERPOLATION_HELIX_CIRCLE_ZX_LINE_Y = 2;
	//	public const short INTERPOLATION_CIRCLE_DIR_CW = 0;
	//	public const short INTERPOLATION_CIRCLE_DIR_CCW = 1;

	//	public struct TCrdPrm
	//	{
	//		public short dimension;                              // ����ϵά��
	//		public short profile1;                               // ����profile��������
	//		public short profile2;                               // ����profile��������
	//		public short profile3;                               // ����profile��������
	//		public short profile4;                               // ����profile��������
	//		public short profile5;                               // ����profile��������
	//		public short profile6;                               // ����profile��������
	//		public short profile7;                               // ����profile��������
	//		public short profile8;                               // ����profile��������
	//		public double synVelMax;                             // ���ϳ��ٶ�
	//		public double synAccMax;                             // ���ϳɼ��ٶ�
	//		public short evenTime;                               // ��С����ʱ��
	//		public short setOriginFlag;                          // ����ԭ������ֵ��־,0:Ĭ�ϵ�ǰ�滮λ��Ϊԭ��λ��;1:�û�ָ��ԭ��λ��
	//		public int originPos1;                             // �û�ָ����ԭ��λ��
	//		public int originPos2;                             // �û�ָ����ԭ��λ��
	//		public int originPos3;                             // �û�ָ����ԭ��λ��
	//		public int originPos4;                             // �û�ָ����ԭ��λ��
	//		public int originPos5;                             // �û�ָ����ԭ��λ��
	//		public int originPos6;                             // �û�ָ����ԭ��λ��
	//		public int originPos7;                             // �û�ָ����ԭ��λ��
	//		public int originPos8;                             // �û�ָ����ԭ��λ��
	//	}

	//	public struct TCrdBufOperation
	//	{
	//		public short flag;                                   // ��־�ò岹���Ƿ���IO����ʱ
	//		public ushort delay;                                 // ��ʱʱ��
	//		public short doType;                                 // ������IO������,0:�����IO
	//		public ushort doMask;                                // ������IO�������������
	//		public ushort doValue;                               // ������IO�����ֵ
	//		public ushort dataExt1;                              // ����������չ����
	//		public ushort dataExt2;                              // ����������չ����
	//	}

	//	public struct TCrdData
	//	{
	//		public short motionType;                             // �˶�����,0:ֱ�߲岹,1:Բ���岹
	//		public short circlePlat;                             // Բ���岹��ƽ��
	//		public int pos1;                                   // ��ǰ�θ����յ�λ��
	//		public int pos2;                                   // ��ǰ�θ����յ�λ��
	//		public int pos3;                                   // ��ǰ�θ����յ�λ��
	//		public int pos4;                                   // ��ǰ�θ����յ�λ��
	//		public int pos5;                                   // ��ǰ�θ����յ�λ��
	//		public int pos6;                                   // ��ǰ�θ����յ�λ��
	//		public int pos7;                                   // ��ǰ�θ����յ�λ��
	//		public int pos8;                                   // ��ǰ�θ����յ�λ��
	//		public double radius;                                // Բ���岹�İ뾶
	//		public short circleDir;                              // Բ����ת����,0:˳ʱ��;1:��ʱ��
	//		public double center1;                               // Բ���岹��Բ������
	//		public double center2;                               // Բ���岹��Բ������
	//		public double center3;                               // Բ���岹��Բ������
	//		public double vel;                                   // ��ǰ�κϳ�Ŀ���ٶ�
	//		public double acc;                                   // ��ǰ�κϳɼ��ٶ�
	//		public short velEndZero;                             // ��־��ǰ�ε��յ��ٶ��Ƿ�ǿ��Ϊ0,0:��ǿ��Ϊ0;1:ǿ��Ϊ0
	//		public TCrdBufOperation operation;                   // ��������ʱ��IO�ṹ��

	//		public double cos1;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double cos2;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double cos3;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double cos4;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double cos5;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double cos6;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double cos7;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double cos8;                                  // ��ǰ�θ����Ӧ������ֵ
	//		public double velEnd;                                // ��ǰ�κϳ��յ��ٶ�
	//		public double velEndAdjust;                          // �����յ��ٶ�ʱ�õ��ı���(ǰհģ��)
	//		public double r;                                     // ��ǰ�κϳ�λ����
	//	}

	//	public struct TCrdTime
	//	{
	//		public double time;
	//		public int segmentUsed;
	//		public int segmentHead;
	//		public int segmentTail;
	//	}

	//	public struct TBufFollowMaster
	//	{
	//		public short crdAxis;
	//		public short masterIndex;
	//		public short masterType;
	//	}

	//	public struct TBufFollowEventCross
	//	{
	//		public int masterPos;
	//		public int pad;
	//	}

	//	public struct TBufFollowEventTrigger
	//	{
	//		public short triggerIndex;
	//		public int triggerOffset;
	//		public int pad;
	//	}

	//	public struct TCrdFollowPrm
	//	{
	//		public double velRatioMax;
	//		public double accRatioMax;
	//		public int masterLead;
	//		public int masterEven;
	//		public int slaveEven;
	//		public short dir;
	//		public short smoothPercent;
	//		public short synchAlign;
	//	}

	//	public struct TCrdFollowStatus
	//	{
	//		public short stage;
	//		public double slavePos;
	//		public double slaveVel;
	//		public int masterFrameWidth;
	//		public int masterFrameIndex;
	//		public uint loopCount;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdPrm(short core, short crd, ref TCrdPrm pCrdPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdPrm(short core, short crd, out TCrdPrm pCrdPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdSpace(short core, short crd, out int pSpace, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdData(short core, short crd, IntPtr pCrdData, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Bezier(short core, short crd, ref TBezierPrm pBezier, double synVel, double synAcc, double velEnd, long segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXY(short core, short crd, int x, int y, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYOverride2(short core, short crd, int x, int y, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYWN(short core, short crd, int x, int y, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYOverride2WN(short core, short crd, int x, int y, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_LnXYG0(short core, short crd, int x, int y, double synVel, double synAcc, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYG0Override2(short core, short crd, int x, int y, double synVel, double synAcc, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYG0WN(short core, short crd, int x, int y, double synVel, double synAcc, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYG0Override2WN(short core, short crd, int x, int y, double synVel, double synAcc, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_LnXYZ(short core, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZOverride2(short core, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZWN(short core, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZOverride2WN(short core, short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_LnXYZG0(short core, short crd, int x, int y, int z, double synVel, double synAcc, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZG0Override2(short core, short crd, int x, int y, int z, double synVel, double synAcc, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZG0WN(short core, short crd, int x, int y, int z, double synVel, double synAcc, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZG0Override2WN(short core, short crd, int x, int y, int z, double synVel, double synAcc, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_LnXYZA(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAOverride2(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAWN(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAOverride2WN(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_LnXYZAG0(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAG0Override2(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAG0WN(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAG0Override2WN(short core, short crd, int x, int y, int z, int a, double synVel, double synAcc, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_LnXYZACUVW(short core, short crd, ref int pPos, short posMask, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZACUVWOverride2(short core, short crd, ref int pPos, short posMask, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZACUVWWN(short core, short crd, ref int pPos, short posMask, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZACUVWOverride2WN(short core, short crd, ref int pPos, short posMask, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_ArcXYR(short core, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYROverride2(short core, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYRWN(short core, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYROverride2WN(short core, short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_ArcXYC(short core, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYCOverride2(short core, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYCWN(short core, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYCOverride2WN(short core, short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_ArcYZR(short core, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZROverride2(short core, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZRWN(short core, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZROverride2WN(short core, short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_ArcYZC(short core, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZCOverride2(short core, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZCWN(short core, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZCOverride2WN(short core, short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_ArcZXR(short core, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXROverride2(short core, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXRWN(short core, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXROverride2WN(short core, short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_ArcZXC(short core, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXCOverride2(short core, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXCWN(short core, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXCOverride2WN(short core, short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_HelixXYRZ(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYRZOverride2(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYRZWN(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYRZOverride2WN(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_HelixXYCZ(short core, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYCZOverride2(short core, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYCZWN(short core, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYCZOverride2WN(short core, short crd, int x, int y, int z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_HelixYZRX(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixYZRXOverride2(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixYZRXWN(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixYZRXOverride2WN(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_HelixYZCX(short core, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixYZCXOverride2(short core, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixYZCXWN(short core, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixYZCXOverride2WN(short core, short crd, int x, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_HelixZXRY(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixZXRYOverride2(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixZXRYWN(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixZXRYOverride2WN(short core, short crd, int x, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_HelixZXCY(short core, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixZXCYOverride2(short core, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixZXCYWN(short core, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixZXCYOverride2WN(short core, short crd, int x, int y, int z, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, int segNum, short fifo);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_BufIO(short core, short crd, short doType, ushort doMask, ushort doValue, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDelay(short core, short crd, ushort delayTime, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDA(short core, short crd, short chn, short daValue, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufIOWN(short core, short crd, short doType, short doMask, short doValue, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDelayWN(short core, short crd, short delayTime, int segNum, short fifo = 0);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDAWN(short core, short crd, short chn, short daValue, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLmtsOn(short core, short crd, short axis, short limitType, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLmtsOff(short core, short crd, short axis, short limitType, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufSetStopIo(short core, short crd, short axis, short stopType, short inputType, short inputIndex, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufMove(short core, short crd, short moveAxis, int pos, double vel, double acc, short modal, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufGear(short core, short crd, short gearAxis, int pos, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufGearPercent(short core, short crd, short gearAxis, int pos, short accPercent, short decPercent, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufStopMotion(short core, short crd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufSetVarValue(short core, short crd, short pageId, ref TVarInfo pVarInfo, double value, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufJumpNextSeg(short core, short crd, short axis, short limitType, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufSynchPrfPos(short core, short crd, short encoder, short profile, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufVirtualToActual(short core, short crd, short fifo);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdStart(short core, short mask, short option);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdStartStep(short core, short mask, short option);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdStepMode(short core, short mask, short option);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetOverride(short core, short crd, double synVelRatio);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetOverride2(short core, short crd, double synVelRatio);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitLookAhead(short core, short crd, short fifo, double T, double accMax, short n, ref TCrdData pLookAheadBuf);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLookAheadSpace(short core, short crd, out int pSpace, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLookAheadSegCount(short core, short crd, out int pSegCount, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdClear(short core, short crd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdStatus(short core, short crd, out short pRun, out int pSegment, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetUserSegNum(short core, short crd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetUserSegNum(short core, short crd, out int pSegment, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetUserSegNumWN(short core, short crd, out int pSegment, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetRemainderSegNum(short core, short crd, out int pSegment, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdStopDec(short core, short crd, double decSmoothStop, double decAbruptStop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdStopDec(short core, short crd, out double pDecSmoothStop, out double pDecAbruptStop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdLmtStopMode(short core, short crd, short lmtStopMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdLmtStopMode(short core, short crd, out short pLmtStopMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetUserTargetVel(short core, short crd, out double pTargetVel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetSegTargetPos(short core, short crd, out int pTargetPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdPos(short core, short crd, out double pPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdVel(short core, short crd, out double pSynVel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserOn(short core, short crd, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserOff(short core, short crd, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserPrfCmd(short core, short crd, double laserPower, short fifo, short channel);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowMode(short core, short crd, short source, short fifo, short channel, double startPower);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowRatio(short core, short crd, double ratio, double minPower, double maxPower, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowOff(short core, short crd, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowSpline(short core, short crd, short tableId, double minPower, double maxPower, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowTable(short core, short crd, short tableId, double minPower, double maxPower, short fifo, short channel);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowMaster(short core, short crd, ref TBufFollowMaster pBufFollowMaster, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowEventCross(short core, short crd, ref TBufFollowEventCross pEventCross, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowEventTrigger(short core, short crd, ref TBufFollowEventTrigger pEventTrigger, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowStart(short core, short crd, int masterSegment, int slaveSegment, int masterFrameWidth, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowNext(short core, short crd, int width, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowReturn(short core, short crd, double vel, double acc, short smoothPercent, short fifo);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetG0Mode(short core, short crd, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetG0Mode(short core, short crd, out short pMode);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_SetCrdMapBase(short core, short crd, short Mapbase);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdMapBase(short core, short crd, out short pBase);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdBufferMode(short core, short crd, short bufferMode, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdBufferMode(short core, short crd, out short pBufferMode, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdSegmentTime(short core, short crd, int segmentIndex, out double pSegmentTime, out int pSegmentNumber, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdTime(short core, short crd, out TCrdTime pTime, short fifo);

	//	/*-----------------------------------------------------------*/
	//	/* Compensate                                                */
	//	/*-----------------------------------------------------------*/

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetBacklash(short core, short axis, int value, double changeValue, int dir);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBacklash(short core, short axis, out int pValue, out double pChangeValue, out int pDir);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLeadScrewComp(short core, short axis, short n, int startPos, int lenPos, ref int pPositive, ref int pNegative);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EnableLeadScrewComp(short core, short axis, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLeadScrewCrossComp(short core, short axis, short n, int startPos, int lenPos, ref int pPositive, ref int pNegative, short link);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EnableLeadScrewCrossComp(short core, short axis, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCompensate(short core, short axis, out double pPitchError, out double pCrossError, out double pBacklashError, ref double pEncPos, ref double pPrfPos);


	//	public struct TLeadScrewPrm
	//	{
	//		public short n;
	//		public int startPos;
	//		public int lenPos;
	//		public int pCompPos;
	//		public int pCompNeg;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLeadScrewTable(short core, short axis, ref TLeadScrewPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EnableLeadScrewTable(short core, short axis, int error);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DisableLeadScrewTable(short core, short axis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLeadScrewTablePrfPosCount(short core, int encPos, out TLeadScrewPrm pPrm, out short pCountPositive, out short pCountNegative);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLeadScrewTablePrfPosPositive(short core, int encPos, out TLeadScrewPrm pPrm, short index, out int pPrfPosPositive);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLeadScrewTablePrfPosNegative(short core, int encPos, out TLeadScrewPrm pPrm, short index, out int pPrfPosNegative);


	//	public struct TCompensate2DTable
	//	{
	//		public short count1;                                // ��������������СֵΪ2
	//		public short count2;                                // ��������������СֵΪ2
	//		public int posBegin1;                             // ���λ��
	//		public int posBegin2;                             // ���λ��
	//		public int step1;                                 // ����
	//		public int step2;                                 // ����
	//	}

	//	public struct TCompensate2D
	//	{
	//		public short enable;                                // 2D����ʹ�ܱ�־
	//		public short tableIndex;                            // ��ʹ�õ�2D������
	//		public short axisType1;                             // ���������
	//		public short axisType2;                             // ���������
	//		public short axisIndex1;                            // ���������
	//		public short axisIndex2;                            // ���������
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCompensate2DTable(short core, short tableIndex, ref TCompensate2DTable pTable, ref int pData, short extend);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCompensate2DTable(short core, short tableIndex, out TCompensate2DTable pTable, out short pExtend);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCompensate2D(short core, short axis, ref TCompensate2D pComp2d);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCompensate2D(short core, short axis, out TCompensate2D pComp2d);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCompensate2DValue(short core, short axis, out double pValue);

	//	/*-----------------------------------------------------------*/
	//	/* IO and Encoder                                            */
	//	/*-----------------------------------------------------------*/

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDo(short core, short doType, int value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDoEx(short core, short doType, ref int pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDoBit(short core, short doType, short doIndex, short value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDo(short core, short doType, out int pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDoEx(short core, short doType, out int pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDoBitReverse(short core, short doType, short doIndex, short value, short reverseTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearAlarm(short core, short axis, short count, ushort delayTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDi(short core, short diType, out int pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDiReverseCount(short core, short diType, short diIndex, out uint pReverseCount, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDiReverseCount(short core, short diType, short diIndex, ref uint pReverseCount, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDiRaw(short core, short diType, out int pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDiEx(short core, short diType, out int pValue, short count);
	//	public struct TExtModuleType
	//	{
	//		public short type;
	//		public short input;
	//		public short output;
	//	}

	//	public struct TExtModuleStatus
	//	{
	//		public short active;
	//		public short checkError;
	//		public short linkError;
	//		public short packageErrorCount;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtModuleType(short core, short station, short module, out TExtModuleType pModuleType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtModuleCount(short core, short station, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteAo(short core, int aoType, short aoIndex, ref double pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDac(short core, short dac, ref short pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDac(short core, short dac, out short pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAuDac(short core, short dac, ref short pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuDac(short core, short dac, out short pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAdc(short core, short adc, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAdcValue(short core, short adc, out short pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuAdc(short core, short adc, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuAdcValue(short core, short adc, out short pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncLineNum(short core, short encoder, out int pLineNum, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncType(short core, short encoder, out short pType, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetEncPos(short core, short encoder, int encPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncPos(short core, short encoder, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncPosPre(short core, short encoder, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncVel(short core, short encoder, out double pValue, short count, out uint pClock);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPlsPos(short core, short encoder, int encPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPlsPos(short core, short pulse, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPlsVel(short core, short pulse, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_SetAuEncPos(short core, short encoder, int encPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuEncPos(short core, short encoder, out double pValue, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuEncVel(short core, short encoder, out double pValue, short count, out uint pClock);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAbsEncPos(short core, short encoder, out int pValue, short mode, short param);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitFPGAEncoder(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFPGAEncoder(short core, short enable, int intervalTime, short reverseMask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetFPGAEncoder(short core, out int pDataChn1, out int pDataChn2, out int pDataChn3, out int pDataChn4, out int pCount, out int pOverFlowFlag);

	//	/*-----------------------------------------------------------*/
	//	/* ExtModule                                                 */
	//	/*-----------------------------------------------------------*/
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ExtModuleInit(short core, short method);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtModuleReverse(short core, short station, short module, short inputCount, ref int pInputReverse, short outputCount, ref int pOutputReverse);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetILinkManuMode(short core, short station);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetILinkManuId(short core, short station, short autoId, out short manuId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetILinkAutoId(short core, short station, short manuId, out short autoId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtDoBit(short core, short doIndex, short value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtDoBit(short core, short doIndex, out short pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtDo(short core, short doIndex, int value, int mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtDo(short core, short doIndex, out int pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtDiBit(short core, short diIndex, out short pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtDi(short core, short diIndex, out int pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtAoValue(short core, short index, out short pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtAiValue(short core, short index, out short pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtAo(short core, short index, ref double pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtAo(short core, short index, out double pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtAi(short core, short index, out double pValue, short count);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetILinkDo(short core, short station, short module, ushort data, ushort mask);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetILinkDi(short core, short station, short module, ushort data);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetILinkAo(short core, short station, short module, short channel, short data);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetILinkAi(short core, short station, short module, short channel, out short data);

	//	/*-----------------------------------------------------------*/
	//	/* Pos Compare                                               */
	//	/*-----------------------------------------------------------*/
	//	public const short POS_COMPARE_MODE_FIFO = 0;
	//	public const short POS_COMPARE_MODE_LINEAR = 1;
	//	public const short POS_COMPARE_MODE_EQUIDISTANT = 2;

	//	public const short POS_COMPARE_OUTPUT_PULSE = 0;
	//	public const short POS_COMPARE_OUTPUT_LEVEL = 1;

	//	public const short POS_COMPARE_SOURCE_ENCODER = 0;
	//	public const short POS_COMPARE_SOURCE_PULSE = 1;


	//	public struct TPosCompareMode
	//	{
	//		public short mode;
	//		public short dimension;
	//		public short sourceMode;
	//		public short sourceX;
	//		public short sourceY;
	//		public short outputMode;
	//		public short outputCounter;
	//		public ushort outputPulseWidth;
	//		public ushort errorBand;
	//	}

	//	public struct TPosCompareLinear
	//	{
	//		public uint count;
	//		public ushort hso;
	//		public ushort gpo;

	//		public int startPos;
	//		public int interval;
	//	}

	//	public struct TPosCompareLinear2D
	//	{
	//		public uint count;
	//		public ushort hso;
	//		public ushort gpo;

	//		public int startPosX;
	//		public int startPosY;
	//		public int intervalX;
	//		public int intervalY;
	//	}


	//	public struct TPosCompareData
	//	{
	//		public int pos;
	//		public ushort hso;
	//		public ushort gpo;
	//		public uint segmentNumber;
	//	}

	//	public struct TPosCompareData2D
	//	{
	//		public int posX;
	//		public int posY;
	//		public ushort hso;
	//		public ushort gpo;
	//		public uint segmentNumber;
	//	}

	//	public struct TPosCompareStatus
	//	{
	//		public ushort mode;
	//		public ushort run;
	//		public ushort space;
	//		public uint pulseCount;
	//		public ushort hso;
	//		public ushort gpo;
	//		public uint segmentNumber;
	//	}

	//	public struct TPosCompareInfo
	//	{
	//		public ushort config;
	//		public ushort fifoEmpty;
	//		public ushort head;
	//		public ushort tail;
	//		public uint commandReceive;
	//		public uint commandSend;
	//		public int posX;
	//		public int posY;
	//	}

	//	public struct TPosComparePsoPrm
	//	{
	//		public uint count;
	//		public short hso;
	//		public ushort gpo;
	//		public int startPosX;
	//		public int startPosY;
	//		public int syncPos;
	//		public int time;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//		public short[] reserve;
	//	}


	//	public struct TPosCompareContinueMode
	//	{
	//		public short mode;
	//		public short count;
	//		public short highLevel;
	//		public short lowLevel;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//		public short[] reserve;
	//	}
	//	public struct THsoPulsePrm
	//	{
	//		public short mode;          // 0���������1����Ĭ�����������2�����յ�ǰָ��������Ϣ���
	//		public short timeScale;     // ʱ�侫�ȣ�0��1us��1:0.1us
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] pad1;
	//		public double pulseWidth;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public double[] pad2;
	//	}
	//	public struct TPosComparePulse
	//	{
	//		public short outputMode;
	//		public short level;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;
	//		public double highLevelTime;
	//		public double lowLevelTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve2;
	//	}
	//	public struct TPosComparePulseStatus
	//	{
	//		public int count;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve2;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosComparePulse(short core, short index, short outputMode, short level, ushort outputPulseWidth);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosComparePulseCount(short core, short index, int count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosComparePulseEx(short core, short index, ref TPosComparePulse pPosComparePulse);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosComparePulseStatus(short core, short index, out TPosComparePulseStatus pPosComparePulseStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareStart(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareStop(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareClear(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareStatus(short core, short index, out TPosCompareStatus pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareData(short core, short index, ref TPosCompareData pData);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareData(short core, short index, IntPtr pData);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareData2D(short core, short index, ref TPosCompareData2D pData);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareData2D(short core, short index, IntPtr pData);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Buf2DCompareData(short crd, short fifo, short chn, ref TPosCompareData2D data, short compareFifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosCompareMode(short core, short index, ref TPosCompareMode pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosCompareMode(short core, short index, out TPosCompareMode pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosCompareContinueMode(short core, short index, ref TPosCompareContinueMode pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosCompareContinueMode(short core, short index, out TPosCompareContinueMode pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosCompareLinear(short core, short index, ref TPosCompareLinear pLinear);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosCompareLinear(short core, short index, out TPosCompareLinear pLinear);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosCompareLinear2D(short core, short index, ref TPosCompareLinear2D pLinear);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosCompareLinear2D(short core, short index, out TPosCompareLinear2D pLinear);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareInfo(short core, short index, out TPosCompareInfo pInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareHsOn(short core, short index, short link, short threshold);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareHsOff(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareSpace(short core, short index, out short pSpace);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosComparePsoPrm(short core, short index, ref TPosComparePsoPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosComparePsoPrm(short core, short index, out TPosComparePsoPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosCompareStartLevel(short core, short index, short type, short startLevel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareDataMass(short core, short index, ref TPosCompareData pData, out long pSendCount, long count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCompareDataMass(short core, short index, IntPtr pData, out long pSendCount, long count);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetHsoPulsePrm(short core, short station, short hsoIndex, ref THsoPulsePrm pPem, short hsoCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetHsoPulsePrm(short core, short station, short hsoIndex, out THsoPulsePrm pPem, short hsoCount);

	//	public const short COMPARE_SEND_DATA_MAX = 30;
	//	public const short COMPARE_DATA_MAX = 4096;
	//	public const int COMPARE_STEP_MAX = 0x1fff;
	//	public const int COMPARE_MAX_NUM = 0x3fffffff;

	//	/*-----------------------------------------------------------*/
	//	/* Laser and Scan                                            */
	//	/*-----------------------------------------------------------*/
	//	public const short FIFO_MODE_STATIC = 0;
	//	public const short FIFO_MODE_DYNAMIC = 1;

	//	public const short SCAN_STATUS_WAIT = 0;
	//	public const short SCAN_STATUS_RUN = 1;
	//	public const short SCAN_STATUS_DONE = 2;

	//	public struct TScanInit
	//	{
	//		public int lookAheadNum;             //ǰհ����
	//		public double time;                  //ʱ�䳣��
	//		public double radiusRatio;           //�������Ƶ��ڲ���
	//	}

	//	public struct TScanInfo
	//	{
	//		public uint segmentNumber;
	//		public ushort commandNumber;
	//		public ushort prfVel;
	//		public ushort fifoEmpty;
	//		public ushort head;
	//		public ushort tail;
	//		public uint commandReceive;
	//		public uint commandSend;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public uint[] reserve;

	//	}

	//	public struct TScanPosSuperposeParameter
	//	{
	//		public short enable;
	//		public short superposeSrc;
	//		public short superposeAxisX;
	//		public short superposeAxisY;
	//		public double xCoefficient;
	//		public double yCoefficient;
	//		public double xVelCoefficient;
	//		public double yVelCoefficient;
	//	}

	//	public struct TLaserInfo
	//	{
	//		public ushort hso;
	//		public ushort powerMode;
	//		public ushort power;
	//		public ushort powerMax;
	//		public ushort powerMin;
	//		public ushort frequency;
	//		public ushort pulseWidth;
	//	}
	//	public struct TLaserPowerPrm
	//	{
	//		public short n;
	//		public double startVel;
	//		public double power;
	//	}

	//	public struct TLaserPowerTable
	//	{
	//		public short n;
	//		public double startVel;
	//		public double velStep;
	//		public double power;
	//	}
	//	//typedef struct
	//	//{
	//	//    short corrX[65][65];
	//	//    short corrY[65][65];
	//	//}TScanCorrectionTableData;

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanInit(short core, ref TScanInit pScanInit, double jumpAcc, double markAcc, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCrdDataEnd(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanLaserLink(short core, short link, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanLaserLink(short core, out short pLink, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanMode(short core, short mode, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanMode(short core, out short pMode, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearScanStatus(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanGetCrdPos(short core, out short pPos, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanJump(short core, short x, short y, double vel, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanJumpPoint(short core, short x, short y, double vel, int motionDelayTime, int laserDelayTime, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanTimeJump(short core, short x, short y, ushort time, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanTimeJumpPoint(short core, short x, short y, ushort time, int motionDelayTime, int laserDelayTime, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanMark(short core, short x, short y, double vel, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanTimeMark(short core, short x, short y, ushort time, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufLaserPrfCmd(short core, double laserPower, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufIO(short core, ushort doType, ushort doMask, ushort doValue, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufDelay(short core, int time, short crd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufDA(short core, ushort chn, short value, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufAO(short core, short chn, double voltage, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufLaserDelay(short core, short laserOnDelay, short laserOffDelay, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufLaserOutFrq(short core, double outFrq, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufSetPulseWidth(short core, ushort width, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufLaserOn(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufLaserOff(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanBufStop(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserIntervalOnList(short core, int time, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanDelayTime(short core, ushort maxJumpDelay, ushort markDelay, ushort multiMarkDelayConst, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanDelayMode(short core, short multiMarkDelayMode, ushort multiMarkLaserOffDelay, ushort minJumpDelay, ushort jumpDelayLengthLimit, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanStop(short core, short stopType, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCrdSpace(short core, out short pSpace, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCrdStart(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCrdClear(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCrdStatus(short core, out short pRun, out short pStatus, short scan);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanPosSuperposeParameter(short core, short crd, TScanPosSuperposeParameter param);
	//	//[DllImport("gts.dll")]
	//	//public static extern short GTN_ScanSetCorrectionTable(short core,short crd,ref TScanCorrectionTableData pParam);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCorrectionOn(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCorrectionOff(short core, short scan);
	//	//[DllImport("gts.dll")]
	//	//public static extern short GTN_ScanGenerateCorrectionTable(short core,double paraX,double paraY,short rangeX,short rangeY,ref TScanCorrectionTableData pParam);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserOn(short core, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserOff(short core, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserOnStatus(short core, out ushort pValue, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserPowerMode(short core, short laserPowerMode, double maxValue, double minValue, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserPrfCmd(short core, double power, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserOutFrq(short core, double outFrq, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPulseWidth(short core, ushort width, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLevelDelay(short core, uint highLevelDelay, uint lowLevelDelay, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserInfo(short core, out TLaserInfo pLaserInfo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetHsoPwmLink(short core, short station, short hsoindex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanInfo(short core, ref TScanInfo pScanInfo, short crd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanHsOn(short core, short crd, short link, short threshold);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanHsOff(short core, short crd);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserOn(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserOff(short core, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserOnStatus(short core, out short pValue, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanSetLaserMode(short core, short laserMode, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserPowerMode(short core, short laserPowerMode, double maxValue, double minValue, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserPrfCmd(short core, double power, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserOutFrq(short core, double outFrq, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanSetPulseWidth(short core, short width, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanSetLevelDelay(short core, short highLevelDelay, short lowLevelDelay, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLaserInfo(short core, ref TLaserInfo pLaserInfo, short scan);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanSetDa(short core, short chn, short value, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanSetMotionWithLaserControl(short core, short laserCtrlEnable, short scan);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanGetMotionWithLaserControl(short core, out short pLaserCtrlEnable, short scan);

	//	/*----------------*/
	//	/*�����ָ��    */
	//	/*----------------*/

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanInitPro(short core, short scanCrd, ref TScanLookAheadParameterPro pPrm, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanCrdPosPro(short core, short scanCrd, out double pPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanStatusPro(short core, short scanCrd, out TScanStatusPro pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLinearPro(short core, short scanCrd, short motionMode, ref TScanLinearMotionPro pPrm, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanCircularPro(short core, short scanCrd, short motionMode, ref TScanCircularMotionPro pPrm, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanDelayPrmPro(short core, short scanCrd, ref TScanDelayParameterPro pPrm, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanMotionDelayPro(short core, short scanCrd, double delayTime, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanExecuteTimePro(short core, short scanCrd, out double pExecuteTime);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearScanExecuteTimePro(short core, short scanCrd);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanLaserLinkPro(short core, short scanCrd, out short pLaserChannel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanLaserLinkPro(short core, short scanCrd, short laserChannel, ref TListInfo pListInfo);//�񾵼����,laserChannelΪ0���ǽ��
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanLaserInfoPro(short core, short scanCrd, out TLaserInfoPro pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanLaserEnablePro(short core, short scanCrd, short laserEnable, ref TListInfo pListInfo);//���⿪�ع�
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanLaserPrmPro(short core, short scanCrd, ref TLaserParameterPro pLaserPrm, ref TListInfo pListInfo);//����ģʽ�͹̶���������

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanLaserPowerPro(short core, short scanCrd, double power, ref TListInfo pListInfo);//������������
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanLaserDelayPro(short core, short scanCrd, double laserOnDelay, double laserOffDelay, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanWobbleMotionCircularEnablePro(short core, short scanCrd, short enable, ref TScanWobbleMotionCircular pWobbleMotionCircular, ref TListInfo pListInfo);

	//	public const short SCAN_MOTION_MODE_NONE = 0;
	//	public const short SCAN_MOTION_MODE_JUMP = 1;
	//	public const short SCAN_MOTION_MODE_JUMP_POINT = 2;
	//	public const short SCAN_MOTION_MODE_JUMP_TIME = 3;
	//	public const short SCAN_MOTION_MODE_JUMP_TIME_POINT = 4;
	//	public const short SCAN_MOTION_MODE_MARK = 5;
	//	public const short SCAN_MOTION_MODE_MARK_TIME = 6;

	//	public const ushort SCAN_LASER_MODE_DUTY_RATIO = 0;//ռ�ձ�ģʽ
	//	public const ushort SCAN_LASER_MODE_FREQUENCY = 1;//Ƶ��ģʽ
	//	public const ushort SCAN_LASER_MODE_ANALOG = 2;//ģ����ģʽ

	//	/*ռ�ձ�ģʽ�̶�����*/
	//	public struct TLaserDutyRatioModeParameterPro
	//	{
	//		public double minDutyRatio;
	//		public double maxDutyRatio;
	//		public double frequency;
	//	}

	//	/*Ƶ��ģʽ�̶�����*/
	//	public struct TLaserFrequencyModeParameterPro
	//	{
	//		public double minFrequency;
	//		public double maxFrequency;
	//		public double pulseWidth;
	//	}

	//	/*ģ����ģʽ�̶�����*/
	//	public struct TlaserAnalogModeParameterPro
	//	{
	//		public double minVoltage;
	//		public double maxVoltage;
	//	}
	//	/*����ģʽ�̶�����*/
	//	public struct TlasetParallelModeParameterPro
	//	{

	//		public double minParallel;
	//		public double maxParallel;
	//		public int powerFollowEnable;                                // �򿪻��߹رռ�����������,0: �رռ�����������,1: �򿪼�����������
	//		public int powerSet;                                         // ����رռ�����������ʱ,������������ֵ
	//	}

	//	/*�������ģʽ�̶�����*/
	//	public struct TLaserParameterUnionPro
	//	{
	//		public TLaserDutyRatioModeParameterPro dutyRatioModePrm;
	//		public TLaserFrequencyModeParameterPro frequencyModePrm;
	//		public TlaserAnalogModeParameterPro analogModePrm;
	//		public TlasetParallelModeParameterPro parallelModePrm;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] data;
	//	}


	//	/*������Ϣ����*/
	//	public struct TLaserInfoPro
	//	{

	//		public ushort laserOn;   //���⿪��״̬
	//		public ushort laserMode; //PWM���ģʽ���궨��
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] pad;             //����
	//		public double power;             //��������
	//		public TLaserParameterUnionPro laserPrm;
	//	}

	//	public struct TLaserParameterPro
	//	{

	//		public ushort laserMode; //PWM���ģʽ�������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad;             //����
	//		public TLaserParameterUnionPro laserPrm;
	//	}


	//	/*��ǰհ����*/
	//	public struct TScanLookAheadParameterPro
	//	{
	//		public short lookAheadNum;   //ǰհ����
	//		public short highSpeedMode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] pad;         //����
	//		public double time;          //ʱ�䳣��
	//		public double radiusRatio;   //�������Ƶ��ڲ���
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] reserve;    //����
	//	}



	//	/*��״̬*/
	//	public struct TScanStatusPro
	//	{
	//		public short run;            //���˶���־
	//		public short space;
	//		public ushort fifoEmpty;     //�ܿձ�־
	//		public short pad1;           //����
	//		public uint segmentNumber;  //ִ�жκ�
	//		public uint commandReceive; //���յ���ָ����
	//		public uint commandSend;    //�ѷ��͵�ָ����
	//		public int pad2;            //����
	//		public double prfVel;        //�ϳɹ滮�ٶ�

	//	}


	//	public struct TScanCircularMotionPro
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public double[] endPos;
	//		public double radius;//�뾶���������Ż��ӻ�
	//		public short dir;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad;//����
	//		public TScanMotionPrmUnionPro motionPrm;
	//	}


	//	public struct TScanDelayParameterPro
	//	{
	//		public short multiMarkDelayMode;
	//		public ushort jumpDelayLengthLimit;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] pad;//����
	//		public double multiMarkLaserOffDelay;
	//		public double multiMarkDelayConst;
	//		public double markDelay;
	//		public double minJumpDelay;
	//		public double maxJumpDelay;
	//	}


	//	public struct TScanLinearMotionPro
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public double[] pos;
	//		public double reserve;//����
	//		public TScanMotionPrmUnionPro motionPrm;
	//	}

	//	public struct TScanMotionPrmUnionPro
	//	{
	//		public TVelModePro velMode;
	//		public TTimeModePro timeMode;
	//		public TVelPointModePro velPointMode;
	//		public TTimePointModePro timePointMode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] data;
	//	}

	//	public struct TVelModePro
	//	{
	//		public double acc;
	//		public double dec;
	//		public double vel;
	//	}

	//	public struct TTimeModePro
	//	{
	//		public double acc;
	//		public double dec;
	//		public ulong time;
	//		public long pad;//����
	//	}

	//	public struct TVelPointModePro
	//	{
	//		public double acc;
	//		public double dec;
	//		public double vel;
	//		public ulong motionDelayTime;
	//		public ulong laserDelayTime;
	//	}

	//	public struct TTimePointModePro
	//	{
	//		public double acc;
	//		public double dec;
	//		public ulong time;
	//		public ulong motionDelayTime;
	//		public ulong laserDelayTime;
	//		public long pad;//����
	//	}
	//	public struct TScanWobbleMotionCircular
	//	{

	//		public double radius;
	//		public short dir;
	//		public short velMode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve;    //����
	//		public double velValue;
	//	}
	//	/*-----------------------------------------------------------*/
	//	/* ������Ұ                                                  */
	//	/*-----------------------------------------------------------*/
	//	public struct TScanInfiniteView
	//	{
	//		public short superposeSource;
	//		public short tableAxisX;
	//		public short tableAxisY;
	//		public short reserve1;
	//		public double scanScale;
	//		public double tableScale;
	//		//public double tableScaleY;
	//		public double tableAccMax;
	//		public double tableVelMax;
	//		public double tableMotionRatio;
	//		public double reserve2;
	//		public double reserve3;
	//		public double reserve4;
	//		public double reserve5;
	//	}
	//	public struct TScanDisableInfiniteView
	//	{
	//		public double reserve1;
	//		public double reserve2;
	//		public double reserve3;
	//		public double reserve4;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanEnableInfiniteView(short core, short scanCrd, ref TScanInfiniteView pScanInfiniteView, string pFileName, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanDisableInfiniteView(short core, short scanCrd, ref TScanDisableInfiniteView pScanInfiniteView, ref TListInfo pListInfo);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanLoadInfiniteViewFile(short core, short scanCrd, string pFileName);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanSendInfiniteViewData(short core, short scanCrd, double time, out double pTime, out double pMotionTime);

	//	/*-----------------------------------------------------------*/
	//	/* ������Ұ                                                  */
	//	/*-----------------------------------------------------------*/
	//	public struct TScanIvInitParameter
	//	{

	//		public short list;                      // ������Ұʹ�õ�ָ������
	//		public short superposeSource;           // ��λ�õ���Դ��������/���������

	//		public short superposeReserveX;  // ��λ�õ��ӷ���ȡ��  1��ȡ��  0������      
	//		public short superposeReserveY;  // ��λ�õ��ӷ���ȡ��  1��ȡ��  0������     

	//		public short tableAxisX;                // ��X��������
	//		public short tableAxisY;                // ��Y��������

	//		public short reserve4;// �����������Ҫ����Ϊ0
	//		public short reserve5;// �����������Ҫ����Ϊ0

	//		public double scanScale;                // �������������λ��bit/mm
	//		public double tableAxisXScale;          // ����̨X�����������������Y��Ӧ����һ�£���λ��pulse/mm
	//		public double tableAxisYScale;          // ����̨Y�����������������X��Ӧ����һ�£���λ��pulse/mm
	//		public double scanViewRange;            // ����Ұ�ӹ���Χ����λ��mm����������4mm�Ļ�������Ұ��������2mm
	//		public double tableAccMax;              // �������˶����ϳɼ��ٶ�
	//		public double tableVelMax;              // �������˶����ϳ��ٶ�
	//		public double tableMotionRatio;         // �������˶�ϵ��������100

	//		public double reserve0;              // �����������Ҫ����Ϊ0
	//		public double reserve1;              // �����������Ҫ����Ϊ0
	//		public double reserve2;              // �����������Ҫ����Ϊ0
	//		public double reserve3;              // �����������Ҫ����Ϊ0
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvInit(short core, short scanCrd, ref TScanIvInitParameter pScanIvInitPrm);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvClear(short core, short scanCrd);

	//	public struct TScanIvCaculateStatus
	//	{

	//		public short process;
	//		public short errorCode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] pad;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvCaculate(short core, short scanCrd, string pFileName, ref TScanIvCaculateStatus pScanIvCaculateStatus);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvSend(short core, short scanCrd, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvStart(short core, short scanCrd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvReset(short core, short scanCrd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvStop(short core, short scanCrd, short stopMode);

	//	public struct TScanIvInfo
	//	{

	//		public short run;                // ������Ұ�˶�״̬
	//		public short scanStatus;         // ������Ұ���˶�״̬
	//		public short tableStatus;        // ������Ұ����̨�˶�״̬
	//		public short fifoEmpty;          // ������Ұ�������ܿձ�־��bit0�����ܿձ�־��bit1������̨�ܿձ�־
	//		public short stopInfo;           // ������Ұֹͣ��Ϣ
	//		public short reserve1;           // �������
	//		public int scanCmdCount;        // ������Ұ�ײ����ݴ洢ʣ��ռ�
	//		public int tableCmdCount;       // ������Ұ�ײ����ݴ洢ʣ��ռ�
	//		public int segNum;              // ������Ұ�˶��κ�
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public int[] reserve2;         // �������
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvInfo(short core, short scanCrd, out TScanIvInfo pScanIvInfo);



	//	public struct TScanIvLaserPowerFollowPrm
	//	{
	//		public short laserMode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad;
	//		public double laserPrePrm;
	//		public double ratio;
	//		public double powerMaxLimit;
	//		public double powerMin;

	//	}



	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ScanIvLaserFollowMode(short core, short scanCrd, ref TScanIvLaserPowerFollowPrm pScanIvLaserPowerFollowPrm);

	//	/*-----------------------------------------------------------*/
	//	/* DLM                                                       */
	//	/*-----------------------------------------------------------*/
	//	public const short DLM_FUNCTION_EVENT = 0;
	//	public const short DLM_FUNCTION_TIMER = 1;
	//	public const short DLM_FUNCTION_BACKGROUND = 2;
	//	public const short DLM_FUNCTION_COMMAND = 3;

	//	public const short DLM_FUNCTION_PROCEDURE = 7;

	//	public const short DLM_FUNCTION_PROFILE_EVENT = 8;
	//	public const short DLM_FUNCTION_PROFILE = 9;
	//	public const short DLM_FUNCTION_PROFILE_SUPERIMPOSED = 10;
	//	public const short DLM_FUNCTION_PROFILE_FILTER = 11;

	//	public const short DLM_FUNCTION_SERVO_EVENT = 16;
	//	public const short DLM_FUNCTION_SERVO = 17;
	//	public const short DLM_FUNCTION_SERVO_SUPERIMPOSED = 18;
	//	public const short DLM_FUNCTION_SERVO_FILTER = 19;

	//	public const short DLM_LOAD_MODE_NONE = 0;
	//	public const short DLM_LOAD_MODE_COMMAND = 1;
	//	public const short DLM_LOAD_MODE_BOOT = 2;
	//	public const short DLM_LOAD_MODE_RUN = 3;

	//	public struct TDlmStatus
	//	{
	//		public int version;
	//		public int date;
	//		public short enable;
	//		public int function;
	//	}

	//	public struct TDlmFunction
	//	{
	//		public short function;
	//		public short enable;
	//		public int value;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadDlm(short core, int vender, int module, string fileName, out short pId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ProgramDlm(short core, short id, short loadMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDlmLoadMode(short core, short id, out short pLoadMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RunDlm(short core, short id);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StopDlm(short core, short id);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDlmStatus(short core, short id, out TDlmStatus pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDlmFunction(short core, short id, ref TDlmFunction pFunction);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDlmFunction(short core, short id, out TDlmFunction pFunction);
	//	[DllImport("gts.dll")]


	//	public static extern short GTN_DlmCommandInit(short core, short code, int index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandAdd16(short core, short value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandAdd32(short core, int value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandAddFloat(short core, float value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandAddDouble(short core, double value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SendDlmCommand(short core, short id, out short pReturnValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandGet16(short core, out short pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandGet32(short core, out int pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandGetFloat(short core, ref float pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DlmCommandGetDouble(short core, out double pValue);

	//	/*-----------------------------------------------------------*/
	//	/* Event-Task                                                */
	//	/*-----------------------------------------------------------*/
	//	public const short TASK_SET_DO_BIT = 0x1101;
	//	public const short TASK_SET_DAC = 0x1120;

	//	public const short TASK_STOP = 0x1303;

	//	public const short TASK_UPDATE_POS = 0x2002;
	//	public const short TASK_UPDATE_VEL = 0x2004;

	//	public const short TASK_PT_START = 0x2306;
	//	public const short TASK_PVT_START = 0x2346;
	//	public const short TASK_MOVE_ABSOLUTE = 0x2500;

	//	public const short TASK_GEAR_START = 0x3005;

	//	public const short TASK_FOLLOW_START = 0x310A;
	//	public const short TASK_FOLLOW_SWITCH = 0x310B;

	//	public const short TASK_CRD_START = 0x4004;
	//	public const short TASK_SCAN_START = 0x4102;

	//	public const short TASK_SET_DO_BIT_MODE_NONE = 0;
	//	public const short TASK_SET_DO_BIT_MODE_TIME = 10;
	//	public const short TASK_SET_DO_BIT_MODE_DISTANCE = 20;



	//	public struct TTaskSetDoBit
	//	{
	//		public short doType;
	//		public short doIndex;
	//		public short doValue;
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public int[] parameter;
	//	}

	//	public struct TTaskSetDac
	//	{
	//		public short dac;
	//		public short value;
	//	}

	//	public struct TTaskStop
	//	{
	//		public int mask;
	//		public int option;
	//	}

	//	public struct TTaskFifoOperation
	//	{
	//		public short type;
	//		public short index;
	//		public short operation;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//		public short[] data;
	//	}

	//	public struct TTaskUpdatePos
	//	{
	//		public short profile;
	//		public int pos;
	//	}

	//	public struct TTaskUpdateDistance
	//	{
	//		public short profile;
	//		public short triggerIndex;
	//		public int distance;
	//	}
	//	public struct TTaskUpdateVel
	//	{
	//		public short profile;
	//		public double vel;
	//	}

	//	public struct TTaskPtStart
	//	{
	//		public int mask;
	//		public int option;
	//	}

	//	public struct TTaskPvtStart
	//	{
	//		public int mask;
	//	}

	//	public struct TTaskGearStart
	//	{
	//		public int mask;
	//	}

	//	public struct TTaskFollowStart
	//	{
	//		public int mask;
	//		public int option;
	//	}

	//	public struct TTaskFollowSwitch
	//	{
	//		public int mask;
	//	}

	//	public struct TTaskMoveAbsolute
	//	{
	//		public short profile;
	//		public int pos;
	//		public double vel;
	//		public double acc;
	//		public double dec;
	//		public short percent;
	//	}

	//	public struct TTaskCrdStart
	//	{
	//		public short mask;
	//		public short option;
	//	}

	//	public struct TTaskScanStart
	//	{
	//		public short core;
	//		public short index;
	//		public short count;
	//	}

	//	public struct TEvent
	//	{
	//		public uint loop;
	//		public TWatchVar var;
	//		public ushort condition;
	//		public double value;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearEvent(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearTask(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearEventTaskLink(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AddTask(short core, short taskType, IntPtr pTaskData, out short pTaskIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AddEvent(short core, ref TEvent pEvent, out short pEventIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AddEventTaskLink(short core, short eventIndex, short taskIndex, out short pLinkIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEventCount(short core, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEvent(short core, short eventIndex, out TEvent pEvent);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEventLoop(short core, short eventIndex, out uint pEventLoop);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTaskCount(short core, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEventTaskLinkCount(short core, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEventTaskLink(short core, short linkIndex, out short pEventIndex, out short pTaskIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EventOn(short core, short eventIndex, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EventOff(short core, short eventIndex, short count);

	//	/*--------- -------------------------------------------------*/
	//	/* Gantry                                                    */
	//	/*-----------------------------------------------------------*/
	//	public const short GANTRY_MODE_NONE = -1;
	//	public const short GANTRY_MODE_OPEN_LOOP_GANTRY = 1;
	//	public const short GANTRY_MODE_DECOUPLE_POSITION_LOOP = 2;

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGantryMode(short core, short group, short master, short slave, short mode, int syncErrorLimit);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGantryMode(short core, short group, out short pMaster, out short pSlave, out short pMode, out int pSyncErrorLimit);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGantryPid(short core, short group, ref TPid pGantryPid, ref TPid pYawPid);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGantryPid(short core, short group, out TPid pGantryPid, out TPid pYawPid);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GantryAxisOn(short core, short group);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GantryAxisOff(short core, short group);


	//	public struct TSecondOrderFilterPara
	//	{
	//		public short active;

	//		public double a0;
	//		public double a1;
	//		public double a2;

	//		public double b1;
	//		public double b2;
	//	}

	//	public const short TYPE_CONTROL_OUTPUT_FILTER = 1;
	//	public const short TYPE_YAW_CONTROL_OUTPUT_FILTER = 2;
	//	public const short FILTER_COUNT_MAX = 2;

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetSecondOrderFilterPara(short core, short control, short type, short index, ref TSecondOrderFilterPara pFilterPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetSecondOrderFilterPara(short core, short control, short type, short index, out TSecondOrderFilterPara pFilterPrm);

	//	public struct OCA_CTRL_GEN
	//	{
	//		public short s16Gain;
	//		public short s16Offset;
	//		public double dFrq;
	//		public int u32RunPeriod;
	//		public short u16SigType;
	//	}

	//	public struct TExcitationPara
	//	{
	//		public short gain;
	//		public short offset;
	//		public short frq;       // hz
	//		public double runTime;  // s
	//	}

	//	public struct TExcitationTrpPara
	//	{
	//		public double vel;
	//		public double acc;
	//		public double dec;
	//		public double runTime;  // s
	//	}


	//	public const short NO_EXCIT = 0xff;
	//	public const short OPEN_LOOP_EXCIT = 1;
	//	public const short SIGNAL_TYPE_STEP = 3;
	//	public const short SIGNAL_TYPE_SIN = 0x10;
	//	public const short SIGNAL_TYPE_TRAP = 0x11;
	//	public const short SIGNAL_TYPE_NOTHING = 0xFF;

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGenerator(short core, ref OCA_CTRL_GEN pGenStr);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StepResponse(short core, short control, short gain, double time);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExctLoopMode(short core, short control, short exciteLoopMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExctLoopMode(short core, short control, out short pExciteLoopMode);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExcitation(short core, short axis, short objectValue, short type, short pParameter);

	//	/*-----------------------------------------------------------*/
	//	/* DMA                                                       */
	//	/*-----------------------------------------------------------*/

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdHsOn(short core, short crd, short fifo, short link, short threshold, short lookAheadInMc);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdHsOff(short core, short crd, short fifo);

	//	/*-----------------------------------------------------------*/
	//	/* Others                                                    */
	//	/*-----------------------------------------------------------*/
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetRetainValue(short core, uint address, short count, ref short pData);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetRetainValue(short core, uint address, short count, out short pData);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGPIOConfig(short core, short effectiveLevel, short direction);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPrfTorque(short core, short axis, short prfTorque);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAtlTorque(short core, short axis, out short atlTorque);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PosCurrFeedForward(short core, short profile, double pos, int gtime, short torque, short gtype, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMotionMode(short core, short axis, short motionMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMotionMode(short core, short axis, out short motionMode);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetProfileTime(short core, int profileTime, int delay, int stepCoef);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetProfileTime(short core, out int pProfileTime, out int pDelay, out int pStepCoef);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCoreTime(short core, int profileTime, int delay, int stepCoef);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCoreTime(short core, out int pProfileTime, out int pDelay, out int pStepCoef);

	//	public struct TControlInfo
	//	{
	//		public double refPos;
	//		public double refPosFilter;
	//		public double refPosFilter2;
	//		public double cntPos;
	//		public double cntPosFilter;

	//		public double error;
	//		public double refVel;
	//		public double refAcc;

	//		public short value;
	//		public short valueFilter;

	//		public short offset;
	//	}

	//	public struct TCommandCount
	//	{
	//		public uint notify;
	//		public uint receive;
	//		public uint execute;
	//		public uint retry;
	//		public uint receiveError;
	//		public uint echo;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearCommandCount(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCommandCount(short core, out TCommandCount pCommandCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetServoTime(short core, int servoTime, int delay, int stepCoef);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetServoTime(short core, out int pServoTime, out int pDelay, out int pStepCoef);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetControlInfo(short core, short control, out TControlInfo pControlInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLongVar(short core, short index, int value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLongVar(short core, short index, out int pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDoubleVar(short core, short index, double value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDoubleVar(short core, short index, out double pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBufWaitDiStatus(short core, short crd, out short pDiType, out short pDiIndex, out short pLevel, out short pContinueTime, out int pOverTime, out short pFlagMode, out int pSegNum, out short pEnable, out int pCount, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBufWaitLongVarStatus(short core, short crd, out short pIndex, out int pValue, out short pFlagMode, out int pSegNum, out short pEnable, out short pStatus, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearBufWaitStatus(short core, short crd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufWaitDi(short core, short crd, short diType, short diIndex, short level, short continueTime, int overTime, short flagMode, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufWaitLongVar(short core, short crd, short index, int value, int overTime, short flagMode, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisMotionSmooth(short core, short axis, double time, double k);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisMotionSmooth(short core, short axis, out double pTime, out double pK);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDoBit(short core, short crd, short doType, short index, short value, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDoBitDelay(short core, short crd, short doType, short index, short value, int delayTime, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdJerk(short core, short crd, double jerkMax);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdJerk(short core, short crd, out double pJerkMax);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdJerkTime(short core, short crd, double jerkTime, double coef);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdJerkTime(short core, short crd, out double pJerkTime, out double pCoef);

	//	public struct TCrdSmooth
	//	{
	//		public short percent;
	//		public short accStartPercent;
	//		public short decEndPercent;
	//		public double reserve;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdSmooth(short core, short crd, ref TCrdSmooth pCrdSmooth);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdSmooth(short core, short crd, out TCrdSmooth pCrdSmooth);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdSmoothTime(short core, short crd, short smoothType, ref double pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdSmoothTime(short core, short crd, out short pSmoothType, out double pPrm);

	//	//////////////////////////////////////////////////////////////////////////
	//	//Standard Home
	//	//////////////////////////////////////////////////////////////////////////

	//	public const short STANDARD_HOME_STAGE_IDLE = 0;                    //δ�����ԭ��
	//	public const short STANDARD_HOME_STAGE_START = 1;                   //�����ԭ��
	//	public const short STANDARD_HOME_STAGE_SEARCH_HOME = 20;            //��������Home
	//	public const short STANDARD_HOME_STAGE_SEARCH_INDEX = 30;         //��������Index
	//	public const short STANDARD_HOME_STAGE_GO_HOME = 80;                //�����˶���ԭ��
	//	public const short STANDARD_HOME_STAGE_END = 100;                   //��ԭ�����
	//	public const short STANDARD_HOME_STAGE_START_CHECK = -1;            //�����ԭ��ǰ�Լ�
	//	public const short STANDARD_HOME_STAGE_CHECKING = -2;               //�Լ���

	//	public const short STANDARD_HOME_ERROR_NONE = 0;                    //δ��������
	//	public const short STANDARD_HOME_ERROR_DISABLE = 10;                //ִ�л�ԭ�����δʹ��
	//	public const short STANDARD_HOME_ERROR_ALARM = 20;                  //ִ�л�ԭ����ᱨ��
	//	public const short STANDARD_HOME_ERROR_STOP = 30;                   //δ��ɻ�ԭ�㣬��ֹͣ�˶�
	//	public const short STANDARD_HOME_ERROR_ON_LIMIT = 40;               //��������λ�޷�����
	//	public const short STANDARD_HOME_ERROR_NO_HOME = 50;                //δ�ҵ�Home
	//	public const short STANDARD_HOME_ERROR_NO_INDEX = 60;               //δ�ҵ�Index
	//	public const short STANDARD_HOME_ERROR_NO_LIMIT = 70;               //δ�ҵ���λ
	//	public const short STANDARD_HOME_ERROR_ENCODER_DIR_SCALE = -1;      //�滮����������������෴���ߵ�����һ��

	//	public struct TStandardHomePrm
	//	{
	//		public short mode;                                    // ��ԭ��ģʽȡֵ��Χ1~36
	//		public double highSpeed;                              // ����Home���ٶȣ���λpulse/ms
	//		public double lowSpeed;                               // ����Index���ٶȣ���λpulse/ms
	//		public double acc;                                    // ������ٶȣ���λpulse/ms^2
	//		public int offset;                                  // ����ƫ��������λpulse
	//		public short check;                                   // �Ƿ������Լ칦�ܣ�1-���ã�����ֵ-������
	//		public short autoZeroPos;                             // ��������Ƿ��Զ����㣬1-�Զ����㣬����ֵ-������
	//		public int motorStopDelay;                          // �����λ��ʱ����λ����������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short pad1;                                    // ���������Ҫ���ã�
	//	}

	//	public struct TStandardHomeStatus
	//	{
	//		public short run;           // �����ڽ��л�ԭ�㣬0����ֹͣ�˶���1-���ڻ�ԭ��
	//		public short stage;         // ��ԭ���˶��Ľ׶�
	//		public short error;         // ��ԭ����̵ķ����Ĵ���
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad1;        // ������޾��庬�壩
	//		public int capturePos;    // ����Home��Indexʱ�̵ı�����λ��
	//		public int targetPos;     // ��Ҫ�˶�����Ŀ��λ�ã�ԭ��λ�û���ԭ��λ��+ƫ��������������Limitʱ��������Home��Indexʱ�����õ���������Ϊ0����ô��ֵ��ʾΪ805306368
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ExecuteStandardHome(short core, short axis, ref TStandardHomePrm pHomePrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetStandardHomePrm(short core, short axis, out TStandardHomePrm pHomePrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetStandardHomeStatus(short core, short axis, out TStandardHomeStatus pHomeStatus);

	//	public struct TLaserOnOffCount
	//	{
	//		public uint onCount;
	//		public uint offCount;
	//		public uint onCountInFpga;
	//		public uint offCountInFpga;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public uint[] pad;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLaserOnOffCount(short core, short channel, out TLaserOnOffCount pLaserCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearLaserOnOffCount(short core, short channel);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosComparePsoPrm(short core, short crd, short index, ref TPosComparePsoPrm pPrm, short fifo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisInputShaping(short core, short axis, short enable, short count, double k);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGantrySynchErrorCompensate2DTable(short core, short tableIndex, ref TCompensate2DTable pTable, ref int pData, short extend);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGantrySynchErrorCompensate2D(short core, short group, ref TCompensate2D pComp2d);

	//	public struct TLaserFollowPrm
	//	{
	//		public short laserFollowMode;
	//		public double maxFrq;
	//		public double minFrq;
	//		public double maxDuty;
	//		public double minDuty;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	//		public short[] pad1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] pad2;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLaserFollowMode(short core, ref TLaserFollowPrm pPrm, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLaserFollowTable(short core, short tableId, int n, ref double pVel, ref double pPower, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LaserFollowOff(short core, short crd, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLaserOnOffSmooth(short core, short crd, short fifo, short channel, short mask);

	//	public struct TBufWaitDiStatusEx
	//	{
	//		public short type;
	//		public short enable;
	//		public short flagMode;
	//		public short diType;
	//		public short diIndex;
	//		public short diValue;
	//		public ushort continueTime;
	//		public ushort trigDelay;
	//		public uint overTime;
	//		public uint counter;
	//		public int longVar;
	//		public int segNum;
	//		public short stop;
	//		public short overTimeStop;
	//		public short pad11;
	//		public short pad12;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetBufWaitDiStatusEx(short core, short crd, short fifo, out TBufWaitDiStatusEx pStatus);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosCompareFifoMode(short core, short index, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosCompareFifoMode(short core, short index, out short pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosCompareLatchValue(short core, short index, int count, out int pDataX, out int pDataY, out int pCount, out TLatchValueInfo pInfo);

	//	public struct TTaskMoveEscape
	//	{
	//		public uint profileMask;
	//		public int offset;
	//		public double vel;
	//		public double acc;
	//	};

	//	public struct TEventStatus
	//	{
	//		public short eventHit;
	//		public short pad11;
	//		public short pad12;
	//		public short pad13;
	//		public int pad21;
	//		public int pad22;
	//		public double pad31;
	//		public double pad32;
	//	};

	//	public struct TaskStatus
	//	{
	//		public short start;
	//		public short execute;
	//		public short pad11;
	//		public short pad12;
	//		public int pad21;
	//		public int pad22;
	//		public double pad31;
	//		public double pad32;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEventStatus(short core, short index, out TEventStatus pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTaskStatus(short core, short index, out TaskStatus pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTriggerMoveEscape(short core, short trigger, ref TTaskMoveEscape pPrm);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosCompareStart(short core, short crd, short fifo, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosCompareStop(short core, short crd, short fifo, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosCompareStartEx(short core, short crd, short fifo, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdBufCommandDelay(short core, short crd, short fifo, short enable);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosCompareStopEx(short core, short crd, short fifo, short index);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdHsPrm(short core, short crd, short fifo, out short pEnable, out short pLink, out ushort pThreshold, out short pLookAheadInMc);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPrfPosEx(short core, short profile, double pos);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDiBit(short core, short diType, short diIndex, out short pValue);

	//	public struct TMpgInfo
	//	{
	//		public double pos;
	//		public double vel;
	//		public double reserve1;
	//		public double reserve2;
	//		public int di;
	//		public int reserve1_1;
	//		public int reserve1_2;
	//		public int reserve1_3;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadMpgInfo(short core, short mpg, out TMpgInfo pMpgInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteMpgPos(short core, short mpg, ref double pPos, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadAuEncPos(short core, short encoder, out double pPos, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteAuEncPos(short core, short encoder, ref double pPos, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DeleteEvent(short core, short eventIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DeleteTask(short core, short taskIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DeleteEventTaskLink(short core, short linkIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetEvent(short core, ref TEvent pEvent, short eventIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTask(short core, short taskType, IntPtr pTaskData, short taskIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetEventTaskLink(short core, short eventIndex, short taskIndex, short linkIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearMcStatus(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMcInfo(short core, int info, int index, uint data);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMcInfo(short core, int info, int index, out uint cpData);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetRNMasterInfo(short core, out ushort pPhyId, out ushort pType, out ushort pInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetRNMasterInfo(short core, ushort phyId, ushort type, ushort info);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_MltPcPduRd(short core, string pData, byte des_id, ushort byte_start_offset, ushort byte_num);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_MltPcPduRdUpdate(short core, byte des_id);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_MltPcPduWr(short core, string pData, byte des_id, ushort byte_start_offset, ushort byte_num);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_MltPcPduWrUpdate(short core, byte des_id);

	//	public struct TLaserStatus
	//	{
	//		public short run;
	//		public short mode;
	//		public double power;
	//		public double frequency;
	//		public double pulseWidth;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
	//		public double[] pad1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public short[] pad2;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLaserStatus(short core, short channel, out TLaserStatus pStatus);


	//	//***************************************************************************************指令流指令开始*************************************************************************
	//	public const short WATCH_VAR_GPI = 31000;
	//	public const short WATCH_VAR_LIMIT_POSITIVE = 31010;
	//	public const short WATCH_VAR_LIMIT_NEGATIVE = 31020;
	//	public const short WATCH_VAR_ALARM = 31030;
	//	public const short WATCH_VAR_HOME = 31040;
	//	public const short WATCH_VAR_ARRIVE = 31050;
	//	public const short WATCH_VAR_BANK_GPI = 31060;

	//	public const short WATCH_VAR_GPO = 32000;
	//	public const short WATCH_VAR_ENABLE = 32010;
	//	public const short WATCH_VAR_CLEAR = 32020;
	//	public const int WATCH_VAR_AI = 33000;
	//	public const int WATCH_VAR_AO = 34000;

	//	public const short COORD_SYSTEM_PCS = 0;
	//	public const short ORI_MODE_NONE = 0;
	//	public const short BLEND_MODE_NONE = 0;
	//	public const short BLEND_MODE_ARC = 1;
	//	public const short BLEND_MODE_BIARC = 2;
	//	public const short BLEND_PARA_TYPE_ERROR = 0;
	//	public const short BLEND_PARA_TYPE_RADIUS = 1;
	//	public const short BLEND_PARA_TYPE_DISTANCE = 2;
	//	//运动模式
	//	public const short PROFILE_MODE_NONE = -1;
	//	public const short PROFILE_MODE_TRAP = 0;
	//	public const short PROFILE_MODE_JOG = 1;
	//	public const short COORD_SYSTEM_ACS = 2;
	//	public const short COORD_SYSTEM_MCS = 1;
	//	public const short VEL_MODEPERCENT = 1;
	//	public const short ORI_PROFILE_MODE_FOLLOW = 0;
	//	public const short ORI_PROFILE_MODE_UNCHANGE = 1;
	//	public const short ORI_PROFILE_MODE_ROTATE = 2;
	//	public const short KIN_TYPE_ORTHOGONAL = 0;
	//	public const short MC_GROUP = 500;
	//	public const short MC_LIST = 700;
	//	public const short MOVE_SYNCHRONIZATION_MODE_GEAR_POS = 3;
	//	public const short MC_GROUP_SYNTHESIS = 505;
	//	public const short OVERRIDE_TYPE_VEL = 0;
	//	public const short VEL_PROFILE_MODE_SMOOTH = 40;
	//	public const short VEL_BLEND_MODE_NONE = 0;      // 不进行速度blending，以第一段的速度过渡，且不进行轨迹blending
	//	public const short VEL_BLEND_MODE_BUFFERER = 1;      // 减速到0，且不进行轨迹blending
	//	public const short VEL_BLEND_MODE_LOW = 2;      // 以两段中最低的速度过渡，根据轨迹blending参数进行轨迹过渡
	//	public const short VEL_BLEND_MODE_PREVIOUS = 3;     // 以第一段的速度过渡，根据轨迹blending参数进行轨迹过渡
	//	public const short VEL_BLEND_MODE_NEXT = 4;    // 以第二段的速度过渡，根据轨迹blending参数进行轨迹过渡
	//	public const short VEL_BLEND_MODE_HIGH = 5;     // 以两段中最高的速度过渡，根据轨迹blending参数进行轨迹过渡
	//	public const short VEL_PROFILE_MODE_TRAP = 1;

	//	public const short VEL_PROFILE_MODE_SMOOTH_EX = 41;
	//	public const short VEL_PROFILE_MODE_JERK = 46;
	//	public const short DRIVER_TORQUE_LIMIT_VALID = 1;
	//	public const short DRIVER_TORQUE_POSITIVE_LIMIT_VALID = 2;
	//	public const short DRIVER_TORQUE_NEGATIVE_LIMIT_VALID = 3;
	//	public const short DRIVER_TORQUE_POSITIVE_AND_NEGATIVE_LIMIT_VALID = 4;

	//	public const short DRIVER_TORQUE_CHECK_PRM_MODE1_PRM_VALID = 1;// 全部参数生效
	//	public const short DRIVER_TORQUE_CHECK_PRM_MODE2_PRM_VALID = 2;// enable和targetTorque生效
	//	public const short DRIVER_TORQUE_CHECK_PRM_MODE3_PRM_VALID = 3;// arrivalBand、arrivalTime、k和torqueCoefficient这些一般设置一次的参数生效
	//	public const short DRIVER_TORQUE_CHECK_PRM_MODE4_PRM_VALID = 4;//enable和targetTorquedir生效

	//	public const short PORT_A_GENERAL_GLINK_II = 1;
	//	public const short PORT_B_GENERAL_GLINK_II = 2;
	//	public const short PORT_C_HIGH_SPEED_GLINK_II = 3;
	//	public const short PORT_D_ETHER_CAT = 4;


	//	public const short DIGITAL_OUTPUT_MODE_NORMAL = 0;
	//	public const short DIGITAL_OUTPUT_MODE_REVERSE_TIME = 10;

	//	public struct TGroupStatus
	//	{
	//		public short run;
	//		public short state;
	//		public short stopInfo;
	//		public short reserve1;
	//		public short reserve2;
	//		public short reserve3;
	//		public short reserve5;
	//		public short reserve6;
	//		public short reserve7;
	//		public short reserve8;
	//		public short reserve9;
	//		public short reserve10;
	//		public short reserve11;
	//		public short reserve12;
	//		public short reserve13;
	//		public long reserve21;
	//		public long reserve22;
	//		public long reserve23;
	//		public long reserve24;
	//	}

	//	public struct TGroupMoveParameter
	//	{
	//		public double velocity;
	//		public double acceleration;
	//		public double reserve1;
	//		public double reserve2;
	//		public double reserve3;
	//		public double deceleration;
	//		public short overrideSelect;
	//		public short endVelocityMode;
	//		public short orientationDir;
	//		public int reserve21;
	//		public int reserve22;
	//		public int reserve23;
	//		public int reserve31;
	//		public int reserve32;
	//		public int reserve33;
	//	}

	//	public struct TMoveAbsolutePrmEx
	//	{
	//		public int pos; /*目标位置*/
	//		public double vel; /*最大速度*/
	//		public double acc; /*加速度，单位pulse/ms2*/
	//		public double dec; /*减速度，单位pulse/ms2*/
	//		public short percent; /*S曲线百分比*/
	//		public double velStart; /*起点速度，单位pulse/ms*/
	//		public double velEnd; /*终点速度，单位pulse/ms*/
	//		public double accStartPercent; /*加速段起始加速度百分比*/
	//		public double decEndPercent; /*减速段终点加速度百分比*/
	//	}

	//	public struct TMoveVelocityPrm
	//	{
	//		public double vel; /*目标速度*/
	//		public double acc; /*加速度，单位pulse/ms2*/
	//		public double dec; /*减速度，单位pulse/ms2*/
	//		public double jerkBegin; /*起始jerk，单位pulse/ms3*/
	//		public double jerkEnd; /*到达目标速度时的jerk，单位pulse/ms3*/
	//		public short direction; /*运动方向*/
	//	}

	//	public struct TListInfo
	//	{
	//		public short list;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;
	//		public short modal;
	//		public int segNum;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve2;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve3;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GroupEnable(short core, short group, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupProfileCoordinateSystem(short core, short group, short coordSystem, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearCommandListData(short core, short list, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMcMode(short core, short mode, short value);
	//	//[DllImport("gxn.dll")]
	//	//public static extern short GTN_MultiMovePosTwoSegment(short core,ref TMultiMovePosTwoSegmentParameter pMovePos, short count = 1,ref TListInfo pListInfo , short group = 0);

	//	/*-----------------------------------------------------------*/
	//	/* MovePos                                                   */
	//	/*-----------------------------------------------------------*/
	//	public struct TMovePosPercent
	//	{
	//		public short value;
	//	};

	//	public struct TMovePosSmoothTime
	//	{
	//		public short value;
	//	};

	//	[StructLayout(LayoutKind.Explicit)]
	//	public struct TMovePosUnion
	//	{
	//		[FieldOffset(0)]
	//		public TMovePosPercent percent;
	//		[FieldOffset(1)]
	//		public TMovePosSmoothTime smoothTime;
	//		//[FieldOffset(2)]
	//		//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		//public double[] value;
	//	};

	//	public struct TMovePosParameter
	//	{
	//		public double pos;
	//		public double vel;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short pad;
	//		public short mode;
	//		public TMovePosUnion data;
	//	};

	//	public struct TMovePosTwoSegmentParameter
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] pos;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] vel;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short pad;
	//		public short mode;
	//		public TMovePosUnion data;
	//	};

	//	public struct TMultiMovePosParameter
	//	{
	//		public short profile;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad1;
	//		public double pos;
	//		public double vel;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short pad2;
	//		public short mode;
	//		public TMovePosUnion data;
	//	};

	//	public struct TMultiMovePosTwoSegmentParameter
	//	{
	//		public short profile;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] pos;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] vel;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short pad2;
	//		public short mode;
	//		public TMovePosUnion data;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WaitForCondition(short core, ref TWatchCondition pWatchCondition, short conditionCount, short operation, ref TWaitTimeout pTimeout, ref TListInfo pListInfo);

	//	public struct TWatchCondition
	//	{
	//		public TWatchVar var;
	//		public ushort condition;
	//		public double value;
	//	};
	//	public struct TWaitTimeout
	//	{
	//		public int time;
	//		public short mode;
	//		public short reservel;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve2;
	//	}

	//	public struct TCartesianParameter
	//	{
	//		public double transX;
	//		public double transY;
	//		public double transZ;
	//		public double rotAngle1;
	//		public double rotAngle2;
	//		public double rotAngle3;
	//	}
	//	public struct TCommandListStatus
	//	{
	//		public short execute;
	//		public short empty;
	//		public short stopInfo;
	//		public short reserve11;
	//		public short reserve12;
	//		public short commandType;
	//		public short command;
	//		public short direction;
	//		public long executeSegNum;
	//		public long remainderSegCount;
	//		public long userTag;
	//		public long reserve21;
	//		public long reserve22;
	//		public long reserve23;
	//		public long reserve24;
	//		public long reserve25;
	//	}
	//	public struct TCommandInfoData
	//	{
	//		public uint commandCode;                   //日志的指令字
	//		public short commandRtn;                               //2word对齐
	//		public short errorCode;
	//		public uint clockTime;                      //控制器的时钟
	//		public int segmentNum;                            //段号
	//		public int userTag;                               //用户标签
	//		public short dataLength;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 225)]
	//		public ushort[] data16;  //
	//	};                   //结构体总大小注意DWord对齐
	//	public struct TVelBlendingParameter
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//		public double[] data;
	//	};

	//	[StructLayout(LayoutKind.Explicit)]
	//	public struct TBlendingParameter
	//	{
	//		[FieldOffset(0)]
	//		public TPathBlendingParameter pathBlendingPrm;
	//		[FieldOffset(0)]
	//		public TVelBlendingParameter velBlendingPrm;
	//		[FieldOffset(0)]
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//		//[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I2)]
	//		public double[] data;
	//	};

	//	public struct TGroupBlendingParameter
	//	{
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve;
	//		public TBlendingParameter prm;
	//	};
	//	public struct TGroupBlendingParameterPathBlendingPrm
	//	{
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve;
	//		// public TBlendingParameter prm;
	//		public TPathBlendingParameter pathBlendingPrm;
	//	}
	//	public struct TVelPathBlendingParameter
	//	{
	//		public short blendType;                   // 速度blending的类型
	//		public short prmType;                     // 参数类型
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	//		public short[] reserve;
	//		public short percentMode;                 // 速度百分比模式，0：过渡速度为由blendType决定的速度，1：过渡速度为由blendType决定的速度*设置的百分比。
	//		public double percent;                    // 速度百分比，在percentMode为1时生效，范围：[0,1]。
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
	//		public double[] prm;
	//	}
	//	public struct TGroupBlendingParameterVelPathBlendingPrm
	//	{
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve;
	//		// public TBlendingParameter prm;
	//		public TVelPathBlendingParameter velBlendingPrm;

	//	}

	//	public struct TDoReverseParameter
	//	{
	//		public double time;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
	//		public double[] reserve;
	//	};

	//	public struct TDigitalOutputModeStruct
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//		public double[] data;
	//	};

	//	//联合体的定义，但是此处加了屏蔽的代码，软件运行起来会崩溃，因此暂时不加,暂时不影响使用
	//	[StructLayout(LayoutKind.Explicit)]
	//	public struct TDigitalOutputMode
	//	{
	//		[FieldOffset(0)]
	//		public TDoReverseParameter doReverse;
	//		//[FieldOffset(0)]
	//		//[MarshalAs(UnmanagedType.ByValArray,SizeConst = 10)]
	//		//public double[] data;
	//	};


	//	//public struct TDoReverseParameter
	//	//{
	//	//    public double time;
	//	//    [MarshalAs(UnmanagedType.ByValArray,SizeConst = 9)]
	//	//    public double[] reserve;
	//	//};

	//	public struct TAtParameter
	//	{
	//		public double distance;
	//		public double delayTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] reserve;
	//	};

	//	public struct TPsoParameter
	//	{
	//		public double distance;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
	//		public double[] reserve;
	//	};

	//	public struct TTsoParameter
	//	{
	//		public double time;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
	//		public double[] reserve;
	//	};

	//	public struct TWriteDigitalOutputMode
	//	{
	//		public TAtParameter atPrm;
	//		public TPsoParameter psoPrm;
	//		public TTsoParameter tsoPrm;
	//		public TDoReverseParameter doReverse;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//		public double[] data;
	//	};

	//	public unsafe struct TDigitalOutput
	//	{
	//		public short mode;              //Do输出模式
	//		public short doType;
	//		public short doIndex;
	//		public short doCount;
	//		//short *pValue;
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;
	//		public TWriteDigitalOutputMode prm;
	//	};

	//	//重载结构体
	//	public unsafe struct TDigitalOutputReloadAtPrm
	//	{
	//		public short mode;
	//		public short doType;
	//		public short doIndex;
	//		public short doCount;
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;
	//		public TAtParameter atPrm;
	//	};

	//	public unsafe struct TDigitalOutputReloadPsoPrm
	//	{
	//		public short mode;
	//		public short doType;
	//		public short doIndex;
	//		public short doCount;
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;
	//		public TPsoParameter psoPrm;
	//	}

	//	public unsafe struct TDigitalOutputReloadTsoPrm
	//	{
	//		public short mode;
	//		public short doType;
	//		public short doIndex;
	//		public short doCount;
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;
	//		public TTsoParameter tsoPrm;
	//	}

	//	public unsafe struct TDigitalOutputReloadDoReverse
	//	{
	//		public short mode;
	//		public short doType;
	//		public short doIndex;
	//		public short doCount;
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;
	//		public TDoReverseParameter doReverse;
	//	}


	//	public struct TDigitalOutputBit
	//	{
	//		public short mode;              //Do输出模式
	//		public short doType;
	//		public short doIndex;
	//		public short doValue;
	//		public short reverseTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve;
	//		public TWriteDigitalOutputMode prm;
	//	};

	//	//重载结构体
	//	public struct TDigitalOutputBitReloadAtPrm
	//	{
	//		public short mode;              //Do输出模式
	//		public short doType;
	//		public short doIndex;
	//		public short doValue;
	//		public short reverseTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve;
	//		public TAtParameter atPrm;

	//	};
	//	public struct TDigitalOutputBitReloadPsoPrm
	//	{
	//		public short mode;              //Do输出模式
	//		public short doType;
	//		public short doIndex;
	//		public short doValue;
	//		public short reverseTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve;
	//		public TPsoParameter psoPrm;

	//	};
	//	public struct TDigitalOutputBitReloadTsoPrm
	//	{
	//		public short mode;              //Do输出模式
	//		public short doType;
	//		public short doIndex;
	//		public short doValue;
	//		public short reverseTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve;
	//		public TTsoParameter tsoPrm;

	//	};
	//	public struct TDigitalOutputBitReloadDoReverse
	//	{
	//		public short mode;              //Do输出模式
	//		public short doType;
	//		public short doIndex;
	//		public short doValue;
	//		public short reverseTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve;
	//		public TDoReverseParameter doReverse;
	//	};

	//	public struct TDelay
	//	{
	//		public double delayTime;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] reserve3;
	//	};
	//	public struct TDigitalOutputProByMoveDistance
	//	{
	//		public short type;                  // type=0:距离起点distance后Do输出；type=1:距离终点distance时Do输出
	//		public short motionType;            // 保留，必须为0，目前只支持插补运动指令，
	//		public int delayTime;             // 保留，必须为0

	//		public double distance;         // 运动distance后Do输出，单位mm
	//	};

	//	public struct TDigitalOutputProByMoveTime
	//	{
	//		public short type;                  // type=0:开始运动后延时delayTime后Do输出；type1:运动结束前提前delayTimeDo输出
	//		public short motionType;            // 保留，必须为0，目前只支持插补运动指令，
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;            // 保留，必须为0
	//		public double delayTime;            // 时间,单位ms
	//	};

	//	public struct TDigitalOutputProDelay
	//	{
	//		public double time;             // 延时输出的时间，单位ms
	//	};

	//	public struct TWriteDigitalOutputProPrmUnion
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
	//		public double[] data;
	//		public TDigitalOutputProDelay delay;                    // 纯延时输出
	//		public TDigitalOutputProByMoveDistance moveDistance;  // 开始运动后，根据运动距离输出。
	//		public TDigitalOutputProByMoveTime moveTime;            // 开始运动后，根据运动时间输出。

	//	};
	//	public struct TDigitalOutputPro
	//	{
	//		// Do输出模式:
	//		// 模式1：延时输出;
	//		// 模式2：执行下一条插补指令时，按照设定的距离段前延迟输出或者段末提前输出;
	//		// 模式3：执行下一条插补指令时，按照设定的时间段前延迟输出或者段末提前输出;
	//		public short mode;              // Do输出模式
	//		public short doType;             // Do类型
	//		public short doIndex;            // Do索引
	//		public short doCount;            // Do输出个数
	//										 //short *pValue;			 // Do输出值，
	//		public IntPtr pValue;

	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;         // 保留，必须为0
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;         // 保留，必须为0
	//		public TWriteDigitalOutputProPrmUnion prm;
	//	};

	//	//重载结构体

	//	public struct TDigitalOutputProReloadDelay
	//	{
	//		// Do输出模式:
	//		// 模式1：延时输出;
	//		// 模式2：执行下一条插补指令时，按照设定的距离段前延迟输出或者段末提前输出;
	//		// 模式3：执行下一条插补指令时，按照设定的时间段前延迟输出或者段末提前输出;
	//		public short mode;              // Do输出模式
	//		public short doType;             // Do类型
	//		public short doIndex;            // Do索引
	//		public short doCount;            // Do输出个数
	//										 //short *pValue;			 // Do输出值，
	//										 //public unsafe short* pValue; 
	//										 //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	//										 //public Int16[] pValue;
	//										 //public short *pValue;
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;         // 保留，必须为0
	//										 //public short reserve2;		 // 保留，必须为0
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;       // 保留，必须为0
	//									 //public Int32 reserve4;		 // 保留，必须为0
	//		public TDigitalOutputProDelay delay;                    // 纯延时输出

	//	};
	//	public struct TDigitalOutputProReloadMoveTime
	//	{
	//		// Do输出模式:
	//		// 模式1：延时输出;
	//		// 模式2：执行下一条插补指令时，按照设定的距离段前延迟输出或者段末提前输出;
	//		// 模式3：执行下一条插补指令时，按照设定的时间段前延迟输出或者段末提前输出;
	//		public short mode;              // Do输出模式
	//		public short doType;             // Do类型
	//		public short doIndex;            // Do索引
	//		public short doCount;            // Do输出个数
	//										 //short *pValue;			 // Do输出值，
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;         // 保留，必须为0
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;       // 保留，必须为0
	//		public TDigitalOutputProByMoveTime moveTime;            // 开始运动后，根据运动时间输出。

	//	};

	//	public struct TDigitalOutputProReloadMoveDistance
	//	{
	//		// Do输出模式:
	//		// 模式1：延时输出;
	//		// 模式2：执行下一条插补指令时，按照设定的距离段前延迟输出或者段末提前输出;
	//		// 模式3：执行下一条插补指令时，按照设定的时间段前延迟输出或者段末提前输出;
	//		public short mode;              // Do输出模式
	//		public short doType;             // Do类型
	//		public short doIndex;            // Do索引
	//		public short doCount;            // Do输出个数
	//										 //short *pValue;			 // Do输出值，
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;         // 保留，必须为0
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] reserve2;       // 保留，必须为0
	//		public TDigitalOutputProByMoveDistance moveDistance;  // 开始运动后，根据运动距离输出。
	//	};
	//	//MoveJog
	//	public const short MOVE_JOG_MODE_GENERAL = 0;

	//	public struct TJogParameter
	//	{
	//		public short overrideSelect;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve1;
	//		public double vel;
	//		public double acc;
	//		public double dec;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
	//		public short[] reserve;
	//	};

	//	public struct TMoveJogPrmUnion
	//	{
	//		public TJogParameter jog;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	//		public short[] reserve;
	//	};

	//	public struct TMoveJogPrm
	//	{
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve;
	//		public TMoveJogPrmUnion data;
	//	};

	//	//重载函数指令
	//	public struct TMoveJogPrmReloadJog
	//	{
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve;
	//		public TJogParameter jog;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupCartesianTransform(short core, short group, short coordSystem, short enable, ref TCartesianParameter pPrm, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupCommandPosDefine(short core, short group, short coordSystem, short orientationMode, short configIndex, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGroupCommandPosDefine(short core, short group, out short coordSystem, out short orientationMode, out short configIndex);

	//	[DllImport("gts.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	//	public static extern short GTN_MoveLinearAbsolute(short core, short group, ref double pos, ref short dir, ref TGroupMoveParameter pPrm, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveJog(short core, short index, ref TMoveJogPrm pPrm, ref TListInfo pListInfo, short group = 0);
	//	/*short GTN_MoveLinearAbsolute(short core,short group,double pos[],short dir[],TGroupMoveParameter *pPrm,TListInfo *pListInfo=NULL) */
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteDigitalOutputPro(short core, ref TDigitalOutputPro pDoPro, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteDigitalOutput(short core, ref TDigitalOutput pDoBit, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CommandListDataEnd(short core, short list);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGroupStatus(short core, short group, out TGroupStatus pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCommandListStatus(short core, short list, out TCommandListStatus pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGroupProfilePos(short core, short group, short index, out double pValue, short count = 1, short coordSystem = COORD_SYSTEM_ACS, short oriMode = ORI_MODE_NONE);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLastCommandError(short core, out TCommandInfoData pCommandData, int start, int count);


	//	//public struct TCallbackEventType

	//	//{
	//	//    public Int16 motionMode;
	//	//    public Int16 index;
	//	//    public Int16 id;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//	//    public Int16[] reserve;
	//	//    public Int16 eventNumber;
	//	//}
	//	//public struct TCallbackEventStatus
	//	//{

	//	//    public Int16 count;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	//	//    public TCallbackEventType [] eventType;

	//	//}
	//	public struct TCallbackEventType
	//	{
	//		public short motionMode;
	//		public short index;
	//		public short id;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public short[] reserve;
	//		public short eventNumber;
	//	}
	//	public struct TCallbackEventStatus
	//	{
	//		public short count;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	//		public TCallbackEventType[] eventType;
	//	}

	//	[DllImport("gts.dll")]

	//	public static extern short GTN_RegisterCallbackFunction(short core, IntPtr fun);
	//	//public delegate void TCallbackFunction(short[] data);


	//	//[DllImport("gxn.dll")] public static extern short GTN_RegisterCallbackFunction(short core, TCallbackFunction callbackFunction);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisScale(short core, short profile, ref TProfileScale pScale, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisScale(short core, short profile, out TProfileScale pScale);
	//	public struct TProfileScale
	//	{
	//		public short count;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] alpha;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] beta;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisMotionConstraint(short core, short axis, ref TAxisMotionConstraint pPrm, ref TListInfo pListInfo);

	//	public const int WATCH_VAR_USER_VAR_INT32 = 52027;
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMcVarEx(short core, ref TWatchVar pVar, ref double pValue, short count, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMcVarEx(short core, out TWatchVar pVar, out double pValue, short count);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMcVar(short core, ref TWatchVar pVar, double pValue, ref TListInfo pListInfo);

	//	//[DllImport("gxn.dll")]
	//	//public static extern short GTN_GetMcVar(short core, out TWatchVar pVar, out double pValue, short count);

	//	//public const short MOTION_PROGRAM_CLEAR_ALL_TASK = 1;
	//	//public const short MOTION_PROGRAM_MODE_RELEASE = 1;

	//	//lua启动脚本语言
	//	public const short MOTION_PROGRAM_CLEAR_ALL_TASK = 1;
	//	public const short MOTION_PROGRAM_CLEAR_TASK = 2;
	//	public const short MOTION_PROGRAM_CLEAR_FILE = 3;

	//	public const short MOTION_PROGRAM_MODE_DEBUG = 0;
	//	public const short MOTION_PROGRAM_MODE_RELEASE = 1;

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StopMP(short core, short task);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearMp(short core, short mode, short task);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_DownLoadFileMP(short core, string pFileMpName);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BindMP(short core, short task, string pFileMpName);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RunMP(short core, short task, short mode);


	//	public struct TAxisMotionConstraint
	//	{
	//		public double velMax;
	//		public double accMax;
	//		public double decMax;
	//		public double jerkMax;
	//		public double dvMax;
	//		public short reverseLimitMode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] reserve2;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisMotionConstraint(short core, short axis, out TAxisMotionConstraint pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCommandListConfig(short core, short list, ref TCommandListConfig pConfig);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCommandListConfig(short core, short index, out TCommandListConfig pConfig);


	//	public struct TCommandListConfig
	//	{
	//		public short mode;
	//		public short elementSize;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public short[] reserve1;
	//		public int forwardSpace;//long从C++移植到C#中用int32
	//		public int reverseSpace;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public int[] reserve2;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCommandListLinkGroup(short core, short list, out uint pLinkGroupMask);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCommandListLinkGroup(short core, short list, uint linkGroupMask);
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_UngroupAllAxes(short core, short group, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]

	//	public static extern short GTN_GroupDisable(short core, short group, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AddAxisToGroup(short core, short group, short profile, short identInGroup, ref TListInfo pListInfo);

	//	//public struct TRobotKinematicParameter
	//	//{
	//	//    public Int16 type;
	//	//    public Int16 subType;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//	//    public Int16[] dir;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//	//    public Int16[] reserve1;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//	//    public double[] prm;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//	//    public double[] offset;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//	//    public Int32[] reserve2;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
	//	//    public double[] reserve3;
	//	//};

	//	//public struct TFiveAxisKinematicParameter
	//	//{
	//	//    public Int16 type;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public Int16[] reserve1;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public double[] primaryAxisPoint;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public double[] slaveAxisPoint;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public double[] toolLocationPoint;
	//	//    public Int16 dirMode;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//	//    public Int16[] reserve2;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	//	//    public Int16[] dir;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5 * 3)]
	//	//    public double[,] axisVector;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//	//    public Int32[] reserve3;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	//	//    public double[] reserve4;
	//	//};

	//	//public struct TMultiAxisKinematicParameter
	//	//{
	//	//    public Int16 axisCount;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public Int16[] reserve1;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//	//    public Int32[] reserve2;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	//	//    public double[] reserve3;
	//	//};

	//	//[StructLayout(LayoutKind.Explicit)]
	//	//public struct TKinematicParameter
	//	//{
	//	//    [FieldOffset(0)]
	//	//    public TRobotKinematicParameter robot;
	//	//    [FieldOffset(0)]
	//	//    public TFiveAxisKinematicParameter fiveAxis;
	//	//    [FieldOffset(0)]
	//	//    public TMultiAxisKinematicParameter multiAxis;
	//	//    [FieldOffset(0)]
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	//	//    public double[] data;
	//	//};

	//	//public struct TKinematicTransform
	//	//{
	//	//    public Int16 type;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public Int16[] reserve;
	//	//    public TKinematicParameter kinPrm;
	//	//};

	//	//public struct TKinematicTransformMultiAxis
	//	//{
	//	//    public Int16 type;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public Int16[] reserve;
	//	//    // public TKinematicParameter kinPrm;
	//	//    //[FieldOffset(0)]
	//	//    public TMultiAxisKinematicParameter multiAxis;
	//	//};
	//	//[DllImport("gts.dll")]
	//	//public static extern short GTN_SetGroupKinematicTransform(Int16 core, Int16 group, ref TKinematicTransform pTransform, ref TListInfo pListInfo);


	//	//[Serializable]
	//	//[structLayoutAttribute(LayoutKind.Sequential,CharSet=CharSet.Ansi,Pack=1)]
	//	//[StructLayout(LayoutKind.Sequential)]
	//	public struct TAnalogOutput
	//	{
	//		public short aoType;
	//		public short aoIndex;
	//		public short count;
	//		public short reserve1;
	//		// [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	//		public IntPtr pValue;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public int[] reserve2;


	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteAnalogOutput(short core, ref TAnalogOutput pAo, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadAnalogInput(short core, short adctype, short adcindex, out double pvalue, short adccount);
	//	//[DllImport("gts.dll")]
	//	//public static extern short GTN_SetGroupKinematicTransform(Int16 core, Int16 group, ref TKinematicTransformMultiAxis pTransform, ref TListInfo pListInfo);

	//	//[DllImport("gts.dll")]
	//	//public static extern short GTN_GetGroupKinematicTransform(Int16 core, Int16 group, out TKinematicTransform pTransform);

	//	public struct TParallelParameter
	//	{
	//		public short subType;
	//		public short axisCount;
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] majorAxis;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public short[] parallelAxis;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//		public long[] reserve2;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
	//		public double[] reserve3;
	//	}


	//	[DllImport("gts.dll")]

	//	public static extern short GTN_GetGroupMotionConstraint(short core, short group, out TGroupMotionConstraint pPrm);

	//	public struct TGroupMotionConstraint
	//	{
	//		public double velMax;
	//		public double accMax;
	//		public double decMax;
	//		public double jerkMax;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//		public double[] reserve;
	//	}
	//	public struct TVelProfileModeSmooth
	//	{
	//		public double accTime;
	//		public double k;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
	//		public double[] reserve;
	//	};

	//	public struct TVelProfileModeJerk
	//	{
	//		public double value;
	//		public double beginPercent;
	//		public double endPercent;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
	//		public double[] reserve;
	//	};

	//	[StructLayout(LayoutKind.Explicit)]
	//	public struct TVelProfileModeParameter
	//	{
	//		[FieldOffset(0)]
	//		public TVelProfileModeSmooth smooth;
	//		[FieldOffset(0)]
	//		public TVelProfileModeJerk jerk;
	//		[FieldOffset(0)]
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//		public double[] data;
	//	};

	//	public struct TVelProfileMode
	//	{
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve;
	//		public TVelProfileModeParameter parameter;

	//	};
	//	public struct TVelProfileSmoothMode
	//	{
	//		public short mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve1;

	//		public TVelProfileModeSmooth smooth;
	//	};

	//	[DllImport("gts.dll")]

	//	public static extern short GTN_SetGroupMotionConstraint(short core, short group, ref TGroupMotionConstraint pPrm, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	// public static extern short GTN_SetGroupVelProfileMode(short core, short group,ref TVelProfileMode pSmooth, ref TListInfo pListInfo);
	//	public static extern short GTN_SetGroupVelProfileMode(short core, short group, ref TVelProfileSmoothMode pSmooth, ref TListInfo pListInfo);
	//	//    public struct TVelProfileMode
	//	//    {
	//	//        public short mode;
	//	//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//        public short[] reserve;
	//	//        public TVelProfileModeParameter parameter;
	//	//}
	//	//    public struct TVelProfileModeParameter
	//	//    {
	//	//        public TVelProfileModeSmooth smooth;
	//	//        public TVelProfileModeJerk jerk;
	//	//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//	//        public double[] data;
	//	//}
	//	//    public struct TVelProfileModeSmooth
	//	//    {
	//	//        public double accTime;
	//	//        public double k;
	//	//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//	//        public double[] reserve;
	//	//}
	//	//    public struct TVelProfileModeJerk
	//	//    {
	//	//        public double value;
	//	//        public short beginPercent;
	//	//        public short endPercent;
	//	//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//	//        public short[] reserve;
	//	//}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGroupVelProfileMode(short core, short group, out TVelProfileSmoothMode pSmooth);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupStopParameter(short core, short group, short type, ref TGroupStopParameter pPrm, ref TListInfo pListInfo);

	//	public struct TGroupStopParameter
	//	{
	//		public double deceleration;
	//		public double jerk;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	//		public double[] reserve2;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGroupStopParameter(short core, short group, short type, out TGroupStopParameter pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteDigitalOutputBit(short core, ref TDigitalOutputBit pDoBit, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadDigitalInput(short core, short diType, short diIndex, out short pValue, short diCount);

	//	public struct TGearPosParameter
	//	{
	//		public double pos;
	//		public double masterLength;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
	//		public short[] reserve;
	//	}
	//	public struct TMoveSynchtonizationUnionGearPosPrm
	//	{

	//		public TGearPosParameter gear;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	//		public short[] reserve;
	//	}
	//	public struct MoveSynchronizationPrmGearPosPrm
	//	{
	//		public short mode;  //同步模式

	//		public short enable;
	//		public short softDirCheck;
	//		public short reverse;
	//		public TGearPosParameter gear;
	//		// [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	//		//public short[] reserve;
	//		//public TMoveSynchtonizationUnionGearPosPrm prm;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupMaxOverride(short core, short group, short type, double overridex, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetGroupMaxOverride(short core, short group, short type, out double overridex);

	//	[DllImport("gts.dll")]

	//	//  public static extern short GTN_MoveSynchronization(short core,ref TProfileItem slave,ref TProfileItem master,ref TMoveSynchronizationPrm pPrm,ref TListInfo pListInfo);
	//	public static extern short GTN_MoveSynchronization(short core, ref TProfileItem slave, ref TProfileItem master, ref MoveSynchronizationPrmGearPosPrm pPrm, ref TListInfo pListInfo);
	//	public struct TProfileItem
	//	{
	//		public short type;
	//		public short index;
	//		public short subIndex;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	//		public short[] reserve;
	//	}

	//	public struct TMoveSynchronizationPrm
	//	{
	//		public short mode; //同步运动模式
	//		public short enable;
	//		public short softDirCheck;
	//		public short reserve;
	//		public TMoveSynchronizationUnion prm;
	//	}
	//	public struct TMoveSynchronizationUnion
	//	{
	//		public TGearParameter gear;
	//		public TMpgParameter mpg;
	//		public TFollowParameter follow;//手册没有
	//		public TGearPosParameter gears;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	//		public short[] reserve;
	//	}
	//	public struct TGearParameter
	//	{
	//		public double masterEven; // 传动比系数：主轴位移
	//		public double slaveEven; // 传动比系数：从轴位移
	//		public double slope; // 离合区位移
	//		public short slopeType;// 离合区位移描述轴，0：主轴，1：从轴
	//		public short dir; // 跟随方向
	//		public short startMode; // 启动模式
	//		public short startPrmType;//启动参数描述轴，0：主轴，1：从轴
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public double[] startPrm; // 启动参数
	//		public double deltaSlaveEven; //对应masterEven的从轴变化量
	//		public double deltaSlope; // 主从比变化时的离合区位移
	//		public short deltaSlopeType; // 主从比变化时的离合区位移描 述轴，0：主轴，1：从轴
	//		public short deltaLoop; // 主从比变化次数，0：无限循环
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//		public short[] reserve2;
	//	}
	//	public struct TMpgParameter
	//	{
	//		public double masterEven; // 传动比系数：主轴位移
	//		public double slaveEven; //传动比系数：从轴位移
	//		public double masterFilterTime;// 主轴滤波时间，单位:ms
	//		public double sampleTime; // 主轴采样时间，单位:ms
	//		public double stopWaitTime; // 停止等待时间，单位:ms
	//		public double acceleration; // 从轴运动加速度，单位:mm/s^2
	//		public double deceleration; // 从轴运动减速度，单位:mm/s^2
	//		public double maxVel; // 从轴运动最大速度，单位:mm/s
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	//		public short[] reserve;
	//	}
	//	public struct TFollowParameter
	//	{
	//		public double masterEven;//传动比主轴，单位是pulse
	//		public double slaveEven;//传动比从轴，单位是mm
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
	//		public short[] reserve;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InsertCallbackEvent(short core, short motionMode, short index, short eventNumber, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDelay(short core, ref TDelay pDelay, ref TListInfo pListInfo);

	//	public struct TMoveContinuousPrm
	//	{
	//		public double pos;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelProfileModeParameter velProfile;
	//	}
	//	[DllImport("gts.dll")]

	//	public static extern short GTN_SetExtModuleAccessMode(short core, short mode);


	//	public struct TVelprofileModeSmooth
	//	{
	//		public double acctime;
	//		public double k;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
	//		public double[] reserve;

	//	}
	//	public struct TMoveContinuousPrmsmooth
	//	{
	//		public double pos;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelprofileModeSmooth velProfile;
	//	}
	//	public struct TMoveContinuousAbsolutePrm
	//	{
	//		public double pos;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelProfileModeParameter profile;
	//	};
	//	//重载
	//	public struct TMoveContinuousAbsolutePrmReloadSmooth
	//	{
	//		public double pos;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelProfileModeSmooth smooth;
	//	};

	//	public struct TMoveContinuousAbsolutePrmReloadJerk
	//	{
	//		public double pos;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelProfileModeJerk jerk;
	//	};

	//	public struct TMoveContinuousRelativePrm
	//	{
	//		public double distance;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelProfileModeParameter velProfile;
	//	};

	//	//重载函数指令
	//	public struct TMoveContinuousRelativePrmReloadSmooth
	//	{
	//		public double distance;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelProfileModeSmooth smooth;
	//	};

	//	public struct TMoveContinuousRelativePrmReloadJerk
	//	{
	//		public double distance;
	//		public double vel;
	//		public double velEnd;
	//		public double acc;
	//		public double dec;
	//		public short direction;
	//		public short overrideSelect;
	//		public short reserve;
	//		public short velProfileMode;
	//		public TVelProfileModeJerk jerk;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveContinuousAbsolute(short core, short profile, ref TMoveContinuousAbsolutePrm pPrm, ref TListInfo pListInfo, short group);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveContinuousAbsolute(short core, short profile, ref TMoveContinuousAbsolutePrmReloadSmooth pPrm, ref TListInfo pListInfo, short group);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveContinuousAbsolute(short core, short profile, ref TMoveContinuousAbsolutePrmReloadJerk pPrm, ref TListInfo pListInfo, short group);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveContinuousRelative(short core, short profile, ref TMoveContinuousRelativePrm pPrm, ref TListInfo pListInfo, short group);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveContinuousRelative(short core, short profile, ref TMoveContinuousRelativePrmReloadSmooth pPrm, ref TListInfo pListInfo, short group);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MoveContinuousRelative(short core, short profile, ref TMoveContinuousRelativePrmReloadJerk pPrm, ref TListInfo pListInfo, short group);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GroupLookAheadEnable(short core, short group, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupLookAheadParameter(short core, short group, ref TGroupLookAheadParameter pPrm, ref TListInfo pListInfo);
	//	//public struct TGroupBlendingParameter
	//	//{
	//	//    public short mode;
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//	//    public short[] reserve;
	//	//    public TBlendingParameter prm;
	//	//}

	//	//public struct TVelBlendingParameter
	//	//{
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//	//    double[] data;
	//	//}



	//	public struct TPathBlendingParameter
	//	{
	//		public short blendType;
	//		public short prmType;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;
	//		public double prm;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] reserve2;
	//		public double minAngle;
	//		public double maxAngle;
	//	}
	//	public struct TGroupLookAheadParameter
	//	{
	//		public int lookAheadNum;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public short[] reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public int[] reserve2;
	//		public double time;
	//		public double radiusRatio;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	//		public double[] reserve3;
	//	};
	//	//[StructLayout(LayoutKind.Explicit)]
	//	//public struct TBlendingParameter
	//	//{
	//	//    [FieldOffset(0)]
	//	//    public TPathBlendingParameter pathBlendingPrm;
	//	//    [FieldOffset(0)]
	//	//    public TVelBlendingParameter velBlendingPrm;
	//	//    [FieldOffset(0)]
	//	//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	//	//    public double[] data;
	//	//};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupBlendingParameter(short core, short group, ref TGroupBlendingParameter pPrm, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupBlendingParameter(short core, short group, ref TGroupBlendingParameterPathBlendingPrm pPrm, ref TListInfo pListInfo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetGroupBlendingParameter(short core, short group, ref TGroupBlendingParameterVelPathBlendingPrm pPrm, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StartCommandList(short core, short list, ref TListInfo pListInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StopCommandList(short core, short list, short stopMode, ref TListInfo pListInfo);




	//	//****************************************************************指令流指令结束********************************************************************************************



	//	/*-----------------------------------------------------------*/
	//	/* New Watch  Code                                           */
	//	/*-----------------------------------------------------------*/
	//	public const short WATCH_MODE_STATIC = 0;
	//	public const short WATCH_MODE_LOOP = 1;
	//	public const short WATCH_MODE_DYNAMIC = 2;

	//	public const short WATCH_MODE_STATIC_BACKGROUND = 10;
	//	public const short WATCH_MODE_LOOP_BACKGROUND = 11;
	//	public const short WATCH_MODE_DYNAMIC_BACKGROUND = 12;

	//	public const short WATCH_EVENT_RUN = 1;
	//	public const short WATCH_EVENT_START = 10;
	//	public const short WATCH_EVENT_STOP = 20;
	//	public const short WATCH_EVENT_OFF = 30;

	//	public const short WATCH_CONDITION_EQ = 1;
	//	public const short WATCH_CONDITION_NE = 2;
	//	public const short WATCH_CONDITION_GE = 3;
	//	public const short WATCH_CONDITION_LE = 4;

	//	public const short WATCH_CONDITION_CHANGE_TO = 11;
	//	public const short WATCH_CONDITION_CHANGE = 12;
	//	public const short WATCH_CONDITION_UP = 13;
	//	public const short WATCH_CONDITION_DOWN = 14;

	//	public const short WATCH_CONDITION_REMAIN_AT = 21;
	//	public const short WATCH_CONDITION_REMAIN = 22;

	//	public const long WATCH_VAR_CLOCK = 1200;
	//	public const long WATCH_VAR_PRF_LOOP = 1201;

	//	public const long WATCH_VAR_COMMAND_CODE = 1220;
	//	public const long WATCH_VAR_COMMAND_DATA = 1221;
	//	public const long WATCH_VAR_COMMAND_COUNT = 1222;
	//	public const long WATCH_VAR_COMMAND_READ_FLAG = 1223;

	//	public const long WATCH_VAR_PRF_POS = 6000;
	//	public const long WATCH_VAR_PRF_VEL = 6001;
	//	public const long WATCH_VAR_PRF_ACC = 6002;

	//	public const long WATCH_VAR_PRF_RUN = 6200;

	//	public const long WATCH_VAR_CRD_PRF_POS = 8000;
	//	public const long WATCH_VAR_CRD_PRF_VEL = 8001;
	//	public const long WATCH_VAR_CRD_PRF_ACC = 8002;

	//	public const long WATCH_VAR_CRD_RUN = 8200;

	//	public const long WATCH_VAR_CRD_SEGMENT_NUMBER = 8202;
	//	public const long WATCH_VAR_CRD_SEGMENT_NUMBER_USER = 8203;
	//	public const long WATCH_VAR_CRD_COMMAND_RECEIVE = 8204;
	//	public const long WATCH_VAR_CRD_COMMAND_EXECUTE = 8205;

	//	public const long WATCH_VAR_CRD_FOLLOW_SLAVE_POS = 8600;
	//	public const long WATCH_VAR_CRD_FOLLOW_SLAVE_VEL = 8601;

	//	public const long WATCH_VAR_CRD_FOLLOW_STAGE = 8610;

	//	public const long WATCH_VAR_SCAN_PRF_POS = 18000;
	//	public const long WATCH_VAR_SCAN_PRF_VEL = 18001;
	//	public const long WATCH_VAR_SCAN_PRF_ACC = 18002;

	//	public const long WATCH_VAR_SCAN_PRF_POS_X = 18010;
	//	public const long WATCH_VAR_SCAN_PRF_POS_Y = 18020;

	//	public const long WATCH_VAR_SCAN_RUN = 18200;

	//	public const long WATCH_VAR_SCAN_SEGMENT_NUMBER = 18202;


	//	public const long WATCH_VAR_LASER_HSIO = 18600;
	//	public const long WATCH_VAR_LASER_POWER = 18601;

	//	public const long WATCH_VAR_AXIS_PRF_POS = 20000;
	//	public const long WATCH_VAR_AXIS_PRF_VEL = 20001;
	//	public const long WATCH_VAR_AXIS_PRF_ACC = 20002;
	//	public const long WATCH_VAR_AXIS_ENC_POS = 20003;

	//	public const long WATCH_VAR_AXIS_PRF_VEL_FILTER = 20011;

	//	public const long WATCH_VAR_ENC_POS = 30000;

	//	public const long WATCH_VAR_ENC_VEL = 30001;

	//	public const long WATCH_VAR_AUTO_FOCUS_OUT = 34006;

	//	public const long WATCH_VAR_TRIGGER_EXECUTE = 38000;
	//	public const long WATCH_VAR_TRIGGER_STATUS = 38001;
	//	public const long WATCH_VAR_TRIGGER_POSITION = 38002;
	//	public const long WATCH_VAR_TRIGGER_COUNT = 38010;

	//	public const long WATCH_VAR_POS_LOOP_ERROR = 40000;

	//	public const long WATCH_VAR_CONTROL_REF_VEL = 41000;

	//	public const long WATCH_VAR_WATCH_TIME = 52001;

	//	public const long WATCH_VAR_INT32 = 52020;
	//	public const long WATCH_VAR_INT64 = 52021;
	//	public const long WATCH_VAR_FLOAT = 52022;
	//	public const long WATCH_VAR_DOUBLE = 52023;
	//	public const long WATCH_VAR_BOOL = 52024;


	//	public struct TWatchVar
	//	{
	//		public ushort type;
	//		public ushort index;
	//		public ushort id;
	//	}

	//	public struct TWatchEvent
	//	{
	//		public ushort type;
	//		public ushort loop;
	//		public ushort watchCount;
	//		public TWatchVar var;
	//		public ushort condition;
	//		public double value;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearWatch(short core, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AddWatchVar(short core, ref TWatchVar pVar);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_AddWatchEvent(short core, ref TWatchEvent pEvent);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WatchOn(short core, short interval, short mode, ushort count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WatchOff(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrintWatch(short core, string pFileName, long start, uint printCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMcVar(short core, out TWatchVar pVar, out double pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetWatchGroup(short core, short group);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetWatchGroup(short core, out short pGroup);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadWatchConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SaveWatchConfig(short core, short group, out char pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadWatch(short core, short varIndex, out double pBuffer, uint bufferSize, out uint pReadCount);

	//	public struct TWatchInfo
	//	{
	//		public short enable;                        // �ɼ�ʹ��
	//		public short run;                           // �ɼ�״̬
	//		public uint time;                   // �ɼ�����
	//		public uint head;                   // ͷָ��
	//		public uint threshold;          // ������ɲɼ�����

	//		public short interval;                      // �ɼ����
	//		public short mode;                          // �ɼ�ģʽ
	//		public ushort countBeforeEvent; // �¼�����֮ǰ�Ĳɼ�����
	//		public ushort countAfterEvent;      // �¼������Ժ�Ĳɼ�����
	//		public ushort varCount;         // �ɼ���������
	//		public ushort eventCount;           // �ɼ��¼�����
	//	}

	//	public struct TWatchVarInfo
	//	{
	//		public uint pAddress;
	//		public ushort length;
	//		public short fraction;
	//		public ushort format;
	//		public ushort hex;
	//		public ushort sign;
	//		public ushort bit;
	//	}

	//	public struct TWatchFormat
	//	{
	//		public short width;
	//		public short precision;
	//		public char seperator;
	//		public short hex;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetWatchInfo(short core, out TWatchInfo pInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetWatchVar(short core, short index, out TWatchVar pVar, out TWatchVarInfo pVarInfo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetWatchEvent(short core, short index, out TWatchEvent pEvent);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetWatchFormat(short core, ref TWatchFormat pFormat);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetWatchFormat(short core, out TWatchFormat pFormat);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadReadHsConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadHsOn(short core, short enable, short mode, double interval);

	//	public struct TAxisArrivePrm
	//	{
	//		public short mode;
	//		public short pad0;
	//		public int band;        //�������жϵ�λ����
	//		public int time;        //�������жϵ�λʱ��
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] pad1;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetStsEx(short core, short axis, out int pSts, short count, out uint pClock);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisArriveMode(short core, short axis, ref TAxisArrivePrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisArriveMode(short core, short axis, out TAxisArrivePrm pPrm);


	//	public struct TCrdStatusEx
	//	{
	//		public short runEmpty;
	//		public int segUseCount;
	//		public int segReceiveCount;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] pad1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public int[] pad2;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public double[] pad3;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdStatusEx(short core, short crd, out TCrdStatusEx pCrdStatus, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdMPGMode(short core, short crd, short enable, short master, int masterEven, int slaveEven, short filterTime, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdMPGMode(short core, short crd, out short pEnable, out short pMaster, out int pMasterEven, out int pSlaveEven, out short pFilterTime, out short pMode, out short pFifoEnd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetReadHs(short core, short enable, short mode, short interval);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadHsReadBuffer(short core, out short pData, int count);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_GeneralCommand(short core, short stationId, int cmdId, int prmSizeCount, IntPtr pPrm, int resultSizeCount, IntPtr pResult);
	//	/*-----------------------------------------------------------*/
	//	/* Encrypt                                           */
	//	/*-----------------------------------------------------------*/

	//	public struct TEncryptOperatePrm
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	//		public byte[] keyValue;     // ԭʼ��Կ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	//		public byte[] randomIn;
	//		public short block;         // �ڼ���block,32bytesһ��block,����
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	//		public byte[] data;         // ��ȡ���Ļ���д��ȥ���µ�����
	//		public short sts;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_WriteUserSlotDataEncrypt(short core, short slotIndex, ref TEncryptOperatePrm pWritePrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadUserSlotDataEncrypt(short core, short slotIndex, out TEncryptOperatePrm pReadPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EncryptionFunConfig(short core, short slotIndex, ref byte pOldKey, ref byte pNewKey, ref byte pUserData, out short pSts, out short pConfigured);

	//	public struct TTriggerProfilePrm
	//	{
	//		public short mode;      //�˶�����,0-��λ��6-PVT������������ʱ��֧��
	//		public short enable;    //�Ƿ�ʹ�ܣ�0-��ʹ�ܣ�1-ʹ��
	//		public short trigger;   //trigger������ȡֵ��1��ʼ
	//		public short pad1;      //����
	//		public int distance;  //����ʱƫ�����������ɸ�����λ������
	//		public int posLimit;  //���¹滮�󣬴���λ��+ƫ�������ܳ�����ֵ
	//		public double vel;      //Ŀ���ٶȣ����¹滮��Ŀ���ٶȣ���λ������/ms
	//		public double acc;      //��Ҫ����ʱ�ļ��ٶȣ���λ������/ms
	//		public double dec;      //�˶�������ƫ�����ļ��ٶȣ���λ������/ms
	//		public double percent;  //���ٶ�S������ʱ��ٷֱȣ�����60��ʾ60%
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve;
	//	};

	//	public struct TTriggerProfileStatus
	//	{
	//		public short mode;
	//		public short enable;
	//		public short execute;           //�Ƿ�ִ����,0-δִ�У�1-ִ��
	//		public short status;            //ִ�й����е�״̬������Ϊ0���쳣�򷵻ش�����
	//		public int endPos;          //�յ�λ�ã�����+ƫ������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	//		public int[] reserve;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTriggerProfilePrm(short core, short profile, ref TTriggerProfilePrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTriggerProfileStatus(short core, short profile, out TTriggerProfileStatus pSts);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LmtsOnEx(short core, short axis, short limitType, short limitMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LmtsOffEx(short core, short axis, short limitType, short limitMode);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrintLogInfo(short core, string pFileName, int start, int count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrintMcStsInfo(short core, string pFileName, short type, short index, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrintCommandInfo(short core, string pFileName, int start, int count);

	//	/*-----------------------------------------------------------*/
	//	/* ILC                                                       */
	//	/*-----------------------------------------------------------*/
	//	public struct TIlcResult
	//	{
	//		public double ErrorMax;
	//		public double ErrorAvg;
	//		public double ErrorRms;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
	//		public double[] pad1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	//		public short[] pad2;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitIlc(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StartIlc(short core, short crd);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StopIlc(short core, short crd, ref TIlcResult pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SaveIlcFile(short core, string pIlcFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadIlcFile(short core, short crd, string filePath);

	//	/*-----------------------------------------------------------*/
	//	/* MovePos                                                   */
	//	/*-----------------------------------------------------------*/
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MovePos(short core, short profile, ref TMovePosParameter pMovePos, ref TListInfo pListInfo, short group = 0);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_MovePosTwoSegment(short core, short profile, ref TMovePosTwoSegmentParameter pMovePos, ref TListInfo pListInfo, short group);

	//	public struct TMotionTimeRestrictDirect
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public short[] condition;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] time;
	//	}

	//	public struct TMotionTimeRestrictAttentionProfile
	//	{
	//		public short condition;
	//		public short attentionProfileCount;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public short[] attentionProfile;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public short[] reserve1;
	//		public double settlingTime;
	//	};


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetWaitForCondition(short core, short list, out TWatchCondition pWatchCondition, out short pConditionCount, short pOperation, out TWaitTimeout pTimeout, out short pConditionResult);
	//	/*-----------------------------------------------------------*/
	//	/* ����                                                      */
	//	/*-----------------------------------------------------------*/
	//	public const short LOOP_MODE_POSITION = 0;      // λ�ñջ�
	//	public const short LOOP_MODE_PRESS = 1;         // ѹ���ջ�
	//	public const short LOOP_MODE_NONE = 2;

	//	public const short PRESS_PROFILE_NONE = 0;      // ����ѹ���ջ�ģʽ�������й滮
	//	public const short PRESS_PROFILE_TARGET = 1;    // ����Ŀ��ѹ��ģʽ
	//	public const short PRESS_PROFILE_ARRAY = 2;     // ����Ŀ��ѹ��ģʽ
	//	public const short PRESS_PROFILE_PERCENT = 3;
	//	public const short PRESS_PROFILE_TABLE = 4;

	//	public const short LIMIT_TYPE_PRESS = 7;
	//	public const short LIMIT_TYPE_TORQUE = 8;
	//	public const short MC_PRESS = 500;
	//	public const short MC_TORQUE = 501;

	//	public const short PRESS_GREATER_THAN_LIMIT = 0;
	//	public const short PRESS_LESS_THAN_LIMIT = 1;

	//	public const short PRESS_DIR_NONE = 0;
	//	public const short PRESS_DIR_CROSS_POSITIVE = 1;
	//	public const short PRESS_DIR_CROSS_NEGATIVE = 2;
	//	public const short PRESS_DIR_CROSS_BOTH = 3;
	//	public const short PRESS_DIR_GE = 4;
	//	public const short PRESS_DIR_LE = 5;

	//	public struct TStopOffset
	//	{
	//		public int distance;        // ���˾���
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse;
	//		public double vel;          // ���ٶ�
	//		public double acc;          // ���˼��ٶ�
	//	};

	//	public struct TLoopMode
	//	{
	//		public short loopMode;              // ��·ģʽ
	//		public short pressProfileMode;      // ѹ���ջ�ģʽ����Ч
	//	};

	//	public struct TPressPrm
	//	{
	//		public short active;            // ����ʹ��
	//		public short reverse1;
	//		public int scale;             // ������������1ţ��N��ת��������ĵ�����
	//		public short linkAxis;          // ѹ���滮�����Ǹ����������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse2;
	//	};

	//	public struct TPressTargetPrm
	//	{
	//		public double acc;              // ���ؼ��ٶ�
	//		public double dec;              // ���ؼ��ٶ�
	//		public double pressStart;       // ��������
	//		public short smoothTime;        // ƽ��ʱ��
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse2;
	//	};

	//	public struct TPressArrayData
	//	{
	//		public double pressTarget;      // Ŀ��ѹ��
	//		public int pressTime;         // ����ʱ�� ms��λ
	//		public int holdTime;          // ����ʱ��
	//	};

	//	public struct TPressArray
	//	{
	//		public short count;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public TPressArrayData[] buffer;
	//		public short exit;              // �滮��ɺ��Ƿ��л���λ�ñջ�ģʽ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reverse2;
	//	};

	//	public struct TPressPid
	//	{
	//		public double kp;
	//		public double ki;
	//		public double kd;
	//		public double kvff;
	//		public double kaff;
	//		public int integralLimit;
	//		public int derivativeLimit;
	//		public short limitMax;                  // ������������ֵ
	//		public short limitMin;                  // �����������Сֵ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse1;
	//	};

	//	// ��·ģʽ
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLoopMode(short core, short axis, ref TLoopMode pMode); // ���û�·ģʽ��ѹ���ջ�����λ�ñջ���
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLoopMode(short core, short axis, out TLoopMode pMode); // ��ȡ��·ģʽ��ѹ���ջ�����λ�ñջ���
	//																							 // ���á���ȡ���ع�����ز���
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressPrm(short core, short pressAxis, ref TPressPrm pPressPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressPrm(short core, short pressAxis, out TPressPrm pPressPrm);
	//	// ����Ŀ��ѹ��
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressTarget(short core, short pressProfile, double value, ref TPressTargetPrm pPressTargetPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressTarget(short core, short pressProfile, out double pValue, out TPressTargetPrm pPressTargetPrm);
	//	// ����Ŀ��ѹ��
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressArray(short core, short pressProfile, ref TPressArray pPressArray);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressArray(short core, short pressProfile, out TPressArray pPressArray);
	//	// ѹ����PID
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressPid(short core, short pressControl, ref TPressPid pPid);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressPid(short core, short pressControl, out TPressPid pPid);
	//	// ��ȡ�滮ѹ��
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPrfPress(short core, short pressProfile, out double pValue, out double pValueFilter);
	//	// ��ȡ����ѹ��
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAtlPress(short core, short pressProfile, out double pValue);
	//	// ��ȡѹ��״̬
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressStatus(short core, short pressAxis, out int pStatus);

	//	// ���ù滮ѹ��
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPrfPress(short core, short axis, double prfPressValue);
	//	// ����ѹ������Դ
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressFeedbackType(short core, short pressAxis, out short pFbType, out short pFbIndex);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressFeedbackType(short core, short pressAxis, short fbType, short fbIndex);

	//	public struct TPressLimit
	//	{
	//		public short limit1;
	//		public short limit2;
	//		public short time;
	//		public short triggerCondition;          // ѹ����ͣ����������PRESS_GREATER_THAN_LIMIT,PRESS_LESS_THAN_LIMIT,
	//	};

	//	public struct TTorqueLimit
	//	{
	//		public short limit1;                    // ����Limit1����time������ֹͣ
	//		public short limit2;                    // ����Limit2����ֹͣ
	//		public short time;
	//		public short reverse;
	//	};
	//	// �������س���ֹͣ����		// ��������
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetLimit(short core, short axis, short type, IntPtr pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLimit(short core, short axis, short type, IntPtr pPrm);

	//	// �������ܴ�������˲���
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetStopOffset(short core, short axis, out TStopOffset pStopOffset);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetStopOffset(short core, short axis, ref TStopOffset pStopOffset);

	//	public struct TPressAutoSwitchPrm
	//	{
	//		public short limit1;
	//		public short limit2;
	//		public short time;
	//		public short triggerCondition;
	//		public short loopMode;
	//		public short pressProfileMode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reverse;
	//	};
	//	// ������/λ�Զ��л�����
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressAutoSwitchPrm(short core, short pressAxis, ref TPressAutoSwitchPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressAutoSwitchPrm(short core, short pressAxis, out TPressAutoSwitchPrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PressAutoSwitchEnable(short core, short pressAxis, short enable);

	//	// ����ѹ���ջ�ģʽ�µĹ����ռ�
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressRange(short core, short pressAxis, short centerSynch, int range);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressRange(short core, short pressAxis, out int pCenterPos, out int pRange);

	//	// ����ѹ���ջ�ģʽ��λ�ô�Խ����
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressCross(short core, short pressAxis, short dir, int pos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressCross(short core, short pressAxis, out short pDir, out int pPos);

	//	// ����ѹ���������
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPressTrigger(short core, short pressAxis, short pressThread, short triggerCondition);
	//	// ��ȡѹ���������
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressTrigger(short core, short pressAxis, out short pPressThread, out short pTriggerCondition);
	//	// ��ѹ��������
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PressTriggerOn(short core, short pressAxis);
	//	// �ر�ѹ��������
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PressTriggerOff(short core, short pressAxis);
	//	// ��ȡѹ������λ��
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPressTriggeredPos(short core, short pressAxis, out short pEnable, out double pCntPos, out short pTriggeredPress);

	//	/************************************************************************/
	//	/* ��ת�Ṧ��                                                           */
	//	/************************************************************************/
	//	public const short ROTARY_DIRECTION_SELECT_MODE_DEFAULT = 0;
	//	public const short ROTARY_DIRECTION_SELECT_MODE_SMART = 1;

	//	public struct TRotaryConfig
	//	{
	//		public short rotary;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad;
	//		public double start;
	//		public double length;
	//		public double reserve;
	//		public double pulse;
	//	};

	//	public struct TLineAbsolutePrm
	//	{
	//		public short fifo;
	//		public short overrideNum;
	//		public short g0Mode;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	//		public short[] reserve1;
	//		public int segNum;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public int[] reserve2;
	//		public double vel;
	//		public double acc;
	//		public double velEnd;
	//		public double velLimit;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] reserve3;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPrfPosRotary(short core, short axis, out double pTheta, out double pRound, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetProfileRotaryConfig(short core, short profile, out TRotaryConfig pConfig);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPrfPosRotary(short core, short profile, out double pTheta, out double pRound, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdScale(short core, short crd, short dimension, double alpha, double beta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdScale(short core, short crd, short dimension, out double pAlpha, out double pBeta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdRotaryConfig(short core, short crd, short dimension, out TRotaryConfig pConfig);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCrdPosRotary(short core, short crd, short dimension, out double pTheta, out double pRound, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncoderRotaryConfig(short core, short encoder, out TRotaryConfig pConfig);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetEncPosRotary(short core, short encoder, out double pTheta, out double pRound, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisRotaryConfig(short core, short axis, ref TRotaryConfig pConfig);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisRotaryConfig(short core, short axis, out TRotaryConfig pConfig);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ZeroAxisRotaryRound(short core, short axis, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LineAbsoluteEx(short core, short crd, ref double pPos, ref short pDir, ref TLineAbsolutePrm pPrm);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisRotaryDirectionSelectMode(short core, short axis, short mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisRotaryDirectionSelectMode(short core, short axis, out short pMode);

	//	public struct TBufMoveAbsPrm
	//	{
	//		public double pos;
	//		public double vel;
	//		public double acc;
	//		public double velMax;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve1;
	//		public short smoothTime;
	//		public short enableRatio;
	//		public short modal;
	//		public short fifo;
	//		public short dir;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserve2;
	//		public int segNum;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public int[] reserve3;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufMoveAbsoluteEx(short core, short crd, short moveAxis, ref TBufMoveAbsPrm pPrm);

	//	/*-----------------------------------------------------------*/
	//	/* ����ֵ�������������                                      */
	//	/*-----------------------------------------------------------*/
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAuAbsEncMultiTurnRange(short core, short encoder, double range);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadAuAbsEncPos(short core, short encoder, ref double pPos);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCrdUserDataEndVelLa(short core, short crd, short crdUserDataType, double endVel);

	//	/*-----------------------------------------------------------*/
	//	/* PVTģʽ�������������                                      */
	//	/*-----------------------------------------------------------*/
	//	public const short PVT_OPERATION_TYPE_LASER_ON = 2;
	//	public const short PVT_OPERATION_TYPE_BUF_DA = 4;
	//	public const short PVT_OPERATION_TYPE_LASER_CMD = 5;
	//	public const short PVT_OPERATION_TYPE_LASER_FOLLOW_RATIO = 6;
	//	public const short PVT_OPERATION_TYPE_LASER_FOLLOW_MODE = 25;
	//	public const short PVT_OPERATION_TYPE_LASER_FOLLOW_OFF = 26;
	//	public const short PVT_OPERATION_TYPE_BUF_DO_BIT = 94;

	//	public struct TPVTDoBit
	//	{
	//		public short doType;
	//		public short index;
	//		public short value;
	//	};

	//	public struct TPVTDA
	//	{
	//		public short chn;
	//		public short daValue;
	//	};

	//	public struct TPVTLaserSwitch
	//	{
	//		public short chn;
	//		public short enable;
	//	};

	//	public struct TPVTLaserPrfCmd
	//	{
	//		public short chn;
	//		public double power;
	//	};

	//	public struct TPVTLaserFollowRatio
	//	{
	//		public short chn;
	//		public double ratio;
	//		public double minPower;
	//		public double maxPower;
	//	};

	//	public struct TPVTLaserFollowOff
	//	{
	//		public short chn;
	//	};

	//	public struct TPVTLaserFollowMode
	//	{
	//		public short chn;
	//		public short source;
	//		public double startPower;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PvtTableUserData(short core, short tableId, short userDataType, double time, IntPtr pData);

	//	public struct TAddition
	//	{
	//		public short type;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] index;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisAddition(short core, short axis, short dataType, ref TAddition pAddition);



	//}


	///*-----------------------------------------------------------*/
	////ԭconfig.cs�����ù��ܣ�����������ģ��                       */
	///*-----------------------------------------------------------*/
	//public class mc_cfg
	//{
	//	/*-----------------------------------------------------------*/
	//	/* config of controller                                      */
	//	/*-----------------------------------------------------------*/
	//	public const short RES_LIMIT = 8;
	//	public const short RES_ALARM = 8;
	//	public const short RES_HOME = 8;
	//	public const short RES_GPI = 16;
	//	public const short RES_ARRIVE = 8;
	//	public const short RES_MPG = 7;

	//	public const short RES_ENABLE = 8;
	//	public const short RES_CLEAR = 8;
	//	public const short RES_GPO = 16;

	//	public const short RES_DAC = 12;
	//	public const short RES_STEP = 8;
	//	public const short RES_PULSE = 8;
	//	public const short RES_ENCODER = 11;
	//	public const short RES_LASER = 2;

	//	public const short AXIS_MAX = 8;
	//	public const short PROFILE_MAX = 8;
	//	public const short CONTROL_MAX = 8;

	//	public const short PRF_MAP_MAX = 2;
	//	public const short ENC_MAP_MAX = 2;

	//	public struct TDiConfig
	//	{
	//		public short active;
	//		public short reverse;
	//		public short filterTime;
	//	}

	//	public struct TCountConfig
	//	{
	//		public short active;
	//		public short reverse;
	//		public short filterType;

	//		public short captureSource;
	//		public short captureHomeSense;
	//		public short captureIndexSense;
	//	}

	//	public struct TDoConfig
	//	{
	//		public short active;
	//		public short axis;
	//		public short axisItem;
	//		public short reverse;
	//	}

	//	public struct TStepConfig
	//	{
	//		public short active;
	//		public short axis;
	//		public short mode;
	//		public short parameter;
	//		public short reverse;
	//	}

	//	public struct TDacConfig
	//	{
	//		public short active;
	//		public short control;
	//		public short reverse;
	//		public short bias;
	//		public short limit;
	//	}

	//	public struct TAdcConfig
	//	{
	//		public short active;
	//		public short reverse;
	//		public double a;
	//		public double b;
	//		public short filterMode;
	//	}

	//	public struct TControlConfig
	//	{
	//		public short active;
	//		public short axis;
	//		public short encoder1;
	//		public short encoder2;
	//		public int errorLimit;
	//		public short filterType1;
	//		public short filterType2;
	//		public short filterType3;
	//		public short encoderSmooth;
	//		public short controlSmooth;
	//	}

	//	public struct TControlConfigEx
	//	{
	//		public short refType;
	//		public short refIndex;

	//		public short feedbackType;
	//		public short feedbackIndex;

	//		public int errorLimit;
	//		public short feedbackSmooth;
	//		public short controlSmooth;
	//	}

	//	public struct TProfileConfig
	//	{
	//		public short active;
	//		public double decSmoothStop;
	//		public double decAbruptStop;
	//	}

	//	public struct TAxisConfig
	//	{
	//		public short active;
	//		public short alarmType;
	//		public short alarmIndex;
	//		public short limitPositiveType;
	//		public short limitPositiveIndex;
	//		public short limitNegativeType;
	//		public short limitNegativeIndex;
	//		public short smoothStopType;
	//		public short smoothStopIndex;
	//		public short abruptStopType;
	//		public short abruptStopIndex;
	//		public int prfMap;
	//		public int encMap;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = PRF_MAP_MAX)]
	//		public short[] prfMapAlpha;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = PRF_MAP_MAX)]
	//		public short[] prfMapBeta;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = ENC_MAP_MAX)]
	//		public short[] encMapAlpha;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = ENC_MAP_MAX)]
	//		public short[] encMapBeta;
	//	}

	//	public struct TMcConfig
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = PROFILE_MAX)]
	//		public TProfileConfig[] profile;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = AXIS_MAX)]
	//		public TAxisConfig[] axis;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = CONTROL_MAX)]
	//		public TControlConfig[] control;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_DAC)]
	//		public TDacConfig[] dac1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_STEP)]
	//		public TStepConfig[] step;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_ENCODER)]
	//		public TCountConfig[] encoder;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_PULSE)]
	//		public TCountConfig[] pulse1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_ENABLE)]
	//		public TDoConfig[] enable;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_CLEAR)]
	//		public TDoConfig[] clear;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_GPO)]
	//		public TDoConfig[] gpo;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_LIMIT)]
	//		public TDiConfig[] limitPositive;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_LIMIT)]
	//		public TDiConfig[] limitNegative;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_ALARM)]
	//		public TDiConfig[] alarm;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_HOME)]
	//		public TDiConfig[] home;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_GPI)]
	//		public TDiConfig[] gpi;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_ARRIVE)]
	//		public TDiConfig[] arrive;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = RES_MPG)]
	//		public TDiConfig[] mpg;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SaveConfig(short core, out string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDiConfig(short core, short diType, short diIndex, ref TDiConfig pDi);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDiConfig(short core, short diType, short diIndex, out TDiConfig pDi);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDoConfig(short core, short doType, short doIndex, ref TDoConfig pDo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDoConfig(short core, short doType, short doIndex, out TDoConfig pDo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetStepConfig(short core, short step, ref TStepConfig pStep);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetStepConfig(short core, short step, out TStepConfig pStep);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetDacConfig(short core, short dac, ref TDacConfig pDac);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetDacConfig(short core, short dac, out TDacConfig pDac);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAdcConfig(short core, short adc, ref TAdcConfig pAdc);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAdcConfig(short core, short adc, out TAdcConfig pAdc);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCountConfig(short core, short countType, short countIndex, ref TCountConfig pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetCountConfig(short core, short countType, short countIndex, out TCountConfig pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetControlConfig(short core, short control, ref TControlConfig pControl);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetControlConfig(short core, short control, out TControlConfig pControl);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetControlConfigEx(short core, short control, ref TControlConfigEx pControl);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetControlConfigEx(short core, short control, out TControlConfigEx pControl);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetProfileConfig(short core, short profile, ref TProfileConfig pProfile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetProfileConfig(short core, short profile, out TProfileConfig pProfile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisConfig(short core, short axis, ref TAxisConfig pAxis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisConfig(short core, short axis, out TAxisConfig pAxis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ProfileScale(short core, short axis, short alpha, short beta);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EncScale(short core, short axis, short alpha, short beta);

	//	/*-----------------------------------------------------------*/
	//	/* Config of Ext-Module                                      */
	//	/*-----------------------------------------------------------*/
	//	public struct TExtModuleStatus
	//	{
	//		public short active;
	//		public short checkError;
	//		public short linkError;
	//		public short packageErrorCount;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
	//		public short[] pad;
	//	}

	//	public struct TExtModuleType
	//	{
	//		public short type;
	//		public short input;
	//		public short output;
	//	}

	//	public struct TExtIoMap
	//	{
	//		public short station;
	//		public short module;
	//		public short index;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadExtModuleConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SaveExtModuleConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ExtModuleOn(short core, short station);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ExtModuleOff(short core, short station);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtModuleStatus(short core, short station, out TExtModuleStatus pStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtModuleId(short core, short station, short count, ref short pId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtModuleId(short core, short station, short count, out short pId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtModuleReverse(short core, short station, short module, short inputCount, ref short pInputReverse, short outputCount, ref short pOutputReverse);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtModuleReverse(short core, short station, short module, short inputCount, out short pInputReverse, short outputCount, out short pOutputReverse);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtModuleCount(short core, short station, out short pCount);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtModuleType(short core, short station, short module, out TExtModuleType pModuleType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtIoMap(short core, short type, short index, ref TExtIoMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtIoMap(short core, short type, short index, out TExtIoMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearExtIoMap(short core, short type);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtAoRange(short core, short index, double max, double min);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtAoRange(short core, short index, out double pMax, out double pMin);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetExtAiRange(short core, short index, double max, double min);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetExtAiRange(short core, short index, out double pMax, out double pMin);

	//	/*-----------------------------------------------------------*/
	//	/* Config of Laser and Scan                                  */
	//	/*-----------------------------------------------------------*/
	//	public struct TScanCommandMotion
	//	{
	//		public int segmentNumber;
	//		public short x;
	//		public short y;
	//		public int deltaX;
	//		public int deltaY;
	//		public int vel;
	//		public int acc;
	//	}
	//	public struct TScanCommandMotionDelay
	//	{
	//		public int delay;
	//	}

	//	public struct TScanCommandDo
	//	{
	//		public short doType;
	//		public short doMask;
	//		public short doValue;
	//	}

	//	public struct TScanCommandDoDelay
	//	{
	//		public int delay;
	//	}

	//	public struct TScanCommandLaser
	//	{
	//		public short mask;
	//		public short value;
	//	}

	//	public struct TScanCommandLaserDelay
	//	{
	//		public int laserOnDelay;
	//		public int laserOffDelay;
	//	}

	//	public struct TScanCommandLaserPower
	//	{
	//		public int power;
	//	}

	//	public struct TScanCommandLaserFrequency
	//	{
	//		public int frequency;
	//	}

	//	public struct TScanCommandLaserPulseWidth
	//	{
	//		public int pulseWidth;
	//	}

	//	public struct TScanCommandDa
	//	{
	//		public short daIndex;
	//		public short daValue;
	//	}

	//	public struct TScanMap
	//	{
	//		public short module;
	//		public short fifo;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetScanMap(short core, short index, ref TScanMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetScanMap(short core, short index, out TScanMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearScanMap(short core);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_UpdateScanMap(short core);

	//	/*-----------------------------------------------------------*/
	//	/* Config of Position Compare                                */
	//	/*-----------------------------------------------------------*/
	//	public struct TPosCompareMap
	//	{
	//		public short module;
	//		public short fifo;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetPosCompareMap(short core, short index, ref TPosCompareMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetPosCompareMap(short core, short index, out TPosCompareMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearPosCompareMap(short core);
	//}

	///*-----------------------------------------------------------*/
	////ԭringnet.cs���͵Ȼ���������ع��ܵ�ָ��                   */
	///*-----------------------------------------------------------*/
	///*-----------------------------------------------------------*/
	///* Ringnet                                                   */
	///*-----------------------------------------------------------*/
	//public class mc_ringnet
	//{
	//	public const short RTN_SUCCESS = 0;
	//	public const short RTN_MALLOC_FAIL = -100;                 /* malloc memory fail */
	//	public const short RTN_FREE_FAIL = -101;                   /* free memory or delete the object fail */
	//	public const short RTN_NULL_POINT = -102;                  /* the param point input is null */
	//	public const short RTN_ERR_ORDER = -103;                   /* call the function order is wrong, some msg isn't validable */
	//	public const short RTN_PCI_NULL = -104;                    /* the pci address is empty, can't access the pci device */
	//	public const short RTN_PARAM_OVERFLOW = -105;              /* the param input is too larget */
	//	public const short RTN_LINK_FAIL = -106;                  /* the two ports both link fail */
	//	public const short RTN_IMPOSSIBLE_ERR = -107;              /* it means the system or same function work wrong */
	//	public const short RTN_TOPOLOGY_CONFLICT = -108;           /* the id conflict */
	//	public const short RTN_TOPOLOGY_ABNORMAL = -109;           /* scan the net abnormal */
	//	public const short RTN_STATION_ALONE = -110;               /* the device no id, it means the device id is 0xF0 */
	//	public const short RTN_WAIT_OBJECT_OVERTIME = -111;        /* multi thread wait for object overtime */
	//	public const short RTN_ACCESS_OVERFLOW = -112;             /* data[i];  i is larger than the define */
	//	public const short RTN_NO_STATION = -113;                  /* the station accessed not existent */
	//	public const short RTN_OBJECT_UNCREATED = -114;            /* the object not created yet */
	//	public const short RTN_PARAM_ERR = -115;                   /* the param input is wrong */
	//	public const short RTN_PDU_CFG_ERR = -116;                 /*Pdu DMA Cfg Err */
	//	public const short RTN_PCI_FPGA_ERR = -117;                /*PCI op err or FPGA op err */
	//	public const short RTN_CHECK_RW_ERR = -118;                /*data write to reg, then rd out, and check err */
	//	public const short RTN_REMOTE_UNEABLE = -119;              /*the device which will be ctrl by net can't be ctrl by net function */

	//	public const short RTN_NET_REQ_DATA_NUM_ZERO = -120;       /* mail op or pdu op req data num can't be 0 */
	//	public const short RTN_WAIT_NET_OBJECT_OVERTIME = -121;    /* net op multi thread wait for object overtime */
	//	public const short RTN_WAIT_NET_RESP_OVERTIME = -122;      /* Can't wait for resp */
	//	public const short RTN_WAIT_NET_RESP_ERR = -123;           /* wait mailbox op err */
	//	public const short RTN_INITIAL_ERR = -124;                 /* initial the device err */
	//	public const short RTN_PC_NO_READY = -125;                 /* find the station'pc isn't work */
	//	public const short RTN_STATION_NO_EXIST = -126;
	//	public const short RTN_MASTER_FUNCTION = -127;             /* this funciton only used by master */

	//	public const short RTN_NOT_ALL_RETURN = -128;              /* the GT_RN_PtProcessData funciton fail return */
	//	public const short RTN_NUM_NOT_EQUAL = -129;               /* the station number of RingNet do not equal  the station number of CFG */

	//	public const short RTN_CHECK_STATION_ONLINE_NUM_ERR = -130;/* Check no slave */
	//	public const short RTN_FILE_ERR_OPEN = -131;               /* open file error */
	//	public const short RTN_FILE_ERR_FORMAT = -132;             /* parse file error */
	//	public const short RTN_FILE_ERR_MISSMATCH = -133;          /* file info is not match with the actual ones */
	//	public const short RTN_DMALIST_ERR_MISSMATCH = -134;       /* can't find the slave */

	//	public const short RTN_REQUSET_MAIL_BUS_OVERTIME = -150;   /* Requset Mail Bus Err */
	//	public const short RTN_INSTRCTION_ERR = -151;              /* instrctions err */
	//	public const short RTN_MAIL_RESP_REQ_ERR = -152;           /* RN_MailRespReq  err */
	//	public const short RTN_CTRL_SRC_ERR = -153;                /* the controlled source  is error */
	//	public const short RTN_PACKET_ERR = -154;                  /* packet is error */
	//	public const short RTN_STATION_ID_ERR = -155;              /* the device id is not in the right rang */
	//	public const short RTN_WAIT_NET_PDU_RESP_OVERTIME = -156;  /* net pdu op wait overtime */
	//	public const short RTN_ETHCAT_ENC_POS_ERR = -157;

	//	public const short RTN_IDLINK_PACKET_ERR = -200;           /* ilink master  decode err! packet_length is not match */
	//	public const short RTN_IDLINK_PACKET_END_ERR = -201;       /* the ending of ilink packet is not 0xFF */
	//	public const short RTN_IDLINK_TYPER_ERR = -202;            /* the type of ilink module is error */
	//	public const short RTN_IDLINK_LOST_CNT = -203;             /* the ilink module has lost connection */
	//	public const short RTN_IDLINK_CTRL_SRC_ERR = -204;         /* the controlled source of ilink module is error */
	//	public const short RTN_IDLINK_UPDATA_ERR = -205;           /* the ilink module updata error */
	//	public const short RTN_IDLINK_NUM_ERR = -206;              /* the ilink num larger the IDLINK_MAX_NUM(30) */
	//	public const short RTN_IDLINK_NUM_ZERO = -207;             /* the ilink num is zero */

	//	public const short RTN_NO_PACKET = 301;                    /* no valid packet */
	//	public const short RTN_RX_ERR_PDU_PACKET = -302;           /* ERR PDU PACKET */
	//	public const short RTN_STATE_MECHINE_ERR = -303;
	//	public const short RTN_PCI_DSP_UN_FINISH = 304;
	//	public const short RTN_SEND_ALL_FAIL = -305;
	//	public const short RTN_STATION_CLOSE = 310;
	//	public const short RTN_STATION_RESP_FAIL = 311;

	//	public const short RTN_UPDATA_MODAL_ERR = -330;            /* update the modal in normal way fail */

	//	public const short RTN_NO_MAIL_DATA = 340;                 /* There is no mail data */
	//	public const short RTN_NO_PDU_DATA = 341;                  /* There is no pdu data */


	//	public const short RTN_FILE_PARAM_NUM_ERR = -500;
	//	public const short RTN_FILE_PARAM_LEN_ERR = -501;
	//	public const short RTN_FILE_MALLOC_FAIL = -502;
	//	public const short RTN_FILE_FREE_FAIL = -503;
	//	public const short RTN_FILE_PARAM_ERR = -504;
	//	public const short RTN_FILE_NOT_EXSITS = 505;
	//	public const short RTN_FILE_CREATE_FAIL = 510;
	//	public const short RTN_FILE_DELETE_FAIL = 511;
	//	public const short RTN_FIFE_CRC_CHECK_ERR = -512;
	//	public const short RTN_FIFE_FUNCTION_ID_RETURN_ERR = -600;
	//	public const short RTN_DLL_WINCE = -800;
	//	public const short RTN_DLL_WIN32 = -801;
	//	public const short RTN_XML_STATION_ERR = -900;                  //dma config file confilit with slave type

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadRingNetConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SaveRingNetConfig(short core, string pFile);

	//	public const short TERMINAL_LOAD_MODE_NONE = 0;
	//	public const short TERMINAL_LOAD_MODE_BOOT = 2;

	//	public struct TTerminalStatus
	//	{
	//		public ushort type;
	//		public short id;
	//		public int status;
	//		public uint synchCount;
	//		public uint ringNetType;
	//		public uint portStatus;
	//		public uint sportDropCount;
	//		public uint reserve1;
	//		public uint reserve2;
	//		public uint reserve3;
	//		public uint reserve4;
	//		public uint reserve5;
	//		public uint reserve6;
	//		public uint reserve7;
	//	}

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_TerminalInit(short core, short detect);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalPermit(short core, short index, short dataType, ushort permit);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalPermitEx(short core, short station, short dataType, ref short permit, short index, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalPermitEx(short core, short station, short dataType, out short pPermit, short index, short count);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_FindStation(short core, short station, uint time);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalPermit(short core, short index, short dataType, out ushort pPermit);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ProgramTerminalConfig(short core, short loadMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalConfigLoadMode(short core, out short pLoadMode);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadPhysicalMap();
	//	[DllImport("gts.dll")]
	//	public static extern short ConvertPhysical(short core, short dataType, short terminal, short index);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalSafeMode(short core, short index, short safeMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalSafeMode(short core, short index, ref short pSafeMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearTerminalSafeMode(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalStatus(short core, short index, out TTerminalStatus pTerminalStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalType(short core, short count, out ushort pType, ref short pTypeConnect);

	//	/*-----------------------------------------------------------*/
	//	/* ��ȡSPORT������                                           */
	//	/*-----------------------------------------------------------*/
	//	public const short SPORT_COUNT = 256;

	//	public struct TTerminalData
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = SPORT_COUNT)]
	//		public uint[] terminalTxBuf;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = SPORT_COUNT)]
	//		public uint[] terminalRxBuf;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ReadTerminalData(short core, out TTerminalData pTerminalData);

	//	/*-----------------------------------------------------------*/
	//	/* Config of module                                          */
	//	/*-----------------------------------------------------------*/
	//	public const short TERMINAL_OPERATION_NONE = 0;
	//	public const short TERMINAL_OPERATION_SKIP = 1;
	//	public const short TERMINAL_OPERATION_CLEAR = 2;
	//	public const short TERMINAL_OPERATION_RESET_MODULE = 3;

	//	public const short TERMINAL_OPERATION_PROGRAM = 11;

	//	public struct TRingNetCrcStatus
	//	{
	//		public uint portACrcOkCnt;
	//		public ushort portACrcErrorCnt;
	//		public uint portBCrcOkCnt;
	//		public ushort portBCrcErrorCnt;
	//		public uint reserve;             //Ŀǰ���ڶ�ȡFLASH�����ݳ���
	//	}

	//	public struct TTerminalError
	//	{
	//		public ushort errorCountReceive;
	//		public ushort errorCountPackageDown;
	//		public ushort errorCountPackageUp;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	//		public ushort[] reserve;
	//	}
	//	public struct TTerminalMap
	//	{
	//		public short moduleDataType;
	//		public short moduleDataIndex;
	//		public short dataIndex;
	//		public short dataCount;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LoadTerminalConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SaveTerminalConfig(short core, string pFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_TerminalOn(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_TerminalSynch(short core, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetRingNetCrcStatus(short core, short index, out TRingNetCrcStatus pRingNetCrcStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalError(short core, short index, out TTerminalError pTerminalError);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalType(short core, short count, ref short pType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalLinkStatus(short core, short count, out short ringNetType, out short pLinkStatus);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalMap(short core, short dataType, short moduleIndex, ref TTerminalMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalMap(short core, short dataType, short moduleIndex, out TTerminalMap pMap);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ClearTerminalMap(short core, short dataType);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalMode(short core, short station, ushort mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalMode(short core, short station, out ushort pMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalTest(short core, short station, short index, ushort value);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalTest(short core, short station, short index, out ushort pValue);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetTerminalOperation(short core, short operation);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetTerminalOperation(short core, out short pOperation);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetMailbox(short core, short station, ushort byteAddress, ref ushort pData, ushort wordCount, ushort dataMode, ushort desId, ushort type);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMailbox(short core, short station, ushort byteAddress, out ushort pData, ushort wordCount, ushort dataMode, ushort desId, ushort type);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetUuid(short core, string pCode, short count);

	//	/*-----------------------------------------------------------*/
	//	/* ����ָ�ָ��                                              */
	//	/*-----------------------------------------------------------*/
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_Recover(short cardIndex);

	//	/*-----------------------------------------------------------*/
	//	/* GSHD�����С��������                                      */
	//	/*-----------------------------------------------------------*/
	//	public struct TTorqueLimit
	//	{
	//		public ushort torqueMax;
	//		public ushort torquePostive;
	//		public ushort torqueNegitive;
	//		public short reserve1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reserve2;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_SetTorqueLimit(short core, short axis, ref TTorqueLimit pTorqueLimit);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_GetTorqueLimit(short core, short axis, out TTorqueLimit pTorqueLimit);

	//	/*-----------------------------------------------------------*/
	//	/* GSHD�ջ���������                                          */
	//	/*-----------------------------------------------------------*/
	//	public struct TServoPosLoopPidMode0
	//	{
	//		public double value;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] reverse;
	//	};

	//	public struct TServoPosLoopPidUnion
	//	{
	//		public TServoPosLoopPidMode0 servoPosLoopPidMode0;
	//	};

	//	public struct TServoPosLoopPid
	//	{
	//		public short mode;
	//		public TServoPosLoopPidUnion servoPosLoopPidPrm;
	//	};

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetServoPosLoopPid(short core, short axis, ref TServoPosLoopPid pServoPosLoopPid);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetServoPosLoopPid(short core, short axis, out TServoPosLoopPid pServoPosLoopPid);

	//	/*-----------------------------------------------------------*/
	//	/* ��ȫģʽ����                                              */
	//	/*-----------------------------------------------------------*/
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_SetStationSafeModeControl(short cardIndex, short stationPhyId, short enable, short clearMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_ClearStationSafeModeStatus(short cardIndex, short stationPhyId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_SetStationSafeModeOut(short cardIndex, short stationPhyId, short type, short index, ref short pEnable, ref double pValue, short count);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_IlinkSetSafeModeControl(short cardIndex, short stationPhyId, short modulePhyId, short enable, short clearMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_IlinkClearSafeModeStatus(short cardIndex, short stationPhyId, short modulePhyId);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_IlinkSetSafeModeOut(short cardIndex, short stationPhyId, short modulePhyId, short type, short index, ref short pEnable, ref double pValue, short count);


	//	//-------------------------------------------------------------------------------------------------------
	//	//��ȡ��ģ��LED��ʾģʽ
	//	// mode:�ư��������ʾģʽ�� 
	//	//0������ģʽ(�ϵ��ʼ״̬��ʾ�㣬��ʹ�ܺ���ʾС���㣬�����л���ʽ����)��  
	//	//1��վ��ģʽ(��ʾվ�ţ�������ʾ����䶯)��  
	//	//2������ģʽ(Ԥ��)��
	//	//radix:�ư��������ʾ���ƣ� 0�������ƣ�  1���˽��ƣ�  2��ʮ���ƣ�  3��ʮ�����ƣ�
	//	//-------------------------------------------------------------------------------------------------------
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_ReadLedDispalyMode(short cardIndex, short stationPhyId, out byte pMode, out byte pRadix);
	//	//-------------------------------------------------------------------------------------------------------
	//	//������ģ��LED��ʾģʽ
	//	// mode:�ư��������ʾģʽ�� 
	//	//0������ģʽ(�ϵ��ʼ״̬��ʾ�㣬��ʹ�ܺ���ʾС���㣬�����л���ʽ����)��  
	//	//1��վ��ģʽ(��ʾվ�ţ�������ʾ����䶯)��  
	//	//2������ģʽ(Ԥ��)��
	//	//radix:�ư��������ʾ���ƣ� 0�������ƣ�  1���˽��ƣ�  2��ʮ���ƣ�  3��ʮ�����ƣ�
	//	//-------------------------------------------------------------------------------------------------------
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_RN_WriteLedDisplayMode(short cardIndex, short stationPhyId, byte mode, byte radix);
	//}

	///*-----------------------------------------------------------*/
	////ԭLookAheadEx.cs����ǰհ��ع��ܵ�ָ��                      */
	///*-----------------------------------------------------------*/
	//public class mc_la
	//{
	//	public const short LA_AXIS_NUM = 8;
	//	public const short LA_WORK_AXIS_NUM = 6;

	//	//��Ĳ�����Ϣ����������ٶȣ����������ٶȣ���������ٶȱ仯�����Ƿ������ٶ�ģʽ
	//	public const short AXIS_LIMIT_NONE = 0;     //��������
	//	public const short AXIS_LIMIT_MAX_VEL = 1;  //������ٶ�����
	//	public const short AXIS_LIMIT_MAX_ACC = 2;  //�������ٶ�����
	//	public const short AXIS_LIMIT_MAX_DV = 4;   //������ٶ�����������
	//	public const short KIN_MSG_BUFFER_SIZE = 32;

	//	//�ٶȹ滮ģʽ
	//	public enum EVelMode
	//	{
	//		T_CURVE = 0,
	//		S_CURVE,
	//		S_CURVE_NEW,                    //���ݼӼ��ٶȡ������ٶȽ���S�����ٶ�ǰհ��2015.11.16
	//		S_CURVE_SMOOTH,

	//		VEL_MODE_MAX = 0x10000,         //ȷ������Ϊ4Byte
	//	};

	//	//��������ϵ�¹켣�Ƿ������ٶ�ģʽ
	//	public enum EWorkLimitMode
	//	{
	//		WORK_LIMIT_INVALID = 0,         //������
	//		WORK_LIMIT_VALID = 1,           //������Ч

	//		WORK_LIMIT_MODE_MAX = 0x10000,    //ȷ������Ϊ4Byte
	//	};

	//	//���õ��ٶȶ������
	//	public enum EVelSettingDef
	//	{
	//		NORMAL_DEF_VEL = 0,             //����Ϊ������ϵ������ĺϳ��ٶ�
	//		NUM_DEF_VEL = 1,                //��NUMϵͳ�Ĺ�����
	//		CUT_DEF_VEL = 2,                //�ٶ�Ϊ�����ٶ�

	//		VEL_SETTING_DEF_MAX = 0x10000,    //ȷ������Ϊ4Byte
	//	};

	//	//���õļ��ٶȶ������
	//	public enum EAccSettingDef
	//	{
	//		NORMAL_DEF_ACC = 0,             //���뼴���
	//		LONG_AXIS_ACC = 1,              //��������ٶ�

	//		VEL_SETTING_DEF_MAX = 0x10000,    //ȷ������Ϊ4Byte
	//	};

	//	//��������
	//	public enum EMachineMode
	//	{
	//		NORMAL_THREE_AXIS = 0,          //��׼�������ģʽ
	//		MULTI_AXES = 1,                 //��������ģʽ
	//		FIVE_AXIS = 2,                  //�������ģʽ��������ϵΪ������������ϵΪ��
	//		FIVE_AXIS_WORK = 3,             //�������ģʽ����������ϵΪ����������ϵΪ��
	//		ROBOT = 4,

	//		VEL_SETTING_DEF_MAX = 0x10000,    //ȷ������Ϊ4Byte
	//	};
	//	//ǰհ�����ṹ��
	//	public struct TLookAheadParameter
	//	{
	//		public int lookAheadNum;                              //ǰհ����
	//		public double time;                                   //ʱ�䳣��
	//		public double radiusRatio;                            //�������Ƶ��ڲ���
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] vMax;                                 //���������ٶ�
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] aMax;                                 //����������ٶ�
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] DVMax;                                //���������ٶȱ仯������ʱ�䳣���ڣ�
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] scale;                                //��������嵱��
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public short[] axisRelation;                          //����������ڲ�����Ķ�Ӧ��ϵ
	//															  //[MarshalAs(UnmanagedType.ByValArray,SizeConst = 128)]
	//		public string machineCfgFileName;                     //���������ļ���
	//	};

	//	/*-----------------------------------------------------------*/
	//	/* ���������߲岹ָ��                                        */
	//	/*-----------------------------------------------------------*/
	//	public const int BEZIER_CONTROL_POINT_COUNT_MAX = 4;
	//	public const int INTERPOLATION_AXIS_MAX = 8;
	//	public struct TBezierPrm
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = INTERPOLATION_AXIS_MAX)]
	//		public double[] endPoint;                         // �յ�����
	//		public short overrideSelect;                      // �ٶȱ���ѡ��0����1�鱶�ʣ�1����2�鱶��
	//		public short plane;                               // ƽ��ѡ��0��XY��1��YZ��2��ZX
	//		public short controlPointCount;                   // �м���Ƶ����,Ŀǰֻ����2���м�㣨3��bezier��
	//		public short mode;                                // ���������Ϊ0
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = BEZIER_CONTROL_POINT_COUNT_MAX * INTERPOLATION_AXIS_MAX)]
	//		public double[,] controlPoint;                    // �м���Ƶ�λ�ã����4����
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	//		public double[] reserve2;                        // ���������Ϊ0
	//	};

	//	/*-----------------------------------------------------------*/
	//	/* ��Բ�岹ָ��                                              */
	//	/*-----------------------------------------------------------*/

	//	public const short ELLIPSE_AUX_POINT_COUNT = 5;
	//	public const short ELLIPSE_MODE_AUX_POINT = 0;
	//	public const short ELLIPSE_MODE_STANDARD = 1;
	//	public const short ELLIPSE_MODE_AUX_POINT_2D = 0;
	//	public const short ELLIPSE_MODE_STANDARD_2D = 1;


	//	public struct TEllipseParameter
	//	{

	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = INTERPOLATION_AXIS_MAX)]
	//		public double[] endPoint;                         // �յ�����
	//		public short plane;                               // ��Բƽ��ѡ��0��XY��1��YZ��2��ZX
	//		public short dir;                                 // ��Բ����0��˳ʱ�룻1����ʱ��
	//		public short overrideSelect;                      // �ٶȱ���ѡ��0����1�鱶�ʣ�1����2�鱶��
	//		public short mode;                                // ��Բģʽ��Ŀǰֻ֧�ֲ���0(������ģʽ)
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = ELLIPSE_AUX_POINT_COUNT * INTERPOLATION_AXIS_MAX)]
	//		public double[,] pos;                                 // ��Բ�ϸ���������

	//	};

	//	//-------------------------------------------------------
	//	//����˵������Բ�岹��������,ģʽ��ELLIPSE_MODE_AU_POINT_2D
	//	//plane--------------��Բƽ��ѡ��INTERPOLATION_CIRCLE_PLAT_XY(0)��XY��INTERPOLATION_CIRCLE_PLAT_YZ(1)��YZ��INTERPOLATION_CIRCLE_PLAT_ZX(2)��ZX
	//	//dir----------------��Բ����0��˳ʱ�룻1����ʱ��
	//	//overrideSelect-----�ٶȱ���ѡ��0����1�鱶�ʣ�1����2�鱶��
	//	//pad----------------ռλ����������Ҫ����
	//	//endPoint1----------�յ�����1,�������plane���������palneΪXYƽ�棬��endPoint1��pos1ΪX���꣬endPoint2��pos2ΪY����
	//	//endPoint2----------�յ�����2
	//	//pos1---------------��Բ�ϸ���������1
	//	//pos2---------------��Բ�ϸ���������2
	//	//-------------------------------------------------------
	//	public struct TEllipseAuxPoint2D
	//	{
	//		public short plane;
	//		public short dir;
	//		public short overrideSelect;
	//		public short pad;
	//		public double endPoint_X;
	//		public double endPoint_Y;

	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = ELLIPSE_AUX_POINT_COUNT)]
	//		public double[] pos_X;    // ��Բ�ϸ���������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = ELLIPSE_AUX_POINT_COUNT)]
	//		public double[] pos_Y;
	//	};

	//	//-------------------------------------------------------
	//	//����˵������Բ�岹��������,ģʽ��ELLIPSE_MODE_STANDARD_2D
	//	//plane--------------��Բƽ��ѡ��INTERPOLATION_CIRCLE_PLAT_XY(0)��XY��INTERPOLATION_CIRCLE_PLAT_YZ(1)��YZ��INTERPOLATION_CIRCLE_PLAT_ZX(2)��ZX
	//	//dir----------------��Բ����0��˳ʱ�룻1����ʱ��
	//	//overrideSelect-----�ٶȱ���ѡ��0����1�鱶�ʣ�1����2�鱶��
	//	//pad----------------ռλ����������Ҫ����
	//	//endPoint1----------�յ�����1,�������plane���������palneΪXYƽ�棬��endPoint1ΪX���꣬endPoint2ΪY����
	//	//endPoint2----------�յ�����2
	//	//centerPoint1-------��ԲԲ������1���������plane���������palneΪXYƽ�棬��centerPoint1ΪX���꣬centerPoint2ΪY����
	//	//centerPoint2-------��ԲԲ������2
	//	//theta--------------��Բ��ת�Ƕȣ���λ����
	//	//a------------------��Բ����
	//	//b------------------��Բ���ᣬ�������ȳ����
	//	//-------------------------------------------------------
	//	public struct TEllipseStandard2D
	//	{
	//		public short plane;
	//		public short dir;
	//		public short overrideSelect;
	//		public short pad;
	//		public double endPoint1;
	//		public double endPoint2;
	//		public double centerPoint1;
	//		public double centerPoint2;
	//		public double theta;
	//		public double a;
	//		public double b;
	//	};
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_Ellipse(short core, short crd, ref TEllipseParameter pEllipse, double synVel, double synAcc, double velEnd, long segNum, short fifo = 0);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EllipseEx(short core, short crd, ref TEllipseParameter pEllipse, double synVel, double synAcc, double velEnd, long segNum, short fifo = 0);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EllipsePro(short core, short crd, short mode, IntPtr pData, double synVel, double synAcc, double velEnd, long segNum, short fifo = 0);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EllipseProEx(short core, short crd, short mode, IntPtr pData, double synVel, double synAcc, double velEnd, long segNum, short fifo = 0);







	//	//////////////////////////////////////
	//	public struct RC_KIN_CONFIG
	//	{
	//		public short RobotType;
	//		public short reserved1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
	//		public short[] KinParUse;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
	//		public double[] KinPar;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	//		public short[] KinLimitUse;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	//		public double[] KinLimitMin;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	//		public double[] KinLimitMax;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	//		public double[] KinLimitMinShift;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	//		public double[] KinLimitMaxShift1;

	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public short[] AxisUse;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public char[] AxisPosSignSwitch;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] AxisPosOffset;

	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public short[] CartUnitUse;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public char[] CartPosKCSSignSwitch;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] reserved2;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	//		public double[] CartPosKCSOffset;
	//	};

	//	public struct RC_ERROR_INTERFACE
	//	{
	//		public char Error;
	//		public short ErrorID;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
	//		public char[] Message;
	//	};

	//	public struct RC_MSG_BUFFER_ELEMENT
	//	{
	//		public short ErrorID;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
	//		public char[] Message;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	//		public char[] LogTime;
	//		public int InternalID;
	//	};

	//	public struct RC_MSG_BUFFER
	//	{
	//		public short LastMsgIndex;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	//		public RC_MSG_BUFFER_ELEMENT[] MsgElement;
	//		public int LastMsgID;
	//	};

	//	//����ⷽ��
	//	public enum ETransDir
	//	{
	//		FORWARD_TRANS = 0,          //����
	//		INVERSE_TRANS,              //���

	//		TRANS_DIR_MAX = 0x10000,    // ȷ������Ϊ4Byte
	//	};

	//	//��ת�᷶Χ����
	//	public struct TRotationAxisRange
	//	{
	//		public int primaryAxisRangeOn;              //��һ��ת���޶���Χ�Ƿ���Ч��0������Ч��1����Ч
	//		public int slaveAxisRangeOn;                //�ڶ���ת���޶���Χ�Ƿ���Ч��0������Ч��1����Ч
	//		public double maxPrimaryAngle;              //��һ��ת�����ֵ
	//		public double minPrimaryAngle;              //��һ��ת����Сֵ
	//		public double maxSlaveAngle;                //�ڶ���ת�����ֵ
	//		public double minSlaveAgnle;                //�ڶ���ת����Сֵ
	//	};

	//	//ѡ�����
	//	public enum EGroupSelect
	//	{
	//		Continuous = 0,
	//		Group_1,
	//		Group_2,
	//	};

	//	public enum OptimizeState
	//	{
	//		OPT_OFF = 0,
	//		OPT_ON = 1
	//	};

	//	public enum OptimizeMethod
	//	{
	//		NO_OPT = 0,
	//		OPT_BLENDING,
	//		OPT_CIRCLEFITTING,
	//		OPT_CUBICSPLINE,
	//		OPT_BSPLINE,
	//	};

	//	public enum ErrorID
	//	{
	//		INIT_ERROR = 1,                         //û�н��в�����ʼ��
	//		PASSWORD_ERROR,                         //����������ڹ̸��˶�����ƽ̨������
	//		INDATA_ERROR,                           //�������ݴ��󣨼��Բ�������Ƿ���ȷ��
	//		PRE_PROCESS_ERROR,
	//		TOOL_RADIUS_COMPENSATE_ERROR_INOUT,     //���߰뾶�������󣺽���/����������������Բ��
	//		TOOL_RADIUS_COMPENSATE_ERROR_NOCROSS,   //���߰뾶�����������ݲ�������޷����㽻��
	//		USERDATA_ERROR,
	//	};

	//	//�켣�Ż������ṹ��
	//	public struct TOptimizeParamUser
	//	{
	//		public OptimizeState usePathOptimize;    //�Ƿ�ʹ��·���Ż���OPT_OFF:��ʹ��	OPT_ON:ʹ��

	//		public float tolerance;                  //����(suggest: rough:0.1, pre-finish:0.05, finish:0.01)

	//		public OptimizeMethod optimizeMethod;   //ѡ�������Ż���ʽ

	//		public OptimizeState keepLargeArc;      //�Ƿ����Բ����OPT_OFF��������� OPT_ON������

	//		public float blendingMinError;          //blending����С�趨���

	//		public float blendingMaxAngle;          //blending�����Ƕ����ƣ������߶������Ƕȴ��ڸýǶ�ʱ������blending����λ���ȣ�

	//	};

	//	public struct TErrorInfo
	//	{
	//		public ErrorID errorID;     //�����(INIT_ERROR:δ��ʼ��������PRE_PROCESS_ERROR:Ԥ����ģ�����
	//		public int errorRowNum;     //�����к�
	//	};

	//	public struct TPreStartPos
	//	{
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = LA_AXIS_NUM)]
	//		public double[] Pos;
	//	};

	//	public enum EMachineType
	//	{
	//		RW_C_ON_B = 0,//B Ϊ��һ��ת�ᣬC Ϊ�ڶ���ת��
	//		RW_B_ON_A,  //A Ϊ��һ��ת�ᣬB Ϊ�ڶ���ת��
	//		RW_A_ON_B,  //B Ϊ��һ��ת�ᣬA Ϊ�ڶ���ת��
	//		RW_C_ON_A,  //A Ϊ��һ��ת�ᣬC Ϊ�ڶ���ת��
	//		DT_B_ON_A,  //A Ϊ��һ��ת�ᣬB Ϊ�ڶ���ת��
	//		DT_A_ON_B,  //B Ϊ��һ��ת�ᣬA Ϊ�ڶ���ת��
	//		DT_A_ON_C,  //C Ϊ��һ��ת�ᣬA Ϊ�ڶ���ת��
	//		DT_B_ON_C,  //C Ϊ��һ��ת�ᣬB Ϊ�ڶ���ת��
	//		T_A_W_B,    //A Ϊ��һ��ת�ᣬB Ϊ�ڶ���ת��
	//		T_B_W_A,    //B Ϊ��һ��ת�ᣬA Ϊ�ڶ���ת��
	//		T_A_W_C,    //A Ϊ��һ��ת�ᣬC Ϊ�ڶ���ת��
	//		T_B_W_C,    //B Ϊ��һ��ת�ᣬC Ϊ�ڶ���ת��
	//	};

	//	public struct TMachCfgInfo
	//	{
	//		public EMachineType machineType;                        //��������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve1;                                //�������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public double[] primaryAxisPoint;                       //��һ��ת��������MCS������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public double[] slaveAxisPoint;                         //�ڶ���ת��������MCS������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public double[] toolLocationPoint;                      //��������ϵ������MCS������
	//		public short dirMode;                                   //��������ģʽ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	//		public short[] reserve2;                                //�������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	//		public short[] dir;                                     //���᷽��
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5 * 3)]
	//		public double[] axisVector;                             //�������߷���
	//	};

	//	public struct TLaserFollowDuoTablePrm
	//	{
	//		public short frqTableId;
	//		public short dutyTableId;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] pad1;
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public short[] pad2;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetupLookAheadCrd(short core, short crd, EMachineMode machineMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisFollowModeLa(short core, short crd, ref int pFollowMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetVelDefineModeLa(short core, short crd, EVelSettingDef velDefMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAccDefineModeLa(short core, short crd, EAccSettingDef accDefMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisLimitModeLa(short core, short crd, ref int pAxisLimitMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetWorkLimitModeLa(short core, short crd, EWorkLimitMode workLimitMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisVelValidModeLa(short core, short crd, int velValidAxis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetVelModeLa(short core, short crd, EVelMode velMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetVelSmoothModeLa(short core, short crd, short smoothMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetVelSmoothMode(short core, short crd, int smoothMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_PrintLACmdLa(short core, short crd, int printFlag, int clearFile);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_UpdateMachineBuildingFileLa(short core, short crd, int update);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitialMachineBuilding(short core, short crd, string pMachineCfgFileName, ref double machineCoordCenter, ref double workCoordCenter, double toolLength);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitialMachineBuildingEx(short core, short crd, string pMachineCfgFileName, ref double machineCoordCenter, ref double workCoordCenter, double toolLength);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitialMachineBuildingPara(short core, short crd, ref TMachCfgInfo pMachCfgInfo, ref double machineCoordCenter, ref double workCoordCenter, double toolLength);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdRTCPOn(short core, short crd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdRTCPOff(short core, short crd, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetNonlinearErrorControl(short core, short crd, int enable, double nonlinearError);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_EnableDiscreateArc(short core, short crd, short enable, double arcError);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisVelValidCompModeLa(short core, short crd, int enable, ref int pCompAxis);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowAxisProcessModeLa(short core, short crd, int AxisFollowMode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCmdVelLimitLa(short core, short crd, int enable, int n1, int n2, int mode);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitLookAheadEx(short core, short crd, ref TLookAheadParameter pLookAheadPara, short fifo, short motionMode, ref TPreStartPos pPreStartPos);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_InitLookAheadPara(short core, short crd, int lookAheadNum, double time, double radiusRatio, double scale, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetFollowAxisParaLa(short core, short crd, ref int pAxisLimitMode, ref double pVmax, ref double pAmax, ref double pDVmax);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCompToolLength(short core, short crd, double compToolLength);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetCompWorkCoordOffset(short core, short crd, ref double pCompWorkOffset);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetLookAheadSegCountEx(short core, short crd, out int pSegCount, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetMotionTimeEx(short core, short crd, out double pTime, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetUserSegNumEx(short core, short crd, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_CrdDataEx(short core, short crd, IntPtr pCrdData, short fifo);  //����ʱ���� IntPtr.Zero GTN_CrdDataEx(1, System.IntPtr.Zero, 0);      

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BezierEx(short core, short crd, ref TBezierPrm pBezier, double synVel, double synAcc, double velEnd, long segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYEx(short core, short crd, double x, double y, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYG0Ex(short core, short crd, double x, double y, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZEx(short core, short crd, double x, double y, double z, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZG0Ex(short core, short crd, double x, double y, double z, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAEx(short core, short crd, double x, double y, double z, double a, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZAG0Ex(short core, short crd, double x, double y, double z, double a, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZACEx(short core, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZACG0Ex(short core, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZACUVWEx(short core, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_LnXYZACUVWG0Ex(short core, short crd, ref double pPos, short posMask, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYREx(short core, short crd, double x, double y, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZREx(short core, short crd, double y, double z, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXREx(short core, short crd, double z, double x, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYCEx(short core, short crd, double x, double y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcYZCEx(short core, short crd, double y, double z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcZXCEx(short core, short crd, double z, double x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYZEx(short core, short crd, double x, double y, double z, double interX, double interY, double interZ, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYRACEx(short core, short crd, double x, double y, double a, double c, double radius, short circleDir, double synVel, double synAcc, long segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYCACEx(short core, short crd, double x, double y, double a, double c, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, long segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_ArcXYZACEx(short core, short crd, double x, double y, double z, double a, double c, double interX, double interY, double interZ, double interA, double interC, double synVel, double synAcc, long segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYRZEx(short core, short crd, double x, double y, double z, double radius, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_HelixXYCZEx(short core, short crd, double x, double y, double z, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, int segNum, short override2, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDelayEx(short core, short crd, ushort delayTime, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufGearEx(short core, short crd, short gearAxis, double deltaPos, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufMoveEx(short core, short crd, short moveAxis, double pos, double vel, double acc, short modal, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufIOEx(short core, short crd, ushort doType, ushort doMask, ushort doValue, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufEnableDoBitPulseEx(short core, short crd, short doType, short doIndex, ushort highLevelTime, ushort lowLevelTime, int pulseNum, short firstLevel, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDisableDoBitPulseEx(short core, short crd, short doType, short doIndex, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDAEx(short core, short crd, short chn, short daValue, short fifo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowStartEx(short core, short crd, int masterSegment, int slaveSegment, int masterFrameWidth, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowNextEx(short core, short crd, int width, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufFollowReturnEx(short core, short crd, double vel, double acc, short smoothPercent, short fifo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufSmartCutterOnEx(short core, short crd, short index, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufSmartCutterOffEx(short core, short crd, short index, short fifo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserOnEx(short core, short crd, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserOffEx(short core, short crd, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowModeEx(short core, short crd, short source, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowTableEx(short core, short crd, short tableId, double minPower, double maxPower, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowOffEx(short core, short crd, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserPrfCmdEx(short core, short crd, double laserPower, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowRatioEx(short core, short crd, double ratio, double minPower, double maxPower, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufWaitDiEx(short core, short crd, short diType, ushort diIndex, ushort level, short continueTime, int overTime, short flagMode, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufWaitLongVarEx(short core, short crd, short index, int value, int overTime, short flagMode, int segNum, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDoBitEx(short core, short crd, int doType, ushort index, short value, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufDoBitDelayEx(short core, short crd, ushort doType, ushort index, short value, int delayTime, short fifo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosCompareStartEx(short core, short crd, short fifo, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosCompareStopEx(short core, short crd, short fifo, short index);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPosComparePulseEx(short core, short crd, short index, short outputMode, short level, ushort outputOulseWidth, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufMoveJogEx(short core, short crd, short moveAxis, double vel, double acc, short modal, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufStopEx(short core, short crd, int mask, int option, short fifo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufLaserFollowDuoTableEx(short core, short crd, ref TLaserFollowDuoTablePrm pPrm, short fifo, short channel);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetRadiusRatioTableLa(short core, short crd, short count, ref double pRadius, ref double pRatio);
	//	/*-----------------------------------------------------------*/
	//	/* Comp                                                      */
	//	/*-----------------------------------------------------------*/

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufPrfCompEnableEx(short core, short crd, short fifo, short profile, short enable, short enableType);

	//	public struct TAxisPressPid
	//	{
	//		public double kp;
	//		public double ki;
	//		public double kd;
	//		public double integralLimit;    //���ּ���
	//		public double derivativeLimit;  //΢�ּ���
	//		public double limit;            //�������ƣ������ѹ��
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] pad1;
	//	};

	//	public const short PRESS_COMPENSATE_MODE_LINEAR = 0;                          // ���Բ���
	//	public const short PRESS_COMPENSATE_MODE_TABLE = 1;                           // ������
	//	public const short PRESS_COMPENSATE_MODE_REGION_LEARN = 2;                    // ��������ѧϰ����

	//	public struct TAxisPressCompensate
	//	{
	//		public short enable;                  //�Ƿ�ʹ�ܣ�0-�رգ�1-ʹ��
	//		public short type;                    //�������ͣ���ѹ������ģ������
	//		public short dimension;               //���������ά�ȣ����3ά
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] index;                 //���������,DAC��1��ʼ��ECAT IOģ��վ�Ŵ�0��ʼ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] subIndex;              //�������������,DAC�ò�����Ч��ECAT IOģ���IOMAP��0��ʼ
	//		public short mode;                    //ģʽ�����Ի��ǲ��
	//		public short revolveAxis;             //����������ת�Ƕȵ����
	//		public short regionAxisIndex;         //��������������Ч�Ĳο���
	//		public short relatedMasterIndex;      //�涯���������
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] pad1;
	//		public double target;                  //Ŀ�������ѹ
	//		public double thredshold;              //thredshold��ʲôʱ��ʼ����
	//		public double deadZone;                //���������ѹ�������ڲ�����
	//		public double factor;                  //����λ�Ƶ�ת��ϵ��
	//		public double revolveOffset;           //��ʼ��ת����������Ĭ�Ϻϳɷ����ingdex[0]�ķ����غ�
	//		public double revolveScale;            //��ת���һȦ������
	//		public TAxisPressPid pid;
	//		public int compPosMaxP;              //�������λ������[N,P]�Ķ˵�P
	//		public int compPosMaxN;              //�������λ������[N,P]�Ķ˵�N
	//		public double k;                       //�������˲�ϵ�� 0-1 ��ֵԽ���˲�Խǿ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	//		public double[] pad2;
	//		public int activeRegionP;            //����������Ч�Ĺ滮λ������[N,P]�Ķ˵�P
	//		public int activeRegionN;            //����������Ч�Ĺ滮λ������[N,P]�Ķ˵�N
	//		public int activeRegionInterval;     //����������Ч�Ĺ滮λ�������ڵ���ѧϰ������modeΪ��ѧϰPRESS_COMPENSATE_MODE_REGION_LEARNʱ��Ч
	//		public int relatedMasterEven;        //�涯����ı���
	//		public int relatedSlaveEven;         //�涯����ı���
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public int[] pad3;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisPressCompensate(short core, short axis, ref TAxisPressCompensate pPressComp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPressCompensate(short core, short axis, out TAxisPressCompensate pPressComp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAxisPressCompensateTable(short core, short axis, short index, int count, ref double pPressData, ref double pPosData);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SelectAxisPressCompensateTable(short core, short axis, short index);

	//	public struct TAxisPressCompensateFixFactor
	//	{
	//		public short type;                 //�������ͣ���ѹ������ģ������
	//		public short dimension;            //���������ά�ȣ����3ά
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] index;              //���������,DAC��1��ʼ��ECAT IOģ��վ�Ŵ�0��ʼ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] subIndex;           //�������������,DAC�ò�����Ч��ECAT IOģ���IOMAP��0��ʼ

	//		public double targetMax;           //�궨�������ֵ���ﵽ�򳬹���ֵʱ�궨����
	//		public double targetMin;           //�궨������Сֵ���ﵽ��С�ڸ�ֵʱ�궨����
	//		public double factor;              //����λ�Ƶ�ת��ϵ�������ʱ����0,��ȡ״̬ʱ�õ��궨ֵ��

	//		public int fixRegionP;           //�궨�滮λ������[N,P]�Ķ˵�P�����λ�õ����λ��
	//		public int fixRegionN;           //�궨�滮λ������[N,P]�Ķ˵�N�����λ�õ����λ��
	//		public int fixRegionInterval;    //�궨�滮λ�������ڵı궨���

	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	//		public int[] tmp;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StartAxisPressCompensateFixFactor(short core, short axis, ref TAxisPressCompensateFixFactor pPressComp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPressCompensateFixFactorStatus(short core, short axis, out short pFixFactorSts, out TAxisPressCompensateFixFactor pPressComp);

	//	public struct TAxisPressCompensateFixPid
	//	{
	//		public short type;           //�������ͣ���ѹ������ģ������
	//		public short dimension;      //���������ά�ȣ����3ά
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] index;        //���������,DAC��1��ʼ��ECAT IOģ��վ�Ŵ�0��ʼ
	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	//		public short[] subIndex;     //�������������,DAC�ò�����Ч��ECAT IOģ���IOMAP��0��ʼ

	//		public double target;        //Ŀ�������ѹ
	//		public double factor;        //����λ�Ƶ�ת��ϵ��
	//		public TAxisPressPid pid;

	//		public int fixPosLimitP;    //�궨λ������[N,P]�Ķ˵�P
	//		public int fixPosLimitN;    //�궨����λ������[N,P]�Ķ˵�N
	//		public double thredshold;    //thredshold��ʲôʱ��ʼ����
	//		public double deadZone;      //���������ѹ�������ڲ�����

	//		//�������ڲ�����������ʹ�ã������û��ӿ�û�иò���
	//		public double Knp;           //ѹ����ȫ������
	//		public double K1;            //ȫ���������ϵ��1
	//		public double K2;            //ȫ���������ϵ��2
	//		public double K3;            //ȫ���������ϵ��3
	//		public double Krise;         //����ϵ��
	//		public double Kpeak;         //��ֵϵ��
	//		public double Tset;          //Ŀ����Ӧʱ��
	//		public double Td;            //������Ӧʱ��	

	//		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	//		public double[] tmp;
	//	}
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_StartAxisPressCompensateFixPid(short core, short axis, ref TAxisPressCompensateFixPid pPressComp);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAxisPressCompensateFixPidStatus(short core, short axis, out short pFixPidSts, out TAxisPressCompensateFixPid pPressComp);


	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufAxisPressCompensatePrmEx(short core, short crd, short axis, double target, double thredshold, short fifo);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_BufAxisPressCompensateEx(short core, short crd, short axis, short enable, double deadZone, double factor, short fifo);

	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAdcBias(short core, short adc, short bias);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAdcBias(short core, short adc, out short pBias);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_SetAuAdcBias(short core, short auAdc, short bias);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_GetAuAdcBias(short core, short auAdc, out short pBias);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_OpenCard(short channel, string pPrm, string pFileName);
	//	[DllImport("gts.dll")]
	//	public static extern short GTN_NetInit(short mode, string pFileName, short overTime, out int pStatus);


	//}
	//#endregion

	//#region 二次开发

	//public interface IMotionController
	//{
	//	/// <summary>
	//	/// 运动控制卡错误事件
	//	/// </summary>
	//	event DeviceErrorEvent ErrorEvent;

	//	/// <summary>
	//	/// 控制器名字
	//	/// </summary>
	//	string ControllerName { get; }

	//	/// <summary>
	//	/// 配置对象
	//	/// </summary>
	//	WorkBaseObject ConnectId { get; set; }


	//	/// <summary>
	//	/// 硬件编号
	//	/// </summary>
	//	short DeviceId { get; }


	//	bool IsOpen { get; set; }

	//	/// <summary>
	//	/// 当前控制卡Controller下 Axis
	//	/// </summary>
	//	List<IAxis> Axises { get; set; }


	//	/// <summary>
	//	/// 是否以Demo模式打开控制器
	//	/// </summary>
	//	/// <returns></returns>
	//	bool Open(bool isDemo);

	//	/// <summary>
	//	/// 关闭控制器
	//	/// </summary>
	//	/// <returns></returns>
	//	bool Close();


	//	/// <summary>
	//	/// 直线插补运动
	//	/// </summary>
	//	/// <param name="dimension"></param>
	//	/// <param name="axises"></param>
	//	/// <param name="targetPos"></param>
	//	/// <param name="crdVel"></param>
	//	/// <param name="crdAcc"></param>
	//	/// <param name="isOpenCo2Laser">是否打开CO2激光器</param>
	//	/// <param name="motonLaserParam">控制卡控制激光器时相关参数</param>
	//	/// <returns></returns>
	//	int LineMove(int dimension, List<IAxis> axises, List<double> targetPos, double crdVel, double crdAcc, bool isOpenCo2Laser, MotonLaserParam motonLaserParam);


	//	/// <summary>
	//	/// 圆弧插补运动(圆心坐标描述法)，用户画整圆
	//	/// </summary>
	//	/// <param name="dimension"></param>
	//	/// <param name="axises"></param>
	//	/// <param name="targetPos"></param>
	//	/// <param name="center"></param>
	//	/// <param name="crdVel"></param>
	//	/// <param name="crdAcc"></param>
	//	/// <param name="isCW">为true代表是顺时针圆弧插补，否则为逆时针圆弧插补</param>
	//	/// <param name="isOpenCo2Laser">是否打开CO2激光器</param>
	//	/// <param name="motonLaserParam">控制卡控制激光器时相关参数</param>
	//	/// <returns></returns>
	//	int CircleMove(int dimension, List<IAxis> axises, List<double> targetPos, List<double> center, double crdVel, double crdAcc, bool isCW, bool isOpenCo2Laser, MotonLaserParam motonLaserParam);


	//	/// <summary>
	//	/// 圆弧插补运动(半径描述法)，用于画圆弧
	//	/// </summary>
	//	/// <param name="dimension"></param>
	//	/// <param name="axises"></param>
	//	/// <param name="targetPos"></param>
	//	/// <param name="r"></param>
	//	/// <param name="isCW"></param>
	//	/// <param name="crdVel"></param>
	//	/// <param name="crdAcc"></param>
	//	/// <param name="isOpenCo2Laser"></param>
	//	/// <param name="motonLaserParam"></param>
	//	int ArcMove(int dimension, List<IAxis> axises, List<double> targetPos, double r, bool isCW, double crdVel, double crdAcc, bool isOpenCo2Laser, MotonLaserParam motonLaserParam);

	//	/// <summary>
	//	/// 在外部触发错误事件
	//	/// </summary>
	//	/// <param name="deviceErrorEventArgs"></param>
	//	void TriggerError(DeviceErrorEventArgs deviceErrorEventArgs);


	//	void SendCmd(string val, object value);

	//	object ReceiveCmd(string val);


	//	#region 激光器出光相关

	//	/// <summary>
	//	///  初始化激光器参数(占空比模式)
	//	/// </summary>
	//	/// <param name="LaserChannel">激光器通道(单核4路激光)</param>
	//	/// <param name="Duty">占空比(0%-100%)</param>
	//	/// <param name="outFrq">激光器频率(0-96kHz)</param>
	//	/// <param name="MaxPower">最大值(100%)</param>
	//	/// <param name="MinPower">最小值(0%)</param>
	//	/// <returns></returns>
	//	bool LaserInit(short LaserChannel, double Duty, double outFrq, double MaxPower, double MinPower);

	//	/// <summary>
	//	/// 控制激光器开关光
	//	/// </summary>
	//	/// <param name="isOpen">是否打开</param>
	//	/// <param name="LaserChannel">激光器通道(单核4路激光)</param>
	//	/// <returns></returns>
	//	bool LaserOn(bool isOpen, short LaserChannel);
	//	#endregion

	//	#region IO相关
	//	/// <summary>
	//	///  //打开数字量输出
	//	/// </summary>
	//	/// <param name="index"></param>
	//	void OpenOutputIO(short index);

	//	/// <summary>
	//	/// //关闭数字量输出
	//	/// </summary>
	//	/// <param name="index"></param>
	//	void CloseOutputIO(short index);


	//	/// <summary>
	//	/// //读取数字量输出
	//	/// </summary>
	//	/// <param name="doIndex"></param>
	//	/// <returns></returns>
	//	short ReadOutputIO(short doIndex);

	//	/// <summary>
	//	/// //读取数字量输入
	//	/// </summary>
	//	/// <param name="diIndex"></param>
	//	/// <returns></returns>
	//	short ReadInputIO(short diIndex);

	//	/// <summary>
	//	/// 打开pso
	//	/// </summary>
	//	/// <param name="isOpen"></param>
	//	/// <param name="pSOPara">pso参数</param>
	//	void OpenPso(bool isOpen, PSOPara pSOPara);

	//	#endregion

	//}
	////如果固高程序中指令执行返回值为非0，说明指令执行错误;当指令执行成功时，会返回0;

	//public interface IAxis
	//{
	//	/// <summary>
	//	/// 状态改变事件，传入改变的参数名称
	//	/// </summary>
	//	event Action<string> StateChanged;

	//	WorkBaseObject Axis { get; set; }

	//	/// <summary>
	//	/// 轴号
	//	/// </summary>
	//	short Id { get; set; }

	//	/// <summary>
	//	/// 轴名称
	//	/// </summary>
	//	string Name { get; set; }

	//	bool WaitPosition(int timeout = 10000 * 100);

	//	/// <summary>
	//	/// 获取轴当前位置
	//	/// </summary>
	//	/// <returns></returns>
	//	double GetCmdPosition();

	//	/// <summary>
	//	/// 轴所属控制器
	//	/// </summary>
	//	IMotionController ParentControl { get; }

	//	/// <summary>
	//	/// 轴参数
	//	/// </summary>
	//	AxisParm Param { get; set; }

	//	/// <summary>
	//	/// 伺服使能
	//	/// </summary>
	//	/// <param name="on"></param>
	//	/// <returns></returns>
	//	int Servo(bool on);

	//	/// <summary>
	//	/// 回零运动
	//	/// </summary>
	//	/// <returns></returns>
	//	int Home();

	//	/// <summary>
	//	/// 运动完成
	//	/// </summary>
	//	/// <returns></returns>
	//	bool HomeFinished();

	//	/// <summary>
	//	/// Jog运动开始
	//	/// </summary>
	//	/// <param name="dir">运动方向</param>
	//	/// <returns></returns>
	//	int JogStart(DirMove dir);
	//	/// <summary>
	//	/// 点位相对运动
	//	/// </summary>
	//	/// <returns></returns>
	//	int RelativeMove(double distance);

	//	/// <summary>
	//	/// 点位绝对运动
	//	/// </summary>
	//	/// <param name="destination"></param>
	//	/// <returns></returns>
	//	int AbsoluteMove(double destination);

	//	/// <summary>
	//	/// 停止运动
	//	/// </summary>
	//	/// <returns></returns>
	//	int StopMove();

	//	/// <summary>
	//	/// 获取当前轴状态
	//	/// </summary>
	//	/// <param name="state"></param>
	//	/// <returns></returns>
	//	int GetState(ref AxisState state);

	//	/// <summary>
	//	/// 设置正向软限位
	//	/// </summary>
	//	/// <param name="pos"></param>
	//	/// <returns></returns>
	//	int SetSoftPel(double pos);

	//	/// <summary>
	//	/// 获取正向软限位
	//	/// </summary>
	//	/// <param name="pos"></param>
	//	/// <returns></returns>
	//	int GetSoftPel(ref double pos);

	//	/// <summary>
	//	/// 设置负向软限位
	//	/// </summary>
	//	/// <param name="pos"></param>
	//	/// <returns></returns>
	//	int SetSoftMel(double pos);

	//	/// <summary>
	//	/// 获取负向软限位
	//	/// </summary>
	//	/// <param name="pos"></param>
	//	/// <returns></returns>
	//	int GetSoftMel(ref double pos);

	//	/// <summary>
	//	/// 设置速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int SetVelocity(double value);

	//	/// <summary>
	//	/// 获取速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int GetVelocity(ref double value);

	//	/// <summary>
	//	/// 设置加速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int SetAcceleration(double value);

	//	/// <summary>
	//	/// 获取加速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int GetAcceleration(ref double value);

	//	/// <summary>
	//	/// 设置减速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int SetDeceleration(double value);

	//	/// <summary>
	//	/// 获取减速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int GetDeceleration(ref double value);

	//	/// <summary>
	//	/// 设置Jog速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int SetJogVelocity(double value);

	//	/// <summary>
	//	/// 获取Jog速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int GetJogVelocity(ref double value);

	//	/// <summary>
	//	/// 设置Jog加速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int SetJogAccelerate(double value);

	//	/// <summary>
	//	/// 获取Jog加速度
	//	/// </summary>
	//	/// <param name="value"></param>
	//	/// <returns></returns>
	//	int GetJogAccelerate(ref double value);

	//	/// <summary>
	//	/// 轴是否处在移动状态
	//	/// </summary>
	//	/// <returns></returns>
	//	bool IsMotionDone();

	//	/// <summary>
	//	/// 清除指定轴的状态: 驱动器报警标志、跟随误差越限标志、限位触发标志等
	//	/// </summary>
	//	/// <returns></returns>
	//	bool ClearAxisStatus();

	//	/// <summary>
	//	/// 设置轴的原点
	//	/// </summary>
	//	void SetAxisZeroPos();

	//}

	//public class GuGaoCardGSN : IAxis, IDisposable
	//{
	//	public double MMToPulses(double mm)
	//	{
	//		var pules = Param.PulseEquivalent * mm;
	//		return pules;
	//	}

	//	public double PulsesToMM(double pules)
	//	{
	//		var mm = pules / Param.PulseEquivalent;
	//		return mm;
	//	}

	//	/// <summary>
	//	/// mm/秒->脉冲/毫秒的转化
	//	/// </summary>
	//	public double VelToCardVel(double vel)
	//	{
	//		var res = vel / 1000 * 10000;
	//		return res;
	//	}

	//	/// <summary>
	//	/// 脉冲/毫秒->mm/秒的转化
	//	/// </summary>
	//	public double CardVelToVel(double vel)
	//	{
	//		var res = vel / 10000 * 1000;
	//		return res;
	//	}

	//	#region 设置轴参数
	//	public int SetVelocity(double value)
	//	{
	//		Param.Velocity = value;
	//		return 0;
	//	}

	//	public int GetVelocity(ref double value)
	//	{
	//		value = Param.Velocity;
	//		return 0;
	//	}

	//	public int SetAcceleration(double value)
	//	{
	//		Param.Acc = value;
	//		return 0;
	//	}

	//	public int GetAcceleration(ref double value)
	//	{
	//		value = Param.Acc;
	//		return 0;
	//	}

	//	public int SetDeceleration(double value)
	//	{
	//		Param.Dec = value;
	//		return 0;
	//	}

	//	public int GetDeceleration(ref double value)
	//	{
	//		value = Param.Dec;
	//		return 0;
	//	}

	//	public int SetJogVelocity(double value)
	//	{
	//		Param.JogVelocity = value;
	//		return 0;
	//	}

	//	public int GetJogVelocity(ref double value)
	//	{
	//		value = Param.JogVelocity;
	//		return 0;
	//	}

	//	public int SetJogAccelerate(double value)
	//	{
	//		Param.JogAccelerate = value;
	//		return 0;
	//	}

	//	public int GetJogAccelerate(ref double value)
	//	{
	//		value = Param.JogAccelerate;
	//		return 0;
	//	}
	//	#endregion

	//	#region 获取轴使能
	//	public bool GetAxisEnable()
	//	{
	//		Z = GTN_GetSts(Param.core, Param.NAxis, out status, 1, out pClock);
	//		commandHandler("GTN_GetSts", Z);
	//		if ((status & 0x200) == 0)
	//			en = 0;
	//		else
	//			en = 1; //为1代表有使能
	//		return en == 1;
	//	}
	//	#endregion

	//	#region 使能
	//	public int Servo(bool on)
	//	{
	//		try
	//		{
	//			if (on) //上使能
	//			{
	//				Z = GTN_ClrSts(Param.core, Param.NAxis, 1); //清除轴状态
	//				commandHandler("GTN_ClrSts", Z);
	//				Z = GTN_AxisOn(Param.core, Param.NAxis); //使能
	//				commandHandler("GTN_AxisOn", Z);
	//				return 0;
	//			}
	//			else
	//			{
	//				Z = GTN_AxisOff(Param.core, Param.NAxis); //下使能
	//				commandHandler("GTN_AxisOff", Z);
	//				return 0;
	//			}
	//		}
	//		catch (Exception e) { }
	//		return 0;
	//	}
	//	#endregion

	//	#region 相对移动
	//	/// <summary>
	//	/// 相对移动
	//	/// </summary>
	//	/// <param name="distance">相对定位距离（单位：MM）</param>
	//	/// <returns></returns>
	//	public int RelativeMove(double DistanceInMM)
	//	{
	//		try
	//		{
	//			//点位运动：完成点到点运动，在运动过程中可以随时修改目标位置和目标速度
	//			int Return = 0;
	//			uint PClock = 0;
	//			double Pos = 0;

	//			if (GetAxisEnable() == false)
	//			{
	//				Return += GTN_AxisOn(Param.core, Param.NAxis); //使能ON
	//			}

	//			TTrapPrm TrapParameter = new TTrapPrm();
	//			Return += GTN_GetTrapPrm(Param.core, Param.NAxis, out TrapParameter); //读取运动参数
	//			double Speed = Convert.ToDouble(VelToCardVel(Param.Velocity)); //增量运动的速度
	//			TrapParameter.acc = Convert.ToDouble(VelToCardVel(Param.Acc)); //加速度
	//			TrapParameter.dec = Convert.ToDouble(VelToCardVel(Param.Dec)); //减速度
	//			TrapParameter.smoothTime = 10; //平滑时间s
	//			TrapParameter.velStart = 3; //起跳速度

	//			Return += GTN_ClrSts(Param.core, Param.NAxis, 1); //清除轴状态--运动之前必须调用此函数清除轴状态
	//			Return += GTN_PrfTrap(Param.core, Param.NAxis); //设置轴为点位模式，参数：轴号
	//			Return += GTN_SetTrapPrm(Param.core, Param.NAxis, ref TrapParameter); //设置运动参数
	//			Return += GTN_SetVel(Param.core, Param.NAxis, Speed); //设置运动速度
	//			Return += GTN_GetPrfPos(Param.core, Param.NAxis, out Pos, 1, out PClock);

	//			//把“当前位置+相对运动值”作为目标值
	//			Return += GTN_SetPos(
	//				Param.core,
	//				Param.NAxis,
	//				(int)Pos + (int)MMToPulses(DistanceInMM)
	//			);
	//			Return += GTN_Update(Param.core, 1 << Param.NAxis - 1);
	//			return 0;
	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show(ex.Message);
	//			return -1;
	//		}
	//	}
	//	#endregion

	//	#region 判断是否运动完成
	//	public bool IsMotionDone()
	//	{
	//		//轴状态
	//		Z = GTN_GetSts(Param.core, Param.NAxis, out status, 1, out pClock);
	//		commandHandler("GTN_GetSts", Z);
	//		if ((status & 0x400) == 0)
	//		{
	//			run = 0; //为0代表运动完成
	//			return true;
	//		}
	//		else
	//		{
	//			run = 1; //为1代表处在运动状态
	//			return false;
	//		}
	//	}
	//	#endregion

	//	#region 获取负向软限位
	//	public int GetSoftMel(ref double pos)
	//	{
	//		try
	//		{
	//			Z = GTN_GetSoftLimitEx(
	//				Param.core,
	//				Param.NAxis,
	//				out double pPositive,
	//				out double pNegative
	//			);
	//			commandHandler("GTN_GetSoftLimitEx", Z);
	//			Param.SoftPel = pPositive;
	//			Param.SoftMel = pNegative;
	//			return (int)Param.SoftMel;
	//		}
	//		catch (Exception ex) { }
	//		return 0;
	//	}
	//	#endregion

	//	#region 设置负向软限位
	//	public int SetSoftMel(double pos)
	//	{
	//		try
	//		{
	//			Param.SoftMel = (int)MMToPulses(Param.SoftMel);
	//			Param.SoftPel = (int)MMToPulses(Param.SoftPel);

	//			Z = GTN_LmtsOnEx(Param.core, Param.NAxis, -1, 1);
	//			commandHandler("GTN_LmtsOnEx", Z);
	//			Z = GTN_SetSoftLimitEx(Param.core, Param.NAxis, Param.SoftMel, Param.SoftPel);
	//			commandHandler("GTN_SetSoftLimitEx", Z);
	//		}
	//		catch (Exception ex) { }
	//		return 0;
	//	}
	//	#endregion

	//	#region  获取正向软限位
	//	public int GetSoftPel(ref double pos)
	//	{
	//		try
	//		{
	//			Z = GTN_GetSoftLimitEx(
	//				Param.core,
	//				Param.NAxis,
	//				out double pPositive,
	//				out double pNegative
	//			);
	//			commandHandler("GTN_GetSoftLimitEx", Z);
	//			Param.SoftPel = pPositive;
	//			Param.SoftMel = pNegative;
	//			return (int)Param.SoftPel;
	//		}
	//		catch (Exception ex) { }
	//		return 0;
	//	}
	//	#endregion

	//	#region  设置正向软限位
	//	public int SetSoftPel(double pos)
	//	{
	//		Param.SoftMel = (int)MMToPulses(Param.SoftMel);
	//		Param.SoftPel = (int)MMToPulses(Param.SoftPel);
	//		Z = GTN_LmtsOnEx(Param.core, Param.NAxis, -1, 1);
	//		commandHandler("GTN_LmtsOnEx", Z);
	//		Z = GTN_SetSoftLimitEx(Param.core, Param.NAxis, Param.SoftMel, Param.SoftPel);
	//		commandHandler("GTN_SetSoftLimitEx", Z);
	//		return 0;
	//	}
	//	#endregion

	//	#region 获取当前位置
	//	public double GetCmdPosition()
	//	{
	//		try
	//		{
	//			Z = GTN_GetEncPos(Param.core, Param.NAxis, out encPos, 1, out pClock); //实际位置
	//			commandHandler("GTN_GetEncPos", Z);
	//			var pos = PulsesToMM(encPos);
	//			return pos;
	//		}
	//		catch (Exception ex) { }
	//		return 0;
	//	}
	//	#endregion

	//	#region 获取当前轴状态
	//	int status,
	//		alarm,
	//		error,
	//		positive,
	//		negetive,
	//		st, //平滑停止
	//		et, //紧急停止
	//		en, //使能
	//		run,
	//		compare;
	//	int prfMode;
	//	double prfPos,
	//		prfVel,
	//		encPos,
	//		encVel;
	//	uint pClock;
	//	short Z1 = 0;

	//	public int GetState(ref AxisState state)
	//	{
	//		try
	//		{
	//			//运动模式
	//			Z1 = GTN_GetPrfMode(Param.core, Param.NAxis, out prfMode, 1, out pClock);
	//			//commandHandler("GTN_GetPrfMode", Z);
	//			prfMode.ToString(); //运动模式显示
	//			switch (prfMode)
	//			{
	//				case 0:
	//					state.PrfMode = "点位运动";
	//					break;
	//				case 1:
	//					state.PrfMode = "JOG运动";
	//					break;
	//				case 2:
	//					state.PrfMode = "PT运动";
	//					break;
	//				case 3:
	//					state.PrfMode = "电子齿轮运动";
	//					break;
	//				case 4:
	//					state.PrfMode = "FOLLOW运动";
	//					break;
	//				case 5:
	//					state.PrfMode = "插补运动";
	//					break;
	//				case 6:
	//					state.PrfMode = "PVT运动";
	//					break;
	//				default:
	//					state.PrfMode = "无运动";
	//					break;
	//			}
	//			//位置信息
	//			Z1 = GTN_GetPrfPos(Param.core, Param.NAxis, out prfPos, 1, out pClock); //规划位置
	//			state.PlanPos = PulsesToMM(prfPos);
	//			//commandHandler("GTN_GetPrfPos", Z);
	//			Z1 = GTN_GetPrfVel(Param.core, Param.NAxis, out prfVel, 1, out pClock); //规划速度
	//			state.PlanSpeed = CardVelToVel(prfVel);
	//			//commandHandler("GTN_GetPrfVel", Z);
	//			Z1 = GTN_GetEncPos(Param.core, Param.NAxis, out encPos, 1, out pClock); //实际位置
	//																					//commandHandler("GTN_GetEncPos", Z);
	//			state.CmdPos = PulsesToMM(encPos); //实际位置

	//			Z1 = GTN_GetEncVel(Param.core, Param.NAxis, out encVel, 1, out pClock); //实际速度
	//																					//commandHandler("GTN_GetEncVel", Z);
	//			state.CmdSpeed = CardVelToVel(encVel); //实际速度

	//			//轴状态
	//			Z1 = GTN_GetSts(Param.core, Param.NAxis, out status, 1, out pClock);
	//			//commandHandler("GTN_GetSts", Z);
	//			if ((status & 0x002) == 0)
	//				alarm = 0;
	//			else
	//				alarm = 1; //报警信号
	//			if ((status & 0x010) == 0)
	//				error = 0;
	//			else
	//				error = 1;
	//			if ((status & 0x020) == 0)
	//				positive = 0;
	//			else
	//				positive = 1; //正限位
	//			if ((status & 0x040) == 0)
	//				negetive = 0;
	//			else
	//				negetive = 1; //负限位
	//			if ((status & 0x080) == 0)
	//				st = 0;
	//			else
	//				st = 1; //平滑停止
	//			if ((status & 0x100) == 0)
	//				et = 0;
	//			else
	//				et = 1; //紧急停止
	//			if ((status & 0x200) == 0)
	//				en = 0;
	//			else
	//				en = 1; //为1代表有使能
	//			if ((status & 0x400) == 0)
	//				run = 0;
	//			else
	//				run = 1; //为1代表处在运动状态
	//			if ((status & 0x800) == 0)
	//				compare = 0;
	//			else
	//				compare = 1;
	//			THomeStatus HomeSts;
	//			var sRtn = GTN_GetHomeStatus(Param.core, Param.NAxis, out HomeSts);
	//			//commandHandler("GTN_GetHomeStatus", Z);

	//			state.Moving = run == 1; //是否在运动
	//			state.Servo = en == 1; //使能信号
	//			state.PEL = positive == 1; //正限位状态
	//			state.MEL = negetive == 1; //负限位状态
	//			state.AlreadyHome = HomeSts.run == 0; //HomeSts.run=1代表回零正在回零，为0代表已经在零点
	//			state.ORG = HomeSts.run == 0; //硬件原点信号*/
	//			state.ALM = alarm == 1; //报警信号
	//			state.EMG = et == 1; //硬件急停信号
	//		}
	//		catch (Exception ex) { }
	//		return 0;
	//	}
	//	#endregion

	//	#region 回零
	//	GSNCard Card = new GSNCard();

	//	public int Home()
	//	{
	//		try
	//		{
	//			THomePrm tHomePrm = new THomePrm(); //回零参数结构体
	//			THomeStatus tHomeStatus01 = new THomeStatus(); //回零状态结构体
	//			THomeStatus tHomeStatus = new THomeStatus();
	//			tHomePrm.moveDir = (short)Param.SelectedHomePosition;
	//			tHomePrm.indexDir = (short)Param.SelectedIndexPosition;
	//			tHomePrm.homeOffset = (int)MMToPulses(Param.HomeOffset);
	//			tHomePrm.edge = 0; //0：下降沿，非0：上升沿
	//			tHomePrm.velHigh = 1000; //一段速
	//			tHomePrm.velLow = 1000;
	//			; //二段速
	//			tHomePrm.acc = VelToCardVel(Param.Acc);
	//			; //回零加速度
	//			tHomePrm.dec = VelToCardVel(Param.Dec);
	//			; //回零减速度
	//			tHomePrm.smoothTime = 10; //平滑时间，取值范围[0,50]
	//			tHomePrm.searchHomeDistance = (int)MMToPulses(Param.SearchHomeDistance);
	//			; //home搜索距离  0表示最大805306368
	//			tHomePrm.searchIndexDistance = (int)MMToPulses(Param.SearchIndexDistance);
	//			; //Index搜索距离  0表示最大805306368
	//			tHomePrm.searchHomeDistance = 0;
	//			; //home搜索距离  0表示最大805306368
	//			tHomePrm.searchIndexDistance = 0;
	//			; //Index搜索距离  0表示最大805306368
	//			tHomePrm.escapeStep = 1000;
	//			///限位回原点时反向脱离距离或者压在感应器上脱离的距离，不能为0
	//			tHomePrm.mode = (short)Param.SelectedHomeMode;
	//			;
	//			Stopwatch sw = new Stopwatch();
	//			sw.Start();

	//			Thread threadHome;
	//			//回零线程
	//			threadHome = new Thread(() =>
	//			{
	//				int pStatus;
	//				uint pClock;
	//				//回零前停止轴运动，清除一下状态和位置
	//				Z = GTN_Stop(Param.core, 1 << Param.NAxis - 1, 0);
	//				Z = GTN_ClrSts(Param.core, Param.NAxis, 1);
	//				Z = GTN_ZeroPos(Param.core, Param.NAxis, 1);
	//				Z = GTN_GoHome(Param.core, Param.NAxis, ref tHomePrm); //回零
	//				do
	//				{
	//					Z = GTN_GetHomeStatus(Param.core, Param.NAxis, out tHomeStatus01); //获取回原点状态
	//				} while (tHomeStatus01.run == 1 || tHomeStatus01.stage != 100); //等待搜索原点停止
	//				Z = GTN_ZeroPos(Param.core, Param.NAxis, 1); //到位后位置清零
	//				Thread.Sleep(20);
	//				AbsoluteMove(Param.HomeOffset);
	//				Thread.Sleep(200);
	//				Z = GTN_ZeroPos(Param.core, Param.NAxis, 1); //到位后位置清零
	//			})
	//			{
	//				IsBackground = true
	//			};
	//			threadHome.Start();

	//			while (true)
	//			{
	//				GTN_GetHomeStatus(Param.core, Param.NAxis, out tHomeStatus);
	//				commandHandler("GTN_GetHomeStatus", Z);
	//				if (tHomeStatus.run == 0) //已经到零点
	//				{
	//					break;
	//				}
	//				Thread.Sleep(50);
	//			}
	//		}
	//		catch (Exception ex) { }
	//		return 0;
	//	}
	//	#endregion

	//	#region 判断回零是否完成
	//	public bool HomeFinished()
	//	{
	//		THomeStatus tHomeStatus = new THomeStatus();
	//		GTN_GetHomeStatus(Param.core, Param.NAxis, out tHomeStatus);
	//		commandHandler("GTN_GetHomeStatus", Z);
	//		return tHomeStatus.run == 0;
	//	}
	//	#endregion

	//	#region 正向Jog运动
	//	// //正向Jog运动  方向正负由速度正负号决定
	//	public int JogStart(DirMove dir)
	//	{
	//		TJogPrm tJogPrm = new TJogPrm();
	//		Z = GTN_PrfJog(Param.core, Param.NAxis); //设置轴为Jog运动模式
	//		commandHandler("GTN_PrfJog", Z);
	//		tJogPrm.acc = VelToCardVel(Param.JogAccelerate);
	//		;
	//		tJogPrm.dec = VelToCardVel(Param.Jogdeceleration);
	//		;
	//		tJogPrm.smooth = Param.JogSmoothtimeJ;
	//		Z = GTN_SetJogPrm(Param.core, Param.NAxis, ref tJogPrm); //设置轴为Jog运动模式
	//		commandHandler("GTN_SetJogPrm", Z);
	//		if (dir == DirMove.Positive)
	//		{
	//			Z = GTN_SetVel(Param.core, Param.NAxis, VelToCardVel(Param.JogVelocity)); //设置Jog正向运动的速度
	//			commandHandler("GTN_SetVel", Z);
	//		}
	//		else
	//		{
	//			Z = GTN_SetVel(Param.core, Param.NAxis, -VelToCardVel(Param.JogVelocity)); //设置Jog正向运动的速度
	//			commandHandler("GTN_SetVel", Z);
	//		}
	//		Z = GTN_Update(Param.core, 1 << Param.NAxis - 1); //更新轴运动
	//		commandHandler("GTN_Update", Z);

	//		return 0;
	//	}
	//	#endregion

	//	#region 停止运动
	//	public int StopMove()
	//	{
	//		stop.AxisStop(Param.core, Param.NAxis);
	//		commandHandler("GTN_Stop", Z);
	//		//停止运动
	//		return 0;
	//	}
	//	#endregion

	//	#region 清除指定轴的状态
	//	/// <summary>
	//	/// 清除指定轴的状态: 驱动器报警标志、跟随误差越限标志、限位触发标志
	//	/// </summary>
	//	/// <param name="TargetAxis">指定轴号【1~运动卡支持的最大轴数量】</param>
	//	/// <returns></returns>
	//	public bool ClearAxisStatus()
	//	{
	//		string ErrorMessage;
	//		try
	//		{
	//			int Return = 0;
	//			Return = GTN_ClrSts(Param.core, Param.NAxis, 1);
	//			if (Return != 0)
	//			{
	//				ErrorMessage = "清除轴状态指令执行失败，请检查运动卡或指令的参数";
	//				return false;
	//			}
	//			else
	//			{
	//				return true;
	//			}
	//		}
	//		catch (Exception ex)
	//		{
	//			ErrorMessage = ex.Message;
	//			return false;
	//		}
	//	}
	//	#endregion

	//	#region 绝对移动
	//	public int AbsoluteMove(double DistanceInMM)
	//	{
	//		try
	//		{
	//			//点位运动：完成点到点运动，在运动过程中可以随时修改目标位置和目标速度
	//			uint PClock = 0;
	//			double Pos = 0;

	//			if (GetAxisEnable() == false)
	//			{
	//				Z = GTN_AxisOn(Param.core, Param.NAxis); //使能ON
	//				commandHandler("GTN_AxisOn", Z);
	//			}

	//			TTrapPrm TrapParameter = new TTrapPrm();
	//			Z = GTN_GetTrapPrm(Param.core, Param.NAxis, out TrapParameter); //读取运动参数
	//			commandHandler("GTN_GetTrapPrm", Z);
	//			double Speed = Convert.ToDouble(VelToCardVel(Param.Velocity)); //增量运动的速度
	//			TrapParameter.acc = Convert.ToDouble(VelToCardVel(Param.Acc)); //加速度
	//			TrapParameter.dec = Convert.ToDouble(VelToCardVel(Param.Dec)); //减速度
	//			TrapParameter.smoothTime = 0; //平滑时间s
	//			TrapParameter.velStart = 3; //起跳速度

	//			Z = GTN_ClrSts(Param.core, Param.NAxis, 1); //清除轴状态--运动之前必须调用此函数清除轴状态
	//			commandHandler("GTN_ClrSts", Z);
	//			Z = GTN_PrfTrap(Param.core, Param.NAxis); //设置轴为点位模式，参数：轴号
	//			commandHandler("GTN_PrfTrap", Z);
	//			Z = GTN_SetTrapPrm(Param.core, Param.NAxis, ref TrapParameter); //设置运动参数
	//			commandHandler("GTN_SetTrapPrm", Z);
	//			Z = GTN_SetVel(Param.core, Param.NAxis, Speed); //设置运动速度
	//			commandHandler("GTN_SetVel", Z);
	//			Z = GTN_GetPrfPos(Param.core, Param.NAxis, out Pos, 1, out PClock);
	//			commandHandler("GTN_GetPrfPos", Z);

	//			//把“当前位置+相对运动值”作为目标值
	//			Z = GTN_SetPos(Param.core, Param.NAxis, (int)MMToPulses(DistanceInMM));
	//			commandHandler("GTN_SetPos", Z);
	//			Z = GTN_Update(Param.core, 1 << Param.NAxis - 1);
	//			commandHandler("GTN_Update", Z);
	//			return 0;
	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show(ex.Message);
	//			return -1;
	//		}
	//	}
	//	#endregion

	//	#region 设置原点
	//	public void SetAxisZeroPos()
	//	{
	//		int res;
	//		//轴状态
	//		Z1 = GTN_GetSts(Param.core, Param.NAxis, out status, 1, out pClock);
	//		if ((status & 0x400) == 0)
	//			res = 0;
	//		else
	//			res = 1; //为1代表处在运动状态
	//		if (res != 1)
	//		{
	//			Z = GTN_ZeroPos(Param.core, Param.NAxis, 1);
	//			commandHandler("GTN_ZeroPos", Z);
	//		}
	//	}

	//	#endregion

	//	public string Name { get; set; }
	//	public IMotionController ParentControl { get; set; }
	//	public AxisParm Param { get; set; }
	//	public WorkBaseObject Axis { get; set; }
	//	public string HomeLable { get; set; }
	//	public short Id { get; set; }
	//	private bool _disposed = false;
	//	private AxisState old_state = new AxisState();
	//	public event Action<string> StateChanged;
	//	private short Z;
	//	private Timer timer;
	//	AxisState state;
	//	Stop stop = new Stop();

	//	public GuGaoCardGSN(int axisId, AxisParm axisParam, IMotionController parentController)
	//	{
	//		Id = (short)axisId;
	//		Param = axisParam;
	//		Param.NAxis = (short)axisId;
	//		Param.core = 1;
	//		ParentControl = parentController;
	//		Axis = ParentControl.ConnectId;
	//		state = new AxisState();
	//		timer = new Timer(OnTimerState);
	//		timer.Change(0, 100);
	//	}

	//	~GuGaoCardGSN()
	//	{
	//		timer.Dispose();
	//		Dispose(false);
	//	}

	//	private void OnTimerState(object state1)
	//	{
	//		GetState(ref state);
	//		StateChanged?.Invoke("CmdPos");
	//	}

	//	private int ReadIntIndex(string variableName, int index)
	//	{
	//		return 0;
	//	}

	//	private int ReadIntBuffer(string variableName, int bufferId)
	//	{
	//		return 0;
	//	}

	//	private void WriteVariable(object value, string variableName) { }

	//	private void WriteVariableIndex(object value, string variableName, int index) { }

	//	private void WriteVariableBuffer(object value, string variableName, int bufferId) { }

	//	void commandHandler(string command, short error) //输出窗口提示
	//	{
	//		if (error != 0)
	//		{
	//			MessageBox.Show(command + "=" + error);
	//		}
	//	}

	//	private void Dispose(bool disposing)
	//	{
	//		if (!_disposed)
	//		{
	//			if (disposing) { }
	//			_disposed = true;
	//		}
	//	}

	//	public void Dispose()
	//	{
	//		Dispose(true);
	//		GC.SuppressFinalize(this);
	//	}

	//	public double GetDout()
	//	{
	//		return 0;
	//	}

	//	ManualResetEvent _mre = new ManualResetEvent(false);

	//	public bool WaitPosition(int timeout = 1000000)
	//	{
	//		if (!_mre.WaitOne(timeout))
	//		{
	//			_mre.Reset();
	//			return false;
	//		}
	//		_mre.Reset();
	//		return true;
	//	}
	//}

	//public class GuGaoMotionController : IMotionController
	//{
	//	private AxisCardObj _card;

	//	public enum GuGaoMotonCardType
	//	{
	//		GSN,
	//		GTS
	//	};

	//	string motonCardType;
	//	private short AxisesCount = 6;
	//	private short core = 1;
	//	short Z = 0;

	//	private short _deviceId = 0;
	//	public bool IsInitialSucceed = true;

	//	public string ControllerName
	//	{
	//		get { return "GuGaoMotionController"; }
	//	}

	//	public short DeviceId
	//	{
	//		get { return _deviceId; }
	//	}

	//	public List<IAxis> Axises { get; set; }

	//	public bool IsOpen
	//	{
	//		get { return IsInitialSucceed; }
	//		set { IsInitialSucceed = value; }
	//	}

	//	public event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged;
	//	public event DeviceErrorEvent ErrorEvent;

	//	public WorkBaseObject ConnectId { get; set; }

	//	public GuGaoMotionController() { }
	//	/// <summary>
	//	/// mm/秒->脉冲/毫秒的转化
	//	/// </summary>
	//	public double VelToCardVel(double mm)
	//	{
	//		var res = (mm / 1000) * 10000;
	//		return res;
	//	}

	//	/// <summary>
	//	/// 脉冲/毫秒->mm/秒的转化
	//	/// </summary>
	//	public double CardVelToVel(double vel)
	//	{
	//		var res = (vel / 10000) * 1000;
	//		return res;
	//	}
	//	public void TriggerError(DeviceErrorEventArgs deviceErrorEventArgs) { }

	//	public void SendCmd(string val, object value) { }

	//	public object ReceiveCmd(string msg)
	//	{
	//		return null;
	//	}
	//	public double MMToPulses(double mm)
	//	{
	//		var pules = 10000 * mm;
	//		return pules;
	//	}

	//	//启动插补
	//	Thread threadCrdStatus;
	//	void commandHandler(string command, short error) //输出窗口提示
	//	{
	//		if (error != 0 && IsInitialSucceed == true)
	//		{
	//			MessageBox.Show(command + "=" + error);
	//		}
	//	}

	//	#region  卡初始化

	//	/// <summary>
	//	/// 初始化运动控制卡
	//	/// </summary>
	//	public bool InitGSN(short core, short TotalAxises, string GTSConfigFile)
	//	{
	//		try
	//		{
	//			//判断扩展文件名是否正确
	//			if (GTSConfigFile.ToUpper().IndexOf(".CFG") == 1)
	//			{
	//				return false;
	//			}

	//			//判断文件是否存在
	//			if (
	//				System.IO.File.Exists(
	//					System.IO.Directory.GetCurrentDirectory() + "\\" + GTSConfigFile
	//				) == false
	//			)
	//			{
	//				return false;
	//			}
	//			int Return = 0;
	//			//初始化固高运动控制器，每个程序开始时必须调用的，且只调用1次

	//			//打开运动控制器,参数必须为（0,0），不能修改.
	//			Return = mc.GTN_Open(5, 2);
	//			if (Return != 0)
	//			{
	//				IsInitialSucceed = false;
	//				return false;
	//			}

	//			//复位运动控制器
	//			Return += mc.GTN_Reset(core);

	//			//清除各轴状态.参数：1.要清除状态轴的起始轴号.2.轴数量
	//			Return += mc.GTN_ClrSts(core, 1, TotalAxises);
	//			for (short i = 1; i <= TotalAxises; i++)
	//			{
	//				Z = mc.GTN_SetAxisBand(core, i, 20, 10); //设置轴的到位误差带
	//			}
	//			if (Return != 0)
	//			{
	//				MessageBox.Show("初始化固高运动控制器失败, 错误代码：" + Return, "错误");
	//				IsInitialSucceed = false;
	//				return false;
	//			}
	//			else
	//			{
	//				return true;
	//			}
	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show("创建类的实例时出现错误！\r\n" + ex.Message, "错误", MessageBoxButton.OK);
	//			return false;
	//		}
	//	}
	//	#endregion

	//	#region 开/关控制卡
	//	bool isdemo = false;
	//	public bool Open(bool isDemo)
	//	{
	//		if (ConnectId == null)
	//			return false;
	//		_card = ConnectId as AxisCardObj;
	//		if (string.IsNullOrEmpty(_card.ConnectIP))
	//			return false;

	//		Axises = new List<IAxis>();

	//		if (isDemo) //如果是Demo模式
	//		{
	//			isdemo = true;
	//			foreach (var cAxis in _card.ListAxisCardParms)
	//			{
	//				var po = cAxis.GetCardSettingPO();

	//				motonCardType = _card.CategoryKind;
	//				var axis = new GuGaoCardGSN(
	//					cAxis.AxisNum,
	//					new AxisParm()
	//					{
	//						Velocity = po.MovePara.Velocity,
	//						Acc = po.MovePara.Accelerate,
	//						Dec = po.MovePara.Decelerate,
	//						JogVelocity = po.JogPara.JogVelocity,
	//						JogAccelerate = po.JogPara.JogAccelerate,
	//						Jogdeceleration = po.JogPara.Jogdeceleration,
	//						JogSmoothtimeJ = po.JogPara.JogSmoothtimeJ,
	//						SoftPel = po.SoftPel,
	//						SoftMel = po.SoftMel,
	//						AbsolutePosition = po.MovePara.AbsolutePosition,
	//						RelativePosition = po.MovePara.RelativePosition,
	//						NAxis = po.AxisNum,
	//						AxisName = po.AxisName,
	//						core = po.core,
	//						PulseEquivalent = po.PulseEquivalent,
	//						SelectedHomeMode = po.SelectedHomeMode,
	//						SelectedHomePosition = po.SelectedHomePosition,
	//						SelectedIndexPosition = po.SelectedIndexPosition,
	//						HomeOffset = po.HomeOffset,
	//						SearchHomeDistance = po.SearchHomeDistance,
	//						SearchIndexDistance = po.SearchIndexDistance,
	//					},
	//					this
	//				)
	//				{
	//					Name = cAxis.CategoryName
	//				};
	//				axis.Axis = cAxis;
	//				axis.HomeLable = po.HomeLabel;
	//				Axises.Add(axis);
	//			}
	//			AxisesCount = (short)Axises.Count;
	//			IsInitialSucceed = false;
	//			return false;
	//		}
	//		else
	//		{
	//			isdemo = false;
	//			InitGSN(core, AxisesCount, "gtn_core1.cfg");
	//		}

	//		foreach (var cAxis in _card.ListAxisCardParms)
	//		{
	//			var po = cAxis.GetCardSettingPO();

	//			motonCardType = _card.CategoryKind;
	//			var axis = new GuGaoCardGSN(
	//				cAxis.AxisNum,
	//				new AxisParm()
	//				{
	//					Velocity = po.MovePara.Velocity,
	//					Acc = po.MovePara.Accelerate,
	//					Dec = po.MovePara.Decelerate,
	//					JogVelocity = po.JogPara.JogVelocity,
	//					JogAccelerate = po.JogPara.JogAccelerate,
	//					Jogdeceleration = po.JogPara.Jogdeceleration,
	//					JogSmoothtimeJ = po.JogPara.JogSmoothtimeJ,
	//					SoftPel = po.SoftPel,
	//					SoftMel = po.SoftMel,
	//					AbsolutePosition = po.MovePara.AbsolutePosition,
	//					RelativePosition = po.MovePara.RelativePosition,
	//					NAxis = po.AxisNum,
	//					AxisName = po.AxisName,
	//					PulseEquivalent = po.PulseEquivalent,
	//					core = po.core,
	//					SelectedHomeMode = po.SelectedHomeMode,
	//					SelectedHomePosition = po.SelectedHomePosition,
	//					SelectedIndexPosition = po.SelectedIndexPosition,
	//					HomeOffset = po.HomeOffset,
	//					SearchHomeDistance = po.SearchHomeDistance,
	//					SearchIndexDistance = po.SearchIndexDistance,
	//				},
	//				this
	//			)
	//			{
	//				Name = cAxis.CategoryName
	//			};
	//			axis.Axis = cAxis;
	//			axis.HomeLable = po.HomeLabel;
	//			Axises.Add(axis);
	//		}
	//		return true;
	//	}

	//	public bool Close()
	//	{
	//		try
	//		{
	//			Z = mc.GTN_Stop(core, 255, 0);
	//			commandHandler("GTN_Stop", Z);
	//			Z = mc.GTN_MultiAxisOff(core, 255);
	//			commandHandler("GTN_MultiAxisOff", Z);
	//			Thread.Sleep(100);
	//			Z = mc.GTN_Close();
	//			commandHandler("GTN_Close", Z);

	//			//如果指令执行返回值为非0，说明指令执行错误
	//			if (Z == 0)
	//			{
	//				IsInitialSucceed = true;
	//				return true;
	//			}
	//			else
	//			{
	//				IsInitialSucceed = false;
	//				return false;
	//			}
	//		}
	//		catch (Exception ex)
	//		{
	//			return false;
	//		}
	//	}
	//	#endregion

	//	#region IO相关
	//	short doType = mc.MC_GPO;
	//	short diType = mc.MC_GPI;//本地输入输出类型
	//							 //读取数字量输入
	//	int[] doValueEx = new int[2]; //本地多组输出
	//	int[] diValueEx = new int[3]; //本地多组输入

	//	//打开数字量输出
	//	public void OpenOutputIO(short index)
	//	{
	//		Z = mc.GTN_SetDoBit(core, doType, index, 0); //默认情况下，value:1表示高电平，0表示低电平
	//		commandHandler("GTN_SetDoBit", Z);
	//	}

	//	//关闭数字量输出
	//	public void CloseOutputIO(short index)
	//	{
	//		Z = mc.GTN_SetDoBit(core, doType, index, 1); //默认情况下，value:1表示高电平，0表示低电平
	//		commandHandler("GTN_SetDoBit", Z);
	//	}

	//	short diReverse, doReverse;//本地输入输出是否取反
	//							   //读取数字量输出
	//	public short ReadOutputIO(short doIndex)
	//	{
	//		if (!IsInitialSucceed)
	//		{
	//			return 1;
	//		}
	//		short res = 1;
	//		Z = mc.GTN_GetSense(1, doType, doIndex, out doReverse);
	//		commandHandler("GTN_GetSense1", Z);

	//		Z = mc.GTN_GetDoEx(1, doType, out doValueEx[0], 3); //单核本地64路输出，32位为1个doValueEx
	//		commandHandler("GTN_GetDoEx1", Z);              //commandHandler("GTN_GetDoEx1", Z);
	//		if (doIndex > 0 & doIndex < 33)
	//		{
	//			if (((1 << (doIndex - 1) & doValueEx[0]) == 0 & doReverse == 0) || ((1 << (doIndex - 1) & doValueEx[0]) != 0 & doReverse == 1))
	//			{
	//				res = 0;
	//			}
	//			else
	//			{
	//				res = 1;
	//			}
	//		}

	//		if (doIndex > 32 & doIndex < 65)
	//		{
	//			if (((1 << (doIndex - 1) & doValueEx[1]) == 0 & doReverse == 0) || ((1 << (doReverse - 1) & doValueEx[1]) != 0 & doReverse == 1))
	//			{
	//				res = 0;
	//			}
	//			else
	//			{
	//				res = 1;
	//			}
	//		}

	//		if (doIndex > 64)
	//		{
	//			if (((1 << (doIndex - 1) & doValueEx[2]) == 0 & doReverse == 0) || ((1 << (doReverse - 1) & doValueEx[2]) != 0 & doReverse == 1))
	//			{
	//				res = 0;
	//			}
	//			else
	//			{
	//				res = 1;
	//			}
	//		}
	//		return res;
	//	}


	//	public short ReadInputIO(short diIndex)
	//	{
	//		if (!IsInitialSucceed)
	//		{
	//			return 1;
	//		}
	//		Z = mc.GTN_GetSense(1, diType, diIndex, out diReverse);//读取输入输出电平逻辑
	//		commandHandler("GTN_GetSense1", Z);
	//		short res = 1;
	//		Z = mc.GTN_GetDiEx(1, diType, out diValueEx[0], 3); //单核最大本地输入100个，32位为1个diValueEx
	//															//commandHandler("GTN_GetDiEx2", Z);
	//		if (diIndex > 0 & diIndex < 33)
	//		{
	//			if (((1 << (diIndex - 1) & diValueEx[0]) == 0 & diReverse == 0) || ((1 << (diIndex - 1) & diValueEx[0]) != 0 & diReverse == 1))
	//			{
	//				res = 0;
	//			}
	//			else
	//			{
	//				res = 1;
	//			}
	//		}

	//		if (diIndex > 32 & diIndex < 65)
	//		{
	//			if (((1 << (diIndex - 1) & diValueEx[1]) == 0 & diReverse == 0) || ((1 << (diIndex - 1) & diValueEx[1]) != 0 & diReverse == 1))
	//			{
	//				res = 0;
	//			}
	//			else
	//			{
	//				res = 1;
	//			}
	//		}

	//		if (diIndex > 64)
	//		{
	//			if (((1 << (diIndex - 1) & diValueEx[2]) == 0 & diReverse == 0) || ((1 << (diIndex - 1) & diValueEx[2]) != 0 & diReverse == 1))
	//			{
	//				res = 0;
	//			}
	//			else
	//			{
	//				res = 1;
	//			}
	//		}
	//		return res;
	//	}
	//	#endregion

	//	#region 插补运动

	//	/// <summary>
	//	///  直线插补运动
	//	/// </summary>
	//	/// <param name="dimension">轴的个数</param>
	//	/// <param name="axises">轴集合</param>
	//	/// <param name="pos">x、y点位</param>
	//	/// <param name="ratio"></param>
	//	/// <returns></returns>
	//	public int LineMove(int dimension, List<IAxis> axises, List<double> targetPos, double crdVel, double crdAcc, bool isOpenCo2Laser, MotonLaserParam motonLaserParam)
	//	{
	//		if (!IsInitialSucceed)
	//		{
	//			return 0;
	//		}

	//		short core = 1;
	//		short crd = 1; //坐标系
	//		short fifo = 0; //缓存区

	//		Z = mc.GTN_Stop(core, 7, 0); //平滑停止轴
	//		commandHandler("GTN_Stop", Z);


	//		//前瞻初始化
	//		mc.TCrdData temp = new mc.TCrdData();
	//		mc.TCrdData[] crdData = new mc.TCrdData[200];
	//		int size = Marshal.SizeOf(temp) * 200;
	//		IntPtr pCrdData = Marshal.AllocHGlobal(size);

	//		short[] crdAxis = new short[8];
	//		crdAxis[axises[0].Id - 1] = 1;
	//		crdAxis[axises[1].Id - 1] = 2; //123表示对应坐标系的XYZ

	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_LaserPowerMode(core, 0, 100, 0, motonLaserParam.LaserChannel); // 设置激光能量控制方式为占空比模式，最大比为 100%，最小占空比为 0 %
	//			commandHandler("GTN_LaserPowerMode", Z);
	//			Z = mc.GTN_LaserOutFrq(core, motonLaserParam.OutFrq, motonLaserParam.LaserChannel); // 设置 PWM 输出的频率为：10KHz
	//			commandHandler("GTN_LaserOutFrq", Z);
	//		}

	//		mc.TCrdPrm crdPrm;
	//		Z = mc.GTN_GetCrdPrm(core, 1, out crdPrm);
	//		//mc.TCrdPrm crdPrm = new mc.TCrdPrm();//坐标系参数结构体
	//		crdPrm.dimension = 2; //坐标系维数
	//		crdPrm.profile1 = crdAxis[0]; //profile1-8表示轴号，123表示对应坐标系的XYZ
	//		crdPrm.profile2 = crdAxis[1];
	//		crdPrm.profile3 = crdAxis[2];
	//		crdPrm.profile4 = crdAxis[3];
	//		crdPrm.profile5 = crdAxis[4];
	//		crdPrm.profile6 = crdAxis[5];
	//		crdPrm.profile7 = crdAxis[6];
	//		crdPrm.profile8 = crdAxis[7];
	//		crdPrm.setOriginFlag = 1; //1：需要设置加工坐标系原点位置，0：不需要指定原点坐标值，则坐标系的原点在当前规划位置上。
	//		crdPrm.originPos1 = 0; //加工坐标系原点位置在(0, 0, 0)，即与机床坐标系原点重合
	//		crdPrm.originPos2 = 0;
	//		crdPrm.originPos3 = 0;
	//		crdPrm.originPos4 = 0;
	//		crdPrm.originPos5 = 0;
	//		crdPrm.originPos6 = 0;
	//		crdPrm.originPos7 = 0;
	//		crdPrm.originPos8 = 0;
	//		crdPrm.evenTime = 50; //插补段最小匀速时间：0-32767
	//		crdPrm.synVelMax = VelToCardVel(crdVel); //插补运动最大速度
	//		crdPrm.synAccMax = VelToCardVel(crdAcc); //插补运动最大加速度
	//		Z = mc.GTN_SetCrdPrm(core, crd, ref crdPrm); //建立坐标系
	//		commandHandler("GTN_SetCrdPrm", Z);

	//		// 即将把数据存入坐标系1的FIFO0中，所以要首先清除此缓存区中的数据
	//		Z = mc.GTN_CrdClear(core, 1, 0);
	//		commandHandler("GTN_CrdClear", Z);


	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_BufLaserFollowMode(core, crd, 0, 0, motonLaserParam.LaserChannel, 10); // 设置跟随编码器
	//			commandHandler("GTN_BufLaserFollowMode", Z);
	//			Z = mc.GTN_BufLaserFollowRatio(core, crd, motonLaserParam.FollowRatio, motonLaserParam.MinPower, motonLaserParam.MaxPower, 0, motonLaserParam.LaserChannel); // 设置跟随的比率为 0.1，最小能量为 10%，最大能量为 100 %
	//			commandHandler("GTN_BufLaserFollowRatio", Z);
	//			Z = mc.GTN_BufLaserOn(core, crd, 0, motonLaserParam.LaserChannel); // 打开激光通道 1 输出
	//			commandHandler("GTN_BufLaserOn", Z);
	//		}

	//		Z = mc.GTN_InitLookAhead(
	//			core,
	//			crd,
	//			0,
	//			5,
	//			VelToCardVel(crdAcc),
	//			200,
	//			ref crdData[0]
	//		);
	//		commandHandler("GTN_InitLookAhead", Z);

	//		Thread.Sleep(500);

	//		// 向缓存区写入第一段插补数据
	//		Z = mc.GTN_LnXY(
	//			core,
	//			1, // 该插补段的坐标系是坐标系1
	//			(int)MMToPulses(targetPos[0]),
	//			(int)MMToPulses(targetPos[1]), // 该插补段的终点坐标(,)
	//			VelToCardVel(crdVel), // 该插补段的目标速度:pulse/ms
	//			VelToCardVel(crdAcc),
	//			0, // 插补段的加速度：0.1pulse/ms^2
	//			0
	//		);
	//		commandHandler("GTN_LnXY", Z);

	//		do
	//		{
	//			Z = mc.GTN_CrdData(core, crd, System.IntPtr.Zero, 0); //需要不断调用直到返回值为0才算调用成功
	//		} while (Z != 0);

	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_BufLaserOff(core, crd, 0, motonLaserParam.LaserChannel); // 关闭激光通道 1 输出
	//			commandHandler("GTN_CrdStart", Z);
	//		}
	//		// 启动坐标系1的FIFO0的插补运动
	//		Z = mc.GTN_CrdStart(core, 1, 0);
	//		commandHandler("GTN_CrdStart", Z);
	//		return 0;
	//	}

	//	//圆弧插补移动-画整圆
	//	public int CircleMove(int dimension, List<IAxis> axises, List<double> targetPos, List<double> center, double crdVel, double crdAcc, bool isCW, bool isOpenCo2Laser, MotonLaserParam motonLaserParam)
	//	{
	//		if (!IsInitialSucceed)
	//		{
	//			return 0;
	//		}
	//		short cw = 0;
	//		if (!isCW)
	//		{
	//			cw = 1;
	//		}


	//		short core = 1;
	//		short crd = 1;
	//		Z = mc.GTN_Stop(core, 7, 0); //平滑停止前三个轴
	//		commandHandler("GTN_Stop", Z);

	//		//前瞻初始化
	//		mc.TCrdData temp = new mc.TCrdData();
	//		mc.TCrdData[] crdData = new mc.TCrdData[200];
	//		int size = Marshal.SizeOf(temp) * 200;
	//		IntPtr pCrdData = Marshal.AllocHGlobal(size);

	//		short[] crdAxis = new short[8];
	//		crdAxis[axises[0].Id - 1] = 1;
	//		crdAxis[axises[1].Id - 1] = 2; //123表示对应坐标系的XYZ

	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_LaserPowerMode(core, 0, 100, 0, motonLaserParam.LaserChannel); // 设置激光能量控制方式为占空比模式，最大比为 100%，最小占空比为 0 %
	//			commandHandler("GTN_LaserPowerMode", Z);
	//			Z = mc.GTN_LaserOutFrq(core, motonLaserParam.OutFrq, motonLaserParam.LaserChannel); // 设置 PWM 输出的频率为：10KHz
	//			commandHandler("GTN_LaserOutFrq", Z);
	//		}

	//		mc.TCrdPrm crdPrm;
	//		Z = mc.GTN_GetCrdPrm(core, 1, out crdPrm);
	//		crdPrm.dimension = 2; //坐标系维数
	//		crdPrm.profile1 = crdAxis[0]; //profile1-8表示轴号，123表示对应坐标系的XYZ
	//		crdPrm.profile2 = crdAxis[1];
	//		crdPrm.profile3 = crdAxis[2];
	//		crdPrm.profile4 = crdAxis[3];
	//		crdPrm.profile5 = crdAxis[4];
	//		crdPrm.profile6 = crdAxis[5];
	//		crdPrm.profile7 = crdAxis[6];
	//		crdPrm.profile8 = crdAxis[7];
	//		crdPrm.setOriginFlag = 1; //1：需要设置加工坐标系原点位置，0：不需要指定原点坐标值，则坐标系的原点在当前规划位置上。
	//		crdPrm.originPos1 = 0; //加工坐标系原点位置在(0, 0, 0)，即与机床坐标系原点重合
	//		crdPrm.originPos2 = 0;
	//		crdPrm.originPos3 = 0;
	//		crdPrm.originPos4 = 0;
	//		crdPrm.originPos5 = 0;
	//		crdPrm.originPos6 = 0;
	//		crdPrm.originPos7 = 0;
	//		crdPrm.originPos8 = 0;
	//		crdPrm.evenTime = 50; //插补段最小匀速时间：0-32767
	//		crdPrm.synVelMax = VelToCardVel(crdVel); //插补运动最大速度
	//		crdPrm.synAccMax = VelToCardVel(crdAcc); //插补运动最大加速度
	//		Z = mc.GTN_SetCrdPrm(core, crd, ref crdPrm); //建立坐标系
	//		commandHandler("GTN_SetCrdPrm", Z);

	//		// 即将把数据存入坐标系1的FIFO0中，所以要首先清除此缓存区中的数据
	//		Z = mc.GTN_CrdClear(core, 1, 0);
	//		commandHandler("GTN_CrdClear", Z);

	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_BufLaserFollowMode(core, crd, 0, 0, motonLaserParam.LaserChannel, 10); // 设置跟随编码器
	//			commandHandler("GTN_BufLaserFollowMode", Z);
	//			Z = mc.GTN_BufLaserFollowRatio(core, crd, motonLaserParam.FollowRatio, motonLaserParam.MinPower, motonLaserParam.MaxPower, 0, motonLaserParam.LaserChannel); // 设置跟随的比率为 0.1，最小能量为 10%，最大能量为 100 %
	//			commandHandler("GTN_BufLaserFollowRatio", Z);
	//			Z = mc.GTN_BufLaserOn(core, crd, 0, motonLaserParam.LaserChannel); // 打开激光通道 1 输出
	//			commandHandler("GTN_BufLaserOn", Z);
	//		}

	//		Z = mc.GTN_InitLookAhead(core, crd, 0, 5, VelToCardVel(crdAcc), 200, ref crdData[0]);
	//		commandHandler("GTN_InitLookAhead", Z);

	//		Thread.Sleep(500);

	//		// 向缓存区写入第一段插补数据
	//		Z = mc.GTN_LnXY(core,
	//			1, // 该插补段的坐标系是坐标系1
	//			(int)MMToPulses(targetPos[0]),
	//			(int)MMToPulses(targetPos[1]), // 该插补段的终点坐标(200000, 0)
	//			VelToCardVel(crdVel), // 该插补段的目标速度：100pulse/ms
	//			VelToCardVel(crdAcc),
	//			0, // 终点速度为0
	//			0
	//		); // 向坐标系1的FIFO0缓存区传递该直线插补数据
	//		commandHandler("GTN_LnXY", Z);

	//		//向缓存区写入第一段插补数据，该段数据是以圆心描述方法描述了一个XY平面的整圆
	//		Z = mc.GTN_ArcXYC(
	//			core,
	//			1, // 坐标系是坐标系1
	//			(int)MMToPulses(targetPos[0]),
	//			(int)MMToPulses(targetPos[1]), // 该圆弧的终点坐标(,)
	//			MMToPulses(center[0]),
	//			MMToPulses(center[1]), // 圆弧插补的圆心相对于起点位置的偏移量(,)
	//			cw, // 该圆弧是顺时针圆弧
	//			VelToCardVel(crdVel), // 该插补段的目标速度：100pulse/ms
	//			VelToCardVel(crdAcc), // 该插补段的加速度：0.1pulse/ms^2
	//			0, // 终点速度为0
	//			0
	//		);
	//		commandHandler("GTN_ArcXYC", Z);
	//		do
	//		{
	//			Z = mc.GTN_CrdData(core, crd, System.IntPtr.Zero, 0); //需要不断调用直到返回值为0才算调用成功
	//		} while (Z != 0);
	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_BufLaserOff(core, crd, 0, motonLaserParam.LaserChannel); // 关闭激光通道 1 输出
	//			commandHandler("GTN_CrdStart", Z);
	//		}

	//		Z = mc.GTN_CrdStart(core, 1, 0); // 启动坐标系1的FIFO0的插补运动
	//		commandHandler("GTN_CrdStart", Z);
	//		return 0;
	//	}

	//	//圆弧插补移动-画圆弧
	//	public int ArcMove(int dimension, List<IAxis> axises, List<double> targetPos, double r, bool isCW, double crdVel, double crdAcc, bool isOpenCo2Laser, MotonLaserParam motonLaserParam)
	//	{
	//		if (!IsInitialSucceed)
	//		{
	//			return 0;
	//		}
	//		short cw = 0;
	//		if (!isCW)
	//		{
	//			cw = 1;
	//		}

	//		short core = 1;
	//		short crd = 1;
	//		Z = mc.GTN_Stop(core, 7, 0); //平滑停止前三个轴
	//		commandHandler("GTN_Stop", Z);

	//		//前瞻初始化
	//		mc.TCrdData temp = new mc.TCrdData();
	//		mc.TCrdData[] crdData = new mc.TCrdData[200];
	//		int size = Marshal.SizeOf(temp) * 200;
	//		IntPtr pCrdData = Marshal.AllocHGlobal(size);

	//		short[] crdAxis = new short[8];
	//		crdAxis[axises[0].Id - 1] = 1;
	//		crdAxis[axises[1].Id - 1] = 2; //123表示对应坐标系的XYZ

	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_LaserPowerMode(core, 0, 100, 0, motonLaserParam.LaserChannel); // 设置激光能量控制方式为占空比模式，最大比为 100%，最小占空比为 0 %
	//			commandHandler("GTN_LaserPowerMode", Z);
	//			Z = mc.GTN_LaserOutFrq(core, motonLaserParam.OutFrq, motonLaserParam.LaserChannel); // 设置 PWM 输出的频率为：10KHz
	//			commandHandler("GTN_LaserOutFrq", Z);
	//		}

	//		mc.TCrdPrm crdPrm;
	//		Z = mc.GTN_GetCrdPrm(core, 1, out crdPrm);
	//		crdPrm.dimension = 2; //坐标系维数
	//		crdPrm.profile1 = crdAxis[0]; //profile1-8表示轴号，123表示对应坐标系的XYZ
	//		crdPrm.profile2 = crdAxis[1];
	//		crdPrm.profile3 = crdAxis[2];
	//		crdPrm.profile4 = crdAxis[3];
	//		crdPrm.profile5 = crdAxis[4];
	//		crdPrm.profile6 = crdAxis[5];
	//		crdPrm.profile7 = crdAxis[6];
	//		crdPrm.profile8 = crdAxis[7];
	//		crdPrm.setOriginFlag = 1; //1：需要设置加工坐标系原点位置，0：不需要指定原点坐标值，则坐标系的原点在当前规划位置上。
	//		crdPrm.originPos1 = 0; //加工坐标系原点位置在(0, 0, 0)，即与机床坐标系原点重合
	//		crdPrm.originPos2 = 0;
	//		crdPrm.originPos3 = 0;
	//		crdPrm.originPos4 = 0;
	//		crdPrm.originPos5 = 0;
	//		crdPrm.originPos6 = 0;
	//		crdPrm.originPos7 = 0;
	//		crdPrm.originPos8 = 0;
	//		crdPrm.evenTime = 50; //插补段最小匀速时间：0-32767
	//		crdPrm.synVelMax = VelToCardVel(crdVel); //插补运动最大速度
	//		crdPrm.synAccMax = VelToCardVel(crdAcc); //插补运动最大加速度
	//		Z = mc.GTN_SetCrdPrm(core, crd, ref crdPrm); //建立坐标系
	//		commandHandler("GTN_SetCrdPrm", Z);

	//		// 即将把数据存入坐标系1的FIFO0中，所以要首先清除此缓存区中的数据
	//		Z = mc.GTN_CrdClear(core, 1, 0);
	//		commandHandler("GTN_CrdClear", Z);

	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_BufLaserFollowMode(core, crd, 0, 0, motonLaserParam.LaserChannel, 10); // 设置跟随编码器
	//			commandHandler("GTN_BufLaserFollowMode", Z);
	//			Z = mc.GTN_BufLaserFollowRatio(core, crd, motonLaserParam.FollowRatio, motonLaserParam.MinPower, motonLaserParam.MaxPower, 0, motonLaserParam.LaserChannel); // 设置跟随的比率为 0.1，最小能量为 10%，最大能量为 100 %
	//			commandHandler("GTN_BufLaserFollowRatio", Z);
	//			Z = mc.GTN_BufLaserOn(core, crd, 0, motonLaserParam.LaserChannel); // 打开激光通道 1 输出
	//			commandHandler("GTN_BufLaserOn", Z);
	//		}

	//		Z = mc.GTN_InitLookAhead(core, crd, 0, 5, VelToCardVel(crdAcc), 200, ref crdData[0]);
	//		commandHandler("GTN_InitLookAhead", Z);

	//		Thread.Sleep(500);

	//		// 向缓存区写入第一段插补数据
	//		Z = mc.GTN_LnXY(core,
	//			1, // 该插补段的坐标系是坐标系1
	//			(int)MMToPulses(targetPos[0]),
	//			(int)MMToPulses(targetPos[1]), // 该插补段的终点坐标(200000, 0)
	//			VelToCardVel(crdVel), // 该插补段的目标速度：100pulse/ms
	//			VelToCardVel(crdAcc),
	//			0, // 终点速度为0
	//			0
	//		); // 向坐标系1的FIFO0缓存区传递该直线插补数据
	//		commandHandler("GTN_LnXY", Z);

	//		//向缓存区写入第一段插补数据，该段数据是以圆心描述方法描述了一个XY平面的整圆
	//		Z = mc.GTN_ArcXYR(
	//			core,
	//			1, // 坐标系是坐标系1
	//			(int)MMToPulses(targetPos[0]),
	//			(int)MMToPulses(targetPos[1]), // 该圆弧的终点坐标(,)
	//			r,
	//			cw, //该圆弧是顺时针圆弧还是逆时针圆弧
	//			VelToCardVel(crdVel), // 该插补段的目标速度：100pulse/ms
	//			VelToCardVel(crdAcc), // 该插补段的加速度：0.1pulse/ms^2
	//			0, // 终点速度为0
	//			0
	//		);
	//		commandHandler("GTN_ArcXYR", Z);
	//		do
	//		{
	//			Z = mc.GTN_CrdData(core, crd, System.IntPtr.Zero, 0); //需要不断调用直到返回值为0才算调用成功
	//		} while (Z != 0);
	//		if (isOpenCo2Laser)
	//		{
	//			Z = mc.GTN_BufLaserOff(core, crd, 0, motonLaserParam.LaserChannel); // 关闭激光通道 1 输出
	//			commandHandler("GTN_CrdStart", Z);
	//		}

	//		Z = mc.GTN_CrdStart(core, 1, 0); // 启动坐标系1的FIFO0的插补运动
	//		commandHandler("GTN_CrdStart", Z);
	//		return 0;
	//	}
	//	#endregion

	//	#region 激光相关
	//	public bool LaserInit(short LaserChannel, double Duty, double outFrq, double MaxPower, double MinPower)
	//	{
	//		short core = 1;
	//		Z = mc.GTN_LaserPowerMode(core, 0, MaxPower, MinPower, LaserChannel); //设置激光模式
	//		commandHandler("GTN_LaserPowerMode", Z);
	//		Z = mc.GTN_LaserOutFrq(core, outFrq, LaserChannel); //设置载波频率
	//		commandHandler("GTN_LaserOutFrq", Z);
	//		Z = mc.GTN_LaserPrfCmd(core, Duty, LaserChannel); //设置占空比
	//		commandHandler("GTN_LaserPrfCmd", Z);
	//		return true;
	//	}

	//	public bool LaserOn(bool isOpen, short LaserChannel)
	//	{
	//		if (isOpen)
	//		{
	//			Z = mc.GTN_LaserOn(core, LaserChannel);
	//			commandHandler("GTN_LaserOn", Z);
	//		}
	//		else
	//		{
	//			Thread.Sleep(100);
	//			int i = 0;
	//			while (i <= 3)
	//			{
	//				Thread.Sleep(50);
	//				Z = mc.GTN_LaserOff(core, LaserChannel);
	//				i++;
	//			}
	//			commandHandler("GTN_LaserOff", Z);
	//		}
	//		return true;
	//	}
	//	#endregion

	//	#region PSO相关

	//	/// <summary>
	//	/// um转脉冲
	//	/// </summary>
	//	/// <returns></returns>
	//	public ushort UmToPulse(ushort um)
	//	{
	//		///脉冲当量默认为1mm=10000脉冲
	//		ushort res = (ushort)((um / 1000) * 10000);
	//		return res;
	//	}

	//	public void OpenPso(bool isOpen, PSOPara pSOPara)
	//	{
	//		short MC_HSO = 18;
	//		if (isOpen)
	//		{
	//			//设置控制权
	//			short permit = 2; //第一路位置比较功能
	//			short HSIOIndex = pSOPara.HardWareIndex;
	//			Z = mc_ringnet.GTN_SetTerminalPermitEx(
	//				core,
	//				1, //模块号
	//				MC_HSO, //输出类型
	//				ref permit, //设置软件控制权限
	//				HSIOIndex, //起始硬件通道号
	//				1
	//			); //硬件数量
	//			commandHandler("GTN_SetTerminalPermitEx", Z);

	//			mc.TPosCompareMode tposCompareMode = new mc.TPosCompareMode
	//			{
	//				mode = 3,
	//				dimension = 2,
	//				sourceMode = pSOPara.CompareSource,
	//				sourceX = pSOPara.SourceX,
	//				sourceY = pSOPara.SourceY,
	//				outputMode = 0,
	//				outputPulseWidth = UmToPulse(pSOPara.PulseWidth), //输出脉冲宽度，单位：.1ms,电平模式下该参数无效,
	//				outputCounter = 1,
	//				errorBand = UmToPulse(pSOPara.TwoDemnDiffer),
	//			};
	//			short posCompareIndex = pSOPara.HardWareIndex;
	//			Z = mc.GTN_SetPosCompareMode(
	//				this.core,
	//				posCompareIndex,
	//				ref tposCompareMode
	//			);
	//			commandHandler("GTN_SetPosCompareMode", Z);
	//			mc.TPosComparePsoPrm tposComparePsoPrm =
	//				default(mc.TPosComparePsoPrm);
	//			Z = mc.GTN_PosCompareClear(this.core, posCompareIndex);
	//			commandHandler("GTN_PosCompareClear", Z);
	//			tposComparePsoPrm.count = 1;
	//			tposComparePsoPrm.syncPos = pSOPara.PsoInterval;
	//			Z = mc.GTN_SetPosComparePsoPrm(
	//				this.core,
	//				posCompareIndex,
	//				ref tposComparePsoPrm
	//			);
	//			commandHandler("GTN_SetPosComparePsoPrm", Z);
	//			Z = mc.GTN_PosCompareStart(this.core, posCompareIndex);
	//			commandHandler("GTN_PosCompareStart", Z);
	//		}
	//		else
	//		{
	//			short posCompareIndex = pSOPara.HardWareIndex;
	//			Z = mc.GTN_PosCompareStop(core, posCompareIndex);
	//			commandHandler("GTN_PosCompareStop", Z);
	//		}
	//	}
	//	#endregion
	//}
	//#endregion
}
