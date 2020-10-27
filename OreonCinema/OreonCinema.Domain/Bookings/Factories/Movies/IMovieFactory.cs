namespace OreonCinema.Domain.Bookings.Factories.Movies
{
    using Common;
    using Models.Movies;
    using System;

    public interface IMovieFactory : IFactory<Movie>
    {
        IMovieFactory WithTitle(string title);

        IMovieFactory WithRating(int rating);

        IMovieFactory WithStartDateTime(DateTime startDateTime);

        IMovieFactory WithEndDateTime(DateTime endDateTime);
    }
}
