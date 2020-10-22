namespace OreonCinema.Domain.Bookings.Models.Bookings
{
    using Common.Models;

    public class PaymentStatus : Enumeration
    {
        public static readonly PaymentStatus Pending = new PaymentStatus(1, nameof(Pending));
        public static readonly PaymentStatus Completed = new PaymentStatus(2, nameof(Completed));
        public static readonly PaymentStatus Cancelled = new PaymentStatus(3, nameof(Cancelled));

        private PaymentStatus(int value)
           : this(value, FromValue<PaymentStatus>(value).Name)
        {
        }

        private PaymentStatus(int value, string name)
            : base(value, name)
        {
        }
    }
}
