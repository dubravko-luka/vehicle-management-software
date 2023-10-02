using System;
using Vehicles.Helpers;
using Vehicles.Models;

namespace Vehicles.Interface
{
    public interface IMotobike: IVehicle
    {
        void createMotobike(string brand, int year, double price, string color);

        void editMotobike(int id, string brand, int year, double price, string color);
    }
}

