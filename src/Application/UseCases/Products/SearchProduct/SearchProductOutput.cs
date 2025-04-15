using Domain.Entities;

namespace Application.UseCases.Products.SearchProduct
{
    public class SearchProductOutput
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public bool Hidden { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
