using System;
using System.Drawing;
using System.IO;

namespace ProSE
{
    class MainClass
    {
        public static void Main(string[] argArray)
        {
            string path = "path-to-image.jpg"; // or png
            Bitmap originalImage = new Bitmap(path); // import image from path
            Bitmap newImage = new Bitmap(originalImage); // create a new image with the same dimensions as originalImage

            // change blue and green to 0
            for (int x = 0; x < originalImage.Width; x++)
            { // x here is the horizontal index of pixel
                for (int y = 0; y < originalImage.Height; y++)
                { // y here is the vertical index of pixel
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int redValue = Convert.ToInt32(pixelColor.R); // you can do the same for blue and green since all color values range from 0 to 255

                    Color newColor = Color.FromArgb(redValue, 0, 0);
                    newImage.SetPixel(x, y, newColor);
                }
            }
            // export newImage
            newImage.Save(newPath);

        }
    }