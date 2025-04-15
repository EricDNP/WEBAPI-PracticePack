using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Categories.SearchCategory
{
    public class SearchCategoryUseCase : BaseSearchUseCase<Category, SearchCategoryOutput>, ISearchCategoryUseCase
    {
        public SearchCategoryUseCase(IMapper mapper, ICategoryRepository categoryRepository)
            : base(mapper, categoryRepository)
        {
            
        }
    }
}
