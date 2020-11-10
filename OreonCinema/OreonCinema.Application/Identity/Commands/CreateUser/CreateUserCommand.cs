namespace OreonCinema.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(IIdentity identity) 
                => this.identity = identity;

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
                => await this.identity.Register(request);
        }
    }
}