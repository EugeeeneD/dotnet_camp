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
    public class ShowtimeService : ContextBase
    {
        public ShowtimeService()
        {
            _context = new CinemaDBContext();
        }

        public ShowtimeService(CinemaDBContext context) : base(context)
        {
        }

        public IQueryable<Showtime> FindAll()
        {
            return base.FindAll<Showtime>();
        }

        public IQueryable<Showtime> FindWhere(Expression<Func<Showtime, bool>> expression)
        {
            return base.FindWhere<Showtime>(expression);
        }

        public void Add(Showtime showtime)
        {
            base.Add<Showtime>(showtime);
        }

        public void Update(Showtime showtime)
        {
            base.Update<Showtime>(showtime);
        }

        public void Delete(Showtime showtime)
        {
            base.Delete<Showtime>(showtime);
        }

        public IQueryable<Showtime> GetFutureShowtimes()
        {
            return _context.Showtimes.Where(x => x.DateTime > DateTime.Now).AsNoTracking();
        }
    }
}
