using System;
using FluentAssertions;
using Xunit;

namespace ContactsCS.Tests
{
    public class ContactV3Tests
    {
        [Fact]
        public void ContactIsConstructedCorrectly()
        {
            var firstName = "James";
            var surname = "Bond";
            var dateOfBirth = new DateTime(1930, 1, 1);
            var emailAddress = "ShakenNotStirred@gmail.com";
            var phoneNumber = "0721000000";

            var james = new ContactV3(firstName: firstName,
                                      surname: surname,
                                      dateOfBirth: dateOfBirth,
                                      emailAddress: emailAddress,
                                      phoneNumber: phoneNumber);

            james.FirstName.Should().Be(firstName);
            james.Surname.Should().Be(surname);
            james.DateOfBirth.Should().Be(dateOfBirth);
            james.EmailAddress.DisplayName.Should().Be(emailAddress);
            james.EmailAddress.Address.Should().Be(emailAddress);
            james.PhoneNumber.DisplayShortNumber.Should().Be(phoneNumber);
            james.PhoneNumber.DisplayFullNumber.Should().Be("254721000000");


        }
    }
}