using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overloading_Angle;

namespace GenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleList<int> list = new SimpleList<int>(10);

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            int[] numbers = { 50, 60, 70, 80, 90, 100 };
            list.Add(numbers);
            Console.WriteLine("My list Count: " + list.Length);
            Console.WriteLine("Print all elements from list:");
            foreach (var item in list)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            // Swap two elements
            Console.WriteLine("Before Swap:");
            Console.WriteLine(list.Get(4));
            Console.WriteLine(list.Get(5));
            list.Swap(5, 4);
            Console.WriteLine("After Swap:");
            Console.WriteLine(list.Get(4));
            Console.WriteLine(list.Get(5));
            Console.WriteLine();

            Console.WriteLine("Get element 5 from list: {0}", list.Get(9));
            Console.WriteLine("Element 2 from list by index: {0}", list[2]);
            Console.WriteLine();

            SimpleList<Angle> angles = new SimpleList<Angle>(2);
            angles.Add(new Angle(210, 23, 51));
            angles.Add(new Angle(140, 10, 43));
            foreach(var angle in angles)
            {
                Console.WriteLine("Angle: {0}", angle);
            }
            Console.WriteLine("Clear list:");

            list.Clear();
            foreach (var item in list)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
