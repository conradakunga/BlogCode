using System;
using System.Text.Json;

namespace TypesLogic
{
    public static class Converter
    {
        public static string ToJson(Person p)
        {
            var json = "";
            // build the data we need
            var name = p.FirstName + " " + p.Surname;
            var age = DateTime.Now.Year - p.DateOfBirth.Year;
            var dateOfBirth = DateTime.Now.ToString("yyyy-MM-dd");
            // create the object payload
            var payload = new { surname = name, age = age, dateOfBirth = dateOfBirth };
            json = JsonSerializer.Serialize(payload, new JsonSerializerOptions() { WriteIndented = true });
            return json;
        }
    }
}