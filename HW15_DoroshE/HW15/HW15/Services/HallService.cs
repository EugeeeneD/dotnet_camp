using HW15.Data;
using HW15.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class HallService : ContextBase
    {
        public HallService() : base()
        {
        }

        public HallService(CinemaDBContext context) : base(context)
        {
        }

        public IQueryable<Hall> FindAll()
        {
            return base.FindAll<Hall>();
        }

        public IQueryable<Hall> FindWhere(Expression<Func<Hall, bool>> expression)
        {
            return base.FindWhere<Hall>(expression);
        }

        public void Add(Hall hall)
        {
            base.Add<Hall>(hall);
        }

        public void Update(Hall hall)
        {
            base.Update<Hall>(hall);
        }

        public void Delete(Hall hall)
        {
            base.Delete<Hall>(hall);
        }
    }
}
