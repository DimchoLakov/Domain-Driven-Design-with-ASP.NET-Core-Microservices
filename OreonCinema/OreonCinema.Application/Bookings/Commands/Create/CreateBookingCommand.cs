namespace OreonCinema.Application.Bookings.Commands.Create
{
    using MediatR;
    using OreonCinema.Application.Common;
    using OreonCinema.Application.Common.Contracts;
    using OreonCinema.Domain.Bookings.Factories.Bookings;
    using OreonCinema.Domain.Bookings.Models.Bookings;
    using OreonCinema.Domain.Bookings.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBookingCommand : EntityCommand<int>, IRequest<int>
    {
        public int CinemaId { get; set; }

        public int MovieId { get; set; }

        public int ScreenId { get; set; }

        public int SeatId { get; set; }

        public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBookingFactory bookingFactory;
            private readonly ICinemaDomainRepository cinemaDomainRepository;
            private readonly IMovieDomainRepository movieDomainRepository;
            private readonly IBookingDomainRepository bookingDomainRepository;

            public CreateBookingCommandHandler(
                ICurrentUser currentUser,
                IBookingFactory bookingFactory,
                ICinemaDomainRepository cinemaDomainRepository,
                IMovieDomainRepository movieDomainRepository,
                IBookingDomainRepository bookingDomainRepository)
            {
                this.currentUser = currentUser;
                this.bookingFactory = bookingFactory;
                this.cinemaDomainRepository = cinemaDomainRepository;
                this.movieDomainRepository = movieDomainRepository;
                this.bookingDomainRepository = bookingDomainRepository;
            }

            public async Task<int> Handle(
                CreateBookingCommand request,
                CancellationToken cancellationToken)
            {
                var cinema = await this.cinemaDomainRepository
                    .Find(request.CinemaId, cancellationToken);

                var movie = await this.movieDomainRepository
                    .Find(request.MovieId, cancellationToken);

                var screen = await this.cinemaDomainRepository
                    .GetScreenById(request.ScreenId);

                var seat = await this.bookingDomainRepository
                    .GetSeatById(request.SeatId);

                var booking = this.bookingFactory
                    .WithCinema(cinema)
                    .WithMovie(movie)
                    .WithScreen(screen)
                    .WithSeat(seat)
                    .WithBookingStatus(BookingStatus.Booked)
                    .WithUserId(this.currentUser.UserId)
                    .Build();

                await this.bookingDomainRepository
                    .Save(booking, cancellationToken);

                return booking.Id;
            }
        }
    }
}
