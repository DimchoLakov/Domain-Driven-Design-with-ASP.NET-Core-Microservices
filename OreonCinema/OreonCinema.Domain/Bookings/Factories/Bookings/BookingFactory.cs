namespace OreonCinema.Domain.Bookings.Factories.Bookings
{
    using Exceptions;
    using Models.Bookings;
    using Models.Cinemas;
    using Models.Movies;
    using System;

    public class BookingFactory : IBookingFactory
    {
        private Cinema cinema = default!;
        private Movie movie = default!;
        private Screen screen = default!;
        private Seat seat = default!;
        private BookingStatus bookingStatus = default!;

        private bool isCinemaSet = false;
        private bool isMovieSet = false;
        private bool isScreenSet = false;
        private bool isSeatSet = false;
        private bool isBookingStatusSet = false;

        public IBookingFactory WithCinema(string name, string phone, Address address)
            => this.WithCinema(new Cinema(name, phone, address));

        public IBookingFactory WithCinema(Cinema cinema)
        {
            this.cinema = cinema;
            this.isCinemaSet = true;

            return this;
        }

        public IBookingFactory WithMovie(string title, int rating, DateTime startDateTime, DateTime endDateTime)
            => this.WithMovie(new Movie(title, rating, startDateTime, endDateTime));

        public IBookingFactory WithMovie(Movie movie)
        {
            this.movie = movie;
            this.isMovieSet = true;

            return this;
        }

        public IBookingFactory WithScreen(string name, bool isAvailable)
            => this.WithScreen(new Screen(name, isAvailable));

        public IBookingFactory WithScreen(Screen screen)
        {
            this.screen = screen;
            this.isScreenSet = true;

            return this;
        }

        public IBookingFactory WithSeat(int rowNumber, string rowLetter, SeatStatus seatStatus)
            => this.WithSeat(new Seat(rowNumber, rowLetter, seatStatus));

        public IBookingFactory WithSeat(Seat seat)
        {
            this.seat = seat;
            this.isSeatSet = true;

            return this;
        }

        public IBookingFactory WithBookingStatus(BookingStatus bookingStatus)
        {
            this.bookingStatus = bookingStatus;
            this.isBookingStatusSet = true;

            return this;
        }

        public Booking Build()
        {
            if (!this.isCinemaSet ||
                !this.isMovieSet ||
                !this.isScreenSet ||
                !this.isSeatSet ||
                !this.isBookingStatusSet)
            {
                throw new InvalidBookingException("Cinema, Movie, Screen, Seat and BookingStatus must have a value.");
            }

            return new Booking(
                this.cinema, 
                this.movie, 
                this.screen, 
                this.seat, 
                this.bookingStatus);
        }
    }
}
