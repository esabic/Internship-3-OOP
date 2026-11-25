using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Models
{
    internal class Shift:Entity
    {
        public ShiftType ShiftType { get; }

        public DateOnly ShiftDate {  get; }

        private readonly List<Employee> _employees = new();
        public IReadOnlyList<Employee> Employees => _employees;

        public Shift(ShiftType shiftType, DateOnly shiftDate)
        {
            ShiftType = shiftType;
            ShiftDate = shiftDate;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            Touch();
        }
    }
}
