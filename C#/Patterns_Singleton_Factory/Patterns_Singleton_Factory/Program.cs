using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Classes;

namespace Patterns_Singleton_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singleton usage example
            GameManager.Instance.LoadLevel(1);
            GameManager.Instance.NumberOfEnemies = 5;
            while (GameManager.Instance.NumberOfEnemies > 0)
            {
                GameManager.Instance.NumberOfEnemies--;
                Console.WriteLine("Killing one enemy! Remaining {0}", GameManager.Instance.NumberOfEnemies);
                GameManager.Instance.Score += 10;
                Thread.Sleep(200);
                if (GameManager.Instance.NumberOfEnemies == 0)
                    GameManager.Instance.GameWin();
            }

            Console.WriteLine("\nFactory Example:\n");
            // Factory example
            SamsungMobile samsung = MobileFactory.CreateSamsungMobile(model: "S10+", processor: "845", ram: 8192);
            XiaomiMobile xiaomi = MobileFactory.CreateXioamiMobile(model: "Mi Mix 3", processor: "855", ram: 6144);
            Console.ReadKey();
        }
    }
}
