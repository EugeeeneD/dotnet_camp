using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.model.tickets
{
    public class TicketA : ITicket
    {
        public int time = 3;

        public int GetTime()
        {
            return time;
        }
    }
}
