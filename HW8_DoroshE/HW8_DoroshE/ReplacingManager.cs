using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_DoroshE
{
    public class ReplacingManager
    {
        private static List<string[]>? ListOfReplaceableProducts;

        public static List<string>? GetListOfReplaceable(string productName)
        {
            if (productName == null) { throw new ArgumentNullException(); }

            UpdateListOfReplaceableProducts();

            if (ListOfReplaceableProducts == null ) { return null; }

            for (int i = 0; i < ListOfReplaceableProducts.Count; i++)
            {
                if (ListOfReplaceableProducts[i].Contains(productName.ToLower()))
                {
                    return ListOfReplaceableProducts[i].ToList();
                }
            }

            return null;
        }

        private static void UpdateListOfReplaceableProducts()
        {
            var data = FileHandler.ReadFile(OrderManager.PathToReplacingProducts);
            ListOfReplaceableProducts = data.Select(x => x.Split(",", StringSplitOptions.TrimEntries)).ToList();
        }
    }
}
