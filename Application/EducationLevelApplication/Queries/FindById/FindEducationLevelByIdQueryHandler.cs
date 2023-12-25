using Application.EducationLevelApplication.Models;
using AutoMapper;
using Infrastructure.Persistance;
using MediatR;

namespace Application.EducationLevelApplication.Queries.FindById
{
    internal class FindEducationLevelByIdQueryHandler : IRequestHandler<FindEducationLevelByIdQuery, EducationLevelInfo>
    {
        private readonly MakmonDbContext _db;
        private readonly IMapper _mapper;
        public FindEducationLevelByIdQueryHandler(MakmonDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<EducationLevelInfo> Handle(FindEducationLevelByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _db.EducationLevels.FindAsync(request.Id);
            return _mapper.Map<Domain.EducationLevel, EducationLevelInfo>(model);
        }
    }
}
