namespace OreonCinema.Domain.Bookings.Exceptions
{
    using Common;

    public class InvalidPaymentException : BaseDomainException
    {
        public InvalidPaymentException()
        {
        }

        public InvalidPaymentException(string error)
        {
            this.Error = error;
        }
    }
}
