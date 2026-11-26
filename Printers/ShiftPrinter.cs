using Internship_3_OOP.Data;
using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Printers
{
    internal class ShiftPrinter : BasePrinter
    {
        public ShiftPrinter(Hotel hotel) : base(hotel) { }

        public void PrintAll()
        {
            if(_hotel.Shifts.Count==0)
            {
                Console.WriteLine("No shifts found.");
                return;
            }

            foreach (Shift shift in _hotel.Shifts)
            {

                Print(shift);
                Console.WriteLine();
            }

        }

        public void Print(Shift shift)
        {
                Console.WriteLine($"Shift: {shift.ShiftType} {shift.ShiftDate:yyyy-MM-dd}");
                foreach (Employee employee in shift.Employees)
                {
                    Console.WriteLine($"{employee.Position}: {employee.FullName} ({employee.BirthYear})");
                }

        }
    }
}
