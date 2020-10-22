namespace OreonCinema.Domain.Models.Bookings
{
    using OreonCinema.Domain.Common;

    public class BookingStatus : Enumeration
    {
        public static readonly BookingStatus Started = new BookingStatus(1, nameof(Started));
        public static readonly BookingStatus Booked = new BookingStatus(2, nameof(Booked));
        public static readonly BookingStatus Cancelled = new BookingStatus(3, nameof(Cancelled));

        private BookingStatus(int value)
            : this(value, FromValue<BookingStatus>(value).Name)
        {
        }

        private BookingStatus(int value, string name) 
            : base(value, name)
        {
        }
    }
}
