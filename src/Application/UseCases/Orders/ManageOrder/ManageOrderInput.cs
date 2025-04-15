using Domain.Entities;
using Domain.Enums;

namespace Application.UseCases.Orders.ManageOrder
{
    public class ManageOrderInput
    {
        public Guid Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ArrivedDate { get; set; }
        public decimal Total { get; set; }
        public DeliveryStatus Status { get; set; }

        public Guid CustomerId { get; set; }

        public Guid AddressId { get; set; }

        public Guid PaymentId { get; set; }
    }
}
