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
        public static void Main(string[] args)
        {
            //Assignment 1 Solution


            // Letter T
            Rectangle recT1 = new Rectangle(0, 50, 50, 60);
            Rectangle recT2 = new Rectangle(20, 30, 1, 50);
            Union letterT = new Union(ref recT1, ref recT2);


            // Letter U
            Rectangle recU1 = new Rectangle(50, 100, 0, 60);
            Rectangle recU2 = new Rectangle(60, 90, 10, 60);
            Difference letterU = new Difference(ref recU1, ref recU2);

            // Letter M
            Rectangle recM1 = new Rectangle(90, 100, 0, 60);
            Rectangle recM2 = new Rectangle(100, 170, 0, 60);
            Rectangle recM3 = new Rectangle(170, 180, 0, 60);
            Circle circM1 = new Circle(135, 60, 35);
            Circle circM2 = new Circle(135, 60, 25);
            Difference ringM1 = new Difference(ref circM1, ref circM2);
            Intersection interM1 = new Intersection(ref recM2, ref ringM1);
            Union letterM1 = new Union(ref recM1, ref recM3);
            Union letterM = new Union(ref letterM1, ref ringM1);

            // Combination of Letters
            Union lettersTU = new Union(ref letterT, ref letterU);
            Union logoTUM = new Union(ref lettersTU, ref letterM);
            logoTUM.Visualize(200, 60);

        }


    }
}