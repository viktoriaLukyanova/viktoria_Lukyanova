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
            DateTime birthday = new DateTime();
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
            public int SetAge
            {
                set
                {
                    if (value > 0)
                    {
                        age = value;
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
                        SetPatronymical = value;
                    }

                }

            }
            public DateTime SetBirthday
            {
                set
                {
                    if (value > DateTime.Now)
                    {
                        birthday = value;
                    }
                    else
                    {
                        throw new Exception("Неккоректное значение");
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            User Pes = new User();
            Pes.SetName = "Петя";
        }
    }
}