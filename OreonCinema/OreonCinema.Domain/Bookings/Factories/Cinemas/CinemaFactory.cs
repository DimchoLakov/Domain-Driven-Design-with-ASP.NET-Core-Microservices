using OreonCinema.Domain.Bookings.Exceptions;
using OreonCinema.Domain.Bookings.Models.Cinemas;

namespace OreonCinema.Domain.Bookings.Factories.Cinemas
{
    public class CinemaFactory : ICinemaFactory
    {
        private string name = default!;
        private string phone = default!;
        private Address address = default!;

        private bool isNameSet = false;
        private bool isPhoneSet = false;
        private bool isAddressSet = false;

        public ICinemaFactory WithAddress(
            string addressLine,
            string postCode,
            string town,
            string country)
           => this.WithAddress(new Address(addressLine, postCode, town, country));


        public ICinemaFactory WithAddress(Address address)
        {
            this.address = address;
            this.isAddressSet = true;

            return this;
        }

        public ICinemaFactory WithName(string name)
        {
            this.name = name;
            this.isNameSet = true;

            return this;
        }

        public ICinemaFactory WithPhone(string phone)
        {
            this.phone = phone;
            this.isPhoneSet = true;

            return this;
        }

        public Cinema Build()
        {
            if (!this.isNameSet ||
                !this.isPhoneSet ||
                !this.isAddressSet)
            {
                throw new InvalidCinemaException("Name, Phone and Address properties must have values.");
            }

            return new Cinema(
                this.name, 
                this.phone,
                this.address);
        }
    }
}
