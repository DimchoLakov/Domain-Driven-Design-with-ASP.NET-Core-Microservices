namespace OreonCinema.Domain.SnackBar.Exceptions
{
    using OreonCinema.Domain.Common;

    public class InvalidDrinkException : BaseDomainException
    {
        public InvalidDrinkException()
        {
        }

        public InvalidDrinkException(string error)
        {
            this.Error = error;
        }
    }
}
