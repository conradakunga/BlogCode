using Bogus;

namespace UnitTestingLogic;

public class InMemorySpyManager : ISpyManager
{
    /// <summary>
    /// Add a Spy
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Guid Add(CreateSpyRequest request)
    {
        // Add to the collection 
        throw new NotImplementedException();
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

        // If not found, throw an exception

        // Otherwise, update
    }

    /// <summary>
    /// Delete a spy
    /// </summary>
    /// <param name="spyID"></param>
    public void Delete(Guid spyID)
    {
        // Find the spy by ID

        // If found, remove

        // Alternatively, removeAll directly
    }

    /// <summary>
    ///  Get a spy
    /// </summary>
    /// <param name="spyID"></param>
    /// <returns></returns>
    public Spy? Get(Guid spyID)
    {
        // Get by ID
        throw new NotImplementedException();
    }

    /// <summary>
    /// Lit all spies
    /// </summary>
    /// <returns></returns>
    public List<Spy> List()
    {
        // Return the list? 
        throw new NotImplementedException();
    }

    /// <summary>
    ///  Search for spies
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    public List<Spy> Search(string search)
    {
        // Search the name

        // Search the name or agency
        throw new NotImplementedException();
    }

    /// <summary>
    /// Generate a list of random spies
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public List<Spy> GenerateRandom(int number)
    {
        // Create and configure a faker
        // var faker = new Faker<Spy>()
        //     .RuleFor(x => x.SpyID, f => Guid.NewGuid());
        
        // Generate
        throw new NotImplementedException();
    }
}