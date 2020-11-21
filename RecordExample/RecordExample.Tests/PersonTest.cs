using System;
using FluentAssertions;
using Xunit;

namespace RecordExample.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Person_Is_Constructed_Correctly()
        {
            var p = new Person()
            {
                FirstName = "Bart",
                Surname = "Simpson",
                DateOfBirth = new DateTime(2000, 1, 1),
                NickName = "JoJo"
            };

            p.FirstName.Should().Be("Bart");
            p.Surname.Should().Be("Simpson");
            p.DateOfBirth.Should().Be(new DateTime(2000, 1, 1));
            p.NickName.Should().Be("JoJo");
            p.FullNames.Should().Be("Simpson, Bart");
            p.Age.Should().Be(20);
        }
    }
}
