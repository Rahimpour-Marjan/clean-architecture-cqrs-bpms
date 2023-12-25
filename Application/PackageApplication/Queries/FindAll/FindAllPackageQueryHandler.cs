using Application.Common;
using Application.PackageApplication.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PackageApplication.Queries.FindAll
{
    public class FindAllPackageQueryHandler : IRequestHandler<FindAllPackageQuery, FindAllQueryResponse<IList<PackageInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllPackageQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<PackageInfo>>> Handle(FindAllPackageQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.PackageRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Package, PackageInfo>).ToList();

                return FindAllQueryResponse<IList<PackageInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<PackageInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
