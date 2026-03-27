using System.Text.Json;
using ImageSerialization;
using Serilog;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Create our movie
var movie = new Movie
{
    Title = "The Old Woman With The Knife",
    Length = 183,
    ReleaseDate = new DateOnly(2025, 5, 1),
    Poster = Image.Load<Rgba32>("movie.jpeg")
};

var options = new JsonSerializerOptions();
// Register our converter
options.Converters.Add(new ImageJsonConverter());

// Serialize for transfer
var json = JsonSerializer.Serialize(movie, options);

// Deserialize for processing (assume this is a different system)
var receivedMovie = JsonSerializer.Deserialize<Movie>(json, options)!;

// Use our movie here
Log.Information("The poster for {MovieTitle} measures {BoundsWidth} x  {BoundsHeight}",
    receivedMovie.Title, receivedMovie.Poster.Bounds.Width, receivedMovie.Poster.Bounds.Height);