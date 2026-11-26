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
    internal class RoomMenu:BaseMenu
    {
        public RoomMenu(Hotel hotel) : base(hotel) { }

        private int AddRoomNumber()
        {
            const int MaxRoomNumber = 599;
            const int MinRoomNumber = 100;

            while (true) 
            {
                int roomNumber = Input.ReadInt($"Write room number in range ({MinRoomNumber}-{MaxRoomNumber}):", MinRoomNumber, MaxRoomNumber);
                if(!_hotel.Rooms.Any(room => room.RoomNumber==roomNumber))
                {
                    return roomNumber;
                }

                Console.WriteLine("INVALID INPUT! Room with that number already exists.\n");
            }
            
        }
        private void AddRoom()
        {
            const int MaxFloor = 5;
            const int MinFloor = 1;

            const int MaxCapacity = 5;
            const int MinCapacity = 1;

            const decimal MaxPricePerNight = 600.00M;
            const decimal MinPricePerNight = 50.00M;

            int roomNumber= AddRoomNumber();
            int floorNumber = Input.ReadInt($"Write floor number in range({MinFloor}-{MaxFloor}): ", MinFloor, MaxFloor);
            RoomCategory category = Input.ReadRoomCategory();
            int capacity= Input.ReadInt($"Write room capacity in range({MinCapacity}-{MaxCapacity}): ", MinCapacity, MaxCapacity);
            decimal pricePerNight = Input.ReadDecimal($"Write room price per night in range ({MinPricePerNight} euros -{MaxPricePerNight} euros): ", MinPricePerNight, MaxPricePerNight);

            if (Confirmation.Ask($"Do you want to add room {roomNumber}?"))
            {
                Room room = new Room(roomNumber, floorNumber, category, capacity, pricePerNight);
                _hotel.Rooms.Add(room);
                Console.WriteLine("Room added successfully.\n");
            }
            else
            {
                Console.WriteLine("Adding room cancelled.\n");
            }
        }
        public override void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("3. ROOM MENU\n\n");
                Console.WriteLine("1 - Show all rooms\n" +
                                  "2 - Add new room\n" +
                                  "3 - Search rooms\n" +
                                  "4 - Delete room\n"+
                                  "5 - Back to main menu\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            new RoomPrinter(_hotel).PrintAll();
                            break;
                        case '2':
                            Console.WriteLine();
                            AddRoom();
                            break;
                        case '3':
                            Console.WriteLine();
                            /////////////////////////
                            break;
                        case '4':
                            Console.WriteLine();
                            /////////////////////////
                            break;
                        case '5':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the main menu........\n");
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
