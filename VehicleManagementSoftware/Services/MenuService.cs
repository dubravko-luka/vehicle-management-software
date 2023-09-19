using System;
using System.Collections;
using VehicleManagementSoftware.Helpers;

namespace VehicleManagementSoftware.Services
{
	public class MenuService
    {
        ArrayList menuKey = new ArrayList { 1, 2, 3, 4};

        public MenuService()
        {
            menuKey.Add(Common.keyExit);
        }

        public void printMenu()
		{
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|                       MENU                     |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine(padSidesMenu("1. Thêm xe"));
            Console.WriteLine(padSidesMenu("2. Xoá xe"));
            Console.WriteLine(padSidesMenu("3. Sửa thông tin xe"));
            Console.WriteLine(padSidesMenu("4. Xem danh sách xe"));
            Console.WriteLine(padSidesMenu($"{Common.keyExit}. Thoát"));
            Console.WriteLine("+------------------------------------------------+");
            Console.Write("Lựa chọn của bạn: ");
        }

        public void headerMenuCeateCar()
        {
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|                    THÊM XE                     |");
            Console.WriteLine("+------------------------------------------------+");
            _printTypeVehicle();
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine();
        }

        private void _printTypeVehicle()
        {
            Console.WriteLine(padSidesMenu("DANH SÁCH CÁC LOẠI "));
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine(padSidesMenu("1: Xe ô tô"));
            Console.WriteLine(padSidesMenu("2: Xe máy"));
            Console.WriteLine(padSidesMenu("3: Xe tải"));
            Console.WriteLine(padSidesMenu($"{Common.keyExit}: Trở về"));
        }

        public void printMenuListCar()
        {
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|            BẠN MUỐN LẤY DANH SÁCH XE           |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine(padSidesMenu("1: Toàn bộ"));
            Console.WriteLine(padSidesMenu("2: Theo màu xe"));
            Console.WriteLine(padSidesMenu("3: Theo năm sản xuất"));
            Console.WriteLine(padSidesMenu($"{Common.keyExit}: Trở về"));
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine();
        }

        private string padSidesMenu(string str)
        {
            str = str.PadRight(20, ' ');
            return $"|{Common.padSides(str, 48)}|";
        }

        public bool handleCheckSelectMenu(string key)
        {
            foreach (int item in menuKey)
            {
                if (item == int.Parse(key))
                {
                    return true;
                }
            }
            Console.Clear();
            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại:");
            return false;
        }

    }
}

