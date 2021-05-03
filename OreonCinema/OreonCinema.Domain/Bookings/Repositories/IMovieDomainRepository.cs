namespace OreonCinema.Domain.Bookings.Repositories
{
    using Common;
    using Models.Movies;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMovieDomainRepository : IDomainRepository<Movie>
    {
        Task<Movie> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
