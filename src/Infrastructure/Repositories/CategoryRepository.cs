using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories.Common;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PracticePackDbContext context)
            : base(context)
        {

        }
    }
}
