using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int starLevel;
            string number;
            do
            {
                Console.Write("Input positive number ");
                number = Console.ReadLine();
            }
            while (!(int.TryParse(number, out starLevel)) && starLevel < 0);
            for (int i = 1; i < starLevel + 1; i++)
            {
                String sing = new string(' ', starLevel - i);
                Console.Write(sing);
                sing = new string('*', 1 + (i - 1) * 2);
                Console.WriteLine(sing);

            }
        }
    }
}