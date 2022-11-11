using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW6
{
    public class FileHandler
    {
        public static string[] FileReader(string path)
        {
            string[] res;
            try
            {
                res = File.ReadAllLines(path);
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException("Path was inputted incorrectly.");
            }
            catch(DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException("Directory not found.");
            }
            catch(FileNotFoundException)
            {
                throw new FileNotFoundException("File not found.");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }
    }
}
