using AutoMapper;
using Domain.Entities;
using Application.UseCases.Addresses.ManageAddress;
using Application.UseCases.Addresses.SearchAddress;

namespace Application.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, ManageAddressInput>().ReverseMap();
            CreateMap<Address, ManageAddressOutput>().ReverseMap();
            CreateMap<Address, SearchAddressOutput>().ReverseMap();
        }
    }
}
