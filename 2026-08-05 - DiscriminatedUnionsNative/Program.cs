var builder = WebApplication.CreateBuilder(args);

// Create a dummy 'database' in memory
List<Person> people =
[
    new Person("James", "Bond", 1, true),
    new Person("Evelyn", "Salt", 2, true),
    new Person("Jason", "Bourne", 3, true),
    new Person("Modesty", "Blaise", 4, false),
    new Person("Harry", "Pearce", 5, true),
];

// Register database
builder.Services.AddSingleton(people);
// Register searcher
builder.Services.AddSingleton<Searcher>();

var app = builder.Build();

// Setup end point
app.MapGet("/Get/{id:int}", (List<Person> injectedPeople, int id) =>
{
    return Searcher.Find(injectedPeople, id) switch
    {
        Person person => Results.Ok(person),
        FoundInactive inactive => Results.UnprocessableEntity(inactive),
        NotFound notFound => Results.NotFound(),
        Problem problem => Results.Problem(problem.Details)
    };
});

app.Run();