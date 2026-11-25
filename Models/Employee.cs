using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Models
{
    internal class Employee : Entity
    {
        public string FirstName { get; }

        public string LastName { get; }

        public int BirthYear { get; }
        public Gender Gender { get; }
        public Position Position { get; }

        public Employee(string firstName, string lastName, int birthYear, Gender gender, Position position)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            Gender = gender;
            Position = position;

        }


        public string FullName => $"{FirstName} {LastName}";

    }
}
