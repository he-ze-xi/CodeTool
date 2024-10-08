
using System.Text.RegularExpressions;

namespace IPGLaser_9
{
	public class IPGLaser
	{
		private TCPClientManager _TCPClientManager;
		public bool InitLaser = false;

		/// <summary>
		/// ����
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="port"></param>
		public async void Connected(string ip, int port)
		{
			_TCPClientManager = new TCPClientManager();
			await _TCPClientManager.ConnectedAsync(ip, port);
		}

		/// <summary>
		/// �Ͽ�����
		/// </summary>
		public void CloseConnected()
		{
			_TCPClientManager.CloseConnected();
		}

		/// <summary>
		/// get and set the Pulse Frequency
		/// </summary>
		public async Task<string> GetPulseFrequency()
		{
			try
			{
				string res = await _TCPClientManager.SendAndReceiveAsync("RPRR");
				res = res.Replace('\r', ' ');

				string numberPattern = @"\d+";
				Match number = Regex.Match(res, numberPattern);
				if (number.Success)
				{
					return number.Value;
				}
				else
				{
					return "0";
				}
			}
			catch (Exception ex)
			{
				LoggerManager.LogError($"Get Pulse Frequency failed, {ex}");
				return "0";
			}
		}
		public async Task SetPulseFrequency(double value)
		{
			if (!InitLaser) { return; }
			await _TCPClientManager.SendAndReceiveAsync("SPRR" + value);
		}

		/// <summary>
		/// get and set the Pulse Width
		/// </summary>
		public async Task<string> GetPulseWidth()
		{
			try
			{
				string res = await _TCPClientManager.SendAndReceiveAsync("RPRR");
				res = res.Replace('\r', ' ');
				var resList = res.Split('\r');

				foreach (var item in resList)
				{
					if (item.Contains("RPW"))
					{
						string numberPattern = @"\d+";
						Match number = Regex.Match(item, numberPattern);
						if (number.Success)
						{
							return number.Value;
						}
						else
						{
							return "0";
						}
					}
				}
				return "0";
			}
			catch (Exception ex)
			{
				LoggerManager.LogError($"Get Pulse Frequency failed, {ex}");
				return "0";
			}
		}
		public async Task SetPulseWidth(double value)
		{
			if (!InitLaser) { return; }
			await _TCPClientManager.SendAndReceiveAsync("SPW" + value);
		}

		/// <summary>
		/// ���ü���������С
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetDiodeCurrent()
		{
			try
			{
				if (!InitLaser) { return "0"; }
				string res = await _TCPClientManager.SendAndReceiveAsync("RPRR");
				res = res.Replace('\r', ' ');
				var resList = res.Split('\r');

				foreach (var item in resList)
				{
					if (item.Contains("RPW"))
					{
						string numberPattern = @"\d+";
						Match number = Regex.Match(item, numberPattern);
						if (number.Success)
						{
							return number.Value;
						}
						else
						{
							return "0";
						}
					}
				}
				return "0";
			}
			catch (Exception ex)
			{
				LoggerManager.LogError($"Get Pulse Frequency failed, {ex}");
				return "0";
			}
		}
		public async Task SetDiodeCurrent(double value)
		{
			if (!InitLaser) { return; }
			await _TCPClientManager.SendAndReceiveAsync("SDC" + value);
		}

		/// <summary>
		/// ���ü���ģʽΪGate
		/// </summary>
		/// <returns></returns>
		public async Task SetGateMode()
		{
			if (!InitLaser) { return; }
			await _TCPClientManager.SendAndReceiveAsync("EGM");
		}

		/// <summary>
		/// start Emission
		/// </summary>
		/// <returns></returns>
		public async Task Emission(bool flag)
		{
			if (!InitLaser) { return; }
			if (flag)
			{
				await _TCPClientManager.SendAndReceiveAsync("EMON");
			}
			else
			{
				await _TCPClientManager.SendAndReceiveAsync("EMOFF");
			}
		}

		/// <summary>
		/// ���
		/// </summary>
		/// <param name="flag"></param>
		/// <returns></returns>
		public async Task AimingBeam(bool flag)
		{
			if (!InitLaser) { return; }
			if (flag)
			{
				await _TCPClientManager.SendAndReceiveAsync("ABN");
			}
			else
			{
				await _TCPClientManager.SendAndReceiveAsync("ABF");
			}
		}
	}

}
