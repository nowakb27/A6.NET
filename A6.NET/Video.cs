using System;
using System.Collections.Generic;
using A6.NET;

namespace A6.NET
{
    public class Video : Media
    {

        public string format { get; set; }
        public int length { get; set; }
        public List<int> regions { get; set; }

        public Video(int ID, string TITLE, string FORMAT, int LENGTH, List<int> REGIONS)
        {
            this.Id = ID;
            this.title = TITLE;
            this.format = FORMAT;
            this.length = LENGTH;
            this.regions = REGIONS;
        }

        public Video(string FORMAT, int LENGTH, List<int> REGIONS)
        {
            this.format = FORMAT;
            this.length = LENGTH;
            this.regions = REGIONS;
        }

        public Video() { }

        public override void Display()
        {
            Console.WriteLine($"Id: {Id}\nTitle: {title}\nFormat: {format}\nLength: {length}\n" +
                              $"Regions: {string.Join(", ", regions)}\n");
        }
    }
}
