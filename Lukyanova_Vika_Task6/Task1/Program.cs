using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {        
            static void Main(string[] args)
            {
                Employee Petr = new Employee();
                Petr.name = "Петр";
                Petr.Birthday = new DateTime(1997, 5, 10);
                Petr.beginWork = new DateTime(2016, 10, 2);
                Petr.post = "Программист";
                Console.WriteLine(Petr.name + "\0 Возраст: " + Petr.Age + "\0 Начал работать: " + Petr.beginWork + "\0 Должность: " + Petr.post + "\0 Стаж: " + Petr.Experience);
            }
        }
    }
}
