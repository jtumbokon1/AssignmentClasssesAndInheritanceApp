using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentClasssesAndInheritance
{
    public enum SoundRating
    {
        Qt,
        Qr,
        Qu,
        M
    }
    public class Dishwasher
    {
        private SoundRating sr;

        public SoundRating SR { get { return sr; } }
        public int ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Wattage { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string Sound { get; set; }
        public double Voltage { get; set; }
    }
}
