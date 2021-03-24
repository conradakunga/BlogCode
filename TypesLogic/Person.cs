using System;
using System.Text.Json.Serialization;

namespace TypesLogic
{
    public class Person
    {
        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string Surname { get; set; }
        public string FullName => $"{FirstName} {Surname}";
        [JsonIgnore]
        public DateTime DateOfBirth { get; set; }
        [JsonPropertyName("dateOfBirth")]
        public string DateOfString => DateOfBirth.ToString("yyyy-MM-dd");
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
    }
}