using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OptimAndGenerKode
{
    class Program
    {
        public static Dictionary<string, string> constList = new Dictionary<string, string>();
        public static string Alg(string[] tet, double x, double y) // алгоритм свертки
        {
            string t1 = string.Empty;
            double z = 0;
            switch (tet[0])
            {
                case "+":
                    z = x + y;
                    break;
                case "-":
                    z = x - y;
                    break;
                case "*":
                    z = x * y;
                    break;
                case "/":
                    z = x / y;
                    break;
                    
            }
            return z.ToString();
        }

        public static List<string> ReplaceConst(List<string> listTetra) // замена констант
        {
            int j = 0;
            string[,] arrayTetra = new string[listTetra.Count, 4];
            List<string> newListTetra = new List<string>();
            foreach (string str in listTetra)
            {
                string[] s = str.Split(new char[] { ',' });
                for (int i = 0; i < s.Length; i++)
                {
                    arrayTetra[j, i] = s[i];
                    if (constList.ContainsKey(arrayTetra[j, i]))
                    {
                        arrayTetra[j, i] = constList[arrayTetra[j, i]];
                    }
                }
                string st = string.Empty;
                st = arrayTetra[j, 0] + "," + arrayTetra[j, 1] + "," + arrayTetra[j, 2] + "," + arrayTetra[j, 3];
                newListTetra.Add(st);
                j++;
            }
            return newListTetra;
        }

        public static string Gener(List<string> tetra)
        {
            int j = 0;
            string[,] arrayTetra = new string[tetra.Count, 4];
            foreach (string str in tetra)
            {
                string[] s = str.Split(new char[] { ',' });
                for (int i = 0; i < s.Length; i++)
                {
                    arrayTetra[j, i] = s[i];
                }
                for (int i = 1; i < 3; i++)
                {
                    if (constList.ContainsKey(arrayTetra[j, i]) && (arrayTetra[j, 0] == "*" || arrayTetra[j, 0] == "/"))
                    {
                        string g = "(" + constList[arrayTetra[j, i]] + ")";
                        arrayTetra[j, i] = "(" + constList[arrayTetra[j, i]] + ")";
                        constList.Remove(arrayTetra[j, i]);
                        constList.Add(arrayTetra[j, i], g);
                    }
                    else if (constList.ContainsKey(arrayTetra[j, i]))
                    {
                        arrayTetra[j, i] = constList[arrayTetra[j, i]];
                    }
                }
                if (constList.ContainsKey(arrayTetra[j, 3]))
                {
                    constList.Remove(arrayTetra[j, 3]);
                    
                }                
                if (arrayTetra[j, 0] != "=")
                {
                    constList.Add(arrayTetra[j, 3], arrayTetra[j, 1] + arrayTetra[j, 0] + arrayTetra[j, 2]);
                }
                else
                {
                    constList.Add(arrayTetra[j, 3], arrayTetra[j, 1]);
                }
                j++;
            }
            return arrayTetra[tetra.Count - 1, 3] + "=" + constList[arrayTetra[tetra.Count - 1, 3]];
        }

        public static List<string> Exp(List<string> assing) //алгоритм исключения
        {
            int j = 0;
            string[,] arrayTetra = new string[assing.Count, 4];
            List<string> newListTetra = new List<string>();
            foreach (string str in assing)
            {
                string[] s = str.Split(new char[] { ',' });
                for (int i = 0; i < s.Length; i++)
                {
                    arrayTetra[j, i] = s[i];
                }
                j++;
            }
            for (int i = 1; i < assing.Count; i++)
            {
                if ((arrayTetra[i - 1, 0] == "+") && ((arrayTetra[i - 1, 1] == arrayTetra[i, 1]) || (arrayTetra[i - 1, 1] == arrayTetra[i, 2])) && ((arrayTetra[i - 1, 2] == arrayTetra[i, 2]) || (arrayTetra[i - 1, 2] == arrayTetra[i, 1])))
                {
                    constList.Add(arrayTetra[i, 3], arrayTetra[i - 1, 3]);
                    assing.RemoveAt(i);
                    assing = ReplaceConst(assing);
                }
                if ((arrayTetra[i - 1, 0] == "*") && ((arrayTetra[i - 1, 1] == arrayTetra[i, 1]) || (arrayTetra[i - 1, 1] == arrayTetra[i, 2])) && ((arrayTetra[i - 1, 2] == arrayTetra[i, 2]) || (arrayTetra[i - 1, 2] == arrayTetra[i, 1])))
                {
                    constList.Add(arrayTetra[i, 3], arrayTetra[i - 1, 3]);
                    assing.RemoveAt(i);
                    assing = ReplaceConst(assing);
                }
            }
            return assing;
        }

        static void Main(string[] args)
        {
            List<string> temp = new List<string>();
            List<string> tempNew = new List<string>();
            string[] loadtet = File.ReadAllLines("tet2.txt");
            foreach (string str in loadtet)
            {
                temp.Add(str);
            }
            //алгоритм свертки
            do
            {
                tempNew.Clear();
                foreach (string str in temp)
                {
                    tempNew.Add(str);
                }
                foreach (string tet in tempNew)
                {
                    string[] sym = tet.Split(new char[] { ',' });
                    if (double.TryParse(sym[1], out double x) && double.TryParse(sym[2], out double y))
                    {
                        constList.Add(sym[3], Alg(sym, x, y));
                        temp.Remove(tet);
                        temp = ReplaceConst(temp);
                    }
                }
            } while (temp.Count != tempNew.Count);
            
            //алгоритм исключения            
            List<string> assing = new List<string>();
            foreach (string str in temp)
            {
                string[] sym = str.Split(new char[] { ',' });
                if (sym[0] != "=")
                {
                    assing.Add(str);
                }
                else
                {
                    assing.Add(str);
                    temp = Exp(assing);
                    File.AppendAllText("tet2.txt", "\r\n" + Gener(temp));                                     
                    assing.Clear();
                }
            }           
        }
    }
}
