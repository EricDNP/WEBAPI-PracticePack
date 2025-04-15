namespace Application.UseCases.Users.RegisterUser
{
    public interface IRegisterUserUseCase
    {
        Task<RegisterUserOutput> Register(RegisterUserInput input);
    }
}
