public sealed record Person(string FirstName, string LastName, int ID, bool Active);

// Type to express no result was returned
public sealed record NotFound;

// Type to express Person was found, but inactive
public sealed record FoundInactive(Person person);

// Type to express some sort of problem was encountered
public sealed record Problem(string Details);