using HW8_DoroshE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.src.Service
{
    public class ConvertFileToList
    {
        public static List<int> GetListOfNumbers(string path)
        {
            string str = File.ReadAllText(path);

            List<int> res = str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => Convert.ToInt32(x)).ToList<int>();
            
            return res;
        }
    }
}
