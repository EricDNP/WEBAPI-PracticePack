using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Products.SearchProduct
{
    public class SearchProductUseCase : BaseSearchUseCase<Product, SearchProductOutput>, ISearchProductUseCase
    {
        public SearchProductUseCase(IMapper mapper, IProductRepository productRepository)
            : base(mapper, productRepository)
        {
            
        }
    }
}
