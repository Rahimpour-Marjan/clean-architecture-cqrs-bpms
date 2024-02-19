using Application.ProductApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductApplication.Queries.FindById
{
    class FindProductByIdQueryHandler : IRequestHandler<FindProductByIdQuery, ProductInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindProductByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductInfo> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.ProductRepository.FindById(request.Id);
            return _mapper.Map<Domain.Product, ProductInfo>(model);
        }
    }
}
