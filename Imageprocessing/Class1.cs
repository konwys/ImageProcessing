using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace Imageprocessing
{
    
    class ImageProcessing
    {
        private Bitmap obrazek;
        private Bitmap obrazekKopia;
        public Bitmap Obrazek
        {
            get
            {
                return obrazek;
            }
            set
            {
                obrazek = value;
            }
        }

        public Bitmap ObrazekKopia
        {
            get
            {
                return obrazekKopia;
            }
        }

        public void ToMainColors (Bitmap MyImage)
        {
          
            for (int i=0; i<MyImage.Width; i++ )
            {
                for (int k = 0; k < MyImage.Height; k++)
                {
                    Color pixelColor = MyImage.GetPixel(i, k);

                    if (pixelColor.R > pixelColor.G && pixelColor.R > pixelColor.B) // najwiekszy R
                    {
                        Color newColor = Color.FromArgb(pixelColor.R, 255,0,0);
                        MyImage.SetPixel(i, k, newColor);
                    } 
                    else if (pixelColor.G > pixelColor.R && pixelColor.G > pixelColor.B) // najwiekszy G
                    {
                        Color newColor = Color.FromArgb(pixelColor.R, 0, 255, 0);
                        MyImage.SetPixel(i, k, newColor);
                    }
                    else if (pixelColor.B > pixelColor.G && pixelColor.B > pixelColor.R) // najwiekszy B
                    {
                        Color newColor = Color.FromArgb(pixelColor.R, 0, 0, 255);
                        MyImage.SetPixel(i, k, newColor);
                    }   
                }            
            }
            Graphics g = Graphics.FromImage(MyImage);
            g.DrawImage(MyImage, 0, 0);

        }

    }

    
}
