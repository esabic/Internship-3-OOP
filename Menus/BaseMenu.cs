using Internship_3_OOP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Menus
{
    internal abstract class BaseMenu
    {
        protected readonly Hotel _hotel;

        public BaseMenu(Hotel hotel)
        {
            _hotel = hotel;
        }

        public abstract void Run();
    }
}
