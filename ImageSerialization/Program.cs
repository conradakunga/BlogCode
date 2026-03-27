using System.Text.Json;
using ImageSerialization;
using Serilog;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Create our DTO
var movieDTO = new MovieDTO
{
    Title = "The Old Woman With The Knife",
    Length = 183,
    ReleaseDate = new DateOnly(2025, 5, 1),
    PosterData = await File.ReadAllBytesAsync("movie.jpeg")
};

// Serialize for transfer
var json = JsonSerializer.Serialize(movieDTO);

// Deserialize for processing (assume this is a different system)
var receivedDTO = JsonSerializer.Deserialize<MovieDTO>(json)!;

// Map to a movie
var movie = new Movie
{
    Title = receivedDTO.Title,
    Length = receivedDTO.Length,
    ReleaseDate = receivedDTO.ReleaseDate,
    Poster = Image.Load<Rgba32>(receivedDTO.PosterData)
};

// Use our movie here
Log.Information("The poster for {MovieTitle} measures {BoundsWidth} x  {BoundsHeight}",
    movie.Title, movie.Poster.Bounds.Width, movie.Poster.Bounds.Height);