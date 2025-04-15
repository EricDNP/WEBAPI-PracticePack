using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Products.SearchProduct
{
    public interface ISearchProductUseCase : IBaseSearchUseCase<Product, SearchProductOutput>
    {

    }
}
