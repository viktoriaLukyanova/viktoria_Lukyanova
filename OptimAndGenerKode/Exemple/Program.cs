using System;
using System.Collections.Generic;
using System.Text;

namespace Exemple
{
    class Program
    {
        public static Dictionary<string, string> constList = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            List<string> listTetra = new List<string>(4);

            int j = 0;
            string[,] arrayTetra = new string[listTetra.Count, 3];
            foreach (string str in listTetra)
            {
                string[] s = str.Split(new char[] { ',' });
                for (int i = 0; i < s.Length; i++)
                {
                    arrayTetra[j, i] = s[i];
                    if (constList.ContainsKey(arrayTetra[j,i]))
                    {
                        arrayTetra[j,i] = constList[arrayTetra[j,i]];
                    }
                }
                j++;
            }
            
                
            }
        }
    }
}
