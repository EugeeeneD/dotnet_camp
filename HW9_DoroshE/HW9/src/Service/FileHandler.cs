using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.src.Service
{
    public class FileHandler
    {
        public static void SplitFile(string path)
        {
            int rowsHalf = GetAmountOfRowsInFile(path) / 2;
            int currentRow = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    if (currentRow < rowsHalf)
                    {
                        File.AppendAllText(Environment.CurrentDirectory + "\\splited0.txt", str);
                        ++currentRow;
                    }
                    else
                    {
                        File.AppendAllText(Environment.CurrentDirectory + "\\splited1.txt", str);
                        ++currentRow;
                    }
                }
            }
        }

        public static int GetAmountOfRowsInFile(string path)
        {
            int res = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                while ((str = sr.ReadLine()) != null) { ++res; }
            }

            return res;
        }

        public static void WriteToFile(string path, string str)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(str);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(str);
                }
            }
        }

        public static void WriteNumberToResultFile(int number)
        {
            FileHandler.WriteToFile(Environment.CurrentDirectory + "\\result.txt", number + " ");
        }
    }
}
