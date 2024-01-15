using Application.ProductBrandApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductBrandApplication.Queries.FindById
{
    class FindProductBrandByIdQueryHandler : IRequestHandler<FindProductBrandByIdQuery, ProductBrandInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindProductBrandByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductBrandInfo> Handle(FindProductBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.ProductBrandRepository.FindById(request.Id);
            return _mapper.Map<Domain.ProductBrand, ProductBrandInfo>(model);
        }
    }
}
