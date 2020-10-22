namespace OreonCinema.Domain.Bookings.Exceptions
{
    using Common;

    public class InvalidMovieException : BaseDomainException
    {
        public InvalidMovieException()
        {
        }

        public InvalidMovieException(string error)
        {
            this.Error = error;
        }
    }
}
