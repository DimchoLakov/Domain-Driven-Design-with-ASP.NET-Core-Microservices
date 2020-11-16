namespace OreonCinema.Application.Bookings.Commands.Create
{
    public class CreateBookingOutputModel
    {
        public CreateBookingOutputModel(int bookingId)
        {
            this.BookingId = bookingId;
        }

        public int BookingId { get; }
    }
}