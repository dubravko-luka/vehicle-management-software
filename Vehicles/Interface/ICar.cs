using System;
namespace Vehicles.Interface
{
	public interface ICar: IVehicle
	{
        void createCar(string brand, int year, double price, string color);

        void editCar(int id, string brand, int year, double price, string color);
    }
}

