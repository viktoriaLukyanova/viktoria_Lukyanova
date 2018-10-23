using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class User
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
        // Вынести классы в отдельные файлы----
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Неккоректный формат Name");
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
                if (string.IsNullOrEmpty(value))
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
                if (string.IsNullOrEmpty(value))
                {
                    patronymical = "-";
                }
                else
                {
                    Patronymical = value;
                }

            }
        }

    }
}