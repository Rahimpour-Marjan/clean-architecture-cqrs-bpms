using Application.CurrencyTypeApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

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
