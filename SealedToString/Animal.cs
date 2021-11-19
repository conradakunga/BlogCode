namespace SealedToString
{
    public record Animal
    {
        public string Name { get; set; }
        public sealed override string ToString()
        {
            return $"I am a {Name}";
        }

    }
    public record Dog : Animal
    {

    }
}