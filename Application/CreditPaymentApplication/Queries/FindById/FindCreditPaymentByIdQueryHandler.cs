using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.CreditPaymentApplication.Models;

namespace Application.CreditPaymentApplication.Queries.FindById
{
    class FindCreditPaymentByIdQueryHandler : IRequestHandler<FindCreditPaymentByIdQuery, CreditPaymentInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindCreditPaymentByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CreditPaymentInfo> Handle(FindCreditPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.CreditPaymentRepository.FindById(request.Id);
            return _mapper.Map<Domain.CreditPayment, CreditPaymentInfo>(model);
        }
    }
}
