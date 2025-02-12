using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public class Microwave : Appliance
    {
        // public properties
        public double Capacity { get; set; }

        public string RoomType { get; set; }

        // constructor
        public Microwave(int itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomType) : 
            base(itemNumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            RoomType = roomType;
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
                $"Capacity: {Capacity}\n" +
                $"Room Type: {RoomType}";
        }
    } // class
} // namespace
