using System;
using Vehicles.Helpers;
using Vehicles.Routes;
using Vehicles.Database;

class Program
{
    static void Main()
    {
        new Constants();
        new Data(true);

        // Start an infinite loop
        while (true)
        {
            // Display the menu
            Strings.printMenu();

            // Read the user's input
            string choice = Console.ReadLine();

            // Check if the input is numeric
            if (Common.checkIsNumeric(choice))
            {
                int _choice = int.Parse(choice);

                // Check if the user wants to quit
                if (Common.checkIsQuit(_choice))
                {
                    return;
                }

                // Check if the user's choice is valid
                if (Common.checkValidSelectListString(_choice, Constants.MENU_LIST))
                {
                    // Handle the user's choice
                    Route.direction(_choice);
                }
            } else
            {
                Strings.notValid();
            }
        }
    }
}