using Sqids;

var builder = WebApplication.CreateBuilder(args);

// var people = new List<Person.v2.Person>
// {
//     new()
//     {
//         ID = 1,
//         FirstName = "James",
//         Surname = "Bond"
//     },
//     new()
//     {
//         ID = 2,
//         FirstName = "Jason",
//         Surname = "Bourne"
//     }
// };
var generator = new SqidsEncoder<int>(new()
{
    MinLength = 10,
    Alphabet = "ABCDEFGHKLMNPQRSTUVWYZabcdefghklmnpqrstuvwxyz23456789",
});
var people = new List<Person.v3.Person>
{
    new()
    {
        ID = 1,
        FirstName = "James",
        Surname = "Bond",
        Identifier = generator.Encode(1)
    },
    new()
    {
        ID = 2,
        FirstName = "Jason",
        Surname = "Bourne",
        Identifier = generator.Encode(2)
    }
};

var app = builder.Build();

app.MapGet("/", () => Results.Ok(people));
app.MapGet("/v1/{ID:int}", (int id) =>
{
    var person = people.FirstOrDefault(x => x.ID == id);
    if (person is null)
        return Results.NotFound();
    return Results.Ok(person);
});


app.MapGet("/v2/{identifier}", (string identifier) =>
{
    var id = generator.Decode(identifier)[0];
    // var person = people.FirstOrDefault(x => x.ID == id);
    var person = people.FirstOrDefault(x => x.Identifier == identifier);
    if (person is null)
        return Results.NotFound();
    return Results.Ok(person);
});
await app.RunAsync();