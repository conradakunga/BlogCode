using CsvHelper.Configuration;

namespace v1
{
    public sealed class SpyClassmap : ClassMap<Spy>
    {
        public SpyClassmap()
        {
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.DateOfBirth).Name("Date Of Birth");
        }
    }
}

namespace v2
{
    public sealed class SpyClassmap : ClassMap<Spy>
    {
        public SpyClassmap()
        {
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.FormattedDateOfBirth).Name("Date Of Birth");
        }
    }
}

namespace v3
{
    public sealed class SpyClassmap : ClassMap<Spy>
    {
        public SpyClassmap()
        {
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.DateOfBirth).Name("Date Of Birth").TypeConverterOption.Format("d MMM yyyy");
        }
    }
}