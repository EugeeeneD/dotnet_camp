using HW15.Data;
using HW15.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class CinemaHallsService : ContextBase
    {
        public CinemaHallsService(CinemaDBContext context) : base(context)
        {
        }

        public CinemaHallsService() : base()
        {
        }

        public async Task<List<CinemaHalls>> GetAllCinemaHallsAsync()
        {
            return await _context.CinemaHalls.ToListAsync();
        }

        public CinemaHalls GetCinemaHallByAddressAsycn(string address)
        {
            return await _context.CinemaHalls.FirstOrDefaultAsync(x => x.Address == address);
        }
        
        public async void AddCinemaHallsAsync(CinemaHalls cinemaHall)
        {
            await _context.CinemaHalls.AddAsync(cinemaHall);
            _context.SaveChangesAsync();
        }
    }
}
