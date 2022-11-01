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

            newProduct.Name = "Banana";

            Product newProduct1 = new Product(newProduct);
            Console.WriteLine(newProduct1);

            //---------------------------------------------------------
            // Buy part

            Console.WriteLine("\nBuy part:");
            Buy newBuy = new Buy( newProduct, 2 );
            Buy newBuy1 = new Buy(new Product("Melon", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 34), 5);

            Console.WriteLine($"{newBuy}, sum: {newBuy.BuySum()}");
            Console.WriteLine($"{newBuy1}, sum: {newBuy1.BuySum()}");

            //---------------------------------------------------------
            // Check part
            Console.WriteLine("\nCheck part:");
            Check newCheck = new Check();

            newCheck.CheckOut(newBuy);
        }
    }
}
