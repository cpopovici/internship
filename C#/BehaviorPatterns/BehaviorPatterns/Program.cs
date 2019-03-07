using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviorPatterns.Observer;
using BehaviorPatterns.Template;
using BehaviorPatterns.Strategy;

namespace BehaviorPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Observer Example
            var customer = new Customer("Eliot Anderson");
            var customer2 = new Customer("Andrei Keks");
            var shop = new OnlineShop();
            var mobile = new Product("Xiaomi MI 9", 600);

            shop.Subscribe(customer);
            shop.Subscribe(customer2);
            shop.AddProduct(mobile);

            // Template pattern example
            var mkvVideo = new MkvVideoPlayer();
            var mp4Video = new MP4VideoPlayer();

            mkvVideo.PlayVideo("funny-cats.mkv");
            mp4Video.PlayVideo("funny-dogs.mp4");


            // Strategy pattern
            var order = new Order(126);
            var calculator = new ShippingCalculator();
            var shippingCostDHL = calculator.CalculateShipping(new DHLShippingStrategy(), order);
            var shippingCostUPS = calculator.CalculateShipping(new UpsShippingStrategy(), order);
            Console.WriteLine($"Shipping prices:\n  DHL price: {shippingCostDHL}$\n  UPS Price: {shippingCostUPS}$");
            Console.ReadLine();

        }
    }
}
