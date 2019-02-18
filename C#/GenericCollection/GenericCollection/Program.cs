using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleList<int> list = new SimpleList<int>(6);
            //list.Add(5);
            //list.Add(10);
            //list.Add(20);
            //list.Add(30);
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            list.Add(numbers);
            Console.WriteLine("Length: " + list.Length);
            
            // Swap two elements
            Console.WriteLine(list.Get(5));
            Console.WriteLine(list.Get(5));
            list.Swap(5, 4);
            Console.WriteLine(list.Get(4));
            Console.WriteLine(list.Get(5));

            //foreach(var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadKey();
        }
    }
}
