using System;
using Microsoft.EntityFrameworkCore;
using StadiumTaskEntity.Entities;

namespace StadiumTaskEntity.DAL
{
    public class StadiumDbContext:DbContext
    {
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=StadiumDB;User Id=sa;Password=MyPass@word");
        }
    }
}
