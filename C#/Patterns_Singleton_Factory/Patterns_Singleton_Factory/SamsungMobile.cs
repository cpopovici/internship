using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class SamsungMobile : Mobile
    {
        public SamsungMobile(string name, string model, string processor, int ram)
            : base(name, model, processor, ram)
        {
            //Console.WriteLine("Mobile " + Name + " " + Model + " Created!");
        }

        public override void UseCamera()
        {
            base.UseCamera();
            Console.WriteLine("\tUsing " + Name + " " + Model + " Camera!");
            Console.WriteLine("\tTake Photo!");
        }
    }
}
