using Internship_3_OOP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Printers
{
    internal abstract class BasePrinter
    {
        protected readonly Hotel _hotel;

        public BasePrinter(Hotel hotel)
        {
            _hotel = hotel;
        }
    }
}
