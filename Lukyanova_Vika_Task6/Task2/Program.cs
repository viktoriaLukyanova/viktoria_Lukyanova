using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {        
            static void Main(string[] args)
            {
                Ring rr = new Ring(10,10,0,0);                
                Console.WriteLine("площадь круга: " + rr.AreaRound);
                Console.WriteLine("длина круга: " + rr.Length);
                Console.WriteLine("площадь кольца: " + rr.AreaRing());
                Console.WriteLine("Сумма внешней и внутренней границ кольца: " + rr.SumLength());
            }
        }
    }
}
