using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Addresses.SearchAddress
{
    public class SearchAddressUseCase : BaseSearchUseCase<Address, SearchAddressOutput>, ISearchAddressUseCase
    {
        public SearchAddressUseCase(IMapper mapper, IAddressRepository addressRepository)
            : base(mapper, addressRepository)
        {
            
        }
    }
}
