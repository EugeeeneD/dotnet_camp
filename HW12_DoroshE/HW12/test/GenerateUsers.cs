using HW12.src.model;
using HW12.src.model.tickets;
using HW12.src.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.test
{
    public static class GenerateUsers
    {
        public static int id = 0;
        public static void GenerateUsersForRoomPerTick(CaseRoom cr, int time)
        {
            Random r = new Random();

            // 0-6 users can be spawned once
            int userAmount = r.Next(6, 7);

            for (int i = 0; i < userAmount; i++)
            {
                int randomX = r.Next(cr.topLeftRoom.Item1, cr.bottromRightRoom.Item1);
                int randomY = r.Next(cr.topLeftRoom.Item1, cr.bottromRightRoom.Item1);
                int randomAge = r.Next(0, 100);
                bool randomStatus = r.Next(0, 2) > 0;

                int amountOfTickets = r.Next(0, 4);
                List<ITicket> tickets = new();

                for (int k = 0; k < amountOfTickets; k++)
                {
                    int ticket = r.Next(0, 3);
                    if (ticket == 0) { tickets.Add(new TicketA()); }
                    else if (ticket == 1) { tickets.Add(new TicketB()); }
                    else { tickets.Add(new TicketC()); }
                }

                try
                {
                    cr.SpawnUser(randomX, randomY, "User" + id, randomAge, randomStatus, tickets);
                    id++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("User wasnt spawned, coordinates out of range.");
                    id++;
                }
            }
        }
    }
}
