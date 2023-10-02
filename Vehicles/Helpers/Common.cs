using System;

namespace Vehicles.Helpers
{
	public class Common
	{
        public static bool checkIsQuit(int key)
        {
            if (isQuit(key))
            {
                Console.Clear();
                Console.WriteLine("Tam biet, hen gap lai!");
                Thread.Sleep(2000);
                return true;
            }

            return false;
        }

        public static bool isQuit(int key)
        {
            if (key == Constants.KEY_QUIT)
            {
                return true;
            }

            return false;
        }

        public static bool checkIsContinute()
        {
            Console.Write("Nhap y tiep tuc: ");
            string continute = Console.ReadLine();
            if (continute == "y" || continute == "Y")
            {
                return true;
            }
            return false;
        }

        // Handle center the string
        public static string padSides(string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }

        // Check is number
        public static bool checkIsNumeric(string input)
        {
            if (input.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                Strings.notValid();
                return false;
            }
        }

        // Check menu valid
        public static bool checkValidSelectListString(int key, List<string> list)
        {
            if (key >= 0 && key <= list.Count())
            {
                return true;
            }
            Console.Clear();
            Console.WriteLine("Lua chon khong hop le, vui long thu lai!");
            return false;
        }

        public static int inputInt(string text)
        {
            string _number;
            do
            {
                Console.Write(text);
                _number = Console.ReadLine();
            } while (!Common.checkIsNumeric(_number) || _number == "");

            return int.Parse(_number);
        }

        public static double inputDouble(string text)
        {
            string _number;
            do
            {
                Console.Write(text);
                _number = Console.ReadLine();
            } while (!Common.checkIsNumeric(_number) || _number == "");

            return double.Parse(_number);
        }

        public static string inputString(string text)
        {
            string _string;
            do
            {
                Console.Write(text);
                _string = Console.ReadLine();
            } while (_string == "");

            return _string;
        }
    }
}
