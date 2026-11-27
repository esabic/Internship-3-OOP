using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using Internship_3_OOP.Printers;
using Internship_3_OOP.Services;
using Internship_3_OOP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class RoomSearchMenu:BaseMenu
    {
        private const int MaxRoomNumber = 599;
        private const int MinRoomNumber = 100;
        public RoomSearchMenu(Hotel hotel) : base(hotel) { }

        private void SearchByRoomNumber()
        {
            int roomNumber = Input.ReadInt($"Write room number ({MinRoomNumber}-{MaxRoomNumber}): ", MinRoomNumber, MaxRoomNumber);

            Room? room = _hotel.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine($"No room found with {roomNumber} number.\n");
            }

            else
            {
                int numberOfReservations = new ReservationService(_hotel).NumberOfReservations(room);
                new RoomPrinter(_hotel).Print(room, numberOfReservations);
            }

        }

        private void SearchByCategory()
        {
            RoomCategory roomCategory = Input.ReadRoomCategory();
            int found = 0;

            foreach (Room room in _hotel.Rooms)
            {
                if (room.Category == roomCategory)
                {
                    int numberOfReservations = new ReservationService(_hotel).NumberOfReservations(room);
                    new RoomPrinter(_hotel).Print(room, numberOfReservations);
                    found++;
                }
            }

            if (found == 0)
            {
                Console.WriteLine($"No rooms found in {roomCategory} category.\n");
            }
        }

        public override void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("SEARCH ROOMS MENU\n\n");
                Console.WriteLine("1 - Search by room number\n" +
                                  "2 - Search by category \n" +
                                  "3 - Back to room menu\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            SearchByRoomNumber();
                            break;
                        case '2':
                            Console.WriteLine();
                            SearchByCategory();
                            break;
                        case '3':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the previous menu........\n");
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


    }
}
