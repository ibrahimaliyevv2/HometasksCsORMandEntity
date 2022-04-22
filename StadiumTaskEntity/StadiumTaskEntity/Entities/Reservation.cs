using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumTaskEntity.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public Stadium Stadium { get; set; }
        public int StadiumId { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
