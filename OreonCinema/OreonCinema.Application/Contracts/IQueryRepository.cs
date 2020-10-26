namespace OreonCinema.Application.Contracts
{
    using Domain.Common;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
