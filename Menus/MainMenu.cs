using Internship_3_OOP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class MainMenu:BaseMenu
    {
        public MainMenu(Hotel hotel):base(hotel) { }
        public override void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("HOTEL APPLICATION\n\n");
                Console.WriteLine("1 - Guests\n" +
                                  "2 - Reservations\n" +
                                  "3 - Rooms\n" +
                                  "4 - Employees\n" +
                                  "5 - EXIT\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            new GuestMenu(_hotel).Run();
                            break;
                        case '2':
                            Console.WriteLine();
                            new ReservationMenu(_hotel).Run();
                            break;
                        case '3':
                            Console.WriteLine();
                            new RoomMenu(_hotel).Run();
                            break;
                        case '4':
                            Console.WriteLine();
                            new EmployeeMenu(_hotel).Run();
                            break;
                        case '5':
                            Console.WriteLine();
                            Console.WriteLine("Closing aplication........\n");
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
