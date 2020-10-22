namespace OreonCinema.Domain.Exceptions
{
    public class InvalidSeatException : BaseDomainException
    {
        public InvalidSeatException()
        {
        }

        public InvalidSeatException(string error)
        {
            this.Error = Error;
        }
    }
}
