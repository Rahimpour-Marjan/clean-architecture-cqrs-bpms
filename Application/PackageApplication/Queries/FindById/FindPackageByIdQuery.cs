using Application.PackageApplication.Models;
using MediatR;

namespace Application.PackageApplication.Queries.FindById
{
    public class FindPackageByIdQuery : IRequest<PackageInfo>
    {
        public int Id { get; set; }
    }
}
