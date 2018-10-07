using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Program
    {
        static void ArrayWriteLine(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write(element + "\0");
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            int sum = 0;
            Random rmd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rmd.Next(15) - 5;
            }
            Console.Write("Array: ");
            ArrayWriteLine(arr);
            foreach (int m in arr)
            {
                if (m > 0)
                {
                    sum += m;
                }
            }
            Console.WriteLine("\nSum positive numbers: " + sum);
        }
    }
}
