using System;

namespace Assignment6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test Assignment 6");

            List<int> intList = new List<int>() { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 }; ;

            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            Console.WriteLine("Original List<int> : ");
            ExtensionLibrary.PrintList(intList);
            Console.WriteLine();

            ExtensionLibrary.QuickSort(intList,2,5);

            //Console.WriteLine();
            //Console.WriteLine("Sorted List<int> : ");

            ExtensionLibrary.PrintList(intList);

            //foreach (var i in arr)
            //{
            //    Console.Write(" " + i);
            //}
            //Console.WriteLine();
        }
    }
}