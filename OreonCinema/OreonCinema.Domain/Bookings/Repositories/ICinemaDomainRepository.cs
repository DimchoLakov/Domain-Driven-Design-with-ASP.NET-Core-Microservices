namespace OreonCinema.Domain.Bookings.Repositories
{
    using OreonCinema.Domain.Bookings.Models.Cinemas;
    using OreonCinema.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICinemaDomainRepository : IDomainRepository<Cinema>
    {
        Task<Cinema> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Address> GetAddress(int cinemaId, CancellationToken cancellationToken = default);
    }
}
