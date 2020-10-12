namespace OreonCinema.Domain.Exceptions
{
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
