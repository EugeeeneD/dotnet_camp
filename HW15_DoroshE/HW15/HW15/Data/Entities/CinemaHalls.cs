using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Data.Entities
{
    public class CinemaHalls
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public ICollection<Hall> Halls { get; set; }
    }
}
