using System;
using Vehicles.Helpers;
using Vehicles.Interface;

namespace Vehicles.Models
{
	public abstract class Vehicle: IVehicle
	{
        public int id { get; set; }
        public Constants.VEHICLE_TYPE_ENUM type { get; set; }
        public string brand { get; set; }
        public int year { get; set; }
        public double price { get; set; }
        public string color { get; set; }
        public DateTime createAt { get; set; }

        public Vehicle() {}

        public Vehicle(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt)
        {
            this.id = id;
            this.type = type;
            this.brand = brand;
            this.year = year;
            this.price = price;
            this.color = color;
            this.createAt = createAt;
        }

        public abstract void create(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt);

        public abstract void edit(int id, Constants.VEHICLE_TYPE_ENUM type, string brand, int year, double price, string color, DateTime createAt);

        public string toString()
        {
            return $"{id},{type},{brand},{year},{price},{color},{createAt}";
        }
    }
}

