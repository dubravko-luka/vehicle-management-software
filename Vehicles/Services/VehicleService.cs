using System;
using Vehicles.Helpers;
using Vehicles.Models;
using Vehicles.Database;
using System.Runtime.ConstrainedExecution;

namespace Vehicles.Services
{
	public class VehicleService
    {
		public VehicleService()
		{
		}

		public void create()
		{
            int choice = 0;

            do
			{
                Console.Clear();
                string _choice;
                bool choiceValid = true;

                // Input and validate the user's choice for vehicle type
                do
                {
                    Strings.printTypeVehicle();
                    _choice = Console.ReadLine();
                    if (Common.checkIsNumeric(_choice))
                    {
                        choice = int.Parse(_choice);
                        choiceValid = !(Common.checkValidSelectListString(choice, Constants.TYPE_VEHICLE_LIST));
                    }
                } while (choiceValid);

                // Check if the user wants to quit
                if (Common.isQuit(choice))
                {
                    Console.Clear();
                    return;
                }

                _create(choice);

            } while (Common.checkIsContinute());
            Console.Clear();
        }

        public void _create(int choice)
        {
            // Input common variable
            string brand = Common.inputString("Hang xe: ");
            string color = Common.inputString("Mau xe: ");
            int year = Common.inputInt("Nam san xuat: ");
            double price = Common.inputDouble("Gia xe: ");

            // Create a vehicle object based on the user's choice
            switch (choice)
            {
                case 1:
                    Car car = new Car();
                    car.createCar(brand, year, price, color);
                    break;
                case 2:
                    Motobike motobike = new Motobike();
                    motobike.createMotobike(brand, year, price, color);
                    break;
                case 3:
                    Truck truck = new Truck();
                    truck.createTruck(brand, year, price, color);
                    break;
                default:
                    break;
            }
        }

        public void read()
        {
            int choice = 0;

            do
            {
                Console.Clear();
                string _choice;
                bool choiceValid = true;

                do
                {
                    Strings.printTypeGetListVehicle();
                    _choice = Console.ReadLine();

                    if (Common.checkIsNumeric(_choice))
                    {

                        choice = int.Parse(_choice);
                        choiceValid = !(Common.checkValidSelectListString(choice, Constants.TYPE_GET_LIST));
                    }
                } while (choiceValid);

                if (Common.isQuit(choice))
                {
                    Console.Clear();
                    return;
                }

                Console.Clear();

                _read(choice);

            } while (Common.checkIsContinute());
            Console.Clear();
        }

        private void _read(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Danh sach xe:");
                    getAll(choice, "");
                    break;
                case 2:
                    string color = Common.inputString("Tim mau xe: ");
                    Console.WriteLine($"Danh sach co mau {color}:");
                    getAll(choice, color);
                    break;
                case 3:
                    string year = Common.inputString("Nhap nam san xuat: ");
                    Console.WriteLine($"Danh sach xe co nam san xuat truoc {year}:");
                    getAll(choice, year);
                    break;
                default:
                    break;
            }
        }

        private void getAll(int typeQuery, string query)
        {
            Data.getAllVehicle();
            Strings.headerTableDataVehicle();
            int count = 0;
            foreach (var vehicle in Data.getAllVehicle())
            {

                if (typeQuery == 1)
                {
                    _printVehicle(vehicle);
                    count++;
                    Strings.lineTableDataVehicle();
                }
                if (typeQuery == 2)
                {
                    if (vehicle.color == query)
                    {
                        count++;
                        _printVehicle(vehicle);
                        Strings.lineTableDataVehicle();
                    }
                }
                if (typeQuery == 3)
                {
                    if (vehicle.year <= int.Parse(query))
                    {
                        count++;
                        _printVehicle(vehicle);
                        Strings.lineTableDataVehicle();
                    }
                }
            }

            if (count == 0)
            {
                Strings.tableNotFound();
                Strings.lineTableDataVehicle();
            }
        }

        private void _printVehicle(Vehicle vehicle)
        {
            if (vehicle.type == Constants.VEHICLE_TYPE_ENUM.CAR)
            {
                Car.printCar((Car)vehicle);
            }
            if (vehicle.type == Constants.VEHICLE_TYPE_ENUM.MOTOBIKE)
            {
                Motobike.printCar((Motobike)vehicle);
            }
            if (vehicle.type == Constants.VEHICLE_TYPE_ENUM.TRUCK)
            {
                Truck.printCar((Truck)vehicle);
            }
        }

        public void delete()
        {
            string choice;

            do
            {
                Console.Clear();
                _read(1);
                do
                {
                    Console.Write("Nhap id can xoa, nhap 0 de tro ve: ");
                    choice = Console.ReadLine();
                } while (!Common.checkIsNumeric(choice));



                if (Common.isQuit(int.Parse(choice)))
                {
                    Console.Clear();
                    return;
                }

                Data.delete(int.Parse(choice));

            } while (Common.checkIsContinute());
            Console.Clear();
        }

        public void edit()
        {
            string id;

            do
            {
                Console.Clear();
                _read(1);
                do
                {
                    Console.Write("Nhap id can sua, nhap 0 de tro ve: ");
                    id = Console.ReadLine();
                } while (!Common.checkIsNumeric(id));

                if (Common.isQuit(int.Parse(id)))
                {
                    Console.Clear();
                    return;
                }
                string type = Data.getTypeStringId(int.Parse(id));

                if (type == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.CAR))
                {
                    _edit(1, int.Parse(id));
                }
                if (type == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.MOTOBIKE))
                {
                    _edit(2, int.Parse(id));
                }
                if (type == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.TRUCK))
                {
                    _edit(3, int.Parse(id));
                }

            } while (Common.checkIsContinute());
            Console.Clear();
        }

        public void _edit(int choice, int id)
        {
            // Input common variable
            string brand = Common.inputString("Hang xe: ");
            string color = Common.inputString("Mau xe: ");
            int year = Common.inputInt("Nam san xuat: ");
            double price = Common.inputDouble("Gia xe: ");

            switch (choice)
            {
                case 1:
                    Car car = new Car();
                    car.editCar(id, brand, year, price, color);
                    break;
                case 2:
                    Motobike motobike = new Motobike();
                    motobike.editMotobike(id, brand, year, price, color);
                    break;
                case 3:
                    Truck truck = new Truck();
                    truck.editTruck(id, brand, year, price, color);
                    break;
                default:
                    break;
            }
        }
    }
}
