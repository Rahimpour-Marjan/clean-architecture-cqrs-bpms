using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Person.Commands
{
    public class PersonUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public int CreatorId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string NationalCode { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }
            public string? FatherName { get; set; }
            public string PersonalNumber { get; set; }
            public Gender? Gender { get; set; }
            public DateTime? BirthDate { get; set; }
            public string? IdentityNumber { get; set; }
            public bool IsActive { get; set; }
            public DateTime? EmployeementDate { get; set; }
            public decimal? WorkingHoursRate { get; set; }
            public string? ImageUrl { get; set; }
            public string? DigitalSignatureUrl { get; set; }
            public string? OrganizationalPost { get; set; }
            public int PostCount { get; set; }
            public List<int> PostIds { get; set; }
        }

        public class Handler : IRequestHandler<Command, OperationResult<Response>>
        {
            private IUnitOfWork _uow;
            private readonly IMediator _mediator;
            public Handler(IUnitOfWork uow, IMediator mediator)
            {
                _uow = uow;
                _mediator = mediator;
            }

            public async Task<OperationResult<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var person = await _uow.PersonRepository.FindById(request.Id);
                    if (person == null)
                        return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                    if (request.PostIds.Count > request.PostCount)
                        return OperationResult<Response>.BuildFailure("تعداد پست سازمانی انتخاب شده غیر مجاز می باشد.");

                    person.FirstName = request.FirstName;
                    person.LastName = request.LastName;
                    person.NationalCode = request.NationalCode;
                    person.Phone = request.Phone;
                    person.Email = request.Email;
                    person.FatherName = request.FatherName;
                    person.PersonalNumber = request.PersonalNumber;
                    person.Gender = request.Gender;
                    person.BirthDate = request.BirthDate;
                    person.IsActive = request.IsActive;
                    person.EmployeementDate = request.EmployeementDate;
                    person.WorkingHoursRate = request.WorkingHoursRate;
                    person.ImageUrl = request.ImageUrl;
                    person.DigitalSignatureUrl = request.DigitalSignatureUrl;

                    await _uow.PersonRepository.Update(person);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PersonId = request.Id
                        });

                    await _uow.PersonRepository.PersonJuncPostDelete(request.Id);
                    await _uow.PersonRepository.PersonJuncPostCreate(request.PostIds, request.Id);
                    await Task.CompletedTask;

                    return result;
                }
                catch (Exception ex)
                {
                    var exResult = OperationResult<Response>.BuildFailure(ex);
                    return exResult;
                }
            }
        }
        public class Response
        {
            public int PersonId { get; set; }
        }
    }
}