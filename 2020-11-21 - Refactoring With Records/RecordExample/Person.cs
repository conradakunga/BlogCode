using System;

namespace RecordExample
{
    public record Person
    {
        public string FirstName { get; init; }
        public string Surname { get; init; }
        public string FullNames => $"{Surname}, {FirstName}";
        public byte Age => (byte)(DateTime.Now.Year - DateOfBirth.Year);
        public DateTime DateOfBirth { get; init; }
        public string NickName { get; init; }
    }
}
