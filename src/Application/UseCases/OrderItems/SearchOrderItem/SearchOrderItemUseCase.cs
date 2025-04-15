using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.OrderItems.SearchOrderItem
{
    public class SearchOrderItemUseCase : BaseSearchUseCase<OrderItem, SearchOrderItemOutput>, ISearchOrderItemUseCase
    {
        public SearchOrderItemUseCase(IMapper mapper, IOrderItemRepository orderItemRepository)
            : base(mapper, orderItemRepository)
        {
            
        }
    }
}
