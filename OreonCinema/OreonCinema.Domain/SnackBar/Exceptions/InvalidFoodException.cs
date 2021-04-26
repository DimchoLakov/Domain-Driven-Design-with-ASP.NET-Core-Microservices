namespace OreonCinema.Domain.SnackBar.Exceptions
{
    using OreonCinema.Domain.Common;

    public class InvalidFoodException : BaseDomainException
    {
        public InvalidFoodException()
        {
        }

        public InvalidFoodException(string error)
        {
            this.Error = error;
        }
    }
}
