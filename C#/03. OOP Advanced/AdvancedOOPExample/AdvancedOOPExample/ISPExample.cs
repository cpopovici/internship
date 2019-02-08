using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOOPExample
{
    class ISPExample
    {
        public ISPExample()
        {
            Car car = new Car() { Name = "Toyota Altezza" };
            Airplane airplane = new Airplane() { Name = "Boeing 777" };
            car.Move();
            airplane.Move();
            airplane.Fly();
        }
    }

    interface ITransport
    {
        string Name { get; set; }
    }

    interface IMove
    {
        void Move();
    }

    interface IFly
    {
        void Fly();
    }

    public class Car : ITransport, IMove
    {
        public string Name { get; set; }
        public void Move()
        {
            Console.WriteLine("Car is Moving!");
        }
    }

    public class Airplane : ITransport, IMove, IFly
    {
        public string Name { get; set; }
        public void Move()
        {
            Console.WriteLine("Airplane is moving!");
        }
        public void Fly()
        {
            Console.WriteLine("Airplane is Flying");
        }
    }
}
