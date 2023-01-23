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

        public void Add(Seat movie)
        {
            base.Add<Seat>(movie);
        }

        public void Update(Seat movie)
        {
            base.Update<Seat>(movie);
        }

        public void Delete(Seat movie)
        {
            base.Delete<Seat>(movie);
        }

        public IQueryable<Seat> GetFreeSeatsForShowtime(Showtime showtime)
        {
            var reserved = _context.Tickets.Where(x => x.Showtime == showtime).Select(x => x.Seat);
            Hall hall = reserved.First().Hall;
            var allSeats = _context.Seats.Join(_context.Halls
                .Where(x => x == hall), x => x.HallGuid, x => x.Id, (seat, hall) => new
                {
                    // шо буде в результат джоіну
                    Seat = seat,
                    Hall = hall
                });


        }
    }
}
