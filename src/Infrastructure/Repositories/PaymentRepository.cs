using Domain.Entities;
using Infrastructure.Repositories.Common;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IPracticePackDbContext context)
            : base(context)
        {

        }
    }
}
