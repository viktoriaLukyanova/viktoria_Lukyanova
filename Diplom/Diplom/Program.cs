using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom
{
    class Program
    {
        static public int[,] Transpon(int[,] matrix, int masEl, int tran)
        {
            int[,] matrixT = new int[masEl, tran];
            for (int i = 0; i < tran; i++)
            {
                for (int j = 0; j < masEl; j++)
                {
                    matrixT[j, i] = matrix[i, j];
                }
            }
            return matrixT;
        }


        static void Main(string[] args)
        {
            List<string> transacts = new List<string>();
            transacts.Add("Хлеб Молоко Печенье");
            transacts.Add("Молоко Сметана");
            transacts.Add("Молоко Хлеб Сметана Печенье");
            transacts.Add("Колбаса Сметана");
            transacts.Add("Хлеб Молоко Печенье Сметана");
            transacts.Add("Конфеты");

            List<string> masElements = new List<string>(); //Массив неповторяющихся элементов
            //Формирования элементов
            for (int i = 0; i < transacts.Count; i++)
            {
                string str = transacts[i];
                string[] masStr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < masStr.Length; j++)
                {
                    if (str.Contains(masStr[j]))
                    {
                        if (!masElements.Contains(masStr[j]))
                        {
                            masElements.Add(masStr[j]);
                        }
                    }
                }
            }
            //создание нормальной матрицы
            int[,] normalTabelTransact = new int[transacts.Count, masElements.Count];
            for (int i = 0; i < transacts.Count; i++)
            {
                for (int j = 0; j < masElements.Count; j++)
                {
                    if (transacts[i].Contains(masElements[j]))
                    {
                        normalTabelTransact[i, j] = 1;
                    }
                    else
                    {
                        normalTabelTransact[i, j] = 0;
                    }
                }
            }
            for (int i = 0; i < transacts.Count; i++)
            {
                for (int j = 0; j < masElements.Count; j++)
                {

                    Console.Write(normalTabelTransact[i,j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < masElements.Count; i++)
            {
                Console.WriteLine(masElements[i]);
            }

            //реализация алгоритма из статьи
            int countMasElement = masElements.Count;
            int countTransacts = transacts.Count;
            int[,] matrixT = Transpon(normalTabelTransact, countMasElement, countTransacts);
            int[,] f = new int[masElements.Count, masElements.Count];

            for (int i = 0; i < masElements.Count; i++)
            {
                for (int j = 0; j < masElements.Count; j++)
                {
                    for (int k = 0; k < transacts.Count; k++)
                    {
                        f[i, j] += matrixT[i, k] * normalTabelTransact[k, j];
                    }
                }
            }
            for (int i = 0; i < masElements.Count; i++)
            {
                for (int j = 0; j < masElements.Count; j++)
                {
                    Console.Write(f[i, j]);
                }
                Console.WriteLine();
            }
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            if (a == b)
            {
                Console.WriteLine("так нельзя");
            }
            else
            {
                Console.WriteLine("Из " + masElements[a] + " следует " + masElements[b] + " с значением равным " + ((f[a, a] - 2 * f[a, b] + f[b, b]) / f[a, b]));
            }

        }
    }
}
