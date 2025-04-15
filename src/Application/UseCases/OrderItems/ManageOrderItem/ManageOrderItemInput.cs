using Domain.Entities;

namespace Application.UseCases.OrderItems.ManageOrderItem
{
    public class ManageOrderItemInput
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }
    }
}
