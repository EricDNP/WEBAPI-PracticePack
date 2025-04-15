using Application.UseCases.Common;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Addresses.ManageAddress
{
    public class ManageAddressUseCase : BaseManageUseCase<Address, ManageAddressInput, ManageAddressOutput>, IManageAddressUseCase
    {
        public ManageAddressUseCase(IMapper mapper, IAddressRepository addressRepository)
            : base(mapper, addressRepository)
        {

        }        
    }
}
