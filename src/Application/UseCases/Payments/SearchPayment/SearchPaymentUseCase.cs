using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.UseCases.Common;

namespace Application.UseCases.Payments.SearchPayment
{
    public class SearchPaymentUseCase : BaseSearchUseCase<Payment, SearchPaymentOutput>, ISearchPaymentUseCase
    {
        public SearchPaymentUseCase(IMapper mapper, IPaymentRepository paymentRepository)
            : base(mapper, paymentRepository)
        {

        }
    }
}
