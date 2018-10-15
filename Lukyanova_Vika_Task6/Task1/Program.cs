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
            public User()
            {
                Name = name;
                Birthday = birthday;
              //  LastName = lastName;
              //  Patronymical = patronymical;

            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (string.IsNullOrEmpty(value) && int.TryParse(value, out int num))
                    {
                        Console.WriteLine("Неккоректный формат Name");
                    }
                    else
                    {
                        name = value;
                    }
                }

            }
            public DateTime Birthday
            {
                set
                {
                    if (value < DateTime.Now)
                    {
                        birthday = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка: Дата рождения указана некорректно");
                    }
                }
            }
            public int Age
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
            public string LastName
            {
                set
                {
                    if (string.IsNullOrEmpty(value) && int.TryParse(value, out int num))
                    {
                        throw new Exception("Ошибка: Неккоректно указана фамилия");
                    }
                    else
                    {
                        lastName = value;
                    }

                }
            }
            public string Patronymical
            {
                set
                {
                    if (string.IsNullOrEmpty(value) && int.TryParse(value, out int num))
                    {
                        throw new Exception("Ошибка: Неккоректно указано отчество");
                    }
                    else
                    {
                        Patronymical = value;
                    }

                }

            }

            class Employee : User
            {
                public string post;
                public int experience;
                public DateTime beganWork;
                public Employee()
                {
                    Post = post;                    
                    BeganWork = beganWork;
                }
                public string Post
                {
                    set
                    {
                        if (string.IsNullOrEmpty(value) && int.TryParse(value, out int num))
                        {
                            Console.WriteLine("Такой должности не существует");
                        }
                        else
                        {
                            post = value;
                        }
                    }
                }
                public int Experience
                {
                    get
                    {
                        experience = (DateTime.Today.AddYears(-beganWork.Year)).Year;
                        if (DateTime.Today.DayOfYear <= beganWork.DayOfYear)
                        {
                            experience++;
                        }
                        return experience;
                    }
                }
                public DateTime BeganWork
                {
                    get { return beganWork.Date; }
                    set
                    {
                        if (value <= DateTime.Now.Date)
                        {
                            beganWork = value;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Неккоректная дата поступления");
                        }
                    }
                }
            }
            static void Main(string[] args)
            {
                Employee Petr = new Employee();                
                Petr.name = "Петр";
                Petr.birthday = new DateTime(1997, 5, 10);
                Petr.beganWork = new DateTime(2016, 10, 2);
                Petr.post = "Программист";
                Console.WriteLine(Petr.name + "\0 Возраст: " + Petr.Age + "\0 Начал работать: " + Petr.beganWork + "\0 Должность: " + Petr.post + "\0 Стаж: " + Petr.Experience);
            }
        }
    }
}
