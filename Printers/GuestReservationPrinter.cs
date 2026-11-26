using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Printers
{
    internal class GuestReservationPrinter:BasePrinter
    {

        public GuestReservationPrinter(Hotel hotel) : base(hotel) { }

        public void PrintAll( Guest guest)
        {
            if (!_hotel.Reservations.Any(r => r.Guest == guest))
            {
                Console.WriteLine("You have no reservations.");
                return;
            }

            foreach (Reservation reservation in _hotel.Reservations)
            {
                if(reservation.Guest == guest)
                {
                    Print(reservation);
                    Console.WriteLine();
                }
            }

        }


        public void Print(Reservation reservation)
        {

            Console.WriteLine($"[{reservation.Id}] Room {reservation.Room.RoomNumber} ({reservation.Room.Category}) | {reservation.CheckInDate:yyyy-MM-dd} -> {reservation.CheckOutDate:yyyy-MM-dd} | {reservation.Nights} nights | {reservation.TotalPrice} euros | {reservation.Status}");

        }

    }
}
