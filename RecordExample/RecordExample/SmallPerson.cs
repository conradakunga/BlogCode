namespace RecordExample
{
    public record SmallPerson : Person
    {
        public byte Height { get; init; }
    }
}