using Internship_3_OOP.Data;

namespace Internship_3_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            InitialData.Initialize(hotel);

        }
    }
}
