using FluentValidation;

namespace ValidationInheritanceLibrary.Validators;

public class HeadmasterValidator<T> : TeacherValidator<T> where T : Headmaster
{
    public HeadmasterValidator()
    {
        // Appointment date must be specified!
        RuleFor(x => x.AppointmentDate)
            .NotEmpty();
        // Appointment date must be in the past
        RuleFor(x => x.AppointmentDate)
            .LessThan(DateOnly.FromDateTime(DateTime.Now));
        // Headmaster cannot be a maths teacher
        RuleFor(x => x.Subject)
            .NotEqual("Mathematics").WithMessage("The headmaster cannot be a Mathematics teacher");
        // Headmaster must be at least 20 years old. Return the actual age in the error message (filled by the {PropertyValue} placeholder)
        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(20)
            .WithMessage(
                "The headmaster is currently {PropertyValue} and therefore is too young. Should be 20 or older");
    }
}