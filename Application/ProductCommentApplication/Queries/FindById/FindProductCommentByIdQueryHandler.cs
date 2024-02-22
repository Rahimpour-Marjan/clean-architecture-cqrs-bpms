using Application.ProductCommentApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCommentApplication.Queries.FindById
{
    class FindProductCommentByIdQueryHandler : IRequestHandler<FindProductCommentByIdQuery, ProductCommentInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindProductCommentByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductCommentInfo> Handle(FindProductCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.ProductCommentRepository.FindById(request.Id);
            return _mapper.Map<Domain.ProductComment, ProductCommentInfo>(model);
        }
    }
}
