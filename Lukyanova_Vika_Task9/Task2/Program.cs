using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Task2
{
    class Program
    {
        class DinamicArray : IEnumerator
        {
            int capacity = 8;
            int lenght = 0;
            int position = -1;
            int[] arr;

            public DinamicArray()
            {
                arr = new int[capacity];
            }

            public DinamicArray(int num)
            {
                arr = new int[Add(num)];
            }

            public DinamicArray(int[] ar)
            {
                arr = new int[capacity];
                AddRange(ar);
            }

            public int Add(int num)
            {
                if (num > capacity)
                {
                    capacity *= 2;
                }
                return capacity;
            }

            public void AddRange(int[] num)
            {
                if (num.Length < capacity)
                {
                    for (int i = 0; i < num.Length; i++)
                    {
                        arr[i] = num[i];
                    }
                }
                else
                {
                    capacity *= 2;
                    AddRange(num);
                }
            }

            public void Remove(int index)
            {
                if (index < arr.Length)
                {
                    arr[index] = 0;
                }
                else
                {
                    Console.WriteLine("Элемент не найден");
                }
            }

            public int Capasity
            {
                get
                {
                    return capacity;
                }
            }

            public int Lenght
            {
                get { return lenght; }
            }



            public double this[int index]
            {
                get
                {
                    return arr[index];
                }
            }

            public void Insert(int element, int index)
            {
                if (index < Capasity)
                {
                    arr[index] = element;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            public IEnumerator GetEnumerator()
            {
                return arr.GetEnumerator();
            }            

            public object Current
            {
                get
                {
                    if (position == -1 || position >= arr.Length)
                        throw new InvalidOperationException();
                    return arr[position];
                }
            }

            public bool MoveNext()
            {
                if (position < arr.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                position = -1;
            }
        }


        static void Main(string[] args)
        {
            int[] mas = new int[] { 5, 1, 2, 3 };
            DinamicArray ar = new DinamicArray(mas);
            // Console.WriteLine(ar.Capasity);
            //ar.Insert(1, 0);
           // ar.Remove(0);
           
            foreach(var i in ar)
            {
                Console.WriteLine(i);
            }
        }
    }
}
