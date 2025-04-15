namespace Application.UseCases.Users.LoginUser
{
    public interface ILoginUserUseCase
    {
        Task<LoginUserOutput?> Login(LoginUserInput input);
    }
}
