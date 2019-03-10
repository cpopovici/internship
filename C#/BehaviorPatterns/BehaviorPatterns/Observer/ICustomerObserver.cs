using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Observer
{
    interface ICustomerObserver
    {
        void Update(string message);
    }
}
