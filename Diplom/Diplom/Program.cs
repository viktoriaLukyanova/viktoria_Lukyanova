using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom
{
    class Program
    {
        static public int[,] Transpon(int[,] matrix)
        {
            int[,] matrixT = new int[9, 7];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matrixT[j, i] = matrix[i, j];
                }
            }
            return matrixT;
        }
        static void Main(string[] args)
        {
            int[,] normalTabelTransact = new int[,] {{0,1,1,0,1,0,0,1,0},
                                                    {0,1,1,0,0,0,1,0,1},
                                                    {1,0,0,1,0,0,0,0,1},
                                                    {0,1,1,0,1,0,0,0,0},
                                                    {1,0,0,0,0,1,0,0,1},
                                                    {0,1,1,0,0,1,0,0,0},
                                                    {0,0,0,1,0,0,1,1,0}};
            int[,] matrixT = Transpon(normalTabelTransact);
            int[,] f = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        f[i, j] += matrixT[i, k] * normalTabelTransact[k, j];
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(f[i, j]);
                }
                Console.WriteLine();
            }
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Это какой-то результат, я еще не поняла зачем он " + ((f[a, a] - 2 * f[a, b] + f[b, b]) / f[a, b]));


        }
    }
}
