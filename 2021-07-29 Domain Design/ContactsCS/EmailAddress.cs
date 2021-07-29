using System;
using System.Text.RegularExpressions;

namespace ContactsCS
{
    public class EmailAddress
    {
        public string DisplayName { get; }
        public string Address { get; }
        public EmailAddress(string displayName, string address)
            : this(address)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentNullException(nameof(displayName));

            DisplayName = displayName;
        }
        public EmailAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException(nameof(address));

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
        + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
        + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(address))
                throw new ArgumentException($"{address} is an invalid email");

            Address = address;
            DisplayName = address;
        }
    }
}