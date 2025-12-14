using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Bogus;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/Generate", async (HttpContext ctx) =>
{
    var faker = new Faker<Person>().UseSeed(0)
        .RuleFor(person => person.FirstName, faker => faker.Person.FirstName)
        .RuleFor(person => person.Surname, faker => faker.Person.LastName)
        .RuleFor(person => person.Salary, faker => faker.Random.Decimal(10_000, 99_000));

    var serializer = new XmlSerializer(typeof(List<Person>));
    await using var ms = new MemoryStream();
    await using (var writer = XmlWriter.Create(
                     ms,
                     new XmlWriterSettings
                     {
                         Encoding = Encoding.UTF8,
                         Indent = true,
                         Async = true
                     }))
    {
        serializer.Serialize(writer, faker.Generate(5));
    }

    ms.Position = 0;
    await ms.CopyToAsync(ctx.Response.Body);
});
app.Run();