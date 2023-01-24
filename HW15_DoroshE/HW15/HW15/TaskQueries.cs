using HW15.Data;
using HW15.Data.Entities;
using HW15.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW15
{
    public class TaskQueries
    {
        private CinemaDBContext _context;

        public TaskQueries()
        {
            _context = new CinemaDBContext();
        }

        public TaskQueries(CinemaDBContext context)
        {
            _context = context;
        }

        //TASK 1
        public IQueryable CurrentWeekShowtimes()
        {
            return _context.Showtimes.Where(x => x.DateTime > DateTime.Now && x.DateTime < DateTime.Now.AddDays(7)).Select(x => new()
            {
                Movie = x.Movie.Name,
                DateTime = x.DateTime
            });
        }

        //TASK 2
        public IQueryable<Seat> AvaiblabeSeatsForShow(Showtime showtime)
        {
            SeatService seats = new();
            return seats.GetFreeSeatsForShowtime(showtime);
        }

        //TASK 3
        public IQueryable<Seat> NeverBooked()
        {
            var reserved = _context.Tickets.Select(x => x.Seat);

            var allSeats = _context.Seats.Join(_context.Halls, x => x.HallGuid, x => x.Id, (seat, hall) => seat);

            return allSeats.Where(x => !reserved.ToList().Contains(x)).AsNoTracking();
        }

        //TASK 4
        public Dictionary<Movie, decimal> EarnedByMovie()
        {
/*            var movieSum = _context.Showtimes.Join(_context.Tickets, x => x.Id, x => x.ShowtimeGuid,
                (showtime, ticket) => new
                {
                    sum = ticket.TotalSum,
                    movie = showtime.Movie
                });

            var res = movieSum.GroupBy(x => x.movie).ToDictionary(x => x.Key, x => x.Sum(x => x.sum));*/

            var res = _context.Showtimes.GroupBy(x => x.Movie).ToDictionary(x => x.Key, x => x.Sum(x => x.Tickets.Sum(x => x.TotalSum)));

            res.OrderByDescending(x => x.Value);

            return res;
        }

        //TASK 5
        public Dictionary<User, decimal> Top3Users(DateTime start, DateTime end)
        {
            var ticketsWithinBounderies = _context.Tickets.Where(x => x.Showtime.DateTime >= start && x.Showtime.DateTime <= end);
            return ticketsWithinBounderies.GroupBy(x => x.User).ToDictionary(x => x.Key, x => x.Sum(x => x.TotalSum));
        }

        //TASK 6
        // через 2 змінні і групбай
    }
}
