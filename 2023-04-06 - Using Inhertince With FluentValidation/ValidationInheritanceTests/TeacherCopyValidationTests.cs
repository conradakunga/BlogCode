using FluentAssertions;
using FluentValidation;
using ValidationInheritanceLibrary;
using ValidationInheritanceLibrary.Validators;

namespace ValidationInheritanceTests;

public class TeacherCopyValidationTests
{
    [Fact]
    public void Teacher_When_Invalid_Throws_4_Errors()
    {
        var teacher = new Teacher
        {
            Name = "",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Subject = ""
        };

        var validator = new TeacherCopyValidator();
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

        var validator = new TeacherCopyValidator();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeNull();
    }
}