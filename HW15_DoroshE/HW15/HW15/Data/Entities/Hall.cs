using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Data.Entities
{
    public class Hall
    {
        public Guid Id { get; set; }
        public CinemaHalls CinemaHall { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
