using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;

namespace VehicleManagementSoftware.Models
{
	public class Car : Vehicle
	{
        public int seat { get; set; }
        public string engineType { get; set; }

        public Car() : base()
        {
            // Mã khởi tạo mặc định của Car
        }

        public Car(int _id, int _type, string _brand, int _year, double _price, string _color, int _seat, string _engineType, DateTime _createAt)
        : base(_id, _type, _brand, _year, _price, _color, _createAt)
        {
            seat = _seat;
            engineType = _engineType;
        }
    }
}

