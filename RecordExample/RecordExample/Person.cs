using System;

namespace RecordExample
{
    public class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string FullNames => $"{Surname}, {FirstName}";
        public byte Age => (byte)(DateTime.Now.Year - DateOfBirth.Year);
        public DateTime DateOfBirth { get; set; }
        public string NickName { get; set; }
    }
}
