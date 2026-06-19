using CsvHelper.Configuration;

public sealed class SmartPersonClassMap : ClassMap<Person>
{
    public SmartPersonClassMap(Gender gender)
    {
        Map(m => m.LastName).Name("Last Name");
        Map(m => m.FirstName).Name(gender == Gender.Male ? "Male First Name" : "Female First Name");
        Map(m => m.Gender).Name("Gender");
    }
}