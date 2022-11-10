using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProSE_Assignment1
{
    class Program
    {
        // public const int sizeGridX = 5;
        // public const int sizeGridY = 5;
        // public const char gridChar= '.';
        public static void Main(string[] args)
        {
            //Assignment 1 Solution
            /*Rectangle rec1 = new Rectangle(0, 50, 50, 60);
            Rectangle rec2 = new Rectangle(20, 30, 1, 50);

            Rectangle rec3 = new Rectangle(50, 60, 0, 60);
            Rectangle rec4 = new Rectangle(60, 100, 0, 5);

            Rectangle rec5 = new Rectangle(90, 100, 0, 60);
            Rectangle rec6 = new Rectangle(90, 180, 50, 60);

            Rectangle rec7 = new Rectangle(128, 138, 0, 60);
            Rectangle rec8 = new Rectangle(170, 180, 0, 60);

            Union newunion = new Union(ref rec1, ref rec2);
            Union newunion2 = new Union(ref rec3, ref rec4);
            Union newunion3 = new Union(ref rec5, ref rec6);
            Union newunion4 = new Union(ref rec7, ref rec8);
            Union hepsi = new Union(ref newunion, ref newunion2);
            Union hepsi2 = new Union(ref hepsi, ref newunion3);
            Union hepsi3 = new Union(ref hepsi2, ref newunion4);

            hepsi3.Visualize(200, 60);*/
            //Rectangle rec1 = new Rectangle(0,50,0,60);
            //Rectangle rec2 = new Rectangle(20, 30, 1, 50);
            //Difference newdifference = new Difference(ref rec1, ref rec2);
            //newdifference.Visualize(100, 100);


            Circle cir1 = new Circle(20, 20, 5);
            cir1.Visualize(50, 50);
            //rec1.Visualize(50, 30);


            //rec2.Visualize(50,40);







        }


    }
}