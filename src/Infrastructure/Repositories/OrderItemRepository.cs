using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories.Common;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(IPracticePackDbContext context)
            : base(context)
        {

        }
    }
}
