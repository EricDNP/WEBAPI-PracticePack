using AutoMapper;
using Domain.Entities;
using Application.Helpers;
using Application.UseCases.Products.ManageProduct;
using Application.UseCases.Products.SearchProduct;

namespace Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ManageProductInput, Product>()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src => FormFileConverter.ConvertToBase64(src.Image)));

            CreateMap<SearchProductOutput, Product>().ReverseMap();

            CreateMap<Product, ManageProductOutput>().ReverseMap();
        }
    }
}
