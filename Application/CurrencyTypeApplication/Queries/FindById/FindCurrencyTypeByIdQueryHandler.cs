using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.CurrencyTypeApplication.Models;

namespace Application.CurrencyTypeApplication.Queries.FindById
{
    class FindCurrencyTypeByIdQueryHandler : IRequestHandler<FindCurrencyTypeByIdQuery, CurrencyTypeInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindCurrencyTypeByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CurrencyTypeInfo> Handle(FindCurrencyTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.CurrencyTypeRepository.FindById(request.Id);
            return _mapper.Map<Domain.CurrencyType, CurrencyTypeInfo>(model);
        }
    }
}
