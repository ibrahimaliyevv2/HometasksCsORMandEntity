using System;
namespace StadiumTaskEntity.Entities
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HourlyPrice { get; set; }
        public byte Capacity { get; set; }
    }
}
