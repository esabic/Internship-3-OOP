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
    internal class ReservationPrinter:BasePrinter
    {
        public ReservationPrinter(Hotel hotel) : base(hotel) { }

        public void PrintAll()
        {
            if (_hotel.Reservations.Count == 0)
            {
                Console.WriteLine("No reservation found.");
                return;
            }

            foreach (Reservation reservation in _hotel.Reservations)
            {
                Print(reservation);
                Console.WriteLine();
            }

        }


        public void Print(Reservation reservation)
        {

            Console.WriteLine($"[{reservation.Id}] {reservation.Guest.FullName} | Room {reservation.Room.RoomNumber} ({reservation.Room.Category}) | {reservation.CheckInDate:yyyy-MM-dd} -> {reservation.CheckOutDate:yyyy-MM-dd} | {reservation.Nights} nights | {reservation.TotalPrice} euros | {reservation.Status}");

        }
    }
}
