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
                                  "3 - Back to room menu\n\n");

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
                            ////////////////////
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
                            /////////////////////////
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
