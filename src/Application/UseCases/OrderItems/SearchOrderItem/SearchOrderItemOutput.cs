using Domain.Entities;

namespace Application.UseCases.OrderItems.SearchOrderItem
{
    public class SearchOrderItemOutput
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
