using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.models
{
    public class DateIndicator
    {
        public DateOnly Date { get; set; }
        public double Indicator { get; set; }

        public bool Equals(DateIndicator obj)
        {
            return Date.Equals(obj.Date) && Indicator.Equals(obj.Indicator);
        }
    }
}
