using System;
using System.Collections.Generic;
using System.Linq;
using StadiumTaskEntity.DAL;

namespace StadiumTaskEntity.Entities
{
    public class StadiumData
    {
        StadiumDbContext stadiumDbContext = new StadiumDbContext();
        public void AddStadium(Stadium stadium)
        {
            stadiumDbContext.Stadiums.Add(stadium);
            stadiumDbContext.SaveChanges();
        }

        public List<Stadium> GetAllStadiums()
        {
            return stadiumDbContext.Stadiums.ToList();
        }

        public Stadium GetStadiumById(int id)
        {
            return stadiumDbContext.Stadiums.Find(id);
        }

        public void DeleteStadiumById(int id)
        {
            var deleteIt = stadiumDbContext.Stadiums.FirstOrDefault(x => x.Id == id);
            stadiumDbContext.Stadiums.Remove(deleteIt);
            stadiumDbContext.SaveChanges();
        }
    }
}
