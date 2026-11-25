using Internship_3_OOP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class ReservationMenu:BaseMenu
    {
        public ReservationMenu(Hotel hotel) : base(hotel) { }

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
                            ///////////
                            break;
                        case '2':
                            Console.WriteLine();
                            ////////////////////
                            break;
                        case '3':
                            Console.WriteLine();
                            /////////////////////////
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
