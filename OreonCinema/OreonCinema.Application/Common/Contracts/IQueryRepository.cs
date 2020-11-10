﻿namespace OreonCinema.Application.Common.Contracts
{
    using Domain.Common;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
