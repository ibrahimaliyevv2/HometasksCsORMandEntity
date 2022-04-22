using Microsoft.EntityFrameworkCore;
using StadiumTaskEntity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumTaskEntity.DAL
{
    class StadiumDbContext:DbContext
    {
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KA8SSD4;Database=StadiumDB;Trusted_Connection=TRUE");
        }
    }
}
