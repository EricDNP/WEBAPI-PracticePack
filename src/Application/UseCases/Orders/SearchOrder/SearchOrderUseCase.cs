using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Orders.SearchOrder
{
    public class SearchOrderUseCase : BaseSearchUseCase<Order, SearchOrderOutput>, ISearchOrderUseCase
    {
        public SearchOrderUseCase(IMapper mapper, IOrderRepository orderRepository)
            : base(mapper, orderRepository)
        {
            
        }
    }
}
