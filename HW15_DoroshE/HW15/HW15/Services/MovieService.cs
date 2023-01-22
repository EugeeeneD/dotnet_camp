using HW15.Data.Entities;
using HW15.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class MovieService : ContextBase
    {
        public MovieService()
        {
            _context = new CinemaDBContext();
        }

        public MovieService(CinemaDBContext context) : base(context)
        {
        }

        public IQueryable<Movie> FindAll()
        {
            return base.FindAll<Movie>();
        }

        public IQueryable<Movie> FindWhere(Expression<Func<Movie, bool>> expression)
        {
            return base.FindWhere<Movie>(expression);
        }

        public void Add(Movie movie)
        {
            base.Add<Movie>(movie);
        }

        public void Update(Movie movie)
        {
            base.Update<Movie>(movie);
        }

        public void Delete(Movie movie)
        {
            base.Delete<Movie>(movie);
        }
    }
}
