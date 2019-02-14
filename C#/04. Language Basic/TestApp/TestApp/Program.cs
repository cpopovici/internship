using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestApp
{
    class Vector3D
    {
        public float x;
        public float y;
        public float z;

        public static Vector3D Lerp(Vector3D v1, Vector3D v2)
        {
            Vector3D result = new Vector3D();
            // some funny math
            return result;
        }
    }

    struct Vector2D
    {
        public float x;
        public float y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Vector3D position3D = new Vector3D();
            Vector2D position2D = new Vector2D();

            position3D.x = 10;
            position3D.y = 40;
            position3D.z = 90;

            position2D.x = 50;
            position2D.y = 85;

            Vector3D vector2 = new Vector3D();
            Vector3D.Lerp(position3D, vector2);

            Console.WriteLine();
            Console.WriteLine(position2D.x + ":" + position2D.y);
            TestValueType(position2D);
            Console.WriteLine(position2D.x + ":" + position2D.y);
            Console.WriteLine();
            Console.WriteLine(position3D.x + ":" + position3D.y + ":" + position3D.z);
            TestReferenceType(position3D);
            Console.WriteLine(position3D.x + ":" + position3D.y + ":" + position3D.z);


            int min, max;
            int[] arr = new int[5]{ 6, 12, 65, 12, 9};
            CalculateMinMax(arr ,out min, out max);
            Console.WriteLine("Max: " + max + " Min: " + min);

            int num = 1337;
            object obj = num;
            num = 100;
            Console.WriteLine("Value - type value of num is : {0}", num);
            Console.WriteLine("Object - type value of obj is : {0}", obj);


            Thread testThread = new Thread(new ThreadStart(SecondThread));
            testThread.Start();
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Main Thread: " + i);
                Thread.Sleep(200);
            }

            Console.ReadLine();
        }

        static void TestValueType(Vector2D position)
        {
            position.x = 0;
            position.y = 240;
            Console.WriteLine(position.x + ":" + position.y);
        }

        static void TestReferenceType(Vector3D position)
        {
            position.x = 360;
            position.y = 210;
            position.z = 22;
            Console.WriteLine(position.x + ":" + position.y + ":" + position.z);
        }

        static void CalculateMinMax(int[] arr, out int min, out int max)
        {
            min = max = arr[0];
         
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }
        }

        static void SecondThread()
        {
            for(int i = 0; i < 9; i++)
            {
                Console.WriteLine("Second Thread: " + i);
                Thread.Sleep(300);
            }
        }
    }
}
