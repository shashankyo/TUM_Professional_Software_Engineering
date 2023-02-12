using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment6
{
    class ExtensionLibrary
    {
        //public static void QuickSort<T>(T[] list) where T : IComparable
        //{
        //    QuickSortInternal(list, 0, list.Length - 1);
        //}

        //public static void QuickSortInternal<T>(T[] list, int left, int right) where T : IComparable
        //{
        //    if (left >= right)
        //    {
        //        return;
        //    }

        //    int partition = PartitionInternal(list, left, right);

        //    QuickSortInternal(list, left, partition - 1);
        //    QuickSortInternal(list, partition + 1, right);
        //}

        //public static int PartitionInternal<T>(T[] list, int left, int right) where T : IComparable
        //{
        //    T partition = list[right];

        //    // stack items smaller than partition from left to right
        //    int swapIndex = left;
        //    for (int i = left; i < right; i++)
        //    {
        //        T item = list[i];
        //        if (item.CompareTo(partition) <= 0)
        //        {
        //            list[i] = list[swapIndex];
        //            list[swapIndex] = item;

        //            swapIndex++;
        //        }
        //    }

        //    // put the partition after all the smaller items
        //    list[right] = list[swapIndex];
        //    list[swapIndex] = partition;

        //    return right;
        //}

        public static void QuickSort(List<int> intList, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(intList, left, right);

                if (pivot > 1)
                {
                    QuickSort(intList, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(intList, pivot + 1, right);
                }
            }

        }

        public static int Partition(List<int> intList, int left, int right)
        {
            int pivot = intList[left];
            while (true)
            {

                while (intList[left] < pivot)
                {
                    left++;
                }

                while (intList[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (intList[left] == intList[right]) return right;

                    int temp = intList[left];
                    intList[left] = intList[right];
                    intList[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }

        public static void PrintList(List<int> intList)
        {
            foreach (var item in intList)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();

        }
    }
}