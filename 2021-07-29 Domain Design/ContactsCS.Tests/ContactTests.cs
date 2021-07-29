using System;
using FluentAssertions;
using Xunit;

namespace ContactsCS.Tests
{
    public class ContactTests
    {
        [Fact]
        public void ContactIsConstructedCorrectly()
        {
            var firstName = "James";
            var surname = "Bond";
            var dateOfBirth = new DateTime(1930, 1, 1);
            var emailAddress = "ShakenNotStirred@gmail.com";
            var phoneNumber = "555-444-33-2";

            var james = new Contact()
            {
                FirstName = firstName,
                Surname = surname,
                DateOfBirth = dateOfBirth,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber
            };

            james.FirstName.Should().Be(firstName);
            james.Surname.Should().Be(surname);
            james.DateOfBirth.Should().Be(dateOfBirth);
            james.EmailAddress.Should().Be(emailAddress);
            james.PhoneNumber.Should().Be(phoneNumber);

        }
        [Fact]
        public void ItIsPossibleToConstuctAConcactWithoutInputs()
        {
            var james = new Contact();

            james.FirstName.Should().Be(default(string));
            james.Surname.Should().Be(default(string));
            james.DateOfBirth.Should().Be(default(DateTime));
            james.EmailAddress.Should().Be(default(string));
            james.PhoneNumber.Should().Be(default(string));

        }
    }
}
