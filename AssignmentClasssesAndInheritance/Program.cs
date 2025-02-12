/*
 * CPRG-211-C Assignment: Classes and Inheritance
 * Author: Jirch Tumbokon, Ethan Jones, Elliot Jost, Iyat Aljabery
 * When: Winter 2025
 * 
 * This program creates a list using the txt file provided,
 * then allows user to select options that allow them to
 * check out an appliance by item number, find appliance by brand,
 * display appliances by type, generate a random appliance and lastly
 * save the information back to the appliances.txt file
 */


using System.Transactions;
using AssignmentClasssesAndInheritance;

class Program
{
    public static void Main()
    {
        Appliance.DisplayMenu(); // display the menu

        Console.WriteLine("Enter option:");
        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Appliance.Checkout(); // check out an appliance by item number
                break;
            case "2":
                Appliance.Find(); // find appliance by brand
                break;
            case "3":
                Appliance.Display(); // display appliance types and its matching items
                break;
            case "4":
                Appliance.RandomAppliance(); // generate a random appliance according to a certain amount
                break;
            case "5":
                List<Appliance> list = Appliance.ReadAppliances();
                Appliance.SaveData(list); // save data and persist to the appliances.txt file
                break;
            default: // Error, option not valid
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    } // main
} // class

