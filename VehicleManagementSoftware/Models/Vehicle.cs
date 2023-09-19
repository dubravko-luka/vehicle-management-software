using System;

namespace VehicleManagementSoftware.Models
{
    public class Vehicle
    {
        // Attributes common
        public int id { get; set; }
        public int type { get; set; }
        public string brand { get; set; }
        public int year { get; set; }
        public double price { get; set; }
        public string color { get; set; }
        public DateTime createAt { get; set; }

        // Init
        public Vehicle(int _id, int _type, string _brand, int _year, double _price, string _color, DateTime _createAt)
        {
            id = _id;
            type = _type;
            brand = _brand;
            year = _year;
            price = _price;
            color = _color;
            createAt = _createAt;
        }

        public Vehicle()
        {
        }
    }
}

