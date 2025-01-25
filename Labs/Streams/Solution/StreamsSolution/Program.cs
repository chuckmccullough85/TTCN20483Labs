
using System.Text.Json;

var filename = @"D:\Documents\class\CSharp\TTCN20483Labs\Labs\Streams\ReducedMoviesJson.txt";

var movies = new List<Movie>();

using var file = new StreamReader(filename);
string? line;
while ((line = file.ReadLine()) != null)
{
    var movie = JsonSerializer.Deserialize<Movie>(line);
    if (movie != null)
        movies.Add(movie);
}
Console.WriteLine(movies.Count);
foreach (var movie in movies.Take(50))
{
    Console.WriteLine($"{movie.Title} ({movie.Year})");
    Console.WriteLine($"Rated: {movie.Rated}");
    Console.WriteLine($"Genre: {movie.Genre}");
    Console.WriteLine($"Cast: {string.Join(", ", movie.Cast)}");
    Console.WriteLine();
}

record Movie(string Title, int Year, string Rated, string Genre, string[] Cast);
