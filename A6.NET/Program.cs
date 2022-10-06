using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using A6.NET;

namespace A6.NET
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintMenu();
        }

        public static void PrintMenu()
        {
            var PICK = "";
            do
            {
                Console.WriteLine("SELECT AN OPTION: \n1. DISPLAY \n2. ADD \n3. EXIT");
                PICK = Console.ReadLine();
                switch (PICK)
                {
                    case "1":
                        List();
                        break;
                    case "2":
                        Add();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("TRY AGAIN");
                        break;
                }
            } while (PICK != "3");
        }

        public static void List()
        {

            var PICK = "";
            do
            {
                Console.WriteLine("SELECT WHAT YOU WOULD LIKE TO DISPLAY: \n1. MOVIES \n2. SHOWS \n3. VIDEOS \n4. EXIT");
                PICK = Console.ReadLine();
                Media media = null;
                switch (PICK)
                {

                    case "1":
                        media = new Movie(1, "Boss Level", new List<string> { "Action", "Comedy" });
                        break;
                    case "2":
                        media = new Show(1, "Banshee", 5, 2, new List<string> { "Tropper" });
                        break;
                    case "3":
                        media = new Video(1, "Mission Impossible 2", "VHS,DVD,BluRay", 123, new List<int> { 0, 2 });
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("TRY AGAIN");
                        break;
                }
                media?.Display();
            } while (PICK != "4");

        }

        public static void Add()
        {

            var choice = "";
            do
            {
                Console.WriteLine("SELECT WHAT YOU WOULD LIKE TO ADD: \n1. MOVIE \n2. SHOW \n3. VIDEO \n4. EXIT");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddMovie();
                        break;
                    case "2":
                        AddShow();
                        break;
                    case "3":
                        AddVideo();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("TRY AGAIN");
                        break;
                }
            } while (choice != "4");
        }
        public static void AddMovie()
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                string file = "Files/movies.csv";
                using (var READ = new StreamReader(file))
                {
                    Movie movie = new Movie();

                    while (!READ.EndOfStream)
                    {
                        var headerline = READ.ReadLine();
                        var line = READ.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(',');
                            movie.Id = Int32.Parse(values[0]);
                            movie.title = values[1];
                            movie.genre = values[2].Split('|').ToList();
                        }

                        movies.Add(movie);
                    }

                    READ.Close();


                    StreamWriter STREAMWRITER = new StreamWriter(file, true);
                    string resp = "";
                    do
                    {
                        movie.Id = movies.Max(m => m.Id) + 1;

                        Console.WriteLine("ENTER TITLE OF MOVIE");
                        string title = Console.ReadLine();
                        if (movie.title.Contains(title))
                        {
                            Console.WriteLine("THIS MOVIE EXISTS ALREADY");
                            Console.WriteLine("TRY AGAIN");
                            title = Console.ReadLine();
                            if (title.Contains(','))
                            {
                                title = $"\"{title}\"";
                            }
                        }


                        var choice = "";
                        movie.genre = new List<string>();
                        do
                        {
                            Console.WriteLine("ENTER GENRE OF MOVIE");
                            movie.genre.Add(Console.ReadLine());
                            Console.WriteLine("WOULD YOU LIKE TO ADD ANOTHER GENRE? Y/N ");
                            choice = Console.ReadLine().ToUpper();
                        } while (choice != "N");

                        STREAMWRITER.WriteLine($"{movie.Id},{title},{string.Join("|", movie.genre)},");
                        Console.WriteLine("WOULD YOU LIKE TO ADD ANOTHER MOVIE? (Y/N) ");
                        resp = Console.ReadLine().ToUpper();
                    } while (resp != "N");

                    STREAMWRITER.Close();

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FILE COULD NOT BE FOUND");
            }
        }

        public static void AddShow()
        {
            try
            {
                List<Show> shows = new List<Show>();
                string file = "Files/shows.csv";
                using (var READ = new StreamReader(file))
                {
                    Show show = new Show();

                    while (!READ.EndOfStream)
                    {
                        READ.ReadLine();
                        var line = READ.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(',');
                            show.Id = Int32.Parse(values[0]);
                            show.title = values[1];
                            show.season = Int32.Parse(values[2]);
                            show.episode = Int32.Parse(values[3]);
                            show.writers = values[4].Split('|').ToList();
                        }

                        shows.Add(show);
                    }

                    READ.Close();


                    StreamWriter STREAMWRITER = new StreamWriter(file, true);
                    string resp = "";
                    do
                    {
                        show.Id = shows.Max(m => m.Id) + 1;

                        Console.WriteLine("ENTER TITLE OF SHOW");
                        string title = Console.ReadLine();
                        if (show.title.Contains(title))
                        {
                            Console.WriteLine("THIS SHOW EXISTS ALREADY");
                            Console.WriteLine("TRY AGAIN");
                            title = Console.ReadLine();
                            if (title.Contains(','))
                            {
                                title = $"\"{title}\"";
                            }
                        }

                        Console.WriteLine("ENTER THE SEASON OF THE SHOW");
                        show.season = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("ENTER THE EPISODE OF THE SEASON");
                        show.episode = Int32.Parse(Console.ReadLine());

                        var choice = "";
                        show.writers = new List<string>();
                        do
                        {
                            Console.WriteLine("ENTER THE WRITER OF THE SHOW");
                            show.writers.Add(Console.ReadLine());
                            Console.WriteLine("WOULD YOU LIKE TO ADD ANOTHER WRITER? Y/N ");
                            choice = Console.ReadLine().ToUpper();
                        } while (choice != "N");

                        STREAMWRITER.WriteLine($"{show.Id},{title},{show.season},{show.episode}{string.Join("|", show.writers)},");
                        Console.WriteLine("WOULD YOU LIKE TO ADD ANOTHER SHOW? (Y/N) ");
                        resp = Console.ReadLine().ToUpper();
                    } while (resp != "N");

                    STREAMWRITER.Close();

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FILE COULD NOT BE FOUND");
            }
        }

        public static void AddVideo()
        {
            try
            {
                List<Video> videos = new List<Video>();
                string file = "Files/videos.csv";
                using (var READ = new StreamReader(file))
                {
                    Video video = new Video();

                    while (!READ.EndOfStream)
                    {
                        READ.ReadLine();
                        var line = READ.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(',');
                            video.Id = Int32.Parse(values[0]);
                            video.title = values[1];
                            video.format = values[2];
                            video.length = Int32.Parse(values[3]);
                            video.regions = values[4].Split('|').Select(Int32.Parse).ToList();
                        }

                        videos.Add(video);
                    }

                    READ.Close();


                    StreamWriter STREAMWRITER = new StreamWriter(file, true);
                    string resp = "";
                    do
                    {
                        video.Id = videos.Max(m => m.Id) + 1;

                        Console.WriteLine("ENTER TITLE OF VIDEO");
                        string title = Console.ReadLine();
                        if (video.title.Contains(title))
                        {
                            Console.WriteLine("THIS VIDEO EXISTS ALREADY");
                            Console.WriteLine("TRY AGAIN");
                            title = Console.ReadLine();
                            if (title.Contains(','))
                            {
                                title = $"\"{title}\"";
                            }
                        }

                        Console.WriteLine("ENTER FORMAT OF VIDEO");
                        video.format = Console.ReadLine();
                        Console.WriteLine("ENTER LENGTH OF VIDEO");
                        video.length = Int32.Parse(Console.ReadLine());


                        var choice = "";
                        video.regions = new List<int>();
                        do
                        {
                            Console.WriteLine("ENTER GENRE OF VIDEO");
                            video.regions.Add(Int32.Parse(Console.ReadLine()));
                            Console.WriteLine("WOULD YOU LIKE TO ADD ANOTHER GENRE? Y/N ");
                            choice = Console.ReadLine().ToUpper();
                        } while (choice != "N");

                        STREAMWRITER.WriteLine($"{video.Id},{title},{video.format},{video.length}{string.Join("|", video.regions)},");
                        Console.WriteLine("WOULD YOU LIKE TO ADD ANOTHER VIDEO? (Y/N) ");
                        resp = Console.ReadLine().ToUpper();
                    } while (resp != "N");

                    STREAMWRITER.Close();

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FILE COULD NOT BE FOUND");
            }
        }

    }
}