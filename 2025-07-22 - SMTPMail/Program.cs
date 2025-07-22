using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using Bogus;
using Bogus.DataSets;
using Serilog;

// Setup logging
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

var faker = new Faker<Spy>()
    // Use a fixed seed
    .UseSeed(0)
    // Pick a random gender
    .RuleFor(spy => spy.Gender, faker => faker.PickRandom<Gender>())
    // Configure first name, gender-specific
    .RuleFor(spy => spy.Firstname,
        (faker, spy) => faker.Name.FirstName(spy.Gender == Gender.Male
            ? Name.Gender.Male
            : Name.Gender.Female))
    // Configure surname
    .RuleFor(spy => spy.Surname, faker => faker.Person.LastName)
    // Configure email
    .RuleFor(spy => spy.EmailAddress, (faker, spy) => faker.Internet.Email(spy.Firstname, spy.Surname))
    // Set date of birth is 50 years in the past max
    .RuleFor(spy => spy.DateOfBirth, t => DateOnly.FromDateTime(t.Date.Past(50)));

// Generate 15
var spies = faker.Generate(15);

// Create SMTPClient
var smtpClient = new SmtpClient
{
    Host = "localhost",
    Port = 25,
    Credentials = CredentialCache.DefaultNetworkCredentials
};

const string fromAddress = "operations@MI5.org.uk";

foreach (var spy in spies)
{
    var email = new MailMessage
    {
        From = new MailAddress(fromAddress),
        To = { new MailAddress(spy.EmailAddress) },
        Subject = $"{spy.Firstname} {spy.Surname} - Upcoming Assignment",
        Body = $"""
                Dear {spy.Firstname} 
                Be advised your upcoming assignment is on 1 August.

                Find attached details for your passport application
                """
    };

    // Prepare the attachment
    var details = $"""
                   First Name: {spy.Firstname}
                   Surname: {spy.Surname}
                   Date of Birth: {spy.DateOfBirth}
                   gender: {spy.Gender}
                   """;
    var stream = new MemoryStream(Encoding.UTF8.GetBytes(details));
    email.Attachments.Add(new Attachment(stream, "Application.txt", MediaTypeNames.Text.Plain));

    // Send the email
    try
    {
        Log.Information("Sending email to {Recipient}", spy.EmailAddress);
        smtpClient.Send(email);
        Log.Information("Email sent");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Error sending email to {Recipient}", spy.EmailAddress);
    }
}