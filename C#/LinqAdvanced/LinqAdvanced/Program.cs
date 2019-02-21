using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<User> users = new List<User>();
            List<int> numbers = GenerateNumbers(20);
            users.Add(new User("Ivan", "Ivanovici", UserRole.Admin));
            users.Add(new User("Stefan", "Popescu", UserRole.User));
            users.Add(new User("Laurentiu", "Juratu", UserRole.Manager));
            users.Add(new User("Dan", "Matt", UserRole.Editor));
            Console.ReadLine();
        }

        static List<int> GenerateNumbers(int size)
        {
            Random random = new Random();
            List<int> numbers = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                numbers.Add(random.Next(100));
            }
            return numbers;
        }
    }
}
