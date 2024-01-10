using Application.CategoryApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CategoryApplication.Queries.FindById
{
    class FindCategoryByIdQueryHandler : IRequestHandler<FindCategoryByIdQuery, CategoryInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindCategoryByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CategoryInfo> Handle(FindCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.CategoryRepository.FindById(request.Id);
            return _mapper.Map<Domain.Category, CategoryInfo>(model);
        }
    }
}
