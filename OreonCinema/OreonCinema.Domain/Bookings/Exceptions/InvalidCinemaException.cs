namespace OreonCinema.Domain.Bookings.Exceptions
{
    using Common;

    public class InvalidCinemaException : BaseDomainException
    {
        public InvalidCinemaException()
        {
        }

        public InvalidCinemaException(string error)
        {
            this.Error = error;
        }
    }
}
