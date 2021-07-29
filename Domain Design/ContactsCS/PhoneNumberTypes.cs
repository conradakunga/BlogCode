namespace ContactsCS
{
    /// <summary>
    /// These types should be immutable and should have object construction and validation enforced
    /// in constructors.
    /// </summary>
    public class Country
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
    public class MobileOperator
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
    }
    public class PhoneNumber
    {
        public Country Country { get; set; }
        public MobileOperator MobileOperator { get; set; }
        public string Number { get; set; }
        public string DisplayFullNumber => $"{Country.CountryCode}{MobileOperator.Prefix.Substring(1, 3)}{Number}";
        public string DisplayShortNumber => $"{MobileOperator.Prefix}{Number}";

        public static PhoneNumber Parse(string input)
        {

            Country country = null;
            MobileOperator mobileOperator = null;

            //
            // This is a MASSIVELY simplified algorithm!
            //

            var parsedCountry = input.Substring(0, 3);
            if (parsedCountry == "254")
                country = new Country() { Name = "Kenya", CountryCode = "254" };

            var parsedMobileOperator = input.Substring(3, 3);
            if (parsedMobileOperator == "721")
                mobileOperator = new MobileOperator() { Name = "Safaricom", Prefix = "0721" };

            return new PhoneNumber()
            {
                Country = country,
                MobileOperator = mobileOperator,
                Number = input.Substring(6, input.Length - 6)
            };
        }
    }

}