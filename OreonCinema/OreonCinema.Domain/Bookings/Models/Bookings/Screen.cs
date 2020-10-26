namespace OreonCinema.Domain.Bookings.Models.Bookings
{
    using Common.Models;
    using OreonCinema.Domain.Bookings.Exceptions;
    using System.Collections.Generic;
    using System.Linq;

    using static ModelConstants.Screen;

    public class Screen : Entity<int>
    {
        private readonly HashSet<Seat> seats;

        internal Screen(string name, bool isAvailable)
        {
            this.ValidateName(name);

            this.Name = name;
            this.IsAvailable = isAvailable;

            this.seats = new HashSet<Seat>();
        }

        public string Name { get; private set; }
     
        public bool IsAvailable { get; private set; }

        public IReadOnlyCollection<Seat> Seats => this.seats.ToList().AsReadOnly();

        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidScreenException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
        }

        public void AddSeat(Seat seat)
        {
            this.seats.Add(seat);
        }

        public void ChangeAvailability()
        {
            this.IsAvailable = !this.IsAvailable;
        }
    }
}
