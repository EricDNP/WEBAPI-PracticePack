using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Users.RemoveUser
{
    public class RemoveUserUseCase : BaseRemoveUseCase<User> , IRemoveUserUseCase
    {
        public RemoveUserUseCase(IUserRepository userRepository)
            : base(userRepository)
        {
            
        }
    }
}
