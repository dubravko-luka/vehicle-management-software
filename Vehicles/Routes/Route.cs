using System;
using Vehicles.Services;

namespace Vehicles.Routes
{
	public class Route
	{
		public static void direction(int _route)
		{
            VehicleService vehicleService = new VehicleService();

            switch (_route)
            {
                case 1:
                    vehicleService.create();
                    break;
                case 2:
                    vehicleService.delete();
                    break;
                case 3:
                    vehicleService.edit();
                    break;
                case 4:
                    vehicleService.read();
                    break;
                default:
                    break;
            }
        }
	}
}

