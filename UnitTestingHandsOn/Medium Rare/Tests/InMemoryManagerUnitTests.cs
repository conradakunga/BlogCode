using AwesomeAssertions;
using UnitTestingLogic;

namespace Tests;

public class InMemoryManagerUnitTests
{
    [Fact]
    public void Add_Spy_Works()
    {
        // Our test data
        const string name = "James Bond";
        const string agency = "Mi5";
        var dateOfBirth = new DateOnly(1950, 1, 1);

        // Arrange
        var manager = new InMemorySpyManager();
        var create = new CreateSpyRequest
        {
            Name = name,
            Agency = agency,
            DateOfBirth = dateOfBirth,
        };
        // Act
        var newID = manager.Add(create);
        var spy = manager.Get(newID);

        // Assert
        // 1. Thew new ID should not be an empty Guid
        // 2. The fetched spy should not be null
        // 3. The name and agency should match what we sent
        newID.Should().NotBeEmpty();
        spy.Should().NotBeNull();
        spy.Name.Should().Be(name);
        spy.Agency.Should().Be(agency);
        spy.DateOfBirth.Should().Be(dateOfBirth);
    }

    [Fact]
    public void Edit_Spy_Works()
    {
        // Our test data
        const string name = "James Bond";
        const string agency = "Mi5";
        var dateOfBirth = new DateOnly(1950, 1, 1);

        // Arrange
        var manager = new InMemorySpyManager();
        var create = new CreateSpyRequest
        {
            Name = name,
            Agency = agency,
            DateOfBirth = dateOfBirth,
        };

        var newID = manager.Add(create);

        // Edit the spy we just created

        const string newName = "Jason Bourne";
        const string newAgency = "CIA";
        var newDateOfBirth = new DateOnly(1970, 1, 1);

        var request = new UpdateSpyRequest
        {
            Name = newName,
            DateOfBirth = newDateOfBirth,
            Agency = newAgency,
        };

        manager.Edit(newID, request);

        // Fetch the spy again

        var updatedSpy = manager.Get(newID);
        updatedSpy.Should().NotBeNull();
        updatedSpy.Name.Should().Be(newName);
        updatedSpy.Agency.Should().Be(newAgency);
        updatedSpy.DateOfBirth.Should().Be(newDateOfBirth);
    }

    [Fact]
    public void Delete_Spy_Works()
    {
        // Our test data
        const string name = "James Bond";
        const string agency = "Mi5";
        var dateOfBirth = new DateOnly(1950, 1, 1);

        // Arrange
        var manager = new InMemorySpyManager();
        var create = new CreateSpyRequest
        {
            Name = name,
            Agency = agency,
            DateOfBirth = dateOfBirth,
        };

        var newID = manager.Add(create);

        // Now delete

        manager.Delete(newID);

        // Check that we can't get the spy back

        var spy = manager.Get(newID);
        spy.Should().BeNull();
    }

    [Fact]
    public void List_Spies_Works()
    {
        var jamesBond = new CreateSpyRequest
        {
            Name = "James Bond",
            DateOfBirth = new DateOnly(1950, 1, 1),
            Agency = "Mi5"
        };
        var jasonBourne = new CreateSpyRequest
        {
            Name = "Jason Bourne",
            DateOfBirth = new DateOnly(1970, 1, 1),
            Agency = "CIA"
        };

        var manager = new InMemorySpyManager();
        manager.Add(jamesBond);
        manager.Add(jasonBourne);

        // Get the list
        var spies = manager.List();
        // Assert that the count is 2
        spies.Count.Should().Be(2);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    public void Generate_Spies_Works(int number)
    {
        var manager = new InMemorySpyManager();
        var spies = manager.GenerateRandom(number);
        spies.Count.Should().Be(number);
    }

    [Fact]
    public void Edit_A_Spy_That_Does_Not_Exist_Throws_Exception()
    {
        var manager = new InMemorySpyManager();
        var request = new UpdateSpyRequest
        {
            Name = "James Bond",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Agency = "CIA",
        };
        var ex = Record.Exception(() => manager.Edit(Guid.NewGuid(), request));
        ex.Should().NotBeNull();
        ex.Should().BeOfType<Exception>();
    }
}