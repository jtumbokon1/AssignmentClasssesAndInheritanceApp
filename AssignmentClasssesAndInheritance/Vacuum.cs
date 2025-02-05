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
        // private data
        private int batteryVoltage;
        private string grade;


        // public properties
        public int BatteryVoltage { get { return batteryVoltage; } }
        public string Grade { get { return grade; } }

        // constructor
        public Vacuum(int itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int batteryVoltage) : 
            base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.batteryVoltage = batteryVoltage;
            this.grade = grade;
        }

        // public methods
        public void FormatForFile() 
        { 
        }

        public override string ToString() 
        {
            return "";
        }
    }
}
