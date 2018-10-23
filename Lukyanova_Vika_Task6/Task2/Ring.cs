using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Ring : Round
    {
        public double rIn, xIn, yIn;
        public Ring(double r, double rIn, double x, double y) : base(x, y, r)
        {
            R = rIn;
        }
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
                            throw new Exception("Ошибка: Внутренний радиус не может быть больше чем внешний");
                        }
                    }
                    else
                    {
                        throw new Exception("Ошибка: Введен отрицательный радиус");
                    }
                else
                {
                    throw new Exception("Центры точек не совпадают");
                }
            }
        }
        public double AreaRing()
        {
            return AreaRound - Math.PI * rIn * rIn;
        }
        public double SumLength()
        {
            return Length + 2 * Math.PI * rIn;
        }
    }
}
