using System;
using VehicleManagementSoftware.Data;
using VehicleManagementSoftware.Models;
using VehicleManagementSoftware.Helpers;

namespace VehicleManagementSoftware.Services
{
	public class CarService
	{
		public CarService()
		{
		}

        public void printCar (Car car)
        {
            _printCar(car);
        }

        private void _printCar(Car car)
        {
            Console.Write($"|{Common.padSides("Xe Ôtô".ToString(), 11)}");
            Console.Write($"|{Common.padSides(car.id.ToString(), 4)}");
            Console.Write($"|{Common.padSides(car.brand.ToString(), 10)}");
            Console.Write($"|{Common.padSides(car.year.ToString(), 16)}");
            Console.Write($"|{Common.padSides(car.price.ToString(), 13)}");
            Console.Write($"|{Common.padSides(car.color.ToString(), 8)}");
            Console.Write($"|{Common.padSides(car.seat.ToString(), 9)}");
            Console.Write($"|{Common.padSides(car.engineType.ToString(), 12)}");
            Console.Write($"|{Common.padSides("".ToString(), 13)}");
            Console.WriteLine($"|{Common.padSides("".ToString(), 13)}|");
        }

        public void addCar(string _brand, int _year, double _price, string _color)
        {
            Console.Write("Nhập số ghế: ");
            string _seat = Console.ReadLine();

            Console.Write("Nhập loại động cơ xe: ");
            string _engineType = Console.ReadLine();

            Car car = new Car(DataVehicle.nextId++, 1, _brand, _year, _price, _color, int.Parse(_seat), _engineType, DateTime.Now);

            DataVehicle.cars.Add(car);
        }
    }
}

