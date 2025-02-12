using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public class Refrigerator : Appliance
    {
        // public properties
        public int Doors { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        // constructor
        public Refrigerator(int itemNumber, string brand, int quantity, double wattage, string color, double price, int doors, double height, double width) :
            base(itemNumber, brand, quantity, wattage, color, price)
        {
            Doors = doors;
            Height = height;
            Width = width;
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
                $"Number of Doors: {Doors}\n" +
                $"Height: {Height}\n" +
                $"Width: {Width}";
        }
    }
}
