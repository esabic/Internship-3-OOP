using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Utils
{
 

    internal static class Input
    {
        public static Guid ReadId(string prompt)
        {

            while (true)
            {
                Console.WriteLine();
                Console.Write(prompt);
                if (Guid.TryParse(Console.ReadLine()?.Trim(), out Guid data))
                {
                    return data;
                }
                Console.WriteLine($"Invalid input! Input must be in format: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.");
            }
        }
        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write($"Write {prompt}: ");
                var stringInput = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(stringInput))
                {
                    return stringInput;
                }

                Console.WriteLine($"INVALID INPUT! Your input cannot be empty. You need to write {prompt}.");
            }
        }

        public static DateOnly ReadDate(string prompt, DateOnly conditionalDate)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write(prompt);
                if(DateOnly.TryParseExact(Console.ReadLine(),"yyyy-MM-dd" ,out DateOnly date) && date > conditionalDate)
                {
                    return date;
                }

                Console.WriteLine($"INVALID INPUT! Enter a date in format yyyy-MM-dd, not earlier than {conditionalDate:yyyy-MM-dd}.");
            }
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            
            while (true)
            {
                Console.WriteLine();
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int data) && data >= min && data <= max)
                {
                    return data;
                }
                Console.WriteLine($"Invalid input! You need to enter a number between {min} and {max}.");
            }
        }

        public static decimal ReadDecimal(string prompt, decimal min, decimal max)
        {

            while (true)
            {
                Console.WriteLine();
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal data) && data >= min && data <= max)
                {
                    return data;
                }
                Console.WriteLine($"Invalid input! You need to enter a number between {min} and {max}.");
            }
        }
        public static Gender ReadGender()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Gender:\n" +
                                  "1 - Male\n" +
                                  "2 - Female\n\n");
                Console.Write("Option: ");

                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            return Gender.Male;
                        case '2':
                            Console.WriteLine();
                            return Gender.Female;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("INVALID INPUT! You need to choose between (1 or 2).\n\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("INVALID INPUT! You need to enter a single character (1 or 2).\n\n ");
                }

            }

        }

        public static Position ReadPosition()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Position:\n" +
                                  "1 - Receptionist\n" +
                                  "2 - Housekeeper\n" +
                                  "3 - Cook\n\n");
                Console.Write("Option: ");

                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            return Position.Receptionist;
                        case '2':
                            Console.WriteLine();
                            return Position.Housekeeper;
                        case '3':
                            Console.WriteLine();
                            return Position.Cook;

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

        public static RoomCategory ReadRoomCategory()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Room category:\n" +
                                  "1 - Standard\n" +
                                  "2 - Deluxe\n" +
                                  "3 - Suite\n\n");
                Console.Write("Option: ");

                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            return RoomCategory.Standard;
                        case '2':
                            Console.WriteLine();
                            return RoomCategory.Deluxe;
                        case '3':
                            Console.WriteLine();
                            return RoomCategory.Suite;
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

        public static ShiftType ReadShiftType()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Shift type:\n" +
                                  "1 - Morning\n" +
                                  "2 - Afternoon\n" +
                                  "3 - Night\n\n");
                Console.Write("Option: ");

                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            return ShiftType.Morning;
                        case '2':
                            Console.WriteLine();
                            return ShiftType.Afternoon;
                        case '3':
                            Console.WriteLine();
                            return ShiftType.Night;
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

