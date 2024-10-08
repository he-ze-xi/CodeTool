using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows;

namespace BaslerCamera_8
{
	/// <summary>
	/// Basler相机二次封装的使用方法。
	/// </summary>
	public class CameraUse
	{
		#region Camera

		#region 相机参数相关
		private BaslerCamera Camera = new BaslerCamera();
		private bool InitCamera = false; //相机是否初始化
		#endregion

		/// <summary>
		/// 获取相机信息
		/// </summary>
		private void GetCameraInfo()
		{
			if (Camera.CameraNameDic.Count > 0)
			{
				foreach (var cameraInfo in Camera.CameraNameDic)
				{
					if (!this.CameraNameList.Items.Contains(cameraInfo.Key))
					{
						this.CameraNameList.Items.Add(cameraInfo.Key);
					}
				}
			}
		}

		/// <summary>
		/// 连接/断开相机
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ConnectedCamera_Click(object sender, RoutedEventArgs e)
		{
			if (this.CameraNameList.Text != null && this.CameraNameList.Text != "" && (bool)this.ConnectedCameraButton.IsChecked)
			{
				Dispatcher.BeginInvoke(new Action(() =>
				{
					Camera.ConnectedCamera((string)Camera.CameraNameDic[this.CameraNameList.Text]["SerialNumber"]);

					// 显示相机曝光值及大小
					_ParametersData.CameraExposure = Camera.Exposure;
					_ParametersData.ImageWidth = Camera.ImageWidth;
					_ParametersData.ImageHeight = Camera.ImageHeight;

					Camera.ImageCaptured += OnImageCaptured;

					InitCamera = true;
					LoggerManager.LogInfo("相机连接成功");
				}));
			}
			else //断开相机
			{
				this.ConnectedCameraButton.IsChecked = false;
				// 停止取图
				if (this.CameraGrabMovement.Text.ToLower().Contains("stop"))
				{
					GrabButton_Click(sender, e);
				}

				Camera.DisconnectedCamera();
				Camera.ImageCaptured -= OnImageCaptured;

				InitCamera = false;

				if (this.CameraNameList.Text == null || this.CameraNameList.Text == "")
				{
					MessageBox.Show("No Camera!!!");
					LoggerManager.LogError("没有找到相机");
				}
				else
				{
					LoggerManager.LogInfo("相机断开连接");
				}

			}
		}

		/// <summary>
		/// 相机回调取图，通过委托传输数据
		/// </summary>
		/// <param name="imageData"></param>
		private void OnImageCaptured(BaseCamera.CameraData imageData)
		{
			try
			{
				BitmapImage img = ImageConvert.ConvertImageDataToBitmapImage(imageData.data, imageData.width, imageData.height);

				this.Dispatcher.Invoke(new Action(() =>
				{
					if (this.TabControl.SelectedIndex == 0)
					{
						this.Picture.Source = img;
					}
					else if (this.TabControl.SelectedIndex == 1)
					{
						this.Picture_Motor.Source = img;
					}
				}));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// 相机 取图/停止取图
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GrabButton_Click(object sender, RoutedEventArgs e)
		{
			if (!InitCamera) { return; }

			if (this.CameraGrabMovement.Text.ToLower().Contains("start")) // 相机取图
			{
				if ((bool)this.GrabOnceButton.IsChecked)
				{
					Camera.GrabOnce();
				}
				if ((bool)this.GrabContinueButton.IsChecked)
				{
					Camera.GrabContinue();
					this.CameraGrabMovement.Text = "Grab Stop";
					this.GrabButton.Background = Brushes.Red;
				}
			}
			else //停止取图
			{
				Camera.StopGrab();

				this.CameraGrabMovement.Text = "Grab Start";
				this.GrabButton.Background = Brushes.Green;
			}
		}

		/// <summary>
		/// 相机曝光修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CameraExposure_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!InitCamera) { return; }
			try
			{
				Camera.Exposure = _ParametersData.CameraExposure;
			}
			catch (Exception ex)
			{
				LoggerManager.LogError($"设置相机曝光失败:{ex.Message}");
			}
		}

		/// <summary>
		/// 重新搜索相机
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ReSearchCameraButton_Click(object sender, RoutedEventArgs e)
		{
			Camera.GetCameraInfoDic();

			// 如果找到相机
			if (Camera.CameraNameDic.Count > 0)
			{
				GetCameraInfo();
			}
			else
			{
				MessageBox.Show("No camera found!!!");
			}
		}

		/// <summary>
		/// 保存图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveImageButton_Click(object sender, RoutedEventArgs e)
		{
			if (!InitCamera) { return; }

			// 停止取图
			if (this.CameraGrabMovement.Text.ToLower().Contains("stop"))
			{
				GrabButton_Click(sender, e);
			}

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "image(*.bmp)|*.bmp|all file (*.*)|*.*";
			saveFileDialog.Title = "Save Image";

			if (saveFileDialog.ShowDialog() == true)
			{
				string strSavePath = saveFileDialog.FileName;
				Camera.SaveImage(strSavePath);
			}
		}

		/// <summary>
		/// 相机标定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CameraCalibrationButton_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// 修改相机标定参数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModifyParameterButton_Click(object sender, RoutedEventArgs e)
		{
			if (!_ParametersData.ModifyParameterButtonClicked)
			{
				_ParametersData.ModifyParameterButtonClicked = true;

				LoadCameraCalibrationParameters(ParametersManager.GetPatameteName(ParametersManager.PName.Calibration));
			}
			else
			{
				_ParametersData.ModifyParameterButtonClicked = false;

				SaveCameraCalibrationParameters(ParametersManager.GetPatameteName(ParametersManager.PName.Calibration));
			}
		}

		/// <summary>
		/// 读取标定参数
		/// </summary>
		/// <param name="parameterName"></param>
		private void LoadCameraCalibrationParameters(string parameterName)
		{
			var parametr = ParametersManager.LoadParameters(parameterName);
			if (parametr.Count > 0)
			{
				_ParametersData.GRID_ROW_SPACING = double.Parse((string)parametr[parameterName][GRID_ROW_SPACING.Name]);
				_ParametersData.GRID_COLUMN_SPACING = double.Parse((string)parametr[parameterName][GRID_COLUMN_SPACING.Name]);
				_ParametersData.GRID_ROW_NUMBER = double.Parse((string)parametr[parameterName][GRID_ROW_NUMBER.Name]);
				_ParametersData.GRID_COLUMN_NUMBER = double.Parse((string)parametr[parameterName][GRID_COLUMN_NUMBER.Name]);
				_ParametersData.Pixel_To_World_Ratio = double.Parse((string)parametr[parameterName][Pixel_To_World_Ratio.Name]);
			}
			else
			{
				this.GRID_ROW_SPACING.Text = "1";
				this.GRID_COLUMN_SPACING.Text = "1";
				this.GRID_ROW_NUMBER.Text = "1";
				this.GRID_COLUMN_NUMBER.Text = "1";
			}
		}

		/// <summary>
		/// 保存标定参数
		/// </summary>
		/// <param name="parameterName"></param>
		private void SaveCameraCalibrationParameters(string parameterName)
		{
			List<TextBox> keys = new List<TextBox>()
			{
				GRID_ROW_SPACING, GRID_COLUMN_SPACING, GRID_ROW_NUMBER, GRID_COLUMN_NUMBER, Pixel_To_World_Ratio
			};

			ParametersManager.SaveParameters(keys, parameterName);
		}
		#endregion
	}
}
