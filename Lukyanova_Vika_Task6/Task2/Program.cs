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

            class Ring : Round
            {
                public double rIn, xIn, yIn;                
                public double R
                {
                    set
                    {
                        if (xIn == x && yIn == y)
                            if (value >= 0)
                            {
                                if (value <= r)
                                {
                                    rIn = value;
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: Внутренний радиус не может быть больше чем внешний");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Введен отрицательный радиус");
                            }
                        else
                        {
                            Console.WriteLine("Центры точек не совпадают");
                        }
                    }
                    get { return rIn; }
                }
                public double AreaRing()
                {
                    return GetArea - Math.PI * rIn * rIn;
                }
                public double SumLength()
                {
                    return Length+ 2 * Math.PI * r;
                }

            }
            static void Main(string[] args)
            {
                Ring rr = new Ring();
                rr.Radius = 10;
                rr.R = 0;
                Console.WriteLine("площадь круга: " + rr.GetArea);
                Console.WriteLine("длина круга: " + rr.Length);
                Console.WriteLine("площадь кольца: "+rr.AreaRing());
                Console.WriteLine("Сумма внешней и внутренней границ кольца: " + rr.SumLength());
            }
        }
    }
}
