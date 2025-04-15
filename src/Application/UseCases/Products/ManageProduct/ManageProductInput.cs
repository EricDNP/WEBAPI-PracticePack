using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Products.ManageProduct
{
    public class ManageProductInput
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IFormFile? Image { get; set; }
        public bool Hidden { get; set; }

        public Guid CategoryId { get; set; }
    }
}
