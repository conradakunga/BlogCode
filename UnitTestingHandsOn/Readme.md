# Problem

The problem we are going to solve is a simple one.

> We, the technical team at World Intelligence HQ, are developing an API to manage spies worldwide.

The `Spy` entity looks like this:

```c#
public sealed record Spy
{
    public required Guid SpyID { get; init; }
    public required Guid Name { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required string Agency { get; init; }
}
```

We next define a contract for the logic that will allow for the management of Spies.

It should allow us to do the following:

- **Add** a `Spy`
- **Delete** a `Spy`
- Get a `Spy`
- **List** all `Spy` entities
- **Edit** A `Spy`
- **Search** For A `Spy`

We can also add two convenience methods

- Generate a **random** list of `Spy` entities

To achieve this, we create a **contract** for an object to carry out this work, in the form of an [interface](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface).

It will look like this:

```c#
public interface ISpyManager
{
    public Guid Add(CreateSpyRequest request);
    public void Edit(Guid spyID, UpdateSpyRequest request);
    public void Delete(Guid spyID);
    public Spy? Get(Guid spyID);
    public List<Spy> List();
    public List<Spy> Search(string search);
    public List<Spy> GenerateRandom(int number);
}
```


