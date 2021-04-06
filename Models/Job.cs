using System;

namespace gregslist.Models
{
    public class Job
    {
        public Job(string title, string company, int salary, int hours, string location)
        {
            Title = title;
            Company = company;
            Salary = salary;
            Hours = hours;
            Location = location;
        }

        public string Title { get; set; }
        
        public string Company { get; set; }

        public int Salary { get; set; }

        public int Hours { get; set; }

        public string Location { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        
    }
}