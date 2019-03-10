using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Observer
{
    class Customer : ICustomerObserver
    {
        public string Name { get; }

        public Customer(string name)
        {
            this.Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{Name}, {message}\n");
        }
    }
}
