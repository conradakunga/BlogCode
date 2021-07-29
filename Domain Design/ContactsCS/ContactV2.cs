using System;
using System.Text.RegularExpressions;

namespace ContactsCS
{
    public class ContactV2
    {
        public string FirstName { get; }
        public string Surname { get; }
        public DateTime? DateOfBirth { get; }
        public EmailAddress EmailAddress { get; }
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
        public string DisplayAge
        {
            get
            {
                if (DateOfBirth.HasValue)
                    return $"{DateTime.Today.Year - DateOfBirth.Value.Year}";
                return "Age unknown";
            }
        }
        public ContactV2(string firstName, string surname, DateTime dateOfBirth, string emailAddress, string phoneNumber)
            : this(firstName, surname, emailAddress, phoneNumber)
        {
            if (dateOfBirth < new DateTime(1900, 1, 1) || dateOfBirth >= DateTime.Today)
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth));

            DateOfBirth = dateOfBirth;
        }
        public void SendEmail(string emailAddress)
        {

        }
        public void SendEmail(EmailAddress emailAddress)
        {

        }
        public ContactV2(string firstName, string surname, string emailAddress, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentNullException(nameof(surname));
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentNullException(nameof(emailAddress));
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            FirstName = firstName;
            Surname = surname;
            EmailAddress = new EmailAddress(emailAddress);
            PhoneNumber = phoneNumber;
        }
    }
}