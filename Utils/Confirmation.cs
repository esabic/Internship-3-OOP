using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Utils
{
    internal static class Confirmation
    {

        public static bool Ask(string question)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write($"{question} (y/n):\n");
                if (char.TryParse(Console.ReadLine()?.Trim(), out char conf))
                {
                    if (char.ToLower(conf) == 'y')
                    {
                        return true;
                    }
                    else if (char.ToLower(conf) == 'n')
                    {
                        return false;
                    }

                    Console.WriteLine("INVALID INPUT! You need to write (y/n).\n");

                }
                else
                {
                    Console.WriteLine("INVALID INPUT! You need to write a single character (y/n)");

                }
            }
        }

    }
}
