using Bogus;

namespace UnitTestingLogic;

public class InMemorySpyManager : ISpyManager
{
    private List<Spy> _spies = [];

    /// <summary>
    /// Add a Spy
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Guid Add(CreateSpyRequest request)
    {
        // Add to the collection 
        var spy = new Spy
        {
            SpyID = Guid.NewGuid(),
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Agency = request.Agency = request.Agency
        };

        _spies.Add(spy);

        return spy.SpyID;
    }

    /// <summary>
    /// Edit a spy
    /// </summary>
    /// <param name="spyID"></param>
    /// <param name="request"></param>
    /// <exception cref="NotFoundException"></exception>
    public void Edit(Guid spyID, UpdateSpyRequest request)
    {
        // Find the spy by ID

        var spy = _spies.FirstOrDefault(s => s.SpyID == spyID);

        // If not found, throw an exception
        if (spy is null)
            throw new Exception("Spy not found");

        // Otherwise, update
        spy.Name = request.Name;
        spy.DateOfBirth = request.DateOfBirth;
        spy.Agency = request.Agency;
    }

    /// <summary>
    /// Delete a spy
    /// </summary>
    /// <param name="spyID"></param>
    public void Delete(Guid spyID)
    {
        // Find the spy by ID

        var spy = _spies.FirstOrDefault(s => s.SpyID == spyID);

        // If found, remove
        if (spy is not null)
            _spies.Remove(spy);

        // Alternatively, removeAll directly
    }

    /// <summary>
    ///  Get a spy
    /// </summary>
    /// <param name="spyID"></param>
    /// <returns></returns>
    public Spy? Get(Guid spyID)
    {
        var spy = _spies.FirstOrDefault(s => s.SpyID == spyID);
        return spy;
    }

    /// <summary>
    /// Lit all spies
    /// </summary>
    /// <returns></returns>
    public List<Spy> List()
    {
        return _spies;
    }

    /// <summary>
    ///  Search for spies
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    public List<Spy> Search(string search)
    {
        return _spies.Where(s => s.Name.Contains(search)
                                 || s.Agency.Contains(search))
            .ToList();
    }

    /// <summary>
    /// Generate a list of random spies
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public List<Spy> GenerateRandom(int number)
    {
        // Create and configure a faker
        var faker = new Faker<Spy>()
            .RuleFor(x => x.SpyID, f => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Agency, f => f.Company.CompanyName());

        // Generate
        return faker.Generate(number);
    }
}