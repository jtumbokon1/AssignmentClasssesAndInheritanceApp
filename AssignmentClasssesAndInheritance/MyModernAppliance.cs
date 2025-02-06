using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public class MyModernAppliance
    {
        public static void Checkout()
        {

        }

        public static void Find()
        {

        }

        public static void RandomList()
        {

        }

        public static void DisplayDishwashers()
        {
            List<Dishwasher> dishwashers = ModernAppliances.ReadAppliances().OfType<Dishwasher>().ToList();

            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
            string? input = Console.ReadLine();

            foreach (Dishwasher dw in dishwashers)
            {
                switch (input)
                {
                    case Dishwasher.SoundRatingDisplay(input);
                        break;
                }
            }

        }
    

        public static void DisplayMicrowaves()
        {

        }

        public static void DisplayRefrigerators()
        {

        }

        public static void DisplayVacuums()
        {

        }
    }
}
