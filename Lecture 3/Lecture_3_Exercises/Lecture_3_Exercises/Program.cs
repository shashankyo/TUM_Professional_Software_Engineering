using System;

namespace ProSE_Lecture3
{
    public class MyFirstClass
    {
        public static void Main(string[] args)
        {
            Vector2D firstvector = new Vector2D(3, 4);
            firstvector.PrintNorm();
            Vector3D secondvector = new Vector3D(3, 4, 5);
            secondvector.PrintNorm();
        }
    }
}