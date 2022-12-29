using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.src.Service
{
    public class Split
    {
        public static int SplitFileAndSortArray(string path)
        {
            int countOfSplitedFiles = 0;


            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    var sortedIntList = Converter.SortedIntListFromString(str);
                    File.WriteAllText($"splited{countOfSplitedFiles}.txt", Converter.IntListToString(sortedIntList));
                    countOfSplitedFiles++;
                }
            }

            return countOfSplitedFiles;
        }
    }
}
