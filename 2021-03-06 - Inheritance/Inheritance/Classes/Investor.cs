using System;

namespace Inheritance
{
    public class Investor
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}