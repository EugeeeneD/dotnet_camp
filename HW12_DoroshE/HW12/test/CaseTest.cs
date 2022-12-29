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
    public class CaseTest
    {
        public static void CaseTestConsole()
        {
            //testing each method
            Console.WriteLine("\n------------ Cases test ------------\n Checking if sorting works right:\n");
            List<User> users = new List<User>();
            Case cs = new Case(1, (8, 12), (12, 0), 6);

            cs.AddUser(new User(2, 1, "1", 55, true, new List<ITicket>()));
            cs.AddUser(new User(5, 2, "1", 49, false, new List<ITicket>()));
            cs.AddUser(new User(4, 3, "1", 50, false, new List<ITicket>()));
            cs.AddUser(new User(2, 4, "1", 50, true, new List<ITicket>()));

            users.Add(new User(6, 2, "1", 49, false, new List<ITicket>()));
            users.Add(new User(3, 4, "1", 50, true, new List<ITicket>()));
            users.Add(new User(7, 3, "1", 45, false, new List<ITicket>()));

            cs.AddUsers(users);
            cs.SortQueue();

            //before removing
            Console.WriteLine("before removing:");
            foreach (var item in cs.Users)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nQueue first out: {cs.Users.Peek()}");
            //after
            Console.WriteLine("\nafter removing:");
            cs.RemoveUser();
            foreach (var item in cs.Users)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n------------ Room test ------------\n");
            users.Clear();
            CaseRoom room = new CaseRoom(3, 4, (0, 15), (15, 0));

            List<ITicket> list0 = new();
            List<ITicket> list1 = new() { new TicketA(), new TicketB() }; //8
            List<ITicket> list2 = new() { new TicketB(), new TicketC() }; //12
            List<ITicket> list3 = new() { new TicketB()}; //5

            room.cases[0].AddUser(new User(1, 1, "1", 55, true, list3));
            room.cases[0].AddUser(new User(5, 1, "2", 49, false, list1));
            room.cases[0].AddUser(new User(4, 1, "3", 50, false, list3));

            room.cases[1].AddUser(new User(2, 1, "4", 50, true, list1));
            room.cases[1].AddUser(new User(6, 1, "5", 49, false, list0));

            room.cases[2].AddUser(new User(6, 1, "6", 49, false, list2));
            room.cases[2].AddUser(new User(3, 1, "7", 50, true, list3));

            //user spawns outside the room

            List<ITicket> ticketsList = new();
            try
            {
                room.SpawnUser(253, 1, "oops", 1, true, ticketsList);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ArgumentOutOfRangeException was catched, user wont added.");
            }
            //user spawns in case
            try
            {
                room.SpawnUser(13, 1, "oops", 1, true, ticketsList);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ArgumentOutOfRangeException was catched, user wont added.\n");
            }

            Console.WriteLine(room);

            Console.WriteLine(room.GetUserAmountInRoom());

            Console.WriteLine("----------- Min distance to case -----------\n");
            User newUser1 = new User(3, 7, "1", 50, true, new List<ITicket>());
            var closestCases = newUser1.GetCaseWithMinDistanceInbetween(room.cases);
            Console.WriteLine(closestCases);

            Console.WriteLine("------------ ControlPassengersGroup -------------\n");
            ControlPassengersGroup.WriteControlPassengersGroupToFile(room, 1, Environment.CurrentDirectory + "\\ControlGroup.txt");
            Console.WriteLine("Done.\n");

            Console.WriteLine("------------ Serving test -------------\n");

            for (int i = 0; i < 15; i++)
            {
                foreach (var queue in room.cases)
                {
                    queue.UserServing(room, i);
                }
            }
            Console.WriteLine("\nServed people:");
            foreach (var item in room.servedUsers)
            {
                Console.WriteLine(item);
            }

            room.SaveServedUsers(Environment.CurrentDirectory + "\\ServedUsers.txt");
        }
    }
}
