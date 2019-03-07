using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Strategy
{
    class ShippingCalculator
    {
        public double CalculateShipping(IShippingStrategy shippingStrategy, Order order)
        {
            return shippingStrategy.CalculateShippingCost(order);
        }
    }
}
