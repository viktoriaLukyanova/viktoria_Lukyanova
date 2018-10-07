using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        static void ArrayWriteLine(int[,,] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.WriteLine("X:"+i+"\0Y:"+j+"\0Z:"+k+"\0"+arr[i, j, k]);
                    }
                    Console.WriteLine();
                }                
            }
        }
        static void Main(string[] args)
        {
            int countReplace=0;
            Random rmd = new Random();
            int[,,] arrayD = new int[3,3,3];
            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    for (int k = 0; k <3; k++)
                    {
                        arrayD[i, j, k] = rmd.Next(10)-5;
                        if (arrayD[i, j, k] >= 0)
                        {
                            arrayD[i, j, k] = 0;
                            countReplace++;
                        }
                    }
                }
            }
            ArrayWriteLine(arrayD);
            Console.WriteLine("Count replaces: "+countReplace);
        }
    }
}
