using HW1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HW1.Product;
using static HW3_DoroshE.Meat;

namespace HW3_DoroshE
{
    public class Storage
    {
        // Продукт та к-сть на складі
        private Dictionary<Product, int> _storage;

        public Dictionary<Product, int> StorageCopy
        { 
            get
            {
                Dictionary<Product, int> storageCopy = _storage.ToDictionary(x => x.Key, x => x.Value);
                return storageCopy;
            }
        }

        public int this[Product product]
        {
            get
            {
                return _storage[FindItem(product)];
            }

            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Count cannot be negative."); }
                _storage[product] = value;
            }
        }

        public Storage()
        {
            _storage = new Dictionary<Product, int>();
        }

        public Storage(Dictionary<Product, int> storage)
        {
            if (storage == null) { throw new ArgumentNullException("Cannot accept null as a storage."); }
            _storage = storage;
        }

        public void AddNewProductToStorage(Product product, int count)
        {
            if (IsOnStorage(product)) { throw new ArgumentException("product already in basket."); }

            var copy = product.DeepCopy();
            copy.ConvertPrice();

            _storage.Add(copy, count);
        }

        public bool DeleteProductFromStorage(Product product)
        {
            return _storage.Remove(FindItem(product));
        }

        public bool ChangeCountOfProduct(Product product, int count)
        {
            if (!IsOnStorage(product)) { return false; }

            _storage[FindItem(product)] += count;
            return true;
        }

        public bool ChangePriceAllOfTheProducts(double percent)
        {
            if (percent < -100) { throw new ArgumentOutOfRangeException("Percentage cannot be lower than -100."); }

            foreach (var item in _storage.Keys)
            {
                dynamic obj = item;
                obj.ChangePrice(percent);
                item.Price = obj.Price;
            }

            return true;
        }

        public Product FindItem(Product product)
        {
            if (!IsOnStorage(product)) { throw new ArgumentException("No such product in basket."); }

            foreach (var item in _storage.Keys)
            {
                if (item.Name == product.Name) { return item; }
            }
            return null;
        }

        public List<Meat> FindMeatProducts()
        {
            List<Meat> res = new List<Meat>();

            foreach (var item in _storage.Keys)
            {
                if (item.GetType() == typeof(Meat)) { res.Add((Meat)item); }
            }
            return res;
        }

        public bool IsOnStorage(Product product)
        {
            foreach (var item in _storage.Keys)
            {
                if (item.Name == product.Name) { return true; }
            }
            return false;
        }
// метод тут лишній. Прив'язка до консолі!!!!
        public void PrintAllInfo()
        {
            foreach (var item in _storage)
            {
                dynamic obj = item;
                Console.WriteLine($"{obj.Key}");
            }
        }

        public override string ToString()
        {
            string res = "Storage:\n";

            foreach (var item in _storage)
            {
                res += "------------\n";
                res += $"{item.Key.Name} - {item.Key.Price} {item.Key.Currency} x {item.Value}\n";
            }
            return res;
        }

