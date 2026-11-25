using Internship_3_OOP.Data;
using Internship_3_OOP.Menus;

namespace Internship_3_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            InitialData.Initialize(hotel);

           new MainMenu(hotel).Run();

        }
    }
}
