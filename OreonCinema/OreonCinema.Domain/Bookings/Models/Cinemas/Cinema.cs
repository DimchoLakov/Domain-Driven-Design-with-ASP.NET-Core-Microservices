namespace OreonCinema.Domain.Bookings.Models.Cinemas
{
    using Bookings;
    using Common;
    using Common.Models;
    using Exceptions;
    using System.Collections.Generic;
    using System.Linq;

    using static ModelConstants.Cinema;

    public class Cinema : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Screen> screens;

        internal Cinema(
            string name, 
            string phone, 
            int seatCapacity, 
            Address address)
        {
            this.Validate(name, phone);

            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.SeatCapacity = seatCapacity;

            this.screens = new HashSet<Screen>();
        }

        private Cinema()
        {
            this.Name = default!;
            this.Phone = default!;
            this.SeatCapacity = default!;
            this.Address = default!;

            this.screens = new HashSet<Screen>();
        }

        public string Name { get; private set; }

        public string Phone { get; private set; }

        public int SeatCapacity { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Screen> Screens => this.screens.ToList().AsReadOnly();

        private void Validate(string name, string phone)
        {
            this.ValidateName(name);
            this.ValidatePhone(phone);
        }

        private void ValidatePhone(string phone)
        {
            Guard.AgainstEmptyString<InvalidCinemaException>(phone, nameof(this.Phone));

            Guard.ForRegex<InvalidCinemaException>(
                phone,
                PhoneRegexPattern,
                nameof(this.Phone));
        }

        private void ValidateName(string name)
        {
            Guard.AgainstEmptyString<InvalidCinemaException>(name, nameof(this.Name));

            Guard.ForStringLength<InvalidCinemaException>(name, MinNameLength, MaxNameLength, nameof(this.Name));
        }
    }
}
