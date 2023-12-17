using MediatR;
using Application.PackageApplication.Models;
using Application.Common;

namespace Application.PackageApplication.Queries.FindAll
{
    public class FindAllPackageQuery : IRequest<FindAllQueryResponse<IList<PackageInfo>>>
    {
        public string? Query { get; set; }
    }
}
