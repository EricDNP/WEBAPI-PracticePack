using Application.UseCases.Common;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Users.ManageUser
{
    public class ManageUserUseCase : BaseManageUseCase<User, ManageUserInput, ManageUserOutput>, IManageUserUseCase
    {
        public ManageUserUseCase(IMapper mapper, IUserRepository userRepository)
            : base(mapper, userRepository)
        {

        }        
    }
}
