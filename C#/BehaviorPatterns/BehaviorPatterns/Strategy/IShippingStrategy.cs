using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Strategy
{
    interface IShippingStrategy
    {
        double CalculateShippingCost(Order order);
    }
}
