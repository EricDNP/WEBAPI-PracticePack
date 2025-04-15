using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories.Common;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IPracticePackDbContext context)
            : base(context)
        {

        }
    }
}
