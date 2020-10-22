namespace OreonCinema.Domain.Bookings.Models.Bookings
{
    using Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Screen : Entity<int>
    {
        private readonly HashSet<Seat> seats;

        internal Screen(string name, bool isAvailable)
        {
            this.Name = name;
            this.IsAvailable = isAvailable;

            this.seats = new HashSet<Seat>();
        }

        public string Name { get; private set; }
     
        public bool IsAvailable { get; private set; }

        public IReadOnlyCollection<Seat> Seats => this.seats.ToList().AsReadOnly();
    }
}
