using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public class Dishwasher : Appliance
    {
        // public properties
        public string Feature { get; set; }
        public string SoundRating { get; set; }


        // constructor
        public Dishwasher(int itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : 
            base(itemNumber, brand, quantity, wattage, color, price)
        {
            SoundRating = soundRating;
            Feature = feature;
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
                $"Feature: {Feature}\n" +
                $"Sound Rating: {SoundRating}";
        }
    }
}
