namespace OreonCinema.Domain.Bookings.Exceptions
{
    using Common;

    public class InvalidAddressException : BaseDomainException
    {
        public InvalidAddressException()
        {
        }

        public InvalidAddressException(string error)
        {
            this.Error = error;
        }
    }
}
