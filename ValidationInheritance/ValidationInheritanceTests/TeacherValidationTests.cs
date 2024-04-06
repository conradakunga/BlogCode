using FluentAssertions;
using FluentValidation;
using ValidationInheritanceLibrary;
using ValidationInheritanceLibrary.Validators;

namespace ValidationInheritanceTests;

public class TeacherValidationTests
{
    [Fact]
    public void Teacher_Can_Be_Validated_By_PersonValidator()
    {
        var teacher = new Teacher
        {
            Name = "",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Subject = ""
        };

        var validator = new PersonValidator<Teacher>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeOfType<ValidationException>();
        var errors = ((ValidationException)result).Errors.Count();
        errors.Should().Be(3);
    }

    [Fact]
    public void Teacher_When_Invalid_Throws_4_Errors()
    {
        var teacher = new Teacher
        {
            Name = "",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Subject = ""
        };

        var validator = new TeacherValidator<Teacher>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeOfType<ValidationException>();
        var errors = ((ValidationException)result).Errors.Count();
        errors.Should().Be(4);
    }

    [Fact]
    public void Teacher_When_Valid_Succeeds()
    {
        var teacher = new Teacher
        {
            Name = "James Bond",
            DateOfBirth = new DateOnly(1960, 1, 1),
            Subject = "Mathematics"
        };

        var validator = new TeacherValidator<Teacher>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeNull();
    }
}