using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOOPExample
{
    class ISPExample_ver2
    {

    }

    public interface IProduct
    {
        int ID { get; set; }
        double Weight { get; set; }
        int Stock { get; set; }
    }

    public interface IPants
    {
        int InseamSize { get; set; }
        int WaistSize { get; set; }
    }

    public interface IHat
    {
        int HatSize { get; set; }
    }

    public class Jeans : IProduct, IPants
    {
        public int ID { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public int InseamSize { get; set; }
        public int WaistSize { get; set; }
    }

    public class BaseballCap : IProduct, IHat
    {
        public int ID { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public int HatSize { get; set; }
    }
}
