using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Models
{
    internal class Reservation:Entity
    { 

        public Guest Guest { get; }
        public Room Room { get; }
        
        public DateOnly CheckInDate { get; private set; }
        public DateOnly CheckOutDate { get; private set; }

        public ReservationStatus Status { get; private set; }
        public Reservation( Guest Guest, Room Room, DateOnly CheckInDate, DateOnly CheckOutDate)
        {
            this.CheckInDate=CheckInDate;
            this.CheckOutDate=CheckOutDate;
            Status=ReservationStatus.Confirmed;
            this.Guest=Guest;
            this.Room=Room;

        }

        public int Nights => CheckOutDate.DayNumber - CheckInDate.DayNumber;

        public decimal TotalPrice => Nights*Room.PricePerNight;
    
        public void Cancel()
        {
            Status =ReservationStatus.Cancelled;
            Touch();
        }

        public void Complete()
        {
            Status = ReservationStatus.Completed;
            Touch();
        }

        public void ChangeDates(DateOnly CheckInDate, DateOnly CheckOutDate)
        {
            this.CheckInDate = CheckInDate;
            this.CheckOutDate = CheckOutDate;
            Touch();
        }
    }
}
