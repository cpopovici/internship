using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            SamsungMobile samsung = new SamsungMobile("Samsung", "S10", "Snapdragon 845", 8192);
            XiaomiMobile xiaomi = new XiaomiMobile("Xiaomi", "Mi Mix 3", "Snapdragon 855", 6144);
            samsung.BatteryLevel = 56;
            xiaomi.BatteryLevel = 130;
            Console.WriteLine();
            List<Mobile> phones = new List<Mobile>();
            phones.Add(samsung);
            phones.Add(xiaomi);

            foreach(Mobile mobile in phones)
            {
                mobile.DisplayMobileInfo();
                mobile.UseCamera();
                mobile.Dial();
                mobile.SendMessage();
                mobile.ReceiveMessage();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
