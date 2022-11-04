using static HW1.Buy;

namespace HW1
{
    internal class Program
    {//yes
        static void Main(string[] args)
        {
            // Product part
            Console.WriteLine("Product part:");

            Product newProduct = new Product("Tomatos", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 55);
            Console.WriteLine(newProduct);

            Product newProduct1 = newProduct.DeepCopy();
            newProduct1.Name = "Banana";
            Console.WriteLine(newProduct1);

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\nBuy part:");

            Buy newBuy = new Buy(newProduct, 2);
            Buy newBuy1 = new Buy(new Product("Melon", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 34), 5);

            Console.WriteLine($"{newBuy}, sum: {newBuy.BuySum()}");
            Console.WriteLine($"{newBuy1}, sum: {newBuy1.BuySum()}");

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\nBasket part:\n");

            Basket basket = new Basket(newBuy, newBuy1);

            Console.WriteLine($"New Basket:\n{basket}");

            Buy newBuy2 = new Buy(newBuy1);

            newBuy2.Product.Name = "Gum";
            newBuy2.Product.Price = 8;
            newBuy2.Count = 10;

            basket.AddNewProductToBasket(newBuy2);

            Product sparkWater = new Product("Spark water", Product.WeightUnits.LITTERS, 1, Product.Currencies.UAH, 31);
            basket.AddNewProductToBasket(sparkWater, 2);

            Console.WriteLine($"After adding new item:\n{basket}");

            // if product not in basket
            /*basket.DeleteProductFromBasket(newProduct1);
            Console.WriteLine($"After deleting an item:\n{basket}");*/

            basket.DeleteProductFromBasket(newBuy2);
            Console.WriteLine($"After deleting an item:\n{basket}");

            Console.WriteLine(basket.ChangeCountOfProduct(newBuy1.Product, -2));
            basket.FindItem(sparkWater).ChangePrice(25);
            Console.WriteLine($"After changing count of item and using discount:\n{basket}");

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\nCheck part:\n");

            Check check = new Check();
            check.CheckOut(basket);

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\nHW5 part:\n");

            Product hw5Product_1 = new Product(name: "Buryak", price: 1.22, currency: Product.Currencies.USD, weight: 1, weightunit: Product.WeightUnits.KILOGRAMM);
            Product hw5Product_2 = new Product(name: "Schparagus", price: 75, currency: Product.Currencies.UAH, weight: 1, weightunit: Product.WeightUnits.KILOGRAMM);
            Product hw5Product_3 = new Product(name: "Potato", price: 150, currency: Product.Currencies.UAH, weight: 10, weightunit: Product.WeightUnits.KILOGRAMM);

            Console.WriteLine(hw5Product_1.CompareTo(hw5Product_2));
        }
    }
}
