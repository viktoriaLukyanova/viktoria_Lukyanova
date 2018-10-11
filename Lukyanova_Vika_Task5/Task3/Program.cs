using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Program
    {
        class Triangle
        {
            double a;
            double b;
            double c;
            double per;
            public string P(int a, int b, int c)
            {
                if (!((a + b) < c || (a + c) < b || (b + c) < b))
                {
                    return (a + b + c).ToString();
                }
                else
                {
                    return "Такого треугольника не существует";
                }

            }
            public string S(int a, int b, int c)
            {
                if (!((a + b) < c || (a + c) < b || (b + c) < b))
                {
                    per = Convert.ToDouble(P(a, b, c));
                    return (Math.Sqrt(per * (per - a) * (per - b) * (per - c))).ToString();
                }
                return "Такого треугольника несуществует";
            }
            public int setA
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
            public int setB
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
            public int setC
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
            Triangle one = new Triangle();
            Console.WriteLine(one.P(1, 1,1));
            Console.WriteLine(one.S(1, 1,1));
        }
    }
}
