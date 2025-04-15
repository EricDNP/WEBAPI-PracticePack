using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.OrderItems.RemoveOrderItem
{
    public class RemoveOrderItemUseCase : BaseRemoveUseCase<OrderItem> , IRemoveOrderItemUseCase
    {
        public RemoveOrderItemUseCase(IOrderItemRepository orderItemRepository)
            : base(orderItemRepository)
        {
            
        }
    }
}
