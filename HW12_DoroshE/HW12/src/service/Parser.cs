using HW12.src.model;
using HW12.src.model.tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.service
{
    public class Parser
    {
        public static List<User> ParseDataToUserList(string[] data)
        {
            List<User> res = new();

            foreach (var str in data)
            {
                string[] temp = str.Split(",", StringSplitOptions.RemoveEmptyEntries);

                int x = Convert.ToInt32(temp[0]);
                int y = Convert.ToInt32(temp[1]);
                string name = temp[2];
                int age = Convert.ToInt32(temp[3]);
                bool status = Convert.ToBoolean(Convert.ToInt32(temp[4]));

                string[] stringTickets = temp[5..];
                List<ITicket> tickets = new();
                for (int i = 0; i < stringTickets.Length; i++)
                {
                    if (stringTickets[i] == "0") { tickets.Add(new TicketA()); }
                    else if (stringTickets[i] == "1") { tickets.Add(new TicketB()); }
                    else if (stringTickets[i] == "2") { tickets.Add(new TicketC()); }
                }

                res.Add(new User(x, y, name, age, status, tickets));
            }

            return res;
        }
    }
}
