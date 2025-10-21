using System.Text.Json;
using CustomMovieSorterLibrary;

const string json =
    """
    	[
      {
        "Title": "Grand Hotel",
        "Year": 1932
      },
      {
        "Title": "Grave of the Fireflies",
        "Year": 1988
      },
      {
        "Title": "Grease",
        "Year": 1978
      },
      {
        "Title": "Greased Lightning",
        "Year": 1977
      },
      {
        "Title": "Green Dolphin Street",
        "Year": 1947
      },
      {
        "Title": "Groundhog Day",
        "Year": 1993
      },
      {
        "Title": "Grumpier Old Men",
        "Year": 1995
      },
      {
        "Title": "Grumpy Old Men",
        "Year": 1993
      },
      {
        "Title": "The Graduate",
        "Year": 1967
      },
      {
        "Title": "The Great Dictator",
        "Year": 1940
      },
      {
        "Title": "The Great Escape",
        "Year": 1963
      },
      {
        "Title": "The Great Gatsby",
        "Year": 1974
      },
      {
        "Title": "The Great Lie",
        "Year": 1941
      },
      {
        "Title": "The Green Hornet",
        "Year": 1974
      },
      {
        "Title": "The Green Mile",
        "Year": 1999
      }
    ]
    """;

var moviesV1 = JsonSerializer.Deserialize<List<V1.Movie>>(json);
var sortedMoviesV1 = moviesV1!.OrderBy(x => x.Title).ToList();
sortedMoviesV1.ForEach(x => Console.WriteLine(x.Title));

var moviesV2 = JsonSerializer.Deserialize<List<V2.Movie>>(json);
var sortedMoviesV2 = moviesV2!.OrderBy(x => x.SortTitle).ToList();
sortedMoviesV2.ForEach(x => Console.WriteLine(x.Title));


moviesV1!.Sort(new MovieComparer());
foreach (var movie in moviesV1)
    Console.WriteLine(movie.Title);


var sortedMovies = moviesV1.OrderBy(x => x).ToList();
foreach (var movie in sortedMovies)
    Console.WriteLine(movie.Title);

sortedMovies = moviesV1.Order().ToList();
foreach (var movie in sortedMovies)
    Console.WriteLine(movie.Title);

moviesV1.Sort();
foreach (var movie in moviesV1)
    Console.WriteLine(movie.Title);