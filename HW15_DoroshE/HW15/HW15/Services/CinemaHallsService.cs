using HW15.Data;
using HW15.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class CinemaHallsService : Context
    {
        public CinemaHallsService(CinemaDBContext context) : base(context)
        {
        }

        public CinemaHallsService() : base()
        {
        }

        public List<CinemaHalls> GetAllCinemaHalls()
        {
            return _context.CinemaHalls.ToList();
        }

        public CinemaHalls GetCinemaHallByAddress(string address)
        {
            return _context.CinemaHalls.FirstOrDefault(x => x.Address == address);
        }

        public void AddCinemaHalls(CinemaHalls cinemaHall)
        {
            await _context.CinemaHalls.AddAsync(cinemaHall);
            _context.SaveChangesAsync();
        }
    }
}
