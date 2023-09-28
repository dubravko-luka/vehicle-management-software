using System;
namespace Vehicles.Helpers
{
	public class Constants
    {
        public static string PATH_FILE_DATABASE_VEHICLE = "./Vehicle.txt";

        public static int KEY_QUIT = 0;

        public enum VEHICLE_TYPE_ENUM
        {
            CAR,
            MOTOBIKE,
            TRUCK
        }

        public static List<string> MENU_LIST = new List<string>();
        public static List<string> TYPE_VEHICLE_LIST = new List<string>();
        public static List<string> TYPE_GET_LIST = new List<string>();

        public Constants()
        {
            _createMenu();
            _createTypeVehicleList();
            _createGetVehicleList();
        }

        private void _createMenu()
        {
            MENU_LIST.Add("Them xe");
            MENU_LIST.Add("Xoa xe");
            MENU_LIST.Add("Sua thong tin xe");
            MENU_LIST.Add("Lay thong tin xe");
        }

        private void _createTypeVehicleList()
        {
            TYPE_VEHICLE_LIST.Add("Xe oto");
            TYPE_VEHICLE_LIST.Add("Xe may");
            TYPE_VEHICLE_LIST.Add("Xe tai");
        }

        private void _createGetVehicleList()
        {
            TYPE_GET_LIST.Add("Toan bo");
            TYPE_GET_LIST.Add("Theo mau");
            TYPE_GET_LIST.Add("Nam san xuat");
        }
    }
}

