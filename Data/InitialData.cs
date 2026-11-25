using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Data
{
    internal static class InitialData
    {
        public static void Initialize(Hotel hotel)
        {
            Guest guest1 = new Guest("Ena", "Sabic", 2005, "ena.sabic@gmail.com", "123456");
            Guest guest2 = new Guest("Filip", "Sabic", 2008, "filip.sab@gmail.com", "270408@");
            Guest guest3 = new Guest("Lana", "Sabic", 2006, "lsabic6@gmail.com", "#34#56");

            hotel.Guests.Add(guest1);
            hotel.Guests.Add(guest2);
            hotel.Guests.Add(guest3);

            Room room1 = new Room(101, 1, RoomCategory.Standard, 2, 50.00M);
            Room room2 = new Room(102, 1, RoomCategory.Standard, 3, 70.00M);
            Room room3 = new Room(204, 2, RoomCategory.Deluxe, 2, 120.00M);
            Room room4 = new Room(305, 3, RoomCategory.Deluxe, 4, 250.00M);
            Room room5 = new Room(401, 4, RoomCategory.Suite, 4, 500.00M);

            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);
            hotel.Rooms.Add(room3);
            hotel.Rooms.Add(room4);
            hotel.Rooms.Add(room5);

            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            Reservation reservation1 = new Reservation(guest1, room1,today.AddDays(1), today.AddDays(4));
            Reservation reservation2 = new Reservation(guest2, room2, today.AddDays(10), today.AddDays(13));
            Reservation reservation3 = new Reservation(guest3, room3, today.AddDays(20), today.AddDays(22));
            Reservation reservation4 = new Reservation(guest1, room4, today.AddDays(-20), today.AddDays(-17));
            Reservation reservation5 = new Reservation(guest3, room5, today.AddDays(-10), today.AddDays(-7));

            reservation4.Complete();
            reservation5.Complete();

            hotel.Reservations.Add(reservation1);
            hotel.Reservations.Add(reservation2);
            hotel.Reservations.Add(reservation3);
            hotel.Reservations.Add(reservation4);
            hotel.Reservations.Add(reservation5);

            Employee receptionist1 = new Employee("Ivan", "Ivic", 1970, Gender.Male, Position.Receptionist);
            Employee receptionist2= new Employee("Marta", "Martic", 1992, Gender.Female, Position.Receptionist);
            Employee housekeeper1 = new Employee("Ante", "Antic", 1986, Gender.Male, Position.Housekeeper);
            Employee housekeeper2 = new Employee("Lucija", "Lucic", 1989, Gender.Female, Position.Housekeeper);
            Employee housekeeper3 = new Employee("Luka", "Lukic", 1991, Gender.Male, Position.Housekeeper);
            Employee cook1 = new Employee("Josip", "Milic", 2004, Gender.Male, Position.Cook);
            Employee cook2 = new Employee("Nikola", "Nikic", 1980, Gender.Male, Position.Cook);
            
            hotel.Employees.Add(receptionist1);
            hotel.Employees.Add(receptionist2);
            hotel.Employees.Add(housekeeper1);
            hotel.Employees.Add(housekeeper2);
            hotel.Employees.Add(housekeeper3);
            hotel.Employees.Add(cook1);
            hotel.Employees.Add(cook2);

            Shift shift = new Shift(ShiftType.Morning, new DateOnly(2026, 12,3));
            shift.AddEmployee(receptionist1);
            shift.AddEmployee(housekeeper1);
            shift.AddEmployee(housekeeper2);
            shift.AddEmployee(cook1);

            hotel.Shifts.Add(shift);
        }
    }
}
