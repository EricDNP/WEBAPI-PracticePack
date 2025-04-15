using AutoMapper;
using Domain.Entities;
using Application.UseCases.Payments.ManagePayment;
using Application.UseCases.Payments.SearchPayment;

namespace Application.Mapping
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, ManagePaymentInput>().ReverseMap();
            CreateMap<Payment, ManagePaymentOutput>().ReverseMap();
            CreateMap<Payment, SearchPaymentOutput>().ReverseMap();
        }
    }
}
