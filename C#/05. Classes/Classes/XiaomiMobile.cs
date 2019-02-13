using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class XiaomiMobile : Mobile
    {
        public XiaomiMobile(string name, string model, string processor, int ram)
            : base(name, model, processor, ram)
        {
            Console.WriteLine("Mobile " + Name + " " + Model + " Created!");
        }
        public override void UseCamera()
        {
            base.UseCamera();
            Console.WriteLine("Using " + Name + " " + Model + " Camera!");
            Console.WriteLine("Take Photo!");
        }
        //public void Dial()
        //{
        //    Console.WriteLine(GetNameAndModel() + " Dial a number");
        //}

        //public void ReceiveMessage()
        //{
        //    Console.WriteLine(GetNameAndModel() + " Receive message");
        //}

        //public void SendMessage()
        //{
        //    Console.WriteLine(GetNameAndModel() + " Send message");
        //}
    }
}
