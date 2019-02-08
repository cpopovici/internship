using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOOPExample
{
    class Program
    {
        static void Main(string[] args)
        {
            OCPExample ocp = new OCPExample();
            Console.WriteLine();
            LiskovExample liskov = new LiskovExample();
            Console.WriteLine();
            ISPExample isp = new ISPExample();
            Console.ReadKey();
        }
    }
}
