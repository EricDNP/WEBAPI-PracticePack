using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Users.SearchUser
{
    public interface ISearchUserUseCase : IBaseSearchUseCase<User, SearchUserOutput>
    {

    }
}
