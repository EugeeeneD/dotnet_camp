using HW8_DoroshE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.src.Service
{
    public class Converter
    {
        public static List<int> GetListOfNumbersFromFile(string path)
        {
            string str = File.ReadAllText(path);

            List<int> res = str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => Convert.ToInt32(x)).ToList<int>();
            
            return res;
        }

        public static List<int> SortedIntListFromString(string str)
        {
            List<int> res = str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => Convert.ToInt32(x)).ToList<int>();
            res.Sort();
            return res;
        }

        public static string IntListToString(List<int> list)
        {
            StringBuilder res = new();
            foreach (var item in list)
            {
                res.Append(item + " ");
            }

            return res.ToString();
        }
    }
}
