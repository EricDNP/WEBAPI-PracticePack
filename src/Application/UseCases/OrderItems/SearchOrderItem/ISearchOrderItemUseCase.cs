using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.OrderItems.SearchOrderItem
{
    public interface ISearchOrderItemUseCase : IBaseSearchUseCase<OrderItem, SearchOrderItemOutput>
    {

    }
}
