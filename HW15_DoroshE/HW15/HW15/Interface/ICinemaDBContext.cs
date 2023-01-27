using HW15.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW15.Interface
{
    public interface ICinemaDBContext
    {
        DbSet<CinemaHalls> CinemaHalls { get; set; }
        DbSet<Hall> Halls { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<Showtime> Showtimes { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<User> Users { get; set; }
    }
}