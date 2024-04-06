using FluentValidation;

namespace ValidationInheritanceLibrary.Validators;

public class TeacherCopyValidator : AbstractValidator<Teacher>
{
    public TeacherCopyValidator()
    {
        // The name must be specified, with a custom error message
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Please specify a name!");
        // The length of the name must be between 5 and 50 characters
        RuleFor(x => x.Name)
            .MinimumLength(5)
            .MaximumLength(50);
        // Date of birth cannot be today or later
        RuleFor(x => x.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Now));
        // Subject must be specified!
        RuleFor(x => x.Subject).NotEmpty().WithMessage("The subject the teacher takes must be specified!");
    }
}