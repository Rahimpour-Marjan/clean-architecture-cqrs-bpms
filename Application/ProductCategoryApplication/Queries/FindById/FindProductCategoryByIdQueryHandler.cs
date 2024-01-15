using Application.ProductCategoryApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCategoryApplication.Queries.FindById
{
    class FindProductCategoryByIdQueryHandler : IRequestHandler<FindProductCategoryByIdQuery, ProductCategoryInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindProductCategoryByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductCategoryInfo> Handle(FindProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.ProductCategoryRepository.FindById(request.Id);
            return _mapper.Map<Domain.ProductCategory, ProductCategoryInfo>(model);
        }
    }
}
