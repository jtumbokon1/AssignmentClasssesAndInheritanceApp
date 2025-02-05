using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public abstract class Appliance
    {
        // private data
        private string brand;
        private string color;
        private int itemNumber;
        private double price;
        private int quantity;
        private double wattage;

        // public properties
        public string Brand { get { return brand; } }
        public string Color { get { return color; } }
        public bool IsAvailable { get; set; }
        public int ItemNumber { get { return itemNumber; } }
        public double Price { get { return price; } }
        public int Quantity { get { return quantity; } }
        public string Type { get; set; }
        public double Wattage { get { return wattage; } }

        public Appliance(string brand, string color, int itemNumber, double price, int quantity, double wattage)
        {
            this.brand = brand;
            this.color = color;
            this.itemNumber = itemNumber;
            this.price = price;
            this.quantity = quantity;
            this.wattage = wattage;
        }
    }
}
