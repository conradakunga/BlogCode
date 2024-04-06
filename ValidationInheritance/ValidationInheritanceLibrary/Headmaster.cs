namespace ValidationInheritanceLibrary;

public record Headmaster : Teacher
{
    public required DateOnly AppointmentDate { get; init; }
}