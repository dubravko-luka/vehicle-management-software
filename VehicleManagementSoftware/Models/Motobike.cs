using System;
namespace VehicleManagementSoftware.Models
{
	public class Motobike : Vehicle
	{
        public int wattage { get; set; }

        public Motobike() : base()
        {
            //
        }

        public Motobike(int _id, int _type, string _brand, int _year, double _price, string _color, int _wattage, DateTime _createAt)
        : base(_id, _type, _brand, _year, _price, _color, _createAt)
        {
            wattage = _wattage;
        }
    }
}

