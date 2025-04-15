using Application.UseCases.Common;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Products.ManageProduct
{
    public class ManageProductUseCase : BaseManageUseCase<Product, ManageProductInput, ManageProductOutput>, IManageProductUseCase
    {
        public ManageProductUseCase(IMapper mapper, IProductRepository productRepository)
            : base(mapper, productRepository)
        {

        }        
    }
}
