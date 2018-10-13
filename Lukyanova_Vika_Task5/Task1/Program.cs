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
            
            public string SetName
            {
                get
                {
                    return name;
                }
                set
                {
                    if (string.IsNullOrEmpty(value) || int.TryParse(value, out int num))
                    {
                        throw new Exception("Некорректный формат");
                    }
                    else
                    {
                        name = value;
                    }
                }

            }            
            public string SetLastName
            {
                set
                {
                    if (string.IsNullOrEmpty(value) || int.TryParse(value, out int num))
                    {
                        throw new Exception("Некорректный формат");
                    }
                    else
                    {
                        lastName = value;
                    }

                }
            }
            public string SetPatronymical
            {
                set
                {
                    if (string.IsNullOrEmpty(value) || int.TryParse(value, out int num))
                    {
                        throw new Exception("Некорректный формат");
                    }
                    else
                    {
                        patronymical = value;
                    }
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
                    return age = DateTime.Now.Year-birthday.Year;                    
                }
            }
            
        }
        static void Main(string[] args)
        {
            User Pes = new User();
           // Pes.SetName = "Петя";
          //  DateTime date = new DateTime(2010,10,20);
          //  Pes.SetBirthday=date;
            Console.WriteLine(Pes.age);
            
        }
    }
}