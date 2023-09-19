using System;
using VehicleManagementSoftware.Routes;
using VehicleManagementSoftware.Services;
using VehicleManagementSoftware.Data;
using VehicleManagementSoftware.Helpers;

class Program
{
    static void Main()
    {
        new DataVehicle();

        while (true)
        {
            // Init
            MenuService menu = new MenuService();
            Common common = new Common();

            // Print menu
            menu.printMenu();

            // Select function
            string choice = Console.ReadLine();

            // Check valid select require menu
            bool isValidChoice = menu.handleCheckSelectMenu(choice);

            if (isValidChoice)
            {
                // Check is quit
                bool isQuit = common.handleCheckIsQuit(choice);

                if (isQuit)
                {
                    Console.WriteLine("Tạm biệt, hẹn gặp lại!");
                    Thread.Sleep(1000);
                    return;
                }

                // Router
                if (isValidChoice)
                {
                    Route route = new Route();
                    route.direction(choice);
                }
            }
        }
    }
}
