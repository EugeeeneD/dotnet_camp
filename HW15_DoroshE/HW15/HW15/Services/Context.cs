using HW15.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class Context
    {
        protected CinemaDBContext _context;
        public Context()
        {
            _context = new CinemaDBContext();
        }

        public Context(CinemaDBContext context)
        {
            _context = context;
        }
    }
}
