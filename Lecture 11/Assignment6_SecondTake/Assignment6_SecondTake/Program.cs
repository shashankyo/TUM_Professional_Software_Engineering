using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSortProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test the integer List QuickSort extension method
            List<int> integerList = new List<int> { 3, 5, 2, 1, 4 };
            List<int> sortedIntegerList = integerList.QuickSort();
            Console.WriteLine("Sorted Integer List: ");
            sortedIntegerList.PrintList();

            //Test the generic List QuickSort extension method
            List<double> doubleList = new List<double> { 3.5, 2.1, 4.9, 1.2, 5.6 };
            List<double> sortedDoubleList = doubleList.QuickSort((a, b) => a.CompareTo(b));
            Console.WriteLine("\nSorted Double List: ");
            sortedDoubleList.PrintList();

            Console.ReadLine();
        }
    }

    //Extension method for QuickSort on integer List
    public static class QuickSortExtensions
    {
        public static List<int> QuickSort(this List<int> list)
        {
            if (list.Count <= 1)
                return list;

            int pivot = list[0];
            List<int> lower = list.Where(x => x < pivot).ToList();
            List<int> higher = list.Where(x => x > pivot).ToList();

            return QuickSort(lower).Concat(new List<int> { pivot }).Concat(QuickSort(higher)).ToList();
        }

        //Generalized implementation of QuickSort that takes a generic List<T> and a Comparison<T> delegate
        public static List<T> QuickSort<T>(this List<T> list, Comparison<T> comparison)
        {
            if (list.Count <= 1)
                return list;

            T pivot = list[0];
            List<T> lower = list.Where(x => comparison(x, pivot) < 0).ToList();
            List<T> higher = list.Where(x => comparison(x, pivot) > 0).ToList();

            return QuickSort(lower, comparison).Concat(new List<T> { pivot }).Concat(QuickSort(higher, comparison)).ToList();
        }

        //Extension method for printing elements of a generic list to the console
        public static void PrintList<T>(this List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}