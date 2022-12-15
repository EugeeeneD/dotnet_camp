using HW1;
using HW3_DoroshE;
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

        public static List<string>? GetListOfReplaceable(string productName, string PathToReplacingProducts)
        {
            if (productName == null) { throw new ArgumentNullException(); }

            UpdateListOfReplaceableProducts(PathToReplacingProducts);

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

        private static void UpdateListOfReplaceableProducts(string PathToReplacingProducts)
        {
            var data = FileHandler.ReadFile(PathToReplacingProducts);
            ListOfReplaceableProducts = data.Select(x => x.Split(",", StringSplitOptions.TrimEntries)).ToList();
        }

        public static bool ReplaceWithAdjustments(Storage storage, (string, int) company, Product product,
                                        List<string> replacingProducts, List<(string, string)> doneOrders, ref int currentAmountOfOriginProduct)
        {
            foreach (var adjProduct in replacingProducts)
            {
                Product adjustedProduct = storage.GetProductByName(adjProduct);
                if (adjustedProduct == null) { continue; }

                int amountWithAdjustedProduct = currentAmountOfOriginProduct + storage[adjustedProduct];

                if (amountWithAdjustedProduct >= company.Item2)
                {
                    currentAmountOfOriginProduct = 0;
                    doneOrders.Add((adjProduct, company.Item1));
                    storage[product] = 0;
                    if (amountWithAdjustedProduct - company.Item2 < 0)
                    {
                        Console.WriteLine("wtf");
                        storage[adjustedProduct] = amountWithAdjustedProduct - company.Item2;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
