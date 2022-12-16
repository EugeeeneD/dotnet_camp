using HW8_DoroshE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.test
{
    public class RandomNumbers
    {
        public static void CreateUnsortedFile(uint lines, uint numbersInline, int lowerBound, int upperBound, string path)
        {
            Random r = new Random();

            List<string> res = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < numbersInline; j++)
                {
                    str.Append(r.Next(lowerBound, upperBound + 1) + " ");
                }
                res.Add(str.ToString());
            }

            res.ForEach(x => FileHandler.WriteToFile(x, path));
        }
    }
}
