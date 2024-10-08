
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using System.Drawing.Imaging;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Color = System.Drawing.Color;

namespace BaslerCamera_8
{

	public static class ImageConvert
	{
		/// <summary>
		/// ��ͼ������תΪbitmap
		/// </summary>
		/// <param name="imageData"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns></returns>
		public static Bitmap ConvertImageDataToBitmap(byte[] imageData, int width, int height)
		{
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
			// ���õ�ɫ��
			ColorPalette palette = bitmap.Palette;
			for (int i = 0; i < 256; i++)
				palette.Entries[i] = Color.FromArgb(i, i, i);
			bitmap.Palette = palette;

			// ��ͼ������д��Bitmap����
			BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			System.Runtime.InteropServices.Marshal.Copy(imageData, 0, bmpData.Scan0, imageData.Length);
			bitmap.UnlockBits(bmpData);

			return bitmap;
		}

		/// <summary>
		/// ��ͼ������תΪbitmapImage
		/// </summary>
		/// <param name="imageData"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns></returns>
		public static BitmapImage ConvertImageDataToBitmapImage(byte[] imageData, int width, int height)
		{
			return ConvertBitmapToBitmapImage(ConvertImageDataToBitmap(imageData, width, height));
		}

		private static BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
		{
			BitmapImage bitmapImage = new BitmapImage();
			using (var memory = new MemoryStream())
			{
				bitmap.Save(memory, ImageFormat.Bmp);
				memory.Position = 0;
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();
				bitmapImage.Freeze();
			}

			//// ����Bitmapͼ��Ϊ������ʽ����PNG��
			//PngBitmapEncoder encoder = new PngBitmapEncoder();
			//encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
			//using (FileStream fs = new FileStream("bitmap_as_png.png", FileMode.Create))
			//{
			//    encoder.Save(fs);
			//}

			return bitmapImage;
		}
	}
}
