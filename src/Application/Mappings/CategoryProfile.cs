using AutoMapper;
using Domain.Entities;
using Application.UseCases.Categories.ManageCategory;
using Application.UseCases.Categories.SearchCategory;

namespace Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ManageCategoryInput>().ReverseMap();
            CreateMap<Category, ManageCategoryOutput>().ReverseMap();
            CreateMap<Category, SearchCategoryOutput>().ReverseMap();
        }
    }
}
