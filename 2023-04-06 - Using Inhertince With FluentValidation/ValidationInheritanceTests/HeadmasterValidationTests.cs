using FluentAssertions;
using FluentValidation;
using ValidationInheritanceLibrary;
using ValidationInheritanceLibrary.Validators;

namespace ValidationInheritanceTests;

public class HeadmasterValidationTests
{
    [Fact]
    public void Headmaster_Can_Be_Validated_By_PersonValidator()
    {
        var teacher = new Headmaster
        {
            Name = "",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Subject = "",
            AppointmentDate = DateOnly.FromDateTime(DateTime.Now)
        };

        var validator = new PersonValidator<Headmaster>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeOfType<ValidationException>();
        var errors = ((ValidationException)result).Errors.Count();
        errors.Should().Be(3);
    }

    [Fact]
    public void Headmaster_Can_Be_Validated_By_TeacherValidator()
    {
        var teacher = new Headmaster
        {
            Name = "",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Subject = "",
            AppointmentDate = DateOnly.FromDateTime(DateTime.Now)
        };

        var validator = new PersonValidator<Headmaster>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeOfType<ValidationException>();
        var errors = ((ValidationException)result).Errors.Count();
        errors.Should().Be(3);
    }

    [Fact]
    public void Headmaster_When_Invalid_Throws_6_Errors()
    {
        var teacher = new Headmaster
        {
            Name = "",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Subject = "",
            AppointmentDate = DateOnly.FromDateTime(DateTime.Now)
        };

        var validator = new HeadmasterValidator<Headmaster>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeOfType<ValidationException>();
        var errors = ((ValidationException)result).Errors.Count();
        errors.Should().Be(6);
    }

    [Fact]
    public void Headmaster_When_Valid_Succeeds()
    {
        var teacher = new Headmaster
        {
            Name = "James Bond",
            DateOfBirth = new DateOnly(1960, 1, 1),
            Subject = "Chemistry",
            AppointmentDate = new DateOnly(2022, 1, 1)
        };

        var validator = new HeadmasterValidator<Headmaster>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeNull();
    }

    [Fact]
    public void Headmaster_Validation_Fails_When_MathematicsTeacher()
    {
        var teacher = new Headmaster
        {
            Name = "James Bond",
            DateOfBirth = new DateOnly(1960, 1, 1),
            Subject = "Mathematics",
            AppointmentDate = new DateOnly(2022, 1, 1)
        };

        var validator = new HeadmasterValidator<Headmaster>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeOfType<ValidationException>();
        // Verify the returned error message is expected
        result.Message.Should().Contain("The headmaster cannot be a Mathematics teacher");
    }

    [Fact]
    public void Headmaster_Validation_Fails_When_Younger_Than_20()
    {
        var currentYear = DateTime.Now.Year;

        var teacher = new Headmaster
        {
            Name = "James Bond",
            DateOfBirth = new DateOnly(currentYear - 19, 1, 1),
            Subject = "Physics",
            AppointmentDate = new DateOnly(2022, 1, 1)
        };

        var validator = new HeadmasterValidator<Headmaster>();
        var result = Record.Exception(() => validator.ValidateAndThrow(teacher))!;
        result.Should().BeOfType<ValidationException>();
        // Verify the returned error message is expected
        result.Message.Should().Contain("19 and therefore is too young");
    }
}