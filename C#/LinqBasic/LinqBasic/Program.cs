using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overloading_Angle;

namespace LinqBasic
{
    public static class AngleExtensions
    {
        public static int DegreesToMinutes(this Angle angle)
        {
            return angle.Degrees * 60;
        }
    }

    class Program
    {
        public delegate bool CompareAngle(Angle a1, Angle a2);

        static void Main(string[] args)
        {
           
            List<Angle> angles = GenerateCollectionOfAngles(6);
            Console.WriteLine("Generated {0} random angles:", angles.Count);
            foreach(var angle in angles)
            {
                Console.WriteLine("\t{0}", angle);
            }
            Console.WriteLine();
            Console.WriteLine();
            // delegate
            Console.WriteLine("Using delegates:");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Compare angles by Minutes:");
            ProcessAngles(angles, MinutesIsGreater);
            Console.WriteLine("Compare angles by seconds:");
            ProcessAngles(angles, SecondsIsGreater);
            Console.WriteLine(angles[0].DegreesToMinutes());

            // Anonymous functions
            Console.WriteLine("Using delegates:");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Compare angles by Minutes:");
            ProcessAngles(angles, delegate (Angle a1, Angle a2)
            {
                return a1.Minutes > a2.Minutes;
            });
            Console.WriteLine("Compare angles by seconds:");
            ProcessAngles(angles, delegate (Angle a1, Angle a2)
            {
                return a1.Seconds > a2.Seconds;
            });
            Console.WriteLine();

            // using lambda
            Console.WriteLine("Using Lambda:");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Compare angles by Minutes:");
            ProcessAngles(angles, (a, b) => ((Angle)a).Minutes > ((Angle)b).Minutes);
            Console.WriteLine("Compare angles by seconds:");
            ProcessAngles(angles, (a, b) => ((Angle)a).Seconds > ((Angle)b).Seconds);
            Console.WriteLine();


            var bigAngles = angles.Where(x => x.Degrees > 180);
            var anglesDegrees = angles.Select(x => x.Degrees);
            Console.WriteLine("Angles with degrees greater than 180:");
            foreach(var angle in bigAngles)
            {
                Console.WriteLine("\t{0}", angle);
            }
            Console.WriteLine();
            Console.WriteLine("Degrees from all angles:");
            foreach (var degree in anglesDegrees)
            {
                Console.WriteLine("\t{0}", degree);
            }

            Console.ReadKey();
        }

        static List<Angle> GenerateCollectionOfAngles(int count)
        {
            Random random = new Random();
            List<Angle> angles = new List<Angle>();
            for (int i = 0; i < count; i++)
            {
                angles.Add(new Angle(random.Next(360), random.Next(59), random.Next(59)));
            }
            return angles;
        }

        static void ProcessAngles(List<Angle> angles, CompareAngle comparer)
        {
            for (int i = 0; i < angles.Count / 2; i++)
            {
                bool compareResult = comparer(angles[i], angles[i + 1]);
                if (compareResult)
                    Console.WriteLine("\t{0} > {1}", angles[i], angles[i + 1]);
                else
                    Console.WriteLine("\t{0} < {1}", angles[i], angles[i + 1]);
            }
        }

        static bool MinutesIsGreater(Angle a1, Angle a2)
        {
            if (a1.Minutes > a2.Minutes)
                return true;
            return false;
        }

        static bool SecondsIsGreater(Angle a1, Angle a2)
        {
            if (a1.Seconds > a2.Seconds)
                return true;
            return false;
        }
    }
}
