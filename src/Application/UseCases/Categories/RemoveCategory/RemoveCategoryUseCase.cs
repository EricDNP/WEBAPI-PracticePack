using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Categories.RemoveCategory
{
    public class RemoveCategoryUseCase : BaseRemoveUseCase<Category> , IRemoveCategoryUseCase
    {
        public RemoveCategoryUseCase(ICategoryRepository categoryRepository)
            : base(categoryRepository)
        {
            
        }
    }
}
