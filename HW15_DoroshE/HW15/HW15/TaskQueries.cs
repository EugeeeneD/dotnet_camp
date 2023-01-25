using HW15.Data;
using HW15.Data.Entities;
using HW15.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IQueryable<Showtime> CurrentWeekShowtimes()
        {
            return _context.Showtimes.Include(x => x.Movie).Where(x => x.DateTime > DateTime.Now && x.DateTime < DateTime.Now.AddDays(7));
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
            var reserved = _context.Tickets.Include(x => x.Seat).Select(x => x.Seat);

            var allSeats = _context.Seats.Join(_context.Halls, x => x.HallGuid, x => x.Id, (seat, hall) => seat);

            return allSeats.Where(x => !reserved.ToList().Contains(x)).AsNoTracking();
        }

        //TASK 4
        public Dictionary<Guid, decimal> EarnedByMovie()
        {
/*            var movieSum = _context.Showtimes.Join(_context.Tickets, x => x.Id, x => x.ShowtimeGuid,
                (showtime, ticket) => new
                {
                    sum = ticket.TotalSum,
                    movie = showtime.Movie
                });

            var res = movieSum.GroupBy(x => x.movie).ToDictionary(x => x.Key, x => x.Sum(x => x.sum));*/

            var res = _context.Showtimes.Include(x => x.Tickets).ToList().GroupBy(x => x.MovieGuid)
                .ToDictionary(x => x.Key, x => x.Sum(x => x.Tickets.Sum(x => x.TotalSum)))
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            return res;
        }

        //TASK 5
        public Dictionary<User, decimal> Top3Users(DateTime start, DateTime end)
        {
            var ticketsWithinBounderies = _context.Tickets.Where(x => x.Showtime.DateTime >= start && x.Showtime.DateTime <= end);
            return ticketsWithinBounderies.Include(x => x.User).ToList().GroupBy(x => x.User).ToDictionary(x => x.Key, x => x.Sum(x => x.TotalSum))
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        //TASK 6
        public IQueryable<CinemaHalls> LessThanTwoWeeksAgo()
        {
            /*            var lastWeek = _context.Tickets
                            .Where(x => x.Showtime.DateTime < DateTime.Now && x.Showtime.DateTime > DateTime.Now.AddDays(-7)).ToList()
                            .GroupBy(x => x.Showtime.Hall.CinemaHall);

                        var preLastWeek = _context.Tickets
                            .Where(x => x.Showtime.DateTime < DateTime.Now.AddDays(-7) && x.Showtime.DateTime > DateTime.Now.AddDays(-14)).ToList()
                            .GroupBy(x => x.Showtime.Hall.CinemaHall);

                        var ticketsForBoth = lastWeek.Join(preLastWeek, x => x.Key, x => x.Key,
                            (last, preLast) => new
                            {
                                Cinema = last.Key,
                                LastWeek = last.Count(),
                                PreLastWeek = preLast.Count()
                            });

                        return ticketsForBoth.Where(x => x.LastWeek < x.PreLastWeek).Select(x => x.Cinema).AsQueryable();*/

            DateTime now = Convert.ToDateTime("2023-02-06");

            var lastWeek = _context.Tickets.Include(x => x.Showtime)
                .Where(x => x.Showtime.DateTime < now && x.Showtime.DateTime > now.AddDays(-7)).Include(x => x.Showtime.Hall.CinemaHall).ToList()
                .GroupBy(x => x.Showtime.Hall.CinemaHall);

            var preLastWeek = _context.Tickets.Include(x => x.Showtime)
                .Where(x => x.Showtime.DateTime < now.AddDays(-7) && x.Showtime.DateTime > now.AddDays(-14)).Include(x => x.Showtime.Hall.CinemaHall).ToList()
                .GroupBy(x => x.Showtime.Hall.CinemaHall);

            var ticketsForBoth = lastWeek.Join(preLastWeek, x => x.Key, x => x.Key,
                (last, preLast) => new
                {
                    Cinema = last.Key,
                    LastWeek = last.Count(),
                    PreLastWeek = preLast.Count()
                });

            return ticketsForBoth.Where(x => x.LastWeek < x.PreLastWeek).Select(x => x.Cinema).AsQueryable();
        }

        //TASK 7
        public Dictionary<User, User> Together()
        {
            Dictionary<User, User> res = new();

            foreach (User user in _context.Users)
            {
                foreach (User secondUser in _context.Users)
                {
                    if(user != secondUser && user.Tickets == secondUser.Tickets)
                    {
                        res.Add(user, secondUser);
                    }   
                }
            }

            return res;
        }
    }
}
