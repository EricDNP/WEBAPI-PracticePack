using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Addresses.SearchAddress
{
    public interface ISearchAddressUseCase : IBaseSearchUseCase<Address, SearchAddressOutput>
    {

    }
}
