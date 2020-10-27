namespace OreonCinema.Domain.Bookings.Factories.Cinemas
{
    using Common;
    using Models.Cinemas;

    public interface ICinemaFactory : IFactory<Cinema>
    {
        ICinemaFactory WithName(string name);

        ICinemaFactory WithPhone(string phone);

        ICinemaFactory WithAddress(
            string addressLine,
            string postCode,
            string town,
            string country);

        ICinemaFactory WithAddress(Address address);
    }
}
