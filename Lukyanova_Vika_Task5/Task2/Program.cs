using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        public class Round
        {
            private double x, y, r;
            public double Radius
            {
                get
                {
                    return r;
                }

                set
                {
                    x = y = 0;
                    if (value <= 0)
                    {
                        throw new ArgumentException("Некорректное значение");
                    }
                    else
                    {
                        r = value;
                    }

                }
            }
            public double GetArea
            {
                get
                {
                    return Math.PI * r * r;
                }
            }

            public double Length { get { return 2 * Math.PI * r; } }

            public double X { get { return x; } }

            public double Y { get { return y; } }

            static void Main(string[] args)
            {
                Round circul = new Round();
                circul.Radius = 5;
                Console.WriteLine(circul.GetArea);
                Console.WriteLine(circul.Length);

            }
        }
    }
}