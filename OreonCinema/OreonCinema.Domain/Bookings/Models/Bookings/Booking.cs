namespace OreonCinema.Domain.Bookings.Models.Bookings
{
    using Cinemas;
    using Common;
    using Common.Models;
    using Models.Movies;
    using OreonCinema.Domain.Bookings.Exceptions;
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

        public Booking ChangeCinema(Cinema cinema)
        {
            this.Cinema = cinema;

            return this;
        }

        public Booking ChangeMovie(Movie movie)
        {
            this.Movie = movie;

            return this;
        }

        public Booking ChangeSeat(int rowNumber, string rowLetter, SeatStatus seatStatus)
        {
            this.Seat = new Seat(rowNumber, rowLetter, seatStatus);

            return this;
        }

        public Booking UpdateBookingStatus(BookingStatus bookingStatus)
        {
            this.BookingStatus = bookingStatus;

            return this;
        }

        public void ChangeOnDate(DateTime onDate)
        {
            this.ValidateChangeOnDate(onDate);

            this.OnDate = onDate;
        }

        private void ValidateChangeOnDate(DateTime onDate)
        {
            Guard.AgainstDateOutOfRange<InvalidBookingException>(
                onDate,
                DateTime.Now.AddDays(2),
                DateTime.Now.AddDays(10));
        }
    }
}
