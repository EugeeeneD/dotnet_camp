using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Basket
    {
        private Dictionary<Product, int> _basket = new Dictionary<Product, int>();

        public Basket()
        {
        }

        public Basket(params Buy[] buy)
        {
            if (buy == null) { throw new ArgumentNullException("Cannot accept null."); }

            foreach (var item in buy)
            {
                var copy = item.Product.DeepCopy();
                copy.ConvertPrice();

                _basket.Add(copy, item.Count);
            }
        }
        public Basket(Dictionary<Product, int> basket)
        {
            if (basket == null) { throw new ArgumentNullException("Cannot accept null."); }

            foreach (var item in basket)
            {
                var copy = item.Key.DeepCopy();
                copy.ConvertPrice();

                _basket.Add(copy, item.Value);
            }
        }

        public int this [Product product]
        {
            get
            {
                return _basket[FindItem(product)];
            }

            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Count cannot be negative."); }

                _basket[product] = value;
            }
        }

        public int this[int index]
        {
            get
            {
                return _basket.ElementAt(index).Value;
            }

            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Count cannot be negative."); }
                else if (index < 0) { throw new ArgumentOutOfRangeException("Index cannot be negative."); }

                _basket[_basket.ElementAt(index).Key] = value;
            }
        }

        //-----------------------

        public void AddNewProductToBasket(Product product, int count)
        {
            if (IsInBasket(product)) { throw new ArgumentException("product already in basket."); }

            var copy = product.DeepCopy();
            copy.ConvertPrice();

            _basket.Add(copy, count);
        }

        public void AddNewProductToBasket(Buy buy)
        {
            if (IsInBasket(buy.Product)) { throw new ArgumentException("product already in basket."); }

            var copy = buy.Product.DeepCopy();
            copy.ConvertPrice();

            _basket.Add(copy, buy.Count);
        }

        //-----------------------

        public bool DeleteProductFromBasket(Product product)
        {
            return _basket.Remove(FindItem(product)); 
        }

        public bool DeleteProductFromBasket(Buy buy)
        {
            return _basket.Remove(FindItem(buy.Product));
        }

        //-----------------------

        public bool ChangeCountOfProduct(Product product, int count)
        {
            if (!IsInBasket(product)) { return false; }

            _basket[FindItem(product)] += count;
            return true;
        }

        public bool ChangeCountOfProduct(Buy buy)
        {
            if (!IsInBasket(buy.Product)) { return false; }

            _basket[FindItem(buy.Product)] += buy.Count;
            return true;
        }

        //-----------------------

        public bool IsInBasket(Product product)
        {
            foreach (var item in _basket.Keys)
            {
                if (item.Name == product.Name) { return true; }
            }
            return false;
        }

        public Product FindItem(Product product)
        {
            if (!IsInBasket(product)) { throw new ArgumentException("No such product in basket."); }

            foreach (var item in _basket.Keys)
            {
                if (item.Name == product.Name) { return item; }
            }
            return null;
        }

        public double SumOfBasket()
        {
            return _basket.Sum(item => item.Key.Price * item.Value);
        }

        public override string ToString()
        {
            string res = "";

            foreach (var item in _basket)
            {
                res += "------------\n";
                res += $"{item.Key.Name} - {item.Key.Price} {item.Key.Currency} x {item.Value}\n";
            }
            return res;
        }
    }
}
