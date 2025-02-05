using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public enum SoundRatingDisplay
    {
        Qt,
        Qr,
        Qu,
        M
    }
    public class Dishwasher : Appliance
    {
        // private data
        private string feature;
        private SoundRatingDisplay soundRating;

        // public properties
        public string Feature { get { return feature; } }
        public SoundRatingDisplay SoundRating { get { return soundRating; } }

        // constructor
        public Dishwasher(int itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, SoundRatingDisplay soundRating) : 
            base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.soundRating = soundRating;
            this.feature = feature;
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
