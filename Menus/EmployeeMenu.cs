using Internship_3_OOP.Data;
using Internship_3_OOP.Printers;
using Internship_3_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_3_OOP.Utils;
using System.Runtime.CompilerServices;

namespace Internship_3_OOP.Menus
{
    internal class EmployeeMenu:BaseMenu
    {
        public EmployeeMenu(Hotel hotel): base(hotel){ }

        private void AddEmployee()
        {
            const int MinBirthYear = 1960;
            

            string firstName = Input.ReadNonEmpty("first name of the employee");
            string lastName = Input.ReadNonEmpty("last name of the employee");
            int birthYear = Input.ReadInt("Birth year: ", MinBirthYear, DateTime.Now.Year-16);
            Gender gender = Input.ReadGender();
            Position position = Input.ReadPosition();

            if (Confirmation.Ask($"Do you want to add employee: {firstName} {lastName}"))
            {
                Employee employee = new Employee(firstName, lastName, birthYear, gender, position);
                _hotel.Employees.Add(employee);
                Console.WriteLine("Employee added successfully.\n");
            }
            else
            {
                Console.WriteLine("Adding employee cancelled.\n");
            }
        }

        private Employee? PickEmployee(Position position, List<Employee> choosen,DateOnly date, string prompt)
        {
            List<Employee> available = new List<Employee>();

            foreach(Employee employee in _hotel.Employees)
            {
                bool rightPosition = employee.Position == position;
                bool alreadyCoosen = choosen.Contains(employee);
                bool alreadyInShift = _hotel.Shifts.Any(s => s.ShiftDate == date && s.Employees.Contains(employee));

                if(rightPosition && !alreadyCoosen && !alreadyInShift)
                {
                    available.Add(employee);
                }
            }

            if(available.Count == 0)
            {
                Console.WriteLine($"No available employees for position {position}.\n");
                return null;
            }

            new ShiftPrinter(_hotel).PrintNumbered(available, prompt);
            int option = Input.ReadInt($"Choose employee: ", 1, available.Count);
            return available[option-1];

        }
        private void CreateNewShift()
        {
            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);


            ShiftType shiftType = Input.ReadShiftType();
            DateOnly shiftDate = Input.ReadDate($"Write shift date in format (YYYY-MM-DD): ", dateToday );

            List<Employee> choosen = new List<Employee>();

            Employee? receptionist = PickEmployee(Position.Receptionist, choosen,shiftDate, $"Available receptionist(s):");
            if(receptionist == null)
            {
                return;
            }
            choosen.Add(receptionist);

            Employee? housekeeper1 = PickEmployee(Position.Housekeeper,choosen ,shiftDate, $"Available housekeeper(s):");
            if (housekeeper1 == null)
            {
                return;
            }
            choosen.Add(housekeeper1);

            Employee? housekeeper2 = PickEmployee(Position.Housekeeper, choosen,shiftDate, $"Available housekeeper(s):");
            if (housekeeper2 == null)
            {
                return;
            }
            choosen.Add(housekeeper2);

            Employee? cook = PickEmployee(Position.Cook,choosen,shiftDate, $"Available cook(s):");
            if (cook == null)
            {
                return;
            }
            choosen.Add(cook);
           
   
            if (Confirmation.Ask("Do you want to add new shift?"))
            {
                Shift shift = new Shift(shiftType, shiftDate);
                shift.AddEmployee(receptionist);
                shift.AddEmployee(housekeeper1);
                shift.AddEmployee(housekeeper2);
                shift.AddEmployee(cook);
                _hotel.Shifts.Add(shift);
                Console.WriteLine("New shift added successfully.\n");
            }
            else
            {
                Console.WriteLine("Creating new shift cancelled.\n");
            }
        }
    
        public override void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("4. EMPLOYEE MENU\n\n");
                Console.WriteLine("1 - Show all shifts\n" +
                                  "2 - Create new shift\n" +
                                  "3 - Add employee\n" +
                                  "4 - Back to main menu\n\n");

                Console.Write("Option: ");
                if (char.TryParse(Console.ReadLine(), out char option))
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine();
                            new ShiftPrinter(_hotel).PrintAll();
                            break;
                        case '2':
                            Console.WriteLine();
                            CreateNewShift();
                            break;
                        case '3':
                            Console.WriteLine();
                            AddEmployee();
                            break;
                        case '4':
                            Console.WriteLine();
                            Console.WriteLine("Returning to the main menu........\n");
                            return;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("INVALID INPUT! You need to choose between (1-4).\n\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("INVALID INPUT! You need to enter a single character (1-4).\n\n ");
                }
            }

        }
    }
}
