namespace OreonCinema.Domain.Bookings.Exceptions
{
    using Common;

    public class InvalidSeatException : BaseDomainException
    {
        public InvalidSeatException()
        {
        }

        public InvalidSeatException(string error)
        {
            this.Error = error;
        }
    }
}
