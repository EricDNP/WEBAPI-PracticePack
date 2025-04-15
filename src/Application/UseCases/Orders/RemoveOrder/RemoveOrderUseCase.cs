using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Orders.RemoveOrder
{
    public class RemoveOrderUseCase : BaseRemoveUseCase<Order> , IRemoveOrderUseCase
    {
        public RemoveOrderUseCase(IOrderRepository orderRepository)
            : base(orderRepository)
        {
            
        }
    }
}
