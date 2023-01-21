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

        public Guid UserGuid { get; set; }
        public User User { get; set; }

        public Guid SeatGuid { get; set; }
        public Seat Seat { get; set; }

        public Guid ShowtimeGuid { get; set; }
        public Showtime Showtime { get; set; }

        public decimal TotalSum { get; set; }
    }
}
