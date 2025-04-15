using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Addresses.ManageAddress
{
    public interface IManageAddressUseCase : IBaseManageUseCase<Address, ManageAddressInput,ManageAddressOutput>
    {

    }
}
