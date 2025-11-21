using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CarWiki
{
    public class Car
    {
        public int id { get; set; }
        public string make { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public int year { get; set; }
        public int horsePower { get; set; }
        public string? imagePath { get; set; }

        public Car()
        {
        }

        public Car(string make, string model, int year, int horsePower, string? imagePath = null)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.horsePower = horsePower;
            this.imagePath = imagePath;
        }
    }
}
