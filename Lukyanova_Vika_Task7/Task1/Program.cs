using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {

        abstract class Figuri
        {
            public abstract string Draw { get; }
        }
        class Rectangle : Figuri
        {
            protected double hieght, width;
            public Rectangle(double hieght, double width)
            {
                this.hieght = hieght;
                this.width = width;
            }
            public override string Draw
            {
                get
                {
                    return "Это Треугольник с длиной:" + hieght + " и высотой: " + width;
                }
            }
        }
        class Line : Figuri
        {
            protected double lenghtLine;
            public Line(double lenghtLine)
            {
                this.lenghtLine = lenghtLine;
            }
            public override string Draw
            {
                get
                {
                    return "Это Линия с длиной:" + lenghtLine;
                }
            }
        }
        class Round : Figuri
        {
            protected double x, y, r;
            public Round(double x, double y, double r)
            {
                this.x = x;
                this.y = y;
                this.r = r;
            }
            public override string Draw
            {
                get
                {
                    return $"Это Круг с центром в точке({x};{y}) и радиусом: {r}";
                }
            }
        }
        class Ring : Round
        {
            protected double innerR;
            public Ring(double x, double y, double r, double innerR) : base(x, y, r)
            {
                this.innerR = innerR;
            }
            public override string Draw
            {
                get
                {
                    return $"Это Кольцо с центром в точке ({x};{y}), внешним радиусом: {r} и внутренним радиусом {innerR}";
                }
            }
        }
        static void Main(string[] args)           
        {
            Figuri[] arrF = new Figuri[4];
            for (int i = 0; i < arrF.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        arrF[i] = new Rectangle(10, 20);
                        break;
                    case 1:
                        arrF[i] = new Round(0, 0, 15);
                        break;
                    case 2:
                        arrF[i] = new Ring(0, 0, 10, 5);
                        break;
                    case 3:
                        arrF[i] = new Line(50);
                        break;
                }
            }
            foreach (Figuri printF in arrF)
            {
                Console.WriteLine(printF.Draw);
            }
        }
    }
}