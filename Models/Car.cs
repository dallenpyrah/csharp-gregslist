using System;

namespace gregslist.Models
{
    public class Car
    {
        public Car(string make, string model, int year, int miles)
        {
            Make = make;
            Model = model;
            Year = year;
            Miles = miles;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Miles { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}