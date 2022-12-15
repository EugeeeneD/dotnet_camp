using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_DoroshE
{
    public class Subscribers
    {
        public static string pathToWriteFailedOrder { get; set; }

        public static void WriteFailedOrder(string str)
        {
            FileHandler.WriteToFile(str, pathToWriteFailedOrder);
        }
    }
}
