using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public enum RoomTypeDisplay { K, W }
    public class Microwave : Appliance
    {
        // private data
        private double capacity;
        private RoomTypeDisplay roomType;

        // public properties
        public double Capacity { get { return capacity; } }
        public RoomTypeDisplay RoomType { get { return roomType; } }

        // constructor
        public Microwave(int itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, RoomTypeDisplay roomType) : 
            base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.capacity = capacity;
            this.roomType = roomType;
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
    }
}
