using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Employee : User
    {
        public string post;
        public int experience;
        public DateTime beginWork;
        public Employee()
        {
            Post = post;
            BeginWork = beginWork;
        }
        public string Post
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    post = value;
                }
                else
                {
                    throw new Exception("Такой должности не существует");
                }
            }
        }
        public int Experience
        {
            get
            {
                return (DateTime.Today.AddYears(-beginWork.Year)).Year;
            }
        }
        public DateTime BeginWork
        {
            set
            {
                if (value <= DateTime.Now.Date)
                {
                    beginWork = value;
                }
                else
                {
                    throw new Exception("Ошибка: Неккоректная дата поступления");
                }
            }
        }
    }
}
