using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.MergeSort
{
    class Mergesort<T>  where T : IComparable
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            
        }

        private static void Merge(T[] arr, int lo ,int mid , int hi)
        {



            for (int i = lo; i < hi + 1; i++)
            {
                aux[i] = arr[i];
            }

            int i = lo;
            int
        }
    }
}
