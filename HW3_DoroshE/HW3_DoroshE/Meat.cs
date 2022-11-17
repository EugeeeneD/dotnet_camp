using HW1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_DoroshE
{
    public class Meat : Product
    {
        public enum Categories
        {
            HIGHEST,
            SECOND
        }

        public enum MeatTypes
        {
            LAMB,
            VEAL,
            PORK,
            CHICKEN
        }

        private Categories _category;
        private MeatTypes _meatType;

        public Meat()//: base()
        {
        }
// не правильне відчуття виклику базового класу. Поясню усно.
        public Meat(Product product, Categories category, MeatTypes meatType) : base(product)
        {
            Category = category;
            MeatType = meatType;
        }

        public Categories Category
        {
            get => _category;

            set
            {
                if (value.GetType() != typeof(Categories)) { throw new ArgumentException(); }
                _category = value;
            }
        }

        public MeatTypes MeatType
        {
            get => _meatType;

            set
            {
                if (value.GetType() != typeof(MeatTypes)) { throw new ArgumentException(); }
                _meatType = value;
            }
        }

        public bool ChangePrice(double percent)
        {
            if (base.ChangePrice(percent))
            {
                if (Category == Categories.HIGHEST) { Price *= 1 + (percent / 100) * 1.55; }
                else { { Price *= 1 + (percent / 100) * 1.15; } }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, category: {Category}, meat type: {MeatType}";
        }
    }
}
