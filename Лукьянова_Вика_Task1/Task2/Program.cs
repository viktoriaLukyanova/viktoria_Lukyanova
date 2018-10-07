using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int column;
            string number;
            do
            {
                Console.Write("Input number ");
                number = Console.ReadLine();
            }
            while (!(int.TryParse(number, out column)) && column < 0);
           
             for (int i = 0; i < column; i++)
             {
                 String a = new string('*', i + 1);
                 Console.WriteLine(a);
             }
        }
    }
}
