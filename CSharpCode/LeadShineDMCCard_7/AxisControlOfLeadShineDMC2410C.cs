
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LeadShineDMCCard_7
{
	//��DMC2410C�������о����λ�õĵ�λΪ���壻�ٶȵ�λΪ����/�룻ʱ�䵥λΪ�롣
	//�����˶���DMC2410���ο���, ��ʵ���������ֱ�ӿ������˶���IO�ź�
	/// <summary>
	/// �����˶���DMC2410���ο���,��ʵ���������ֱ�ӿ������˶���IO�ź�
	/// </summary>
	class AxisControlOfLeadShineDMC2410C
	{

		//�������������ϸ񱣳�һ����
		#region "�����˶���DMC2410C#�⺯�������б�"

		//Ϊ���ƿ�����ϵͳ��Դ������ʼ�����ƿ�
		/// <summary>
		/// Ϊ���ƿ�����ϵͳ��Դ������ʼ�����ƿ������ó�ʼ�����ٶȵ�����
		/// </summary>
		/// <returns>0�� û���ҵ����ƿ������߿��ƿ��쳣;
		/// 1��8�� ���ƿ���;
		/// ��ֵ�� ������2�Ż�2�����Ͽ��ƿ���Ӳ�����ÿ�����ͬ������ֵȡ����ֵ���1��Ϊ�ÿ���
		/// 1001 + j: j�ſ���ʼ������ ��1001��ʼ��
		/// </returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_board_init",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt16 d2410_board_init();

		//�ر����п����ͷ�ϵͳ��Դ
		/// <summary>
		/// �ر����п����ͷ�ϵͳ��Դ
		/// </summary>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_board_close",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_board_close();

		//��λ���п���ֻ���ڳ�ʼ�����֮����ã�
		/// <summary>
		/// ��λ���п���ֻ���ڳ�ʼ�����֮����ã�
		/// </summary>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_board_rest",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_board_rest();

		//���������������
		//����ָ������������ģʽ
		/// <summary>
		/// ����ָ������������ģʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="outmode">���������ʽѡ��[0~5]
		/// ע�⣺�ڵ����˶��������磺d2410_t_vmove�ȣ��������֮ǰ��һ��Ҫ������������
		/// �������ģʽ����d2410_set_pulse_outmode���ÿ��ƿ��������ģʽ��</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_pulse_outmode",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_pulse_outmode(UInt16 axis,
			UInt16 outmode);

		//ר���ź����ú��� 

		//����ALM����Ч��ƽ���乤����ʽ
		/// <summary>
		/// ����ALM����Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="alm_logic">ALM�źŵ�������Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="alm_action">ALM�źŵ��ƶ���ʽ��0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_ALM_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_ALM_PIN(UInt16 axis,
			UInt16 alm_logic, UInt16 alm_action);

		//��ȡALM����Ч��ƽ���乤����ʽ
		/// <summary>
		/// ��ȡALM����Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="alm_logic">ALM�źŵ�������Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="alm_action">ALM�źŵ��ƶ���ʽ��0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_config_ALM_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_config_ALM_PIN(UInt16 axis,
			ref UInt16 alm_logic, ref UInt16 alm_action);

		//d2410_config_ALM_PIN��չ����������ALMʹ��״̬�����Ʒ�ʽ���趨
		/// <summary>
		/// d2410_config_ALM_PIN��չ����������ALMʹ��״̬�����Ʒ�ʽ���趨
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="alm_enable">ALMʹ��״̬��0����ֹ��1������</param>
		/// <param name="alm_logic">ALM�źŵ�������Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="alm_all">ALM�źſ��Ʒ�ʽ��0��ֹͣ���ᣬ1��ֹͣ������</param>
		/// <param name="alm_action">ALM�źŵ��ƶ���ʽ��0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_config_ALM_PIN_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_config_ALM_PIN_Extern(UInt16 axis,
			ref UInt16 alm_enable, ref UInt16 alm_logic, ref UInt16 alm_all,
			ref UInt16 alm_action);

		//d2410_config_ALM_PIN��չ����������ALMʹ��״̬�����Ʒ�ʽ���趨
		/// <summary>
		/// d2410_config_ALM_PIN��չ����������ALMʹ��״̬�����Ʒ�ʽ���趨
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="alm_enbale">ALMʹ��״̬��0����ֹ��1������</param>
		/// <param name="alm_logic">ALM�źŵ�������Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="alm_all">ALM�źſ��Ʒ�ʽ��0��ֹͣ���ᣬ1��ֹͣ������</param>
		/// <param name="alm_action">ALM�źŵ��ƶ���ʽ��0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_ALM_PIN_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_ALM_PIN_Extern(UInt16 axis,
			UInt16 alm_enbale, UInt16 alm_logic, UInt16 alm_all, UInt16 alm_action);

		//����EL�źŵ���Ч��ƽ���ƶ���ʽ
		/// <summary>
		/// ����EL�źŵ���Ч��ƽ���ƶ���ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="el_mode">EL��Ч��ƽ���ƶ���ʽ��
		/// 0������ͣ������Ч
		/// 1������ͣ������Ч
		/// 2������ͣ������Ч
		/// 3������ͣ������Ч
		/// </param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_EL_MODE",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_EL_MODE(UInt16 axis,
			UInt16 el_mode);

		//����EL�źŵ�ʹ��״̬
		/// <summary>
		/// ����EL�źŵ�ʹ��״̬
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="enable">EL�źŵ�ʹ��״̬��0����ʹ�ܣ�1��ʹ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_Enable_EL_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_Enable_EL_PIN(UInt16 axis,
			UInt16 enable);

		//����ԭ��ORG�źŵ���Ч��ƽ���Լ�����/��ֹ�˲�����
		/// <summary>
		/// ����ԭ��ORG�źŵ���Ч��ƽ���Լ�����/��ֹ�˲�����
		/// ע�⣺�����˶��У���ѡ�����ģʽΪ0~4ʱ���øú�������ԭ���ź���Ч��ƽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="org_logic">ORG�źŵ���Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="filter">����/��ֹ�˲����ܣ�0����ֹ��1������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_HOME_pin_logic",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_HOME_pin_logic(UInt16 axis,
			UInt16 org_logic, UInt16 filter);

		//�����ָ������ŷ�ʹ�ܶ��ӵĿ���
		/// <summary>
		/// �����ָ������ŷ�ʹ�ܶ��ӵĿ���
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="on_off">�趨�ܽŵ�ƽ״̬��0���ͣ�1����</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_write_SEVON_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_write_SEVON_PIN(UInt16 axis,
			UInt16 on_off);

		//��ȡָ������ŷ�ʹ�ܶ��ӵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ������ŷ�ʹ�ܶ��ӵĵ�ƽ״̬
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_SEVON_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_SEVON_PIN(UInt16 axis);

		//��ȡָ���˶���ġ��ŷ�׼���á����ӵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ���˶���ġ��ŷ�׼���á����ӵĵ�ƽ״̬
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_RDY_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_RDY_PIN(UInt16 axis);

		//ͨ������/������ƺ���

		//��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <param name="bitno">ָ�������λ�ţ�ȡֵ��Χ��1~32��</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_inbit",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_inbit(UInt16 cardno, UInt16 bitno);

		//��ָ�����ƿ���ĳһλ�������λ
		/// <summary>
		/// ��ָ�����ƿ���ĳһλ�������λ
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <param name="bitno">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <param name="on_off">�����ƽ��0����ʾ����͵�ƽ��1����ʾ����ߵ�ƽ</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_write_outbit",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_write_outbit(UInt16 cardno, UInt16 bitno, UInt16 on_off);

		//��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <param name="bitno">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_outbit",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_outbit(UInt16 cardno, UInt16 bitno);

		//��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <returns>bit0~bit31λֵ�ֱ�����1~32������˿�ֵ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_inport",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_inport(UInt16 cardno);

		//��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <returns>bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_outport",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_outport(UInt16 cardno);

		//ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <param name="port_value">bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_write_outport",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_write_outport(UInt16 cardno,
			UInt32 port_value);

		//�ƶ�����

		//ָ�������ֹͣ�����ô˺���ʱ�������ٺ�ֹͣ��ֹͣʱ���ٶ�����ʼ�ٶȺ�ֹͣ�ٶ��еĽϴ�ֵ��
		/// <summary>
		/// ָ�������ֹͣ�����ô˺���ʱ�������ٺ�ֹͣ��ֹͣʱ���ٶ�����ʼ�ٶȺ�ֹͣ�ٶ��еĽϴ�ֵ��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="Tdec">����ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_decel_stop",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_decel_stop(UInt16 axis, double Tdec);

		//ʹָ��������ֹͣ��û���κμ��ٵĹ���
		/// <summary>
		/// ʹָ��������ֹͣ��û���κμ��ٵĹ���
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_imd_stop",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_imd_stop(UInt16 axis);

		////ʹ���е��˶������ֹͣ
		/// <summary>
		/// ʹ���е��˶������ֹͣ
		/// </summary>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_emg_stop",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_emg_stop();

		//λ�����úͶ�ȡ����

		//��ȡָ�����ָ������λ��
		/// <summary>
		/// ��ȡָ�����ָ������λ��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>ָ�������������������λ��pulse</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_position",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_position(UInt16 axis);

		//��ȡָ�����˶���Ŀ������λ��[��������]
		/// <summary>
		/// ��ȡָ�����˶���Ŀ������λ��[��������]
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>ָ�����˶���Ŀ������λ��[��������]����λ��pulse</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_target_position",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_target_position(UInt16 axis);

		//����ָ�����ָ������λ��
		/// <summary>
		/// ����ָ�����ָ������λ��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="current_position">����λ������ֵ</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_position",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_position(UInt16 axis,
			Int32 current_position);

		//״̬��⺯��

		//���ָ������˶�״̬��ֹͣ������������
		/// <summary>
		/// ���ָ������˶�״̬��ֹͣ������������
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>0��ָ�����������У�1��ָ������ֹͣ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_check_done",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt16 d2410_check_done(UInt16 axis);

		//��ȡָ�����й��˶��źŵ�״̬������ָ�����ר��I/O״̬
		/// <summary>
		/// ��ȡָ�����й��˶��źŵ�״̬������ָ�����ר��I/O״̬
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>λ��:11, �ź�����: ALM, 1����ʾ�ŷ������ź� ALM Ϊ ON
		/// λ��:12, �ź�����: PEL, 1����ʾ����λ�ź� +EL Ϊ ON
		/// λ��:13, �ź�����: NEL, 1����ʾ����λ�źŨCELΪ ON
		/// λ��:14, �ź�����: ORG, 1����ʾԭ���ź� ORG Ϊ ON
		/// λ��:����, �ź�����: ����
		/// </returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_axis_io_status",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt16 d2410_axis_io_status(UInt16 axis);

		//��ȡָ������ⲿ�ź�״̬
		/// <summary>
		/// ��ȡָ������ⲿ�ź�״̬
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>λ��:0~3, �ź�����: ����
		/// λ��:7, �ź�����: EMG, 1����ʾ����ֹͣ�źţ�EMG��Ϊ ON
		/// λ��:10, �ź�����: EZ, 1����ʾ�����źţ�EZ��Ϊ ON
		/// λ��:11, �ź�����: +DR(PA), 1����ʾ +DR(PA) �ź�Ϊ ON
		/// λ��:12, �ź�����: -DR(PB), 1����ʾ -DR(PB) �ź�Ϊ ON
		/// λ��:����λ, �ź�����: ����
		/// </returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_rsts",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_rsts(UInt16 axis);

		//�ٶ����úͶ�ȡ����              

		//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
		/// <summary>
		/// �趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
		/// </summary>
		/// <param name="Min_Vel">��������</param>
		/// <param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
		/// <param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_vector_profile",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_vector_profile(double Min_Vel,
			double Max_Vel, double Tacc, double Tdec);

		//�趨�������ߵ���ʼ�ٶȡ������ٶȡ�����ʱ�䡢����ʱ��
		/// <summary>
		/// �趨�������ߵ���ʼ�ٶȡ������ٶȡ�����ʱ�䡢����ʱ��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
		/// <param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_profile",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_profile(UInt16 axis,
			double Min_Vel, double Max_Vel, double Tacc, double Tdec);

		//d2410_set_profile��չ����������ֹͣ�ٶȵ��趨
		/// <summary>
		/// d2410_set_profile��չ����������ֹͣ�ٶȵ��趨
		/// </summary>
		/// <param name="axis">�μ��˶������</param>
		/// <param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
		/// <param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Stop_Vel">ֹͣ�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_profile_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_profile_Extern(UInt16 axis,
			double Min_Vel, double Max_Vel, double Tacc, double Tdec,
			double Stop_Vel);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="axis"></param>
		/// <param name="Min_Vel"></param>
		/// <param name="Max_Vel"></param>
		/// <param name="Tacc"></param>
		/// <param name="Tdec"></param>
		/// <param name="Sacc"></param>
		/// <param name="Sdec"></param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_s_profile",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_s_profile(UInt16 axis,
			double Min_Vel, double Max_Vel, double Tacc, double Tdec,
			Int32 Sacc, Int32 Sdec);

		//�趨S�������˶�����ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		/// <summary>
		/// �趨S�������˶�����ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		/// </summary>
		/// <param name="axis">�μ��˶������</param>
		/// <param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
		/// <param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Tsacc">S��ʱ�䣬��λ��s����Χ[0,50] ms</param>
		/// <param name="Tsdec">��������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_st_profile",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_st_profile(UInt16 axis,
			double Min_Vel, double Max_Vel, double Tacc, double Tdec,
			double Tsacc, double Tsdec);

		//d2410_set_st_profile��չ����������ֹͣ�ٶȵ��趨
		/// <summary>
		/// d2410_set_st_profile��չ����������ֹͣ�ٶȵ��趨
		/// </summary>
		/// <param name="axis">�μ��˶������</param>
		/// <param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
		/// <param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="Tsacc">S��ʱ�䣬��λ��s����Χ[0,50] ms</param>
		/// <param name="Tsdec">��������</param>
		/// <param name="Stop_Vel">ֹͣ�ٶ�</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_st_profile_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_st_profile_Extern(UInt16 axis,
			double Min_Vel, double Max_Vel, double Tacc, double Tdec,
			double Tsacc, double Tsdec, double Stop_Vel);

		//��ȡ��ǰ�ٶ�ֵ����λ��pulse/s
		/// <summary>
		/// ��ȡ��ǰ�ٶ�ֵ����λ��pulse/s
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>ָ������ٶ�������, ע �⣺��ִ�в岹�˶�ʱ�����øú�����ȡ��Ϊʸ���ٶ�</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_current_speed",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern double d2410_read_current_speed(UInt16 axis);

		//��ȡָ������ʸ���ٶ�
		/// <summary>
		/// ��ȡָ������ʸ���ٶ�
		/// </summary>
		/// <param name="card">ָ������</param>
		/// <returns>����ʸ���ٶ�</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_vector_speed",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern double d2410_read_vector_speed(UInt16 card);

		//���߱���/��λ

		//���߸ı�ָ����ĵ�ǰ�˶��ٶȡ��ú���ֻ�����ڵ����˶��еı���
		/// <summary>
		/// ���߸ı�ָ����ĵ�ǰ�˶��ٶȡ��ú���ֻ�����ڵ����˶��еı���
		/// </summary>
		/// <param name="axis">�μ��˶������</param>
		/// <param name="Curr_Vel">�µ������ٶȣ���λ��pulse/s
		/// ע�⣺
		/// (1)����һ�������������Ĭ�������ٶȽ��ᱻ��дΪCurr_Vel��
		///    Ҳ��������get_profile�ض��ٶȲ���ʱ�ᷢ����set_profile�����õĲ�һ�µ�����;
		/// (2)�ڵ����ٶ��˶���Curr_Vel��ֵ��ʾ��������٣���ֵ��ʾ��������١� 
		///    �ڵ��ᶨ���˶���Curr_Velֻ������ֵ��
		/// </param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_change_speed",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_change_speed(UInt16 axis, double Curr_Vel);

		//�ڵ�������˶��иı�Ŀ��λ��
		/// <summary>
		/// �ڵ�������˶��иı�Ŀ��λ��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="dist">����λ��ֵ, ע�⣺����distΪ����λ��ֵ�����۵�ǰ���˶�ģʽΪ�������껹���������ģʽ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_reset_target_position",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_reset_target_position(UInt16 axis,
			Int32 dist);

		//���ᶨ���˶�

		//ʹָ�����ԶԳ������ٶ���������λ�˶�
		/// <summary>
		/// ʹָ�����ԶԳ������ٶ���������λ�˶�
		/// </summary>
		/// <param name="axis">�μ��˶������</param>
		/// <param name="Dist">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="posi_mode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_t_pmove",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_t_pmove(UInt16 axis,
			Int32 Dist, UInt16 posi_mode);

		//ʹָ�����ԷǶԳ������ٶ���������λ�˶�
		/// <summary>
		/// ʹָ�����ԷǶԳ������ٶ���������λ�˶�
		/// </summary>
		/// <param name="axis">�μ��˶������</param>
		/// <param name="Dist">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="posi_mode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_ex_t_pmove",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_ex_t_pmove(UInt16 axis,
			Int32 Dist, UInt16 posi_mode);

		//ʹָ�����ԶԳ�S���ٶ���������λ�˶�
		/// <summary>
		/// ʹָ�����ԶԳ�S���ٶ���������λ�˶�
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="Dist">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="posi_mode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_s_pmove",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_s_pmove(UInt16 axis,
			Int32 Dist, UInt16 posi_mode);

		//ʹָ�����ԷǶԳ�S���ٶ���������λ�˶�
		/// <summary>
		/// ʹָ�����ԷǶԳ�S���ٶ���������λ�˶�
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="Dist">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="posi_mode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_ex_s_pmove",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_ex_s_pmove(UInt16 axis,
			Int32 Dist, UInt16 posi_mode);

		//���������˶�

		//ʹָ������S���ٶ����߼��ٵ����٣�������������ȥ
		/// <summary>
		/// ʹָ������S���ٶ����߼��ٵ����٣�������������ȥ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="dir">ָ���˶��ķ���0��������1��������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_s_vmove",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_s_vmove(UInt16 axis, UInt16 dir);

		//ʹָ������T���ٶ����߼��ٵ����٣�������������ȥ
		/// <summary>
		/// ʹָ������T���ٶ����߼��ٵ����٣�������������ȥ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="dir">ָ���˶��ķ���0��������1��������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_t_vmove",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_t_vmove(UInt16 axis, UInt16 dir);

		//ֱ�߲岹

		//ָ�����������ԶԳƵ������ٶ��������岹�˶�
		/// <summary>
		/// ָ�����������ԶԳƵ������ٶ��������岹�˶�
		/// </summary>
		/// <param name="axis1">ָ������岹�ĵ�һ��</param>
		/// <param name="Dist1">ָ��axis1��λ��ֵ����λ��pulse</param>
		/// <param name="axis2">ָ������岹�ĵڶ���</param>
		/// <param name="Dist2">ָ��axis2��λ��ֵ����λ��pulse</param>
		/// <param name="posi_mode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_t_line2",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_t_line2(UInt16 axis1, Int32 Dist1,
			UInt16 axis2, Int32 Dist2, UInt16 posi_mode);

		//ָ�����������ԶԳƵ������ٶ��������岹�˶�
		/// <summary>
		/// ָ�����������ԶԳƵ������ٶ��������岹�˶�
		/// </summary>
		/// <param name="axis">����б��ָ��</param>
		/// <param name="Dist1">ָ��axis[0]���λ��ֵ����λ��pulse</param>
		/// <param name="Dist2">ָ��axis[1]���λ��ֵ����λ��pulse</param>
		/// <param name="Dist3">ָ��axis[2]���λ��ֵ����λ��pulse</param>
		/// <param name="posi_mode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_t_line3",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_t_line3(UInt16[] axis,
			Int32 Dist1, Int32 Dist2, Int32 Dist3, UInt16 posi_mode);

		//ָ�������ԶԳƵ������ٶ��������岹�˶�
		/// <summary>
		/// ָ�������ԶԳƵ������ٶ��������岹�˶�
		/// </summary>
		/// <param name="cardno">ָ���岹�˶��İ忨��, ��Χ��0~N��NΪ���ţ�</param>
		/// <param name="Dist1">ָ����һ���λ��ֵ����λ��pulse</param>
		/// <param name="Dist2">ָ���ڶ����λ��ֵ����λ��pulse</param>
		/// <param name="Dist3">ָ���������λ��ֵ����λ��pulse</param>
		/// <param name="Dist4">ָ���������λ��ֵ����λ��pulse</param>
		/// <param name="posi_mode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_t_line4",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_t_line4(UInt16 cardno,
			Int32 Dist1, Int32 Dist2, Int32 Dist3, Int32 Dist4, UInt16 posi_mode);

		//Բ���岹

		//ָ������������Ե�ǰλ��Ϊ��㣬��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// <summary>
		/// ָ������������Ե�ǰλ��Ϊ��㣬��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// </summary>
		/// <param name="axis">����б�ָ��</param>
		/// <param name="target_pos">Ŀ�����λ���б�ָ�룬��λ��pulse</param>
		/// <param name="cen_pos">Բ�ľ���λ���б�ָ�룬��λ��pulse</param>
		/// <param name="arc_dir">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_arc_move",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_arc_move(UInt16[] axis,
			Int32[] target_pos, Int32[] cen_pos, UInt16 arc_dir);

		//ָ������������Ե�ǰλ��Ϊ��㣬��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// <summary>
		/// ָ������������Ե�ǰλ��Ϊ��㣬��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// </summary>
		/// <param name="axis">����б�ָ��</param>
		/// <param name="rel_pos">Ŀ�����λ���б�ָ��, ��λ��pulse</param>
		/// <param name="rel_cen">Բ�����λ���б�ָ��, ��λ��pulse</param>
		/// <param name="arc_dir">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_rel_arc_move",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_rel_arc_move(UInt16[] axis,
			Int32[] rel_pos, Int32[] rel_cen, UInt16 arc_dir);

		//�����˶�

		//�����������������źŵļ�����ʽ
		/// <summary>
		/// �����������������źŵļ�����ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="inmode">��ʾ���뷽ʽ��0��A��B��λ����������1��˫�����ź�</param>
		/// <param name="multi">�������ļ������򼰱������ã��������ֵı���, ������ʾĬ�Ϸ��򣬸�����ʾ��Ĭ�Ϸ����෴</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_handwheel_inmode",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_handwheel_inmode(UInt16 axis,
			UInt16 inmode, double multi);

		//����ָ��������������˶�
		/// <summary>
		/// ����ָ��������������˶�,
		/// ע �⣺�����������˶���ֻ�з���d2410_decel_stop��d2410_imd_stop�����Ż��˳�����ģʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_handwheel_move",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_handwheel_move(UInt16 axis);

		//��ԭ��

		//�趨ָ����Ļ�ԭ��ģʽ
		/// <summary>
		/// �趨ָ����Ļ�ԭ��ģʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="mode">��ԭ����ź�ģʽ��
		/// 0��ֻ��home 
		/// 1����home��EZ����1��EZ�ź� 
		/// 2��һ�λ���ӻ��� 
		/// 3�����λ���
		/// 4��EZ��������
		/// 5��ԭ�㲶�����
		/// </param>
		/// <param name="EZ_count">EZ�źų���EZ_countָ���Ĵ��������˶�ֹͣ��
		/// ����mode=4ʱ�ò���������Ч��ȡֵ��Χ��1��16</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_home_mode",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_home_mode(UInt16 axis,
			UInt16 mode, UInt16 EZ_count);

		//�����ԭ���˶�
		/// <summary>
		/// �����ԭ���˶�
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="home_mode">��ԭ�㷽ʽ��1���������ԭ�㣬2���������ԭ��</param>
		/// <param name="vel_mode">��ԭ���ٶȣ�0�����ٻ�ԭ�㣬1�����ٻ�ԭ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_home_move",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_home_move(UInt16 axis,
			UInt16 home_mode, UInt16 vel_mode);

		//ԭ������

		//����/��ȡԭ�����淽ʽ
		/// <summary>
		/// ����/��ȡԭ�����淽ʽ, ע�⣺�����˶��У���ѡ�����ģʽΪ5ʱ����d2410_set_homelatch_mode��������ԭ���ź����淽ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="enable">ԭ������ʹ��״̬��0����ֹ��2������</param>
		/// <param name="logic">ԭ�����淽ʽ��0���½������棬1������������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_homelatch_mode",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_homelatch_mode(UInt16 axis,
			UInt16 enable, UInt16 logic);

		//����/��ȡԭ�����淽ʽ
		/// <summary>
		/// ����/��ȡԭ�����淽ʽ, ע�⣺�����˶��У���ѡ�����ģʽΪ5ʱ����d2410_set_homelatch_mode��������ԭ���ź����淽ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="enable">ԭ������ʹ��״̬��0����ֹ��2������</param>
		/// <param name="logic">ԭ�����淽ʽ��0���½������棬1������������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_homelatch_mode",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_homelatch_mode(UInt16 axis, ref UInt16 enable, ref UInt16 logic);

		//��ȡԭ�������־
		/// <summary>
		/// ��ȡԭ�������־
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>ԭ�������־��0��δ������1������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_homelatch_flag",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_homelatch_flag(UInt16 axis);

		//��λԭ�������־
		/// <summary>
		/// ��λԭ�������־
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_reset_homelatch_flag",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_reset_homelatch_flag(UInt16 axis);

		//��ȡԭ������ֵ��ԭ������λ��Ϊָ������λ�ã�
		/// <summary>
		/// ��ȡԭ������ֵ��ԭ������λ��Ϊָ������λ�ã�
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>ԭ������ֵ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_homelatch_value",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_homelatch_value(UInt16 axis);

		//����λ�ñȽϺ���

		//���ñȽ�������
		/// <summary>
		/// ���ñȽ�������
		/// </summary>
		/// <param name="card">����</param>
		/// <param name="queue">�Ƚ϶��кţ�0��1</param>
		/// <param name="enable">1��ʹ�ܱȽϹ��ܣ�0����ֹ�ȽϹ���</param>
		/// <param name="axis">���</param>
		/// <param name="cmp_source">�Ƚ�Դ��0���Ƚ�ָ��λ�ã�1���Ƚϱ�����λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_compare_config_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_compare_config_Extern(UInt16 card,
			UInt16 queue, UInt16 enable, UInt16 axis, UInt16 cmp_source);

		//��ȡ�Ƚ�������
		/// <summary>
		/// ��ȡ�Ƚ�������
		/// </summary>
		/// <param name="card">����</param>
		/// <param name="queue">�Ƚ϶��кţ�0��1</param>
		/// <param name="enable">1��ʹ�ܱȽϹ��ܣ�0����ֹ�ȽϹ���</param>
		/// <param name="axis">���</param>
		/// <param name="cmp_source">�Ƚ�Դ��0���Ƚ�ָ��λ�ã�1���Ƚϱ�����λ��</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_compare_get_config_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_compare_get_config_Extern(UInt16 card,
			UInt16 queue, ref UInt16 enable, ref UInt16 axis, ref UInt16 cmp_source);

		//������бȽϵ�
		/// <summary>
		/// ������бȽϵ�
		/// </summary>
		/// <param name="card">����</param>
		/// <param name="queue">�Ƚ϶��кţ�0��1</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_compare_clear_points_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_compare_clear_points_Extern(UInt16 card, UInt16 queue);

		//��ӱȽϵ�
		/// <summary>
		/// ��ӱȽϵ�
		/// </summary>
		/// <param name="card">����</param>
		/// <param name="queue">�Ƚ϶��кţ�0��1</param>
		/// <param name="pos">λ������</param>
		/// <param name="dir">�ȽϷ���0��С�ڵ��ڣ�1�����ڵ���</param>
		/// <param name="action">�Ƚϵ㴥������</param>
		/// <param name="actpara">�Ƚϵ㴥�����ܲ���
		/// action:1 , actpara: IO��, ����: IO��Ϊ�͵�ƽ
		/// action:2 , actpara: IO��, ����: IO��Ϊ�ߵ�ƽ
		/// action:3 , actpara: IO��, ����: ȡ��IO
		/// action:5 , actpara: IO��, ����: ���100us ����
		/// action:6 , actpara: IO��, ����: ���1ms ����
		/// action:7 , actpara: IO��, ����: ���10ms ����
		/// action:8 , actpara: IO��, ����: ���100ms ����
		/// action:11 , actpara: �ٶ�ֵ, ����: ��ǰ�����
		/// action:13 , actpara: ���, ����: ָֹͣ����
		/// </param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_compare_add_point_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_compare_add_point_Extern(UInt16 card,
			UInt16 queue, UInt32 pos, UInt16 dir, UInt16 action, UInt32 actpara);

		//��ȡ��ǰ�Ƚϵ�λ��
		/// <summary>
		/// ��ȡ��ǰ�Ƚϵ�λ��
		/// </summary>
		/// <param name="card">����</param>
		/// <param name="queue">�Ƚ϶��кţ�0��1</param>
		/// <returns>��ǰ�Ƚϵ��λ��ֵ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_compare_get_current_point_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_compare_get_current_point_Extern(UInt16 card, UInt16 queue);

		//��ѯ�Ѿ��ȽϹ��ĵ����
		/// <summary>
		/// ��ѯ�Ѿ��ȽϹ��ĵ����
		/// </summary>
		/// <param name="card">����</param>
		/// <param name="queue">�Ƚ϶��кţ�0��1</param>
		/// <returns>�Ѿ��ȽϹ��ıȽϵ������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_compare_get_points_runned_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_compare_get_points_runned_Extern(UInt16 card, UInt16 queue);

		//����λ������
		/// <summary>
		/// ����λ������
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="factor">������ϵ�������嵱����
		/// ˵ �������赱ǰ������������Ϊ200��ָ��������Ϊ1002�� ��������Ϊ2��������ϵ����Ϊ5��
		/// �������£� 200*5=1000,1000-1002=-2,��������Χ[-2,2]֮�ڣ���ʱ��Ϊ��������λ��
		/// </param>
		/// <param name="errormsg">λ������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_factor_error",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_set_factor_error(UInt16 axis,
			double factor, Int32 errormsg);

		//��ȡλ������
		/// <summary>
		/// ��ȡλ������
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="factor">������ϵ�������嵱����</param>
		/// <param name="errormsg">λ������
		/// ˵ �������赱ǰ������������Ϊ200��ָ��������Ϊ1002�� ��������Ϊ2��������ϵ����Ϊ5��
		/// �������£� 200*5=1000,1000-1002=-2,��������Χ[-2,2]֮�ڣ���ʱ��Ϊ��������λ��
		/// </param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_factor_error",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_factor_error(UInt16 axis,
			ref double factor, ref Int32 errormsg);

		//��ѯ���Լ���ıȽϵ�����
		/// <summary>
		/// ��ѯ���Լ���ıȽϵ�����
		/// </summary>
		/// <param name="card">����</param>
		/// <param name="queue">�Ƚ϶��кţ�0��1</param>
		/// <returns>ʣ����õıȽϵ�����</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_compare_get_points_remained_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_compare_get_points_remained_Extern(UInt16 card, UInt16 queue);

		//����λ�ñȽ�

		//���ø���λ�ñȽ���
		/// <summary>
		/// ���ø���λ�ñȽ���
		/// </summary>
		/// <param name="axis">���</param>
		/// <param name="cmp_enable">�Ƚ���ʹ��״̬��0����ֹ��1��ʹ��</param>
		/// <param name="cmp_pos">�Ƚ�λ��ֵ</param>
		/// <param name="CMP_logic">CMP�����Ч��ƽ��0���͵�ƽ��1���ߵ�ƽ
		/// ע �⣺������CMP�Ƚ�������ӦCMP����ڵĵ�ƽ���Ϊ�����õĵ�ƽ�෴��
		/// ��λ�ô���ʱ��CMP�˿ڻ����һ�������źţ�1~2ms����
		/// </param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_CMP_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_CMP_PIN(UInt16 axis,
			UInt16 cmp_enable, Int32 cmp_pos, UInt16 CMP_logic);

		//��ȡ����λ�ñȽ���
		/// <summary>
		/// ��ȡ����λ�ñȽ���
		/// </summary>
		/// <param name="axis">���</param>
		/// <param name="cmp_enable">�Ƚ���ʹ��״̬��0����ֹ��1��ʹ��</param>
		/// <param name="cmp_pos">�Ƚ�λ��ֵ</param>
		/// <param name="CMP_logic">CMP�����Ч��ƽ��0���͵�ƽ��1���ߵ�ƽ
		/// ע �⣺������CMP�Ƚ�������ӦCMP����ڵĵ�ƽ���Ϊ�����õĵ�ƽ�෴��
		/// ��λ�ô���ʱ��CMP�˿ڻ����һ�������źţ�1~2ms����
		/// </param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_config_CMP_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_config_CMP_PIN(UInt16 axis,
			ref UInt16 cmp_enable, ref Int32 cmp_pos, ref UInt16 CMP_logic);

		//��ȡ����λ�ñȽ������״̬
		/// <summary>
		/// ��ȡ����λ�ñȽ������״̬
		/// </summary>
		/// <param name="axis">���</param>
		/// <returns>1-�ߵ�ƽ��0-�͵�ƽ</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_CMP_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_CMP_PIN(UInt16 axis);

		//���ø���λ�ñȽ������״̬
		/// <summary>
		/// ���ø���λ�ñȽ������״̬
		/// </summary>
		/// <param name="axis">���</param>
		/// <param name="on_off">1-�ߵ�ƽ��0-�͵�ƽ</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_write_CMP_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_write_CMP_PIN(UInt16 axis, UInt16 on_off);

		//��������������

		//��ȡָ�������������λ���������ֵ����Χ��28λ�з�����
		/// <summary>
		/// ��ȡָ�������������λ���������ֵ����Χ��28λ�з�����
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>λ�÷�������ֵ����λ��pulse</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_encoder",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_encoder(UInt16 axis);

		//����ָ��������������������ֵ����Χ��28λ�з�����
		/// <summary>
		/// ����ָ��������������������ֵ����Χ��28λ�з�����
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="encoder_value">���������趨ֵ</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_encoder",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_encoder(UInt16 axis,
			UInt32 encoder_value);

		//����ָ�����EZ�źŵ���Ч��ƽ��������
		/// <summary>
		/// ����ָ�����EZ�źŵ���Ч��ƽ��������
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="ez_logic">EZ�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="ez_mode">EZ�źŵĹ�����ʽ��0��EZ�ź���Ч��1��EZ�Ǽ�������λ�ź�</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_EZ_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_EZ_PIN(UInt16 axis,
			UInt16 ez_logic, UInt16 ez_mode);

		//��ȡָ�����ƿ��ļ������ı�ʶλ
		/// <summary>
		/// ��ȡָ�����ƿ��ļ������ı�ʶλ
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���</param>
		/// <returns>����ֵλ�� 0: ָ������X�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 1: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 2: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 3: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 4~7: ����
		/// ����ֵλ�� 8: ָ������Y�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 9: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 10: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 11: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 12~15: ����
		/// ����ֵλ�� 16: ָ������Z�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 17: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 18: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 19: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 20~23: ����
		/// ����ֵλ�� 24: ָ������U�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 25: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 26: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 27: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 28~31: ����
		/// </returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_counter_flag",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_counter_flag(UInt16 cardno);

		//��λ�������ļ�����־λ, ��Χ��0~N��NΪ���ţ�
		/// <summary>
		/// ��λ�������ļ�����־λ, ��Χ��0~N��NΪ���ţ�
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_reset_counter_flag",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_reset_counter_flag(UInt16 cardno);

		//��λ�������������־λ, ��Χ��0~N��NΪ���ţ�
		/// <summary>
		/// ��λ�������������־λ, ��Χ��0~N��NΪ���ţ�
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_reset_clear_flag",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_reset_clear_flag(UInt16 cardno);

		//��������

		//����ָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ
		/// <summary>
		/// ����ָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="ltc_logic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="ltc_mode">��������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_LTC_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_LTC_PIN(UInt16 axis,
			UInt16 ltc_logic, UInt16 ltc_mode);

		//��ȡָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ
		/// <summary>
		/// ��ȡָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="ltc_logic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="ltc_mode">��������</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_config_LTC_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_config_LTC_PIN(UInt16 axis,
			ref UInt16 ltc_logic, ref UInt16 ltc_mode);

		//d2410_config_LTC_PIN��չ�����������˲�ʱ����趨
		/// <summary>
		/// d2410_config_LTC_PIN��չ�����������˲�ʱ����趨
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="ltc_logic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="ltc_mode">��������</param>
		/// <param name="ltc_filter">�˲�ʱ�䣬��λ��ms</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_config_LTC_PIN_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_config_LTC_PIN_Extern(UInt16 axis,
			ref UInt16 ltc_logic, ref UInt16 ltc_mode, ref double ltc_filter);

		//d2410_config_LTC_PIN��չ�����������˲�ʱ����趨
		/// <summary>
		/// d2410_config_LTC_PIN��չ�����������˲�ʱ����趨
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="ltc_logic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="ltc_mode">��������</param>
		/// <param name="ltc_filter">�˲�ʱ�䣬��λ��ms</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_LTC_PIN_Extern",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_LTC_PIN_Extern(UInt16 axis,
			UInt16 ltc_logic, UInt16 ltc_mode, double ltc_filter);

		//�������淽ʽΪ���������������ͬʱ����
		/// <summary>
		/// �������淽ʽΪ���������������ͬʱ����
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���[0~N]</param>
		/// <param name="all_enable">���淽ʽ ��0���������棬1������ͬʱ����
		/// ע �⣺λ��������ʱֻ֧�ַ���λ������
		/// </param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_latch_mode",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_latch_mode(UInt16 cardno,
			UInt16 all_enable);

		//���ñ������ļ�����ʽ
		/// <summary>
		/// ���ñ������ļ�����ʽ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="mode">�������ļ�����ʽ��
		/// 0����A/B�� (����/����)
		/// 1��1��A/B
		/// 2��2�� A/B
		/// 3��4�� A/B
		/// </param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_counter_config",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_counter_config(UInt16 axis, UInt16 mode);

		//��ȡ��������������ֵ
		/// <summary>
		/// ��ȡ��������������ֵ
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>�������ڵı���������������λ��pulse
		/// ע �⣺��λ�������У���δ������������ֻ�����һ�δ���λ�ã�
		/// ֻ�е��ú����������״̬�����ٴ�����
		/// </returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_latch_value",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_latch_value(UInt16 axis);

		//��ȡָ�����ƿ����������ı�־λ
		/// <summary>
		/// ��ȡָ�����ƿ����������ı�־λ
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <returns>����ֵλ��: 0, ����: 0��ָ������0���д����ź�
		/// ����ֵλ��: 1, ����: 0��1���д����ź�
		/// ����ֵλ��: 2, ����: 0��2���д����ź�
		/// ����ֵλ��: 3, ����: 0��3���д����ź�
		/// ����ֵλ��: 4, ����: 1��ָ������0���������ź�
		/// ����ֵλ��: 5, ����: 1��1���������ź�
		/// ����ֵλ��: 6, ����: 1��2���������ź�
		/// ����ֵλ��: 7, ����: 1��3���������ź�
		/// ����ֵλ��: 8, ����: 1��0��λ��������
		/// ����ֵλ��: 9, ����: 1��1��λ��������
		/// ����ֵλ��: 10, ����: 1��2��λ��������
		/// ����ֵλ��: 11, ����: 1��3��λ��������
		/// ����ֵλ��: 12, ����: 1��ָ������0��λ��������
		/// ����ֵλ��: 13, ����: 1��1��λ��������
		/// ����ֵλ��: 14, ����: 1��2��λ��������
		/// ����ֵλ��: 15, ����: 1��3��λ��������
		/// ����ֵλ��: 16~31, ����:����
		/// </returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_latch_flag",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_latch_flag(UInt16 cardno);

		//��λָ�����ƿ����������ı�־λ
		/// <summary>
		/// ��λָ�����ƿ����������ı�־λ
		/// </summary>
		/// <param name="cardno">ָ�����ƿ���, ��Χ��0~N��NΪ���ţ�</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_reset_latch_flag",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_reset_latch_flag(UInt16 cardno);

		//ѡ��ȫ������ʱ���ⴥ���ź�ͨ���������ɶ����ź�ͨ�����룬��LTC1, LTC2��Ĭ��ΪLTC1
		/// <summary>
		/// ѡ��ȫ������ʱ���ⴥ���ź�ͨ���������ɶ����ź�ͨ�����룬��LTC1, LTC2��Ĭ��ΪLTC1
		/// </summary>
		/// <param name="cardno">����</param>
		/// <param name="num">�ź�ͨ��ѡ��ţ�0��LTC1�����ĸ��ᣬ1��LTC2�����ĸ���</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_triger_chunnel",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_triger_chunnel(UInt16 cardno,
			UInt16 num);

		//ѡ�������Speaker��LED������߼���Ĭ��Ϊ����Ч
		/// <summary>
		/// ѡ�������Speaker��LED������߼���Ĭ��Ϊ����Ч
		/// </summary>
		/// <param name="cardno">����</param>
		/// <param name="logic">0������Ч��1������Ч</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_speaker_logic",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_set_speaker_logic(UInt16 cardno,
			UInt16 logic);

		//���ָ�λ����������
		/// <summary>
		/// ���ָ�λ����������
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>0��������λ�����趨��Ŀ��λ�õ�����֮�⣻
		/// 1��������λ�����趨��Ŀ��λ�õ�����֮��</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_check_success_encoder",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_check_success_encoder(UInt16 axis);

		//���ָ�λ�����塿
		/// <summary>
		/// ���ָ�λ�����塿
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <returns>0��ָ��λ�����趨��Ŀ��λ�õ�����֮�⣻
		/// 1��ָ��λ�����趨��Ŀ��λ�õ�����֮��</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_check_success_pulse",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_check_success_pulse(UInt16 axis);

		//EMG����

		//EMG�ź����ã���ͣ�ź���Ч�������ֹͣ������
		/// <summary>
		/// EMG�ź����ã���ͣ�ź���Ч�������ֹͣ������
		/// </summary>
		/// <param name="cardno">�˶�������</param>
		/// <param name="enable">0����Ч��1����Ч</param>
		/// <param name="emg_logic">0������Ч��1������Ч</param>
		/// <returns>�������</returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_EMG_PIN",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_EMG_PIN(UInt16 cardno,
			UInt16 enable, UInt16 emg_logic);

		//�����λ����

		//
		/// <summary>
		/// 
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="ON_OFF"></param>
		/// <param name="source_sel"></param>
		/// <param name="SL_action"></param>
		/// <param name="N_limit"></param>
		/// <param name="P_limit"></param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_config_softlimit",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_config_softlimit(UInt16 axis,
			UInt16 ON_OFF, UInt16 source_sel, UInt16 SL_action, Int32 N_limit,
			Int32 P_limit);

		//
		/// <summary>
		/// 
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="ON_OFF"></param>
		/// <param name="source_sel"></param>
		/// <param name="SL_action"></param>
		/// <param name="N_limit"></param>
		/// <param name="P_limit"></param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_config_softlimit",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_get_config_softlimit(UInt16 axis,
			ref UInt16 ON_OFF, ref UInt16 source_sel, ref UInt16 SL_action,
			ref Int32 N_limit, ref Int32 P_limit);

		//���嵱������

		//��ȡ���嵱�����ƶ�1��������Ҫ������������
		/// <summary>
		/// ��ȡ���嵱�����ƶ�1��������Ҫ������������
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="equiv">�ƶ�1��������Ҫ����������</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_equiv",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_equiv(UInt16 axis, ref double equiv);


		//�������嵱�����ƶ�1��������Ҫ������������
		/// <summary>
		/// �������嵱�����ƶ�1��������Ҫ������������
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="new_equiv">�ƶ�1��������Ҫ����������</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_equiv",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_set_equiv(UInt16 axis, double new_equiv);

		//��ȡ��ĵ�ǰλ�á���λ��mm��
		/// <summary>
		/// ��ȡ��ĵ�ǰλ�á���λ��mm��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="pos_by_mm">��ĵ�ǰλ�á���λ��mm��</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_position_unitmm",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_position_unitmm(UInt16 axis, ref double pos_by_mm);

		//�趨ָ����ĵ�ǰλ�á���λ��mm���������ڻص�ԭ���λ�����㡿
		/// <summary>
		/// �趨ָ����ĵ�ǰλ�á���λ��mm���������ڻص�ԭ���λ�����㡿
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="pos_by_mm">���λ�á���λ��mm��</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_position_unitmm",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_set_position_unitmm(UInt16 axis, double pos_by_mm);

		//��ȡ��ǰ�ٶ�ֵ����λ��mm/s
		/// <summary>
		/// ��ȡ��ǰ�ٶ�ֵ����λ��mm/s
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="current_speed">��ǰ�ٶ�ֵ����λ��mm/s</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_read_current_speed_unitmm",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_read_current_speed_unitmm(UInt16 axis,
			ref double current_speed);

		//��ȡ�����������λ�á���λ��mm��
		/// <summary>
		/// ��ȡ�����������λ�á���λ��mm��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="encoder_pos_by_mm">�����������λ�á���λ��mm��</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_get_encoder_unitmm",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_get_encoder_unitmm(UInt16 axis,
			ref double encoder_pos_by_mm);

		//�����������������ֵ����λ��mm��
		/// <summary>
		/// �����������������ֵ����λ��mm��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="encoder_pos_by_mm">�����������������ֵ����λ��mm��</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_set_encoder_unitmm",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern Int32 d2410_set_encoder_unitmm(UInt16 axis,
			double encoder_pos_by_mm);

		//����Բ������λ�ò岹����λ��mm��
		/// <summary>
		/// ����Բ������λ�ò岹����λ��mm��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="target_pos">����λ���б�ָ��, ��λ��mm</param>
		/// <param name="cen_pos">Բ�ľ���λ���б�ָ��, ��λ��mm</param>
		/// <param name="arc_dir">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_arc_move_unitmm",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_arc_move_unitmm(UInt16[] axis,
			double[] target_pos, double[] cen_pos, UInt16 arc_dir);

		//����Բ�����λ�ò岹����λ��mm��
		/// <summary>
		/// ����Բ�����λ�ò岹����λ��mm��
		/// </summary>
		/// <param name="axis">ָ�����</param>
		/// <param name="rel_pos">Ŀ�����λ���б�ָ��, ��λ��mm</param>
		/// <param name="rel_cen">Բ�����λ���б�ָ��, ��λ��mm</param>
		/// <param name="arc_dir">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <returns></returns>
		[DllImport("DMC2410.dll", EntryPoint = "d2410_rel_arc_move_unitmm",
			CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		private static extern UInt32 d2410_rel_arc_move_unitmm(UInt16[] axis,
			double[] rel_pos, double[] rel_cen, UInt16 arc_dir);

		#endregion

		#region "�����˶���˵��"

		//���࿨���С�
		//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
		//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
		//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

		//�����ź���ŵĶ�Ӧ��ϵΪ����
		//                       0�ſ���Ӧ0~3���᣻1�ſ���Ӧ4~7���᣻n�ſ���Ӧ4n~ 4*��n+1��-1���ᡣ

		//DMC2410C�˶����ƿ���4·��������źŽӿڡ������ź�PUL�ͷ����ź�DIR��Ϊ�������źš�Ҳ��������Ϊ��������źš�

		//DMC2410C�������������ָ�������źţ�
		//       һ��Ϊ����+����ģʽ��������ģʽ��
		//       һ��Ϊ������+������ģʽ��˫����ģʽ��

		//1�������������������źŵ�EA+��EA-��EB+��EB-��EZ+��EZ-�Ĳ���źŵ�ѹ��������3.5V��С��5V��
		//�����������ӦС��6mA�� 
		//2����Ҫ�������豸�ĵ��ߺͿ��ƿ���GND���ӡ�
		//3���������źŽӿھ������ŷ�����������¼1�еĲ���X2�����

		//DMC2410CΪÿ���ᶼ�ṩ��1��ԭ��λ�ô������źŵ�����˿�ORG

		//DMC2410CΪÿ�����ṩ��2����е��λ�ź�EL+ �� EL-��EL+Ϊ������λ�źţ�EL-Ϊ������λ�źš�
		//���˶�ƽ̨������λ����ʱ��EL+��EL-����Ч��DMC2410C����ֹ�˶�ƽ̨������ǰ�˶���
		//ע�⣺
		//1. �û������ʹ�õ���λ����������������λ���ص���Ч������ƽ��
		//��ʹ�ó�������λ����ʱ��Ӧͨ�����ѡ��EL+��EL-�ź�Ϊ�͵�ƽ��Ч��
		//��ʹ�ó�������λ����ʱ��Ӧѡ��EL+��EL-�ź�Ϊ�ߵ�ƽ��Ч��

		//DMC2410C�˶����ƿ��ź�RDY��ALM���ڼ���ŷ����״̬���ź�SEVON���������ŷ����״̬��

		//λ�������ź�����ӿ�
		//DMC2410C�˶����ƿ�ÿһ�ᶼ�ṩһ��λ�����������ź�LTC���ź�LTC1��LTC4���Էֱ�����4�����
		//��ǰ������λ�û�ָ��λ�ã�Ҳ����ͨ��������ã���LTC1��LTC2�ź�ͬʱ����4�����λ��.

		//ͨ�����������źŽӿ�
		//DMC2410C��Ϊ�û��ṩ�˶��32·ͨ�����������źţ�����4·��RDY�źŸ��ã�

		//ͨ����������źŽӿ�
		//DMC2410C��Ϊ�û��ṩ�˶��28·ͨ����������ӿڣ����а���4·��ר���źŽӿڸ��ã�����ULN2803оƬ������
		//�����������Ϊ50 mA��5��40Vdc�����룩�������ڿ��Ƽ̵�������ŷ����źŵƻ������豸�� 
		//OUT 1��OUT 16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�

		//���������У�DMC2410C�˶����ƿ��ϵ�4����ı�ź�Ӳ����Ų�һ�������Ǵ�0��ʼ������1��ʼ��

		//��ԭ�㲽��
		//�ڽ��о�ȷ���˶�����֮ǰ����Ҫ�趨�˶�����ϵ��ԭ�㡣�˶�ƽ̨�϶�����ԭ�㴫������Ҳ��Ϊԭ�㿪�أ���
		//Ѱ��ԭ�㿪�ص�λ�ò�����λ����Ϊƽ̨������ԭ�㣬��Ϊ��ԭ���˶���

		//DMC2410C���ƿ����ṩ��6�ֻ�ԭ�㷽ʽ:
		//���з�ʽ1~5�ǲ���ԭ���ƽ״̬�������źţ�
		//��ʽ6���ǲ���ԭ������ź��������źţ�

		//�����ԭ���˶���Ҫ�������£� 
		//1�����û��㷽ʽ1~5����ԭ���˶��� 
		//  1��ʹ��d2410_set_HOME_pin_logic��������ԭ�㿪�ص���Ч��ƽ��
		//  2��ʹ��d2410_config_home_mode�������û�ԭ�㷽ʽ�� 
		//  3�����û�ԭ���˶��������ٶ���ʽ�� 
		//  4��ʹ��d2410_home_move�������л�ԭ���˶��� 
		//  5���ص�ԭ���ָ��������������㡣

		//2�����û��㷽ʽ6����ԭ���˶��� 
		//  1��ʹ��d2410_set_homelatch_mode��������ԭ���ź����淽ʽ�� 
		//  2��ʹ��d2410_config_home_mode�������û�ԭ�㷽ʽ�� 
		//  3�����û�ԭ���˶��������ٶ���ʽ�� 
		//  4��ʹ��d2410_home_move�������л�ԭ���˶��� 
		//  5���ص�ԭ���ָ��������������㡣

		//��ԭ�㷽ʽ
		//DMC2410C�˶����ƿ��ṩ��6�ֻ�ԭ���˶��ķ�ʽ�� 

		//��ʽ1��һ�λ���
		//�÷�ʽ�Ե��ٻ�ԭ�㣻�ʺ����г̶̡���ȫ��Ҫ��ߵĳ��ϡ�
		//��������Ϊ������ӳ�ʼλ���Ժ㶨���ٶ���ԭ�㷽���˶���������ԭ�㿪��λ�ã�ԭ���źű�������
		//�������ֹͣ������0������ֹͣλ����Ϊԭ��λ�á�

		//��ʽ2��һ�λ���ӻ��� 
		//�÷�ʽ�Ƚ��з�ʽ1�˶�����ɺ��ٷ������ԭ�㿪�صı�Եλ�ã���ԭ���źŵ�һ����Ч��ʱ�򣬵������ֹͣ��
		//��ֹͣλ����Ϊԭ��λ�á�

		//��ʽ3�����λ��� 
		//�÷�ʽΪ��ʽ1�ͷ�ʽ2����ϡ��Ƚ��з�ʽ2�Ļ���ӷ��ң���ɺ��ٽ��з�ʽ1��һ�λ��㡣

		//��ʽ4��һ�λ�����ټ�1��EZ������л��� 
		//�÷�ʽ�ڻ�ԭ���˶������У����ҵ�ԭ���źź󣬻�Ҫ�ȴ������EZ�źų��֣���ʱ���ֹͣ��
		//����֮ǰ��Ҫ���EZ״̬����EZ�źŵ���ʱ���������ֹͣ��

		//��ʽ5��EZ�������� 
		//�÷�ʽ�ڻ�ԭ���˶������У���EZ �źż�������ָ����������ʱ���ֹͣ��

		//��ʽ6��ԭ�㲶�����
		//�÷�ʽ�ڻ�ԭ���˶������У���ԭ�㲶���ź���Чʱ���˶����ٵ�ֹͣ��Ȼ����ص�����λ�á�
		//������ԭ�㲶�����ģʽ��ʱ��ԭ���źŵĳ�ʼ״̬�Ի����˶�û��Ӱ�죬�û���ģʽ���õ��Ǳ��ش�����
		//ÿ�������û����˶���ʱ��ԭ�������־���Զ������ 
		//ע�⣺�ڻ��㷽ʽ6�У�ԭ������λ��Ϊָ������λ�á�

		//����                                ����
		//d2410_set_HOME_pin_logic         ����ԭ���źŵĵ�ƽ���˲���ʹ��
		//d2410_config_home_mode           ѡ���ԭ��ģʽ
		//d2410_home_move                  ��ָ���ķ�����ٶȷ�ʽ��ʼ��ԭ��
		//d2410_set_homelatch_mode         ����ԭ�����淽ʽ
		//d2410_set_position               ָ���������������

		//ע�⣺ִ����d2410_home_move������ָ����������������Զ����㣻
		//������������ڻ����˶���ɺ󣬵���d2410_set_position����������㡣

		//����7.1����ʽ1���ٻ�ԭ��
		//d2410_set_HOME_pin_logic 0,0,1           '����0����ԭ���źŵ͵�ƽ��Ч��ʹ���˲����� 
		//d2410_config_home_mode 0,0,0             '����0�������ģʽΪ��ʽ1 
		//d2410_set_profile 0,500,1000,0.1,0.1     '����0�������������ٶȣ��ӡ�����ʱ�� 
		//d2410_home_move 0,2,0                    '����0����Ϊ�������ԭ�㣬�ٶȷ�ʽΪ���ٻ�ԭ�� 
		//While (d2410_check_done(0) = 0)          '����˶�״̬���ȴ���ԭ�㶯����� 
		//DoEvents 
		//Wend 
		//D2410_set_position 0,0                   '����0�����ָ���������������λ��Ϊ0

		//����7.2����ʽ6���ٻ�ԭ��
		//d2410_set_homelatch_mode 0,2,0           '����0����ԭ�����淽ʽΪ�½������� 
		//d2410_config_home_mode 0,5,0             '����0�������ģʽΪ��ʽ6 
		//d2410_set_profile 0,500,1000,0.1,0.1     '����0�������������ٶȣ��ӡ�����ʱ�� 
		//d2410_home_move 0,2,0                    '����0����Ϊ�������ԭ�㣬�ٶȷ�ʽΪ���ٻ�ԭ�� 
		//While (d2410_check_done(0) = 0)          '����˶�״̬���ȴ���ԭ�㶯����� 
		//DoEvents 
		//Wend 
		//D2410_set_position 0,0                   '����0�����ָ���������������λ��Ϊ0

		//MC2410C�˶����ƿ��������˶��켣ʱ�����þ�������Ҳ������������ꡣ
		//����ģʽ�����ŵ㣬
		//�磺�ھ�������ģʽ����һϵ������㶨��һ�����ߣ����Ҫ�޸��м�ĳ������ʱ������Ӱ�����������ꣻ
		//���������ģʽ�У���һϵ������㶨��һ�����ߣ���ѭ����������ظ��������߹켣��Ρ�

		//��DMC2410C�������о����λ�õĵ�λΪ���壻�ٶȵ�λΪ����/�룻ʱ�䵥λΪ�롣
		//�������λ�ÿ�����ָ�ӵ�ǰλ���˶�����һ��λ�ã�һ���Ϊ��λ�˶��򶨳��˶��� 
		//DMC2410C����ִ�е������ʱ����ʹ������������ٶ����߻�S���ٶ����߽��е�λ�˶��������˶���

		//�����ٶ������µĵ�λ�˶�
		//d2410_set_profile              �趨�����ٶ����ߵ���ʼ�ٶȡ�����ٶȡ�����ʱ�䡢����ʱ��
		//d2410_set_profile_Extern       �趨�����ٶ����ߵ���ʼ�ٶȡ�����ٶȡ�ֹͣ�ٶȡ�����ʱ�䡢����ʱ��
		//d2410_t_pmove                  ��ָ�����ԶԳ������ٶ���������λ�˶�
		//d2410_ex_t_pmove               ��ָ�����ԷǶԳ������ٶ���������λ�˶�

		//ע�����Գ������ٶ����ߡ���ָ����ٶȺͼ��ٶ���ԣ������ٹ��̺ͼ��ٹ��̵�����б�ʶԳơ�

		//����7.3��ִ���ԷǶԳ������ٶ���������λ�˶� 
		//d2410_set_profile 0,500,6000,0.02,0.01     '����0������ʼ�ٶ�Ϊ500����/�� 
		//'�����ٶ�Ϊ6000����/�롢����ʱ��Ϊ0.02�롢
		//'����ʱ��Ϊ0.01�롣 
		//d2410_ex_t_pmove 0,50000,0                 '����0���ᡢ��

		//**************************
		//�ڵ������й����У�����ٶ�Max_Vel��Ŀ��λ��Dist������ʵʱ�ı�
		//**************************

		//�����ٶ��¸ı��ٶȡ��յ����غ���˵��
		//d2410_change_speed                  '���������иı䵱ǰ����ٶ�
		//d2410_reset_target_position         '�ı�Ŀ��λ��

		//����7.4���ı��ٶȡ��ı��յ�λ��
		//d2410_set_profile 0,500,6000,0.01,0.02     '�������������ٶȡ��ӡ�����ʱ��*/ 
		//d2410_ex_t_pmove 0,50000,0                 '������š��˶�����50000���������ģʽ 
		//If(���ı��ٶ�������)                       '����ı��ٶ��������㣬��ִ�иı��ٶ����� 
		//Curr_Vel= 9000                             '�����µ��ٶ� 
		//d2410_change_speed 0,Curr_Vel              'ִ�иı��ٶ�ָ�� 
		//End If 
		//If(���ı��յ�λ��������)                   '����ı��յ�λ���������㣬��ִ�иı��յ�λ������ 
		//d2410_reset_target_position 0,55000        '�ı��յ�λ��Ϊ55000 
		//End If 

		//������˶��е�����ٶ����õ�С����ʼ�ٶȣ������˶������н���������ٶ��������˶��� 
		//����˶�����̣ܶ�������С�ڻ����(Max_Vel+Min_Vel)��Taccʱ���������ٶ����߽���Ϊ�����Σ�
		//��DMC2410C�˶����ƿ����Զ��������ܣ��������εļ����ȥ���Ա����ٶȱ仯̫�����������

		//S���ٶ������˶�ģʽ
		//d2410_set_st_profile                '����S��ʱ�䣬��ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		//d2410_set_st_profile_Extern         '����S��ʱ�䣬��ֹͣ�ٶ�
		//d2410_s_pmove                       '��ָ�����ԶԳ�S���ٶ���������λ�˶�
		//d2410_ex_s_pmove                    '��ָ�����ԷǶԳ�S���ٶ���������λ�˶�

		//��S���ٶ������µĵ�λ�˶������У�Ҳ���Ե���d2410_change_speed��d2410_reset_target_position����
		//ʵʱ�ı������ٶȺ�Ŀ��λ�á�������岹��������²���ʵʱ�ı������ٶȺ�Ŀ��λ�á�

		//�����˶�ģʽ
		//�����˶�ģʽ�У�DMC2410C���ƿ����Կ��Ƶ�������λ�S���ٶ�������ָ���ļ���ʱ���ڴ���ʼ�ٶȼ���������ٶȣ�
		//Ȼ���Ը��ٶ��������У�ֱ������ָֹͣ����߸���������λ�źŲŻᰴ����ʱ���ٶ����߼���ֹͣ��

		//�����˶���غ���˵��
		//d2410_t_vmove      '��ָ�����������ٶ����߼��ٵ�����ٶȺ���������
		//d2410_s_vmove      '��ָ������S���ٶ����߼��ٵ�����ٶȺ���������
		//d2410_decel_stop   'ָ�������ֹͣ�����ô˺������������٣�������ʼ�ٶȺ�ֹͣ

		//�ڵ���ִ�������˶������У����Ե���d2410_change_speed ʵʱ�ı��ٶȡ�
		//ע�⣺����S���ٶ����������˶�ʱ���ı�����ٶ�����ڼ��ٹ����Ѿ���ɵĺ��ٶν��С�

		//����7.5����S���ٶ����߼��ٵ������˶������١�ֹͣ����
		//d2410_set_st_profile 0,100, 1000,0.1,0.1,0.01,0      '����S������S��ʱ�� 
		//d2410_s_vmove 0,1                                    '0���������˶�������Ϊ�� 
		//if(���ı��ٶ�������)                                 '����ı��ٶ��������㣬��ִ�иı��ٶ����� 
		//Curr_Vel= 1200                                       '�����µ��ٶ� 
		//d2410_change_speed 0,Curr_Vel                        'ִ�иı��ٶ�ָ�� 
		//End If 
		//if(��ֹͣ������)                                     '����˶�ֹͣ�������㣬��ִ�м���ֹͣ���� 
		//d2410_decel_stop 0,0.1                               '����ֹͣ������ʱ��Ϊ0.1��
		//End If

		//�����˶���ʵ��

		//*************************
		//��������
		//������ͬʱ�˶�����Ϊ����������
		//DMC2410C�˶����ƿ����ſ����Կ���4�����Զ��ַ�ʽ�˶������õ��У�����������ֱ�߲岹��Բ���岹��
		//DMC2410C���ƿ����Կ��ƶ�����ͬʱִ��d2410_t_move��d2410_s_move���൥���˶�������
		//��νͬʱִ�У����ڳ�����˳�����d2410_t_move��d2410_s_move�Ⱥ�������Ϊ����ִ���ٶȺܿ죬
		//��˲�伸���������ʼ�˶������˵ĸо�����ͬʱ��ʼ�˶��� 
		//���������ڸ����ٶ����ò���ʱ������ֹͣʱ�䲻ͬ����������յ�֮���˶��Ĺ켣Ҳ����ֱ��
		//*************************

		//ֱ�߲岹�˶�
		//DMC2410C�����Խ�������2�ᡢ3���4��ֱ�߲岹���岹�����ɿ��ƿ���Ӳ��ִ�У�
		//�û�ֻ�轫�岹�˶����ٶȡ����ٶȡ��յ�λ�õȲ���д����غ������������岹�����еļ��㹤����

		//ֱ�߲岹�˶���غ���˵��
		//d2410_t_line2                  '��ָ�����������ԳƵ����μӼ��ٲ岹�˶�
		//d2410_t_line3                  '��ָ�����������ԳƵ����μӼ��ٲ岹�˶�
		//d2410_t_line4                  'ָ�������ԶԳƵ������ٶ��������岹�˶�
		//d2410_set_vector_profile       '�趨�岹ʸ���˶����ߵ�����ٶȡ�����ʱ�䡢����ʱ��

		//����7.6��XY��ֱ�߲岹 
		//Dim AxisArray(2) as Integer AxisArray(0)=0     '����岹0��ΪX�� 
		//AxisArray(1)=1                                 '����岹1��ΪY�� 
		//d2410_set_vector_profile 0,5000,0.1,0.2 
		//d2410_t_line2 AxisArray(0),30000,AxisArray(1),40000,0
		//������ʹX��Y��������ģʽֱ�߲岹�˶���
		//����ز���Ϊ�� 
		//��X = 30000 pulse 
		//��Y = 40000 pulse 
		//���ʸ���ٶ� = 5000 p/s ��0��,1����ٶ�Ϊ3000��4000 p/s�� 
		//���μ���ʱ�� = 0.1 s 
		//���μ���ʱ�� = 0.2 s

		//Բ���岹�˶�
		//DMC2410C������������֮����Խ���Բ���岹��Բ���岹��Ϊ���λ��Բ���岹�;���λ��Բ���岹��
		//�˶��ķ����Ϊ˳ʱ�루CW������ʱ�루CCW����

		//Բ���岹��غ���˵��
		//d2410_arc_move             '��ָ���Ķ���������λ��Բ���岹�˶���
		//d2410_rel_arc_move         '��ָ���Ķ��������λ��Բ���岹�˶���

		//����7.7��XY��Բ���岹 
		//Dim AxisArray(2) As Integer
		//Dim Pos(2), Cen(2) As Long
		//AxisArray(0)=0                                  '����0��Ϊ�岹X��
		//AxisArray(1)=1                                  '����1��Ϊ�岹Y�� 
		//Pos(0) = 5000 Pos(1) = -5000                    '�����յ����� 
		//Cen(0) = 5000 Cen(1) = 0                        '����Բ������ 
		//'d2410_set_vector_profile 1000,3000,0.1,0.2      '����ʸ���ٶ����� 
		//d2410_arc_move AxisArray(0), Pos(0), Cen(0), 0  'XY�����˳ʱ�뷽�����Բ���岹�˶��� 
		//'�յ㣨5000, -5000����Բ�ģ�5000, 0��


		//ͨ��IO��غ���˵��
		//d2410_read_inbit           '��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		//d2410_write_outbit         '��ָ�����ƿ���ĳһλ�������λ
		//d2410_read_outbit          'ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		//d2410_read_inport          '��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		//d2410_read_outport         '��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		//d2410_write_outport        'ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬

		//ע�⣺��ʹ��d2410_write_outport���˶����ƿ���ȫ������ڽ�����λ��
		//ʹ��d2410_read_inport��d2410_read_outport����IO��ƽ��ȡ��ʾʱ��
		//Ӧ��ʹ��ʮ�����������и�ֵ����������ʹ��ʮ���������ر����ڲ�֧���޷��ű����Ŀ��������£���
		//�ڶ�IO��ƽ���п������ȡʱ��ʹ��ʮ����������ֵԶ��ʹ��ʮ��������ֵ����ֱ�ۡ����㡣

		//����7.8����ȡ��0�ſ���ͨ�������1�ĵ�ƽֵ������ͨ�������3�øߵ�ƽ
		//Dim MyCardNo, MyInbitno, MyInValue, MyOutbitno, MyOutValue As Integer
		//MyCardNo = 0                                         '���� 
		//MyInbitno = 1                                        '����ͨ�������1 
		//MyInValue = d2410_read_inbit (MyCardNo, MyInbitno)   '��ȡͨ�������1�ĵ�ƽֵ������ֵ������MyInValue 
		//MyOutbitno = 3                                       '����ͨ�������3 
		//MyOutValue = 1                                       '���������ƽΪ�� 
		//d2410_write_outbit MyCardNo, MyOutbitno, MyOutValue  '��ͨ�������3�øߵ�ƽ

		//��7.9����ȡȫ������IO�ڵĵ�ƽֵ��������ʾ����ȫ�����IO�ڵĵ�ƽ���г�ʼ��
		//Dim MyCardNo As Integer
		//Dim MyInportValue, MyOutportValue As Long
		//Dim MyInportValueTemp As String
		//MyCardNo = 0                                        '���� 
		//MyInportValue = d2410_read_inport (MyCardNo)        '��ȡ��������IO�ڵ�ƽֵ������ֵ������MyInportValue 
		//MyInportValueTemp = Hex(MyInportValue)              'ת����ʮ������ 
		//MyInTextShow = MyInportValueTemp                    '��ʾ���ı���MyInTextShow�� 
		//MyOutportValue = &HFFFFFBFA                         '&H��ʾʮ�����ƣ�VB������������ڵ�ƽֵ�������1��3��11Ϊ�͵�ƽ������˿�Ϊ�ߵ�ƽ 
		//d2410_write_outport MyCardNo, MyOutportValue        '��ȫ������ڽ��е�ƽ��ֵ

		//����������ʵ��
		//DMC2410C�ķ���λ�ü�������һ��32λ��������������ͨ�����ƿ��������ӿ�EA��
		//EB��������壨�����������դ�߷�������ȣ����м�����

		//�����������غ���˵��
		//d2410_counter_config           '���ñ���������ڵļ�����ʽ
		//d2410_get_encoder              '��ȡ�������������������ֵ
		//d2410_set_encoder              '���ñ��������������ֵ

		//����7.10�����������������Ĳ���
		//d2410_counter_config 0,3            '������0Ϊ4��������Ĭ�ϵ�EA��EB�������� 
		//d2410_set_encoder 0,0               '������0�ļ�����ʼֵΪ0 
		//X_Position = d2410_get_encoder(0)   '����0�ļ���������ֵ������X_Position

		//λ�ñȽϹ��ܵ�ʵ��
		//DMC2410C�˶����ƿ��ṩ��λ�ñȽϹ��ܣ�λ�ñȽϵ�һ�㲽���ǣ� 
		//   1�����ñȽ����� 
		//   2�����λ�ñȽ����ݣ�
		//   3����ӱȽ�λ�õ㣻
		//   4����ʼ�˶����鿴�Ƚ�״̬��

		//����λ�ñȽϹ���
		//DMC2410C���ṩ���������λ�ñȽϣ�ÿ����඼�������8���Ƚϵ㡣����λ�ñȽϵĴ�����ʱʱ��С��1ms��

		//����λ�ñȽ���غ���˵��
		//d2410_compare_config_Extern               '���ñȽ�������
		//d2410_compare_clear_points_Extern         '������бȽϵ�
		//d2410_compare_add_point_Extern            '��ӱȽϵ�
		//d2410_compare_get_current_point_Extern    '��ȡ��ǰ�Ƚϵ�λ��
		//d2410_compare_get_points_runned_Extern    '��ѯ�Ѿ��ȽϹ��ĵ����
		//d2410_compare_get_points_remained_Extern  '��ѯ���Լ���ıȽϵ�����

		//ע�⣺1������λ�ñȽϹ�������Ƚ϶��У�ÿ����е�λ�ñȽ϶��Ƕ������еģ� 
		//      2��ִ��λ�ñȽ�ʱ��ÿ���Ƚϵ�Ĵ����ǰ�����ӵıȽϵ�˳��ִ�еģ�
		//         �������һ���Ƚϵ�û�б������Ƚ϶�������ô����ıȽϵ��ǲ��������õġ�

		//��7.11������λ�ñȽ� 
		//Dim MyCardNo, Myqueue, Myenable, Myaxis, Mycmp_source As Integer
		//Dim Mydir, Myaction As Integer
		//Dim Mypos, Myactpara As Long
		//MyCardNo = 0             '���� 
		//Myqueue = 0              '���ñȽ����к�Ϊ0 
		//Myaxis = 0               '���Ϊ0 
		//Myenable = 1             '���ñȽ���ʹ�� 
		//Mycmp_source = 0         '���ñȽ�ԴΪָ��λ�� 
		//d2410_compare_config_Extern MyCardNo,Myqueue, Myenable, Myaxis,Mycmp_source '���ñȽ��� 
		//d2410_compare_clear_points_Extern MyCardNo,Myqueue                          '����Ƚϵ� 
		//Mypos = 8000                 '���ñȽ�λ��Ϊ8000pulse 
		//Mydir = 1                    '���ñȽϷ���Ϊ���ڵ��� 
		//Myaction = 3                 '��������ΪIO��ƽȡ�� 
		//Myactpara = 1                '�������IO�˿�1�������� 
		//d2410_set_position MyAxis, 0 '��ǰλ����Ϊ��� 
		//d2410_compare_add_point_Extern MyCardNo,Myqueue,Mypos,Mydir,Myaction,Myactpara '��ӱȽϵ� 
		//d2410_ex_t_pmove Myaxis,10000,0     'ִ�ж����˶���λ��Ϊ10000pulse���������ģʽ

		//����λ�ñȽϹ���
		//DMC2410C���ƿ�Ϊÿ�����ṩ��һ������λ�ñȽϡ�����λ�ñȽϻ����޴�����ʱʱ��
		//��������ʱ����ָ�������ʱ�䣩��

		//����λ�ñȽ���غ���˵��
		//d2410_config_CMP_PIN           '���ø���λ�ñȽ���
		//d2410_read_CMP_PIN             '��ȡ����λ�ñȽ������״̬

		//ע�⣺ÿ���λ�ñȽ϶��Ƕ������еģ�����λ�ñȽ���ʱֻ֧�ַ���λ�ñȽϡ�

		//��7.12������λ�ñȽ� 
		//Dim Myaxis, Mycmp_enable, MyCMP_logic As Integer
		//Dim Mycmp_pos As Long
		//Myaxis = 0                         '��� 
		//Mycmp_enable = 1                   'CMPʹ�� 
		//Mycmp_pos = 8000                   'CMP�Ƚ�λ��Ϊ8000pulse 
		//MyCMP_logic = 0                    'CMP����͵�ƽ�������ź� 
		//d2410_config_CMP_PIN Myaxis, Mycmp_enable, Mycmp_pos, MyCMP_logic      '���ñȽ�����0���ᣬ�Ƚ�λ��Ϊ8000pulse��
		//'����ʱ����ΪCMP����͵�ƽ�������ź� 
		//d2410_ex_t_pmove Myaxis,10000,1       'ִ�ж����˶���λ��Ϊ10000pulse����������ģʽ

		//λ�����湦�ܵ�ʵ��
		//DMC2410C���ṩ�˸���λ�����湦�ܣ�λ�������޴�����ʱʱ�䣬������λ�������źź��������浱ǰλ�á�

		//����������غ���˵��
		//d2410_config_latch_mode    '�������淽ʽΪ���������������ͬʱ����
		//d2410_get_latch_value      '��ȡ��������������ֵ
		//d2410_get_latch_flag       '��ȡָ�����ƿ����������ı�־λ
		//d2410_reset_latch_flag     '��λָ�����ƿ����������ı�־λ
		//d2410_triger_chunnel       'ѡ��ȫ������ʱ���ⴥ���ź�ͨ��

		//ע�⣺1����λ�������У���δ������������ֻ�����һ�δ���λ�ã�ֻ�е��ú����������״̬�����ٴ����棻 
		//      2��λ��������ʱֻ֧�ַ���λ�����档

		//��7.13��λ������ 
		//Dim MyCardNo, Myaxis, Myall_enable As Integer
		//Dim Mylatch_value As Long
		//MyCardNo = 0                                        '���� 
		//Myaxis = 0                                          '��� 
		//Myall_enable = 0                                    '�������淽ʽΪ�������� 
		//d2410_config_latch_mode MyCardNo,Myall_enable       '�������淽ʽ 
		//d2410_reset_latch_flag MyCardNo                     '��λ��������־λ 
		//d2410_ex_t_pmove Myaxis,10000,0                     'ִ�ж����˶���λ��Ϊ10000pulse���������ģʽ 
		//While ((d2410_get_latch_flag(MyCardNo) And (2 ^ (Myaxis + 8))) = 0) '�ж��趨���LTC����״̬ 
		//DoEvents 
		//Wend 
		//Mylatch_value= d2410_get_latch_value(Myaxis)         '��ȡ��������ֵ������ֵ������My_latch_Value

		//�����˶����ܵ�ʵ��
		//DMC2410C�˶����ƿ�֧�ֵ��������˶����ܡ��ù��������û�����һ������ͨ����Ӧһ���˶�������˶���

		//�����˶�������غ���˵��
		//d2410_set_handwheel_inmode       '�����������������źŵļ�����ʽ
		//d2410_handwheel_move             '����ָ��������������˶�

		//ע �⣺�����������˶���ֻ�з���d2410_decel_stop��d2410_imd_stop�����Ż��˳�����ģʽ
		//��7.14�������˶� 
		//Dim Myaxis, Myinmode As Integer
		//Dim Mymulti As Double
		//Myaxis = 0                                             '�����˶���Ϊ0���� 
		//Myinmode = 0                                           '�����������뷽ʽΪAB�� 
		//Mymulti = 10                                           '�����������뱶��Ϊ10 
		//d2410_set_handwheel_inmode Myaxis,Myinmode, Mymulti    '���������˶� 
		//d2410_handwheel_move Myaxis                            '���������˶� 
		//d2410_imd_stop Myaxis                                  '����ֹͣ�����˶�

		#endregion

		#region "��������"

		Microsoft.VisualBasic.Devices.Computer PC = new Microsoft.VisualBasic.Devices.Computer();

		/// <summary>
		/// ���ÿ�����
		/// </summary>
		Int32 AvailableCardQty = 0;

		/// <summary>
		/// Ŀ�����
		/// </summary>
		ushort TargetAxis = 0;

		/// <summary>
		/// Ŀ�꿨��
		/// </summary>
		ushort TargetCard = 0;

		bool SuccessBuiltNew = false, PasswordIsCorrect = false;

		/// <summary>
		/// ����ִ�еķ���ֵ��������
		/// </summary>
		bool TempStatus = false;

		Int32 TempErrorCode = 0;

		string ErrorMessage = "";

		/// <summary>
		/// ��ǰ�������
		/// </summary>
		public Int32 ErrorCode
		{
			get { return TempErrorCode; }
		}

		/// <summary>
		/// �����˶���������Ϣö��
		/// </summary>
		public enum ErrorMsg
		{

			/// <summary>
			/// �ɹ�
			/// </summary>
			Err_NoErr,

			/// <summary>
			/// δ֪����
			/// </summary>
			Err_Unknown,

			/// <summary>
			/// ��������
			/// </summary>
			Err_ParaErr,

			/// <summary>
			/// ��ʱ
			/// </summary>
			Err_Timeout,

			/// <summary>
			/// �����˶���/������æ
			/// </summary>
			Err_ControllerBusy,

			/// <summary>
			/// �˶�/�������
			/// </summary>
			Motion_Err_HandleErr,

			/// <summary>
			/// ���ʹ���
			/// </summary>
			Err_SendErr,

			/// <summary>
			/// �̼���Ч����
			/// </summary>
			Err_FirewareInvalidPara,

			/// <summary>
			/// �˶�����֧�ֹ̼�
			/// </summary>
			Err_FirewareCardNotSupport

			//��������˵�������ҵ���
			//Motion_ERR_CONNECT_TOOMANY = 5,                    //�忨������

			//Motion_ERR_CONTILINE = 6,                        //�����岹����
			//Motion_ERR_NoThisFunction = 7,                    //�ݲ�֧�ָù���
			//Motion_ERR_CANNOT_CONNECTETH = 8,                //��������
			//Motion_ERR_HANDLEERR = 9,                        //����Դδ���ҵ�
			//Motion_ERR_SENDERR = 10,                        //pciͨ�Ŵ���
			//Motion_ERR_FIRMWAREERR = 12,                    //�̼��ļ�����
			//Motion_ERR_FIRMWAR_MISMATCH = 14,                //�̼���ƥ��

			//Motion_ERR_FIRMWARE_INVALID_PARA    = 20,        //�̼���������
			//Motion_ERR_FIRMWARE_PARA_ERR    = 20,            //�̼���������2
			//Motion_ERR_FIRMWARE_STATE_ERR    = 22,            //�̼���ǰ״̬���������
			//Motion_ERR_FIRMWARE_LIB_STATE_ERR    = 22,        //�̼���ǰ״̬���������2
			//Motion_ERR_FIRMWARE_CARD_NOT_SUPPORT    = 24,   //�̼���֧�ֵĹ��� ��������֧�ֵĹ���
			//Motion_ERR_FIRMWARE_LIB_NOTSUPPORT    = 24,     //�̼���֧�ֵĹ���2

		}

		/// <summary>
		/// ִ�л�ԭ���˶�ԭ������ʹ��״̬��0����ֹ��2������
		/// </summary>
		ushort SearchingHomeEnableLatch = 2;

		/// <summary>
		/// ִ�л�ԭ���˶�ԭ�����淽ʽ��0���½������棬1������������
		/// </summary>
		ushort SearchingHomeLatchLogic = 0;

		/// <summary>
		/// ��ԭ���˶��У�ԭ���źŵ���Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч
		/// </summary>
		ushort SearchingHomeOrgLogic = 1;

		/// <summary>
		/// ��ԭ���˶��У�����/��ֹ�˲����ܣ�0����ֹ��1������
		/// </summary>
		ushort SearchingHomeEnableFilter = 0;

		/// <summary>
		/// EZ�źų���EZCountָ���Ĵ��������˶�ֹͣ��
		/// ����Mode=5ʱ�ò���������Ч��ȡֵ��Χ��1��16
		/// </summary>
		ushort SearchingHomeEZCount = 0;

		/// <summary>
		/// ��ԭ���˶���ʼ�ٶȣ���λ��pulse/s
		/// </summary>
		double SearchingHomeMinVelocity = 0;

		/// <summary>
		/// ��ԭ���˶�����ٶȣ���λ��pulse/s
		/// </summary>
		double SearchingHomeMaxVelocity = 0;

		/// <summary>
		/// ��ԭ���˶��ܼ���ʱ�䣬��λ��s
		/// </summary>
		double SearchingHomeAccTime = 0.0;

		/// <summary>
		/// ��ԭ���˶��ܼ���ʱ�䣬��λ��s
		/// </summary>
		double SearchingHomeDecTime = 0.0;

		/// <summary>
		/// ��ԭ�㷽ʽ��1���������ԭ�㣬2���������ԭ��
		/// </summary>
		ushort SearchingHomeDirection = 0;

		/// <summary>
		/// ��ԭ���ٶȣ�0�����ٻ�ԭ�㣬1�����ٻ�ԭ��
		/// </summary>
		ushort SearchingHomeVelocityMode = 0;

		/// <summary>
		/// ִ�л�ԭ���б�־
		/// </summary>
		bool DoingSearchHome = false;

		/// <summary>
		/// ��ԭ��ģʽ��1~6��
		/// </summary>
		ushort SearchingHomeMode = 0;

		/// <summary>
		/// ִ�л�ԭ����߳�
		/// </summary>
		private Thread SearchHomeThread;

		/// <summary>
		/// ���������Ϣ
		/// </summary>
		public string Author
		{
			get { return "������ߣ����ϣ���ϵ��ʽ��southeastofstar@163.com"; }
		}

		/// <summary>
		/// ���Ƿ��Ѿ���ԭ��
		/// </summary>
		public bool AtHome
		{
			get
			{
				AxisSignal AxisStatus = GetAxisSignalStatus();
				if (AxisStatus.HomeSignal == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// ���ŷ�����������λ������λ��ԭ���ź����ݽṹ
		/// </summary>
		public struct AxisSignal
		{
			/// <summary>
			/// �ŷ������ź�״̬
			/// </summary>
			public bool ServoAlarm;

			/// <summary>
			/// ����λ�ź�״̬
			/// </summary>
			public bool PositiveLimit;

			/// <summary>
			/// ����λ�ź�״̬
			/// </summary>
			public bool NegotiveLimit;

			/// <summary>
			/// ԭ���ź�״̬
			/// </summary>
			public bool HomeSignal;
		}

		/// <summary>
		/// �����ֹͣ�źţ�EMG���������ź�(EZ)��+DR(PA)�źš�-DR(PB)�ź����ݽṹ
		/// </summary>
		public struct AxisOutsideSignal
		{
			/// <summary>
			/// ����ֹͣ�ź�(EMG)
			/// </summary>
			public bool EStop;

			/// <summary>
			/// �����ź�(EZ)
			/// </summary>
			public bool EZIndexSignal;

			/// <summary>
			/// +DR(PA)�ź�
			/// </summary>
			public bool PositiveDR_PA;

			/// <summary>
			/// -DR(PB)�ź�
			/// </summary>
			public bool NegativeDR_PB;
		}

		/// <summary>
		/// ���ƿ��������ı�־λ���ݽṹ
		/// </summary>
		public struct LatchFlag
		{
			/// <summary>
			/// ָ������0���д����ź�
			/// </summary>
			public bool Bit0;

			/// <summary>
			/// ָ������1���д����ź�
			/// </summary>
			public bool Bit1;

			/// <summary>
			/// ָ������2���д����ź�
			/// </summary>
			public bool Bit2;

			/// <summary>
			/// 3���д����ź�
			/// </summary>
			public bool Bit3;

			/// <summary>
			/// ָ������0���������ź�
			/// </summary>
			public bool Bit4;

			/// <summary>
			/// ָ������1���������ź�
			/// </summary>
			public bool Bit5;

			/// <summary>
			/// ָ������2���������ź�
			/// </summary>
			public bool Bit6;

			/// <summary>
			/// ָ������3���������ź�
			/// </summary>
			public bool Bit7;

			/// <summary>
			/// ָ������0��λ��������
			/// </summary>
			public bool Bit8;

			/// <summary>
			/// ָ������1��λ��������
			/// </summary>
			public bool Bit9;

			/// <summary>
			/// ָ������2��λ��������
			/// </summary>
			public bool Bit10;

			/// <summary>
			/// ָ������3��λ��������
			/// </summary>
			public bool Bit11;

			/// <summary>
			/// ָ������0��λ��������
			/// </summary>
			public bool Bit12;

			/// <summary>
			/// ָ������1��λ��������
			/// </summary>
			public bool Bit13;

			/// <summary>
			/// ָ������2��λ��������
			/// </summary>
			public bool Bit14;

			/// <summary>
			/// ָ������3��λ��������
			/// </summary>
			public bool Bit15;
		}

		/// <summary>
		/// ���ƿ��ļ������ı�ʶλ���ݽṹ
		/// </summary>
		public struct CounterFlag
		{

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ0
			/// </summary>
			public bool Bit0;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ1
			/// </summary>
			public bool Bit1;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ2
			/// </summary>
			public bool Bit2;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ3
			/// </summary>
			public bool Bit3;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ8
			/// </summary>
			public bool Bit8;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ9
			/// </summary>
			public bool Bit9;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ10
			/// </summary>
			public bool Bit10;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ11
			/// </summary>
			public bool Bit11;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ16
			/// </summary>
			public bool Bit16;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ17
			/// </summary>
			public bool Bit17;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ18
			/// </summary>
			public bool Bit18;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ19
			/// </summary>
			public bool Bit19;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ24
			/// </summary>
			public bool Bit24;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ25
			/// </summary>
			public bool Bit25;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ26
			/// </summary>
			public bool Bit26;

			/// <summary>
			/// ���ƿ��ļ������ı�ʶλ27
			/// </summary>
			public bool Bit27;

		}

		/// <summary>
		/// ���ƿ�ȫ��ͨ������źŵ����ݽṹ
		/// ��Bit0~Bit19��Bit24~Bit31λֵ�ֱ�����1~20��25~32������˿�ֵ��
		/// </summary>
		public struct OutputSignal
		{

			/// <summary>
			/// ͨ�����λ0
			/// </summary>
			public bool Bit0;

			/// <summary>
			/// ͨ�����λ1
			/// </summary>
			public bool Bit1;

			/// <summary>
			/// ͨ�����λ2
			/// </summary>
			public bool Bit2;

			/// <summary>
			/// ͨ�����λ3
			/// </summary>
			public bool Bit3;

			/// <summary>
			/// ͨ�����λ4
			/// </summary>
			public bool Bit4;

			/// <summary>
			/// ͨ�����λ5
			/// </summary>
			public bool Bit5;

			/// <summary>
			/// ͨ�����λ6
			/// </summary>
			public bool Bit6;

			/// <summary>
			/// ͨ�����λ7
			/// </summary>
			public bool Bit7;

			/// <summary>
			/// ͨ�����λ8
			/// </summary>
			public bool Bit8;

			/// <summary>
			/// ͨ�����λ9
			/// </summary>
			public bool Bit9;

			/// <summary>
			/// ͨ�����λ10
			/// </summary>
			public bool Bit10;

			/// <summary>
			/// ͨ�����λ11
			/// </summary>
			public bool Bit11;

			/// <summary>
			/// ͨ�����λ12
			/// </summary>
			public bool Bit12;

			/// <summary>
			/// ͨ�����λ13
			/// </summary>
			public bool Bit13;

			/// <summary>
			/// ͨ�����λ14
			/// </summary>
			public bool Bit14;

			/// <summary>
			/// ͨ�����λ15
			/// </summary>
			public bool Bit15;

			/// <summary>
			/// ͨ�����λ16
			/// </summary>
			public bool Bit16;

			/// <summary>
			/// ͨ�����λ17
			/// </summary>
			public bool Bit17;

			/// <summary>
			/// ͨ�����λ18
			/// </summary>
			public bool Bit18;

			/// <summary>
			/// ͨ�����λ19
			/// </summary>
			public bool Bit19;

			/// <summary>
			/// ͨ�����λ24
			/// </summary>
			public bool Bit24;

			/// <summary>
			/// ͨ�����λ25
			/// </summary>
			public bool Bit25;

			/// <summary>
			/// ͨ�����λ26
			/// </summary>
			public bool Bit26;

			/// <summary>
			/// ͨ�����λ27
			/// </summary>
			public bool Bit27;

			/// <summary>
			/// ͨ�����λ28
			/// </summary>
			public bool Bit28;

			/// <summary>
			/// ͨ�����λ29
			/// </summary>
			public bool Bit29;

			/// <summary>
			/// ͨ�����λ30
			/// </summary>
			public bool Bit30;

			/// <summary>
			/// ͨ�����λ31
			/// </summary>
			public bool Bit31;

		}

		/// <summary>
		/// ���ƿ�ȫ�������źŵ����ݽṹ��0~31λ��
		/// </summary>
		public struct InputSignal
		{

			/// <summary>
			/// ͨ������λ0
			/// </summary>
			public bool Bit0;

			/// <summary>
			/// ͨ������λ1
			/// </summary>
			public bool Bit1;

			/// <summary>
			/// ͨ������λ2
			/// </summary>
			public bool Bit2;

			/// <summary>
			/// ͨ������λ3
			/// </summary>
			public bool Bit3;

			/// <summary>
			/// ͨ������λ4
			/// </summary>
			public bool Bit4;

			/// <summary>
			/// ͨ������λ5
			/// </summary>
			public bool Bit5;

			/// <summary>
			/// ͨ������λ6
			/// </summary>
			public bool Bit6;

			/// <summary>
			/// ͨ������λ7
			/// </summary>
			public bool Bit7;

			/// <summary>
			/// ͨ������λ8
			/// </summary>
			public bool Bit8;

			/// <summary>
			/// ͨ������λ9
			/// </summary>
			public bool Bit9;

			/// <summary>
			/// ͨ������λ10
			/// </summary>
			public bool Bit10;

			/// <summary>
			/// ͨ������λ11
			/// </summary>
			public bool Bit11;

			/// <summary>
			/// ͨ������λ12
			/// </summary>
			public bool Bit12;

			/// <summary>
			/// ͨ������λ13
			/// </summary>
			public bool Bit13;

			/// <summary>
			/// ͨ������λ14
			/// </summary>
			public bool Bit14;

			/// <summary>
			/// ͨ������λ15
			/// </summary>
			public bool Bit15;

			/// <summary>
			/// ͨ������λ16
			/// </summary>
			public bool Bit16;

			/// <summary>
			/// ͨ������λ17
			/// </summary>
			public bool Bit17;

			/// <summary>
			/// ͨ������λ18
			/// </summary>
			public bool Bit18;

			/// <summary>
			/// ͨ������λ19
			/// </summary>
			public bool Bit19;

			/// <summary>
			/// ͨ������λ20
			/// </summary>
			public bool Bit20;

			/// <summary>
			/// ͨ������λ21
			/// </summary>
			public bool Bit21;

			/// <summary>
			/// ͨ������λ22
			/// </summary>
			public bool Bit22;

			/// <summary>
			/// ͨ������λ23
			/// </summary>
			public bool Bit23;

			/// <summary>
			/// ͨ������λ24
			/// </summary>
			public bool Bit24;

			/// <summary>
			/// ͨ������λ25
			/// </summary>
			public bool Bit25;

			/// <summary>
			/// ͨ������λ26
			/// </summary>
			public bool Bit26;

			/// <summary>
			/// ͨ������λ27
			/// </summary>
			public bool Bit27;

			/// <summary>
			/// ͨ������λ28
			/// </summary>
			public bool Bit28;

			/// <summary>
			/// ͨ������λ29
			/// </summary>
			public bool Bit29;

			/// <summary>
			/// ͨ������λ30
			/// </summary>
			public bool Bit30;

			/// <summary>
			/// ͨ������λ31
			/// </summary>
			public bool Bit31;

		}

		#endregion

		#region "��ʼ������"

		//�����������˶����Ƶ���ʵ��
		/// <summary>
		/// �����������˶����Ƶ���ʵ��
		/// </summary>
		/// <param name="DLLPassword">ʹ�ô�DLL�ļ�������</param>
		/// <param name="NumberOfTargetAxis">Ŀ�����š���Χ��1~������*4��</param>
		/// <param name="NumberOfTargetCard">Ŀ�꿨[�����ڿ�]��š���Χ��1~8��</param>
		public AxisControlOfLeadShineDMC2410C(string DLLPassword,
			Int32 NumberOfTargetAxis, Int32 NumberOfTargetCard)
		{

			try
			{

				SuccessBuiltNew = false;
				PasswordIsCorrect = false;

				if (DLLPassword == "ThomasPeng"
					| DLLPassword == "pengdongnan"
					| DLLPassword == "����")
				{
					PasswordIsCorrect = true;

					if (PC.FileSystem.FileExists("DMC2410.dll") == false)
					{
						MessageBox.Show("Failed to load the 'DMC2410.dll', please copy it to the same directory of this software."
							+ "Otherwise, this software can't run.\r\n"
							+ "�뽫 'DMC2410.dll'�ļ�������������еĵ�ǰĿ¼�У���������޷����У�",
							"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					//����ֵ��0�� û���ҵ����ƿ������߿��ƿ��쳣 1��8�� ���ƿ��� 
					//��ֵ�� ������2�Ż�2�����Ͽ��ƿ���Ӳ�����ÿ�����ͬ������ֵȡ����ֵ���1��Ϊ�ÿ���
					AvailableCardQty = d2410_board_init();

					if (AvailableCardQty == 0)
					{
						MessageBox.Show("There is no any Leadshine Motion Card in the PC system,"
							+ " please double check the possible reasons and retry.\r\n"
							+ "��ǰPCϵͳ��û�з��ֿ��õ������˶�����������ܵ�ԭ����ٳ��ԡ�",
							"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					else if (AvailableCardQty < 0)
					{
						MessageBox.Show("There are two or more motion cards which have the same hardware ID,"
							+ " please carefully check the system and set the unique number for each motion card.\r\n"
							+ "��ǰPCϵͳ�������������������˶�����Ӳ�����ÿ�����ͬ������ϵͳ��������ȷӲ�������ٳ��ԣ�",
							"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					//���࿨���С�
					//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
					//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
					//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

					if (NumberOfTargetCard > AvailableCardQty)
					{
						MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
							+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
							"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					//�����ź���ŵĶ�Ӧ��ϵΪ���� 
					// 0�ſ���Ӧ0~3���᣻1�ſ���Ӧ4~7���᣻n�ſ���Ӧ4n~ 4*��n+1��-1���ᡣ
					//��ʹ��ϰ�ߴ�1��ʼ�������������ڵ��ú���ʱ��Ҫ��ȥ1������ȷ����š���
					if (NumberOfTargetAxis > AvailableCardQty * 4
						|| NumberOfTargetAxis < (AvailableCardQty * 4 - 3))
					{
						MessageBox.Show("The value for target axis 'NumberOfTargetAxis' should be : "
							+ (AvailableCardQty * 4 - 3) + "~" + (AvailableCardQty * 4)
							+ " ,please revise the parameter and retry.\r\n"
							+ "Ŀ����Ų��� 'NumberOfTargetAxis' ȡֵ��Χ��"
							+ (AvailableCardQty * 4 - 3) + "~" + (AvailableCardQty * 4)
							+ "���޸Ĳ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					else
					{
						TargetAxis = (ushort)(NumberOfTargetAxis - 1);
					}
					TargetCard = (ushort)NumberOfTargetCard;
					SuccessBuiltNew = true;

				}
				else
				{
					SuccessBuiltNew = false;
					PasswordIsCorrect = false;
					MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n��δ�õ���Ȩ�����룬�޷�ʹ�ô�DLL���������������������������ϵ��southeastofstar@163.com\r\n                                                                ��Ȩ���У� ����",
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

			}
			catch (Exception ex)
			{
				SuccessBuiltNew = false;
				MessageBox.Show("�������ʵ��ʱ���ִ���\r\n" + ex.Message, "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


		}

		//�����������˶����Ƶ���ʵ��
		/// <summary>
		/// �����������˶����Ƶ���ʵ��
		/// </summary>
		/// <param name="DLLPassword">ʹ�ô�DLL�ļ�������</param>
		/// <param name="NumberOfTargetAxis">Ŀ�����š���Χ��1~������*4��</param>
		public AxisControlOfLeadShineDMC2410C(string DLLPassword,
			Int32 NumberOfTargetAxis)
		{

			try
			{

				SuccessBuiltNew = false;
				PasswordIsCorrect = false;

				if (DLLPassword == "ThomasPeng"
					| DLLPassword == "pengdongnan"
					| DLLPassword == "����")
				{
					PasswordIsCorrect = true;

					if (PC.FileSystem.FileExists("DMC2410.dll") == false)
					{
						MessageBox.Show("Failed to load the 'DMC2410.dll', please copy it to the same directory of this software."
							+ "Otherwise, this software can't run.\r\n"
							+ "�뽫 'DMC2410.dll'�ļ�������������еĵ�ǰĿ¼�У���������޷����У�",
							"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					//����ֵ��0�� û���ҵ����ƿ������߿��ƿ��쳣 1��8�� ���ƿ��� 
					//��ֵ�� ������2�Ż�2�����Ͽ��ƿ���Ӳ�����ÿ�����ͬ������ֵȡ����ֵ���1��Ϊ�ÿ���
					AvailableCardQty = d2410_board_init();

					if (AvailableCardQty == 0)
					{
						MessageBox.Show("There is no any Leadshine Motion Card in the PC system,"
							+ " please double check the possible reasons and retry.\r\n"
							+ "��ǰPCϵͳ��û�з��ֿ��õ������˶�����������ܵ�ԭ����ٳ��ԡ�",
							"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					else if (AvailableCardQty < 0)
					{
						MessageBox.Show("There are two or more motion cards which have the same hardware ID,"
							+ " please carefully check the system and set the unique number for each motion card.\r\n"
							+ "��ǰPCϵͳ�������������������˶�����Ӳ�����ÿ�����ͬ������ϵͳ��������ȷӲ�������ٳ��ԣ�",
							"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					//���࿨���С�
					//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
					//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
					//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

					//�����ź���ŵĶ�Ӧ��ϵΪ���� 
					// 0�ſ���Ӧ0~3���᣻1�ſ���Ӧ4~7���᣻n�ſ���Ӧ4n~ 4*��n+1��-1���ᡣ
					//��ʹ��ϰ�ߴ�1��ʼ�������������ڵ��ú���ʱ��Ҫ��ȥ1������ȷ����š���
					if (NumberOfTargetAxis > AvailableCardQty * 4
						&& NumberOfTargetAxis < 0)
					{
						MessageBox.Show("The value for target axis 'NumberOfTargetAxis' should be : "
							+ "1~" + (AvailableCardQty * 4) + " ,please revise the parameter and retry.\r\n"
							+ "Ŀ����Ų��� 'NumberOfTargetAxis' ȡֵ��Χ��" + "1~" + (AvailableCardQty * 4)
							+ "���޸Ĳ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					else
					{
						TargetAxis = (ushort)(NumberOfTargetAxis - 1);
					}

					SuccessBuiltNew = true;

				}
				else
				{
					SuccessBuiltNew = false;
					PasswordIsCorrect = false;
					MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n��δ�õ���Ȩ�����룬�޷�ʹ�ô�DLL���������������������������ϵ��southeastofstar@163.com\r\n                                                                ��Ȩ���У� ����",
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

			}
			catch (Exception ex)
			{
				SuccessBuiltNew = false;
				MessageBox.Show("�������ʵ��ʱ���ִ���\r\n" + ex.Message, "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

		}

		//�رտ��ƿ����ͷſ��ƿ�ϵͳ��Դ
		/// <summary>
		/// �رտ��ƿ����ͷſ��ƿ�ϵͳ��Դ
		/// </summary>
		/// <returns></returns>
		public int CloseCard()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����");
					return 1;
				}

				UInt32 TempReturn = 0;
				TempReturn = d2410_board_close();
				return (int)TempReturn;

			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "���������������"

		// DMC2410C�������������ָ�������źţ�
		//һ��Ϊ����+����ģʽ��������ģʽ��
		//һ��Ϊ������+������ģʽ��˫����ģʽ��

		//��������������ģʽ
		/// <summary>
		/// ��������������ģʽ
		/// </summary>
		/// <param name="TargetPulseOutMode">���������ʽѡ��[0~5]
		/// 0--����������[PULSE��������壬DIR�ߵ�ƽ]  ����������[PULSE��������壬DIR�͵�ƽ]
		/// 1--����������[PULSE��������壬DIR�ߵ�ƽ]  ����������[PULSE��������壬DIR�͵�ƽ]
		/// 2--����������[PULSE��������壬DIR�͵�ƽ]  ����������[PULSE��������壬DIR�ߵ�ƽ]
		/// 3--����������[PULSE��������壬DIR�͵�ƽ]  ����������[PULSE��������壬DIR�ߵ�ƽ]
		/// 4--����������[PULSE��������壬DIR���ƽ]  ����������[PULSE����ߵ�ƽ��DIR������]
		/// 5--����������[PULSE��������壬DIR�͵�ƽ]  ����������[PULSE����ߵ�ƽ��DIR������]
		/// </param>
		/// <returns></returns>
		public int SetPulseOutMode(ushort TargetPulseOutMode)
		{
			try
			{
				//ע�⣺�ڵ����˶��������磺d2410_t_vmove�ȣ��������֮ǰ��һ��Ҫ������������
				//�������ģʽ����d2410_set_pulse_outmode���ÿ��ƿ��������ģʽ��
				//d2410_set_pulse_outmode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal outmode As Int16) As Int32

				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetPulseOutMode < 0
					|| TargetPulseOutMode > 5)
				{
					MessageBox.Show("The parameter 'TargetPulseOutMode' should be 0~5, please revise it and retry.\r\n"
						+ "���� 'TargetPulseOutMode' ȡֵ��ΧӦ��Ϊ0~5�����޸Ĳ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_pulse_outmode(TargetAxis, TargetPulseOutMode);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//���ñ������ļ�����ʽ
		/// <summary>
		/// ���ñ������ļ�����ʽ
		/// </summary>
		/// <param name="EncoderCounterMode">�������ļ�����ʽ��
		/// 0����A/B�� (����/����)
		/// 1��1��A/B
		/// 2��2�� A/B
		/// 3��4�� A/B
		/// </param>
		/// <returns></returns>
		public int SetEncoderCounterMode(ushort EncoderCounterMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (EncoderCounterMode < 0
					|| EncoderCounterMode > 3)
				{
					MessageBox.Show("The value for parameter 'EncoderCounterMode' should be 0~3, please revise it.\r\n"
						+ "���� 'EncoderCounterMode' ��ȡֵ��Χ��0~3�����޸Ĳ�����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_counter_config(TargetAxis, EncoderCounterMode);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "�ƶ�����"

		//ָ�������ֹͣ�����ô˺���ʱ�������ٺ�ֹͣ��ֹͣʱ���ٶ�����ʼ�ٶȺ�ֹͣ�ٶ��еĽϴ�ֵ��
		/// <summary>
		/// ָ�������ֹͣ�����ô˺���ʱ�������ٺ�ֹͣ��
		/// ֹͣʱ���ٶ�����ʼ�ٶȺ�ֹͣ�ٶ��еĽϴ�ֵ��
		/// </summary>
		/// <param name="DecelerationTime">����ʱ�䣬��λ��s</param>
		/// <returns></returns>
		public int StopDecel(double DecelerationTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_decel_stop(TargetAxis, DecelerationTime);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//ʹָ��������ֹͣ��û���κμ��ٵĹ���
		/// <summary>
		/// ʹָ��������ֹͣ��û���κμ��ٵĹ���
		/// </summary>
		/// <returns></returns>
		public int StopImmediately()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_imd_stop(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//ʹ���е��˶������ֹͣ
		/// <summary>
		/// ʹ���е��˶������ֹͣ
		/// </summary>
		/// <returns></returns>
		public int StopAllAxisEmergent()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_emg_stop();

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "״̬��⺯��"

		//���ָ������˶�״̬��ֹͣ������������
		/// <summary>
		/// ���ָ������˶�״̬��ֹͣ������������
		/// </summary>
		/// <returns></returns>
		public bool GetRunningStatus()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				int TempReturn = 0;
				TempReturn = d2410_check_done(TargetAxis);
				if (TempReturn == 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return false;
			}
		}

		//��ȡָ�����й��˶��źŵ�״̬�����ŷ�����������λ������λ��ԭ���źš�������ָ�����ר��I/O״̬
		/// <summary>
		/// ��ȡָ�����й��˶��źŵ�״̬�����ŷ�����������λ������λ��ԭ���źš���
		/// ����ָ�����ר��I/O״̬
		/// </summary>
		/// <returns>���˶��źŵ�״̬���ݽṹ</returns>
		public AxisSignal GetAxisSignalStatus()
		{
			AxisSignal TempAxisSignal;
			TempAxisSignal.HomeSignal = false;
			TempAxisSignal.NegotiveLimit = false;
			TempAxisSignal.PositiveLimit = false;
			TempAxisSignal.ServoAlarm = false;
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempAxisSignal;
				}

				int TempReturn = 0;

				//λ�š���0��ʼ��:����, �ź�����: ����
				TempReturn = (int)d2410_axis_io_status(TargetAxis);

				//λ��:11, �ź�����: ALM, 1����ʾ�ŷ������ź� ALM Ϊ ON
				//if ((TempReturn & (int)(Math.Pow(2, 11))) == 1)
				//    {
				//    TempAxisSignal.ServoAlarm = true;
				//    }
				//else 
				//    {
				//    TempAxisSignal.ServoAlarm = false;
				//    }

				if ((TempReturn >> (11 - 1)) == 1)
				{
					TempAxisSignal.ServoAlarm = true;
				}
				else
				{
					TempAxisSignal.ServoAlarm = false;
				}

				//λ��:12, �ź�����: PEL, 1����ʾ����λ�ź� +EL Ϊ ON
				if ((TempReturn >> (12 - 1)) == 1)
				{
					TempAxisSignal.PositiveLimit = true;
				}
				else
				{
					TempAxisSignal.PositiveLimit = false;
				}

				//λ��:13, �ź�����: NEL, 1����ʾ����λ�źŨCELΪ ON
				if ((TempReturn >> (13 - 1)) == 1)
				{
					TempAxisSignal.NegotiveLimit = true;
				}
				else
				{
					TempAxisSignal.NegotiveLimit = false;
				}

				//λ��:14, �ź�����: ORG, 1����ʾԭ���ź� ORG Ϊ ON
				if ((TempReturn >> (14 - 1)) == 1)
				{
					TempAxisSignal.HomeSignal = true;
				}
				else
				{
					TempAxisSignal.HomeSignal = false;
				}

				return TempAxisSignal;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempAxisSignal;
			}
		}

		//��ȡָ������ⲿ�ź�״̬������ֹͣ�ź�(EMG)�������ź�(EZ)��+DR(PA)�źš�-DR(PB)�źš�
		/// <summary>
		/// ��ȡָ������ⲿ�ź�״̬
		/// ������ֹͣ�ź�(EMG)�������ź�(EZ)��+DR(PA)�źš�-DR(PB)�źš�
		/// </summary>
		/// <returns>���ⲿ�źŵ�״̬���ݽṹ</returns>
		public AxisOutsideSignal GetAxisOutsideSignalStatus()
		{
			AxisOutsideSignal TempAxisOutsideSignal;
			TempAxisOutsideSignal.EStop = false;
			TempAxisOutsideSignal.EZIndexSignal = false;
			TempAxisOutsideSignal.NegativeDR_PB = false;
			TempAxisOutsideSignal.PositiveDR_PA = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempAxisOutsideSignal;
				}

				int TempReturn = 0;

				//λ��:����λ, �ź�����: ����
				//λ��:0~3, �ź�����: ����
				TempReturn = (int)d2410_axis_io_status(TargetAxis);

				//λ��:7, �ź�����: EMG, 1����ʾ����ֹͣ�źţ�EMG��Ϊ ON
				if ((TempReturn >> (7 - 1)) == 1)
				{
					TempAxisOutsideSignal.EStop = true;
				}
				else
				{
					TempAxisOutsideSignal.EStop = false;
				}

				//λ��:10, �ź�����: EZ, 1����ʾ�����źţ�EZ��Ϊ ON
				if ((TempReturn >> (10 - 1)) == 1)
				{
					TempAxisOutsideSignal.EZIndexSignal = true;
				}
				else
				{
					TempAxisOutsideSignal.EZIndexSignal = false;
				}

				//λ��:11, �ź�����: +DR(PA), 1����ʾ +DR(PA) �ź�Ϊ ON
				if ((TempReturn >> (11 - 1)) == 1)
				{
					TempAxisOutsideSignal.PositiveDR_PA = true;
				}
				else
				{
					TempAxisOutsideSignal.PositiveDR_PA = false;
				}

				//λ��:12, �ź�����: -DR(PB), 1����ʾ -DR(PB) �ź�Ϊ ON
				if ((TempReturn >> (12 - 1)) == 1)
				{
					TempAxisOutsideSignal.NegativeDR_PB = true;
				}
				else
				{
					TempAxisOutsideSignal.NegativeDR_PB = false;
				}

				return TempAxisOutsideSignal;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempAxisOutsideSignal;
			}
		}

		#endregion

		#region "λ�����úͶ�ȡ����"

		//��ȡ��ĵ�ǰλ������������λ��pulse��
		/// <summary>
		/// ��ȡ��ĵ�ǰλ������������λ��pulse�� 
		/// </summary>
		/// <returns></returns>
		public int GetCurrentPosInPulse()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_position(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡ��ĵ�ǰλ�á���λ��mm��
		/// <summary>
		/// ��ȡ��ĵ�ǰλ�á���λ��mm��
		/// </summary>
		/// <param name="CurrentPosInMM">��ĵ�ǰλ�á���λ��mm��</param>
		/// <returns></returns>
		public int GetCurrentPosInMM(ref double CurrentPosInMM)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_position_unitmm(TargetAxis, ref CurrentPosInMM);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ���Ŀ������λ�á��������꡿����λ��pulse
		/// <summary>
		/// ��ȡ���Ŀ������λ�á��������꡿����λ��pulse
		/// </summary>
		/// <returns>���Ŀ������λ�á��������꡿����λ��pulse</returns>
		public int GetABSPosInPulse()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_target_position(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//�趨ָ����ĵ�ǰλ�á���λ��pulse���������ڻص�ԭ���λ�����㡿
		/// <summary>
		/// �趨ָ����ĵ�ǰλ�á���λ��pulse���������ڻص�ԭ���λ�����㡿
		/// </summary>
		/// <param name="ABSValueForCurrentPosition">����λ��ֵ����λ��pulse��</param>
		/// <returns></returns>
		public int SetABSPosInPulse(Int32 ABSValueForCurrentPosition)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_position(TargetAxis, ABSValueForCurrentPosition);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�趨ָ����ĵ�ǰλ�á���λ��mm���������ڻص�ԭ���λ�����㡿
		/// <summary>
		/// �趨ָ����ĵ�ǰλ�á���λ��mm���������ڻص�ԭ���λ�����㡿
		/// </summary>
		/// <param name="ValueForCurrentABSPosInMM">����λ��ֵ����λ��mm��</param>
		/// <returns></returns>
		public int SetABSPosInMM(double ValueForCurrentABSPosInMM)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_position_unitmm(TargetAxis, ValueForCurrentABSPosInMM);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "�ٶ����úͶ�ȡ"

		//�趨�������ߵ���ʼ�ٶȡ������ٶȡ�����ʱ�䡢����ʱ��
		/// <summary>
		/// �趨�������ߵ���ʼ�ٶȡ������ٶȡ�����ʱ�䡢����ʱ��
		/// </summary>
		/// <param name="MinVelocity">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int SetTCurveProfile(double MinVelocity, double MaxVelocity,
			double TotalAccTime, double TotalDecTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile(TargetAxis, MinVelocity,
					MaxVelocity, TotalAccTime, TotalDecTime);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//Set_T_Profile��չ����������ֹͣ�ٶȵ��趨
		/// <summary>
		/// Set_T_Profile��չ����������ֹͣ�ٶȵ��趨
		/// </summary>
		/// <param name="MinVelocity">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="StopVelocity">ֹͣ�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int SetTCurveProfileExtern(double MinVelocity, double MaxVelocity,
			double TotalAccTime, double TotalDecTime, double StopVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile_Extern(TargetAxis, MinVelocity,
					MaxVelocity, TotalAccTime, TotalDecTime, StopVelocity);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�趨ST�������˶�����ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		/// <summary>
		/// �趨ST�������˶�����ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		/// </summary>
		/// <param name="MinVelocity">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="STAccTime">S��ʱ�䣬��λ��s����Χ[0,50]ms</param>
		/// <param name="STDecTime">��������</param>
		/// <returns>�������</returns>
		public int SetSTCurveProfile(double MinVelocity, double MaxVelocity,
			double TotalAccTime, double TotalDecTime, double STAccTime, double STDecTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_st_profile(TargetAxis, MinVelocity,
					MaxVelocity, TotalAccTime, TotalDecTime, STAccTime, STDecTime);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�趨S�������˶�����ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		/// <summary>
		/// �趨S�������˶�����ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		/// </summary>
		/// <param name="MinVelocity">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="SAccTime">S��ʱ�䣬��λ��s����Χ[0,50]ms</param>
		/// <param name="SDecTime">��������</param>
		/// <returns>�������</returns>
		public int SetSCurveProfile(double MinVelocity, double MaxVelocity,
			double TotalAccTime, double TotalDecTime, int SAccTime, int SDecTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_s_profile(TargetAxis, MinVelocity,
					MaxVelocity, TotalAccTime, TotalDecTime, SAccTime, SDecTime);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//Set_ST_Profile��չ����������ֹͣ�ٶȵ��趨
		/// <summary>
		/// Set_ST_Profile��չ����������ֹͣ�ٶȵ��趨
		/// </summary>
		/// <param name="MinVelocity">��ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="SAccTime">S��ʱ�䣬��λ��s����Χ[0,50] ms</param>
		/// <param name="SDecTime">��������</param>
		/// <param name="StopVelocity">ֹͣ�ٶ�</param>
		/// <returns>�������</returns>
		public int SetSTCurveProfileExtern(double MinVelocity, double MaxVelocity,
			double TotalAccTime, double TotalDecTime, double SAccTime,
			double SDecTime, double StopVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_st_profile_Extern(TargetAxis,
					MinVelocity, MaxVelocity, TotalAccTime, TotalDecTime, SAccTime,
					SDecTime, StopVelocity);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
		/// <summary>
		/// �趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
		/// </summary>
		/// <param name="MinVelocity">��������</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int SetVectorProfile(double MinVelocity, double MaxVelocity,
			double TotalAccTime, double TotalDecTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity, MaxVelocity,
					TotalAccTime, TotalDecTime);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��ǰ�ٶ�ֵ����λ��pulse/s
		//��ע�⣺��ִ�в岹�˶�ʱ�����øú�����ȡ��Ϊʸ���ٶȡ�
		/// <summary>
		/// ��ȡ��ǰ�ٶ�ֵ����λ��pulse/s
		/// ��ע�⣺��ִ�в岹�˶�ʱ�����øú�����ȡ��Ϊʸ���ٶȡ�
		/// </summary>
		/// <returns>��ĵ�ǰ�����ٶȡ���λ��pulse/s��</returns>
		public double GetCurrentSpeed()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_current_speed(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡ��ǰ�ٶ�ֵ����λ��mm/s
		//��ע�⣺��ִ�в岹�˶�ʱ�����øú�����ȡ��Ϊʸ���ٶȡ�
		/// <summary>
		/// ��ȡ��ǰ�ٶ�ֵ����λ��mm/s
		/// ��ע�⣺��ִ�в岹�˶�ʱ�����øú�����ȡ��Ϊʸ���ٶȡ�
		/// </summary>
		/// <param name="CurrentSpeedInMMPerSecond">��������ٶȡ���λ��mm/s��</param>
		/// <returns></returns>
		public int GetCurrentSpeed(ref double CurrentSpeedInMMPerSecond)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_current_speed_unitmm(TargetAxis,
					ref CurrentSpeedInMMPerSecond);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��ǰ���ƿ���ʸ���ٶ�ֵ����λ��pulse/s
		/// <summary>
		/// ��ȡ��ǰ���ƿ���ʸ���ٶ�ֵ����λ��pulse/s
		/// </summary>
		/// <returns>�������ʸ���ٶȡ���λ��pulse/s��</returns>
		public double GetCurrentVectorSpeed()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				double TempReturn = 0;
				TempReturn = d2410_read_vector_speed(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡָ�����ƿ���ʸ���ٶ�ֵ����λ��pulse/s
		/// <summary>
		/// ��ȡָ�����ƿ���ʸ���ٶ�ֵ����λ��pulse/s
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>ָ�����ƿ��������ʸ���ٶȡ���λ��pulse/s��</returns>
		public double GetCurrentVectorSpeed(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				//�����ź���ŵĶ�Ӧ��ϵΪ���� 
				// 0�ſ���Ӧ0~3���᣻1�ſ���Ӧ4~7���᣻n�ſ���Ӧ4n~ 4*��n+1��-1���ᡣ
				// Ϊ������ʱ���, ���Ŵ�1��ʼ, Ȼ���ں���������м�1�õ�ʵ�ʵĿ���
				if (TargetCardNumber < 1
					|| TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("The parameter 'TargetCardNumber' should be 1~"
						+ AvailableCardQty + ", please revise it.");
					return 0;
				}

				ushort TempCard = (ushort)(TargetCardNumber - 1);

				double TempReturn = 0.0;
				TempReturn = d2410_read_vector_speed(TempCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		#endregion

		#region "���߱���/��λ"

		//���߸ı���ĵ�ǰ�˶��ٶȡ���λ��pulse/s�����ú���ֻ�����ڵ����˶��еı���
		/// <summary>
		/// ���߸ı���ĵ�ǰ�˶��ٶȡ���λ��pulse/s����
		/// �ú���ֻ�����ڵ����˶��еı��١�
		/// ע�⣺
		/// (1)����һ�������������Ĭ�������ٶȽ��ᱻ��дΪNewVelocity��
		///    Ҳ��������get_profile�ض��ٶȲ���ʱ�ᷢ����set_profile�����õĲ�һ�µ�����;
		/// (2)�ڵ����ٶ��˶���NewVelocity��ֵ��ʾ��������٣���ֵ��ʾ��������١�
		///    �ڵ��ᶨ���˶���NewVelocityֻ������ֵ��
		/// </summary>
		/// <param name="NewVelocity">�µ������ٶȡ���λ��pulse/s��</param>
		/// <returns>�������</returns>
		public int ChangeSpeed(double NewVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_change_speed(TargetAxis, NewVelocity);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�ڵ�������˶��иı�Ŀ��λ�á���λ��pulse��
		/// <summary>
		/// �ڵ�������˶��иı�Ŀ��λ�á���λ��pulse��
		/// ע�⣺����NewABSPosΪ����λ��ֵ�����۵�ǰ���˶�ģʽΪ�������껹���������ģʽ��
		/// </summary>
		/// <param name="NewABSPos">�¾���λ��ֵ</param>
		/// <returns>�������</returns>
		public int ChangeTargetABSPos(int NewABSPos)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_target_position(TargetAxis, NewABSPos);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "����λ�ÿ��ƺ���"

		//��DMC2410C�������о����λ�õĵ�λΪ���壻�ٶȵ�λΪ����/�룻ʱ�䵥λΪ�롣
		//�������λ�ÿ�����ָ�ӵ�ǰλ���˶�����һ��λ�ã�һ���Ϊ��λ�˶��򶨳��˶��� 
		//DMC2410C����ִ�е������ʱ����ʹ������������ٶ����߻�S���ٶ����߽��е�λ�˶��������˶���

		//ע�����Գ������ٶ����ߡ���ָ����ٶȺͼ��ٶ���ԣ������ٹ��̺ͼ��ٹ��̵�����б�ʶԳơ�

		//�����ٶ������µĵ�λ�˶�
		//d2410_set_profile              �趨�����ٶ����ߵ���ʼ�ٶȡ�����ٶȡ�����ʱ�䡢����ʱ��
		//d2410_set_profile_Extern       �趨�����ٶ����ߵ���ʼ�ٶȡ�����ٶȡ�ֹͣ�ٶȡ�����ʱ�䡢����ʱ��
		//d2410_t_pmove                  ��ָ�����ԶԳ������ٶ���������λ�˶�
		//d2410_ex_t_pmove               ��ָ�����ԷǶԳ������ٶ���������λ�˶�

		//����7.3��ִ���ԷǶԳ������ٶ���������λ�˶� 
		//d2410_set_profile 0,500,6000,0.02,0.01     '����0������ʼ�ٶ�Ϊ500����/�� 
		//'�����ٶ�Ϊ6000����/�롢����ʱ��Ϊ0.02�롢
		//'����ʱ��Ϊ0.01�롣 
		//d2410_ex_t_pmove 0,50000,0                 '����0���ᡢ��

		//**************************
		//�ڵ������й����У�����ٶ�Max_Vel��Ŀ��λ��Dist������ʵʱ�ı�
		//**************************

		//�����ٶ��¸ı��ٶȡ��յ����غ���˵��
		//d2410_change_speed                  '���������иı䵱ǰ����ٶ�
		//d2410_reset_target_position         '�ı�Ŀ��λ��

		//����7.4���ı��ٶȡ��ı��յ�λ��
		//d2410_set_profile 0,500,6000,0.01,0.02     '�������������ٶȡ��ӡ�����ʱ��*/ 
		//d2410_ex_t_pmove 0,50000,0                 '������š��˶�����50000���������ģʽ 
		//If(���ı��ٶ�������)                       '����ı��ٶ��������㣬��ִ�иı��ٶ����� 
		//Curr_Vel= 9000                             '�����µ��ٶ� 
		//d2410_change_speed 0,Curr_Vel              'ִ�иı��ٶ�ָ�� 
		//End If 
		//If(���ı��յ�λ��������)                   '����ı��յ�λ���������㣬��ִ�иı��յ�λ������ 
		//d2410_reset_target_position 0,55000        '�ı��յ�λ��Ϊ55000 
		//End If 

		//������˶��е�����ٶ����õ�С����ʼ�ٶȣ������˶������н���������ٶ��������˶��� 
		//����˶�����̣ܶ�������С�ڻ����(Max_Vel+Min_Vel)��Taccʱ���������ٶ����߽���Ϊ�����Σ�
		//��DMC2410C�˶����ƿ����Զ��������ܣ��������εļ����ȥ���Ա����ٶȱ仯̫�����������

		//S���ٶ������˶�ģʽ
		//d2410_set_st_profile                '����S��ʱ�䣬��ʼ�ٶȺ�ֹͣ�ٶ���ͬ
		//d2410_set_st_profile_Extern         '����S��ʱ�䣬��ֹͣ�ٶ�
		//d2410_s_pmove                       '��ָ�����ԶԳ�S���ٶ���������λ�˶�
		//d2410_ex_s_pmove                    '��ָ�����ԷǶԳ�S���ٶ���������λ�˶�

		//��S���ٶ������µĵ�λ�˶������У�Ҳ���Ե���d2410_change_speed��d2410_reset_target_position����
		//ʵʱ�ı������ٶȺ�Ŀ��λ�á�������岹��������²���ʵʱ�ı������ٶȺ�Ŀ��λ�á�

		//�����˶�ģʽ
		//�����˶�ģʽ�У�DMC2410C���ƿ����Կ��Ƶ�������λ�S���ٶ�������ָ���ļ���ʱ���ڴ���ʼ�ٶȼ���������ٶȣ�
		//Ȼ���Ը��ٶ��������У�ֱ������ָֹͣ����߸���������λ�źŲŻᰴ����ʱ���ٶ����߼���ֹͣ��

		//�����˶���غ���˵��
		//d2410_t_vmove      '��ָ�����������ٶ����߼��ٵ�����ٶȺ���������
		//d2410_s_vmove      '��ָ������S���ٶ����߼��ٵ�����ٶȺ���������
		//d2410_decel_stop   'ָ�������ֹͣ�����ô˺������������٣�������ʼ�ٶȺ�ֹͣ

		//�ڵ���ִ�������˶������У����Ե���d2410_change_speed ʵʱ�ı��ٶȡ�
		//ע�⣺����S���ٶ����������˶�ʱ���ı�����ٶ�����ڼ��ٹ����Ѿ���ɵĺ��ٶν��С�

		//����7.5����S���ٶ����߼��ٵ������˶������١�ֹͣ����
		//d2410_set_st_profile 0,100, 1000,0.1,0.1,0.01,0      '����S������S��ʱ�� 
		//d2410_s_vmove 0,1                                    '0���������˶�������Ϊ�� 
		//if(���ı��ٶ�������)                                 '����ı��ٶ��������㣬��ִ�иı��ٶ����� 
		//Curr_Vel= 1200                                       '�����µ��ٶ� 
		//d2410_change_speed 0,Curr_Vel                        'ִ�иı��ٶ�ָ�� 
		//End If 
		//if(��ֹͣ������)                                     '����˶�ֹͣ�������㣬��ִ�м���ֹͣ���� 
		//d2410_decel_stop 0,0.1                               '����ֹͣ������ʱ��Ϊ0.1��
		//End If

		//

		/// <summary>
		/// ʹ����T���ٶ����߼��ٵ����٣�������������ȥ
		/// </summary>
		/// <param name="MoveDirection">ָ���˶��ķ���0��������1��������</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int MoveTCurve(ushort MoveDirection, double MinVelocity,
			double MaxVelocity, double TotalAccTime, double TotalDecTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (MoveDirection != 0)
				{
					MoveDirection = 1;
				}

				//�趨�������ߵ���ʼ�ٶȡ������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="axis">ָ�����</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//Declare Function d2410_set_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, 
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile(TargetAxis, MinVelocity, MaxVelocity,
					TotalAccTime, TotalDecTime);
				TempReturn += (int)d2410_t_vmove(TargetAxis, MoveDirection);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//ʹ����S���ٶ����߼��ٵ����٣�������������ȥ
		/// <summary>
		/// ʹ����S���ٶ����߼��ٵ����٣�������������ȥ
		/// </summary>
		/// <param name="MoveDirection">ָ���˶��ķ���0��������1��������</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="StopVelocity">ֹͣ�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int MoveSCurve(ushort MoveDirection, double MinVelocity,
			double MaxVelocity, double TotalAccTime, double TotalDecTime,
			double StopVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (MoveDirection != 0)
				{
					MoveDirection = 1;
				}

				//d2410_set_profile��չ����������ֹͣ�ٶȵ��趨
				//<param name="axis">�μ��˶������</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Stop_Vel">ֹͣ�ٶȣ���λ��pulse/s</param>
				//Declare Function d2410_set_profile_Extern Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double,
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_Vel As Double) As Int32


				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile_Extern(TargetAxis,
					MinVelocity, MaxVelocity, TotalAccTime, TotalDecTime, StopVelocity);
				TempReturn = (int)d2410_s_vmove(TargetAxis, MoveDirection);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//ʹ���ԶԳ������ٶ���������λ�˶�
		/// <summary>
		/// ʹ���ԶԳ������ٶ���������λ�˶�
		/// </summary>
		/// <param name="MoveDistance">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="MoveMode">λ��ģʽ�趨��
		/// 0�����λ��
		/// 1������λ��
		/// </param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="StopVelocity">ֹͣ�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int MoveSymmetricalTCurve(int MoveDistance, ushort MoveMode,
			double MinVelocity, double MaxVelocity, double TotalAccTime,
			double TotalDecTime, double StopVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (MoveMode != 0)
				{
					MoveMode = 1;
				}

				//d2410_set_profile��չ����������ֹͣ�ٶȵ��趨
				//<param name="axis">�μ��˶������</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Stop_Vel">ֹͣ�ٶȣ���λ��pulse/s</param>
				//Declare Function d2410_set_profile_Extern Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double,
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_Vel As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile_Extern(TargetAxis, MinVelocity,
					MaxVelocity, TotalAccTime, TotalDecTime, StopVelocity);
				TempReturn += (int)d2410_t_pmove(TargetAxis, MoveDistance, MoveMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//ʹ���ԶԳ�S���ٶ���������λ�˶�
		/// <summary>
		/// ʹ���ԶԳ�S���ٶ���������λ�˶�
		/// </summary>
		/// <param name="MoveDistance">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="MoveMode">>λ��ģʽ�趨��
		/// 0�����λ��
		/// 1������λ��
		/// </param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="StopVelocity">ֹͣ�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int MoveSymmetricalSCurve(int MoveDistance, ushort MoveMode,
			double MinVelocity, double MaxVelocity, double TotalAccTime,
			double TotalDecTime, double StopVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (MoveMode != 0)
				{
					MoveMode = 1;
				}

				//d2410_set_profile��չ����������ֹͣ�ٶȵ��趨
				//<param name="axis">�μ��˶������</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Stop_Vel">ֹͣ�ٶȣ���λ��pulse/s</param>
				//Declare Function d2410_set_profile_Extern Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double,
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_Vel As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile_Extern(TargetAxis,
					MinVelocity, MaxVelocity, TotalAccTime, TotalDecTime, StopVelocity);
				TempReturn += (int)d2410_s_pmove(TargetAxis, MoveDistance, MoveMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//ʹ���ԷǶԳ������ٶ���������λ�˶�
		/// <summary>
		/// ʹ���ԷǶԳ������ٶ���������λ�˶�
		/// </summary>
		/// <param name="MoveDistance">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="MoveMode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="StopVelocity">ֹͣ�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int MoveFreeTCurve(int MoveDistance, ushort MoveMode,
			double MinVelocity, double MaxVelocity, double TotalAccTime,
			double TotalDecTime, double StopVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (MoveMode != 0)
				{
					MoveMode = 1;
				}

				//d2410_set_profile��չ����������ֹͣ�ٶȵ��趨
				//<param name="axis">�μ��˶������</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Stop_Vel">ֹͣ�ٶȣ���λ��pulse/s</param>
				//Declare Function d2410_set_profile_Extern Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double,
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_Vel As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile_Extern(TargetAxis,
					MinVelocity, MaxVelocity, TotalAccTime, TotalDecTime, StopVelocity);
				TempReturn += (int)d2410_ex_t_pmove(TargetAxis, MoveDistance, MoveMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//ʹ���ԷǶԳ�S���ٶ���������λ�˶�
		/// <summary>
		/// ʹ���ԷǶԳ�S���ٶ���������λ�˶�
		/// </summary>
		/// <param name="MoveDistance">λ����������/��ԣ�����λ��pulse</param>
		/// <param name="MoveMode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="StopVelocity">ֹͣ�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int MoveFreeSCurve(int MoveDistance, ushort MoveMode,
			double MinVelocity, double MaxVelocity, double TotalAccTime,
			double TotalDecTime, double StopVelocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (MoveMode != 0)
				{
					MoveMode = 1;
				}

				//d2410_set_profile��չ����������ֹͣ�ٶȵ��趨
				//<param name="axis">�μ��˶������</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Stop_Vel">ֹͣ�ٶȣ���λ��pulse/s</param>
				//Declare Function d2410_set_profile_Extern Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double,
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_Vel As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile_Extern(TargetAxis, MinVelocity,
					MaxVelocity, TotalAccTime, TotalDecTime, StopVelocity);
				TempReturn += (int)d2410_ex_s_pmove(TargetAxis, MoveDistance, MoveMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ת
		/// <summary>
		/// ����ת
		/// </summary>
		/// <param name="Velocity">�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int JogPositive(int Velocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				//�趨�������ߵ���ʼ�ٶȡ������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="axis">ָ�����</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//Declare Function d2410_set_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, 
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile(TargetAxis, 100, Velocity, 0.1, 0.1);

				//ʹָ������T���ٶ����߼��ٵ����٣�������������ȥ
				//<param name="dir">ָ���˶��ķ���0��������1��������</param>
				//Declare Function d2410_t_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal dir As Int16) As Int32

				TempReturn += (int)d2410_t_vmove(TargetAxis, 1);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�ᷴת
		/// <summary>
		/// �ᷴת
		/// </summary>
		/// <param name="Velocity">�ٶȣ���λ��pulse/s</param>
		/// <returns>�������</returns>
		public int JogNegative(int Velocity)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				//�趨�������ߵ���ʼ�ٶȡ������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="axis">ָ�����</param>
				//<param name="Min_Vel">��ʼ�ٶȣ���λ��pulse/s</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//Declare Function d2410_set_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, 
				//ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_profile(TargetAxis, 100,
					Velocity, 0.1, 0.1);

				//ʹָ������T���ٶ����߼��ٵ����٣�������������ȥ
				//<param name="dir">ָ���˶��ķ���0��������1��������</param>
				//Declare Function d2410_t_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal dir As Int16) As Int32

				TempReturn += (int)d2410_t_vmove(TargetAxis, 0);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "��ԭ��"

		//�趨��Ļ�ԭ��ģʽ
		/// <summary>
		/// �趨��Ļ�ԭ��ģʽ
		/// </summary>
		/// <param name="SearchHomeMode">��ԭ����ź�ģʽ��
		/// 0��ֻ��home 
		/// 1����home��EZ����1��EZ�ź�
		/// 2��һ�λ���ӻ���
		/// 3�����λ���
		/// 4��EZ�������� 
		/// 5��ԭ�㲶�����
		/// </param>
		/// <param name="EZ_Count">EZ�źų���EZ_countָ���Ĵ��������˶�ֹͣ��
		/// ����SearchHomeMode=4ʱ�ò���������Ч��ȡֵ��Χ��1��16
		/// </param>
		/// <returns>�������</returns>
		public int SetSearchHomeMode(ushort SearchHomeMode, ushort EZ_Count)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (SearchHomeMode < 0
					|| SearchHomeMode > 5)
				{
					MessageBox.Show("The parameter 'SearchHomeMode' should be 0~5, please revise it.");
					return 1;
				}

				if (SearchHomeMode == 4)
				{
					if (EZ_Count < 1
						|| EZ_Count > 16)
					{
						MessageBox.Show("The parameter 'EZ_Count' should be 1~16, please revise it.");
						return 1;
					}
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_home_mode(TargetAxis, SearchHomeMode, EZ_Count);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�����ԭ���˶�
		/// <summary>
		/// �����ԭ���˶�
		/// </summary>
		/// <param name="SearchHomeDirection">��ԭ�㷽ʽ��1���������ԭ�㣬2���������ԭ��</param>
		/// <param name="VelocityMode">��ԭ���ٶȣ�0�����ٻ�ԭ�㣬1�����ٻ�ԭ��</param>
		/// <returns>�������</returns>
		public int SearchHome(ushort SearchHomeDirection, ushort VelocityMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (SearchHomeDirection < 1
					|| SearchHomeDirection > 2)
				{
					MessageBox.Show("The parameter 'SearchHomeDirection' should be 1~2, please revise it.");
					return 1;
				}

				if (VelocityMode < 0 || VelocityMode > 1)
				{
					MessageBox.Show("The parameter 'VelocityMode' should be 0~1, please revise it.");
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_home_move(TargetAxis, SearchHomeDirection, VelocityMode);

				while (d2410_check_done(TargetAxis) == 0)
				{
					Application.DoEvents();
				}

				TempReturn = (int)d2410_set_position(TargetAxis, 0);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ԭ�����淽ʽ
		/// <summary>
		/// ����ԭ�����淽ʽ
		/// ע�⣺�����˶��У���ѡ�����ģʽΪ5ʱ����SetHomeLatchMode��������ԭ���ź����淽ʽ
		/// </summary>
		/// <param name="Enable">ԭ������ʹ��״̬��0����ֹ��2������</param>
		/// <param name="Logic">ԭ�����淽ʽ��0���½������棬1������������</param>
		/// <returns>�������</returns>
		public int SetHomeLatchMode(ushort Enable, ushort Logic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (Enable != 0 || Enable != 2)
				{
					MessageBox.Show("The parameter 'Enable' should be 0 or 2, please revise it.");
					return 1;
				}

				if (Logic != 0)
				{
					Logic = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_homelatch_mode(TargetAxis, Enable, Logic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡԭ�����淽ʽ
		/// <summary>
		/// ��ȡԭ�����淽ʽ
		/// </summary>
		/// <param name="Enable">ԭ������ʹ��״̬��0����ֹ��2������</param>
		/// <param name="Logic">ԭ�����淽ʽ��0���½������棬1������������</param>
		/// <returns>�������</returns>
		public int GetHomeLatchMode(ref ushort Enable, ref ushort Logic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_homelatch_mode(TargetAxis, ref Enable, ref Logic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡԭ�������־
		/// <summary>
		/// ��ȡԭ�������־
		/// </summary>
		/// <returns>ԭ�������־��0��δ������1������</returns>
		public int GetHomeLatchFlag()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_homelatch_flag(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��λԭ�������־
		/// <summary>
		/// ��λԭ�������־
		/// </summary>
		/// <returns>�������</returns>
		public int ResetHomeLatchFlag()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_homelatch_flag(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡԭ������ֵ��ԭ������λ��Ϊָ������λ�ã�
		/// <summary>
		/// ��ȡԭ������ֵ��ԭ������λ��Ϊָ������λ�ã�
		/// </summary>
		/// <returns>ԭ������ֵ</returns>
		public int GetHomeLatchValue()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_homelatch_value(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//ִ�л�ԭ���˶��������̡߳�
		/// <summary>
		/// ִ�л�ԭ���˶��������̡߳�
		/// ע�⣺��ԭ���˶��У���ѡ�����ģʽΪ1~5ʱ��Ҫ����ԭ���ź���Ч��ƽ
		/// </summary>
		/// <param name="SearchHomeMode">��ԭ��ģʽ��1~6��
		/// ��ʽ1��һ�λ���
		/// ��ʽ2��һ�λ���ӻ���
		/// ��ʽ3�����λ���
		/// ��ʽ4��һ�λ�����ټ�1��EZ������л���
		/// ��ʽ5��EZ��������
		/// ��ʽ6��ԭ�㲶�����
		/// </param>
		/// <param name="SearchHomeDirection">��ԭ�㷽ʽ��1���������ԭ�㣬2���������ԭ��</param>
		/// <param name="VelocityMode">��ԭ���ٶȣ�0�����ٻ�ԭ�㣬1�����ٻ�ԭ��</param>
		/// <param name="MinVelocity">��ԭ����ʼ�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">��ԭ������ٶȣ���λ��pulse/s</param>
		/// <param name="TotalAccTime">��ԭ���ܼ���ʱ�䣬��λ��s</param>
		/// <param name="TotalDecTime">��ԭ���ܼ���ʱ�䣬��λ��s</param>
		/// <param name="OrgLogic">ԭ���źŵ���Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="EnableFilter">����/��ֹ�˲����ܣ�0����ֹ��1������</param>
		/// <param name="EZCount">EZ�źų���EZCountָ���Ĵ��������˶�ֹͣ������Mode=5ʱ�ò���������Ч��ȡֵ��Χ��1��16</param>
		/// <param name="EnableLatch">ԭ������ʹ��״̬��0����ֹ��2������</param>
		/// <param name="LatchLogic">ԭ�����淽ʽ��0���½������棬1������������</param>
		public void GoHome(ushort SearchHomeMode, ushort SearchHomeDirection = 1,
			ushort VelocityMode = 0, double MinVelocity = 400, double MaxVelocity = 1000,
			double TotalAccTime = 0.1, double TotalDecTime = 0.1, ushort OrgLogic = 1,
			ushort EnableFilter = 1, ushort EZCount = 1, ushort EnableLatch = 2, ushort LatchLogic = 0)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				//��ԭ��ģʽ��1~6��
				if (SearchHomeMode < 1 || SearchHomeMode > 6)
				{
					MessageBox.Show("The parameter 'SearchHomeMode' should be 1~6, please revise it.");
					return;
				}

				//��ԭ�㷽ʽ��1���������ԭ�㣬2���������ԭ��
				if (SearchHomeDirection < 1 || SearchHomeDirection > 2)
				{
					MessageBox.Show("The parameter 'SearchHomeDirection' should be 1~2, please revise it.");
					return;
				}

				//EZCount ȡֵ��Χ��1��16
				if (EZCount < 1 || EZCount > 16)
				{
					MessageBox.Show("The parameter 'EZCount' should be 1~16, please revise it.");
					return;
				}

				//ԭ������ʹ��״̬��0����ֹ��2������
				if (EnableLatch != 0 && EnableLatch != 2)
				{
					MessageBox.Show("The parameter 'EnableLatch' should be 0 or 2, please revise it.");
					return;
				}

				//ԭ�����淽ʽ��0���½������棬1������������
				if (LatchLogic != 0)
				{
					LatchLogic = 1;
				}

				//ԭ���źŵ���Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч
				if (OrgLogic != 0)
				{
					OrgLogic = 1;
				}

				//��ԭ���ٶȣ�0�����ٻ�ԭ�㣬1�����ٻ�ԭ��
				if (VelocityMode != 0)
				{
					VelocityMode = 1;
				}

				if (DoingSearchHome == true)
				{
					MessageBox.Show("The axis " + (TargetAxis + 1)
						+ " is searching home signal now, please wait until it is done...");
					return;
				}
				else
				{
					DoingSearchHome = true;
				}

				//ע�⣺�����˶��У���ѡ�����ģʽΪ0~4����Ӧ1~5��ʱ���øú�������ԭ���ź���Ч��ƽ
				SearchingHomeMode = SearchHomeMode;
				SearchingHomeDirection = SearchHomeDirection;
				SearchingHomeVelocityMode = VelocityMode;
				SearchingHomeOrgLogic = OrgLogic;
				SearchingHomeEnableFilter = EnableFilter;
				SearchingHomeEZCount = EZCount;
				SearchingHomeMinVelocity = MinVelocity;
				SearchingHomeMaxVelocity = MaxVelocity;

				SearchingHomeAccTime = TotalAccTime;
				SearchingHomeDecTime = TotalDecTime;

				SearchingHomeEnableLatch = EnableLatch;
				SearchingHomeLatchLogic = LatchLogic;

				SearchHomeThread = null;
				SearchHomeThread = new Thread(SearchHomeFunction);
				SearchHomeThread.IsBackground = true;
				SearchHomeThread.Start();

			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return;
			}
		}

		//ִ�л�ԭ��ĺ���
		/// <summary>
		/// ִ�л�ԭ��ĺ���
		/// </summary>
		private void SearchHomeFunction()
		{

			// ��ԭ�㲽��
			//�ڽ��о�ȷ���˶�����֮ǰ����Ҫ�趨�˶�����ϵ��ԭ�㡣�˶�ƽ̨�϶�����ԭ�㴫������Ҳ��Ϊԭ�㿪�أ���
			//Ѱ��ԭ�㿪�ص�λ�ò�����λ����Ϊƽ̨������ԭ�㣬��Ϊ��ԭ���˶���

			//DMC2410C���ƿ����ṩ��6�ֻ�ԭ�㷽ʽ:
			//���з�ʽ1~5�ǲ���ԭ���ƽ״̬�������źţ�
			//��ʽ6���ǲ���ԭ������ź��������źţ�

			//�����ԭ���˶���Ҫ�������£� 

			//1�����û��㷽ʽ1~5����ԭ���˶��� 
			//  1��ʹ��d2410_set_HOME_pin_logic��������ԭ�㿪�ص���Ч��ƽ�� 
			//  2��ʹ��d2410_config_home_mode�������û�ԭ�㷽ʽ�� 
			//  3�����û�ԭ���˶��������ٶ���ʽ�� 
			//  4��ʹ��d2410_home_move�������л�ԭ���˶��� 
			//  5���ص�ԭ���ָ��������������㡣

			//�趨ָ����Ļ�ԭ��ģʽ
			//<param name="axis">ָ�����</param>
			//<param name="mode">��ԭ����ź�ģʽ�� 
			//0��ֻ��home 
			//1����home��EZ����1��EZ�ź� 
			//2��һ�λ���ӻ��� 
			//3�����λ��� 
			//4��EZ�������� 
			//5��ԭ�㲶�����</param>
			//<param name="EZ_count">EZ�źų���EZ_countָ���Ĵ��������˶�ֹͣ��
			//����mode=4ʱ�ò���������Ч��ȡֵ��Χ��1��16</param>
			//Declare Function d2410_config_home_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16) As Int32

			//�����ԭ���˶�
			//<param name="axis">ָ�����</param>
			//<param name="home_mode">��ԭ�㷽ʽ��1���������ԭ�㣬2���������ԭ��</param>
			//<param name="vel_mode">��ԭ���ٶȣ�0�����ٻ�ԭ�㣬1�����ٻ�ԭ��</param>
			//Declare Function d2410_home_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16) As Int32

			//ԭ������
			//����/��ȡԭ�����淽ʽ
			//<param name="axis">ָ�����</param>
			//<param name="enable">ԭ������ʹ��״̬��0����ֹ��2������</param>
			//<param name="logic">ԭ�����淽ʽ��0���½������棬1������������</param>
			//<remarks>ע�⣺�����˶��У���ѡ�����ģʽΪ5ʱ����d2410_set_homelatch_mode��������ԭ���ź����淽ʽ</remarks>
			//Declare Function d2410_set_homelatch_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal logic As Int16) As Int32

			//��λԭ�������־
			//<param name="axis">ָ�����</param>
			//Declare Function d2410_reset_homelatch_flag Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

			//����ORG�źŵ���Ч��ƽ���Լ�����/��ֹ�˲�����
			//<param name="axis">ָ�����</param>
			//<param name="org_logic">ORG�źŵ���Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
			//<param name="filter">����/��ֹ�˲����ܣ�0����ֹ��1������</param>
			//<remarks>ע�⣺�����˶��У���ѡ�����ģʽΪ0~4ʱ���øú�������ԭ���ź���Ч��ƽ</remarks>
			//Declare Function d2410_set_HOME_pin_logic Lib "DMC2410.dll" (ByVal axis As Int16, ByVal org_logic As Int16, _
			//                                                        ByVal filter As Int16) As Int32

			//��ԭ�㷽ʽ
			//DMC2410C�˶����ƿ��ṩ��6�ֻ�ԭ���˶��ķ�ʽ�� 

			//����                                ����
			//d2410_set_HOME_pin_logic         ����ԭ���źŵĵ�ƽ���˲���ʹ��
			//d2410_config_home_mode           ѡ���ԭ��ģʽ
			//d2410_home_move                  ��ָ���ķ�����ٶȷ�ʽ��ʼ��ԭ��
			//d2410_set_homelatch_mode         ����ԭ�����淽ʽ
			//d2410_set_position               ָ���������������

			//ע�⣺ִ����d2410_home_move������ָ����������������Զ����㣻
			//������������ڻ����˶���ɺ󣬵���d2410_set_position����������㡣

			int TempReturn = 0;

			try
			{

				switch (SearchingHomeMode)
				{
					case 1:
						//��ʽ1��һ�λ���
						//�÷�ʽ�Ե��ٻ�ԭ�㣻�ʺ����г̶̡���ȫ��Ҫ��ߵĳ��ϡ�
						//��������Ϊ������ӳ�ʼλ���Ժ㶨���ٶ���ԭ�㷽���˶���������ԭ�㿪��λ�ã�ԭ���źű�������
						//�������ֹͣ������0������ֹͣλ����Ϊԭ��λ�á�

						//����7.1����ʽ1���ٻ�ԭ��
						//d2410_set_HOME_pin_logic 0,0,1           '����0����ԭ���źŵ͵�ƽ��Ч��ʹ���˲����� 
						//d2410_config_home_mode 0,0,0             '����0�������ģʽΪ��ʽ1 
						//d2410_set_profile 0,500,1000,0.1,0.1     '����0�������������ٶȣ��ӡ�����ʱ�� 
						//d2410_home_move 0,2,0                    '����0����Ϊ�������ԭ�㣬�ٶȷ�ʽΪ���ٻ�ԭ�� 
						//While (d2410_check_done(0) = 0)          '����˶�״̬���ȴ���ԭ�㶯����� 
						//DoEvents 
						//Wend 
						//D2410_set_position 0,0                   '����0�����ָ���������������λ��Ϊ0

						TempReturn += (int)d2410_set_HOME_pin_logic(TargetAxis,
							SearchingHomeOrgLogic, SearchingHomeEnableFilter);
						TempReturn += (int)d2410_config_home_mode(TargetAxis,
							SearchingHomeMode, SearchingHomeEZCount);
						TempReturn += (int)d2410_set_profile(TargetAxis,
							SearchingHomeMinVelocity, SearchingHomeMaxVelocity,
							SearchingHomeAccTime, SearchingHomeDecTime);
						TempReturn += (int)d2410_home_move(TargetAxis,
							SearchingHomeMode, SearchingHomeVelocityMode);
						while (d2410_check_done(TargetAxis) == 0)
						{
							Application.DoEvents();
						}
						TempReturn += (int)d2410_set_position(TargetAxis, 0);

						break;

					case 2:
						//��ʽ2��һ�λ���ӻ��� 
						//�÷�ʽ�Ƚ��з�ʽ1�˶�����ɺ��ٷ������ԭ�㿪�صı�Եλ�ã���ԭ���źŵ�һ����Ч��ʱ�򣬵������ֹͣ��
						//��ֹͣλ����Ϊԭ��λ�á�
						TempReturn = (int)d2410_set_HOME_pin_logic(TargetAxis,
							SearchingHomeOrgLogic, SearchingHomeEnableFilter);
						TempReturn = (int)d2410_config_home_mode(TargetAxis,
							SearchingHomeMode, SearchingHomeEZCount);
						TempReturn = (int)d2410_set_profile(TargetAxis,
							SearchingHomeMinVelocity, SearchingHomeMaxVelocity,
							SearchingHomeAccTime, SearchingHomeDecTime);
						TempReturn = (int)d2410_home_move(TargetAxis,
							SearchingHomeMode, SearchingHomeVelocityMode);
						while (d2410_check_done(TargetAxis) == 0)
						{
							Application.DoEvents();
						}
						TempReturn = (int)d2410_set_position(TargetAxis, 0);
						break;

					case 3:
						//��ʽ3�����λ��� 
						//'�÷�ʽΪ��ʽ1�ͷ�ʽ2����ϡ��Ƚ��з�ʽ2�Ļ���ӷ��ң�
						//��ɺ��ٽ��з�ʽ1��һ�λ��㡣

						TempReturn = (int)d2410_set_HOME_pin_logic(TargetAxis,
							SearchingHomeOrgLogic, SearchingHomeEnableFilter);
						TempReturn = (int)d2410_config_home_mode(TargetAxis,
							SearchingHomeMode, SearchingHomeEZCount);
						TempReturn = (int)d2410_set_profile(TargetAxis,
							SearchingHomeMinVelocity, SearchingHomeMaxVelocity,
							SearchingHomeAccTime, SearchingHomeDecTime);
						TempReturn = (int)d2410_home_move(TargetAxis,
							SearchingHomeMode, SearchingHomeVelocityMode);
						while (d2410_check_done(TargetAxis) == 0)
						{
							Application.DoEvents();
						}
						TempReturn = (int)d2410_set_position(TargetAxis, 0);

						break;

					case 4:
						//��ʽ4��һ�λ�����ټ�1��EZ������л��� 
						//�÷�ʽ�ڻ�ԭ���˶������У����ҵ�ԭ���źź󣬻�Ҫ�ȴ������EZ�źų��֣���ʱ���ֹͣ��
						//����֮ǰ��Ҫ���EZ״̬����EZ�źŵ���ʱ���������ֹͣ��

						TempReturn = (int)d2410_set_HOME_pin_logic(TargetAxis,
							SearchingHomeOrgLogic, SearchingHomeEnableFilter);
						TempReturn = (int)d2410_config_home_mode(TargetAxis,
							SearchingHomeMode, SearchingHomeEZCount);
						TempReturn = (int)d2410_set_profile(TargetAxis,
							SearchingHomeMinVelocity, SearchingHomeMaxVelocity,
							SearchingHomeAccTime, SearchingHomeDecTime);
						TempReturn = (int)d2410_home_move(TargetAxis,
							SearchingHomeMode, SearchingHomeVelocityMode);
						while (d2410_check_done(TargetAxis) == 0)
						{
							Application.DoEvents();
						}
						TempReturn = (int)d2410_set_position(TargetAxis, 0);

						break;

					case 5:
						//��ʽ5��EZ�������� 
						//�÷�ʽ�ڻ�ԭ���˶������У���EZ �źż�������ָ����������ʱ���ֹͣ��
						TempReturn = (int)d2410_set_HOME_pin_logic(TargetAxis,
							SearchingHomeOrgLogic, SearchingHomeEnableFilter);
						TempReturn = (int)d2410_config_home_mode(TargetAxis,
							SearchingHomeMode, SearchingHomeEZCount);
						TempReturn = (int)d2410_set_profile(TargetAxis,
							SearchingHomeMinVelocity, SearchingHomeMaxVelocity,
							SearchingHomeAccTime, SearchingHomeDecTime);
						TempReturn = (int)d2410_home_move(TargetAxis,
							SearchingHomeMode, SearchingHomeVelocityMode);
						while (d2410_check_done(TargetAxis) == 0)
						{
							Application.DoEvents();
						}
						TempReturn = (int)d2410_set_position(TargetAxis, 0);

						break;

					case 6:
						//2�����û��㷽ʽ6����ԭ���˶��� 
						//  1��ʹ��d2410_set_homelatch_mode��������ԭ���ź����淽ʽ�� 
						//  2��ʹ��d2410_config_home_mode�������û�ԭ�㷽ʽ�� 
						//  3�����û�ԭ���˶��������ٶ���ʽ�� 
						//  4��ʹ��d2410_home_move�������л�ԭ���˶��� 
						//  5���ص�ԭ���ָ��������������㡣

						//��ʽ6��ԭ�㲶�����
						//�÷�ʽ�ڻ�ԭ���˶������У���ԭ�㲶���ź���Чʱ���˶����ٵ�ֹͣ��Ȼ����ص�����λ�á�
						//������ԭ�㲶�����ģʽ��ʱ��ԭ���źŵĳ�ʼ״̬�Ի����˶�û��Ӱ�죬�û���ģʽ���õ��Ǳ��ش�����
						//ÿ�������û����˶���ʱ��ԭ�������־���Զ������ 
						//ע�⣺�ڻ��㷽ʽ6�У�ԭ������λ��Ϊָ������λ�á�

						//����7.2����ʽ6���ٻ�ԭ��
						//d2410_set_homelatch_mode 0,2,0           '����0����ԭ�����淽ʽΪ�½������� 
						//d2410_config_home_mode 0,5,0             '����0�������ģʽΪ��ʽ6 
						//d2410_set_profile 0,500,1000,0.1,0.1     '����0�������������ٶȣ��ӡ�����ʱ�� 
						//d2410_home_move 0,2,0                    '����0����Ϊ�������ԭ�㣬�ٶȷ�ʽΪ���ٻ�ԭ�� 
						//While (d2410_check_done(0) = 0)          '����˶�״̬���ȴ���ԭ�㶯����� 
						//DoEvents 
						//Wend 
						//D2410_set_position 0,0                   '����0�����ָ���������������λ��Ϊ0

						TempReturn = (int)d2410_set_homelatch_mode(TargetAxis,
							SearchingHomeEnableLatch, SearchingHomeLatchLogic);
						TempReturn = (int)d2410_config_home_mode(TargetAxis,
							SearchingHomeMode, SearchingHomeEZCount);
						TempReturn = (int)d2410_set_profile(TargetAxis,
							SearchingHomeMinVelocity, SearchingHomeMaxVelocity,
							SearchingHomeAccTime, SearchingHomeDecTime);
						TempReturn = (int)d2410_home_move(TargetAxis,
							SearchingHomeMode, SearchingHomeVelocityMode);

						while (d2410_check_done(TargetAxis) == 0)
						{
							Application.DoEvents();
						}
						TempReturn = (int)d2410_set_position(TargetAxis, 0);

						break;
				}

				DoingSearchHome = false;
				return;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				DoingSearchHome = false;
				return;
			}
		}

		#endregion

		#region "ר���ź����ú���"

		//��ȡAlarm����Ч��ƽ���乤����ʽ
		/// <summary>
		/// ��ȡAlarm����Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="AlarmLogic">Alarm�źŵ�������Ч��ƽ��
		/// 0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="AlarmStopMode">Alarm�źŵ��ƶ���ʽ��
		/// 0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns>�������</returns>
		public int GetAlarmMode(ref ushort AlarmLogic, ref ushort AlarmStopMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_config_ALM_PIN(TargetAxis,
					ref AlarmLogic, ref AlarmStopMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ALM����Ч��ƽ���乤����ʽ
		/// <summary>
		/// ����ALM����Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="AlarmLogic">Alarm�źŵ�������Ч��ƽ��
		/// 0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="AlarmStopMode">Alarm�źŵ��ƶ���ʽ��
		/// 0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns>�������</returns>
		public int SetAlarmMode(ushort AlarmLogic, ushort AlarmStopMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (AlarmLogic != 0)
				{
					AlarmLogic = 1;
				}

				if (AlarmStopMode != 0)
				{
					AlarmStopMode = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_ALM_PIN(TargetAxis,
					AlarmLogic, AlarmStopMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//SetAlarmMode��չ����������ALMʹ��״̬�����Ʒ�ʽ���趨
		/// <summary>
		/// SetAlarmMode��չ����������ALMʹ��״̬�����Ʒ�ʽ���趨
		/// </summary>
		/// <param name="AlarmEnabled">ALMʹ��״̬��0����ֹ��1������</param>
		/// <param name="AlarmLogic">ALM�źŵ�������Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="AlarmAll">ALM�źſ��Ʒ�ʽ��0��ֹͣ���ᣬ1��ֹͣ������</param>
		/// <param name="AlarmStopMode">ALM�źŵ��ƶ���ʽ��0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns>�������</returns>
		public int SetAlarmModeExtern(ushort AlarmEnabled, ushort AlarmLogic,
			ushort AlarmAll, ushort AlarmStopMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (AlarmEnabled != 0)
				{
					AlarmEnabled = 1;
				}

				if (AlarmLogic != 0)
				{
					AlarmLogic = 1;
				}

				if (AlarmStopMode != 0)
				{
					AlarmStopMode = 1;
				}

				if (AlarmAll != 0)
				{
					AlarmAll = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_ALM_PIN_Extern(TargetAxis,
					AlarmEnabled, AlarmLogic, AlarmAll, AlarmStopMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//GetAlarmMode��չ����������Alarmʹ��״̬�����Ʒ�ʽ���趨
		/// <summary>
		/// GetAlarmMode��չ����������Alarmʹ��״̬�����Ʒ�ʽ���趨
		/// </summary>
		/// <param name="AlarmEnabled">Alarmʹ��״̬��0����ֹ��1������</param>
		/// <param name="AlarmLogic">Alarm�źŵ�������Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="AlarmAll">Alarm�źſ��Ʒ�ʽ��0��ֹͣ���ᣬ1��ֹͣ������</param>
		/// <param name="AlarmStopMode">Alarm�źŵ��ƶ���ʽ��0������ֹͣ��1������ֹͣ(����)</param>
		/// <returns>�������</returns>
		public int GetAlarmModeExtern(ref ushort AlarmEnabled, ref ushort AlarmLogic,
			ref ushort AlarmAll, ref ushort AlarmStopMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_config_ALM_PIN_Extern(TargetAxis,
					ref AlarmEnabled, ref AlarmLogic, ref AlarmAll, ref AlarmStopMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����EL�źŵ�ʹ��״̬
		/// <summary>
		/// ����EL�źŵ�ʹ��״̬
		/// </summary>
		/// <param name="Enable">EL�źŵ�ʹ��״̬��0����ʹ�ܣ�1��ʹ��</param>
		/// <returns>�������</returns>
		public int EnableELPin(ushort Enable)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (Enable != 0)
				{
					Enable = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_Enable_EL_PIN(TargetAxis, Enable);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����EL�źŵ���Ч��ƽ���ƶ���ʽ
		/// <summary>
		/// ����EL�źŵ���Ч��ƽ���ƶ���ʽ
		/// </summary>
		/// <param name="ELMode">EL��Ч��ƽ���ƶ���ʽ��
		/// 0������ͣ������Ч
		/// 1������ͣ������Ч
		/// 2������ͣ������Ч
		/// 3������ͣ������Ч
		/// </param>
		/// <returns>�������</returns>
		public int SetELMode(ushort ELMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (ELMode < 0 || ELMode > 3)
				{
					MessageBox.Show("The parameter 'ELMode' should be 0~3, please revise it.");
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_EL_MODE(TargetAxis, ELMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ԭ��ORG�źŵ���Ч��ƽ���Լ�����/��ֹ�˲�����
		/// <summary>
		/// ����ԭ��ORG�źŵ���Ч��ƽ���Լ�����/��ֹ�˲�����
		/// ע�⣺�����˶��У���ѡ�����ģʽΪ0~4ʱ���øú�������ԭ���ź���Ч��ƽ
		/// </summary>
		/// <param name="OrgLogic">ORG�źŵ���Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
		/// <param name="EnableFilter">����/��ֹ�˲����ܣ�0����ֹ��1������</param>
		/// <returns>�������</returns>
		public int SetHomeSignalLogic(ushort OrgLogic, ushort EnableFilter)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (OrgLogic != 0)
				{
					OrgLogic = 1;
				}

				if (EnableFilter != 0)
				{
					EnableFilter = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_HOME_pin_logic(TargetAxis,
					OrgLogic, EnableFilter);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ����ŷ�ʹ�ܶ��ӵĵ�ƽ״̬
		/// <summary>
		/// ��ȡ����ŷ�ʹ�ܶ��ӵĵ�ƽ״̬
		/// </summary>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		public int GetServoOnSignalStatus()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_SEVON_PIN(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��������ŷ�ʹ��
		/// <summary>
		/// ��������ŷ�ʹ��
		/// </summary>
		/// <returns></returns>
		public int ServoOn()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_SEVON_PIN(TargetAxis, 1);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//���������ŷ�ʹ�ܶ��ӵĿ���
		/// <summary>
		/// ���������ŷ�ʹ�ܶ��ӵĿ���
		/// </summary>
		/// <param name="SetOn">�趨�ܽŵ�ƽ״̬��0���ͣ�1����</param>
		/// <returns>�������</returns>
		public int ServoOn(ushort SetOn)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (SetOn != 0)
				{
					SetOn = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_SEVON_PIN(TargetAxis, SetOn);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�ر�����ŷ�ʹ��
		/// <summary>
		/// �ر�����ŷ�ʹ��
		/// </summary>
		/// <returns></returns>
		public int ServoOff()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_SEVON_PIN(TargetAxis, 0);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��ġ��ŷ�׼���á����ӵĵ�ƽ״̬
		/// <summary>
		/// ��ȡ��ġ��ŷ�׼���á����ӵĵ�ƽ״̬
		/// </summary>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		public int GetServoReadyStatus()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_RDY_PIN(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//���ָ�λ��Pulseλ�á�
		/// <summary>
		/// ���ָ�λ��Pulseλ�á����ָ�λ��Pulseλ�á�
		/// </summary>
		/// <returns>0��ָ��λ�����趨��Ŀ��λ�õ�����֮�⣻
		/// 1��ָ��λ�����趨��Ŀ��λ�õ�����֮��
		/// </returns>
		public int VerifyMotionIsDoneByPulse()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_check_success_pulse(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//���ָ�λ��������λ�á�
		/// <summary>
		/// ���ָ�λ��������λ�á�
		/// </summary>
		/// <returns>0��������λ�����趨��Ŀ��λ�õ�����֮�⣻
		/// 1��������λ�����趨��Ŀ��λ�õ�����֮��
		/// </returns>
		public int VerifyMotionIsDonebByEncoder()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_check_success_encoder(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//Emergency�ź����ã���ͣ�ź���Ч�������ֹͣ������
		/// <summary>
		/// Emergency�ź����ã���ͣ�ź���Ч�������ֹͣ������
		/// </summary>
		/// <param name="TargetCardNo">����, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="EnableEmergency">0����Ч��1����Ч</param>
		/// <param name="EmergencySignalLogic">0������Ч��1������Ч</param>
		/// <returns>�������</returns>
		public int SetEmergencySignal(ushort TargetCardNo, ushort EnableEmergency,
			ushort EmergencySignalLogic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (EnableEmergency != 0)
				{
					EnableEmergency = 1;
				}

				if (EmergencySignalLogic != 0)
				{
					EmergencySignalLogic = 1;
				}

				if (TargetCardNo > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_EMG_PIN(TargetCardNo,
					EnableEmergency, EmergencySignalLogic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//Emergency�ź����ã���ͣ�ź���Ч�������ֹͣ������
		/// <summary>
		/// Emergency�ź����ã���ͣ�ź���Ч�������ֹͣ������
		/// </summary>
		/// <param name="EnableEmergency">0����Ч��1����Ч</param>
		/// <param name="EmergencySignalLogic">0������Ч��1������Ч</param>
		/// <returns>�������</returns>
		public int SetEmergencySignal(ushort EnableEmergency,
			ushort EmergencySignalLogic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (EnableEmergency != 0)
				{
					EnableEmergency = 1;
				}

				if (EmergencySignalLogic != 0)
				{
					EmergencySignalLogic = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_EMG_PIN(TargetCard,
					EnableEmergency, EmergencySignalLogic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "λ�ñȽ��������"

		//λ�ñȽϹ��ܵ�ʵ��
		//DMC2410C�˶����ƿ��ṩ��λ�ñȽϹ��ܣ�λ�ñȽϵ�һ�㲽���ǣ� 
		//   1�����ñȽ����� 
		//   2�����λ�ñȽ����ݣ�
		//   3����ӱȽ�λ�õ㣻
		//   4����ʼ�˶����鿴�Ƚ�״̬��

		//����λ�ñȽϹ���
		//DMC2410C���ṩ���������λ�ñȽϣ�ÿ����඼�������8���Ƚϵ㡣����λ�ñȽϵĴ�����ʱʱ��С��1ms��

		//����λ�ñȽ���غ���˵��
		//d2410_compare_config_Extern               '���ñȽ�������
		//d2410_compare_clear_points_Extern         '������бȽϵ�
		//d2410_compare_add_point_Extern            '��ӱȽϵ�
		//d2410_compare_get_current_point_Extern    '��ȡ��ǰ�Ƚϵ�λ��
		//d2410_compare_get_points_runned_Extern    '��ѯ�Ѿ��ȽϹ��ĵ����
		//d2410_compare_get_points_remained_Extern  '��ѯ���Լ���ıȽϵ�����

		//ע�⣺1������λ�ñȽϹ�������Ƚ϶��У�ÿ����е�λ�ñȽ϶��Ƕ������еģ� 
		//      2��ִ��λ�ñȽ�ʱ��ÿ���Ƚϵ�Ĵ����ǰ�����ӵıȽϵ�˳��ִ�еģ�
		//         �������һ���Ƚϵ�û�б������Ƚ϶�������ô����ıȽϵ��ǲ��������õġ�

		//��7.11������λ�ñȽ� 
		//Dim MyCardNo,Myqueue, Myenable, Myaxis, Mycmp_source As Integer 
		//Dim Mydir,Myaction As Integer 
		//Dim Mypos,Myactpara As Long 
		//MyCardNo = 0             '���� 
		//Myqueue = 0              '���ñȽ����к�Ϊ0 
		//Myaxis = 0               '���Ϊ0 
		//Myenable = 1             '���ñȽ���ʹ�� 
		//Mycmp_source = 0         '���ñȽ�ԴΪָ��λ�� 
		//d2410_compare_config_Extern MyCardNo,Myqueue, Myenable, Myaxis,Mycmp_source '���ñȽ��� 
		//d2410_compare_clear_points_Extern MyCardNo,Myqueue                          '����Ƚϵ� 
		//Mypos = 8000                 '���ñȽ�λ��Ϊ8000pulse 
		//Mydir = 1                    '���ñȽϷ���Ϊ���ڵ��� 
		//Myaction = 3                 '��������ΪIO��ƽȡ�� 
		//Myactpara = 1                '�������IO�˿�1�������� 
		//d2410_set_position MyAxis, 0 '��ǰλ����Ϊ��� 
		//d2410_compare_add_point_Extern MyCardNo,Myqueue,Mypos,Mydir,Myaction,Myactpara '��ӱȽϵ� 
		//d2410_ex_t_pmove Myaxis,10000,0     'ִ�ж����˶���λ��Ϊ10000pulse���������ģʽ


		/// <summary>
		/// ����λ��������Deviation��
		/// </summary>
		/// <param name="EncoderFactor">������ϵ��(���嵱��)</param>
		/// <param name="Deviation">λ������
		/// ˵�������赱ǰ������������Ϊ200��ָ��������Ϊ1002�� ��������Ϊ2��������ϵ����Ϊ5��
		/// �������£� 200*5=1000,1000-1002=-2,��������Χ[-2,2]֮�ڣ���ʱ��Ϊ��������λ��
		/// </param>
		/// <returns>�������</returns>
		public int SetPositionDeviation(double EncoderFactor, int Deviation)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_factor_error(TargetAxis,
					EncoderFactor, Deviation);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡλ��������Deviation��
		/// <summary>
		/// ��ȡλ��������Deviation��
		/// </summary>
		/// <param name="EncoderFactor">������ϵ��(���嵱��)</param>
		/// <param name="Deviation">λ������</param>
		/// <returns>�������</returns>
		public int GetPositionDeviation(ref double EncoderFactor, ref int Deviation)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_factor_error(TargetAxis, ref
					EncoderFactor, ref Deviation);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ָ�����ƿ�����Ƚ�������
		/// <summary>
		/// ����ָ�����ƿ�����Ƚ�������
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <param name="EnableCompare">1��ʹ�ܱȽϹ��ܣ�0����ֹ�ȽϹ���</param>
		/// <param name="TargetAxisNumber">TargetAxisNumber���</param>
		/// <param name="CompareSource">�Ƚ�Դ��0���Ƚ�ָ��λ�ã�1���Ƚϱ�����λ��</param>
		/// <returns>�������</returns>
		public int SetCompareExtern(ushort TargetCardNumber, ushort QueueNumber,
			ushort EnableCompare, ushort TargetAxisNumber, ushort CompareSource)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				//���࿨���С�
				//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
				//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
				//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				//�����ź���ŵĶ�Ӧ��ϵΪ���� 
				// 0�ſ���Ӧ0~3���᣻1�ſ���Ӧ4~7���᣻n�ſ���Ӧ4n~ 4*��n+1��-1���ᡣ
				//��ʹ��ϰ�ߴ�1��ʼ�������������ڵ��ú���ʱ��Ҫ��ȥ1������ȷ����š���
				if (TargetAxisNumber > AvailableCardQty * 4
					|| TargetAxisNumber < (AvailableCardQty * 4 - 3))
				{
					MessageBox.Show("The value for target axis 'TargetAxisNumber' should be : "
						+ (AvailableCardQty * 4 - 3) + "~" + (AvailableCardQty * 4)
						+ " ,please revise the parameter and retry.\r\n"
						+ "Ŀ����Ų��� 'TargetAxisNumber' ȡֵ��Χ��"
						+ (AvailableCardQty * 4 - 3) + "~" + (AvailableCardQty * 4)
						+ "���޸Ĳ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				if (EnableCompare != 0)
				{
					EnableCompare = 1;
				}

				if (CompareSource != 0)
				{
					CompareSource = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_config_Extern((ushort)(TargetCardNumber - 1),
					QueueNumber, EnableCompare, (ushort)(TargetAxisNumber - 1), CompareSource);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//���õ�ǰ���ƿ��ĵ�ǰ��Ƚ�������
		/// <summary>
		/// ���õ�ǰ���ƿ��ĵ�ǰ��Ƚ�������
		/// </summary>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <param name="EnableCompare">1��ʹ�ܱȽϹ��ܣ�0����ֹ�ȽϹ���</param>
		/// <param name="CompareSource">�Ƚ�Դ��0���Ƚ�ָ��λ�ã�1���Ƚϱ�����λ��</param>
		/// <returns>�������</returns>
		public int SetCompareExtern(ushort QueueNumber, ushort EnableCompare,
			ushort CompareSource)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				if (EnableCompare != 0)
				{
					EnableCompare = 1;
				}

				if (CompareSource != 0)
				{
					CompareSource = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_config_Extern(TargetCard,
					QueueNumber, EnableCompare, TargetAxis, CompareSource);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡָ�����ƿ�����Ƚ�������
		/// <summary>
		/// ��ȡָ�����ƿ�����Ƚ�������
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <param name="EnableCompare">1��ʹ�ܱȽϹ��ܣ�0����ֹ�ȽϹ���</param>
		/// <param name="TargetAxisNumber">Ŀ�����</param>
		/// <param name="CompareSource">�Ƚ�Դ��0���Ƚ�ָ��λ�ã�1���Ƚϱ�����λ��</param>
		/// <returns>�������</returns>
		public int GetCompareSettingExtern(ushort TargetCardNumber, ushort QueueNumber,
			ref ushort EnableCompare, ref ushort TargetAxisNumber, ref ushort CompareSource)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				//���࿨���С�
				//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
				//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
				//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				//�����ź���ŵĶ�Ӧ��ϵΪ���� 
				// 0�ſ���Ӧ0~3���᣻1�ſ���Ӧ4~7���᣻n�ſ���Ӧ4n~ 4*��n+1��-1���ᡣ
				//��ʹ��ϰ�ߴ�1��ʼ�������������ڵ��ú���ʱ��Ҫ��ȥ1������ȷ����š���
				if (TargetAxisNumber > AvailableCardQty * 4
					|| TargetAxisNumber < (AvailableCardQty * 4 - 3))
				{
					MessageBox.Show("The value for target axis 'TargetAxisNumber' should be : "
						+ (AvailableCardQty * 4 - 3) + "~" + (AvailableCardQty * 4)
						+ " ,please revise the parameter and retry.\r\n"
						+ "Ŀ����Ų��� 'TargetAxisNumber' ȡֵ��Χ��"
						+ (AvailableCardQty * 4 - 3) + "~" + (AvailableCardQty * 4)
						+ "���޸Ĳ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetAxisNumber = (ushort)(TargetAxisNumber - 1);

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_config_Extern((ushort)(TargetCardNumber - 1),
					QueueNumber, ref EnableCompare, ref TargetAxisNumber,
					ref CompareSource);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��ǰ���ƿ��ĵ�ǰ��Ƚ�������
		/// <summary>
		/// ��ȡ��ǰ���ƿ��ĵ�ǰ��Ƚ�������
		/// </summary>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <param name="EnableCompare">1��ʹ�ܱȽϹ��ܣ�0����ֹ�ȽϹ���</param>
		/// <param name="CompareSource">�Ƚ�Դ��0���Ƚ�ָ��λ�ã�1���Ƚϱ�����λ��</param>
		/// <returns>�������</returns>
		public int GetCompareSettingExtern(ushort QueueNumber,
			ref ushort EnableCompare, ref ushort CompareSource)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_config_Extern(TargetCard,
					QueueNumber, ref EnableCompare, ref TargetAxis,
					ref CompareSource);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//���ָ�����ƿ������бȽϵ�
		/// <summary>
		/// ���ָ�����ƿ������бȽϵ�
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>�������</returns>
		public int ClearAllComparePos(ushort TargetCardNumber, ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				//���࿨���С�
				//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
				//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
				//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_clear_points_Extern(TargetCardNumber, QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�����ǰ���ƿ������бȽϵ�
		/// <summary>
		/// �����ǰ���ƿ������бȽϵ�
		/// </summary>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>�������</returns>
		public int ClearAllComparePos(ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_clear_points_Extern(TargetCard, QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡָ�����ƿ����ᵱǰ�Ƚϵ�λ��
		/// <summary>
		/// ��ȡָ�����ƿ����ᵱǰ�Ƚϵ�λ��
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>��ǰ�Ƚϵ�λ��</returns>
		public int GetComparePosForCurrentPointExtern(ushort TargetCardNumber,
			ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				//���࿨���С�
				//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
				//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
				//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_current_point_Extern(TargetCardNumber,
					QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡ��ǰ���ƿ����ᵱǰ�Ƚϵ�λ��
		/// <summary>
		/// ��ȡ��ǰ���ƿ��ĵ�ǰ�ᵱǰ�Ƚϵ�λ��
		/// </summary>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>��ǰ�Ƚϵ�λ��</returns>
		public int GetComparePosForCurrentPointExtern(ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_current_point_Extern(TargetCard,
					QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ѯָ�����ƿ��Ѿ��ȽϹ��ĵ����
		/// <summary>
		/// ��ѯָ�����ƿ��Ѿ��ȽϹ��ĵ����
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>�Ѿ��ȽϹ��ıȽϵ������</returns>
		public int GetQtyOfComparedPos(ushort TargetCardNumber,
			ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				//���࿨���С�
				//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
				//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
				//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_points_runned_Extern(TargetCardNumber,
					QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ѯ��ǰ���ƿ��Ѿ��ȽϹ��ĵ����
		/// <summary>
		/// ��ѯ��ǰ���ƿ��Ѿ��ȽϹ��ĵ����
		/// </summary>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>�Ѿ��ȽϹ��ıȽϵ������</returns>
		public int GetQtyOfComparedPos(ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_points_runned_Extern(TargetCard,
					QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ѯָ�����ƿ����Լ���ıȽϵ�����
		/// <summary>
		/// ��ѯָ�����ƿ����Լ���ıȽϵ�����
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>ʣ����õıȽϵ�����</returns>
		public int GetRemainQtyOfComparedPos(ushort TargetCardNumber,
			ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				//���࿨���С�
				//DMC2410C�˶����ƿ�����������֧�����8��DMC2410C��ͬʱ��������ˣ�һ̨PC������ͬʱ���ƶ��32�����ͬʱ�˶��� 
				//DMC2410C��֧�ּ��弴��ģʽ���û��ɲ���ȥ����������ÿ��Ļ���ַ��IRQ�ж�ֵ����ʹ�ö���˶����ƿ�ʱ������Ҫ
				//���˶����ƿ��ϵĲ��뿪�����ÿ��ţ�ϵͳ������ϵͳBIOSΪ��Ӧ�Ŀ��Զ���������ռ䡣 

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_points_remained_Extern(TargetCardNumber,
					QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ѯ��ǰ���ƿ����Լ���ıȽϵ�����
		/// <summary>
		/// ��ѯ��ǰ���ƿ����Լ���ıȽϵ�����
		/// </summary>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <returns>ʣ����õıȽϵ�����</returns>
		public int GetRemainQtyOfComparedPos(ushort QueueNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_get_points_remained_Extern(TargetCard,
					QueueNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//Ϊָ�����ƿ���ӱȽϵ�
		/// <summary>
		/// Ϊָ�����ƿ���ӱȽϵ�
		/// action:1 , actpara: IO��, ����: IO��Ϊ�͵�ƽ
		/// action:2 , actpara: IO��, ����: IO��Ϊ�ߵ�ƽ
		/// action:3 , actpara: IO��, ����: ȡ��IO
		/// action:5 , actpara: IO��, ����: ���100us ����
		/// action:6 , actpara: IO��, ����: ���1ms ����
		/// action:7 , actpara: IO��, ����: ���10ms ����
		/// action:8 , actpara: IO��, ����: ���100ms ����
		/// action:11 , actpara: �ٶ�ֵ, ����: ��ǰ�����
		/// action:13 , actpara: ���, ����: ָֹͣ����
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <param name="Position">λ������</param>
		/// <param name="Direction">�ȽϷ���0��С�ڵ��ڣ�1�����ڵ���</param>
		/// <param name="Action">�Ƚϵ㴥������</param>
		/// <param name="ComparePosTriggerPara">�Ƚϵ㴥�����ܲ���</param>
		/// <returns>�������</returns>
		public int AddComparePointExtern(ushort TargetCardNumber,
			ushort QueueNumber, UInt32 Position, ushort Direction,
			ushort Action, UInt32 ComparePosTriggerPara)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				if (Direction != 0)
				{
					Direction = 1;
				}

				if (Action < 1 || Action == 4
					|| (Action > 8 && Action < 11)
					|| Action == 12
					|| Action > 13)
				{
					MessageBox.Show("The parameter 'Action' should be 1~3,5~8,11,13, please revise it and retry.");
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_add_point_Extern(TargetCardNumber,
					QueueNumber, Position, Direction, Action, ComparePosTriggerPara);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//Ϊ��ǰ���ƿ���ӱȽϵ�
		/// <summary>
		/// Ϊ��ǰ���ƿ���ӱȽϵ�
		/// action:1 , actpara: IO��, ����: IO��Ϊ�͵�ƽ
		/// action:2 , actpara: IO��, ����: IO��Ϊ�ߵ�ƽ
		/// action:3 , actpara: IO��, ����: ȡ��IO
		/// action:5 , actpara: IO��, ����: ���100us ����
		/// action:6 , actpara: IO��, ����: ���1ms ����
		/// action:7 , actpara: IO��, ����: ���10ms ����
		/// action:8 , actpara: IO��, ����: ���100ms ����
		/// action:11 , actpara: �ٶ�ֵ, ����: ��ǰ�����
		/// action:13 , actpara: ���, ����: ָֹͣ����
		/// </summary>
		/// <param name="QueueNumber">�Ƚ϶��кţ�0��1</param>
		/// <param name="Position">λ������</param>
		/// <param name="Direction">�ȽϷ���0��С�ڵ��ڣ�1�����ڵ���</param>
		/// <param name="Action">�Ƚϵ㴥������</param>
		/// <param name="ComparePosTriggerPara">�Ƚϵ㴥�����ܲ���</param>
		/// <returns>�������</returns>
		public int AddComparePointExtern(ushort QueueNumber,
			UInt32 Position, ushort Direction, ushort Action,
			UInt32 ComparePosTriggerPara)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (QueueNumber != 0)
				{
					QueueNumber = 1;
				}

				if (Direction != 0)
				{
					Direction = 1;
				}

				if (Action < 1 || Action == 4
					|| (Action > 8 && Action < 11)
					|| Action == 12
					|| Action > 13)
				{
					MessageBox.Show("The parameter 'Action' should be 1~3,5~8,11,13, please revise it and retry.");
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_compare_add_point_Extern(TargetCard,
					QueueNumber, Position, Direction, Action, ComparePosTriggerPara);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "����λ�ñȽ�"

		//����λ�ñȽϹ���
		//DMC2410C���ƿ�Ϊÿ�����ṩ��һ������λ�ñȽϡ�����λ�ñȽϻ����޴�����ʱʱ��
		//��������ʱ����ָ�������ʱ�䣩��

		//����λ�ñȽ���غ���˵��
		//d2410_config_CMP_PIN           '���ø���λ�ñȽ���
		//d2410_read_CMP_PIN             '��ȡ����λ�ñȽ������״̬

		//ע�⣺ÿ���λ�ñȽ϶��Ƕ������еģ�����λ�ñȽ���ʱֻ֧�ַ���λ�ñȽϡ�

		//��7.12������λ�ñȽ� 
		//Dim Myaxis,Mycmp_enable,MyCMP_logic As Integer 
		//Dim Mycmp_pos As Long 
		//Myaxis = 0                         '��� 
		//Mycmp_enable = 1                   'CMPʹ�� 
		//Mycmp_pos = 8000                   'CMP�Ƚ�λ��Ϊ8000pulse 
		//MyCMP_logic = 0                    'CMP����͵�ƽ�������ź� 
		//d2410_config_CMP_PIN Myaxis, Mycmp_enable, Mycmp_pos, MyCMP_logic      '���ñȽ�����0���ᣬ�Ƚ�λ��Ϊ8000pulse��
		//                                                                        '����ʱ����ΪCMP����͵�ƽ�������ź� 
		//d2410_ex_t_pmove Myaxis,10000,1       'ִ�ж����˶���λ��Ϊ10000pulse����������ģʽ

		/// <summary>
		/// ���ø���λ�ñȽ���
		/// ע�⣺������CMP�Ƚ�������ӦCMP����ڵĵ�ƽ���Ϊ�����õĵ�ƽ�෴��
		/// ��λ�ô���ʱ��CMP�˿ڻ����һ�������ź�(1~2ms)��
		/// </summary>
		/// <param name="EnableCompare">ʹ��״̬��0����ֹ��1��ʹ��</param>
		/// <param name="ComparePos">�Ƚ�λ��ֵ</param>
		/// <param name="CompareLogic">CMP�����Ч��ƽ��0���͵�ƽ��1���ߵ�ƽ</param>
		/// <returns>�������</returns>
		public int SetHighSpeedPosCompare(ushort EnableCompare,
			int ComparePos, ushort CompareLogic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (EnableCompare != 0)
				{
					EnableCompare = 1;
				}

				if (CompareLogic != 0)
				{
					CompareLogic = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_CMP_PIN(TargetAxis,
					EnableCompare, ComparePos, CompareLogic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ����λ�ñȽ���
		/// <summary>
		/// ��ȡ����λ�ñȽ���
		/// </summary>
		/// <param name="EnableCompare">ʹ��״̬��0����ֹ��1��ʹ��</param>
		/// <param name="ComparePos">�Ƚ�λ��ֵ</param>
		/// <param name="CompareLogic">CMP�����Ч��ƽ��0���͵�ƽ��1���ߵ�ƽ</param>
		/// <returns>�������</returns>
		public int GetHighSpeedPosCompare(ref ushort EnableCompare,
			ref int ComparePos, ref ushort CompareLogic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_config_CMP_PIN(TargetAxis,
					ref EnableCompare, ref ComparePos, ref CompareLogic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ����λ�ñȽ������״̬
		/// <summary>
		/// ��ȡ����λ�ñȽ������״̬
		/// </summary>
		/// <returns>1-�ߵ�ƽ��0-�͵�ƽ</returns>
		public int GetBitStatusOfHighSpeedPosCompare()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_CMP_PIN(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//���ø���λ�ñȽ������״̬
		/// <summary>
		/// ���ø���λ�ñȽ������״̬
		/// </summary>
		/// <param name="SetOn">1-�ߵ�ƽ��0-�͵�ƽ</param>
		/// <returns></returns>
		public int SetOutBitOfHighSpeedPosCompare(ushort SetOn)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (SetOn != 0)
				{
					SetOn = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_CMP_PIN(TargetAxis, SetOn);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "ͨ������/������ƺ���"

		//ͨ��IO��غ���˵��
		//d2410_read_inbit           '��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		//d2410_write_outbit         '��ָ�����ƿ���ĳһλ�������λ
		//d2410_read_outbit          'ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		//d2410_read_inport          '��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		//d2410_read_outport         '��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		//d2410_write_outport        'ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬

		//ע�⣺��ʹ��d2410_write_outport���˶����ƿ���ȫ������ڽ�����λ��
		//ʹ��d2410_read_inport��d2410_read_outport����IO��ƽ��ȡ��ʾʱ��
		//Ӧ��ʹ��ʮ�����������и�ֵ����������ʹ��ʮ���������ر����ڲ�֧���޷��ű����Ŀ��������£���
		//�ڶ�IO��ƽ���п������ȡʱ��ʹ��ʮ����������ֵԶ��ʹ��ʮ��������ֵ����ֱ�ۡ����㡣

		//����7.8����ȡ��0�ſ���ͨ�������1�ĵ�ƽֵ������ͨ�������3�øߵ�ƽ
		//Dim MyCardNo,MyInbitno,MyInValue,MyOutbitno,MyOutValue As Integer 
		//MyCardNo = 0                                         '���� 
		//MyInbitno = 1                                        '����ͨ�������1 
		//MyInValue = d2410_read_inbit (MyCardNo, MyInbitno)   '��ȡͨ�������1�ĵ�ƽֵ������ֵ������MyInValue 
		//MyOutbitno = 3                                       '����ͨ�������3 
		//MyOutValue = 1                                       '���������ƽΪ�� 
		//d2410_write_outbit MyCardNo, MyOutbitno, MyOutValue  '��ͨ�������3�øߵ�ƽ

		//��7.9����ȡȫ������IO�ڵĵ�ƽֵ��������ʾ����ȫ�����IO�ڵĵ�ƽ���г�ʼ��
		//Dim MyCardNo As Integer 
		//Dim MyInportValue,MyOutportValue As Long 
		//Dim MyInportValueTemp As String 
		//MyCardNo = 0                                        '���� 
		//MyInportValue = d2410_read_inport (MyCardNo)        '��ȡ��������IO�ڵ�ƽֵ������ֵ������MyInportValue 
		//MyInportValueTemp = Hex(MyInportValue)              'ת����ʮ������ 
		//MyInTextShow = MyInportValueTemp                    '��ʾ���ı���MyInTextShow�� 
		//MyOutportValue = &HFFFFFBFA                         '&H��ʾʮ�����ƣ�VB������������ڵ�ƽֵ�������1��3��11Ϊ�͵�ƽ������˿�Ϊ�ߵ�ƽ 
		//d2410_write_outport MyCardNo, MyOutportValue        '��ȫ������ڽ��е�ƽ��ֵ

		/// <summary>
		/// ��ȡ��ǰ���ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="TargetBit">ָ�������λ��(ȡֵ��Χ��1~32)</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		public int GetInputBitStatus(ushort TargetBit)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				if (TargetBit < 1 || TargetBit > 32)
				{
					MessageBox.Show("The parameter 'TargetBit' should be 1~32, please revise it.");
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_inbit(TargetCard, TargetBit);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ(1~N��NΪ����)</param>
		/// <param name="TargetBit">ָ�������λ��(ȡֵ��Χ��1~32)</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		public int GetInputBitStatus(ushort TargetCardNumber, ushort TargetBit)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetBit < 1 || TargetBit > 32)
				{
					MessageBox.Show("The parameter 'TargetBit' should be 1~32, please revise it.");
					return 0;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_read_inbit(TargetCardNumber, TargetBit);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ָ�����ƿ���ĳһλ�������λ
		/// <summary>
		/// ��ָ�����ƿ���ĳһλ�������λ
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="TargetBit">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <param name="SetOn">�����ƽ��0����ʾ����͵�ƽ��1����ʾ����ߵ�ƽ</param>
		/// <returns>�������</returns>
		public int SetOutputBit(ushort TargetCardNumber, ushort TargetBit,
			ushort SetOn)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetBit < 1 || TargetBit > 32
					|| (TargetBit > 20 && TargetBit < 25))
				{
					MessageBox.Show("The parameter 'TargetBit' should be  1~20 and 25~32, please revise it.");
					return 0;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				if (SetOn != 0)
				{
					SetOn = 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outbit(TargetCardNumber, TargetBit, SetOn);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�Ե�ǰ���ƿ���ĳһλ�������λ
		/// <summary>
		/// �Ե�ǰ���ƿ���ĳһλ�������λ
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="TargetBit">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <param name="SetOn">�����ƽ��0����ʾ����͵�ƽ��1����ʾ����ߵ�ƽ</param>
		/// <returns>�������</returns>
		public int SetOutputBit(ushort TargetBit, ushort SetOn)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetBit < 1 || TargetBit > 32
					|| (TargetBit > 20 && TargetBit < 25))
				{
					MessageBox.Show("The parameter 'TargetBit' should be  1~20 and 25~32, please revise it.");
					return 0;
				}

				if (SetOn != 0)
				{
					SetOn = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outbit(TargetCard, TargetBit, SetOn);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�Ե�ǰ���ƿ���ĳһλ�������λON
		/// <summary>
		/// �Ե�ǰ���ƿ���ĳһλ�������λON
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="TargetBit">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <returns>�������</returns>
		public int SetOutputBitOn(ushort TargetBit)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetBit < 1 || TargetBit > 32
					|| (TargetBit > 20 && TargetBit < 25))
				{
					MessageBox.Show("The parameter 'TargetBit' should be  1~20 and 25~32, please revise it.");
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outbit(TargetCard, TargetBit, 1);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�Ե�ǰ���ƿ���ĳһλ�������λOFF
		/// <summary>
		/// �Ե�ǰ���ƿ���ĳһλ�������λOFF
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="TargetBit">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <returns>�������</returns>
		public int SetOutputBitOff(ushort TargetBit)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetBit < 1 || TargetBit > 32
					|| (TargetBit > 20 && TargetBit < 25))
				{
					MessageBox.Show("The parameter 'TargetBit' should be  1~20 and 25~32, please revise it.");
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outbit(TargetCard, TargetBit, 0);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="TargetBit">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		public int GetOutputBitStatus(ushort TargetCardNumber, ushort TargetBit)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				if (TargetBit < 1 || TargetBit > 32
					|| (TargetBit > 20 && TargetBit < 25))
				{
					MessageBox.Show("The parameter 'TargetBit' should be  1~20 and 25~32, please revise it.");
					return 0;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_read_outbit(TargetCardNumber, TargetBit);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡ��ǰ���ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡ��ǰ���ƿ���ĳһλ����ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="TargetBit">ָ�������λ�ţ�ȡֵ��Χ��1~20��25~32��</param>
		/// <returns>0���͵�ƽ��1���ߵ�ƽ</returns>
		public int GetOutputBitStatus(ushort TargetBit)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				if (TargetBit < 1 || TargetBit > 32
					|| (TargetBit > 20 && TargetBit < 25))
				{
					MessageBox.Show("The parameter 'TargetBit' should be  1~20 and 25~32, please revise it.");
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_outbit(TargetCard, TargetBit);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>bit0~bit31λֵ�ֱ�����1~32������˿�ֵ</returns>
		public int GetAllInputSignal(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 0;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_read_inport(TargetCardNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <returns>����intֵ��bit0~bit31λֵ�ֱ�����1~32������˿�ֵ</returns>
		public int GetAllInputSignal()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_read_inport(TargetCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <returns>����InputSignal���ݽṹ��bit0~bit31λֵ�ֱ�����1~32������˿�ֵ</returns>
		public InputSignal GetAllInputSignalNew()
		{
			InputSignal TempInputSignal;
			TempInputSignal.Bit0 = false;
			TempInputSignal.Bit1 = false;
			TempInputSignal.Bit2 = false;
			TempInputSignal.Bit3 = false;
			TempInputSignal.Bit4 = false;
			TempInputSignal.Bit5 = false;
			TempInputSignal.Bit6 = false;
			TempInputSignal.Bit7 = false;
			TempInputSignal.Bit8 = false;
			TempInputSignal.Bit9 = false;
			TempInputSignal.Bit10 = false;
			TempInputSignal.Bit11 = false;
			TempInputSignal.Bit12 = false;
			TempInputSignal.Bit13 = false;
			TempInputSignal.Bit14 = false;
			TempInputSignal.Bit15 = false;
			TempInputSignal.Bit16 = false;
			TempInputSignal.Bit17 = false;
			TempInputSignal.Bit18 = false;
			TempInputSignal.Bit19 = false;
			TempInputSignal.Bit20 = false;
			TempInputSignal.Bit21 = false;
			TempInputSignal.Bit22 = false;
			TempInputSignal.Bit23 = false;
			TempInputSignal.Bit24 = false;
			TempInputSignal.Bit25 = false;
			TempInputSignal.Bit26 = false;
			TempInputSignal.Bit27 = false;
			TempInputSignal.Bit28 = false;
			TempInputSignal.Bit29 = false;
			TempInputSignal.Bit30 = false;
			TempInputSignal.Bit31 = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempInputSignal;
				}

				int TempReturn = 0;
				TempReturn = d2410_read_inport(TargetCard);

				//Bit0
				if ((TempReturn & 1) == 1)
				{
					TempInputSignal.Bit0 = true;
				}
				//else 
				//    {
				//    TempInputSignal.Bit0 = false;
				//    }

				//Bit1
				if (((TempReturn >> 1) & 1) == 1)
				{
					TempInputSignal.Bit1 = true;
				}

				//Bit2
				if (((TempReturn >> 2) & 1) == 1)
				{
					TempInputSignal.Bit2 = true;
				}

				//Bit3
				if (((TempReturn >> 3) & 1) == 1)
				{
					TempInputSignal.Bit3 = true;
				}

				//Bit4
				if (((TempReturn >> 4) & 1) == 1)
				{
					TempInputSignal.Bit4 = true;
				}

				//Bit5
				if (((TempReturn >> 5) & 1) == 1)
				{
					TempInputSignal.Bit5 = true;
				}

				//Bit6
				if (((TempReturn >> 6) & 1) == 1)
				{
					TempInputSignal.Bit6 = true;
				}

				//Bit7
				if (((TempReturn >> 7) & 1) == 1)
				{
					TempInputSignal.Bit7 = true;
				}

				//Bit8
				if (((TempReturn >> 8) & 1) == 1)
				{
					TempInputSignal.Bit8 = true;
				}

				//Bit9
				if (((TempReturn >> 9) & 1) == 1)
				{
					TempInputSignal.Bit9 = true;
				}

				//Bit10
				if (((TempReturn >> 10) & 1) == 1)
				{
					TempInputSignal.Bit10 = true;
				}

				//Bit11
				if (((TempReturn >> 11) & 1) == 1)
				{
					TempInputSignal.Bit11 = true;
				}

				//Bit12
				if (((TempReturn >> 12) & 1) == 1)
				{
					TempInputSignal.Bit12 = true;
				}

				//Bit13
				if (((TempReturn >> 13) & 1) == 1)
				{
					TempInputSignal.Bit13 = true;
				}

				//Bit14
				if (((TempReturn >> 14) & 1) == 1)
				{
					TempInputSignal.Bit14 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempInputSignal.Bit15 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempInputSignal.Bit15 = true;
				}

				//Bit16
				if (((TempReturn >> 16) & 1) == 1)
				{
					TempInputSignal.Bit16 = true;
				}

				//Bit17
				if (((TempReturn >> 17) & 1) == 1)
				{
					TempInputSignal.Bit17 = true;
				}

				//Bit18
				if (((TempReturn >> 18) & 1) == 1)
				{
					TempInputSignal.Bit18 = true;
				}

				//Bit19
				if (((TempReturn >> 19) & 1) == 1)
				{
					TempInputSignal.Bit19 = true;
				}

				//Bit20
				if (((TempReturn >> 20) & 1) == 1)
				{
					TempInputSignal.Bit20 = true;
				}

				//Bit21
				if (((TempReturn >> 21) & 1) == 1)
				{
					TempInputSignal.Bit21 = true;
				}

				//Bit22
				if (((TempReturn >> 22) & 1) == 1)
				{
					TempInputSignal.Bit22 = true;
				}

				//Bit23
				if (((TempReturn >> 23) & 1) == 1)
				{
					TempInputSignal.Bit23 = true;
				}

				//Bit24
				if (((TempReturn >> 24) & 1) == 1)
				{
					TempInputSignal.Bit24 = true;
				}

				//Bit25
				if (((TempReturn >> 25) & 1) == 1)
				{
					TempInputSignal.Bit25 = true;
				}

				//Bit26
				if (((TempReturn >> 26) & 1) == 1)
				{
					TempInputSignal.Bit26 = true;
				}

				//Bit27
				if (((TempReturn >> 27) & 1) == 1)
				{
					TempInputSignal.Bit27 = true;
				}

				//Bit28
				if (((TempReturn >> 28) & 1) == 1)
				{
					TempInputSignal.Bit28 = true;
				}

				//Bit29
				if (((TempReturn >> 29) & 1) == 1)
				{
					TempInputSignal.Bit29 = true;
				}

				//Bit30
				if (((TempReturn >> 30) & 1) == 1)
				{
					TempInputSignal.Bit30 = true;
				}

				//Bit31
				if (((TempReturn >> 31) & 1) == 1)
				{
					TempInputSignal.Bit31 = true;
				}

				return TempInputSignal;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempInputSignal;
			}
		}

		//��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</returns>
		public int GetAllOutputStatus(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 0;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = d2410_read_outport(TargetCardNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <returns>bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</returns>
		public int GetAllOutputStatus()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = d2410_read_outport(TargetCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡ��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <returns>bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</returns>
		public OutputSignal GetAllOutputStatusNew()
		{
			OutputSignal TempOutputSignal;
			TempOutputSignal.Bit0 = false;
			TempOutputSignal.Bit1 = false;
			TempOutputSignal.Bit2 = false;
			TempOutputSignal.Bit3 = false;
			TempOutputSignal.Bit4 = false;
			TempOutputSignal.Bit5 = false;
			TempOutputSignal.Bit6 = false;
			TempOutputSignal.Bit7 = false;
			TempOutputSignal.Bit8 = false;
			TempOutputSignal.Bit9 = false;
			TempOutputSignal.Bit10 = false;
			TempOutputSignal.Bit11 = false;
			TempOutputSignal.Bit12 = false;
			TempOutputSignal.Bit13 = false;
			TempOutputSignal.Bit14 = false;
			TempOutputSignal.Bit15 = false;
			TempOutputSignal.Bit16 = false;
			TempOutputSignal.Bit17 = false;
			TempOutputSignal.Bit18 = false;
			TempOutputSignal.Bit19 = false;
			TempOutputSignal.Bit24 = false;
			TempOutputSignal.Bit25 = false;
			TempOutputSignal.Bit26 = false;
			TempOutputSignal.Bit27 = false;
			TempOutputSignal.Bit28 = false;
			TempOutputSignal.Bit29 = false;
			TempOutputSignal.Bit30 = false;
			TempOutputSignal.Bit31 = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempOutputSignal;
				}

				int TempReturn = 0;
				TempReturn = d2410_read_outport(TargetCard);

				//Bit0
				if ((TempReturn & 1) == 1)
				{
					TempOutputSignal.Bit0 = true;
				}
				//else
				//    {
				//    TempOutputSignal.Bit0 = false;
				//    }

				//Bit1
				if (((TempReturn >> 1) & 1) == 1)
				{
					TempOutputSignal.Bit1 = true;
				}

				//Bit2
				if (((TempReturn >> 2) & 1) == 1)
				{
					TempOutputSignal.Bit2 = true;
				}

				//Bit3
				if (((TempReturn >> 3) & 1) == 1)
				{
					TempOutputSignal.Bit3 = true;
				}

				//Bit4
				if (((TempReturn >> 4) & 1) == 1)
				{
					TempOutputSignal.Bit4 = true;
				}

				//Bit5
				if (((TempReturn >> 5) & 1) == 1)
				{
					TempOutputSignal.Bit5 = true;
				}

				//Bit6
				if (((TempReturn >> 6) & 1) == 1)
				{
					TempOutputSignal.Bit6 = true;
				}

				//Bit7
				if (((TempReturn >> 7) & 1) == 1)
				{
					TempOutputSignal.Bit7 = true;
				}

				//Bit8
				if (((TempReturn >> 8) & 1) == 1)
				{
					TempOutputSignal.Bit8 = true;
				}

				//Bit9
				if (((TempReturn >> 9) & 1) == 1)
				{
					TempOutputSignal.Bit9 = true;
				}

				//Bit10
				if (((TempReturn >> 10) & 1) == 1)
				{
					TempOutputSignal.Bit10 = true;
				}

				//Bit11
				if (((TempReturn >> 11) & 1) == 1)
				{
					TempOutputSignal.Bit11 = true;
				}

				//Bit12
				if (((TempReturn >> 12) & 1) == 1)
				{
					TempOutputSignal.Bit12 = true;
				}

				//Bit13
				if (((TempReturn >> 13) & 1) == 1)
				{
					TempOutputSignal.Bit13 = true;
				}

				//Bit14
				if (((TempReturn >> 14) & 1) == 1)
				{
					TempOutputSignal.Bit14 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempOutputSignal.Bit15 = true;
				}

				//Bit16
				if (((TempReturn >> 16) & 1) == 1)
				{
					TempOutputSignal.Bit16 = true;
				}

				//Bit17
				if (((TempReturn >> 17) & 1) == 1)
				{
					TempOutputSignal.Bit17 = true;
				}

				//Bit18
				if (((TempReturn >> 18) & 1) == 1)
				{
					TempOutputSignal.Bit18 = true;
				}

				//Bit19
				if (((TempReturn >> 19) & 1) == 1)
				{
					TempOutputSignal.Bit19 = true;
				}

				//Bit24
				if (((TempReturn >> 24) & 1) == 1)
				{
					TempOutputSignal.Bit24 = true;
				}

				//Bit25
				if (((TempReturn >> 25) & 1) == 1)
				{
					TempOutputSignal.Bit25 = true;
				}

				//Bit26
				if (((TempReturn >> 26) & 1) == 1)
				{
					TempOutputSignal.Bit26 = true;
				}

				//Bit27
				if (((TempReturn >> 27) & 1) == 1)
				{
					TempOutputSignal.Bit27 = true;
				}

				//Bit28
				if (((TempReturn >> 28) & 1) == 1)
				{
					TempOutputSignal.Bit28 = true;
				}

				//Bit29
				if (((TempReturn >> 29) & 1) == 1)
				{
					TempOutputSignal.Bit29 = true;
				}

				//Bit30
				if (((TempReturn >> 30) & 1) == 1)
				{
					TempOutputSignal.Bit30 = true;
				}

				//Bit31
				if (((TempReturn >> 31) & 1) == 1)
				{
					TempOutputSignal.Bit31 = true;
				}

				return TempOutputSignal;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempOutputSignal;
			}
		}

		//��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// ��ȡָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</returns>
		public OutputSignal GetAllOutputStatusNew(ushort TargetCardNumber)
		{
			OutputSignal TempOutputSignal;
			TempOutputSignal.Bit0 = false;
			TempOutputSignal.Bit1 = false;
			TempOutputSignal.Bit2 = false;
			TempOutputSignal.Bit3 = false;
			TempOutputSignal.Bit4 = false;
			TempOutputSignal.Bit5 = false;
			TempOutputSignal.Bit6 = false;
			TempOutputSignal.Bit7 = false;
			TempOutputSignal.Bit8 = false;
			TempOutputSignal.Bit9 = false;
			TempOutputSignal.Bit10 = false;
			TempOutputSignal.Bit11 = false;
			TempOutputSignal.Bit12 = false;
			TempOutputSignal.Bit13 = false;
			TempOutputSignal.Bit14 = false;
			TempOutputSignal.Bit15 = false;
			TempOutputSignal.Bit16 = false;
			TempOutputSignal.Bit17 = false;
			TempOutputSignal.Bit18 = false;
			TempOutputSignal.Bit19 = false;
			TempOutputSignal.Bit24 = false;
			TempOutputSignal.Bit25 = false;
			TempOutputSignal.Bit26 = false;
			TempOutputSignal.Bit27 = false;
			TempOutputSignal.Bit28 = false;
			TempOutputSignal.Bit29 = false;
			TempOutputSignal.Bit30 = false;
			TempOutputSignal.Bit31 = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempOutputSignal;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return TempOutputSignal;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = d2410_read_outport(TargetCardNumber);

				//Bit0
				if ((TempReturn & 1) == 1)
				{
					TempOutputSignal.Bit0 = true;
				}
				//else
				//    {
				//    TempOutputSignal.Bit0 = false;
				//    }

				//Bit1
				if (((TempReturn >> 1) & 1) == 1)
				{
					TempOutputSignal.Bit1 = true;
				}

				//Bit2
				if (((TempReturn >> 2) & 1) == 1)
				{
					TempOutputSignal.Bit2 = true;
				}

				//Bit3
				if (((TempReturn >> 3) & 1) == 1)
				{
					TempOutputSignal.Bit3 = true;
				}

				//Bit4
				if (((TempReturn >> 4) & 1) == 1)
				{
					TempOutputSignal.Bit4 = true;
				}

				//Bit5
				if (((TempReturn >> 5) & 1) == 1)
				{
					TempOutputSignal.Bit5 = true;
				}

				//Bit6
				if (((TempReturn >> 6) & 1) == 1)
				{
					TempOutputSignal.Bit6 = true;
				}

				//Bit7
				if (((TempReturn >> 7) & 1) == 1)
				{
					TempOutputSignal.Bit7 = true;
				}

				//Bit8
				if (((TempReturn >> 8) & 1) == 1)
				{
					TempOutputSignal.Bit8 = true;
				}

				//Bit9
				if (((TempReturn >> 9) & 1) == 1)
				{
					TempOutputSignal.Bit9 = true;
				}

				//Bit10
				if (((TempReturn >> 10) & 1) == 1)
				{
					TempOutputSignal.Bit10 = true;
				}

				//Bit11
				if (((TempReturn >> 11) & 1) == 1)
				{
					TempOutputSignal.Bit11 = true;
				}

				//Bit12
				if (((TempReturn >> 12) & 1) == 1)
				{
					TempOutputSignal.Bit12 = true;
				}

				//Bit13
				if (((TempReturn >> 13) & 1) == 1)
				{
					TempOutputSignal.Bit13 = true;
				}

				//Bit14
				if (((TempReturn >> 14) & 1) == 1)
				{
					TempOutputSignal.Bit14 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempOutputSignal.Bit15 = true;
				}

				//Bit16
				if (((TempReturn >> 16) & 1) == 1)
				{
					TempOutputSignal.Bit16 = true;
				}

				//Bit17
				if (((TempReturn >> 17) & 1) == 1)
				{
					TempOutputSignal.Bit17 = true;
				}

				//Bit18
				if (((TempReturn >> 18) & 1) == 1)
				{
					TempOutputSignal.Bit18 = true;
				}

				//Bit19
				if (((TempReturn >> 19) & 1) == 1)
				{
					TempOutputSignal.Bit19 = true;
				}

				//Bit24
				if (((TempReturn >> 24) & 1) == 1)
				{
					TempOutputSignal.Bit24 = true;
				}

				//Bit25
				if (((TempReturn >> 25) & 1) == 1)
				{
					TempOutputSignal.Bit25 = true;
				}

				//Bit26
				if (((TempReturn >> 26) & 1) == 1)
				{
					TempOutputSignal.Bit26 = true;
				}

				//Bit27
				if (((TempReturn >> 27) & 1) == 1)
				{
					TempOutputSignal.Bit27 = true;
				}

				//Bit28
				if (((TempReturn >> 28) & 1) == 1)
				{
					TempOutputSignal.Bit28 = true;
				}

				//Bit29
				if (((TempReturn >> 29) & 1) == 1)
				{
					TempOutputSignal.Bit29 = true;
				}

				//Bit30
				if (((TempReturn >> 30) & 1) == 1)
				{
					TempOutputSignal.Bit30 = true;
				}

				//Bit31
				if (((TempReturn >> 31) & 1) == 1)
				{
					TempOutputSignal.Bit31 = true;
				}

				return TempOutputSignal;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempOutputSignal;
			}
		}

		//�趨ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// �趨ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="PortValue">bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</param>
		/// <returns>�������</returns>
		public int SetAllOutputStatus(ushort TargetCardNumber, uint PortValue)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outport(TargetCardNumber, PortValue);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�趨��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// �趨��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="PortValue">bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</param>
		/// <returns>�������</returns>
		public int SetAllOutputStatus(uint PortValue)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outport(TargetCard, PortValue);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�趨ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// �趨ָ�����ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="PortValue">bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</param>
		/// <returns>�������</returns>
		public int SetAllOutputStatus(ushort TargetCardNumber, OutputSignal PortValue)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempPortValue = 0;

				//Bit0
				if (PortValue.Bit0 == true)
				{
					TempPortValue = TempPortValue & 1;
				}

				//Bit1
				if (PortValue.Bit1 == true)
				{
					TempPortValue = TempPortValue & 2;
				}

				//Bit2
				if (PortValue.Bit2 == true)
				{
					TempPortValue = TempPortValue & 4;
				}

				//Bit3
				if (PortValue.Bit3 == true)
				{
					TempPortValue = TempPortValue & 8;
				}

				//Bit4
				if (PortValue.Bit4 == true)
				{
					TempPortValue = TempPortValue & 16;
				}

				//Bit5
				if (PortValue.Bit5 == true)
				{
					TempPortValue = TempPortValue & 32;
				}

				//Bit6
				if (PortValue.Bit6 == true)
				{
					TempPortValue = TempPortValue & 64;
				}

				//Bit7
				if (PortValue.Bit7 == true)
				{
					TempPortValue = TempPortValue & 128;
				}

				//Bit8
				if (PortValue.Bit8 == true)
				{
					TempPortValue = TempPortValue & (2 << 8);
					//TempPortValue = TempPortValue & (1<<9);
				}

				//Bit9
				if (PortValue.Bit9 == true)
				{
					TempPortValue = TempPortValue & (2 << 9);
				}

				//Bit10
				if (PortValue.Bit10 == true)
				{
					TempPortValue = TempPortValue & (2 << 10);
				}

				//Bit11
				if (PortValue.Bit11 == true)
				{
					TempPortValue = TempPortValue & (2 << 11);
				}

				//Bit12
				if (PortValue.Bit12 == true)
				{
					TempPortValue = TempPortValue & (2 << 12);
				}

				//Bit13
				if (PortValue.Bit13 == true)
				{
					TempPortValue = TempPortValue & (2 << 13);
				}

				//Bit14
				if (PortValue.Bit14 == true)
				{
					TempPortValue = TempPortValue & (2 << 14);
				}

				//Bit15
				if (PortValue.Bit15 == true)
				{
					TempPortValue = TempPortValue & (2 << 15);
				}

				//Bit16
				if (PortValue.Bit16 == true)
				{
					TempPortValue = TempPortValue & (2 << 16);
				}

				//Bit17
				if (PortValue.Bit17 == true)
				{
					TempPortValue = TempPortValue & (2 << 17);
				}

				//Bit18
				if (PortValue.Bit18 == true)
				{
					TempPortValue = TempPortValue & (2 << 18);
				}

				//Bit19
				if (PortValue.Bit19 == true)
				{
					TempPortValue = TempPortValue & (2 << 19);
				}

				//Bit24
				if (PortValue.Bit24 == true)
				{
					TempPortValue = TempPortValue & (2 << 24);
				}

				//Bit25
				if (PortValue.Bit25 == true)
				{
					TempPortValue = TempPortValue & (2 << 25);
				}

				//Bit25
				if (PortValue.Bit25 == true)
				{
					TempPortValue = TempPortValue & (2 << 25);
				}

				//Bit26
				if (PortValue.Bit26 == true)
				{
					TempPortValue = TempPortValue & (2 << 26);
				}

				//Bit27
				if (PortValue.Bit27 == true)
				{
					TempPortValue = TempPortValue & (2 << 27);
				}

				//Bit28
				if (PortValue.Bit28 == true)
				{
					TempPortValue = TempPortValue & (2 << 28);
				}

				//Bit29
				if (PortValue.Bit29 == true)
				{
					TempPortValue = TempPortValue & (2 << 29);
				}

				//Bit30
				if (PortValue.Bit30 == true)
				{
					TempPortValue = TempPortValue & (2 << 30);
				}

				//Bit31
				if (PortValue.Bit31 == true)
				{
					TempPortValue = TempPortValue & (2 << 31);
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outport(TargetCardNumber,
					(uint)TempPortValue);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�趨��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// <summary>
		/// �趨��ǰ���ƿ���ȫ��ͨ������ڵĵ�ƽ״̬
		/// OUT1��OUT16�˿ڿ������ϵ�ʱ�ĳ�ʼ��ƽ��OUT17��OUT20�ϵ��ʼ��ƽΪ�ߡ�
		/// </summary>
		/// <param name="PortValue">bit0~bit19��bit24~bit31λֵ�ֱ�����1~20��25~32������˿�ֵ</param>
		/// <returns>�������</returns>
		public int SetAllOutputStatus(OutputSignal PortValue)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempPortValue = 0;

				//Bit0
				if (PortValue.Bit0 == true)
				{
					TempPortValue = TempPortValue & 1;
				}

				//Bit1
				if (PortValue.Bit1 == true)
				{
					TempPortValue = TempPortValue & 2;
				}

				//Bit2
				if (PortValue.Bit2 == true)
				{
					TempPortValue = TempPortValue & 4;
				}

				//Bit3
				if (PortValue.Bit3 == true)
				{
					TempPortValue = TempPortValue & 8;
				}

				//Bit4
				if (PortValue.Bit4 == true)
				{
					TempPortValue = TempPortValue & 16;
				}

				//Bit5
				if (PortValue.Bit5 == true)
				{
					TempPortValue = TempPortValue & 32;
				}

				//Bit6
				if (PortValue.Bit6 == true)
				{
					TempPortValue = TempPortValue & 64;
				}

				//Bit7
				if (PortValue.Bit7 == true)
				{
					TempPortValue = TempPortValue & 128;
				}

				//Bit8
				if (PortValue.Bit8 == true)
				{
					TempPortValue = TempPortValue & (2 << 8);
					//TempPortValue = TempPortValue & (1<<9);
				}

				//Bit9
				if (PortValue.Bit9 == true)
				{
					TempPortValue = TempPortValue & (2 << 9);
				}

				//Bit10
				if (PortValue.Bit10 == true)
				{
					TempPortValue = TempPortValue & (2 << 10);
				}

				//Bit11
				if (PortValue.Bit11 == true)
				{
					TempPortValue = TempPortValue & (2 << 11);
				}

				//Bit12
				if (PortValue.Bit12 == true)
				{
					TempPortValue = TempPortValue & (2 << 12);
				}

				//Bit13
				if (PortValue.Bit13 == true)
				{
					TempPortValue = TempPortValue & (2 << 13);
				}

				//Bit14
				if (PortValue.Bit14 == true)
				{
					TempPortValue = TempPortValue & (2 << 14);
				}

				//Bit15
				if (PortValue.Bit15 == true)
				{
					TempPortValue = TempPortValue & (2 << 15);
				}

				//Bit16
				if (PortValue.Bit16 == true)
				{
					TempPortValue = TempPortValue & (2 << 16);
				}

				//Bit17
				if (PortValue.Bit17 == true)
				{
					TempPortValue = TempPortValue & (2 << 17);
				}

				//Bit18
				if (PortValue.Bit18 == true)
				{
					TempPortValue = TempPortValue & (2 << 18);
				}

				//Bit19
				if (PortValue.Bit19 == true)
				{
					TempPortValue = TempPortValue & (2 << 19);
				}

				//Bit24
				if (PortValue.Bit24 == true)
				{
					TempPortValue = TempPortValue & (2 << 24);
				}

				//Bit25
				if (PortValue.Bit25 == true)
				{
					TempPortValue = TempPortValue & (2 << 25);
				}

				//Bit25
				if (PortValue.Bit25 == true)
				{
					TempPortValue = TempPortValue & (2 << 25);
				}

				//Bit26
				if (PortValue.Bit26 == true)
				{
					TempPortValue = TempPortValue & (2 << 26);
				}

				//Bit27
				if (PortValue.Bit27 == true)
				{
					TempPortValue = TempPortValue & (2 << 27);
				}

				//Bit28
				if (PortValue.Bit28 == true)
				{
					TempPortValue = TempPortValue & (2 << 28);
				}

				//Bit29
				if (PortValue.Bit29 == true)
				{
					TempPortValue = TempPortValue & (2 << 29);
				}

				//Bit30
				if (PortValue.Bit30 == true)
				{
					TempPortValue = TempPortValue & (2 << 30);
				}

				//Bit31
				if (PortValue.Bit31 == true)
				{
					TempPortValue = TempPortValue & (2 << 31);
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_write_outport(TargetCard,
					(uint)TempPortValue);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "��������������"

		//����������ʵ��
		//DMC2410C�ķ���λ�ü�������һ��32λ��������������ͨ�����ƿ��������ӿ�EA��
		//EB��������壨�����������դ�߷�������ȣ����м�����

		//�����������غ���˵��
		//d2410_counter_config           '���ñ���������ڵļ�����ʽ
		//d2410_get_encoder              '��ȡ�������������������ֵ
		//d2410_set_encoder              '���ñ��������������ֵ

		//����7.10�����������������Ĳ���
		//d2410_counter_config 0,3            '������0Ϊ4��������Ĭ�ϵ�EA��EB�������� 
		//d2410_set_encoder 0,0               '������0�ļ�����ʼֵΪ0 
		//X_Position = d2410_get_encoder(0)   '����0�ļ���������ֵ������X_Position

		/// <summary>
		/// ��ȡ�����������λ���������ֵ����Χ��28λ�з�����
		/// </summary>
		/// <returns>λ�÷�������ֵ����λ��pulse</returns>
		public int GetEncoderPosInPulse()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_encoder(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ�����������λ�á���λ��mm��
		/// <summary>
		/// ��ȡ�����������λ�á���λ��mm��
		/// </summary>
		/// <param name="EncoderPosInMM">λ�÷���ֵ����λ��mm��</param>
		/// <returns></returns>
		public int GetEncoderPosInMM(ref double EncoderPosInMM)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_encoder_unitmm(TargetAxis,
					ref EncoderPosInMM);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����������������������ֵ����Χ��28λ�з�����
		/// <summary>
		/// ����������������������ֵ����Χ��28λ�з�����
		/// </summary>
		/// <param name="EncoderValueInPulse">��������������������趨ֵ</param>
		/// <returns>�������</returns>
		public int SetEncoderPosInPulse(uint EncoderValueInPulse)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_encoder(TargetAxis, EncoderValueInPulse);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�����������������ֵ����λ��mm��
		/// <summary>
		/// �����������������ֵ����λ��mm��
		/// </summary>
		/// <param name="EncoderPosValueInMM">���������趨ֵ����λ��mm��</param>
		/// <returns>�������</returns>
		public int SetEncoderPosInMM(double EncoderPosValueInMM)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_encoder_unitmm(TargetAxis,
					EncoderPosValueInMM);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡָ�����ƿ��ļ������ı�ʶλ
		/// <summary>
		/// ��ȡָ�����ƿ��ļ������ı�ʶλ
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>����ֵλ�� 0: ָ������X�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 1: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 2: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 3: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 4~7: ����
		/// ����ֵλ�� 8: ָ������Y�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 9: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 10: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 11: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 12~15: ����
		/// ����ֵλ�� 16: ָ������Z�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 17: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 18: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 19: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 20~23: ����
		/// ����ֵλ�� 24: ָ������U�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 25: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 26: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 27: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 28~31: ����
		/// </returns>
		public int GetCounterFlag(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 0;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_get_counter_flag(TargetCardNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡ��ǰ���ƿ��ļ������ı�ʶλ
		/// <summary>
		/// ��ȡ��ǰ���ƿ��ļ������ı�ʶλ
		/// </summary>
		/// <returns>����ֵλ�� 0: ָ������X�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 1: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 2: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 3: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 4~7: ����
		/// ����ֵλ�� 8: ָ������Y�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 9: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 10: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 11: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 12~15: ����
		/// ����ֵλ�� 16: ָ������Z�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 17: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 18: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 19: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 20~23: ����
		/// ����ֵλ�� 24: ָ������U�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 25: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 26: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 27: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 28~31: ����
		/// </returns>
		public int GetCounterFlag()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_counter_flag(TargetCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡָ�����ƿ��ļ������ı�ʶλ
		/// <summary>
		/// ��ȡָ�����ƿ��ļ������ı�ʶλ
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>����ֵλ�� 0: ָ������X�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 1: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 2: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 3: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 4~7: ����
		/// ����ֵλ�� 8: ָ������Y�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 9: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 10: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 11: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 12~15: ����
		/// ����ֵλ�� 16: ָ������Z�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 17: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 18: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 19: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 20~23: ����
		/// ����ֵλ�� 24: ָ������U�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 25: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 26: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 27: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 28~31: ����
		/// </returns>
		public CounterFlag GetCounterFlagNew(ushort TargetCardNumber)
		{
			CounterFlag TempCounterFlag;
			TempCounterFlag.Bit0 = false;
			TempCounterFlag.Bit1 = false;
			TempCounterFlag.Bit2 = false;
			TempCounterFlag.Bit3 = false;
			TempCounterFlag.Bit8 = false;
			TempCounterFlag.Bit9 = false;
			TempCounterFlag.Bit10 = false;
			TempCounterFlag.Bit11 = false;
			TempCounterFlag.Bit16 = false;
			TempCounterFlag.Bit17 = false;
			TempCounterFlag.Bit18 = false;
			TempCounterFlag.Bit19 = false;
			TempCounterFlag.Bit24 = false;
			TempCounterFlag.Bit25 = false;
			TempCounterFlag.Bit26 = false;
			TempCounterFlag.Bit27 = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempCounterFlag;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return TempCounterFlag;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);
				int TempReturn = 0;
				TempReturn = (int)d2410_get_counter_flag(TargetCardNumber);

				//Bit0
				if ((TempReturn & 1) == 1)
				{
					TempCounterFlag.Bit0 = true;
				}
				//else
				//    {
				//    TempCounterFlag.Bit0 = false;
				//    }

				//Bit1
				if (((TempReturn >> 1) & 1) == 1)
				{
					TempCounterFlag.Bit1 = true;
				}

				//Bit2
				if (((TempReturn >> 2) & 1) == 1)
				{
					TempCounterFlag.Bit2 = true;
				}

				//Bit3
				if (((TempReturn >> 3) & 1) == 1)
				{
					TempCounterFlag.Bit3 = true;
				}

				//Bit8
				if (((TempReturn >> 8) & 1) == 1)
				{
					TempCounterFlag.Bit8 = true;
				}

				//Bit9
				if (((TempReturn >> 9) & 1) == 1)
				{
					TempCounterFlag.Bit9 = true;
				}

				//Bit10
				if (((TempReturn >> 10) & 1) == 1)
				{
					TempCounterFlag.Bit10 = true;
				}

				//Bit11
				if (((TempReturn >> 11) & 1) == 1)
				{
					TempCounterFlag.Bit11 = true;
				}

				//Bit16
				if (((TempReturn >> 16) & 1) == 1)
				{
					TempCounterFlag.Bit16 = true;
				}

				//Bit17
				if (((TempReturn >> 17) & 1) == 1)
				{
					TempCounterFlag.Bit17 = true;
				}

				//Bit18
				if (((TempReturn >> 18) & 1) == 1)
				{
					TempCounterFlag.Bit18 = true;
				}

				//Bit19
				if (((TempReturn >> 19) & 1) == 1)
				{
					TempCounterFlag.Bit19 = true;
				}

				//Bit24
				if (((TempReturn >> 24) & 1) == 1)
				{
					TempCounterFlag.Bit24 = true;
				}

				//Bit25
				if (((TempReturn >> 25) & 1) == 1)
				{
					TempCounterFlag.Bit25 = true;
				}

				//Bit26
				if (((TempReturn >> 26) & 1) == 1)
				{
					TempCounterFlag.Bit26 = true;
				}

				//Bit27
				if (((TempReturn >> 27) & 1) == 1)
				{
					TempCounterFlag.Bit27 = true;
				}

				return TempCounterFlag;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempCounterFlag;
			}
		}

		//��ȡ��ǰ���ƿ��ļ������ı�ʶλ
		/// <summary>
		/// ��ȡ��ǰ���ƿ��ļ������ı�ʶλ
		/// </summary>
		/// <returns>����ֵλ�� 0: ָ������X�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 1: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 2: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 3: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 4~7: ����
		/// ����ֵλ�� 8: ָ������Y�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 9: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 10: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 11: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 12~15: ����
		/// ����ֵλ�� 16: ָ������Z�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 17: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 18: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 19: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 20~23: ����
		/// ����ֵλ�� 24: ָ������U�� ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 25: ��λ������־��������ÿ�����ʱ����һ��
		/// ����ֵλ�� 26: ���ű�־�������������Ϊ0�������Ϊ1
		/// ����ֵλ�� 27: ���¼�����־���ϼ���ʱΪ1���¼���ʱΪ0
		/// ����ֵλ�� 28~31: ����
		/// </returns>
		public CounterFlag GetCounterFlagNew()
		{
			CounterFlag TempCounterFlag;
			TempCounterFlag.Bit0 = false;
			TempCounterFlag.Bit1 = false;
			TempCounterFlag.Bit2 = false;
			TempCounterFlag.Bit3 = false;
			TempCounterFlag.Bit8 = false;
			TempCounterFlag.Bit9 = false;
			TempCounterFlag.Bit10 = false;
			TempCounterFlag.Bit11 = false;
			TempCounterFlag.Bit16 = false;
			TempCounterFlag.Bit17 = false;
			TempCounterFlag.Bit18 = false;
			TempCounterFlag.Bit19 = false;
			TempCounterFlag.Bit24 = false;
			TempCounterFlag.Bit25 = false;
			TempCounterFlag.Bit26 = false;
			TempCounterFlag.Bit27 = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempCounterFlag;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_counter_flag(TargetCard);

				//Bit0
				if ((TempReturn & 1) == 1)
				{
					TempCounterFlag.Bit0 = true;
				}
				//else
				//    {
				//    TempCounterFlag.Bit0 = false;
				//    }

				//Bit1
				if (((TempReturn >> 1) & 1) == 1)
				{
					TempCounterFlag.Bit1 = true;
				}

				//Bit2
				if (((TempReturn >> 2) & 1) == 1)
				{
					TempCounterFlag.Bit2 = true;
				}

				//Bit3
				if (((TempReturn >> 3) & 1) == 1)
				{
					TempCounterFlag.Bit3 = true;
				}

				//Bit8
				if (((TempReturn >> 8) & 1) == 1)
				{
					TempCounterFlag.Bit8 = true;
				}

				//Bit9
				if (((TempReturn >> 9) & 1) == 1)
				{
					TempCounterFlag.Bit9 = true;
				}

				//Bit10
				if (((TempReturn >> 10) & 1) == 1)
				{
					TempCounterFlag.Bit10 = true;
				}

				//Bit11
				if (((TempReturn >> 11) & 1) == 1)
				{
					TempCounterFlag.Bit11 = true;
				}

				//Bit16
				if (((TempReturn >> 16) & 1) == 1)
				{
					TempCounterFlag.Bit16 = true;
				}

				//Bit17
				if (((TempReturn >> 17) & 1) == 1)
				{
					TempCounterFlag.Bit17 = true;
				}

				//Bit18
				if (((TempReturn >> 18) & 1) == 1)
				{
					TempCounterFlag.Bit18 = true;
				}

				//Bit19
				if (((TempReturn >> 19) & 1) == 1)
				{
					TempCounterFlag.Bit19 = true;
				}

				//Bit24
				if (((TempReturn >> 24) & 1) == 1)
				{
					TempCounterFlag.Bit24 = true;
				}

				//Bit25
				if (((TempReturn >> 25) & 1) == 1)
				{
					TempCounterFlag.Bit25 = true;
				}

				//Bit26
				if (((TempReturn >> 26) & 1) == 1)
				{
					TempCounterFlag.Bit26 = true;
				}

				//Bit27
				if (((TempReturn >> 27) & 1) == 1)
				{
					TempCounterFlag.Bit27 = true;
				}

				return TempCounterFlag;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempCounterFlag;
			}
		}

		//��λָ�����ƿ��������ļ�����־λ, ��Χ��1~N��NΪ���ţ�
		/// <summary>
		/// ��λָ�����ƿ��������ļ�����־λ, ��Χ��1~N��NΪ���ţ�
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���</param>
		/// <returns>�������</returns>
		public int ResetCounterFlag(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_counter_flag(TargetCardNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��λ��ǰ���ƿ��������ļ�����־λ, ��Χ��1~N��NΪ���ţ�
		/// <summary>
		/// ��λ��ǰ���ƿ��������ļ�����־λ, ��Χ��1~N��NΪ���ţ�
		/// </summary>
		/// <returns>�������</returns>
		public int ResetCounterFlag()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_counter_flag(TargetCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��λָ�����ƿ��������������־λ, ��Χ��1~N��NΪ���ţ�
		/// <summary>
		/// ��λָ�����ƿ��������������־λ, ��Χ��1~N��NΪ���ţ�
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���</param>
		/// <returns>�������</returns>
		public int ResetClearFlag(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_clear_flag(TargetCardNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��λ��ǰ���ƿ��������������־λ, ��Χ��1~N��NΪ���ţ�
		/// <summary>
		/// ��λ��ǰ���ƿ��������������־λ, ��Χ��1~N��NΪ���ţ�
		/// </summary>
		/// <returns>�������</returns>
		public int ResetClearFlag()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_clear_flag(TargetCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ָ�����EZ�źŵ���Ч��ƽ��������
		/// <summary>
		/// ����ָ�����EZ�źŵ���Ч��ƽ��������
		/// </summary>
		/// <param name="EZLogic">EZ�ź���Ч��ƽ��
		/// 0������Ч��
		/// 1������Ч</param>
		/// <param name="EZMode">EZ�źŵĹ�����ʽ��
		/// 0��EZ�ź���Ч��
		/// 1��EZ�Ǽ�������λ�ź�</param>
		/// <returns></returns>
		public int SetEZSignal(ushort EZLogic, ushort EZMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (EZLogic != 0)
				{
					EZLogic = 1;
				}

				if (EZMode != 0)
				{
					EZMode = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)1;

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "��������"

		//λ�����湦�ܵ�ʵ��
		//DMC2410C���ṩ�˸���λ�����湦�ܣ�λ�������޴�����ʱʱ�䣬������λ�������źź��������浱ǰλ�á�

		//����������غ���˵��
		//d2410_config_latch_mode    '�������淽ʽΪ���������������ͬʱ����
		//d2410_get_latch_value      '��ȡ��������������ֵ
		//d2410_get_latch_flag       '��ȡָ�����ƿ����������ı�־λ
		//d2410_reset_latch_flag     '��λָ�����ƿ����������ı�־λ
		//d2410_triger_chunnel       'ѡ��ȫ������ʱ���ⴥ���ź�ͨ��

		//ע�⣺1����λ�������У���δ������������ֻ�����һ�δ���λ�ã�ֻ�е��ú����������״̬�����ٴ����棻 
		//      2��λ��������ʱֻ֧�ַ���λ�����档

		//��7.13��λ������ 
		//Dim MyCardNo, Myaxis ,Myall_enable As Integer 
		//Dim Mylatch_value As Long 
		//MyCardNo = 0                                        '���� 
		//Myaxis = 0                                          '��� 
		//Myall_enable = 0                                    '�������淽ʽΪ�������� 
		//d2410_config_latch_mode MyCardNo,Myall_enable       '�������淽ʽ 
		//d2410_reset_latch_flag MyCardNo                     '��λ��������־λ 
		//d2410_ex_t_pmove Myaxis,10000,0                     'ִ�ж����˶���λ��Ϊ10000pulse���������ģʽ 
		//While ((d2410_get_latch_flag(MyCardNo) And (2 ^ (Myaxis + 8))) = 0) '�ж��趨���LTC����״̬ 
		//DoEvents 
		//Wend 
		//Mylatch_value= d2410_get_latch_value(Myaxis)         '��ȡ��������ֵ������ֵ������My_latch_Value

		/// <summary>
		/// ����ָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="LTCLogic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="LTCMode">��������</param>
		/// <returns>�������</returns>
		public int SetLTCSignal(ushort LTCLogic, ushort LTCMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (LTCLogic != 0)
				{
					LTCLogic = 1;
				}

				if (LTCMode != 0)
				{
					LTCMode = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_LTC_PIN(TargetAxis,
					LTCLogic, LTCMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ,SetLTCSignal��չ�����������˲�ʱ����趨
		/// <summary>
		/// ����ָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ,
		/// SetLTCSignal��չ�����������˲�ʱ����趨
		/// </summary>
		/// <param name="LTCLogic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="LTCMode">��������</param>
		/// <param name="LTCFilter">�˲�ʱ�䣬��λ��ms</param>
		/// <returns>�������</returns>
		public int SetLTCSignalExtern(ushort LTCLogic, ushort LTCMode,
			double LTCFilter)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (LTCLogic != 0)
				{
					LTCLogic = 1;
				}

				if (LTCMode != 0)
				{
					LTCMode = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_LTC_PIN_Extern(TargetAxis,
					LTCLogic, LTCMode, LTCFilter);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ
		/// <summary>
		/// ��ȡָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ
		/// </summary>
		/// <param name="LTCLogic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="LTCMode">��������</param>
		/// <returns>�������</returns>
		public int GetLTCSignal(ref ushort LTCLogic, ref ushort LTCMode)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_config_LTC_PIN(TargetAxis,
					ref LTCLogic, ref LTCMode);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ,GetLTCSignal��չ�����������˲�ʱ��
		/// <summary>
		/// ��ȡָ���ᡰ���桱�źŵ���Ч��ƽ���乤����ʽ,
		/// GetLTCSignal��չ�����������˲�ʱ��
		/// </summary>
		/// <param name="LTCLogic">LTC�ź���Ч��ƽ��0������Ч��1������Ч</param>
		/// <param name="LTCMode">��������</param>
		/// <param name="LTCFilter">�˲�ʱ�䣬��λ��ms</param>
		/// <returns>�������</returns>
		public int GetLTCSignalExtern(ref ushort LTCLogic, ref ushort LTCMode,
			ref double LTCFilter)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_config_LTC_PIN_Extern(TargetAxis,
					ref LTCLogic, ref LTCMode, ref LTCFilter);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��������������ֵ
		/// <summary>
		/// ��ȡ��������������ֵ
		/// ע�⣺��λ�������У���δ������������ֻ�����һ�δ���λ�ã�
		///       ֻ�е��ú����������״̬�����ٴ�����
		/// </summary>
		/// <returns>�������ڵı���������������λ��pulse</returns>
		public int GetEncoderLatchValue()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_latch_value(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 0;
			}
		}

		//��ȡָ�����ƿ����������ı�־λ
		/// <summary>
		/// ��ȡָ�����ƿ����������ı�־λ
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>����ֵλ��: 0, ����: 0��ָ������0���д����ź�
		/// ����ֵλ��: 1, ����: 0��1���д����ź�
		/// ����ֵλ��: 2, ����: 0��2���д����ź�
		/// ����ֵλ��: 3, ����: 0��3���д����ź�
		/// ����ֵλ��: 4, ����: 1��ָ������0���������ź�
		/// ����ֵλ��: 5, ����: 1��1���������ź�
		/// ����ֵλ��: 6, ����: 1��2���������ź�
		/// ����ֵλ��: 7, ����: 1��3���������ź�
		/// ����ֵλ��: 8, ����: 1��0��λ��������
		/// ����ֵλ��: 9, ����: 1��1��λ��������
		/// ����ֵλ��: 10, ����: 1��2��λ��������
		/// ����ֵλ��: 11, ����: 1��3��λ��������
		/// ����ֵλ��: 12, ����: 1��ָ������0��λ��������
		/// ����ֵλ��: 13, ����: 1��1��λ��������
		/// ����ֵλ��: 14, ����: 1��2��λ��������
		/// ����ֵλ��: 15, ����: 1��3��λ��������
		/// ����ֵλ��: 16~31, ����:����
		/// </returns>
		public int GetLatchFlag(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 0;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_get_latch_flag(TargetCardNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡ��ǰ���ƿ����������ı�־λ
		/// <summary>
		/// ��ȡ��ǰ���ƿ����������ı�־λ
		/// </summary>
		/// <returns>����ֵλ��: 0, ����: 0��ָ������0���д����ź�
		/// ����ֵλ��: 1, ����: 0��1���д����ź�
		/// ����ֵλ��: 2, ����: 0��2���д����ź�
		/// ����ֵλ��: 3, ����: 0��3���д����ź�
		/// ����ֵλ��: 4, ����: 1��ָ������0���������ź�
		/// ����ֵλ��: 5, ����: 1��1���������ź�
		/// ����ֵλ��: 6, ����: 1��2���������ź�
		/// ����ֵλ��: 7, ����: 1��3���������ź�
		/// ����ֵλ��: 8, ����: 1��0��λ��������
		/// ����ֵλ��: 9, ����: 1��1��λ��������
		/// ����ֵλ��: 10, ����: 1��2��λ��������
		/// ����ֵλ��: 11, ����: 1��3��λ��������
		/// ����ֵλ��: 12, ����: 1��ָ������0��λ��������
		/// ����ֵλ��: 13, ����: 1��1��λ��������
		/// ����ֵλ��: 14, ����: 1��2��λ��������
		/// ����ֵλ��: 15, ����: 1��3��λ��������
		/// ����ֵλ��: 16~31, ����:����
		/// </returns>
		public int GetLatchFlag()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_latch_flag(TargetCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��ȡָ�����ƿ����������ı�־λ
		/// <summary>
		/// ��ȡָ�����ƿ����������ı�־λ
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>����ֵλ��: 0, ����: 0��ָ������0���д����ź�
		/// ����ֵλ��: 1, ����: 0��1���д����ź�
		/// ����ֵλ��: 2, ����: 0��2���д����ź�
		/// ����ֵλ��: 3, ����: 0��3���д����ź�
		/// ����ֵλ��: 4, ����: 1��ָ������0���������ź�
		/// ����ֵλ��: 5, ����: 1��1���������ź�
		/// ����ֵλ��: 6, ����: 1��2���������ź�
		/// ����ֵλ��: 7, ����: 1��3���������ź�
		/// ����ֵλ��: 8, ����: 1��0��λ��������
		/// ����ֵλ��: 9, ����: 1��1��λ��������
		/// ����ֵλ��: 10, ����: 1��2��λ��������
		/// ����ֵλ��: 11, ����: 1��3��λ��������
		/// ����ֵλ��: 12, ����: 1��ָ������0��λ��������
		/// ����ֵλ��: 13, ����: 1��1��λ��������
		/// ����ֵλ��: 14, ����: 1��2��λ��������
		/// ����ֵλ��: 15, ����: 1��3��λ��������
		/// ����ֵλ��: 16~31, ����:����
		/// </returns>
		public LatchFlag GetLatchFlagNew(ushort TargetCardNumber)
		{
			LatchFlag TempLatchFlag;
			TempLatchFlag.Bit0 = false;
			TempLatchFlag.Bit1 = false;
			TempLatchFlag.Bit2 = false;
			TempLatchFlag.Bit3 = false;
			TempLatchFlag.Bit4 = false;
			TempLatchFlag.Bit5 = false;
			TempLatchFlag.Bit6 = false;
			TempLatchFlag.Bit7 = false;
			TempLatchFlag.Bit8 = false;
			TempLatchFlag.Bit9 = false;
			TempLatchFlag.Bit10 = false;
			TempLatchFlag.Bit11 = false;
			TempLatchFlag.Bit12 = false;
			TempLatchFlag.Bit13 = false;
			TempLatchFlag.Bit14 = false;
			TempLatchFlag.Bit15 = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempLatchFlag;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return TempLatchFlag;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_get_latch_flag(TargetCardNumber);

				//Bit0
				if ((TempReturn & 1) == 1)
				{
					TempLatchFlag.Bit0 = true;
				}

				//Bit1
				if (((TempReturn >> 1) & 1) == 1)
				{
					TempLatchFlag.Bit1 = true;
				}

				//Bit2
				if (((TempReturn >> 2) & 1) == 1)
				{
					TempLatchFlag.Bit2 = true;
				}

				//Bit3
				if (((TempReturn >> 3) & 1) == 1)
				{
					TempLatchFlag.Bit3 = true;
				}

				//Bit4
				if (((TempReturn >> 4) & 1) == 1)
				{
					TempLatchFlag.Bit4 = true;
				}

				//Bit5
				if (((TempReturn >> 5) & 1) == 1)
				{
					TempLatchFlag.Bit5 = true;
				}

				//Bit6
				if (((TempReturn >> 6) & 1) == 1)
				{
					TempLatchFlag.Bit6 = true;
				}

				//Bit7
				if (((TempReturn >> 7) & 1) == 1)
				{
					TempLatchFlag.Bit7 = true;
				}

				//Bit8
				if (((TempReturn >> 8) & 1) == 1)
				{
					TempLatchFlag.Bit8 = true;
				}

				//Bit9
				if (((TempReturn >> 9) & 1) == 1)
				{
					TempLatchFlag.Bit9 = true;
				}

				//Bit10
				if (((TempReturn >> 10) & 1) == 1)
				{
					TempLatchFlag.Bit10 = true;
				}

				//Bit11
				if (((TempReturn >> 11) & 1) == 1)
				{
					TempLatchFlag.Bit11 = true;
				}

				//Bit12
				if (((TempReturn >> 12) & 1) == 1)
				{
					TempLatchFlag.Bit12 = true;
				}

				//Bit13
				if (((TempReturn >> 13) & 1) == 1)
				{
					TempLatchFlag.Bit13 = true;
				}

				//Bit14
				if (((TempReturn >> 14) & 1) == 1)
				{
					TempLatchFlag.Bit14 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempLatchFlag.Bit15 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempLatchFlag.Bit15 = true;
				}

				return TempLatchFlag;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempLatchFlag;
			}
		}

		//��ȡ��ǰ���ƿ����������ı�־λ
		/// <summary>
		/// ��ȡ��ǰ���ƿ����������ı�־λ
		/// </summary>
		/// <returns>����ֵλ��: 0, ����: 0��ָ������0���д����ź�
		/// ����ֵλ��: 1, ����: 0��1���д����ź�
		/// ����ֵλ��: 2, ����: 0��2���д����ź�
		/// ����ֵλ��: 3, ����: 0��3���д����ź�
		/// ����ֵλ��: 4, ����: 1��ָ������0���������ź�
		/// ����ֵλ��: 5, ����: 1��1���������ź�
		/// ����ֵλ��: 6, ����: 1��2���������ź�
		/// ����ֵλ��: 7, ����: 1��3���������ź�
		/// ����ֵλ��: 8, ����: 1��0��λ��������
		/// ����ֵλ��: 9, ����: 1��1��λ��������
		/// ����ֵλ��: 10, ����: 1��2��λ��������
		/// ����ֵλ��: 11, ����: 1��3��λ��������
		/// ����ֵλ��: 12, ����: 1��ָ������0��λ��������
		/// ����ֵλ��: 13, ����: 1��1��λ��������
		/// ����ֵλ��: 14, ����: 1��2��λ��������
		/// ����ֵλ��: 15, ����: 1��3��λ��������
		/// ����ֵλ��: 16~31, ����:����
		/// </returns>
		public LatchFlag GetLatchFlagNew()
		{
			LatchFlag TempLatchFlag;
			TempLatchFlag.Bit0 = false;
			TempLatchFlag.Bit1 = false;
			TempLatchFlag.Bit2 = false;
			TempLatchFlag.Bit3 = false;
			TempLatchFlag.Bit4 = false;
			TempLatchFlag.Bit5 = false;
			TempLatchFlag.Bit6 = false;
			TempLatchFlag.Bit7 = false;
			TempLatchFlag.Bit8 = false;
			TempLatchFlag.Bit9 = false;
			TempLatchFlag.Bit10 = false;
			TempLatchFlag.Bit11 = false;
			TempLatchFlag.Bit12 = false;
			TempLatchFlag.Bit13 = false;
			TempLatchFlag.Bit14 = false;
			TempLatchFlag.Bit15 = false;

			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return TempLatchFlag;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_latch_flag(TargetCard);

				//Bit0
				if ((TempReturn & 1) == 1)
				{
					TempLatchFlag.Bit0 = true;
				}

				//Bit1
				if (((TempReturn >> 1) & 1) == 1)
				{
					TempLatchFlag.Bit1 = true;
				}

				//Bit2
				if (((TempReturn >> 2) & 1) == 1)
				{
					TempLatchFlag.Bit2 = true;
				}

				//Bit3
				if (((TempReturn >> 3) & 1) == 1)
				{
					TempLatchFlag.Bit3 = true;
				}

				//Bit4
				if (((TempReturn >> 4) & 1) == 1)
				{
					TempLatchFlag.Bit4 = true;
				}

				//Bit5
				if (((TempReturn >> 5) & 1) == 1)
				{
					TempLatchFlag.Bit5 = true;
				}

				//Bit6
				if (((TempReturn >> 6) & 1) == 1)
				{
					TempLatchFlag.Bit6 = true;
				}

				//Bit7
				if (((TempReturn >> 7) & 1) == 1)
				{
					TempLatchFlag.Bit7 = true;
				}

				//Bit8
				if (((TempReturn >> 8) & 1) == 1)
				{
					TempLatchFlag.Bit8 = true;
				}

				//Bit9
				if (((TempReturn >> 9) & 1) == 1)
				{
					TempLatchFlag.Bit9 = true;
				}

				//Bit10
				if (((TempReturn >> 10) & 1) == 1)
				{
					TempLatchFlag.Bit10 = true;
				}

				//Bit11
				if (((TempReturn >> 11) & 1) == 1)
				{
					TempLatchFlag.Bit11 = true;
				}

				//Bit12
				if (((TempReturn >> 12) & 1) == 1)
				{
					TempLatchFlag.Bit12 = true;
				}

				//Bit13
				if (((TempReturn >> 13) & 1) == 1)
				{
					TempLatchFlag.Bit13 = true;
				}

				//Bit14
				if (((TempReturn >> 14) & 1) == 1)
				{
					TempLatchFlag.Bit14 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempLatchFlag.Bit15 = true;
				}

				//Bit15
				if (((TempReturn >> 15) & 1) == 1)
				{
					TempLatchFlag.Bit15 = true;
				}

				return TempLatchFlag;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return TempLatchFlag;
			}
		}

		//��λָ�����ƿ����������ı�־λ
		/// <summary>
		/// ��λָ�����ƿ����������ı�־λ
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <returns>�������</returns>
		public int ResetLatchFlag(ushort TargetCardNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_latch_flag(TargetCardNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//��λ��ǰ���ƿ����������ı�־λ
		/// <summary>
		/// ��λ��ǰ���ƿ����������ı�־λ
		/// </summary>
		/// <returns>�������</returns>
		public int ResetLatchFlag()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_reset_latch_flag(TargetCard);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ָ�����ƿ������淽ʽΪ���������������ͬʱ����
		/// <summary>
		/// ����ָ�����ƿ������淽ʽΪ���������������ͬʱ����
		/// ע �⣺λ��������ʱֻ֧�ַ���λ������
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="EnableForAllAxis">���淽ʽ ��0���������棬1������ͬʱ����</param>
		/// <returns>�������</returns>
		public int SetLatchMode(ushort TargetCardNumber, ushort EnableForAllAxis)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (EnableForAllAxis != 0)
				{
					EnableForAllAxis = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_latch_mode(TargetCardNumber,
					EnableForAllAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//���õ�ǰ���ƿ������淽ʽΪ���������������ͬʱ����
		/// <summary>
		/// ���õ�ǰ���ƿ������淽ʽΪ���������������ͬʱ����
		/// ע �⣺λ��������ʱֻ֧�ַ���λ������
		/// </summary>
		/// <param name="EnableForAllAxis">���淽ʽ ��0���������棬1������ͬʱ����</param>
		/// <returns>�������</returns>
		public int SetLatchMode(ushort EnableForAllAxis)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (EnableForAllAxis != 0)
				{
					EnableForAllAxis = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_config_latch_mode(TargetCard,
					EnableForAllAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ָ�����ƿ�ȫ������ʱ���ⴥ���ź�ͨ���������ɶ����ź�ͨ�����룬��LTC1, LTC2��Ĭ��ΪLTC1
		/// <summary>
		/// ����ָ�����ƿ�ȫ������ʱ���ⴥ���ź�ͨ����
		/// �����ɶ����ź�ͨ�����룬��LTC1, LTC2��Ĭ��ΪLTC1
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="ChannelNumber">�ź�ͨ��ѡ��ţ�0��LTC1�����ĸ��ᣬ1��LTC2�����ĸ���</param>
		/// <returns>�������</returns>
		public int SetLTCTriggerChannel(ushort TargetCardNumber,
			ushort ChannelNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (ChannelNumber != 0)
				{
					ChannelNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_triger_chunnel(TargetCardNumber,
					ChannelNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//���õ�ǰ���ƿ�ȫ������ʱ���ⴥ���ź�ͨ���������ɶ����ź�ͨ�����룬��LTC1, LTC2��Ĭ��ΪLTC1
		/// <summary>
		/// ���õ�ǰ���ƿ�ȫ������ʱ���ⴥ���ź�ͨ����
		/// �����ɶ����ź�ͨ�����룬��LTC1, LTC2��Ĭ��ΪLTC1
		/// </summary>
		/// <param name="ChannelNumber">�ź�ͨ��ѡ��ţ�0��LTC1�����ĸ��ᣬ1��LTC2�����ĸ���</param>
		/// <returns>�������</returns>
		public int SetLTCTriggerChannel(ushort ChannelNumber)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (ChannelNumber != 0)
				{
					ChannelNumber = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_triger_chunnel(TargetCard,
					ChannelNumber);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ָ�����ƿ�������Speaker��LED������߼���Ĭ��Ϊ����Ч
		/// <summary>
		/// ����ָ�����ƿ�������Speaker��LED������߼���Ĭ��Ϊ����Ч
		/// </summary>
		/// <param name="TargetCardNumber">ָ�����ƿ���, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="OutputSignalLogic">0������Ч��1������Ч</param>
		/// <returns>�������</returns>
		public int SetSpeakerLEDOutputLogic(ushort TargetCardNumber,
			ushort OutputSignalLogic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (OutputSignalLogic != 0)
				{
					OutputSignalLogic = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_speaker_logic(TargetCardNumber,
					OutputSignalLogic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//���õ�ǰ���ƿ�������Speaker��LED������߼���Ĭ��Ϊ����Ч
		/// <summary>
		/// ���õ�ǰ���ƿ�������Speaker��LED������߼���Ĭ��Ϊ����Ч
		/// </summary>
		/// <param name="OutputSignalLogic">0������Ч��1������Ч</param>
		/// <returns>�������</returns>
		public int SetSpeakerLEDOutputLogic(ushort OutputSignalLogic)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (OutputSignalLogic != 0)
				{
					OutputSignalLogic = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_speaker_logic(TargetCard,
					OutputSignalLogic);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		#region "���嵱������"

		//���嵱��Ϊÿ�������Ӧ��ƽ̨��λ����
		//�����嵱�������������������û�ͼ����ÿ���״����������


		/// <summary>
		/// ��ȡ���嵱������ֵ���ƶ�1��������Ҫ������������
		/// </summary>
		/// <param name="PulseQtyPerMM">�ƶ�1��������Ҫ����������</param>
		/// <returns>�������</returns>
		public int GetPulsePerMM(ref double PulseQtyPerMM)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_get_equiv(TargetAxis, ref PulseQtyPerMM);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�������嵱�����ƶ�1��������Ҫ������������
		/// <summary>
		/// �������嵱�����ƶ�1��������Ҫ������������
		/// </summary>
		/// <param name="PulseQtyPerMM">�ƶ�1��������Ҫ����������</param>
		/// <returns>�������</returns>
		public int SetPulsePerMM(double PulseQtyPerMM)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_equiv(TargetAxis, PulseQtyPerMM);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}












		#endregion

		#region "�����˶�"

		//�����˶����ܵ�ʵ��
		//DMC2410C�˶����ƿ�֧�ֵ��������˶����ܡ��ù��������û�����һ������ͨ����Ӧһ���˶�������˶���

		//�����˶�������غ���˵��
		//d2410_set_handwheel_inmode       '�����������������źŵļ�����ʽ
		//d2410_handwheel_move             '����ָ��������������˶�

		//ע �⣺�����������˶���ֻ�з���d2410_decel_stop��d2410_imd_stop�����Ż��˳�����ģʽ
		//��7.14�������˶� 
		//Dim Myaxis,Myinmode As Integer 
		//Dim Mymulti As Double
		//Myaxis = 0                                             '�����˶���Ϊ0���� 
		//Myinmode = 0                                           '�����������뷽ʽΪAB�� 
		//Mymulti = 10                                           '�����������뱶��Ϊ10 
		//d2410_set_handwheel_inmode Myaxis,Myinmode, Mymulti    '���������˶� 
		//d2410_handwheel_move Myaxis                            '���������˶� 
		//d2410_imd_stop Myaxis                                  '����ֹͣ�����˶�


		/// <summary>
		/// �����������������źŵļ�����ʽ
		/// </summary>
		/// <param name="ModeOfInputSignal">��ʾ���뷽ʽ��
		/// 0��A��B��λ����������
		/// 1��˫�����ź�</param>
		/// <param name="Multiply">�������ļ������򼰱������ã�
		/// �������ֵı���, ������ʾĬ�Ϸ��򣬸�����ʾ��Ĭ�Ϸ����෴</param>
		/// <returns>�������</returns>
		public int SetHandWheelMode(ushort ModeOfInputSignal,
			double Multiply)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (ModeOfInputSignal != 0)
				{
					ModeOfInputSignal = 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_set_handwheel_inmode(TargetAxis,
					ModeOfInputSignal, Multiply);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����������������˶�
		/// <summary>
		/// ����������������˶�
		/// </summary>
		/// <returns>�������</returns>
		public int HandWheelMove()
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				int TempReturn = 0;
				TempReturn = (int)d2410_handwheel_move(TargetAxis);

				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//�˳�����ģʽ
		/// <summary>
		/// �˳�����ģʽ
		/// </summary>
		/// <param name="StopMode">�����˶�ֹͣ��ʽ��
		/// 0������ֹͣ��
		/// 1������ֹͣ</param>
		/// <param name="DecelTime">ֹͣʱ�ļ���ʱ��</param>
		/// <returns>�������</returns>
		public int HandWheelStop(ushort StopMode, double DecelTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (StopMode != 0)
				{
					StopMode = 1;
				}
				//ע��: �����������˶���, ֻ�з���d2410_decel_stop��d2410_imd_stop�����Ż��˳�����ģʽ
				int TempReturn = 0;
				if (StopMode == 0)
				{
					TempReturn = (int)d2410_decel_stop(TargetAxis, DecelTime);
				}
				else
				{
					TempReturn = (int)d2410_imd_stop(TargetAxis);
				}
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

		//MC2410C�˶����ƿ��������˶��켣ʱ�����þ�������Ҳ������������ꡣ
		//����ģʽ�����ŵ㣬
		//�磺�ھ�������ģʽ����һϵ������㶨��һ�����ߣ����Ҫ�޸��м�ĳ������ʱ������Ӱ�����������ꣻ
		//���������ģʽ�У���һϵ������㶨��һ�����ߣ���ѭ����������ظ��������߹켣��Ρ�

		//*************************
		//��������
		//������ͬʱ�˶�����Ϊ����������
		//DMC2410C�˶����ƿ����ſ����Կ���4�����Զ��ַ�ʽ�˶������õ��У�����������ֱ�߲岹��Բ���岹��
		//DMC2410C���ƿ����Կ��ƶ�����ͬʱִ��d2410_t_move��d2410_s_move���൥���˶�������
		//��νͬʱִ�У����ڳ�����˳�����d2410_t_move��d2410_s_move�Ⱥ�������Ϊ����ִ���ٶȺܿ죬
		//��˲�伸���������ʼ�˶������˵ĸо�����ͬʱ��ʼ�˶��� 
		//���������ڸ����ٶ����ò���ʱ������ֹͣʱ�䲻ͬ����������յ�֮���˶��Ĺ켣Ҳ����ֱ��
		//*************************

		#region "���Բ岹"

		//ֱ�߲岹�˶�
		//DMC2410C�����Խ�������2�ᡢ3���4��ֱ�߲岹���岹�����ɿ��ƿ���Ӳ��ִ�У�
		//�û�ֻ�轫�岹�˶����ٶȡ����ٶȡ��յ�λ�õȲ���д����غ������������岹�����еļ��㹤����

		//ֱ�߲岹�˶���غ���˵��
		//d2410_t_line2                  '��ָ�����������ԳƵ����μӼ��ٲ岹�˶�
		//d2410_t_line3                  '��ָ�����������ԳƵ����μӼ��ٲ岹�˶�
		//d2410_t_line4                  'ָ�������ԶԳƵ������ٶ��������岹�˶�
		//'d2410_set_vector_profile       '�趨�岹ʸ���˶����ߵ�����ٶȡ�����ʱ�䡢����ʱ��

		//����7.6��XY��ֱ�߲岹 
		//Dim AxisArray(2) as Integer AxisArray(0)=0     '����岹0��ΪX�� 
		//AxisArray(1)=1                                 '����岹1��ΪY�� 
		//d2410_set_vector_profile 0,5000,0.1,0.2 
		//d2410_t_line2 AxisArray(0),30000,AxisArray(1),40000,0
		//������ʹX��Y��������ģʽֱ�߲岹�˶���
		//����ز���Ϊ�� 
		//��X = 30000 pulse 
		//��Y = 40000 pulse 
		//���ʸ���ٶ� = 5000 p/s ��0��,1����ٶ�Ϊ3000��4000 p/s�� 
		//���μ���ʱ�� = 0.1 s 
		//���μ���ʱ�� = 0.2 s

		/// <summary>
		/// ����ֱ�߲岹: ָ�����������ԶԳƵ������ٶ����������Բ岹�˶�
		/// </summary>
		/// <param name="NoOfAxis1">ָ������岹�ĵ�һ�᡾��ţ���1~N��</param>
		/// <param name="DistanceOfAxis1">ָ����һ���λ��ֵ����λ��pulse</param>
		/// <param name="NoOfAxis2">ָ������岹�ĵڶ��᡾��ţ���1~N��</param>
		/// <param name="DistanceOfAxis2">ָ���ڶ����λ��ֵ����λ��pulse</param>
		/// <param name="PositionMode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="AcclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="DeclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int TwoAxisLinearMove(ushort NoOfAxis1, int DistanceOfAxis1,
			ushort NoOfAxis2, int DistanceOfAxis2, ushort PositionMode,
			ushort MinVelocity, ushort MaxVelocity, double AcclTime,
			double DeclTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (NoOfAxis1 == NoOfAxis2)
				{
					MessageBox.Show("The parameter 'NoOfAxis1' and 'NoOfAxis2' can't be set as the same axis, please revise it.");
					return 1;
				}

				if (NoOfAxis1 < 1 || NoOfAxis1 > (AvailableCardQty * 4)
					|| NoOfAxis2 < 1 || NoOfAxis2 > (AvailableCardQty * 4))
				{
					MessageBox.Show("The value for target axis should be : 1~"
						+ (AvailableCardQty * 4) + " ,please revise the parameter.");
					return 1;
				}

				NoOfAxis1 = (ushort)(NoOfAxis1 - 1);
				NoOfAxis2 = (ushort)(NoOfAxis2 - 1);

				if (PositionMode != 0)
				{
					PositionMode = 1;
				}

				//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="Min_Vel">��������</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<returns>�������</returns>
				//Declare Function d2410_set_vector_profile Lib "DMC2410.dll" 
				//(ByVal Min_Vel As Double, ByVal Max_Vel As Double, 
				//ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity, MaxVelocity,
					AcclTime, DeclTime);
				TempReturn += (int)d2410_t_line2(NoOfAxis1, DistanceOfAxis1,
					NoOfAxis2, DistanceOfAxis2, PositionMode);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ֱ�߲岹: ָ�����������ԶԳƵ������ٶ��������岹�˶�
		/// <summary>
		/// ����ֱ�߲岹: ָ�����������ԶԳƵ������ٶ��������岹�˶�
		/// </summary>
		/// <param name="AxisArray">����б��ָ��</param>
		/// <param name="DistanceOfAxis1">ָ��axis[0]���λ��ֵ����λ��pulse</param>
		/// <param name="DistanceOfAxis2">ָ��axis[1]���λ��ֵ����λ��pulse</param>
		/// <param name="DistanceOfAxis3">ָ��axis[2]���λ��ֵ����λ��pulse</param>
		/// <param name="PositionMode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="AcclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="DeclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns></returns>
		public int ThreeAxisLinearMove(ref ushort[] AxisArray, int DistanceOfAxis1,
			int DistanceOfAxis2, int DistanceOfAxis3, ushort PositionMode,
			ushort MinVelocity, ushort MaxVelocity, double AcclTime, double DeclTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (PositionMode != 0)
				{
					PositionMode = 1;
				}

				if (AxisArray.Length < 3)
				{
					MessageBox.Show("The length of parameter 'AxisArray' doesn't equal to 3, please revise it.");
					return 1;
				}

				if (AxisArray[0] == AxisArray[1]
					|| AxisArray[0] == AxisArray[2]
					|| AxisArray[1] == AxisArray[2])
				{
					MessageBox.Show("The three axises of parameter 'AxisArray' can't be set as the same axis, please revise it.");
					return 1;
				}

				for (int a = 0; a < AxisArray.Length; a++)
				{
					if (AxisArray[a] < 1 || AxisArray[a] > (AvailableCardQty * 4))
					{
						MessageBox.Show("The value for target axis should be : 1~"
							+ (AvailableCardQty * 4) + " ,please revise the parameter.");
						return 1;
					}
					else
					{
						AxisArray[a] = (ushort)(AxisArray[a] - 1);
					}
				}

				//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="Min_Vel">��������</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<returns>�������</returns>
				//Declare Function d2410_set_vector_profile Lib "DMC2410.dll" 
				//(ByVal Min_Vel As Double, ByVal Max_Vel As Double, 
				//ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity,
					MaxVelocity, AcclTime, DeclTime);
				TempReturn = (int)d2410_t_line3(AxisArray, DistanceOfAxis1,
					DistanceOfAxis2, DistanceOfAxis3, PositionMode);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����ֱ�߲岹: ָ�����ƿ��������ԶԳƵ������ٶ��������岹�˶�
		/// <summary>
		/// ����ֱ�߲岹: ָ�����ƿ��������ԶԳƵ������ٶ��������岹�˶�
		/// </summary>
		/// <param name="TargetCardNumber">ָ���岹�˶��İ忨��, ��Χ��1~N��NΪ���ţ�</param>
		/// <param name="DistanceOfAxis1">ָ����һ���λ��ֵ����λ��pulse</param>
		/// <param name="DistanceOfAxis2">ָ���ڶ����λ��ֵ����λ��pulse</param>
		/// <param name="DistanceOfAxis3">ָ���������λ��ֵ����λ��pulse</param>
		/// <param name="DistanceOfAxis4">ָ���������λ��ֵ����λ��pulse</param>
		/// <param name="PositionMode">λ��ģʽ�趨��0�����λ�ƣ�1������λ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="AcclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="DeclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int FourAxisLinearMove(ushort TargetCardNumber, int DistanceOfAxis1,
			int DistanceOfAxis2, int DistanceOfAxis3, int DistanceOfAxis4, ushort PositionMode,
			ushort MinVelocity, ushort MaxVelocity, double AcclTime, double DeclTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (TargetCardNumber > AvailableCardQty
					|| TargetCardNumber < 1)
				{
					MessageBox.Show("There is(are) " + AvailableCardQty + " card(s) available in the PC system, please revise the parameter and retry.\r\n"
						+ "PCϵͳ���� " + AvailableCardQty + "���˶����ƿ������޸Ĳ���С�ڵ��ڴ���ֵ��",
						"����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return 1;
				}

				TargetCardNumber = (ushort)(TargetCardNumber - 1);

				if (PositionMode != 0)
				{
					PositionMode = 1;
				}

				//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="Min_Vel">��������</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<returns>�������</returns>
				//Declare Function d2410_set_vector_profile Lib "DMC2410.dll" 
				//(ByVal Min_Vel As Double, ByVal Max_Vel As Double,
				//ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity, MaxVelocity,
					AcclTime, DeclTime);
				TempReturn += (int)d2410_t_line4(TargetCardNumber, DistanceOfAxis1,
					DistanceOfAxis2, DistanceOfAxis3, DistanceOfAxis4, PositionMode);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion


		#region "Բ���岹"

		//Բ���岹�˶�
		//DMC2410C������������֮����Խ���Բ���岹��
		//Բ���岹��Ϊ���λ��Բ���岹�;���λ��Բ���岹��
		//�˶��ķ����Ϊ˳ʱ�루CW������ʱ�루CCW����

		//Բ���岹��غ���˵��
		//d2410_arc_move             '��ָ���Ķ���������λ��Բ���岹�˶���
		//d2410_rel_arc_move         '��ָ���Ķ��������λ��Բ���岹�˶���

		//����7.7��XY��Բ���岹 
		//Dim AxisArray(2) As Integer 
		//Dim Pos(2), Cen(2) As Long 
		//AxisArray(0)=0                                  '����0��Ϊ�岹X��
		//AxisArray(1)=1                                  '����1��Ϊ�岹Y�� 
		//Pos(0) = 5000 Pos(1) = -5000                    '�����յ����� 
		//Cen(0) = 5000 Cen(1) = 0                        '����Բ������ 
		//'d2410_set_vector_profile 1000,3000,0.1,0.2      '����ʸ���ٶ����� 
		//d2410_arc_move AxisArray(0), Pos(0), Cen(0), 0  'XY�����˳ʱ�뷽�����Բ���岹�˶��� 
		//                                                '�յ㣨5000, -5000����Բ�ģ�5000, 0��

		/// <summary>
		/// ����Բ������λ�ò岹����λ��pulse����ָ������������Ե�ǰλ��Ϊ��㣬
		/// ��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// </summary>
		/// <param name="AxisArray">����б�ָ��</param>
		/// <param name="TargetABSPos">Ŀ�����λ���б�ָ�룬��λ��pulse</param>
		/// <param name="CenterABSPos">Բ�ľ���λ���б�ָ�룬��λ��pulse</param>
		/// <param name="ArcDirection">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="AcclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="DeclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int TwoAxisArcABSMove(ref ushort[] AxisArray, ref int[] TargetABSPos,
			ref int[] CenterABSPos, ushort ArcDirection, ushort MinVelocity,
			ushort MaxVelocity, double AcclTime, double DeclTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (ArcDirection != 0)
				{
					ArcDirection = 1;
				}

				if (AxisArray.Length < 2
					|| TargetABSPos.Length < 2
					|| CenterABSPos.Length < 2)
				{
					MessageBox.Show("The length of parameter 'AxisArray'/'TargetABSPos'/'CenterABSPos' doesn't equal to 2, please revise it.");
					return 1;
				}

				if (AxisArray[0] == AxisArray[1])
				{
					MessageBox.Show("The two axises of parameter 'AxisArray' can't be set as the same axis, please revise it.");
					return 1;
				}

				for (int a = 0; a < AxisArray.Length; a++)
				{
					if (AxisArray[a] < 1 || AxisArray[a] > (AvailableCardQty * 4))
					{
						MessageBox.Show("The value for target axis should be : 1~"
							+ (AvailableCardQty * 4) + " ,please revise the parameter.");
						return 1;
					}
					else
					{
						AxisArray[a] = (ushort)(AxisArray[a] - 1);
					}
				}

				//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="Min_Vel">��������</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<returns>�������</returns>
				//Declare Function d2410_set_vector_profile Lib "DMC2410.dll" 
				//(ByVal Min_Vel As Double, ByVal Max_Vel As Double,
				//ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity,
					MaxVelocity, AcclTime, DeclTime);
				TempReturn += (int)d2410_arc_move(AxisArray, TargetABSPos,
					CenterABSPos, ArcDirection);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����Բ������λ�ò岹����λ��mm��
		/// <summary>
		/// ����Բ������λ�ò岹����λ��mm����ָ������������Ե�ǰλ��Ϊ��㣬
		/// ��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// </summary>
		/// <param name="AxisArray">����б�ָ��</param>
		/// <param name="TargetABSPos">Ŀ�����λ���б�ָ�룬��λ��mm</param>
		/// <param name="CenterABSPos">Բ�ľ���λ���б�ָ�룬��λ��mm</param>
		/// <param name="ArcDirection">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��mm/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��mm/s</param>
		/// <param name="AcclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="DeclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int TwoAxisArcABSMoveInMM(ref ushort[] AxisArray, ref double[] TargetABSPos,
			ref double[] CenterABSPos, ushort ArcDirection, ushort MinVelocity,
			ushort MaxVelocity, double AcclTime, double DeclTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (ArcDirection != 0)
				{
					ArcDirection = 1;
				}

				if (AxisArray.Length < 2
					|| TargetABSPos.Length < 2
					|| CenterABSPos.Length < 2)
				{
					MessageBox.Show("The length of parameter 'AxisArray'/'TargetABSPos'/'CenterABSPos' doesn't equal to 2, please revise it.");
					return 1;
				}

				if (AxisArray[0] == AxisArray[1])
				{
					MessageBox.Show("The two axises of parameter 'AxisArray' can't be set as the same axis, please revise it.");
					return 1;
				}

				for (int a = 0; a < AxisArray.Length; a++)
				{
					if (AxisArray[a] < 1 || AxisArray[a] > (AvailableCardQty * 4))
					{
						MessageBox.Show("The value for target axis should be : 1~"
							+ (AvailableCardQty * 4) + " ,please revise the parameter.");
						return 1;
					}
					else
					{
						AxisArray[a] = (ushort)(AxisArray[a] - 1);
					}
				}

				//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="Min_Vel">��������</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<returns>�������</returns>
				//Declare Function d2410_set_vector_profile Lib "DMC2410.dll" 
				//(ByVal Min_Vel As Double, ByVal Max_Vel As Double,
				//ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity,
					MaxVelocity, AcclTime, DeclTime);
				TempReturn += (int)d2410_arc_move_unitmm(AxisArray, TargetABSPos,
					CenterABSPos, ArcDirection);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����Բ�����λ�ò岹
		/// <summary>
		/// ����Բ�����λ�ò岹����λ��pulse����ָ������������Ե�ǰλ��Ϊ��㣬
		/// ��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// </summary>
		/// <param name="AxisArray">����б�ָ��</param>
		/// <param name="TargetRelativePos">Ŀ�����λ���б�ָ�룬��λ��pulse</param>
		/// <param name="CenterRelativePos">Բ�����λ���б�ָ�룬��λ��pulse</param>
		/// <param name="ArcDirection">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��pulse/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��pulse/s</param>
		/// <param name="AcclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="DeclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int TwoAxisArcRelativeMove(ref ushort[] AxisArray, ref int[] TargetRelativePos,
			ref int[] CenterRelativePos, ushort ArcDirection, ushort MinVelocity,
			ushort MaxVelocity, double AcclTime, double DeclTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (ArcDirection != 0)
				{
					ArcDirection = 1;
				}

				if (AxisArray.Length < 2
					|| TargetRelativePos.Length < 2
					|| CenterRelativePos.Length < 2)
				{
					MessageBox.Show("The length of parameter 'AxisArray'/'TargetABSPos'/'CenterABSPos' doesn't equal to 2, please revise it.");
					return 1;
				}

				if (AxisArray[0] == AxisArray[1])
				{
					MessageBox.Show("The two axises of parameter 'AxisArray' can't be set as the same axis, please revise it.");
					return 1;
				}

				for (int a = 0; a < AxisArray.Length; a++)
				{
					if (AxisArray[a] < 1 || AxisArray[a] > (AvailableCardQty * 4))
					{
						MessageBox.Show("The value for target axis should be : 1~"
							+ (AvailableCardQty * 4) + " ,please revise the parameter.");
						return 1;
					}
					else
					{
						AxisArray[a] = (ushort)(AxisArray[a] - 1);
					}
				}

				//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="Min_Vel">��������</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<returns>�������</returns>
				//Declare Function d2410_set_vector_profile Lib "DMC2410.dll" 
				//(ByVal Min_Vel As Double, ByVal Max_Vel As Double,
				//ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity,
					MaxVelocity, AcclTime, DeclTime);
				TempReturn += (int)d2410_rel_arc_move(AxisArray, TargetRelativePos,
					CenterRelativePos, ArcDirection);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		//����Բ�����λ�ò岹����λ��mm��
		/// <summary>
		/// ����Բ�����λ�ò岹����λ��mm����ָ������������Ե�ǰλ��Ϊ��㣬
		/// ��ָ����Բ�ġ�Ŀ�����λ�úͷ�����Բ���岹�˶�
		/// </summary>
		/// <param name="AxisArray">����б�ָ��</param>
		/// <param name="TargetRelativePos">Ŀ�����λ���б�ָ�룬��λ��mm</param>
		/// <param name="CenterRelativePos">Բ�����λ���б�ָ�룬��λ��mm</param>
		/// <param name="ArcDirection">Բ������0��˳ʱ�룬1����ʱ��</param>
		/// <param name="MinVelocity">��С�ٶȣ���λ��mm/s</param>
		/// <param name="MaxVelocity">����ٶȣ���λ��mm/s</param>
		/// <param name="AcclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <param name="DeclTime">�ܼ���ʱ�䣬��λ��s</param>
		/// <returns>�������</returns>
		public int TwoAxisArcRelativeMoveInMM(ref ushort[] AxisArray, ref double[] TargetRelativePos,
			ref double[] CenterRelativePos, ushort ArcDirection, ushort MinVelocity,
			ushort MaxVelocity, double AcclTime, double DeclTime)
		{
			try
			{
				if (SuccessBuiltNew == false)
				{
					MessageBox.Show("Invalid operation, because you failed to initialize this class.\r\n"
						+ "��Ч��������Ϊ����ʵ��������ʱ��ʼ��ʧ�ܣ��޷������µ�ʵ����"
						 , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 1;
				}

				if (ArcDirection != 0)
				{
					ArcDirection = 1;
				}

				if (AxisArray.Length < 2
					|| TargetRelativePos.Length < 2
					|| CenterRelativePos.Length < 2)
				{
					MessageBox.Show("The length of parameter 'AxisArray'/'TargetABSPos'/'CenterABSPos' doesn't equal to 2, please revise it.");
					return 1;
				}

				if (AxisArray[0] == AxisArray[1])
				{
					MessageBox.Show("The two axises of parameter 'AxisArray' can't be set as the same axis, please revise it.");
					return 1;
				}

				for (int a = 0; a < AxisArray.Length; a++)
				{
					if (AxisArray[a] < 1 || AxisArray[a] > (AvailableCardQty * 4))
					{
						MessageBox.Show("The value for target axis should be : 1~"
							+ (AvailableCardQty * 4) + " ,please revise the parameter.");
						return 1;
					}
					else
					{
						AxisArray[a] = (ushort)(AxisArray[a] - 1);
					}
				}

				//�趨�岹ʸ���˶����ߵ�S�β����������ٶȡ�����ʱ�䡢����ʱ��
				//<param name="Min_Vel">��������</param>
				//<param name="Max_Vel">����ٶȣ���λ��pulse/s</param>
				//<param name="Tacc">�ܼ���ʱ�䣬��λ��s</param>
				//<param name="Tdec">�ܼ���ʱ�䣬��λ��s</param>
				//<returns>�������</returns>
				//Declare Function d2410_set_vector_profile Lib "DMC2410.dll" 
				//(ByVal Min_Vel As Double, ByVal Max_Vel As Double,
				//ByVal Tacc As Double, ByVal Tdec As Double) As Int32

				int TempReturn = 0;
				TempReturn = (int)d2410_set_vector_profile(MinVelocity,
					MaxVelocity, AcclTime, DeclTime);
				TempReturn += (int)d2410_rel_arc_move_unitmm(AxisArray, TargetRelativePos,
					CenterRelativePos, ArcDirection);
				return TempReturn;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return 1;
			}
		}

		#endregion

	}

}
