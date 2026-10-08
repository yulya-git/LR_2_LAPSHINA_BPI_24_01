using System.Drawing;
using System.Windows.Media;

namespace LR_2_LAPSHINA_BPI_24_01
{
    public class Formula
    {
        public Bitmap Source { get; set; }
        public Formula(Bitmap source)
        {
            Source = source;
        }

        public virtual double Calculate()
        {
            return 0.0;
        }

        public ImageSource WpfSource => ImageHelper.ToBitmapImage(Source);
    }
}
