using AutoMapper;
using Domain.Entities;
using Application.UseCases.Common;
using Domain.Interfaces;

namespace Application.UseCases.Payments.ManagePayment
{
    public class ManagePaymentUseCase : BaseManageUseCase<Payment, ManagePaymentInput, ManagePaymentOutput>, IManagePaymentUseCase
    {
        public ManagePaymentUseCase(IMapper mapper, IPaymentRepository paymentRepository)
            : base(mapper, paymentRepository)
        {
            
        }
    }
}
