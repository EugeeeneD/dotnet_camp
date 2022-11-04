using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Product : IProduct, IComparable, IComparer<Product>
    {
        public enum WeightUnits
        {
            GRAMM,
            KILOGRAMM,
            LITTERS
        }

        public enum Currencies
        {
            USD,
            UAH,
            EUR
        }

        private string _name;
        private double _weight;
        private WeightUnits _weightUnit;
        private double _price;
        private Currencies _currency;

        private readonly Dictionary<Currencies, double> exchangeRate = new Dictionary<Currencies, double>()
        {
            [Currencies.UAH] = 1,
            [Currencies.USD] = 36.9,
            [Currencies.EUR] = 36.56
        };

        public Product()
        {
        }

        public Product(Product product)
        {
            Name = product.Name;
            Weight = product.Weight;
            WeightUnit = product.WeightUnit;
            Price = product.Price;
            Currency = product.Currency;
        }

        public Product(string name, WeightUnits weightunit, double weight, Currencies currency, double price)
        {
            Name = name;
            Weight = weight;
            WeightUnit = weightunit;
            Price = price;
            Currency = currency;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null) { _name = value; }

                else { throw new ArgumentNullException("Name cannot be null."); }
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value < 0) { throw new ArgumentException("Weight cannot be negative."); }

                _weight = value;
            }
        }

        public WeightUnits WeightUnit
        {
            get
            {
                return _weightUnit;
            }
            set
            {
                _weightUnit = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0) { throw new ArgumentException("Price cannot be negative."); }
                _price = value;
            }
        }

        public Currencies Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
            }
        }

        public void ConvertPrice()
        {
            Price = Price * exchangeRate[Currency];
            Currency = Currencies.UAH;
        }

        public bool ChangePrice(double percent)
        {
            if (percent < -100) { throw new ArgumentOutOfRangeException("Percentage cannot be lower -100."); }
            Price *= 1 + (percent / 100);
            return true;
        }

        public override string ToString()
        {
            return $"Name: {Name}, weight: {Weight} {WeightUnit}, price: {Price} {Currency}";
        }

        public Product DeepCopy()
        {
            Product copy = new Product(this);
            return copy;
        }

        public override bool Equals(object? obj)
        {
            return obj.GetHashCode() == this.ToString().GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) { return 1; }

            Product otherProduct = obj as Product;
            if (otherProduct != null)
            {
                var otherCopy = otherProduct.DeepCopy();
                otherCopy.ConvertPrice();
                otherProduct.ConvertPrice();

                var thisCopy = this.DeepCopy();
                thisCopy.ConvertPrice();

                return thisCopy.Price.CompareTo(otherCopy.Price);
            }
            else
                throw new ArgumentException("Object is not a product.");
        }

        public int Compare(Product? x, Product? y)
        {
            Product xCopy = x.DeepCopy();
            xCopy.ConvertPrice();

            Product yCopy = y.DeepCopy();
            yCopy.ConvertPrice();

            if (xCopy.Price == yCopy.Price) { return 0; }
            if (xCopy.Price > yCopy.Price) { return 1; }
            return -1;
        }
    }
}
