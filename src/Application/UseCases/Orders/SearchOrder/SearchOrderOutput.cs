using Domain.Entities;
using Domain.Enums;

namespace Application.UseCases.Orders.SearchOrder
{
    public class SearchOrderOutput
    {
        public Guid Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ArrivedDate { get; set; }
        public decimal Total { get; set; }
        public DeliveryStatus Status { get; set; }

        public Guid CustomerId { get; set; }

        public Guid AddressId { get; set; }
        public Address? Address { get; set; }

        public Guid PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
