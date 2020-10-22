namespace OreonCinema.Domain.Bookings.Models.Movies
{
    using Common;
    using Common.Models;
    using Exceptions;
    using Models.Bookings;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static ModelConstants.Movie;

    public class Movie : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Screen> screens;

        internal Movie(
            string title,
            int rating,
            DateTime startDateTime,
            DateTime endDateTime)
        {
            this.Validate(
                title,
                rating,
                startDateTime,
                endDateTime);

            this.Title = title;
            this.Rating = rating;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;

            this.screens = new HashSet<Screen>();
        }

        public string Title { get; private set; }

        public int Rating { get; private set; }

        public DateTime StartDateTime { get; private set; }

        public DateTime EndDateTime { get; private set; }

        public IReadOnlyCollection<Screen> Screens => this.screens.ToList().AsReadOnly();

        private void Validate(string title, int rating, DateTime start, DateTime end)
        {
            this.ValidateTitle(title);
            this.ValidateRating(rating);
            this.ValidateStartEndDates(start, end);
        }

        private void ValidateStartEndDates(DateTime startDateTime, DateTime endDateTime)
        {
            Guard.AgainstDateOverlap<InvalidMovieException>(
                startDateTime, 
                endDateTime, 
                nameof(this.StartDateTime), 
                nameof(this.EndDateTime));
        }

        private void ValidateRating(int rating)
        {
            Guard.AgainstOutOfRange<InvalidMovieException>(
                rating,
                MinRating,
                MaxRating,
                nameof(this.Rating));
        }

        private void ValidateTitle(string title)
        {
            Guard.AgainstEmptyString<InvalidMovieException>(title, nameof(this.Title));

            Guard.ForStringLength<InvalidMovieException>(
                title,
                MinTitleLength,
                MaxTitleLength,
                nameof(this.Title));
        }
    }
}
