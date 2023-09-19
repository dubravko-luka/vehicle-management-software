using System;
using VehicleManagementSoftware.Services;

namespace VehicleManagementSoftware.Routes
{
	public class Route
	{
		public void direction(string _route)
		{
			int route = int.Parse(_route);
            VehicleService vehicleService = new VehicleService();

            switch (route)
            {
                case 1:
                    vehicleService.createVehicle();
                    break;
                case 2:
                    Console.WriteLine("Bạn đã chọn xoá xe.");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Bạn đã chọn sửa thông tin xe.");
                    Console.ReadLine();
                    break;
                case 4:
                    vehicleService.getVevicles();
                    break;
                default:
                    break;
            }
        }
	}
}

