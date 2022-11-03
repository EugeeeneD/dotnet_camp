using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Check : Buy
    {
        public Check()
        {
        }

        public void CheckOut(Basket basket)
        {
            if (basket == null) { throw new ArgumentNullException("Cannot accept null."); }

            Console.WriteLine("Basket:");
            
            Console.WriteLine(basket);

            Console.WriteLine("------------");

            Console.WriteLine($"Basket summa equals: {basket.SumOfBasket()} UAH.");
            
        }
    }
}
