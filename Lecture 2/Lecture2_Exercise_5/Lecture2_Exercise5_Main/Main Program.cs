using System;
namespace ProSE
{
    class MainProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hi!");
            Vector3d vector1 = new Vector3d("vector1", 2,44,5.11);
            //vector1.x = 3;<
            //vector1.y = 4.4;
            //vector1.z = 5.33;
            //Console.WriteLine(vector1.x);
            //Console.WriteLine(vector1.y);
            //Console.WriteLine(vector1.z);
            //Vector3d.GetNorm(vector1);
            vector1.GetNorm();
            vector1.PrintVector();
        }
    }
}