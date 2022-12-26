using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.service
{
    public class FileHandler
    {
        public static string[] ReadFile(string path)
        {
            string[] res;
            try
            {
                res = File.ReadAllLines(path);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Path was inputted incorrectly.");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Directory not found.");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File not found.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public static void WriteToFile(string str, string path)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(str);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(str);
                } 
            }
        }
    }
}
