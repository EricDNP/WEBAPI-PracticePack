using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Payments.ManagePayment
{
    public interface IManagePaymentUseCase : IBaseManageUseCase<Payment, ManagePaymentInput, ManagePaymentOutput>
    {

    }
}
