using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_DoroshE
{
    public class OrdersHandler
    {
        public static Dictionary<string, List<(string, int)>> ManageData(string path)
        {
            if (!File.Exists(path)) { throw new ArgumentException(); }

            Dictionary<string, List<(string, int)>> res = new();
            string[] str = FileHandler.ReadFile(path);

            FillDictionary(res, str);

            return res;
        }

        private static void FillDictionary(Dictionary<string, List<(string, int)>> res, string[] str)
        {
            foreach (var order in str)
            {
                string[] splitedString = order.Split(",", StringSplitOptions.RemoveEmptyEntries);

                string company = splitedString[0].ToLower();
                string product = splitedString[1].ToLower();
                int amount = Convert.ToInt32(splitedString[2]);

                if (res.ContainsKey(product)) { res[product].Add((company, amount)); }
                else { res.Add(product, new List<(string, int)>() { (company, amount) }); }
            }
        }
    }
}
