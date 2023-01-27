using HW15.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Data
{
    public class CinemaDBContext : DbContext
    {
        public CinemaDBContext(DbContextOptions options) : base(options)
        {
        }
        public CinemaDBContext()
        {
        }
        public DbSet<CinemaHalls> CinemaHalls { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HOPA162;Database=CinemaNetwork;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //optionsBuilder.UseSqlServer("Data Source=JOHEN1;Database=CinemaNetwork;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CinemaHalls>()
                .HasMany(x => x.Halls)
                .WithOne(x => x.CinemaHall)
                .HasForeignKey(x => x.CinemaGuid)
                .IsRequired();

            modelBuilder.Entity<Seat>()
                .HasOne(x => x.Hall)
                .WithMany(x => x.Seats)
                .HasForeignKey(x => x.HallGuid)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Showtimes)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieGuid)
                .IsRequired();

            modelBuilder.Entity<Showtime>()
                .HasOne(x => x.Hall)
                .WithMany(x => x.Showtimes)
                .HasForeignKey(x => x.HallGuid)
                .IsRequired()
                .Metadata.DeleteBehavior = DeleteBehavior.NoAction;

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.Seat)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.SeatGuid)
                .IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.Showtime)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.ShowtimeGuid)
                .IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserGuid)
                .IsRequired();
        }
    }
}
