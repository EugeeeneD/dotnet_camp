using HW1;
using HW3_DoroshE;
using HW8_DoroshE;

Product sweets = new Product("Sweets", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 75);
Product candys = new Product("Candys", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 23);
Product pepsi = new Product("Pepsi", Product.WeightUnits.LITTERS, 1, Product.Currencies.UAH, 23);
Product mirinda = new Product("Mirinda", Product.WeightUnits.LITTERS, 1, Product.Currencies.UAH, 20.5);
Product bananas = new Product("Bananas", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 30);
Product apples = new Product("Apples", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 21);

Meat chicken = new Meat(new Product("Chicken", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 105)
    , Meat.Categories.SECOND, Meat.MeatTypes.CHICKEN);
Meat pork = new Meat(new Product("Pork", Product.WeightUnits.KILOGRAMM, 1, Product.Currencies.UAH, 284)
    , Meat.Categories.HIGHEST, Meat.MeatTypes.PORK);

Dairy_products milk = new Dairy_products(new Product("Milk", Product.WeightUnits.LITTERS, 0.5, Product.Currencies.UAH, 23), 13);

Storage storage = new Storage();

Product[] products = { sweets, candys , pepsi , mirinda , bananas , apples , chicken , pork , milk };

//can fulfil solo
storage.AddNewProductToStorage(sweets, 100);

//cannot be done
storage.AddNewProductToStorage(pepsi, 6);
storage.AddNewProductToStorage(mirinda, 6);

//can be fulfiled with replacing product
storage.AddNewProductToStorage(bananas, 10);
storage.AddNewProductToStorage(apples, 190);

storage.AddNewProductToStorage(candys, 6);
storage.AddNewProductToStorage(chicken, 6);
storage.AddNewProductToStorage(pork, 6);
storage.AddNewProductToStorage(milk, 6);

OrderManager bigOrder = new OrderManager();

Subscribers.pathToWriteFailedOrder = "F:\\sigma_dotnet_camp\\HW8_DoroshE\\HW8_DoroshE\\Data\\result.txt";
bigOrder.FailedOrder += Subscribers.WriteFailedOrder;

Console.WriteLine(storage);

var res = bigOrder.FulfilOrders(storage, "F:\\sigma_dotnet_camp\\HW8_DoroshE\\HW8_DoroshE\\Data\\orders.txt"
                                            , "F:\\sigma_dotnet_camp\\HW8_DoroshE\\HW8_DoroshE\\Data\\adjacentProducts.txt");

Console.WriteLine(storage);

Console.WriteLine("Successful orders:\n");
foreach (var item in res)
{
    Console.WriteLine(item.Item2 + " " + item.Item1);
}

