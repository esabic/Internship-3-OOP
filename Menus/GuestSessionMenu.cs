using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using Internship_3_OOP.Printers;
using Internship_3_OOP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class GuestSessionMenu:BaseMenu
    {
        private const int CancellationLimitDays = 2;

        private DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        private readonly Guest _guest;
        public GuestSessionMenu(Hotel hotel, Guest guest) : base(hotel) 
        { 
            _guest=guest;
        }

        private void CreateNewReservation()
        {
            DateOnly today=DateOnly.FromDateTime(DateTime.Now);
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
                Reservation reservation = new Reservation(_guest, chosenRoom, checkInDate, checkOutDate);
                _hotel.Reservations.Add(reservation);
                Console.WriteLine("Reservation created successfully.\n");
            }
            else
            {
                Console.WriteLine("Reservation cancelled.\n");
            }
        }
        private void CancelReservation()
        {
            List<Reservation> guestReservations = new List<Reservation>();

            foreach (Reservation reservation in _hotel.Reservations)
            { 
                if (reservation.Guest==_guest&&reservation.Status==ReservationStatus.Confirmed)
                {
                    guestReservations.Add(reservation);
                }
            }
            if (guestReservations.Count == 0)
            {
                Console.WriteLine("You have no reservations.\n");
                return;
            }
            new GuestReservationPrinter(_hotel).PrintNumbered(guestReservations);
            int choice = Input.ReadInt("Choose reservation to cancel: ", 1, guestReservations.Count);
            Reservation chosenReservation = guestReservations[choice - 1];

            int daysUntilCancelation = chosenReservation.CheckInDate.DayNumber - today.DayNumber;

            if (daysUntilCancelation < CancellationLimitDays)
            {
                Console.WriteLine($"Cannot cancel, arival is less than {CancellationLimitDays * 24} hours.\n");
                return;
            }

            if (Confirmation.Ask("Do you want to cancel reservation?"))
            { 
                chosenReservation.Cancel();
                Console.WriteLine("Reservation canceled successfully.\n");
            }
            else
            {
                Console.WriteLine("Reservation cancelation cancelled.\n");
            }

        }
        public override void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("GUEST SESSION MENU \n\n");
                Console.WriteLine("1 - My reservations\n" +
                                  "2 - New reservation\n" +
                                  "3 - Search rooms\n" +
                                  "4 - Cancel reservation\n" +
                                  "5 - Back to previous menu\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            new GuestReservationPrinter(_hotel).PrintAll(_guest);
                            break;
                        case '2':
                            Console.WriteLine();
                            CreateNewReservation();
                            break;
                        case '3':
                            Console.WriteLine();
                            new RoomSearchMenu(_hotel).Run();
                            break;
                        case '4':
                            Console.WriteLine();
                            CancelReservation();
                            break;
                        case '5':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the previous menu........\n");
                            return;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("INVALID INPUT! You need to choose between (1-5).\n\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("INVALID INPUT! You need to enter a single character (1-5).\n\n ");
                }
            }
        }
    }
}
