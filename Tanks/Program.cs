using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tanks());
        }
    }

    public static class Extention
    {
        public static Image Crop(this Image image, Rectangle selection)
        {
            Bitmap bmp = image as Bitmap;

            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            image.Dispose();

            return cropBmp;
        }
    }
}
