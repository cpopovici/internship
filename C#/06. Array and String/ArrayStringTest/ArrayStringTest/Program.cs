﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = new string[7] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            int[,] matrix = new int[,] { {0, 0, 1 }, {1, 0, 1 }, {1, 1, 1 } };
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[] { 5, 8, 5, 9, 22 };
            jaggedArray[1] = new int[] { 0, 7, 14, 13 };
            jaggedArray[2] = new int[] { 11, 22 };

            Console.WriteLine("Initial Jagged array:");
            PrintJaggedArray(jaggedArray);
            Console.WriteLine("Sorted Jagged array:");
            int[][] sortedArray = SortJaggedArray(jaggedArray);
            PrintJaggedArray(sortedArray);
            Console.WriteLine();

            PrintArrayElements(daysOfWeek);
            Console.WriteLine();
            PrintArrayElements(matrix, 3);
            Console.WriteLine();

            string allDaysOfWeek = string.Join(" | ", daysOfWeek);
            string firstDay = allDaysOfWeek.Split('|')[0];
            Console.WriteLine("All days of week: {0}", allDaysOfWeek.ToUpper());
            Console.WriteLine("First day of week: {0}", firstDay);
            Console.WriteLine();
            StringBuilder builder = new StringBuilder("Count: ");
            for(int i = 0; i < 100; i++)
            {
                builder.Append(i.ToString());
                builder.Append(" ");
            }
            builder.Replace("99", "100");
            Console.WriteLine(builder);
            Console.ReadLine();
        }

        static int[][] SortJaggedArray(int[][] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Array.Sort(arr[i]);
            }
            return arr;
        }

        static void PrintArrayElements(string[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Element {0}, Value: {1}", i + 1, arr[i]);
            }
        }

        static void PrintJaggedArray(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Element({0}): ", i);
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
               Console.WriteLine();
            }
        }

        static void PopulateArray(int[] arr, int value)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
        }

        static void PrintArrayElements(int[,] arr, int size)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Element {0}-{1}, Value: {2}", i + 1, j + 1, arr[i, j]);
                }
        }
    }
}
