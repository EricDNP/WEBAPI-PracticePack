using AutoMapper;
using Domain.Entities;
using Application.UseCases.Orders.ManageOrder;
using Application.UseCases.Orders.SearchOrder;

namespace Application.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ManageOrderInput>().ReverseMap();
            CreateMap<Order, ManageOrderOutput>().ReverseMap();
            CreateMap<Order, SearchOrderOutput>().ReverseMap();
        }
    }
}
