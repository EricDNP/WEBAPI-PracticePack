using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Payments.RemovePayment
{
    public class RemovePaymentUseCase : BaseRemoveUseCase<Payment> , IRemovePaymentUseCase
    {
        public RemovePaymentUseCase(IPaymentRepository paymentRepository)
            : base(paymentRepository)
        {
            
        }
    }
}
