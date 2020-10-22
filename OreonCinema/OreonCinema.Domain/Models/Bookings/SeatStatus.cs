namespace OreonCinema.Domain.Models.Bookings
{
    using OreonCinema.Domain.Common;

    public class SeatStatus : Enumeration
    {
        public static readonly SeatStatus Available = new SeatStatus(1, nameof(Available));
        public static readonly SeatStatus Booked = new SeatStatus(2, nameof(Booked));

        private SeatStatus(int value)
            : this(value, FromValue<SeatStatus>(value).Name)
        {
        }

        private SeatStatus(int value, string name)
            : base(value, name)
        {
        }
    }
}
