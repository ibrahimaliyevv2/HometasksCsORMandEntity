using System;
using System.Collections.Generic;
using System.Linq;
using StadiumTaskEntity.DAL;

namespace StadiumTaskEntity.Entities
{
    public class ReservationData
    {
        StadiumDbContext stadiumDbContext = new StadiumDbContext();

        public void AddReservation(Reservation reservation)
        {
            stadiumDbContext.Reservations.Add(reservation);
            stadiumDbContext.SaveChanges();
        }

        public List<Reservation> GetAllReservations()
        {
            return stadiumDbContext.Reservations.ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return stadiumDbContext.Reservations.Find(id);
        }
    }
}
