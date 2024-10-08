
namespace BaslerCamera_8
{
	/// <summary>
	/// ������࣬���ڶ�������Ļ�������
	/// </summary>
	public abstract class BaseCamera
	{
		public abstract void GetCameraInfoDic();//��ȡ���������Ϣ
		public abstract void ConnectedCamera(string serialNumber);//���ӵ�ָ�����Ƶ����
		public abstract void DisconnectedCamera();//�Ͽ��������
		public abstract void GrabOnce();//���βɼ�
		public abstract void GrabContinue();//�����ɼ�
		public abstract void StopGrab();//ֹͣ�ɼ�
		public abstract void SaveImage(string savePath);//����ͼ��
		public virtual double Exposure { get; set; }//����ع�
		public virtual double ImageWidth { get; set; }//�����
		public virtual double ImageHeight { get; set; }//�����

		/// <summary>
		/// ͼ����Ϣ
		/// </summary>
		public struct CameraData
		{
			public byte[] data; // ����
			public int width; // ��
			public int height; // ��
		}
	}
}
