using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOOPExample
{
    class LiskovExample
    {
        public LiskovExample()
        {
            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(new RedApple() { Name = "Red Apple" });
            fruits.Add(new Banana() { Name = "Banana" });
            foreach(Fruit fruit in fruits)
            {
                Console.WriteLine(fruit.Name + " is " + fruit.GetColor());
            }
        }
    }

    public abstract class Fruit
    {
        public string Name { get; set;}
        public abstract string GetColor();
    }

    public class RedApple : Fruit
    {
        public override string GetColor()
        {
            return "Red";
        }
    }

    public class Banana : Fruit
    {
        public override string GetColor()
        {
            return "Yellow";
        }
    }
}
