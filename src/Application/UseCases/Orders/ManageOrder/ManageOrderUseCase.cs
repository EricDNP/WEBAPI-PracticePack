using Application.UseCases.Common;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Orders.ManageOrder
{
    public class ManageOrderUseCase : BaseManageUseCase<Order, ManageOrderInput, ManageOrderOutput>, IManageOrderUseCase
    {
        public ManageOrderUseCase(IMapper mapper, IOrderRepository orderRepository)
            : base(mapper, orderRepository)
        {

        }        
    }
}
