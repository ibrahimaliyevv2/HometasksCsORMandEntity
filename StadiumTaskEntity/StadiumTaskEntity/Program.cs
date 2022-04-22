using StadiumTaskEntity.DAL;
using StadiumTaskEntity.Entities;
using System;

namespace StadiumTaskEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();

            Stadium stadium = new Stadium
            {
                Id = 1,
                Name = "Tofiq Bahramov",
                HourlyPrice = 2,
                Capacity = 13
            };

            stadiumDbContext.Stadiums.Add(stadium);
            stadiumDbContext.SaveChanges();
        }
    }
}
