using AutoMapper;
using Domain.Entities;
using Application.UseCases.OrderItems.ManageOrderItem;
using Application.UseCases.OrderItems.SearchOrderItem;

namespace Application.Mapping
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, ManageOrderItemInput>().ReverseMap();
            CreateMap<OrderItem, ManageOrderItemOutput>().ReverseMap();
            CreateMap<OrderItem, SearchOrderItemOutput>().ReverseMap();
        }
    }
}
