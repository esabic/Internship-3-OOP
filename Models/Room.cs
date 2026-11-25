using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Models
{
    internal class Room:Entity
    {
        public int RoomNumber { get; }

        public int FloorNumber { get; }

        public RoomCategory Category { get; }

        public int Capacity {  get; }

        public decimal PricePerNight { get; }

        public Room(int roomNumber, int floreNumber, RoomCategory category, int capacity, decimal pricePerNight)
        {
            RoomNumber = roomNumber;
            FloorNumber = floreNumber;
            Category = category;
            Capacity = capacity;
            PricePerNight = pricePerNight;
        }


    }
}
