using System;
using System.Collections.Generic;
using A6.NET;

namespace A6.NET
{
    public class Movie : Media
    {
        public List<string> genre { get; set; }

        public Movie() { }

        public Movie(int ID, string TITLE, List<string> GENRE)
        {
            this.Id = ID;
            this.title = TITLE;
            this.genre = GENRE;
        }

        public Movie(List<string> genre)
        {
            this.genre = genre;
        }

        public override void Display()
        {
            Console.WriteLine($"Id: {Id}\nTitle: {title}\nGenres: {string.Join(", ", genre)}\n");
        }
    }
}