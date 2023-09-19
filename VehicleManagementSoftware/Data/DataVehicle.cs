using System;
using VehicleManagementSoftware.Models;

namespace VehicleManagementSoftware.Data
{
	public class DataVehicle
    {
        public static List<Car> cars { get; } = new List<Car>();
        public static List<Motobike> motobikes { get; } = new List<Motobike>();
        public static List<Truck> trucks { get; } = new List<Truck>();
        public static int nextId { get; set; } = 1;

        public DataVehicle()
        {

            // Init data
            _initData();
        }

        public static List<Vehicle> allVehicle()
        {
            var allVehicles = new List<Vehicle>();

            allVehicles.AddRange(cars);
            allVehicles.AddRange(motobikes);
            allVehicles.AddRange(trucks);

            return allVehicles;
        }

        public static List<Vehicle> sortItemsByCreatedDate()
        {
            return allVehicle().OrderBy(item => item.createAt).ToList();
        }

        private void _initData() {
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
                    Car car = new Car(nextId++, randomTypeCar, brands[randomIndex], random.Next(1950, 2001), random.Next(1000000000, 2000000000), colors[randomIndex], random.Next(4, 17), "diesel", DateTime.Now);
                    cars.Add(car);
                }
                if (randomTypeCar == 2)
                {
                    Motobike motobike = new Motobike(nextId++, randomTypeCar, brands[randomIndex], random.Next(1950, 2001), random.Next(1000000000, 2000000000), colors[randomIndex], random.Next(150, 300), DateTime.Now);
                    motobikes.Add(motobike);
                }
                if (randomTypeCar == 3)
                {
                    Truck truck = new Truck(nextId++, randomTypeCar, brands[randomIndex], random.Next(1950, 2001), random.Next(1000000000, 2000000000), colors[randomIndex], "10 tấn", DateTime.Now);
                    trucks.Add(truck);
                }
                // Create with create_at
                Thread.Sleep(500);
            }
            Console.Clear();
        }
    }
}

