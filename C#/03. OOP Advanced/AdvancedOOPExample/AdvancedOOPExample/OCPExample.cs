using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOOPExample
{
    class OCPExample
    {
        public OCPExample()
        {
            ShapesAreaCalculator calculator = new ShapesAreaCalculator();
            Rectangle rectangle = new Rectangle()
            {
                Width = 10,
                Height = 8
            };
            Circle circle = new Circle()
            {
                Radius = 10.00
            };
            Shape[] shapes = { rectangle, circle };
        
            Console.WriteLine("Rectangle area: " + rectangle.Area());
            Console.WriteLine("Circle area: " + circle.Area());
            Console.WriteLine("Shapes total area: " + calculator.Area(shapes));
        }  
    }

    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
    }

    public class ShapesAreaCalculator
    {
        public double Area(Shape[] shapes)
        {
            double shapesArea = 0;
            foreach (var shape in shapes)
            {
                shapesArea += shape.Area();
            }
            return shapesArea;
        }
    }
}
