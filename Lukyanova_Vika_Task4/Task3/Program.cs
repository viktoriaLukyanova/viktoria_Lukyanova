using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task3
{
    class Program
    {
        static void PrintInfo(CultureInfo culture, CultureInfo culture2)
        {
            Console.WriteLine("Date Format\t"+DateTime.Now.ToString(culture)+"\t"+ DateTime.Now.ToString(culture2));
            Console.WriteLine("Currency Format\t"+culture.NumberFormat.CurrencyGroupSeparator+"\t"+ culture2.NumberFormat.CurrencyGroupSeparator);
            Console.WriteLine("Number Format\t"+culture.NumberFormat.NumberGroupSeparator+"\t"+ culture2.NumberFormat.CurrencyDecimalSeparator);
        }

        static CultureInfo GetCultureInfoByName(string name)
        {
            return new CultureInfo(name);
        }

        static void Main(string[] args)
        {

            string cult = string.Empty;
            string name1 = string.Empty;
            string name2 = string.Empty;
            bool log=false;            
            Console.WriteLine("Input two culture. (Exemple: ru-RU en-US)");
            while (log == false) 
            {
                try
                {                    
                    name1 = Console.ReadLine();
                    name2 = Console.ReadLine();
                    log = true;
                    var culture = GetCultureInfoByName(name1);
                    var culture2 = GetCultureInfoByName(name2);
                    PrintInfo(culture, culture2);                    
                }                
                catch (Exception)
                {
                    Console.WriteLine("Error: Try again");
                    log = false;
                }
            }            
        }

    }
}
