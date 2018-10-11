using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string str = string.Empty;
            do
            {
                Console.WriteLine("Input phrase: ");
                str = Console.ReadLine();
            } while (string.IsNullOrEmpty(str));
            string word = string.Empty;
            string[] sentence = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);  
            foreach (string words in sentence)
            {
                foreach(char s in words)
                {
                    if (Char.IsPunctuation(s))
                    {
                        word = words.Remove(words.IndexOf(s));
                        sum += word.Length;
                    }
                    else
                    {
                        sum += words.Length;
                    }
                }  
            }
            Console.WriteLine("Average length word in sentence=" + sum/ sentence.Length);

        }
    }
}
