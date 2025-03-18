using CsvHelper.Configuration;

namespace XMLSerialization;

public class SpyMap : ClassMap<Spy>
{
    public SpyMap()
    {
        Map(m => m.Name).Name("Name");
        Map(m => m.DateOfBirth).Name("DateOfBirth");
    }
}