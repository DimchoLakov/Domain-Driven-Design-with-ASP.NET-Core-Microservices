namespace OreonCinema.Domain.Bookings.Repositories
{
    using Common;
    using Models.Bookings;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBookingDomainRepository : IDomainRepository<Booking>
    {
        Task<Seat> GetSeatById(int seatId, CancellationToken cancellationToken = default);
    }
}
