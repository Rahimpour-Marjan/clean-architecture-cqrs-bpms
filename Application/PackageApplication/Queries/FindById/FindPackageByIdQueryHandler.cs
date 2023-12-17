using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.PackageApplication.Models;

namespace Application.PackageApplication.Queries.FindById
{
    class FindPackageByIdQueryHandler : IRequestHandler<FindPackageByIdQuery, PackageInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindPackageByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<PackageInfo> Handle(FindPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.PackageRepository.FindById(request.Id);
            return _mapper.Map<Domain.Package, PackageInfo>(model);
        }
    }
}
