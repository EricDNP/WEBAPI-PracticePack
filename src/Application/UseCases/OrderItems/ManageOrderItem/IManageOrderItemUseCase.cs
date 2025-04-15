using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.OrderItems.ManageOrderItem
{
    public interface IManageOrderItemUseCase : IBaseManageUseCase<OrderItem, ManageOrderItemInput,ManageOrderItemOutput>
    {

    }
}
