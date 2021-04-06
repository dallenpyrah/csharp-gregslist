using System.Collections.Generic;
using gregslist.Models;

namespace gregslist.db
{
    public class Fakedb
    {
        public static List<Car> Cars { get; set; } = new List<Car>();

        public static List<House> Houses { get; set; } = new List<House>();

        public static List<Job> Jobs { get; set; } = new List<Job>();

        public static List<Bike> Bikes { get; set; } = new List<Bike>();
    }
}