namespace OreonCinema.Domain.Bookings.Factories.Bookings
{
    using Common;
    using Models.Bookings;
    using Models.Cinemas;
    using Models.Movies;

    public interface IBookingFactory : IFactory<Booking>
    {
        IBookingFactory WithCinema(Cinema cinema);

        IBookingFactory WithMovie(Movie movie);

        IBookingFactory WithScreen(Screen screen);

        IBookingFactory WithSeat(Seat seat);

        IBookingFactory WithBookingStatus(BookingStatus bookingStatus);
    }
}
