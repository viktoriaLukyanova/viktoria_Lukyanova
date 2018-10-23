using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 100; i = i + 3)
            {
                sum += i;
            }
            for (int i = 0; i < 100; i = i + 5)
            {

                if (i % 3 != 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum of all numbers less 100 which divide by 3 or 5 = "+sum);
        }
    }
}
