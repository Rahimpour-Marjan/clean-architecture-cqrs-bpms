using Application.EducationSubFieldApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationSubFieldApplication.Queries.FindById
{
    internal class FindEducationSubFieldByIdQueryHandler : IRequestHandler<FindEducationSubFieldByIdQuery, EducationSubFieldInfo>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FindEducationSubFieldByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EducationSubFieldInfo> Handle(FindEducationSubFieldByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.EducationSubFieldRepository.FindById(request.Id);
            return _mapper.Map<Domain.EducationSubField, EducationSubFieldInfo>(model);
        }
    }
}
