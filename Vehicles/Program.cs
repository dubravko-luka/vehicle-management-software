using System;
using System.IO;
using Vehicles.Helpers;
using Vehicles.Routes;
using Vehicles.Database;

class Program
{
    static void Main()
    {
        new Constants();
        new Data(true);

        while (true)
        {
            Strings.printMenu();

            string choice = Console.ReadLine();

            if (Common.checkIsNumeric(choice))
            {
                int _choice = int.Parse(choice);
                if (Common.checkIsQuit(_choice))
                {
                    return;
                }
                if (Common.checkValidSelectListString(_choice, Constants.MENU_LIST))
                {
                    Route.direction(_choice);
                }
            } else
            {
                Strings.notValid();
            }
        }
    }
}