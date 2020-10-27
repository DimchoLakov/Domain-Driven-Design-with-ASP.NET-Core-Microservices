using OreonCinema.Domain.Bookings.Exceptions;
using OreonCinema.Domain.Bookings.Models.Movies;
using System;

namespace OreonCinema.Domain.Bookings.Factories.Movies
{
    public class MovieFactory : IMovieFactory
    {
        private string title = default!;
        private int rating = default!;
        private DateTime startDateTime = default!;
        private DateTime endDateTime = default!;

        private bool isTitleSet = false;
        private bool isRatingSet = false;
        private bool isStartDateTimeSet = false;
        private bool isEndDateTimeSet = false;

        public IMovieFactory WithEndDateTime(DateTime endDateTime)
        {
            this.endDateTime = endDateTime;
            this.isEndDateTimeSet = true;

            return this;
        }

        public IMovieFactory WithRating(int rating)
        {
            this.rating = rating;
            this.isRatingSet = true;

            return this;
        }

        public IMovieFactory WithStartDateTime(DateTime startDateTime)
        {
            this.startDateTime = startDateTime;
            this.isStartDateTimeSet = true;

            return this;
        }

        public IMovieFactory WithTitle(string title)
        {
            this.title = title;
            this.isTitleSet = true;

            return this;
        }

        public Movie Build()
        {
            if (!this.isTitleSet ||
                !this.isStartDateTimeSet ||
                !this.isEndDateTimeSet ||
                !this.isRatingSet)
            {
                throw new InvalidMovieException("Title, Rating, StartDateTime, EndDateTime must have values.");
            }

            return new Movie(
                this.title,
                this.rating,
                this.startDateTime,
                this.endDateTime);
        }
    }
}
