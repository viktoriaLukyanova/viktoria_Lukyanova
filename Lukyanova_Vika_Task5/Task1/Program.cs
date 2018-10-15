using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {
        class User
        {
            public string name;
            public string lastName;
            public string patronymical;
            public int age;
            public DateTime birthday;
            public string Check(string str)
            {
                if (string.IsNullOrEmpty(str) || int.TryParse(str, out int num))
                {
                    throw new Exception("Некорректный формат");
                }
                else
                {
                    return str;
                }
            }
            public DateTime SetBirthday
            {
                set
                {
                    if (value < DateTime.Now)
                    {
                        birthday = value;
                    }
                    else
                    {
                        throw new Exception("Неккоректное значение");
                    }
                }
            }
            public int GetAge
            {
                get
                {
                    age = (DateTime.Today.AddYears(-birthday.Year)).Year;
                    if (DateTime.Today.DayOfYear <= birthday.DayOfYear)
                    {
                        age++;
                    }
                    return age;
                }
            }

        }
        static void Main(string[] args)
        {
            User Pes = new User();
            DateTime date = new DateTime(1997, 9, 25);
            Pes.birthday = date;
            string name = "Петя";
            Pes.Check(Pes.name = name);
            Console.WriteLine(Pes.name + "\0" + Pes.GetAge);

        }
    }
}