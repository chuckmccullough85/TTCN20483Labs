
using System.Text.Json;

var filename = @"D:\Documents\class\CSharp\TTCN20483Labs\Labs\Streams\ReducedMoviesJson.txt";

var db = new MovieDb(filename);

var movies = db.Movies.Where(m => m.Year > 2010 && m.Genre.Contains("Action"));
foreach (var movie in movies)
{
    Console.WriteLine($"{movie.Title} ({movie.Year})");
    Console.WriteLine($"Rated: {movie.Rated}");
    Console.WriteLine($"Genre: {movie.Genre}");
    Console.WriteLine($"Cast: {string.Join(", ", movie.Cast)}");
    Console.WriteLine();
}

movies = db.Movies.Where(m => m.Cast.Contains("Tom Cruise"));
foreach (var movie in movies)
{
    Console.WriteLine($"{movie.Title} ({movie.Year})");
    Console.WriteLine($"Rated: {movie.Rated}");
    Console.WriteLine($"Genre: {movie.Genre}");
    Console.WriteLine($"Cast: {string.Join(", ", movie.Cast)}");
    Console.WriteLine();
}

record Movie(string Title, int Year, string Rated, string Genre, string[] Cast);

class MovieDb
{
    private readonly List<Movie> _movies = new();

    public MovieDb(string filename)
    {
        using var file = new StreamReader(filename);
        string? line;
        while ((line = file.ReadLine()) != null)
        {
            var movie = JsonSerializer.Deserialize<Movie>(line);
            if (movie != null)
                _movies.Add(movie);
        }
    }

    public IEnumerable<Movie> Movies => _movies;
}