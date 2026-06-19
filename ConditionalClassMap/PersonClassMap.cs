using CsvHelper.Configuration;

public sealed class PersonClassMap : ClassMap<Person>
{
    public PersonClassMap()
    {
        Map(m => m.LastName).Name("Last Name");
        Map(m => m.FirstName).Name("First Name");
        Map(m => m.Gender).Name("Gender");
    }
}