using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Models
{
    internal class Reservation:Entity
    {
        
        public decimal Price { get; set; }
        public ReservationStatus Status { get; set; }
    
    }
}
