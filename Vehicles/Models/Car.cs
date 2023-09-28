using System;
using Vehicles.Helpers;
using Vehicles.Database;
using System.Drawing;

namespace Vehicles.Models
{
	public class Car : Vehicle
	{
        public int seat { get; set; }
        public string engineType { get; set; }

        public Car() { }

        public Car(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt, int seat, string engineType) : base(id, type, brand, year, price, color, createAt)
        {
            this.seat = seat;
            this.engineType = engineType;
        }

        public override string toString()
        {
            return $"{id},{type},{brand},{year},{price},{color},{createAt},{seat},{engineType}";
        }

        public void createCar(string brand, int year, double price, string color)
        {
            create(Data.getNextId(), Constants.VEHICLE_TYPE_ENUM.CAR, brand, year, price, color, DateTime.Now);
        }

        public override void create(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt)
        {
            int _seat = Common.inputInt("So ghe ngoi: ");
            string _engineType = Common.inputString("Kieu dong co: ");
            Car car = new Car(id, type, brand, year, price, color, createAt, _seat, _engineType);
            Data.addData(car.toString());
        }

        public void editCar(int id, string brand, int year, double price, string color)
        {
            edit(id, Constants.VEHICLE_TYPE_ENUM.CAR, brand, year, price, color, DateTime.Now);
        }

        public override void edit(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt)
        {
            int _seat = Common.inputInt("So ghe ngoi: ");
            string _engineType = Common.inputString("Kieu dong co: ");
            Car car = new Car(id, type, brand, year, price, color, createAt, _seat, _engineType);
            Data.edit(id, car.toString());
        }

        public static void printCar(Car car)
        {
            Console.Write($"|{Common.padSides("Xe oto".ToString(), 11)}");
            Console.Write($"|{Common.padSides(car.id.ToString(), 4)}");
            Console.Write($"|{Common.padSides(car.brand.ToString(), 10)}");
            Console.Write($"|{Common.padSides(car.year.ToString(), 16)}");
            Console.Write($"|{Common.padSides(car.price.ToString("N0"), 15)}");
            Console.Write($"|{Common.padSides(car.color.ToString(), 8)}");
            Console.Write($"|{Common.padSides(car.seat.ToString(), 9)}");
            Console.Write($"|{Common.padSides(car.engineType.ToString(), 12)}");
            Console.Write($"|{Common.padSides("".ToString(), 13)}");
            Console.WriteLine($"|{Common.padSides("".ToString(), 13)}|");
        }
    }
}

