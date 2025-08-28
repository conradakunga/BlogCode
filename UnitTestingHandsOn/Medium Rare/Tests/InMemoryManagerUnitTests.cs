// using AwesomeAssertions;
// using UnitTestingLogic;
//
// namespace Tests;
//
// public class InMemoryManagerUnitTests
// {
//     [Fact]
//     public void Add_Spy_Works()
//     {
//         // Our test data
//         const string name = "James Bond";
//         const string agency = "Mi5";
//         var dateOfBirth = new DateOnly(1950, 1, 1);
//
//         // Arrange - act - assert
//
//         // Create a manager
//
//         // Create a spy request
//
//         // Add the request
//
//         // Get the new ID
//
//         // Fetch the spy by ID
//
//         // Assert
//         // 1. Thew new ID should not be an empty Guid
//         // 2. The fetched spy should not be null
//         // 3. The name and agency should match what we sent
//     }
//
//     [Fact]
//     public void Edit_Spy_Works()
//     {
//         // Our test data
//         const string name = "James Bond";
//         const string agency = "Mi5";
//         var dateOfBirth = new DateOnly(1950, 1, 1);
//
//         // Create a manager
//
//         // Create a spy
//
//         // Get The ID
//
//         // Edit the spy we just created
//
//         const string newName = "Jason Bourne";
//         const string newAgency = "CIA";
//         var newDateOfBirth = new DateOnly(1970, 1, 1);
//
//         // Create an update request
//
//         // Edit the spy
//
//         // Fetch the spy by ID again
//
//         // Assert
//         // 1. Should not be null
//         // 2. Validate the new name
//         // 3. Validate the new agency
//         // 4. Validate the new date of birth
//     }
//
//     [Fact]
//     public void Delete_Spy_Works()
//     {
//         // Our test data
//         const string name = "James Bond";
//         const string agency = "Mi5";
//         var dateOfBirth = new DateOnly(1950, 1, 1);
//
//         // Create a manager
//
//         // Create a spy
//
//         // Fetch the soy
//
//         // Now delete the spy
//
//         // Fetch the spy by ID
//
//         // Assert it is null
//     }
//
//     [Fact]
//     public void List_Spies_Works()
//     {
//         // Make two Create Spy Requests
//
//         // Create a manager
//
//         // List the current spies
//
//         // Assert they are none
//
//         // Add the twp spies
//
//         // List the current spies
//
//         // Assert that the count is 2
//     }
//
//     public void Generate_Spies_Works(int number)
//     {
//         // Test generation for multiple counts 
//     }
//
//     [Fact]
//     public void Edit_A_Spy_That_Does_Not_Exist_Throws_Exception()
//     {
//         var manager = new InMemorySpyManager();
//         var request = new UpdateSpyRequest
//         {
//             Name = "James Bond",
//             DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
//             Agency = "CIA",
//         };
//         var ex = Record.Exception(() => manager.Edit(Guid.NewGuid(), request));
//         ex.Should().NotBeNull();
//         ex.Should().BeOfType<NotFoundException>();
//     }
// }