using System.Transactions;
using AssignmentClasssesAndInheritance;

class Program
{
    public static void Main()
    {
        ModernAppliances.DisplayMenu();

        Console.WriteLine("Enter option:");
        string? option = Console.ReadLine();

        switch (option)
        {
            case "1": // Refrigerator
                ModernAppliances.Checkout();
                break;
            case "2":
                ModernAppliances.Find();
                break;
        }
    }
}
