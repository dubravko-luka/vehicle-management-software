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
                // Write new line with after all line in file
                File.AppendAllLines(Constants.PATH_FILE_DATABASE_VEHICLE, line);
            }
            catch (IOException e)
            {
                Console.WriteLine("");
            }
        }

        private void _initData()
        {
            // Check file if not found data in file -> generate data
            if (getAllVehicle().Count() <= 0)
            {
                Console.WriteLine("Generating data...");

                Random random = new Random();
                string[] colors = { "white", "black", "green" };
                string[] brands = { "honda", "yamaha", "hyundai" };

                for (int i = 1; i <= 10; i++)
                {
                    int randomIndex = random.Next(0, colors.Length);

                    // random car 1: car, 2: motobike, 3: truck
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
                    // Create with not same create_at
                    Thread.Sleep(500);
                }
                Console.Clear();
            }
        }

        public static List<Vehicle> getAllVehicle()
        {
            // Init list for three vehicle on the project
            List<Car> cars = new List<Car>();
            List<Motobike> motobikes = new List<Motobike>();
            List<Truck> trucks = new List<Truck>();

            // If file exists
            if (File.Exists(Constants.PATH_FILE_DATABASE_VEHICLE))
            {
                string[] lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE);
                foreach (string line in lines)
                {
                    // Convert line string to array string
                    string[] parts = line.Split(',');

                    // Veriable of vehicle (veriable common)
                    int id = int.Parse(parts[0]);

                    // Parse string to type vehicle `VEHICLE_TYPE_ENUM`
                    Enum.TryParse<Constants.VEHICLE_TYPE_ENUM>(parts[1], out Constants.VEHICLE_TYPE_ENUM type);
                    string brand = parts[2];
                    int year = int.Parse(parts[3]);
                    double price = double.Parse(parts[4]);
                    string color = parts[5];
                    DateTime createAt = DateTime.Parse(parts[6]);

                    // If line data of car
                    if (parts[1] == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.CAR))
                    {
                        int seat = int.Parse(parts[7]);
                        string engineType = parts[8];

                        Car car = new Car(id, type, brand, year, price, color, createAt, seat, engineType);
                        cars.Add(car);
                    }

                    // If line data of motobike
                    if (parts[1] == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.MOTOBIKE))
                    {
                        int wattage = int.Parse(parts[7]);
                        Motobike motobike = new Motobike(id, type, brand, year, price, color, createAt, wattage);
                        motobikes.Add(motobike);
                    }

                    // If line data of truck
                    if (parts[1] == Enum.GetName(typeof(Constants.VEHICLE_TYPE_ENUM), Constants.VEHICLE_TYPE_ENUM.TRUCK))
                    {
                        string payload = parts[7];
                        Truck truck = new Truck(id, type, brand, year, price, color, createAt, payload);
                        trucks.Add(truck);
                    }
                }
            }

            // Init list data for all vehicle: car, motobike, truck
            var allVehicles = new List<Vehicle>();

            allVehicles.AddRange(cars);
            allVehicles.AddRange(motobikes);
            allVehicles.AddRange(trucks);

            // Sort vehicle with id
            return allVehicles.OrderBy(item => item.id).ToList();
        }

        public static void delete(int id)
        {
            // Get list car form file
            List<string> lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE).ToList();

            bool idExists = false;

            // Remove line ->
            lines.RemoveAll(line =>
            {
                // Get id from line
                int _id = getId(line);

                // If id of line == id input user
                if (_id == id)
                {
                    idExists = true;
                    // Return true == remove line
                    return true;
                }
                return false;
            });


            // Rewrite all line to file
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
            // Convert string to array with `,`
            string[] parts = line.Split(',');

            // Line have character and parts[0] is id
            if (parts.Length > 0 && int.TryParse(parts[0], out int id))
            {
                return id;
            }
            return -1;
        }

        public static string getTypeStringId(int id)
        {

            // Get all line from file
            string[] lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE);

            string type = "";
            bool idExists = false;

            foreach (string line in lines) {
                string[] parts = line.Split(',');

                // If id input user == id line
                if (int.Parse(parts[0]) == id)
                {
                    idExists = true;
                    // Assign type with parts[1]
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
                // Get all line from file
                foreach (string line in File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE))
                {

                    // Get id
                    int id = getId(line);
                    if (id > maxId)
                    {
                        // Assign for max
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

                // If not found return id
                if (!found)
                {
                    return i;
                }
            }


            // If id missed not found then max id + 1
            return maxId + 1;
        }

        public static void edit(int idEdit, string newData)
        {
            List<string> lines = File.ReadAllLines(Constants.PATH_FILE_DATABASE_VEHICLE).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                int id = getId(lines[i]);

                // 
                if (id == idEdit)
                {
                    // Assign old data with new data
                    lines[i] = newData;

                    // Exists for
                    break;
                }
            }

            // Rewrite all data from file
            File.WriteAllLines(Constants.PATH_FILE_DATABASE_VEHICLE, lines);
        }
    }
}

