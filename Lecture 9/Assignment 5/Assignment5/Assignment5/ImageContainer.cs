using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class ImageContainer
    {
        public Bitmap originalImage;
        public Bitmap correctedImage;
        public string originalFilePath;
        private static object _locker = new object();
        public ImageContainer(string path)
        {
            originalImage = new Bitmap(path);
            correctedImage = new Bitmap(originalImage); 
            this.originalFilePath = path;
        }

        public void ProcessImage()
        {
            Monitor.Enter(_locker);

                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting ...");
                Bitmap newImage = new Bitmap(originalImage);

                //change blue and greem to 0
                for (int x = 1; x < originalImage.Width - 1; x++)
                { // x here is the horizontal index of the pixel
                    for (int y = 1; y < originalImage.Height - 1; y++)
                    {// y here is the vertical index of the pixel

                        //--------------RED---------------------------

                        Color pixelColorR = originalImage.GetPixel(x, y);
                        int redValue = Convert.ToInt32(pixelColorR.R);

                        ////Y-AXIS colorifaction(top-bottom)
                        Color pixelColortop = originalImage.GetPixel(x, y + 1);
                        int redValuetop = Convert.ToInt32(pixelColortop.R);

                        Color pixelColorbottom = originalImage.GetPixel(x, y - 1);
                        int redValuebottom = Convert.ToInt32(pixelColorbottom.R);

                        ////X-AXIS colorification(left-right)
                        Color pixelColorRight = originalImage.GetPixel(x + 1, y);
                        int redValueRight = Convert.ToInt32(pixelColorRight.R);

                        Color pixelColorLeft = originalImage.GetPixel(x - 1, y);
                        int redValueLeft = Convert.ToInt32(pixelColorLeft.R);

                        ////Y-AXIS grad calculation(top-bottom)
                        int grad = (redValuetop - redValuebottom) / 2;
                        int gradTopAndBottom = (int)Math.Pow((grad), 2);

                        ////X-AXIS grad calculation(left-right)
                        int gradx = (redValueRight - redValueLeft) / 2;
                        int gradLeftAndRight = (int)Math.Pow((gradx), 2);   //(int), turning double into integer


                        int magnitude = (int)Math.Sqrt(gradTopAndBottom + gradLeftAndRight);
                        int gradResult = magnitude;

                        //-----------------GREEN-----------------

                        Color pixelColorG = originalImage.GetPixel(x, y);
                        int greenValue = Convert.ToInt32(pixelColorG.G);

                        //////Y-AXIS colorifaction(top-bottom)
                        Color pixelColorGtop = originalImage.GetPixel(x, y + 1);
                        int greenValuetop = Convert.ToInt32(pixelColorGtop.G);

                        Color pixelColorGbottom = originalImage.GetPixel(x, y - 1);
                        int greenValuebottom = Convert.ToInt32(pixelColorGbottom.G);

                        //////X-AXIS colorification(left-right)
                        Color pixelColorGRight = originalImage.GetPixel(x + 1, y);
                        int greenValueRight = Convert.ToInt32(pixelColorGRight.G);

                        Color pixelColorGLeft = originalImage.GetPixel(x - 1, y);
                        int greenValueLeft = Convert.ToInt32(pixelColorGLeft.G);

                        //////Y-AXIS grad calculation(top-bottom)
                        int gradGreen = (greenValuetop - greenValuebottom) / 2;
                        int gradGreenTopAndBottom = (int)Math.Pow((gradGreen), 2);

                        //////X-AXIS grad calculation(left-right)
                        int gradGreenx = (greenValueRight - greenValueLeft) / 2;
                        int gradGreenLeftAndRight = (int)Math.Pow((gradGreenx), 2);   //(int), turning double into integer

                        int magnitudeGreen = (int)Math.Sqrt(gradGreenTopAndBottom + gradGreenLeftAndRight);
                        int gradGreenResult = magnitudeGreen;

                        ////-------------BLUE-------------

                        Color pixelColorB = originalImage.GetPixel(x, y);
                        int blueValue = Convert.ToInt32(pixelColorB.B);

                        ////Y-AXIS colorifaction(top-bottom)
                        Color pixelColorBtop = originalImage.GetPixel(x, y + 1);
                        int blueValuetop = Convert.ToInt32(pixelColorBtop.B);

                        Color pixelColorBbottom = originalImage.GetPixel(x, y - 1);
                        int blueValuebottom = Convert.ToInt32(pixelColorBbottom.B);

                        ////X-AXIS colorification(left-right)
                        Color pixelColorBRight = originalImage.GetPixel(x + 1, y);
                        int blueValueRight = Convert.ToInt32(pixelColorBRight.B);

                        Color pixelColorBLeft = originalImage.GetPixel(x - 1, y);
                        int blueValueLeft = Convert.ToInt32(pixelColorBLeft.B);

                        ////Y-AXIS grad calculation(top-bottom)
                        int gradBlue = (blueValuetop - blueValuebottom) / 2;
                        int gradBlueTopAndBottom = (int)Math.Pow((gradBlue), 2);

                        ////X-AXIS grad calculation(left-right)
                        int gradBluex = (blueValueRight - blueValueLeft) / 2;
                        int gradBlueLeftAndRight = (int)Math.Pow((gradBluex), 2);   //(int), turning double into integer

                        int magnitudeBlue = (int)Math.Sqrt(gradBlueTopAndBottom + gradBlueLeftAndRight);
                        int gradBlueResult = magnitudeBlue;


                        //ASSIGNING ALL COLORS, R-G-B

                        Color newColor = Color.FromArgb(gradResult, gradGreenResult, gradBlueResult);
                        //Color newColorRed = Color.FromArgb(gradResult, 0, 0);
                        //Color newColorGreen = Color.FromArgb(0, gradGreenResult, 0);
                        //Color newColorBlue = Color.FromArgb(0, 0, gradBlueResult);
                        newImage.SetPixel(x, y, newColor);



                    }
                }
                string newPath = $"corrected_{this.originalFilePath}";

                newImage.Save(newPath); // export newImage
                this.correctedImage = newImage;
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed ...");

            Monitor.Exit(_locker);
        }

    }
}
