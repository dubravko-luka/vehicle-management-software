using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using VehicleManagementSoftware.Data;
using VehicleManagementSoftware.Helpers;
using VehicleManagementSoftware.Models;

namespace VehicleManagementSoftware.Services
{
	public class TruckService
	{
		public TruckService()
		{
		}

        public void printCar(Truck truck)
        {
            _printCar(truck);
        }

        private void _printCar(Truck truck)
        {
            Console.Write($"|{Common.padSides("Xe Tải".ToString(), 11)}");
            Console.Write($"|{Common.padSides(truck.id.ToString(), 4)}");
            Console.Write($"|{Common.padSides(truck.brand.ToString(), 10)}");
            Console.Write($"|{Common.padSides(truck.year.ToString(), 16)}");
            Console.Write($"|{Common.padSides(truck.price.ToString(), 13)}");
            Console.Write($"|{Common.padSides(truck.color.ToString(), 8)}");
            Console.Write($"|{Common.padSides("".ToString(), 9)}");
            Console.Write($"|{Common.padSides("".ToString(), 12)}");
            Console.Write($"|{Common.padSides("".ToString(), 13)}");
            Console.WriteLine($"|{Common.padSides(truck.payload.ToString(), 13)}|");
        }

        public void addCar(string _brand, int _year, double _price, string _color) {
            Console.Write("Nhập tải trọng: ");
            string _payload = Console.ReadLine();

            Truck truck = new Truck(DataVehicle.nextId++, 3, _brand, _year, _price, _color, _payload, DateTime.Now);

            DataVehicle.trucks.Add(truck);
        }
    }
}

