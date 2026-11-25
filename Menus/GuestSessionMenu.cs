using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class GuestSessionMenu:BaseMenu
    {
        private readonly Guest _guest;
        public GuestSessionMenu(Hotel hotel, Guest guest) : base(hotel) 
        { 
            _guest=guest;
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
                                  "4 - Cancel resrvation\n" +
                                  "5 - Back to previous menu\n\n");

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
                            /////////////////////////
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
