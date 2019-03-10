using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Patterns_Singleton_Factory
{
    class MobileFactory
    {
        public static SamsungMobile CreateSamsungMobile(string model, string processor, int ram)
        {
            string name = "Samsung";
            var mobile = new SamsungMobile(name, model, processor, ram);
            OnMobileCreated(mobile);
            return mobile;
        }

        public static XiaomiMobile CreateXioamiMobile(string model, string processor, int ram)
        {
            string name = "Xioami";
            var mobile = new XiaomiMobile(name, model, processor, ram);
            OnMobileCreated(mobile);
            return mobile;
        }

        private static void OnMobileCreated(Mobile mobile)
        {
            Console.WriteLine("Mobile Factory Created:");
            mobile.DisplayMobileInfo();
            mobile.UseCamera();
            mobile.Dial();
            mobile.SendMessage();
            mobile.ReceiveMessage();
            Console.WriteLine();
        }
    }
}
