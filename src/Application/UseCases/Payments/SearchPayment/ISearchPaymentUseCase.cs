using Domain.Entities;
using Application.UseCases.Common;

namespace Application.UseCases.Payments.SearchPayment
{
    public interface ISearchPaymentUseCase : IBaseSearchUseCase<Payment, SearchPaymentOutput>
    {

    }
}
