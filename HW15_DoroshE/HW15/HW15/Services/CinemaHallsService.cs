using HW15.Data;
using HW15.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class CinemaHallsService : ContextBase
    {
        public CinemaHallsService()
        {
            _context = new CinemaDBContext();
        }

        public CinemaHallsService(CinemaDBContext context) : base(context)
        {
        }

        public IQueryable<CinemaHalls> FindAll()
        {
            return base.FindAll<CinemaHalls>();
        }

        public IQueryable<CinemaHalls> FindWhere(Expression<Func<CinemaHalls, bool>> expression)
        {
            return base.FindWhere<CinemaHalls>(expression);
        }

        public void Add(CinemaHalls cinemaHall)
        {
            base.Add<CinemaHalls>(cinemaHall);
        }

        public void Update(CinemaHalls cinemaHall)
        {
            base.Update<CinemaHalls>(cinemaHall);
        }

        public void Delete(CinemaHalls cinemaHall)
        {
            base.Delete<CinemaHalls>(cinemaHall);
        }
    }
}
