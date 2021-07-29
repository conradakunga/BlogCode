using FluentAssertions;
using Xunit;

namespace ContactsCS.Tests
{
    public class PhoneNumberTests
    {
        [Fact]
        public void PhoneNumberIsConstructedCorrectly()
        {
            var kenya = new Country() { Name = "Kenya", CountryCode = "254" };
            var safaricom = new MobileOperator() { Name = "Safaricom", Prefix = "0721" };
            var phoneNumber = new PhoneNumber() { Country = kenya, MobileOperator = safaricom, Number = "000000" };
            phoneNumber.DisplayFullNumber.Should().Be("254721000000");
            phoneNumber.DisplayShortNumber.Should().Be("0721000000");
        }
        [Fact]
        public void PhoneNumberIsParsedCorrectly()
        {
            var kenya = new Country() { Name = "Kenya", CountryCode = "254" };
            var safaricom = new MobileOperator() { Name = "Safaricom", Prefix = "0721" };

            var inputPhoneNumber = "254721000000";
            var phoneNumber = PhoneNumber.Parse(inputPhoneNumber);
            phoneNumber.Country.CountryCode.Should().Be(kenya.CountryCode);
            phoneNumber.Country.Name.Should().Be(kenya.Name);
            phoneNumber.MobileOperator.Name.Should().Be(safaricom.Name);
            phoneNumber.MobileOperator.Prefix.Should().Be(safaricom.Prefix);
            phoneNumber.Number.Should().Be("000000");
            phoneNumber.DisplayFullNumber.Should().Be("254721000000");
            phoneNumber.DisplayShortNumber.Should().Be("0721000000");
        }
    }
}