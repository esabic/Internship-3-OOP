using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Data
{
    internal class Hotel
    {
        public List<Employee> Employees { get; } = new();
        public List<Guest> Guests { get; } = new();
        public List<Reservation> Reservations { get; } = new();
        public List<Room> Rooms { get; } = new();
        public List<Shift> Shifts { get; } = new();

    }
}
