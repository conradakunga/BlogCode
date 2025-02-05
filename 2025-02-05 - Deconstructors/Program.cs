using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var spy = new Spy("James", "Bond", new DateOnly(1950, 1, 1));

Log.Information("The first name is {FirstName}", spy.FirstName);
Log.Information("The surname name is {Surname}", spy.Surname);
Log.Information("The date of birth is {DateOfBirth}", spy.DateOfBirth);

var (firstName, surname, dateOfBirth) = spy;

Log.Information("The first name is {FirstName}", firstName);
Log.Information("The surname name is {Surname}", surname);
Log.Information("The date of birth is {DateOfBirth}", dateOfBirth);

//var (firstName, surname, _) = spy;

Log.Information("The first name is {FirstName}", firstName);
Log.Information("The surname name is {Surname}", surname);

var agency = new Agency("Central Intelligence Agency", "The work of a nation the center of intelligence",
    new DateOnly(1947, 9, 18));

var (name, motto, dateFounded) = agency;

Log.Information("The agency name is {Name}, founded in {DateFounded:d MMM yyyy}", name, dateFounded);
Log.Information("The motto is {Motto}", motto);