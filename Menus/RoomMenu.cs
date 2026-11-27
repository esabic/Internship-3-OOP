using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using Internship_3_OOP.Printers;
using Internship_3_OOP.Services;
using Internship_3_OOP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class RoomMenu:BaseMenu
    {
        private const int MaxRoomNumber = 599;
        private const int MinRoomNumber = 100;
        public RoomMenu(Hotel hotel) : base(hotel) { }

        private int AddRoomNumber()
        {
            

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

        private void DelteRoomIfAllowed(Room room)
        {
            bool isActive = _hotel.Reservations.Any(r => r.Room == room && r.Status == ReservationStatus.Confirmed);

            if (isActive)
            {
                Console.WriteLine("Room has active reservation and cannot be deleted.\n");
                return;
            }

            if (Confirmation.Ask($"Do you want to delete room ?"))
            {
                _hotel.Reservations.RemoveAll(r => r.Room == room);
                _hotel.Rooms.Remove(room);
                Console.WriteLine("Room deleted successfully.\n");
            }
            else
            {
                Console.WriteLine("Deleting room cancelled.\n");
            }
        }


        private void DeleteById()
        {
            if(_hotel.Rooms.Count == 0)
            {
                Console.WriteLine("No rooms found.\n");
                return;
            }
            new RoomPrinter(_hotel).PrintAll();

            Guid id = Input.ReadId("Write id: ");
            Room? room = _hotel.Rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                Console.WriteLine($"Room with id ({id}) does not exist.\n");
                return;
            }
        
            DelteRoomIfAllowed (room);
        }

        private void DeleteByRoomNumber()
        {
            if (_hotel.Rooms.Count == 0)
            {
                Console.WriteLine("No rooms found.\n");
                return;
            }
            new RoomPrinter(_hotel).PrintAll();

            int roomNumber = Input.ReadInt("Write room number: ", MinRoomNumber, MaxRoomNumber);
            Room? room = _hotel.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine($"Room with number ({roomNumber}) does not exist.\n");
                return;
            }

            DelteRoomIfAllowed (room);
        }
        private void DeleteRoom()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("DELETE ROOM MENU\n\n");
                Console.WriteLine("1 - Delete by Id\n" +
                                  "2 - Delete by room number\n" +
                                  "3 - Back to room menu\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            DeleteById();
                            break;
                        case '2':
                            Console.WriteLine();
                           DeleteByRoomNumber();
                            break;
                        case '3':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the room menu........\n");
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
                            new RoomSearchMenu(_hotel).Run();
                            break;
                        case '4':
                            Console.WriteLine();
                            DeleteRoom();
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
