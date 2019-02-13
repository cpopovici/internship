using System;
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

        static void PrintArrayElements(string[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Element {0}, Value: {1}", i + 1, arr[i]);
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
