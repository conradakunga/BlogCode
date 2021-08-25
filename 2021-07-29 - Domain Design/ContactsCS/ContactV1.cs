using System;
using System.Text.RegularExpressions;

namespace ContactsCS
{
    public class ContactV1
    {
        public string FirstName { get; }
        public string Surname { get; }
        public DateTime? DateOfBirth { get; }
        public string EmailAddress { get; }
        public string PhoneNumber { get; }
        public byte? Age
        {
            get
            {
                if (DateOfBirth.HasValue)
                    return (byte)(DateTime.Today.Year - DateOfBirth.Value.Year);
                return null;
            }
        }
        public string DisplayAge => Age == null ? "Unknown" : $"{Age}";
        public ContactV1(string firstName, string surname, DateTime dateOfBirth, string emailAddress, string phoneNumber)
            : this(firstName, surname, emailAddress, phoneNumber)
        {
            if (dateOfBirth < new DateTime(1900, 1, 1) || dateOfBirth >= DateTime.Today)
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth));

            DateOfBirth = dateOfBirth;
        }
        public ContactV1(string firstName, string surname, string emailAddress, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentNullException(nameof(surname));
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentNullException(nameof(emailAddress));
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            // Validate the email
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(emailAddress))
                throw new ArgumentException($"{emailAddress} is an invalid email");

            FirstName = firstName;
            Surname = surname;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }
    }
}