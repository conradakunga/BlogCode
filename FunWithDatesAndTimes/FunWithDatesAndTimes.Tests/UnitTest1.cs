using FunWithDatesAndTimes.Core;
using AutoBogus;
using Bogus;
using Person = FunWithDatesAndTimes.Core.Person;
using AutoBogus.Conventions;
using FluentAssertions;

namespace FunWithDatesAndTimes.Tests;

public class PersonTests
{
    private Faker<Person> faker;
    public PersonTests()
    {
        faker = new AutoFaker<Person>()
       .RuleFor(fake => fake.Surname, fake => fake.Person.LastName)
       .RuleFor(fake => fake.FirstName, fake => fake.Person.FirstName)
       .RuleFor(fake => fake.DateOfBirth, fake => DateOnly.FromDateTime(fake.Date.Past()));
    }
    [Fact]
    public void Person_Is_Created_Successfully()
    {
        var firstName = "James";
        var surname = "Bond";
        var registrationDate = DateTime.Now;
        var dateOfBirth = new DateOnly(2000, 1, 1);

        var person = new Person()
        {
            DateOfBirth = dateOfBirth,
            FirstName = firstName,
            Surname = surname,
            RegistrationDate = registrationDate
        };

        person.DateOfBirth.Should().Be(dateOfBirth);
        person.FirstName.Should().Be(firstName);
        person.Surname.Should().Be(surname);
        person.RegistrationDate.Should().Be(registrationDate);
    }
    [Fact]
    public void Person_Is_Modified_Successfully()
    {
        var person = faker.Generate();

        var firstName = "James";
        var surname = "Bond";
        var registrationDate = DateTime.Now;
        var dateOfBirth = new DateOnly(2000, 1, 1);

        person.FirstName = firstName;
        person.Surname = surname;
        person.DateOfBirth = dateOfBirth;
        person.RegistrationDate = registrationDate;

        person.DateOfBirth.Should().Be(dateOfBirth);
        person.FirstName.Should().Be(firstName);
        person.Surname.Should().Be(surname);
        person.RegistrationDate.Should().Be(registrationDate);
    }
}