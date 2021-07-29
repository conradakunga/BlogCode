using System;
using FluentAssertions;
using Xunit;

namespace ContactsCS.Tests
{
    public class ContactV1Tests
    {
        [Theory]
        [InlineData(1800)]
        [InlineData(2022)]
        public void InvalidContactByDateCannotBeConstructed(int year)
        {
            var ex = Record.Exception(() =>
            {
                var james = new ContactV1("james", "bond", new DateTime(year, 1, 1), "james@gmail.com", "32423424");
            });
            ex.Should().BeOfType<ArgumentNullException>();
        }
        [Fact]
        public void InvalidContactByValuesCannotBeConstructed()
        {
            var ex = Record.Exception(() =>
            {
                var james = new ContactV1("", "", new DateTime(2000, 1, 1), "", "");
            });
            ex.Should().BeOfType<ArgumentOutOfRangeException>();
        }
        [Theory]
        [InlineData(1950, 1, 71)]
        [InlineData(1950, 12, 71)]
        [InlineData(1960, 1, 61)]
        public void AgeIsComputedCorrectly(int birthYear, int birthMonth, byte age)
        {

            var james = new ContactV1("james", "bond", new DateTime(birthYear, birthMonth, 1), "james@gmail.com", "32423424");
            james.Age.Should().Be(age);
        }
        [Fact]
        public void ContactWithoutAgeHasAgeHandledComputedCorrectly()
        {

            var james = new ContactV1(firstName: "james", surname: "bond", emailAddress: "james@gmail.com", phoneNumber: "32423424");
            james.Age.Should().BeNull();
        }
        [Fact]
        public void ValidEmailIsAccepted()
        {

            var james = new ContactV1(firstName: "james", surname: "bond", emailAddress: "james@gmail.com", phoneNumber: "32423424");
            james.Age.Should().BeNull();
        }
        [Fact]
        public void InValidEmailIsRejected()
        {
            var ex = Record.Exception(() =>
            {
                var james = new ContactV1(firstName: "james", surname: "bond", emailAddress: "2423424242423", phoneNumber: "32423424");
            });
            ex.Should().BeOfType<ArgumentException>();
        }
    }
}