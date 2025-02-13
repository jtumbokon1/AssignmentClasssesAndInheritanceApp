using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public abstract class Appliance
    {
        // public properties
        public string Brand { get; set; }
        public string Color { get; set; }
        public int ItemNumber { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public double Wattage { get; set; }

        public Appliance(int itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }

        private const string PATH = @"..\..\..\res\appliances.txt";
        private const char SEP = ';';

        // public methods
        public static List<Appliance> ReadAppliances()
        {
            List<Appliance> list = new List<Appliance>();
            StreamReader reader = new StreamReader(PATH);
            string? line;
            string[] fields;

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                fields = line.Split(SEP);
                // fields [0] = Item Number
                // fields [1] = Brand
                // fields [2] = Quantity
                // fields [3] = Wattage
                // fields [4] = Color
                // fields [5] = Price
                // fields [6] = Number of Doors, Grade, Capacity, Feature
                // fields [7] = Height, Battery Voltage, Room Type, Sound Rating
                // fields [8] = Width
                Appliance? app = null;
                if (fields[0].StartsWith("1")) // refrigerator
                {
                    app = new Refrigerator(
                        Convert.ToInt32(fields[0]),
                        fields[1],
                        Convert.ToInt32(fields[2]),
                        Convert.ToDouble(fields[3]),
                        fields[4],
                        Convert.ToDouble(fields[5]),
                        Convert.ToInt32(fields[6]),
                        Convert.ToDouble(fields[7]),
                        Convert.ToDouble(fields[8]));
                }
                else if (fields[0].StartsWith("2")) // vacuum
                {
                    app = new Vacuum(
                        Convert.ToInt32(fields[0]),
                        fields[1],
                        Convert.ToInt32(fields[2]),
                        Convert.ToDouble(fields[3]),
                        fields[4],
                        Convert.ToDouble(fields[5]),
                        fields[6],
                        Convert.ToInt32(fields[7]));
                }
                else if (fields[0].StartsWith("3")) // microwave
                {
                    app = new Microwave(
                        Convert.ToInt32(fields[0]),
                        fields[1],
                        Convert.ToInt32(fields[2]),
                        Convert.ToDouble(fields[3]),
                        fields[4],
                        Convert.ToDouble(fields[5]),
                        Convert.ToDouble(fields[6]),
                        fields[7]);
                }
                else if (fields[0].StartsWith("4") || fields[0].StartsWith("5")) // dishwasher
                {

                    app = new Dishwasher(
                        Convert.ToInt32(fields[0]),
                        fields[1],
                        Convert.ToInt32(fields[2]),
                        Convert.ToDouble(fields[3]),
                        fields[4],
                        Convert.ToDouble(fields[5]),
                        fields[6],
                        fields[7]);
                }
                list.Add(app);
            }
            reader.Close();
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

        public static void Checkout()
        {
            Console.WriteLine("Enter item number of an appliance: ");
            string? input = Console.ReadLine();
            int output = 0;

            if (int.TryParse(input, out output)) // check if input is a number
            {

                List<Appliance> list = ReadAppliances();
                Appliance? appliance = list.FirstOrDefault(a => a.ItemNumber == output);

                if (appliance != null) // if input matches the item number
                {
                    if (appliance.Quantity > 0) // if appliance is avaiable then check out
                    {
                        appliance.Quantity--;
                        Console.WriteLine($"Appliance \"{input}\" has been checked out.");
                    }
                    else // if no appliance is available
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                    }
                }
                else // if input doesn't match
                {
                    Console.WriteLine("No appliances found with that item number.");
                }
            }
            else // if input is a string
            {
                Console.WriteLine("Must be a number");
            }
        }

        public static void Find()
        {
            Console.WriteLine("Enter brand to search for:");
            string? input = Console.ReadLine()?.ToLower();
            int output = 0;

            if (int.TryParse(input, out output)) // check if input is a number
            {
                Console.WriteLine("Must be letters.");
                return;
            }

            List<Appliance> list = ReadAppliances();
            List<Appliance> appliances = list.Where(a => a.Brand.ToLower() == input).ToList();

            if (appliances.Count > 0) // if input matches the brand
            {
                Console.WriteLine("Matching appliances:");
                foreach (Appliance a in appliances) // display all matching appliances
                {
                    Console.WriteLine(a + "\n");
                }
            }
            else // if input doesn't match
            {
                Console.WriteLine("No appliances found.");
            }
        }

        public static void Display()
        {
            Console.WriteLine("Appliance Types\n" +
                "1 - Refrigerators\n" +
                "2 - Vacuums\n" +
                "3 - Microwaves\n" +
                "4 - Dishwashers\n" +
                "Enter type of appliance:");
            string? input = Console.ReadLine();

            List<Appliance> list = ReadAppliances();
            switch (input)
            {
                case "1": // refrigerator
                    Console.WriteLine("Enter number of doors (2, 3, or 4):");
                    string? doors = Console.ReadLine();
                    int doorsOutput = 0;

                    if (int.TryParse(doors, out doorsOutput)) // check if input is a number
                    {
                        List<Refrigerator> refrigerators = list.OfType<Refrigerator>().ToList();
                        List<Refrigerator> matchingRefrigerators = refrigerators.Where(r => r.Doors == doorsOutput).ToList();

                        if (matchingRefrigerators.Count > 0) // if input matches the number of doors
                        {
                            Console.WriteLine("Matching refrigerators:");
                            foreach (Refrigerator r in matchingRefrigerators) // display all matching refrigerators
                            {
                                Console.WriteLine(r + "\n");
                            }
                        }
                        else // if input doesn't match
                        {
                            Console.WriteLine("No refrigerators found with " + doors + " doors.");
                        }
                    }
                    else // if input is a string
                    {
                        Console.WriteLine("Must be a number.");
                    }
                    break;

                case "2": // vacuum
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                    string? voltage = Console.ReadLine();
                    int voltageOutput = 0;

                    if (int.TryParse(voltage, out voltageOutput)) // check if input is a number
                    {
                        List<Vacuum> vacuums = list.OfType<Vacuum>().ToList();
                        List<Vacuum> matchingVacuums = vacuums.Where(v => v.BatteryVoltage == voltageOutput).ToList();

                        if (matchingVacuums.Count > 0) // if input matches the battery voltage
                        {
                            Console.WriteLine("Matching vacuums:");
                            foreach (Vacuum v in matchingVacuums) // display all matching vacuums
                            {
                                Console.WriteLine(v + "\n");
                            }
                        }
                        else // if it doesn't match
                        {
                            Console.WriteLine("No vacuums found with " + voltage + " V battery voltage.");
                        }
                    }
                    else // if input is a string
                    {
                        Console.WriteLine("Must be a number.");
                    }
                    break;

                case "3": // microwave
                    Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                    string? room = Console.ReadLine()?.ToLower();
                    int roomOutput = 0;

                    if (int.TryParse(room, out roomOutput)) // check if input is a number
                    {
                        Console.WriteLine("Must be letters.");
                        return;
                    }

                    List<Microwave> microwaves = list.OfType<Microwave>().ToList();
                    List<Microwave> matchingMicrowaves = microwaves.Where(m => m.RoomType.ToLower() == room).ToList();

                    if (matchingMicrowaves.Count > 0) // if input matches room type
                    {
                        Console.WriteLine("Matching microwaves:");
                        foreach (Microwave m in matchingMicrowaves) // display all matching microwaves
                        {
                            Console.WriteLine(m + "\n");
                        }
                    }
                    else // if it doesn't match
                    {
                        Console.WriteLine("No microwaves found for room type " + room + ".");
                    }
                    break;

                case "4": // Dishwasher
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate):");
                    string? sound = Console.ReadLine()?.ToLower();
                    int soundOutput = 0;

                    if (int.TryParse(sound, out soundOutput)) // check if input is a number
                    {
                        Console.WriteLine("Must be letters.");
                        return;
                    }

                    List<Dishwasher> dishwashers = list.OfType<Dishwasher>().ToList();
                    List<Dishwasher> matchingDishwashers = dishwashers.Where(d => d.SoundRating.ToLower() == sound).ToList();

                    if (matchingDishwashers.Count > 0) // if input matches the sound rating
                    {
                        Console.WriteLine("Matching dishwashers:");
                        foreach (Dishwasher d in matchingDishwashers) // display all matching dishwashers
                        {
                            Console.WriteLine(d + "\n");
                        }
                    }
                    else // if input doesn't match
                    {
                        Console.WriteLine("No dishwashers found with sound rating " + sound + ".");
                    }
                    break;

                default: // Error, input not an option
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                    break;
            }
        }

        public static void RandomAppliance()
        {
            Console.WriteLine("Enter number of appliances:");
            string? input = Console.ReadLine();
            int output = 0;

            if (int.TryParse(input, out output)) // check if input is a number
            {
                List<Appliance> list = ReadAppliances();

                if (output > 0 && list.Count > 0) // if input is greater than 0 and has a matching object in list
                {
                    Console.WriteLine("Random appliances:");
                    Random rand = new Random();

                    for (int i = 0; i < output; i++) // display number of random appliances according to input amount
                    {
                        Appliance randomAppliance = list[rand.Next(0, list.Count)];
                        Console.WriteLine(randomAppliance + "\n");
                    }

                }
                else // if input is not over 0
                {
                    Console.WriteLine("Must be over 0.");
                }
            }
            else // if input is a string
            {
                Console.WriteLine("Must be a number.");
            }        
        }
     
        public static void SaveData(List<Appliance> list)
        {
            using StreamWriter writer = new StreamWriter(PATH);
            foreach (Appliance a in list)
            {
                // formatting for file
                string line = $"{a.ItemNumber}{SEP}{a.Brand}{SEP}{a.Quantity}{SEP}{a.Wattage}{SEP}{a.Color}{SEP}{a.Price}";

                if (a is Refrigerator r) // formatting for refrigerators
                {
                    line += $"{SEP}{r.Doors}{SEP}{r.Height}{SEP}{r.Width}{SEP}";
                }
                else if (a is Vacuum v) // formatting for vacuums
                {
                    line += $"{SEP}{v.Grade}{SEP}{v.BatteryVoltage}{SEP}";
                }
                else if (a is Microwave m) // formatting for microwaves
                {
                    line += $"{SEP}{m.Capacity}{SEP}{m.RoomType}{SEP}";
                }
                else if (a is Dishwasher d) // formatting for dishwashers
                {
                    line += $"{SEP}{d.Feature}{SEP}{d.SoundRating}{SEP}";
                }
                writer.WriteLine(line);
            }
            writer.Close();
            Console.WriteLine("Data has been saved.");
        }
    } // class
} // namespace

