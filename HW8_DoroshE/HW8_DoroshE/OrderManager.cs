using HW1;
using HW3_DoroshE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_DoroshE
{
    public class OrderManager
    {
        //a
        public delegate void Notify(string str);
        public event Notify? FailedOrder;

        public List<(string, string)> FulfilOrders(Storage storage, string pathToGetOrders, string pathToReplacingProducts)
        {
            //product, (company, amount)
            Dictionary<string, List<(string, int)>> orders = OrdersHandler.ManageData(pathToGetOrders);

            //company, product name
            List<(string, string)> doneOrders = new();

            foreach (var order in orders)
            {
                var product = storage.GetProductByName(order.Key);

                if (product != null)
                {
                    //total amount of product from all orders
                    int totalAmountOFProductInOrder = order.Value.Sum(x => x.Item2);

                    //If product can solo fulfil all orders
                    if (storage[product] >= totalAmountOFProductInOrder)
                    {
                        doneOrders.AddRange(SuccessfullCompleteFullOrder(storage, order, product, totalAmountOFProductInOrder));
                        continue;
                    }
                    else
                    {
                        List<string>? replacingProducts = ReplacingManager.GetListOfReplaceable(order.Key, pathToReplacingProducts);
                        //If there are no replacing products
                        if (replacingProducts == null)
                        {
                            order.Value.ForEach(x => FailedOrder?.Invoke($"Failed order(No enough product and no replacing products): {order.Key} - {x.Item1} - {x.Item2};"));
                            continue;
                        }
                        replacingProducts.Remove(order.Key);

                        int currentAmountOfOriginProduct = storage[product];

                        //Going through the loop and checking if we can do single order without replacing products
                        foreach (var company in order.Value)
                        {
                            if (currentAmountOfOriginProduct >= company.Item2)
                            {
                                currentAmountOfOriginProduct -= company.Item2;
                                doneOrders.Add((order.Key, company.Item1));
                                continue;
                            }

                            //Going through the loop and checking if we can do single order with replacing products
                            if (ReplacingManager.ReplaceWithAdjustments(storage, company, product, replacingProducts, doneOrders, ref currentAmountOfOriginProduct) == false)
                            {
                                FailedOrder?.Invoke($"Failed order(No enough product and no enough replacing products): {order.Key} - {company.Item1} - {company.Item2};");
                            }
                        }
                        //f
                        storage[product] = currentAmountOfOriginProduct;
                    }
                }
                else
                {
                    order.Value.ForEach(x => FailedOrder?.Invoke($"Failed order(No such product): {order.Key} - {x.Item1} - {x.Item2};"));
                }
            }
            return doneOrders;
        }

        private List<(string, string)> SuccessfullCompleteFullOrder(Storage storage, KeyValuePair<string, 
                                            List<(string, int)>> orderList, Product product, int totalAmountOFProductInOrder)
        {
            List<(string, string)> doneOrders = new();

            storage[product] -= totalAmountOFProductInOrder;
            foreach (var company in orderList.Value)
            {
                doneOrders.Add((orderList.Key, company.Item1));
            }

            return doneOrders;
        }
    }
}
