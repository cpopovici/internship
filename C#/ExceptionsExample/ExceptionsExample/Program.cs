using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Overloading_Angle;

namespace ExceptionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input arguments exception and multiple catch
            double x = 40, y = 0;
            try
            {
                Console.WriteLine("{0} / {1} = {2}",x, y, DivideNumbers(x, y));
                
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Debug.WriteLine("Divide by zero Exception: first argument: {0}, second argument: {1}", x, y);
            }

            var angle = new Angle(240, 10, 50);
            Console.WriteLine("Initial Angle: {0}", angle);
            try
            {
                angle["seconds"] = 25;
                angle["minutes"] = 10;
                angle[3] = 10;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            // Custom Exceptions
            var student = new Student("Ivan", "Ivanovici", 17);
            try
            {
                Student.ValidateStudent(student);
                Console.WriteLine(student);
            }
            catch (InvalidStudentAgeException e)
            {
                Console.WriteLine("Exception: " + e.Message);
                
            }
            catch (InvalidStudentNameException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            // Catch when filter
            x = -1;
            y = 10;
            try
            {
                if (x < 0)
                    throw new ArgumentException("invalid x argument");
                if (y > 10)
                    throw new ArgumentException("invalid y argument");
            }
            catch(ArgumentException e) when (e.Message == "invalid x argument")
            {
                Console.WriteLine("X argument exception: " + e.Message);
            }
            catch (ArgumentException e) when (e.Message == "invalid y argument")
            {
                Console.WriteLine("Y  argument exception: " + e.Message);
            }


            // try - catch - finally
            FileStream file = null;
            StreamReader reader = null;
            try
            {
                file = File.Open("settings.json", FileMode.OpenOrCreate);
                reader = new StreamReader(file);
                string text = reader.ReadToEnd();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (file != null && reader != null)
                {
                    file.Dispose();
                    reader.Dispose();
                }
            }

            Console.ReadLine();
        }

        static double DivideNumbers(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Attempted divide by zero.");
            return a / b;
        }
    }
}
