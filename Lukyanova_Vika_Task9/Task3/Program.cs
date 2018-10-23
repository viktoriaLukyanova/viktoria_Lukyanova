using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        private static List<string> DelRepeats(string[] str)
        {
            List<string> list = new List<string>(str.Length);
            String resStr = string.Empty;
            foreach (string s in str)
            {
                if (!list.Contains(s))
                {
                    list.Add(s);
                }
            }
            return list;
        }
        static void Main(string[] args)
        {
           // String NameFile = Console.ReadLine();
           // string[] txt = File.ReadAllLines("Text.txt");
             string str = "Actually it is about MY GIRLFRIEND PET CAT That way you can combine this sentence with the next one If you say a pet of it means that she has several pets and you are just going to write about one of them He is AN OUTDOOR CAT but usually sleeps IN THE HOUSE He eats IN THE HOUSE TOO we keep a sack of cat food on the floor for him He likes to go OUT at night Imagine this I am lying IN BED trying to sleep AND he comes up to my door and starts to sCratch and MEOW like let me out Ok I GET up and go with him Suddenly he LAYS ON HIS SIDE IN the middle of the kitchen FOR ME TO PET HIM OK I pet him AND make HIM stand up He WALKS but not outside he shows me how he eats at midnight It takes of couple of minuteS then I open the door and say Get out BUT HE iS LIKE NO I go BACK TO BED and he DOES THE SAME THING probably three MORE times then he finally goes OUT";
           // string str = string.Join("\n",txt);            
            str = str.ToLower();
            Console.WriteLine(str);
            string[] arr;
            Regex reg = new Regex(" ");
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            arr = reg.Split(str);
            // Array.Sort(arr);
           var list = DelRepeats(arr);
            int count = 0, j;
            
            for (int i=0; i<list.Count; i++)
            {
                for (j = 0; j <arr.Length; j++)
                {
                    if (list[i] == arr[j])
                    {
                        count++;
                    }
                }
                dictionary.Add(list[i], count);                
                count = 0;
            }
            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
           
        }
    }
}
