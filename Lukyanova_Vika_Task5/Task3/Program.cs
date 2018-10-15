using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Program
    {
        class Triangle
        {
            public double a;
            public double b;
            public double c;
            public double per;
            public Triangle(double a, double b, double c)
            {
                setA = a;
                setB = b;
                setC = c;
                if (!((a + b) < c || (a + c) < b || (b + c) < a))
                {
                    Console.WriteLine("P: " + P(a, b, c));
                    Console.WriteLine("S: " + S(a, b, c));

                }
                else
                {
                    Console.WriteLine("Ошибка: Такого треугольника не существует");
                }
            }
            public double P(double a, double b, double c)
            {
                return per = (a + b + c);
            }
            public double S(double a, double b, double c)
            {
                return Math.Sqrt(per * (per - a) * (per - b) * (per - c));
            }
            public double setA
            {
                set
                {
                    if (value > 0)
                    {
                        a = value;
                    }
                    else
                    {
                        throw new Exception("Некорректный формат");
                    }
                }
            }
            public double setB
            {
                set
                {
                    if (value > 0)
                    {
                        b = value;
                    }
                    else
                    {
                        throw new Exception("Некорректный формат");
                    }

                }
            }
            public double setC
            {
                set
                {
                    if (value > 0)
                    {
                        c = value;
                    }
                    else
                    {
                        throw new Exception("Некорректный формат");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Triangle one = new Triangle(1,1,1);                      
            Console.WriteLine(one.c);





        }
    }
}
