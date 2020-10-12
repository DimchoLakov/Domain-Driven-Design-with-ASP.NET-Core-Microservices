using OreonCinema.Domain.Common;

namespace OreonCinema.Domain.Models.Bookings
{
    public class BookingStatus : Enumeration
    {
        public static readonly BookingStatus Started = new BookingStatus(1, nameof(Started));
        public static readonly BookingStatus InProgress = new BookingStatus(2, nameof(InProgress));
        public static readonly BookingStatus Booked = new BookingStatus(3, nameof(Booked));
        public static readonly BookingStatus Cancelled = new BookingStatus(4, nameof(Cancelled));

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
