using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_1
{
    class Program
    {
        static void ArrayWriteLine(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write(element+"\0");
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            Random Rmd = new Random();            
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Rmd.Next(100);
            }
            Array.Sort(arr);
            Console.Write("Sorted massive: ");
            ArrayWriteLine(arr);
            Console.WriteLine($"\nMin:{arr[0]} and Max: {arr[14]}");
            Console.ReadKey();
        }
    }
}
