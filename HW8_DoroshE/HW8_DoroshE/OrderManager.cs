using HW1;
using HW3_DoroshE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_DoroshE
{
    public static class OrderManager
    {
        // не впевнений куда їх помістити
        private static string pathToGetOrders;
        private static string pathToWriteFailedOrder;
        private static string pathToReplacingProducts;

        public static string PathToGetOrders
        {
            get
            {
                return pathToGetOrders;
            }
            set
            {
                if (File.Exists(value)) { pathToGetOrders = value; }
            }
        }
        public static string PathToWriteFailedOrder
        {
            get
            {
                return pathToWriteFailedOrder;
            }
            set
            {
                pathToWriteFailedOrder = value;
            }
        }
        public static string PathToReplacingProducts
        {
            get
            {
                return pathToReplacingProducts;
            }
            set
            {
                if (File.Exists(value)) { pathToReplacingProducts = value; }
            }
        }
        delegate void WriteToFile(string str, string path);

        //можна було простіше, але вже пізно
        public static List<(string, string)> FulfilOrders(Storage storage)
        {
            WriteToFile writeFailedOrder = FileHandler.WriteToFile;

            Dictionary<string, List<(string, int)>> orders = OrdersHandler.ManageData(pathToGetOrders);

            //company, product name
            List<(string, string)> doneOrders = new();

            foreach (var order in orders)
            {
                var product = storage.GetProductByName(order.Key);

                if (product != null)
                {
                    int totalAmountOFProductInOrder = order.Value.Sum(x => x.Item2);
                    if (storage[product] >= totalAmountOFProductInOrder)
                    {
                        doneOrders.AddRange(SuccessfullCompleteFullOrder(storage, order, product, totalAmountOFProductInOrder));
                        storage[product] = totalAmountOFProductInOrder - storage[product];
                        continue;
                    }
                    else
                    { 
                        int currentAmountOfProduct = storage[product];
                        foreach (var company in order.Value)
                        {
                            if (currentAmountOfProduct < company.Item2)
                            {
                                var replacingProducts = ReplacingManager.GetListOfReplaceable(order.Key);
                                if (replacingProducts == null)
                                {
                                    writeFailedOrder(SingleFailedOrderString(company.Item1, order.Key, company.Item2), PathToWriteFailedOrder);
                                    continue;
                                }

                                replacingProducts.Remove(order.Key);

                                foreach (var adjProduct in replacingProducts)
                                {
                                    Product adjustedProduct = storage.GetProductByName(adjProduct);
                                    if (adjustedProduct == null) { continue; }

                                    int amountOfAdjustedProduct = currentAmountOfProduct + storage[adjustedProduct];

                                    if (amountOfAdjustedProduct >= company.Item2)
                                    {
                                        doneOrders.Add((adjProduct, company.Item1));
                                        storage[product] = 0;
                                        storage[adjustedProduct] = amountOfAdjustedProduct - company.Item2;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                currentAmountOfProduct -= company.Item2;
                                doneOrders.Add((order.Key, company.Item1));
                            }
                        }
                        storage[product] = currentAmountOfProduct;
                    }
                }
                else
                {
                    writeFailedOrder(FullFailedOrderString(order), PathToWriteFailedOrder);
                }
            }

            return doneOrders;
        }

        public static List<(string, string)> SuccessfullCompleteFullOrder(Storage storage, KeyValuePair<string, List<(string, int)>> orderList, Product product, int totalAmountOFProductInOrder)
        {
            List<(string, string)> doneOrders = new();

            storage[product] -= totalAmountOFProductInOrder;
            foreach (var company in orderList.Value)
            {
                doneOrders.Add((orderList.Key, company.Item1));
            }

            return doneOrders;
        }

        public static string FullFailedOrderString(KeyValuePair<string, List<(string, int)>> orderList)
        {
            StringBuilder str = new();
            foreach (var item in orderList.Value)
            {
                str.AppendLine($"{item.Item1}, {orderList.Key}, {item.Item2}");
            }
            return str.ToString();
        }

        public static string SingleFailedOrderString(string company, string productName, int amount)
        {
            string str = $"{company}, {productName}, {amount}";
            return str;
        }
    }
}
