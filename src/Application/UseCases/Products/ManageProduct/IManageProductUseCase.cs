using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Products.ManageProduct
{
    public interface IManageProductUseCase : IBaseManageUseCase<Product, ManageProductInput,ManageProductOutput>
    {

    }
}
