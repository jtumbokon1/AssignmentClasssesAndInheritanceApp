﻿using System;
using System.Collections.Generic;
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
                // fields [7] = Height, Batter Voltage, Room Type, Sound Rating
                // fields [8] = Width
                Appliance? app = null;
                if (fields[0].StartsWith("1"))
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
                else if (fields[0].StartsWith("2"))
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
                else if (fields[0].StartsWith("3"))
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
                else if (fields[0].StartsWith("4") || fields[0].StartsWith("5"))
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
            int? input = Convert.ToInt32(Console.ReadLine());

            List<Appliance> list = ReadAppliances();
            Appliance? appliance = list.FirstOrDefault(a => a.ItemNumber == input);

            if (appliance != null)
            {
                if (appliance.Quantity > 0)
                {
                    appliance.Quantity--;
                    Console.WriteLine($"Appliance \"{input}\" has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
            else
            {
                Console.WriteLine("No appliances found with that item number.");
            }
        }

        public static void Find()
        {
            Console.WriteLine("Enter brand to search for:");
            string? input = Console.ReadLine()?.ToLower();

            List<Appliance> list = ReadAppliances();
            List<Appliance> appliances = list.Where(a => a.Brand.ToLower() == input).ToList();

            if (appliances.Count > 0)
            {
                Console.WriteLine("Matching appliances:");
                foreach (Appliance appliance in appliances)
                {
                    Console.WriteLine(appliance + "\n");
                }
            }
            else
            {
                Console.WriteLine("No appliances found for the specified brand.");
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
                case "1": // Refrigerator
                    Console.WriteLine("Enter number of doors (2, 3, or 4):");
                    string? doors = Console.ReadLine();

                    // Get only refrigerators
                    List<Refrigerator> refrigerators = list.OfType<Refrigerator>().ToList();

                    // Filter based on number of doors
                    List<Refrigerator> matchingRef = refrigerators.Where(r => r.Doors.ToString() == doors).ToList();

                    if (matchingRef.Count > 0)
                    {
                        Console.WriteLine("\nMatching Refrigerators:");
                        foreach (Refrigerator r in matchingRef)
                        {
                            Console.WriteLine(r);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo refrigerators found with " + doors + " doors.");
                    }
                    break;

                case "2": // Vacuum
                    List<Vacuum> vacuums = list.OfType<Vacuum>().ToList();
                    Console.WriteLine("\nAll Vacuums:");
                    foreach (Vacuum v in vacuums)
                    {
                        Console.WriteLine(v);
                    }
                    break;

                case "3": // Microwave
                    List<Microwave> microwaves = list.OfType<Microwave>().ToList();
                    Console.WriteLine("\nAll Microwaves:");
                    foreach (Microwave m in microwaves)
                    {
                        Console.WriteLine(m);
                    }
                    break;

                case "4": // Dishwasher
                    List<Dishwasher> dishwashers = list.OfType<Dishwasher>().ToList();
                    Console.WriteLine("\nAll Dishwashers:");
                    foreach (Dishwasher d in dishwashers)
                    {
                        Console.WriteLine(d);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                    break;
            }
        } 
    }
}
