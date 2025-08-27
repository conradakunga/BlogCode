using Bogus;

namespace UnitTestingLogic;

public class InMemorySpyManager : ISpyManager
{
    private readonly List<Spy> _spies = [];

    /// <summary>
    /// Add a Spy
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Guid Add(CreateSpyRequest request)
    {
        var spy = new Spy
        {
            SpyID = Guid.NewGuid(),
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Agency = request.Agency
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
        var spy = _spies.FirstOrDefault(s => s.SpyID == spyID);
        
        if (spy == null)
            throw new NotFoundException();
        
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
        var spy = _spies.FirstOrDefault(s => s.SpyID == spyID);
        if (spy != null)
            _spies.Remove(spy);
    }

    /// <summary>
    ///  Get a spy
    /// </summary>
    /// <param name="spyID"></param>
    /// <returns></returns>
    public Spy? Get(Guid spyID)
    {
        return _spies.FirstOrDefault(s => s.SpyID == spyID);
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
        return _spies.Where(x => x.Name.Contains(search)).ToList();
    }

    /// <summary>
    /// Generate a list of random spies
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public List<Spy> GenerateRandom(int number)
    {
        var faker = new Faker<Spy>()
            .RuleFor(x => x.SpyID, f => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.DateOfBirth, f => DateOnly.FromDateTime(f.Date.Past(50)))
            .RuleFor(x => x.Agency, f => f.Company.CompanyName());
        return faker.Generate(number);
    }
}