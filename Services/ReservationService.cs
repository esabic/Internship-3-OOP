using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Services
{
    internal class ReservationService
    {
        private readonly Hotel _hotel;

        public ReservationService(Hotel hotel)
        {
            _hotel = hotel;
        }

        public int NumberOfReservations(Room room)
        {
            var counter = 0;
            foreach(Reservation reservation in _hotel.Reservations)
            {
                if(reservation.Room == room && reservation.Status == ReservationStatus.Confirmed)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
    
}
