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
            var angle3 = new Angle(320, 12, 36);
            
            
            Console.WriteLine(angle.ToDecimal());
            Angle[] angles = new Angle[3] { angle, angle2, angle3};

            Array.Sort(angles);
            Console.WriteLine();
            foreach (var item in angles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Array.Sort(angles, new AngleMinutesComparer());
            Console.WriteLine();
            foreach (var item in angles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(angle + angle2);
            Console.WriteLine(angle == angle2);
            Console.WriteLine(angle != angle3);
            angle["degrees"] = 360;
            Console.WriteLine(angle["degrees"]);

            Console.WriteLine("CompareTo: " + angle.CompareTo(angle2));
            Console.WriteLine("FOREACH");
            foreach(int i in angle)
            {
                Console.WriteLine("First foreach: {0}", i);
                foreach (int x in angle)
                {
                    Console.WriteLine("Second foreach: {0}", x);
                }
            }

            Console.ReadKey();
        }
    }
}
