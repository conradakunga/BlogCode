using Bogus;

namespace v1
{
    public class Repository
    {
        public List<Spy> GetSpies()
        {
            var faker = new Faker<Spy>()
                .RuleFor(s => s.SpyID, Guid.CreateVersion7())
                .RuleFor(s => s.FullName, f => f.Person.FullName)
                .RuleFor(s => s.DateOfBirth, f => DateOnly.FromDateTime(f.Date.Past(10)));
            return faker.Generate(10);
        }
    }
}

namespace v2
{
    public class Repository
    {
        public IEnumerable<Spy> GetSpies()
        {
            var faker = new Faker<Spy>()
                .RuleFor(s => s.SpyID, Guid.CreateVersion7())
                .RuleFor(s => s.FullName, f => f.Person.FullName)
                .RuleFor(s => s.DateOfBirth, f => DateOnly.FromDateTime(f.Date.Past(10)));
            return faker.Generate(10).ToHashSet();
        }
    }
}