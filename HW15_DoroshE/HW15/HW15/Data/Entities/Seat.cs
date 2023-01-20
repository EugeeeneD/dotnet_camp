using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Data.Entities
{
    public class Seat
    {
        public Guid Id { get; set; }
        public virtual Hall Hall { get; set; }
        public decimal SeatPriceCoef { get; set; }
        public int SeatNumber { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
