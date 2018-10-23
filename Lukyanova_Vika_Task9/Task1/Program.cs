using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {
        public static void RemoveEachSecondItem(List<int> list)
        {
            int i = 1;           
            while (list.Count != 1)
            {
                list.RemoveAt(i);
                i++;
                if (i > list.Count)
                {
                    i = 1;
                }
                if (i == list.Count)
                {
                    i = 0;
                }
            }
        }
        public static void RemoveEachSecondItem(LinkedList<int> list)
        {
            var first = list.First;

            while (list.Count != 1)
            {
                list.Remove(first.Next ?? list.First);
                first = first.Next ?? list.First;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Put count person at table");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] person = new int[count];

            List<int> table = new List<int>(person);
            RemoveEachSecondItem(table);

            LinkedList<int> table2 = new LinkedList<int>(person);
            RemoveEachSecondItem(table2);
        }
    }
}
