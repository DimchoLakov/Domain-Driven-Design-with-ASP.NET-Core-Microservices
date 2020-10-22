namespace OreonCinema.Domain.Bookings.Models.Cinemas
{
    using Common.Models;
    using Exceptions;

    using static ModelConstants.Address;

    public class Address : ValueObject
    {
        internal Address(
            string addressLine,
            string postCode,
            string town,
            string country)
        {
            this.Validate(
                addressLine,
                postCode,
                town,
                country);

            this.AddressLine = addressLine;
            this.PostCode = postCode;
            this.Town = town;
            this.Country = country;
        }

        public string AddressLine { get; private set; }

        public string PostCode { get; private set; }

        public string Town { get; private set; }

        public string Country { get; private set; }

        private void Validate(string addressLine, string postCode, string town, string country)
        {
            this.ValidateAddressLine(addressLine);
            this.ValidatePostCode(postCode);
            this.ValidateTown(town);
            this.ValidateCountry(country);
        }

        private void ValidateAddressLine(string addressLine)
        {
            Guard.ForStringLength<InvalidAddressException>(
                addressLine,
                MinAddressLineLength,
                MaxAddressLineLength,
                nameof(this.AddressLine));
        }

        private void ValidatePostCode(string postCode)
        {
            Guard.ForStringLength<InvalidAddressException>(
                postCode,
                MinPostCodeLength,
                MaxPostCodeLength,
                nameof(this.PostCode));
        }

        private void ValidateTown(string town)
        {
            Guard.ForStringLength<InvalidAddressException>(
                town,
                MinTownLength,
                MaxTownLength,
                nameof(this.Town));
        }

        private void ValidateCountry(string country)
        {
            Guard.ForStringLength<InvalidAddressException>(
                country,
                MinCountryLength,
                MaxCountryLength,
                nameof(this.Country));
        }
    }
}
