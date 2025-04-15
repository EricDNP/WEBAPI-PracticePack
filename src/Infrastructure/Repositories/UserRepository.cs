using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories.Common;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IPracticePackDbContext context)
            : base(context)
        {

        }
    }
}
