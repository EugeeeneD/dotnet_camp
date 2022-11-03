using HW1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_DoroshE
{
    public class Dairy_products : Product
    {
        private int _expirationDate;

        public Dairy_products()
        {
        }

        public Dairy_products(Product product, int days) : base(product)
        {
            ExpirationDate = days;
        }

        public bool ChangePrice(double percent)
        {
            if (base.ChangePrice(percent))
            {
                Price *= 1 + (percent / 100);
                if (ExpirationDate > 10 && ExpirationDate <= 20) { Price *= 0.85; }
                if (ExpirationDate < 10) { Price *= 0.5; }
                return true;
            }
            return false;
        }

        public int ExpirationDate 
        {
            get => _expirationDate;
            set
            {
                _expirationDate = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, expiration date in days - {ExpirationDate}";
        }
    }
}
