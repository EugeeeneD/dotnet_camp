using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Data.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Seat Seat { get; set; }
        public Showtime Showtime { get; set; }
        public decimal TotalSum { get; set; }
    }
}
