using OreonCinema.Domain.Common;

namespace OreonCinema.Domain.Bookings.Exceptions
{
    public class InvalidBookingException : BaseDomainException
    {
        public InvalidBookingException()
        {
        }

        public InvalidBookingException(string error)
        {
            this.Error = error;
        }
    }
}
