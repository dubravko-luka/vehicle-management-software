using System;

namespace Vehicles.Helpers
{
	public class Strings
	{
        public static void printMenu()
        {
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|                       MENU                     |");
            Console.WriteLine("+------------------------------------------------+");

            int index = 0;
            foreach(var menu in Constants.MENU_LIST)
            {
                index++;
                Console.WriteLine(padSidesMenu($"{index}. {menu}"));
            }
            Console.WriteLine(padSidesMenu($"{Constants.KEY_QUIT}. Thoat"));
            Console.WriteLine("+------------------------------------------------+");

            Console.Write("Lua chon cua ban: ");
        }

        private static string padSidesMenu(string str)
        {
            str = str.PadRight(20, ' ');
            return $"|{Common.padSides(str, 48)}|";
        }

        public static void printTypeVehicle()
        {
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|              DANH SACH CAC LOAI XE             |");
            Console.WriteLine("+------------------------------------------------+");
            int index = 0;
            foreach (var typeVehicle in Constants.TYPE_VEHICLE_LIST)
            {
                index++;
                Console.WriteLine(padSidesMenu($"{index}. {typeVehicle}"));
            }
            Console.WriteLine(padSidesMenu($"{Constants.KEY_QUIT}. Thoat"));
            Console.WriteLine("+------------------------------------------------+");

            Console.Write("Lua chon cua ban: ");
        }

        public static void printTypeGetListVehicle()
        {
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|                BAN MUON TIM THEO               |");
            Console.WriteLine("+------------------------------------------------+");
            int index = 0;
            foreach (var typeGetList in Constants.TYPE_GET_LIST)
            {
                index++;
                Console.WriteLine(padSidesMenu($"{index}. {typeGetList}"));
            }
            Console.WriteLine(padSidesMenu($"{Constants.KEY_QUIT}. Thoat"));
            Console.WriteLine("+------------------------------------------------+");

            Console.Write("Lua chon cua ban: ");
        }

        public static void notValid()
        {
            Console.Clear();
            Console.WriteLine("Lua chon khong hop le, vui long thu lai!");
        }

        public static void headerTableDataVehicle()
        {
            Console.WriteLine("+-----------+----+----------+----------------+---------------+--------+---------+------------+-------------+-------------+");
            Console.WriteLine("|  Loai xe  | ID |  Brand   | Nam san xuat   |   Gia         | Mau    | So ghe  | Dong co    | Cong suat   | Tai trong   |");
            Console.WriteLine("+-----------+----+----------+----------------+---------------+--------+---------+------------+-------------+-------------+");
        }

        public static void tableNotFound()
        {
            Console.WriteLine("|                                             Khong tim thay san pham nao                                                |");
        }

        public static void lineTableDataVehicle()
        {
            Console.WriteLine("+-----------+----+----------+----------------+---------------+--------+---------+------------+-------------+-------------+");
        }
    }
}

