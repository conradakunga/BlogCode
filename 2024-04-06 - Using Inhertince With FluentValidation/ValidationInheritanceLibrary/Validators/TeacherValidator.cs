using FluentValidation;

namespace ValidationInheritanceLibrary.Validators;

public class TeacherValidator<T> : PersonValidator<T> where T : Teacher
{
    public TeacherValidator()
    {
        // Subject must be specified!
        RuleFor(x => x.Subject).NotEmpty().WithMessage("The subject the teacher takes must be specified!");
    }
}