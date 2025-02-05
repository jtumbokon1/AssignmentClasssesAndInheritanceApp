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

        public Appliance(int itemNumber, string brand, int quantity, double wattage, string color,  double price)
        {
            this.itemNumber = itemNumber;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.color = color;       
            this.price = price;
        }
    }
}
