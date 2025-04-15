using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Users.ManageUser
{
    public interface IManageUserUseCase : IBaseManageUseCase<User, ManageUserInput,ManageUserOutput>
    {

    }
}
