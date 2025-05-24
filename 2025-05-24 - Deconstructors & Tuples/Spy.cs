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

        // Deconstructor
        public void Deconstruct(out string firstname, out string surname)
        {
            firstname = FirstName;
            surname = Surname;
        }
    }
}

namespace ConstructorTuples.V2
{
    public sealed class Spy
    {
        public Spy(string firstName, string surname) => (FirstName, Surname) = (firstName, surname);

        public string FirstName { get; }
        public string Surname { get; }

        // Deconstructor
        public void Deconstruct(out string firstname, out string surname) =>
            (firstname, surname) = (FirstName, Surname);
    }
}