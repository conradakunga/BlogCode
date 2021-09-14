using System;

var app = WebApplication.Create(args);

// Configure the root to accept HEAD requests
app.MapMethods("/", new [] { "HEAD" }, () => "This is a head request");

// Configure the root to also accept GET requests
app.MapGet("/", () => $"The time on the server is {DateTime.Now}");

// Map a new route, hello, that takes a string parameter
app.MapGet("/hello/{name}", (string name) => $"Hello {name} from the server");

// Map a new route, count, that takes an int parameter
app.MapGet("/count/{counter:int}", (int counter) => $"Received {counter}");

app.Urls.Add("https://localhost:3000");

app.Run();