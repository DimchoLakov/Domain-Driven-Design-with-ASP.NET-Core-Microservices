namespace OreonCinema.Domain.Exceptions
{
    public class InvalidPaymentException : BaseDomainException
    {
        public InvalidPaymentException()
        {
        }

        public InvalidPaymentException(string error)
        {
            this.Error = Error;
        }
    }
}
