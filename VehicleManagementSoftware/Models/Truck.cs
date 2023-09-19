using System;
namespace VehicleManagementSoftware.Models
{
	public class Truck : Vehicle
	{
        public string payload { get; set; }

        public Truck() : base()
        {
            //
        }

        public Truck(int _id, int _type, string _brand, int _year, double _price, string _color, string _payload, DateTime _createAt)
        : base(_id, _type, _brand, _year, _price, _color, _createAt)
        {
            payload = _payload;
        }
    }
}

