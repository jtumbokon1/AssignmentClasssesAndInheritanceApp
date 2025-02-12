using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public class Vacuum : Appliance
    {
        // public properties
        public int BatteryVoltage { get; set; }
        public string Grade { get; set; }

        // constructor
        public Vacuum(int itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int batteryVoltage) : 
            base(itemNumber, brand, quantity, wattage, color, price)
        {
            BatteryVoltage = batteryVoltage;
            Grade = grade;
        }

        // public methods
        public override string ToString() 
        {
            return $"Item Number: {ItemNumber}\n" +
                $"Brand: {Brand}\n" +
                $"Quantity: {Quantity}\n" +
                $"Wattage: {Wattage}\n" +
                $"Color: {Color}\n" +
                $"Price: {Price}\n" +
                $"Grade: {Grade}\n" +
                $"Battery Voltage: {BatteryVoltage}";
        }
    }
}
