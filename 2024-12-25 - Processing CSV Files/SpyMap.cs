using CsvHelper.Configuration;

public class SpyMap : ClassMap<Spy>
{
    public SpyMap()
    {
        Map(m => m.Name).Name("FullNames").Index(0);
        Map(m => m.Age).Name("CurrentAge").Index(1);
        Map(m => m.Service).Name("Agency").Index(2);
    }
}
