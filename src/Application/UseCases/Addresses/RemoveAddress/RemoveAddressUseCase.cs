using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Addresses.RemoveAddress
{
    public class RemoveAddressUseCase : BaseRemoveUseCase<Address> , IRemoveAddressUseCase
    {
        public RemoveAddressUseCase(IAddressRepository addressRepository)
            : base(addressRepository)
        {
            
        }
    }
}
