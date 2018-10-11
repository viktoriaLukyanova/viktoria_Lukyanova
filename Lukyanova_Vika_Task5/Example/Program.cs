using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
        class UserInfo
        {
            int a;
            string s = "Alex";

            // Создадим свойство, управляющее
            // доступом к переменной a
            public int Age
            {
                get
                {
                    if (a <= 0)
                        return 1;
                    return a;
                }

                set
                {
                    a = value;
                }
            }

            // Свойство только для чтения
            // переменной s
            // аксессор set отсутствует
            public string Name
            {
                get
                {
                    return s;
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                UserInfo ui = new UserInfo();

                // Доступ к закрытой переменной экземпляра только через свойство
                ui.Age = 26;
                // Переменная только для чтения
                string myName = ui.Name;

                Console.ReadLine();
            }
        }
    }