using System;
using System.Drawing;
using System.IO;

namespace ProSE
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // taking all the pictures
            // add them all to a list
            List<ImageContainer> imageContainers = new List<ImageContainer>()
            {
                new ImageContainer(("image1.jpg")),
                new ImageContainer(("image2.jpg")),
                new ImageContainer(("image3.jpg")),
                new ImageContainer(("image4.jpg")),
                new ImageContainer(("image5.jpg"))
            };

            // starting threads and initializing the method

            foreach (var i in imageContainers)
            {
                new Thread(i.ProcessImage).Start();

            }

            
            // corrected images will be exported in to the bin/Debug/net6.0 folder
            // with corrected_ prefix
    
        }

    }
}