        public bool GetProductsFromUser()
        {
            Dictionary<Product, int> input = new Dictionary<Product, int>();
            bool exit = true;

            while (true)
            {
                Console.WriteLine($"Enter if you want to:\n1.Product\n2.Meat\n3.Dairy Product\n4.Clear inputed products\n5.Exit");
                var variant = Console.ReadLine();

                switch (variant)
                {
                    case "1":
                        Product product = CreatingProduct();
                        int.TryParse(Console.ReadLine(), out int amount);

                        if(!IsProductInputedCorrect(product)) { break; }

                        input.Add(product, amount);
                        break;

                    case "2":
                        Product meatProduct = CreatingProduct();
                        int.TryParse(Console.ReadLine(), out int meatAmount);

                        var meat = CreatingMeat(meatProduct);

                        if (!IsProductInputedCorrect(meat)) { break; }

                        input.Add(meat, meatAmount);
                        break;

                    case "3":
                        Product dairyProduct = CreatingProduct();
                        int.TryParse(Console.ReadLine(), out int dairyProductAmount);

                        var dairy = CreatingDairyProduct(dairyProduct);

                        if (!IsProductInputedCorrect(dairyProduct)) { break; }

                        input.Add(dairy, dairyProductAmount);
                        break;

                    case "4":
                        input.Clear();
                        break;

                    case "5":
                        exit = false;
                        break;

                    default:
                        continue;
                }
                if(!exit) { break; }
            }
            foreach (var item in input)
            {
                _storage.Add(item.Key, item.Value); 
            }
            return true;
        }
// Не властивий метод
        public Product CreatingProduct()
        {
            string name;
            Currencies currency;
            WeightUnits weightUnit;

            Console.WriteLine(("Enter name of a product:\n"));
            name = Console.ReadLine();

            Console.WriteLine(("Enter price of a product:\n"));
            double.TryParse(Console.ReadLine(), out double price);

            Console.WriteLine(("Enter currency:\n1.UAH\n2.USD\n3.EUR\n"));
            switch (Console.ReadLine())
            {
                case "1":
                    currency = Currencies.UAH;
                    break;
                case "2":
                    currency = Currencies.USD;
                    break;
                case "3":
                    currency = Currencies.EUR;
                    break;
                default:
                    currency = Currencies.UAH;
                    break;
            }

            Console.WriteLine(("Enter weight:"));
            double.TryParse(Console.ReadLine(), out double weight);

            Console.WriteLine(("Enter weight units:\n1.Gramms\n2.Kilogramms\n3.Litters\n"));
            switch (Console.ReadLine())
            {
                case "1":
                    weightUnit = WeightUnits.GRAMM;
                    break;
                case "2":
                    weightUnit = WeightUnits.KILOGRAMM;
                    break;
                case "3":
                    weightUnit = WeightUnits.LITTERS;
                    break;
                default:
                    weightUnit = WeightUnits.KILOGRAMM;
                    break;
            }

            return new Product(name, weightUnit, weight, currency, price);
        }

        public Meat CreatingMeat(Product product)
        {
            Console.WriteLine($"Meat category: Highest. Enter y/n.\n");
            string answer = Console.ReadLine();

            Categories category;

            if (answer == "y") { category = Categories.HIGHEST; }
            else { category = Categories.HIGHEST; }

            Console.WriteLine($"Type of meat:\n1.Lamb\n2.Veal\n3.Pork\nPress Enter if its Chicken");
            var variant = Console.ReadLine();
            MeatTypes meatType;

            switch (variant)
            {
                case "1":
                    meatType = MeatTypes.LAMB;
                    break;

                case "2":
                    meatType = MeatTypes.VEAL;
                    break;

                case "3":
                    meatType = MeatTypes.PORK;
                    break;

                default:
                    meatType = MeatTypes.CHICKEN;
                    break;
            }

            var meat = new Meat(product, category, meatType);
            Console.WriteLine(meat);
            return meat;
        }

        public Dairy_products CreatingDairyProduct(Product product)
        {
            Console.WriteLine("ExpidationDate in days:\n");
            int.TryParse(Console.ReadLine(), out int expirationDate);

            return new Dairy_products(product, expirationDate);
        }

        public bool IsProductInputedCorrect(Product product)
        {
            dynamic obj = product;
            Console.WriteLine(obj.ToString());

            Console.WriteLine("Is product info correct: y\\n\n");
            if (Console.ReadLine().ToLower() == "y") { return true; }

            return false;
        }

        public Storage SortBy(Func<KeyValuePair<Product, int>, double> func)
        {
            Dictionary<Product, int> sortedStorage = StorageCopy.OrderBy(func).ToDictionary(x => x.Key, x => x.Value);

            return new Storage(sortedStorage);
        }

        public Storage SortByName()
        {
            Dictionary<Product, int> sortedStorage = StorageCopy.OrderBy(x => x.Key.Name).ToDictionary(x => x.Key, x => x.Value);

            return new Storage(sortedStorage);
        }
    }
}
