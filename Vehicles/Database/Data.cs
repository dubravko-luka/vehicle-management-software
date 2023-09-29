using System;
using System.Runtime.ConstrainedExecution;
using Vehicles.Helpers;
using Vehicles.Models;
using static Vehicles.Helpers.Constants;

namespace Vehicles.Database
{
	public class Data
	{
        public Data() { }

		public Data(bool init)
		{
            if (init)
            {
                _handleCheckFile();
                _initData();
            }
        }

		private void _handleCheckFile()
		{
            // If file not exists
            if (!File.Exists(Constants.PATH_FILE_DATABASE_VEHICLE))
            {
                // Create file
                File.WriteAllText(Constants.PATH_FILE_DATABASE_VEHICLE, "");
            }
        }

		public static void addData(string text)
		{
            string[] line = new string[] { text };
            try
            {
                File.AppendAllLines(Constants.PATH_FILE_DATABASE_VEHICLE, line);
            }
            catch (IOException e)
            {
                Console.WriteLine("");
            }
        }

        private void _initData()
        {
            if (getAllVehicle().Count() <= 0)
            {
                Console.WriteLine("Generating data...");
                Random random = new Random();
                string[] colors = { "white", "black", "green" };
                string[] brands = { "honda", "yamaha", "hyundai" };

                for (int i = 1; i <= 10; i++)
                {
                    int randomIndex = random.Next(0, colors.Length);
                    int randomTypeCar = random.Next(1, 4);

                    if (randomTypeCar == 1)
                    {
                        Car car = new Car(i, Constants.VEHICLE_TYPE_ENUM.CAR, brands[randomIndex], random.Next(1950, 2001), random.Next(1000000000, 2000000000), colors[randomIndex], DateTime.Now, random.Next(4, 32), "diesel");
                        addData(car.toString());
                    }
                    if (randomTypeCar == 2)
                    {
                        Motobike motobike = new Motobike(i, Constants.VEHICLE_TYPE_ENUM.MOTOBIKE, brands[randomIndex], random.Next(1950, 2001), random.Next(1000000000, 2000000000), colors[randomIndex], DateTime.Now, random.Next(150, 300));
                        addData(motobike.toString());
                    }
                    if (randomTypeCar == 3)
                    {
                        Truck truck = new Truck(i, Constants.VEHICLE_TYPE_ENUM.TRUCK, brands[randomIndex], random.Next(1950, 2001), random.Next(1000000000, 2000000000), colors[randomIndex], DateTime.Now, $"{random.Next(4, 32)} tan");
                        addData(truck.toString());
                    }
                    // Create with create_at
                    Thread.Sleep(500);
                }
                Console.Clear();
            }
        }

        public static List<Vehicle> getAllVehicle()
        {
            List<Car> cars = new List<Car>();
            List<Motobike> motobikes = new List<Motobike>();
            List<Truck> trucks = new List<Truck>();

            if (File.Exists(Constants.PATH_FILE_DATABASE_VEHICLE))
            {
                string[] lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE);
                foreach (string line in lines)
                {
                    // Convert line string to array string
                    string[] parts = line.Split(',');

                    // Veriable of vehicle
                    int id = int.Parse(parts[0]);
                    Enum.TryParse<Constants.VEHICLE_TYPE_ENUM>(parts[1], out Constants.VEHICLE_TYPE_ENUM type);
                    string brand = parts[2];
                    int year = int.Parse(parts[3]);
                    double price = double.Parse(parts[4]);
                    string color = parts[5];
                    DateTime createAt = DateTime.Parse(parts[6]);

                    if (parts[1] == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.CAR))
                    {
                        int seat = int.Parse(parts[7]);
                        string engineType = parts[8];

                        Car car = new Car(id, type, brand, year, price, color, createAt, seat, engineType);
                        cars.Add(car);
                    }
                    if (parts[1] == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.MOTOBIKE))
                    {
                        int wattage = int.Parse(parts[7]);
                        Motobike motobike = new Motobike(id, type, brand, year, price, color, createAt, wattage);
                        motobikes.Add(motobike);
                    }
                    if (parts[1] == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.TRUCK))
                    {
                        string payload = parts[7];
                        Truck truck = new Truck(id, type, brand, year, price, color, createAt, payload);
                        trucks.Add(truck);
                    }
                }
            }

            var allVehicles = new List<Vehicle>();

            allVehicles.AddRange(cars);
            allVehicles.AddRange(motobikes);
            allVehicles.AddRange(trucks);

            return allVehicles.OrderBy(item => item.id).ToList();
        }

        public static void delete(int id)
        {
            List<string> lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE).ToList();

            bool idExists = false;

            lines.RemoveAll(line =>
            {
                int _id = getId(line);
                if (_id == id)
                {
                    idExists = true;
                    return true;
                }
                return false;
            });
            File.WriteAllLines(Constants.PATH_FILE_DATABASE_VEHICLE, lines);

            Console.Clear();
            if (idExists)
            {
                Console.WriteLine("Da xoa!");
            }
            else
            {
                Console.WriteLine("Khong tim thay du lieu!");
            }
        }

        static int getId(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length > 0 && int.TryParse(parts[0], out int id))
            {
                return id;
            }
            return -1;
        }

        public static string getTypeStringId(int id)
        {
            string[] lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE);

            string type = "";
            bool idExists = false;

            foreach (string line in lines) {
                string[] parts = line.Split(',');
                if (int.Parse(parts[0]) == id)
                {
                    idExists = true;
                    type = parts[1];
                }
            }

            if (!idExists)
            {
                Console.WriteLine("Khong tim thay du lieu!");
            }

            return type;
        }

        public static int getNextId()
        {
            int maxId = 0;

            // Get max id in file
            if (File.Exists(Constants.PATH_FILE_DATABASE_VEHICLE))
            {
                foreach (string line in File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE))
                {
                    int id = getId(line);
                    if (id > maxId)
                    {
                        maxId = id;
                    }
                }
            }

            // Get id missed
            for (int i = 1; i <= maxId + 1; i++)
            {
                bool found = false;
                foreach (string line in File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE))
                {
                    int id = getId(line);
                    if (id == i)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return i;
                }
            }

            return maxId + 1;
        }

        public static void edit(int idEdit, string newData)
        {
            List<string> lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                int id = getId(lines[i]);
                if (id == idEdit)
                {
                    lines[i] = newData;
                    break;
                }
            }

            File.WriteAllLines(Constants.PATH_FILE_DATABASE_VEHICLE, lines);
        }
    }
}

