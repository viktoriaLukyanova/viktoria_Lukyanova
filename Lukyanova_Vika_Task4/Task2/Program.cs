using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        private static string DelRepeats(string str)
        {
            String resStr = string.Empty;
            foreach (char s in str)
            {
                if (!resStr.Contains(s.ToString()))
                {
                    resStr = string.Concat(resStr, s);
                }
            }
            return resStr;
        }
        static void Main(string[] args)
        {
            string firstStr;
            string secondStr;
            do
            {
                Console.WriteLine("Input first string");
                firstStr = Console.ReadLine();
            } while (string.IsNullOrEmpty(firstStr));

            do
            {
                Console.WriteLine("Input second string");
                secondStr = Console.ReadLine();
            } while (string.IsNullOrEmpty(secondStr));

            secondStr = DelRepeats(secondStr);
            foreach (var i in secondStr)
            {
                firstStr = firstStr.Replace(i.ToString(), i.ToString() + i.ToString());
            }
            Console.WriteLine("Result: " + firstStr);
        }
    }
}
