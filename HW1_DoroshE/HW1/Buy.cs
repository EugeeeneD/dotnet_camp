using static HW1.Product;

namespace HW1
{
    public class Buy
    {
        private Product _product;
        private int _count;

        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                if (value == null) { throw new ArgumentNullException("Cannot accept null as a product."); }
                _product = value.DeepCopy();
            }
        }

        public int Count
        {
            get 
            {
                return _count;
            }
            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Count cannot be negative."); }
                _count = value;
            }
        }

        public Buy()
        {
        }

        public Buy(Product product, int count)
        {
            Product = product.DeepCopy();
            Count = count;
        }

        public Buy(Buy buy)
        {
            Product = buy.Product.DeepCopy();
            Count = buy.Count;
        }

        public double BuySum()
        {
            return Product.Price * Count;
        }

        public Buy DeepCopy()
        {
            Buy copy = new Buy(this.Product.DeepCopy(), this.Count);
            return copy;
        }

        public override string ToString()
        {
            return $"Product: {Product}, count: {Count}\n";
        }
    }
}
