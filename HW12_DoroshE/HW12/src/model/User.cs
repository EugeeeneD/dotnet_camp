using HW12.src.model.tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.model
{
    public class User
    {
        private double _x;
        private double _y;
        private string _name;
        private int _age;
        public List<ITicket> tickets;

        //true - urgent or vip, just more important
        private bool _status;

        public User(double x, double y, string name, int age, bool status, List<ITicket> ticketsToBuy)
        {
            X = x;
            Y = y;
            _name = name;
            Age = age;
            _status = status;
            tickets = ticketsToBuy;
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("x out of room;"); }
                _x = value;
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("y out of room;"); }
                _y = value;
            }
        }
        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("y out of room;"); }
                _age = value;
            }
        }

        //task5 TODO
        public void ChangeCase(Case from, Case To)
        {

        }

        public int GetTimeToBuyAllTickets()
        {
            return tickets.Sum(x => x.GetTime());
        }

        public Case GetCaseWithMinDistanceInbetween(List<Case> cases)
        {
            return cases.MinBy(sCase =>
                                        Math.Sqrt((Math.Pow(sCase.Center.Item1 - X, 2) + (Math.Pow(sCase.Center.Item2 - Y, 2)))))?? throw new ArgumentException("No cases.");
        }

        public override string ToString()
        {
            return $"({_x}, {_y}) {_name} - {_age} - {_status}; Time to get tickets: {GetTimeToBuyAllTickets()}";
        }

        public User DeepCopy()
        {
            User userCopy = new User(X, Y, _name, _age, _status, tickets);
            return userCopy;
        }
    }
}
