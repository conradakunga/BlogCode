using CsvHelper.Configuration;

public sealed class SpyClassmap : ClassMap<Spy>
{
    public SpyClassmap()
    {
        Map(m => m.LastName).Name("Last Name");
        Map(m => m.FirstName).Name("First Name");
        Map(m => m.DateOfBirth).Name("Date Of Birth");
    }
}