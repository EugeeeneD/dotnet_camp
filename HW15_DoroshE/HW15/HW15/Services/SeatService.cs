using HW15.Data.Entities;
using HW15.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HW15.Services
{
    public class SeatService : ContextBase
    {
        public SeatService()
        {
            _context = new CinemaDBContext();
        }

        public SeatService(CinemaDBContext context) : base(context)
        {
        }

        public IQueryable<Seat> FindAll()
        {
            return base.FindAll<Seat>();
        }

        public IQueryable<Seat> FindWhere(Expression<Func<Seat, bool>> expression)
        {
            return base.FindWhere<Seat>(expression);
        }

        public void Add(Seat seat)
        {
            base.Add<Seat>(seat);
        }

        public void Update(Seat seat)
        {
            base.Update<Seat>(seat);
        }

        public void Delete(Seat seat)
        {
            base.Delete<Seat>(seat);
        }

        public IQueryable<Seat> GetFreeSeatsForShowtime(Showtime showtime)
        {
            var reserved = _context.Tickets.Include(x => x.Showtime).Where(x => x.Showtime == showtime).Select(x => x.Seat);

            Hall hall = _context.Halls.FirstOrDefault(x => x.Id == reserved.FirstOrDefault().HallGuid);

            var allSeats = _context.Seats.Join(_context.Halls
                .Where(x => x == hall), x => x.HallGuid, x => x.Id, (seat, hall) => seat );

            return allSeats.Where(x => !reserved.ToList().Contains(x)).AsNoTracking();
        }
    }
}
