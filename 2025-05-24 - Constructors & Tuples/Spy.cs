namespace ConstructorTuples.V1
{
    public sealed class Spy
    {
        public Spy(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public string FirstName { get; }
        public string Surname { get; }
    }
}

namespace ConstructorTuples.V2
{
    public sealed class Spy
    {
        public Spy(string firstName, string surname) => (FirstName, Surname) = (firstName, surname);

        public string FirstName { get; }
        public string Surname { get; }
    }
}