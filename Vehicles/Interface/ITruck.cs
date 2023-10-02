using System;
namespace Vehicles.Interface
{
	public interface ITruck
	{
		void createTruck(string brand, int year, double price, string color);

		void editTruck(int id, string brand, int year, double price, string color);

        string toString();
    }
}

