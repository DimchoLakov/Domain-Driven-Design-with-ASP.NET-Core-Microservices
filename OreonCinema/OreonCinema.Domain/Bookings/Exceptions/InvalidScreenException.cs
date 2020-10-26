using OreonCinema.Domain.Common;

namespace OreonCinema.Domain.Bookings.Exceptions
{
    public class InvalidScreenException : BaseDomainException
    {
        public InvalidScreenException()
        {
        }

        public InvalidScreenException(string error)
        {
            this.Error = error;
        }
    }
}
