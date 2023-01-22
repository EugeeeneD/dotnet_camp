using HW15.Data.Entities;
using HW15.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    internal class TicketService : ContextBase
    {
        public TicketService()
        {
            _context = new CinemaDBContext();
        }

        public TicketService(CinemaDBContext context) : base(context)
        {
        }

        public IQueryable<Ticket> FindAll()
        {
            return base.FindAll<Ticket>();
        }

        public IQueryable<Ticket> FindWhere(Expression<Func<Ticket, bool>> expression)
        {
            return base.FindWhere<Ticket>(expression);
        }

        public void Add(Ticket ticket)
        {
            base.Add<Ticket>(ticket);
        }

        public void Update(Ticket ticket)
        {
            base.Update<Ticket>(ticket);
        }

        public void Delete(Ticket ticket)
        {
            base.Delete<Ticket>(ticket);
        }
    }
}
