using System;
using System.Collections;
using VehicleManagementSoftware.Helpers;
using VehicleManagementSoftware.Models;
using VehicleManagementSoftware.Data;

namespace VehicleManagementSoftware.Services
{
	public class VehicleService
	{
        // Type car is: Car, Motobike, Truck
        ArrayList typeCarKey = new ArrayList { 1, 2, 3 };

        // Type get list vehicle: All, color, year
        ArrayList menuListVehicleKey = new ArrayList { 1, 2, 3 };

        public VehicleService()
        {
            typeCarKey.Add(Common.keyExit);
            menuListVehicleKey.Add(Common.keyExit);
        }

        public void getVevicles()
        {
            Console.Clear();
            Common common = new Common();
            MenuService menuService = new MenuService();

            do
            {
                menuService.printMenuListCar();
                string choice;

                bool choiceInValid = true;

                do
                {
                    Console.Write("Lựa chọn của bạn: ");

                    choice = Console.ReadLine();

                    choiceInValid = !(_handleCheckSelectMenuListVehicle(choice));

                } while (choiceInValid);

                // 
                bool isQuit = common.handleCheckIsQuit(choice);

                if (isQuit)
                {
                    return;
                }

                switch (int.Parse(choice))
                {
                    case 1:
                        _getAllVehicle(int.Parse(choice), "");
                        break;
                    case 2:
                        Console.Write("Tìm màu xe: ");
                        string _color = Console.ReadLine();
                        _getAllVehicle(int.Parse(choice), _color);
                        break;
                    case 3:
                        Console.Write("Nhập năm sản xuất: ");
                        string _year = Console.ReadLine();
                        _getAllVehicle(int.Parse(choice), _year);
                        break;
                    default:
                        break;
                }
            } while (common.handleContinute());

        }

        private void _getAllVehicle(int choice, string _query)
        {
            Console.Clear();
            Console.WriteLine($"Danh sách xe {(choice == 2 ? "có màu " + _query : choice == 3 ? "có năm sản xuất trước năm " + _query : "")}:");
            Common.headerTableDataVehicle();

            foreach (var car in DataVehicle.sortItemsByCreatedDate())
            {
                if (choice == 1)
                {
                    _printVehicle(car);
                    Common.lineTableDataVehicle();
                }
                else if (choice == 2)
                {
                    if (car.color == _query)
                    {
                        _printVehicle(car);
                        Common.lineTableDataVehicle();
                    }
                }
                else
                {
                    if (car.year <= int.Parse(_query))
                    {
                        _printVehicle(car);
                        Common.lineTableDataVehicle();
                    }
                }
            }
        }

        private void _printVehicle(Vehicle vehicle)
        {
            switch (vehicle.type)
            {
                case 1:
                    CarService carService = new CarService();
                    carService.printCar((Car)vehicle);
                    break;
                case 2:
                    MotobikeService motobikeService = new MotobikeService();
                    motobikeService.printCar((Motobike)vehicle);
                    break;
                case 3:
                    TruckService truckService = new TruckService();
                    truckService.printCar((Truck)vehicle);
                    break;
                default:
                    break;
            }
        }

        public void createVehicle()
        {
            // Init variable
            Common common = new Common();
            MenuService menuService = new MenuService();

            // Check valid choice optional
            bool choiceInValid = true;

            // Type car: Eg: car, motobike, truck
            string choiceTypeVehicle;

            do
            {
                // 
                Console.Clear();
                menuService.headerMenuCeateCar();

                // Handle check valid choice type car
                do
                {
                    Console.Write("Dòng xe bạn muốn nhập: ");

                    choiceTypeVehicle = Console.ReadLine();

                    choiceInValid = !(_handleCheckSelectTypeVehicle(choiceTypeVehicle));

                } while (choiceInValid);

                // 
                bool isQuit = common.handleCheckIsQuit(choiceTypeVehicle);

                if (isQuit)
                {
                    return;
                }

                //
                _createVehicle(int.Parse(choiceTypeVehicle));

            } while (common.handleContinute());

            // Back to main menu
            Console.Clear();
        }

        private void _createVehicle(int choiceTypeVehicle)
        {
            // Input common variable
            Console.Write("Nhập hãng xe: ");
            string _brand = Console.ReadLine();

            Console.Write("Nhập năm sản xuất: ");
            string _year = Console.ReadLine();

            Console.Write("Nhập giá xe: ");
            string _price = Console.ReadLine();

            Console.Write("Nhập màu xe: ");
            string _color = Console.ReadLine();

            //
            switch (choiceTypeVehicle)
            {
                case 1:
                    CarService carService = new CarService();
                    carService.addCar(_brand, int.Parse(_year), int.Parse(_price), _color);
                    break;
                case 2:
                    MotobikeService motobikeService = new MotobikeService();
                    motobikeService.addCar(_brand, int.Parse(_year), int.Parse(_price), _color);
                    break;
                case 3:
                    TruckService truckService = new TruckService();
                    truckService.addCar(_brand, int.Parse(_year), int.Parse(_price), _color);
                    break;
                default: break;
            }
            Console.WriteLine("Đã thêm!");
        }

        private bool _handleCheckSelectTypeVehicle(string key)
        {
            foreach (int item in typeCarKey)
            {
                if (item == int.Parse(key))
                {
                    return true;
                }
            }
            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại:");
            return false;
        }

        private bool _handleCheckSelectMenuListVehicle(string key)
        {
            foreach (int item in menuListVehicleKey)
            {
                if (item == int.Parse(key))
                {
                    return true;
                }
            }
            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại:");
            return false;
        }
    }
}

