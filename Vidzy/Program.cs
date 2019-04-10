using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            //Action Movies Sorterd by Name

            //var movies = context.Videos
            //    .Where(c => c.Genre.Name == "Action")
            //    .OrderBy(c=> c.Name);
            //foreach (var movie in movies)
            //{
            //    Console.WriteLine(movie.Name);
            //}



            //Gold drama movies sorted by release date (newest first)

            //var movies = context.Videos
            //     .Where(g => g.Genre.Name == "Drama")
            //     .Where(v => v.Classification == Classification.Gold )
            //     .OrderByDescending(v=> v.ReleaseDate);
            //foreach (var movie in movies)
            //{
            //    Console.WriteLine(movie.Name);
            //}



            //All movies projected into an anonymous type with two properties:MovieName and Genre

            //var movies = context.Videos
            //    .Select(v => new
            //    {
            //        MovieName = v.Name,
            //        Genre = v.Genre.Name
            //    });
            //foreach (var movie in movies)
            //{
            //    Console.WriteLine("{0}=>{1}", movie.Genre, movie.MovieName);
            //}




            //All movies grouped by their classification

            //var groups = context.Videos
            //   .GroupBy(v => v.Classification)
            //   .Select(g => new
            //   {
            //       Classification = g.Key.ToString(),
            //       Videos = g.OrderBy(v => v.Name)
            //   });
            //foreach (var g in groups)
            //{
            //    Console.WriteLine("Classification: " + g.Classification);

            //    foreach (var v in g.Videos)
            //        Console.WriteLine("\t" + v.Name);
            //}


            //The classification of the videos and its count

            //var classification = context.Videos
            //    .GroupBy(v => v.Classification)
            //    .Select(v=> new
            //    {
            //        Clasiffication= v.Key.ToString(),
            //        video= v.Count()
            //    });

            //foreach (var counting in classification)
            //{
            //    Console.WriteLine(counting.Clasiffication + " ("+counting.video+")");
            //}



            //List of genres and number of videos they include, sorted by the number of videos

            var genres = context.Genres
                .GroupJoin(context.Videos, g => g.Id, v => v.GenreId, (genre, videos) => new
                {
                    Name = genre.Name,
                    VideosCount = videos.Count()
                })
                .OrderByDescending(g => g.VideosCount);

            Console.WriteLine();
            Console.WriteLine("GENRES AND NUMBER OF VIDEOS IN THEM");
            foreach (var g in genres)
                Console.WriteLine("{0} ({1})", g.Name, g.VideosCount);

        }
    }
}
