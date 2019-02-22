using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface I1
    {
        int Age { get; set; }

        string Name { get; set; }
    }

    public class Class1 : I1
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
