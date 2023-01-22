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
    public abstract class ContextBase
    {
        protected CinemaDBContext _context;
        public ContextBase()
        {
            _context = new CinemaDBContext();
        }

        public ContextBase(CinemaDBContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> FindWhere<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return _context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
    }
}
