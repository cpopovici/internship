using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExceptionsExample
{
    class Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }

        public Student(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            PrintDebugInfo();
        }

        [Conditional("DEBUG")]
        void PrintDebugInfo()
        {
            Console.WriteLine("\n** New Student created with Name: {0}, Surname: {1} and Age: {2} **\n", Name, Surname, Age);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Surname: {1}, Age: {2}", Name, Surname, Age);
        }

        public static void ValidateStudent(Student student)
        {
            if (!Regex.IsMatch(student.Name, @"^[a-zA-Z]+$"))
                throw new InvalidStudentNameException("Invalid student name, Name can only contains letters!");
            if (student.Age < 18)
                throw new InvalidStudentAgeException("Student age is less than 18 years!");
        }
    }

    class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string message) : base(message) { }
    }

    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string message) : base(message) { }
    }
}
