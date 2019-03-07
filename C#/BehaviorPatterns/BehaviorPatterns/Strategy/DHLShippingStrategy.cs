using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Strategy
{
    class DHLShippingStrategy : IShippingStrategy
    {
        public double CalculateShippingCost(Order order)
        {
            return Math.Round(order.Price * 0.185f, 2);
        }
    }
}
