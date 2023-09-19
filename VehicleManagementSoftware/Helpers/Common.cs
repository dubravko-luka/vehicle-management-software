using System;

namespace VehicleManagementSoftware.Helpers
{
	public class Common
	{

        public static int keyExit { get; } = 0;

        public bool handleCheckIsQuit(string key)
        {
            if (int.Parse(key) == keyExit)
            {
                Console.Clear();
                return true;
            }

            return false;
        }

        public bool handleContinute()
        {
            Console.Write("Bạn có muốn tiếp tục? (y/n): ");
            string continute = Console.ReadLine();
            if (continute == "y" || continute == "Y")
            {
                return true;
            }
            return false;
        }

        public static string padSides(string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }

        public static void headerTableDataVehicle()
        {
            Console.WriteLine("+-----------+----+----------+----------------+-------------+--------+---------+------------+-------------+-------------+");
            Console.WriteLine("|  Loại xe  | ID |  Brand   | Năm sản xuất   | Giá         | Màu    | Số ghế  | Động cơ    | Công suất   | Tải trọng   |");
            Console.WriteLine("+-----------+----+----------+----------------+-------------+--------+---------+------------+-------------+-------------+");
        }

        public static void lineTableDataVehicle()
        {
            Console.WriteLine("+-----------+----+----------+----------------+-------------+--------+---------+------------+-------------+-------------+");
        }
    }
}
