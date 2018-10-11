using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {
        static public double Check(string number)
        {
            double res = -1;
            double r = 0;
            if ((double.TryParse(number, out r)) && r > 0)
            {
                return res = r;
            }
            else
            {
                Console.WriteLine("This isn't number or number is negative or equals zero");
                return res;
            }
        }
        static void Main(string[] args)
        {
            double width = 0;
            double hieght = 0;
            do
            {
                Console.Write("Input width:");
                string oneNumber = Console.ReadLine();
                width = Check(oneNumber);
            }
            while (width < 0);
            do
            {
                Console.Write("Input hieght:");
                string twoNumber = Console.ReadLine();
                hieght = Check(twoNumber);
            }
            while (hieght < 0);
            Console.WriteLine($"Square of rectangle is {width * hieght}");
        }
    }
}
