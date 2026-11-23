using System;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        string jsonText = File.ReadAllText("Car_Owners.json");
        List<Owner> owners = JsonSerializer.Deserialize<List<Owner>>(jsonText);
        Console.WriteLine();

        // Show the menu ONCE, before looping through the owners
        Console.WriteLine("========== MAIN MENU ==========");
        Console.WriteLine("Choose one of the following options: \n1) Display All Owner Info\n2) Filter Owner Info By Color");
        int option = Convert.ToInt16(Console.ReadLine());

        if (option == 1)
        {
            Console.WriteLine("\n---------- ALL CAR OWNER INFORMATION ----------\n");

            foreach (Owner owr in owners)
            {
                DisplayAllOwnerInfo(owr);
            }
        }

        else if (option == 2)
        {
            Console.WriteLine("Which color would you like to filter by?");
            string filterColor = Console.ReadLine();
            string capFilterColor = filterColor.ToUpper();

            Console.WriteLine($"\n---------- ALL {capFilterColor} CAR OWNER INFORMATION ----------\n");

            foreach (Owner owr in owners)
            {
                if (owr.Color.ToLower() == filterColor.ToLower())
                {
                    DisplayAllOwnerInfo(owr);
                }
            }
        }

        else
        {
            Console.WriteLine("Please choose an option between 1 and 2.");
        }
    }

    static void DisplayAllOwnerInfo(Owner owr)
    {
        Console.WriteLine($"firstname: {owr.FirstName}");
        Console.WriteLine($"lastname: {owr.LastName}");
        Console.WriteLine($"make: {owr.Make}");
        Console.WriteLine($"model: {owr.Model}");
        Console.WriteLine($"year: {owr.Year}");
        Console.WriteLine($"color: {owr.Color}");
        Console.WriteLine();
    }
}