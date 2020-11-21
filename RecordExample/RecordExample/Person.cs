using System;

namespace RecordExample
{
    public class Person
    {
        public string FirstName { get; }
        public string Surname { get; }
        public string FullNames => $"{Surname}, {FirstName}";
        public byte Age => (byte)(DateTime.Now.Year - DateOfBirth.Year);
        public DateTime DateOfBirth { get; }
        public string NickName { get; }

        public Person(string firstName, string surname, DateTime dateOfBirth, string nickName) =>
            (FirstName, Surname, DateOfBirth, NickName) = (firstName, surname, dateOfBirth, nickName);
    }
}
