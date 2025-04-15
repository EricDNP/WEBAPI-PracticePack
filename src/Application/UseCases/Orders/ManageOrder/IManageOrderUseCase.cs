using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Orders.ManageOrder
{
    public interface IManageOrderUseCase : IBaseManageUseCase<Order, ManageOrderInput,ManageOrderOutput>
    {

    }
}
