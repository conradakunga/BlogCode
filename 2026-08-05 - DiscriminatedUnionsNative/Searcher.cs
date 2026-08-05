public union FindResult(Person, FoundInactive, NotFound, Problem);

public sealed class Searcher
{
    public static FindResult Find(List<Person> people, int id)
    {
        try
        {
            // Randomly throw an exception
            if (Random.Shared.Next(0, 2) < 1)
                return new Problem("Random error");
            // Try and find the person
            var person = people.SingleOrDefault(x => x.ID == id);
            // Not found
            if (person is null)
                return new NotFound();
            // Found, but with caveats
            return person.Active switch
            {
                // Active, normal result
                true => person,
                // Inactive, edge case result
                false => new FoundInactive(person)
            };
        }
        catch (Exception e)
        {
            // Some other exception. Return this too
            return new Problem(e.Message);
        }
    }
}