using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Users.SearchUser
{
    public class SearchUserUseCase : BaseSearchUseCase<User, SearchUserOutput>, ISearchUserUseCase
    {
        public SearchUserUseCase(IMapper mapper, IUserRepository userRepository)
            : base(mapper, userRepository)
        {
            
        }
    }
}
