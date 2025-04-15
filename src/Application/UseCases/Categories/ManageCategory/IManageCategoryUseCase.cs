using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Categories.ManageCategory
{
    public interface IManageCategoryUseCase : IBaseManageUseCase<Category, ManageCategoryInput,ManageCategoryOutput>
    {

    }
}
