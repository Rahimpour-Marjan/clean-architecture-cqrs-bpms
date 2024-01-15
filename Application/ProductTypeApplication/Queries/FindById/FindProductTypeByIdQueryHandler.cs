using Application.ProductTypeApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductTypeApplication.Queries.FindById
{
    class FindProductTypeByIdQueryHandler : IRequestHandler<FindProductTypeByIdQuery, ProductTypeInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindProductTypeByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductTypeInfo> Handle(FindProductTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.ProductTypeRepository.FindById(request.Id);
            return _mapper.Map<Domain.ProductType, ProductTypeInfo>(model);
        }
    }
}
