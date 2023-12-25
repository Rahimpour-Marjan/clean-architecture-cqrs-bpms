using Application.Common;
using Application.PackageApplication.Models;
using MediatR;

namespace Application.PackageApplication.Queries.FindAll
{
    public class FindAllPackageQuery : IRequest<FindAllQueryResponse<IList<PackageInfo>>>
    {
        public string? Query { get; set; }
    }
}
