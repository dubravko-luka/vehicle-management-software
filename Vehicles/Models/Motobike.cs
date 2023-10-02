using System;
using Vehicles.Database;
using Vehicles.Helpers;
using Vehicles.Interface;

namespace Vehicles.Models
{
	public class Motobike : Vehicle, IMotobike
    {
        public int wattage { get; set; }

        public Motobike() { }

        public Motobike(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt, int wattage) : base(id, type, brand, year, price, color, createAt)
        {
            this.wattage = wattage;
        }

        public void createMotobike(string brand, int year, double price, string color)
        {
            create(Data.getNextId(), Constants.VEHICLE_TYPE_ENUM.MOTOBIKE, brand, year, price, color, DateTime.Now);
        }

        public override void create(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt)
        {
            int _wattage = Common.inputInt("Cong suat: ");
            Motobike motobike = new Motobike(id, type, brand, year, price, color, createAt, _wattage);
            Data.addData(motobike.toString());
        }

        public void editMotobike(int id, string brand, int year, double price, string color)
        {
            edit(id, Constants.VEHICLE_TYPE_ENUM.MOTOBIKE, brand, year, price, color, DateTime.Now);
        }

        public override void edit(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt)
        {
            int _wattage = Common.inputInt("Cong suat: ");
            Motobike motobike = new Motobike(id, type, brand, year, price, color, createAt, _wattage);
            Data.edit(id, motobike.toString());
        }

        public string toString()
        {
            return $"{base.toString()},{wattage}";
        }

        public static void printCar(Motobike motobike)
        {
            Console.Write($"|{Common.padSides("Xe may".ToString(), 11)}");
            Console.Write($"|{Common.padSides(motobike.id.ToString(), 4)}");
            Console.Write($"|{Common.padSides(motobike.brand.ToString(), 10)}");
            Console.Write($"|{Common.padSides(motobike.year.ToString(), 16)}");
            Console.Write($"|{Common.padSides(motobike.price.ToString("N0"), 15)}");
            Console.Write($"|{Common.padSides(motobike.color.ToString(), 8)}");
            Console.Write($"|{Common.padSides("".ToString(), 9)}");
            Console.Write($"|{Common.padSides("".ToString(), 12)}");
            Console.Write($"|{Common.padSides(motobike.wattage.ToString(), 13)}");
            Console.WriteLine($"|{Common.padSides("".ToString(), 13)}|");
        }
    }
}

