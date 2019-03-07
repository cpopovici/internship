using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Strategy
{
    class Order
    {
        public int Price { get; }

        public Order(int price)
        {
            this.Price = price;
        }
    }
}
