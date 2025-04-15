using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Products.RemoveProduct
{
    public class RemoveProductUseCase : BaseRemoveUseCase<Product> , IRemoveProductUseCase
    {
        public RemoveProductUseCase(IProductRepository productRepository)
            : base(productRepository)
        {
            
        }
    }
}
