using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Observer
{
    class OnlineShop
    {
        private List<ICustomerObserver> _observers;
        private List<Product> products;
       
        public OnlineShop()
        {
            _observers = new List<ICustomerObserver>();
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Notify();
        }

        public void Subscribe(ICustomerObserver customer)
        {
            _observers.Add(customer);
        }

        public void Unsubscripe(ICustomerObserver customer)
        {
            _observers.Remove(customer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update($"To Online Shop added new item:\n  {products.Last()}");
            }
        }

  
    }
}
