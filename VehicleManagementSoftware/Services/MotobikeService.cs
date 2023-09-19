using VehicleManagementSoftware.Data;
using VehicleManagementSoftware.Helpers;
using VehicleManagementSoftware.Models;

namespace VehicleManagementSoftware.Services
{
	public class MotobikeService
    {

        public MotobikeService()
        {
        }

        public void printCar(Motobike motobike)
        {
            _printCar(motobike);
        }

        private void _printCar(Motobike motobike)
        {
            Console.Write($"|{Common.padSides("Xe Máy".ToString(), 11)}");
            Console.Write($"|{Common.padSides(motobike.id.ToString(), 4)}");
            Console.Write($"|{Common.padSides(motobike.brand.ToString(), 10)}");
            Console.Write($"|{Common.padSides(motobike.year.ToString(), 16)}");
            Console.Write($"|{Common.padSides(motobike.price.ToString(), 13)}");
            Console.Write($"|{Common.padSides(motobike.color.ToString(), 8)}");
            Console.Write($"|{Common.padSides("".ToString(), 9)}");
            Console.Write($"|{Common.padSides("".ToString(), 12)}");
            Console.Write($"|{Common.padSides(motobike.wattage.ToString(), 13)}");
            Console.WriteLine($"|{Common.padSides("".ToString(), 13)}|");
        }

        public void addCar(string _brand, int _year, double _price, string _color)
        {
            Console.Write("Nhập công suất: ");
            string _wattage = Console.ReadLine();

            Motobike motobike = new Motobike(DataVehicle.nextId++, 2, _brand, _year, _price, _color, int.Parse(_wattage), DateTime.Now);

            DataVehicle.motobikes.Add(motobike);
        }
    }
}

