using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using Internship_3_OOP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal class GuestMenu:BaseMenu
    {
        public GuestMenu(Hotel hotel) : base(hotel) { }


        private Guest? Login()
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

                Console.WriteLine("Wrong email or password.");
                if(!Confirmation.Ask("Do you want to try again?"))
                {
                    return null;
                }

            } 
            
        }

        private void Register()
        {
            int minBirthYear = DateTime.Now.Year-126;
            int maxBirthYear = DateTime.Now.Year;

            string firstName = Input.ReadNonEmpty("first name");
            string lastName = Input.ReadNonEmpty("last name");
            int birthYear = Input.ReadInt("Write birth year: ", minBirthYear, maxBirthYear);

            string email;
            while (true)
            {
                email = Input.ReadNonEmpty("email");
                if(!_hotel.Guests.Any(guest => string.Equals(guest.Email,email)))
                {
                   break;
                }

                Console.WriteLine("INVALID INPUT! Email already exists.\n");
            }

            string password;
            while (true)
            {
                password = Input.ReadNonEmpty("password (min 6 characters)");
                if (password.Length >=  6)
                {
                    break;
                }

                Console.WriteLine("INVALID INPUT! Password must have at least 6 characters.\n");
            }

            if (Confirmation.Ask($"Do you want to add guest: {firstName} {lastName}"))
            {
                Guest guest = new Guest(firstName, lastName, birthYear, email, password);
                _hotel.Guests.Add(guest);
                Console.WriteLine("Guest added successfully.\n");
            }
            else
            {
                Console.WriteLine("Adding guest cancelled.\n");
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
                            Register();
                            break;
                        case '2':
                            Console.WriteLine();
                            Guest? guestLogin = Login();
                            if(guestLogin!=null)
                            {
                                new GuestSessionMenu(_hotel, guestLogin).Run();
                            }
                            
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
