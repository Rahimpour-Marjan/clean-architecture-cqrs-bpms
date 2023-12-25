using Application.EducationFieldApplication.Models;
using AutoMapper;
using Infrastructure.Persistance;
using MediatR;

namespace Application.EducationFieldApplication.Queries.FindById
{
    internal class FindStorePartByIdQueryHandler : IRequestHandler<FindEducationFieldByIdQuery, EducationFieldInfo>
    {
        private readonly MakmonDbContext _db;
        private readonly IMapper _mapper;
        public FindStorePartByIdQueryHandler(MakmonDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<EducationFieldInfo> Handle(FindEducationFieldByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _db.EducationFields.FindAsync(request.Id);
            return _mapper.Map<Domain.EducationField, EducationFieldInfo>(model);
        }
    }
}
