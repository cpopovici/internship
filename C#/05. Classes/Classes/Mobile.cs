using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Mobile : IMobile
    {
        private int _batteryLevel;


        public string Name { get; private set; }
        public string Model { get; private set; }
        public int IMEICode { get; private set; }
        public string Processor { get; private set; }
        public int RAM { get; private set; }
        
        public int BatteryLevel
        {
            get { return _batteryLevel; }
            set
            {
                _batteryLevel = value;
                if (value > 100)
                    _batteryLevel = 100;
                if (value < 0)
                    _batteryLevel = 0;
            }
        }
        
        public Mobile(string name, string model, string processor, int ram)
        {
            Random random = new Random();
            this.Name = name;
            this.Model = model;
            this.Processor = processor;
            this.RAM = ram;
            this.IMEICode = random.Next(1000000, 9999999);
        }

        public string GetNameAndModel()
        {
            return Name + " " + Model;
        }

        public void DisplayMobileInfo()
        {
            Console.WriteLine(GetNameAndModel());
            Console.WriteLine("Processor: " + Processor);
            Console.WriteLine("RAM: " + RAM + "MB");
            Console.WriteLine("Battery level: " + BatteryLevel + "%");
            Console.WriteLine("IMEI Code: " + IMEICode);
        }

        public virtual void UseCamera()
        {
            Console.WriteLine("Starting Camera App!");
        }

        public void Dial()
        {
            Console.WriteLine(GetNameAndModel() + " Dial a number");
        }

        public void ReceiveMessage()
        {
            Console.WriteLine(GetNameAndModel() + " Receive message");
        }

        public void SendMessage()
        {
            Console.WriteLine(GetNameAndModel() + " Send message");
        }
    }
}
