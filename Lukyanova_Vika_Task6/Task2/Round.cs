using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Round
    {
        public double x, y, r;
        public Round(double x, double y, double r)
        {
            Radius = r;
        }
        public double Radius
        {
            get
            {
                return r;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Некорректное значение");
                }
                else
                {
                    r = value;
                }
            }
        }
        public double AreaRound
        {
            get
            {
                return Math.PI * r * r;
            }
        }
        public double Length { get { return 2 * Math.PI * r; } }
    }
}
