using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEvolution
{
    // AutoProperty Initializer new way, EXPRESSION-BODIED MEMBERS
    class Order
    {
        public int OrderId { get; }
        public DateTime OrderDate { get; } = DateTime.Now;
        public string OrderInfo => OrderId.ToString() + " " + OrderDate;

        public Order(int orderId)
        {
            this.OrderId = orderId;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Optional parameters, named arguments
            Console.WriteLine("Optional and named arguments example:");
            DisplayUserInfo(name: "Ivan", lastname: "Olegovici");
            DisplayUserInfo("Andrei", "Kekovici", phoneNumber: "37367281915");
            Console.WriteLine();

            //Dynamic and nameof, string interpolation
            dynamic number = 5;
            Console.WriteLine($"{nameof(number)} type is: {number.GetType()}");
            number = "5";
            Console.WriteLine($"{nameof(number)} type is: {number.GetType()}");
            number = DateTime.Now;
            Console.WriteLine($"{nameof(number)} type is: {number.GetType()}");
            Console.WriteLine();


            //AutoProperty, EXPRESSION-BODIED
            var order = new Order(12);
            Console.WriteLine($"Order Info:\n  {order.OrderInfo}");
            Console.WriteLine();


            // Tuples
            (string name, string lastname, int age) person = ("Stefan", "Popescu", 27);
            (string, string, int) person2 = ("Valera", "Plamadeala", 16);
            (string personName, int personAge) = GetPErson();

            Console.WriteLine($"Tuple with named values:\n  {person.name} {person.lastname}, Age: {person.age}");
            Console.WriteLine($"Tuple without named values:\n  {person2.Item1} {person2.Item2}, Age: {person2.Item3}");
            Console.WriteLine($"Tuple decomposing:\n  {personName}, Age: {personAge}");
            Console.WriteLine();

            //Ref return
            string[] cars = { "Toyota Altezza", "Nissan GTR R32" };
            ref string firstCar = ref FindCar(0, cars);

            Console.WriteLine($"First Car:\n  {firstCar}");
            firstCar = "Toyota Altezza RS200";
            Console.WriteLine($"First Car replaced with:\n  {cars[0]}");
            Console.WriteLine();

            Console.ReadLine();
        }

        static void DisplayUserInfo(string name, string lastname, string phoneNumber = "")
        {
            Console.WriteLine($"  Name {name}, Last Name: {lastname}, Phone Number: {phoneNumber}");
        }

        static (string name, int age) GetPErson()
        {
            return ("Laurentiu", 20);
        }

        static ref string FindCar(int index, string[] cars)
        {
            if (cars.Length > 0)
                return ref cars[index];
            throw new ArgumentOutOfRangeException();
        }

       
    }
}
