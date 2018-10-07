using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Program
    {
        static void ArrayWriteLine(int[,] arr, int i)
        {
            for (int j=0; j<5; j++)
            {
                Console.Write(arr[i,j]+"\0");
            }
        }
        static void Main(string[] args)
        {
            int[,] matrix = new int[5,5];
            int sum = 0;
            Random rmd = new Random();
            for (int i=0; i<5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i,j] = rmd.Next(10);
                    if ((i+j)%2==0)
                    {
                        sum += matrix[i, j];
                    }
                }
                ArrayWriteLine(matrix,i);
                Console.WriteLine();
            }
            Console.WriteLine("Sum even positions:" + sum);
        }
    }
}
