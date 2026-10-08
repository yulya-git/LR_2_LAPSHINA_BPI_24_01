using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace LR_2_LAPSHINA_BPI_24_01
{
    /// <summary>
    /// Конвертирует System.Drawing.Bitmap (из Resources.resx)
    /// в System.Windows.Media.ImageSource (для WPF).
    /// </summary>
    public static class ImageHelper
    {
        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            if (bitmap == null) return null;

            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
    }
}