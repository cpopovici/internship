using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Observer
{
    class Product
    {
        string Name { get; }
        int Price { get; }

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format($"Name: {Name}\n  Price: {Price}");
        }
    }
}
