using Internship_3_OOP.Data;
using Internship_3_OOP.Printers;
using Internship_3_OOP.Utils;
using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_3_OOP.Services;

namespace Internship_3_OOP.Menus
{
    internal class ReservationMenu:BaseMenu
    {
        public ReservationMenu(Hotel hotel) : base(hotel) { }

        private const int MinDaysBeforeCheckIn = 2;
        private void SearchById()
        {
            Guid id = Input.ReadId("Write id of the reservation: ");
            Reservation? reservation = _hotel.Reservations.FirstOrDefault(r => r.Id == id);

            if (reservation == null)
            {
                Console.WriteLine($"No reservation found with {id} id.\n");
            }

            else
            {
                new ReservationPrinter(_hotel).Print(reservation);
            }
        }

        private void SearchByLastNameOfTheGuest()
        {
            string lastName = Input.ReadNonEmpty("last name of the guest");
            int found =0;

            foreach(Reservation reservation in _hotel.Reservations)
            {
                if(reservation.Guest.LastName == lastName)
                {
                    new ReservationPrinter(_hotel).Print(reservation);
                    found++;
                }
            }
            if (found == 0)
            {
                Console.WriteLine($"No reservation found with guest last name {lastName}.\n");
            }


        }
        private void SearchReservation()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("SEARCH RESERVATION MENU\n\n");
                Console.WriteLine("1 - Search by Id\n" +
                                  "2 - Search by last name of the guest \n" +
                                  "3 - Back to reservation menu\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            SearchById();
                            break;
                        case '2':
                            Console.WriteLine();
                            SearchByLastNameOfTheGuest();
                            break;
                        case '3':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the reservation menu........\n");
                            return;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("INVALID INPUT! You need to choose between (1-3).\n\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("INVALID INPUT! You need to enter a single character (1-3).\n\n ");
                }
            }
        }

        private void AddReservation()
        { 
            DateOnly today=DateOnly.FromDateTime(DateTime.Now);

            if(_hotel.Guests.Count == 0)
            {
                Console.WriteLine("No guests found.\n");
                return;
            }

            for (int i = 0; i < _hotel.Guests.Count; i++)
            {
                Console.WriteLine($"{i + 1} {_hotel.Guests[i].FullName} | {_hotel.Guests[i].Email} ");

            }
            int option = Input.ReadInt("Choose guest: ", 1, _hotel.Guests.Count);
            Guest chosenGuest = _hotel.Guests[option - 1];

            DateOnly checkInDate = Input.ReadDate("Write check in date: ", today);
            DateOnly checkOutDate = Input.ReadDate("Write check out date: ",checkInDate);

            List<Room > available = new List<Room>();

            foreach(Room room in _hotel.Rooms)
            {
                bool isOccupied = _hotel.Reservations.Any(r => r.Room == room && r.Status == ReservationStatus.Confirmed && r.CheckInDate < checkOutDate && r.CheckOutDate > checkInDate);
                if (!isOccupied)
                {
                    available.Add(room);
                }
            }
            if(available.Count == 0)
            {
                Console.WriteLine("No free rooms for that period.\n");
                return;
            }
            new RoomPrinter(_hotel).PrintNumbered(available);
            int choice = Input.ReadInt("Choose room: ", 1, available.Count);
            Room chosenRoom = available[choice-1];

            int nights = checkOutDate.DayNumber-checkInDate.DayNumber;
            decimal totalPrice = nights * chosenRoom.PricePerNight;
            Console.WriteLine($"Total price per night is {totalPrice} euros");

            if (Confirmation.Ask("Do you want to reserve room?"))
            {
                Reservation reservation = new Reservation(chosenGuest, chosenRoom, checkInDate, checkOutDate);
                _hotel.Reservations.Add(reservation);
                Console.WriteLine("Reservation created successfully.\n");
            }
            else
            {
                Console.WriteLine("Reservation cancelled.\n");
            }

        }

        private void DeleteReservation()
        {
            if (_hotel.Reservations.Count == 0)
            {
                Console.WriteLine("No reservations found.\n");
                return;
            }
            new ReservationPrinter(_hotel).PrintAll();

            Guid id = Input.ReadId("Write id: ");
            Reservation? reservation = _hotel.Reservations.FirstOrDefault(r => r.Id == id);

            if (reservation == null)
            {
                Console.WriteLine($"Reservation with id ({id}) does not exist.\n");
                return;
            }

            if (reservation.Status == ReservationStatus.Completed)
            {
                Console.WriteLine($"Completed reservation cannot be deleted.\n");
                return;
            }

            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            int daysUntilCheckIn = reservation.CheckInDate.DayNumber- today.DayNumber;

          

            if (daysUntilCheckIn < MinDaysBeforeCheckIn)
            {
                Console.WriteLine("Cannot delete, arrival is in less than 48 hours.\n");
                return;
            }

            if (Confirmation.Ask($"Do you want to delete this reservation?"))
            {
                
                _hotel.Reservations.Remove(reservation);
                Console.WriteLine("Reservation deleted successfully.\n");
            }
            else
            {
                Console.WriteLine("Deleting reservation cancelled.\n");
            }

        }
        public override void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("2. RESERVATION MENU\n\n");
                Console.WriteLine("1 - Show all reservations\n" +
                                  "2 - Add reservation\n" +
                                  "3 - Search reservation\n" +
                                  "4 - Edit reservation\n" +
                                  "5 - Delete reservation\n" +
                                  "6 - Back to main menu\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            new ReservationPrinter(_hotel).PrintAll();
                            break;
                        case '2':
                            Console.WriteLine();
                            AddReservation();
                            break;
                        case '3':
                            Console.WriteLine();
                            SearchReservation();
                            break;
                        case '4':
                            Console.WriteLine();
                            ////////////////////
                            break;
                        case '5':
                            Console.WriteLine();
                            DeleteReservation();
                            break;
                        case '6':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the main menu........\n");
                            return;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("INVALID INPUT! You need to choose between (1-6).\n\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("INVALID INPUT! You need to enter a single character (1-6).\n\n ");
                }
            }
        }
    }
}
