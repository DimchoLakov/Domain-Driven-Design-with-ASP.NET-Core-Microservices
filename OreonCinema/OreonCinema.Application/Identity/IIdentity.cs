namespace OreonCinema.Application.Identity
{
    using Commands;
    using Commands.ChangePassword;
    using Commands.LoginUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
