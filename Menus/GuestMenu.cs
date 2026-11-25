using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using Internship_3_OOP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class GuestMenu:BaseMenu
    {
        public GuestMenu(Hotel hotel) : base(hotel) { }


        private Guest Login()
        {
            while (true)
            {
                string email = Input.ReadNonEmpty("email");
                string password = Input.ReadNonEmpty("password");

                foreach (Guest guest in _hotel.Guests)
                {
                    if (guest.CheckEmail(email) && guest.CheckPassword(password))
                    {

                        return guest;
                    }
                }

                Console.WriteLine("Wrong email or password. Try again.");

            } 
            
        }

        public override void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. GUEST MENU\n\n");
                Console.WriteLine("1 - Register\n" +
                                  "2 - Login\n" +
                                  "3 - Back to main menu\n\n");

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
                            Guest guest = Login();
                            new GuestSessionMenu(_hotel, guest).Run();

                            break;
                        case '3':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the main menu........\n");
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
