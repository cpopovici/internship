using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading_Angle
{
    class Program
    {
        static void Main(string[] args)
        {
            var angle = new Angle(20, 10, 50);
            var angle2 = new Angle(320, 40, 36);
            var angle3 = new Angle(87, 12, 40);
            Angle[] angles = new Angle[3] { angle, angle2, angle3};

            Console.WriteLine("Angle [{0}] to decimal value: {1}", angle, angle.ToDecimal());
            // standard sort
            Console.WriteLine("Standard sort:");
            Array.Sort(angles);
            foreach (var item in angles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // sort by minutes
            Console.WriteLine("Sort angles by minutes:");
            Array.Sort(angles, Angle.Comparer.CompareByMinutes());
            foreach (var item in angles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // sort by seconds
            Console.WriteLine("Sort angles by seconds:");
            Array.Sort(angles, Angle.Comparer.CompareBySeconds());
            foreach (var item in angles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // operators overloading
            Console.WriteLine("[{0}] + [{1}] = [{2}]",angle, angle2, angle + angle2);
            Console.WriteLine("[{0}] == [{1}] is {2}",angle, angle2, angle == angle2);
            Console.WriteLine("[{0}] != [{1}] is {2}",angle, angle2, angle != angle3);
            Console.WriteLine();

            // index
            Console.WriteLine("Change angle degrees to 360 by string index and minutes to 59 by int index:");
            angle["degrees"] = 360;
            angle[1] = 59;
            Console.WriteLine("Angle degress = {0}, minutes = {1}", angle["degrees"], angle[1]);
            Console.WriteLine();

            Console.WriteLine("Compare [{0}] to [{1}] is {2}",angle, angle2, angle.CompareTo(angle2));
            Console.WriteLine();
           
            Console.WriteLine("FOREACH TEST:");
            foreach(var i in angle)
            {
                Console.WriteLine("[1] First foreach: {0}", i);
                Console.WriteLine();
                foreach (var x in angle)
                {
                    Console.WriteLine("[2] Second foreach: {0}", x);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
