using Application.UseCases.Common;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.OrderItems.ManageOrderItem
{
    public class ManageOrderItemUseCase : BaseManageUseCase<OrderItem, ManageOrderItemInput, ManageOrderItemOutput>, IManageOrderItemUseCase
    {
        public ManageOrderItemUseCase(IMapper mapper, IOrderItemRepository orderItemRepository)
            : base(mapper, orderItemRepository)
        {

        }        
    }
}
