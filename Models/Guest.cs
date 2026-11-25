using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Models
{
    internal class Guest:Entity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int BirthYear { get; }
        public string Email { get; }
        private string Password { get; }


        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public bool CheckEmail(string email)
        {
            return Email == email;
        }
        public Guest(string firstName, string lastName, int birthYear, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            Email = email;
            Password = password;
        }

        public string FullName=>$"{FirstName} {LastName}";
    }
}
