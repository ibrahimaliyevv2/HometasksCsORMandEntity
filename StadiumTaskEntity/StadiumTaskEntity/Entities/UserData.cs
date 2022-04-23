using System;
using System.Collections.Generic;
using System.Linq;
using StadiumTaskEntity.DAL;

namespace StadiumTaskEntity.Entities
{
    public class UserData
    {
        StadiumDbContext stadiumDbContext = new StadiumDbContext();

        public void AddUser(User user)
        {
            stadiumDbContext.Users.Add(user);
            stadiumDbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return stadiumDbContext.Users.ToList();
        }
    }
}
