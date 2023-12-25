using Application.CreditPaymentApplication.Models;
using AutoMapper;
using Domain;

namespace Application.CreditPaymentApplication
{
    internal class CreditPaymentMapper : Profile
    {
        public CreditPaymentMapper()
        {
            CreateMap<CreditPayment, CreditPaymentInfo>();
        }
    }
}
