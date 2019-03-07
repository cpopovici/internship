using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Strategy
{
    class UpsShippingStrategy : IShippingStrategy
    {
        public double CalculateShippingCost(Order order)
        {
            return Math.Round(order.Price * 0.13f, 2);
        }
    }
}
