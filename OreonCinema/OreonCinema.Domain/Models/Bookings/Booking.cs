namespace OreonCinema.Domain.Models.Bookings
{
    using OreonCinema.Domain.Common;
    using System;

    public class Booking : Entity<int>, IAggregateRoot
    {
        internal Booking(
            Cinema cinema, 
            Movie movie, 
            Screen screen, 
            Seat seat,
            BookingStatus bookingStatus)
        {
            this.Cinema = cinema;
            this.Movie = movie;
            this.Screen = screen;
            this.Seat = seat;
            this.OnDate = DateTime.Now;
            this.BookingStatus = bookingStatus;
        }

        private Booking()
        {
            this.Cinema = default!;
            this.Movie = default!;
            this.Screen = default!;
            this.Seat = default!;
            this.BookingStatus = default!;

            this.OnDate = DateTime.Now;
        }

        public DateTime OnDate { get; private set; }

        public Cinema Cinema { get; private set; }

        public Movie Movie { get; private set; }

        public Screen Screen { get; private set; }

        public Seat Seat { get; private set; }

        public BookingStatus BookingStatus { get; private set; }
    }
}
