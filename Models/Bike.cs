using System;

namespace gregslist.Models
{
    public class Bike
    {
        public Bike(string brand, string type, int wheels, string weight)
        {
            Brand = brand;
            Type = type;
            Wheels = wheels;
            Weight = weight;
        }

        public string Brand { get; set; }

        public string Type { get; set; }

        public int Wheels { get; set; }

        public string Weight { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}