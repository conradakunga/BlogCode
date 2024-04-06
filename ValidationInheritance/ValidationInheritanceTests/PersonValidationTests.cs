using FluentAssertions;
using FluentValidation;
using ValidationInheritanceLibrary;
using ValidationInheritanceLibrary.Validators;

namespace ValidationInheritanceTests;

public class PersonValidationTests
{
    [Fact]
    public void Person_When_Invalid_Throws_3_Errors()
    {
        var person = new Person
        {
            Name = "",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now)
        };

        var validator = new PersonValidator<Person>();
        var result = Record.Exception(() => validator.ValidateAndThrow(person))!;
        result.Should().BeOfType<ValidationException>();
        var errors = ((ValidationException)result).Errors.Count();
        errors.Should().Be(3);
    }

    [Fact]
    public void Person_When_Valid_Succeeds()
    {
        var person = new Person
        {
            Name = "James Bond",
            DateOfBirth = new DateOnly(1960, 1, 1)
        };

        var validator = new PersonValidator<Person>();
        var result = Record.Exception(() => validator.ValidateAndThrow(person))!;
        result.Should().BeNull();
    }
}