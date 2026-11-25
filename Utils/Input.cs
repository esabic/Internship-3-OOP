using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Utils
{
    internal static class Input
    {
        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write($"Write your {prompt}: ");
                var stringInput = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(stringInput))
                {
                    return stringInput;
                }

                Console.WriteLine($"INVALID INPUT! Your input cannot be empty. You need to write {prompt}.");
            }
        }
    }
}
