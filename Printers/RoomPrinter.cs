using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using Internship_3_OOP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Printers
{
    internal class RoomPrinter:BasePrinter
    {
        public RoomPrinter(Hotel hotel) : base(hotel) { }

        public void PrintAll()
        {
            if (_hotel.Rooms.Count == 0)
            {
                Console.WriteLine("No rooms found.");
                return;
            }

            foreach (Room room in _hotel.Rooms)
            {
                var numberOfReservations = new ReservationService(_hotel).NumberOfReservations(room);
                Print(room, numberOfReservations);
                Console.WriteLine();
            }

        }

        
        public void Print(Room room, int numberOfReservations)
        {

            Console.WriteLine($"[{room.Id}] Room {room.RoomNumber} | {room.FloorNumber} floor | {room.Category} | {room.Capacity} | {room.PricePerNight} euro/night | number of reservations {numberOfReservations}");
            
        }
    }
}
