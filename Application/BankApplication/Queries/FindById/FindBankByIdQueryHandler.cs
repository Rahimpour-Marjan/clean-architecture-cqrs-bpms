using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.BankApplication.Models;

namespace Application.BankApplication.Queries.FindById
{
    class FindBankByIdQueryHandler : IRequestHandler<FindBankByIdQuery, BankInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindBankByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<BankInfo> Handle(FindBankByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.BankRepository.FindById(request.Id);
            return _mapper.Map<Domain.Bank, BankInfo>(model);
        }
    }
}
