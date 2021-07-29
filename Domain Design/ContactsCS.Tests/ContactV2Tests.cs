using System;
using FluentAssertions;
using Xunit;

namespace ContactsCS.Tests
{
    public class ContactV2Tests
    {
        [Fact]
        public void ContactIsConstructedCorrectly()
        {
            var firstName = "James";
            var surname = "Bond";
            var dateOfBirth = new DateTime(1930, 1, 1);
            var emailAddress = "ShakenNotStirred@gmail.com";
            var phoneNumber = "555-444-33-2";

            var james = new ContactV2(firstName: firstName,
                                      surname: surname,
                                      dateOfBirth: dateOfBirth,
                                      emailAddress: emailAddress,
                                      phoneNumber: phoneNumber);

            james.FirstName.Should().Be(firstName);
            james.Surname.Should().Be(surname);
            james.DateOfBirth.Should().Be(dateOfBirth);
            james.EmailAddress.DisplayName.Should().Be(emailAddress);
            james.EmailAddress.Address.Should().Be(emailAddress);
            james.PhoneNumber.Should().Be(phoneNumber);

            
        }
    }
}