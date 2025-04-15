using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Orders.SearchOrder
{
    public interface ISearchOrderUseCase : IBaseSearchUseCase<Order, SearchOrderOutput>
    {

    }
}
