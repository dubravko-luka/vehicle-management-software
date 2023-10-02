using System;
using Vehicles.Database;
using Vehicles.Helpers;
using Vehicles.Interface;

namespace Vehicles.Models
{
	public class Truck : Vehicle, ITruck
    {
        public string payload { get; set; }

        public Truck() { }

        public Truck(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt, string payload) : base(id, type, brand, year, price, color, createAt)
        {
            this.payload = payload;
        }

        public void createTruck(string brand, int year, double price, string color)
        {
            create(Data.getNextId(), Constants.VEHICLE_TYPE_ENUM.TRUCK, brand, year, price, color, DateTime.Now);
        }

        public override void create(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt)
        {
            string _payload = Common.inputString("Trong tai: ");
            Truck truck = new Truck(id, type, brand, year, price, color, createAt, _payload);
            Data.addData(truck.toString());
        }

        public void editTruck(int id, string brand, int year, double price, string color)
        {
            edit(id, Constants.VEHICLE_TYPE_ENUM.TRUCK, brand, year, price, color, DateTime.Now);
        }

        public override void edit(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt)
        {
            string _payload = Common.inputString("Trong tai: ");
            Truck truck = new Truck(id, type, brand, year, price, color, createAt, _payload);
            Data.edit(id, truck.toString());
        }

        public string toString()
        {
            return $"{base.toString()},{payload}";
        }

        public static void printCar(Truck truck)
        {
            Console.Write($"|{Common.padSides("Xe tai".ToString(), 11)}");
            Console.Write($"|{Common.padSides(truck.id.ToString(), 4)}");
            Console.Write($"|{Common.padSides(truck.brand.ToString(), 10)}");
            Console.Write($"|{Common.padSides(truck.year.ToString(), 16)}");
            Console.Write($"|{Common.padSides(truck.price.ToString("N0"), 15)}");
            Console.Write($"|{Common.padSides(truck.color.ToString(), 8)}");
            Console.Write($"|{Common.padSides("".ToString(), 9)}");
            Console.Write($"|{Common.padSides("".ToString(), 12)}");
            Console.Write($"|{Common.padSides("".ToString(), 13)}");
            Console.WriteLine($"|{Common.padSides(truck.payload.ToString(), 13)}|");
        }
    }
}

