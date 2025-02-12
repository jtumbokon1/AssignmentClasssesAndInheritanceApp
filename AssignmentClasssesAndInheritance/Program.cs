using System.Transactions;
using AssignmentClasssesAndInheritance;

class Program
{
    public static void Main()
    {
        Appliance.DisplayMenu();

        Console.WriteLine("Enter option:");
        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Appliance.Checkout();
                break;
            case "2":
                Appliance.Find();
                break;
            case "3":
                Appliance.Display();
                break;
            case "4":
                break;
            case "5":
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}

