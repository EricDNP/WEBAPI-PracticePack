using Application.UseCases.Common;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Categories.ManageCategory
{
    public class ManageCategoryUseCase : BaseManageUseCase<Category, ManageCategoryInput, ManageCategoryOutput>, IManageCategoryUseCase
    {
        public ManageCategoryUseCase(IMapper mapper, ICategoryRepository categoryRepository)
            : base(mapper, categoryRepository)
        {

        }        
    }
}
