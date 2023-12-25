using MediatR;
using Application.PackageApplication.Models;

namespace Application.PackageApplication.Queries.FindById
{
    public class FindPackageByIdQuery : IRequest<PackageInfo>
    {
        public int Id { get; set; }
    }
}
