using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public enum applianceType { refrigerator, vacuum, microwave, dishwasher }
    public abstract class ModernAppliances
    {
        // constants
        private const string PATH = @"..\..\..\res\appliances.txt";
        private const char SEP = ';';

        // public methods
        public static List<Appliance> ReadAppliances()
        {
            List<Appliance> list = new List<Appliance>();
            StreamReader reader = new StreamReader(PATH);
            string? line;
            string[] fields;

            while ((line = reader.ReadLine()) != null)
            {
                fields = line.Split(SEP);
                // fields [0] = Item Number
                // fields [1] = Brand
                // fields [2] = Quantity
                // fields [3] = Wattage
                // fields [4] = Color
                // fields [5] = Price
                // fields [6] = Number of Doors, Grade, Capacity, Feature
                // fields [7] = Height, Batter Voltage, Room Type, Sound Rating
                // fields [8] = Width
                Appliance app = null;
                if (fields[0].StartsWith("1"))
                {
                    app = new Refrigerator(int.Parse(fields[0]),
                        fields[1],
                        int.Parse(fields[2]),
                        double.Parse(fields[3]),
                        fields[4],
                        double.Parse(fields[5]),
                        int.Parse(fields[6]),
                        double.Parse(fields[7]),
                        double.Parse(fields[8]));
                }
                else if (fields[0].StartsWith("2"))
                {
                    app = new Vacuum(int.Parse(fields[0]),
                        fields[1],
                        int.Parse(fields[2]),
                        double.Parse(fields[3]),
                        fields[4],
                        double.Parse(fields[5]),
                        fields[6],
                        int.Parse(fields[7]));
                }
                else if (fields[0].StartsWith("3"))
                {
                    app = new Microwave(int.Parse(fields[0]),
                        fields[1],
                        int.Parse(fields[2]),
                        double.Parse(fields[3]),
                        fields[4],
                        double.Parse(fields[5]),
                        double.Parse(fields[6]),
                        (RoomTypeDisplay)Enum.Parse(typeof(RoomTypeDisplay), fields[7]));
                }
                else if (fields[0].StartsWith("4"))
                {

                    app = new Dishwasher(int.Parse(fields[0]),
                        fields[1],
                        int.Parse(fields[2]),
                        double.Parse(fields[3]),
                        fields[4],
                        double.Parse(fields[5]),
                        fields[6],
                        (SoundRatingDisplay)Enum.Parse(typeof(SoundRatingDisplay), fields[7]));
                }
                list.Add(app);
            }
            return list;
        }

        public static void DisplayMenu()
        {
            Console.WriteLine($"Welcome to Modern Appliances!\n" +
            "How may we assist you?\n" +
            "1 - Check out appliance\n" +
            "2 - Find appliances by brand\n" +
            "3 - Display appliances by type\n" +
            "4 - Produce random appliance list\n" +
            "5 - Save & exit");
        }

        public static void Find()
        {
        }
    }// class
}// namespace
