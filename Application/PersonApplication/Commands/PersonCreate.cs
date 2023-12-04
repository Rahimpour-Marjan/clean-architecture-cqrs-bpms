using FluentValidation;
using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;


namespace Application.Person.Commands
{
    public class PersonCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
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
            public List<int> PostIds { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(u => u.FirstName).NotEmpty().WithMessage("وارد کردن نام الزامی می باشد");
                RuleFor(u => u.LastName).NotEmpty().WithMessage("نام خانوادگی الزامی می باشد");
                RuleFor(u => u.NationalCode).Length(10).WithMessage("کد ملی باید 10 رقمی باشد");
                // ................
            }
        }

        public class Handler : IRequestHandler<Command, OperationResult<Response>>
        {
            private IUnitOfWork _uow;
            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<OperationResult<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    int postCount = 1;
                    if (request.PostIds.Count > 1)
                    {
                        return OperationResult<Response>.BuildFailure("تعداد پست سازمانی انتخاب شده غیر مجاز می باشد.");
                    }
                    else
                    {
                        var employee = new Domain.Person(request.FirstName, request.LastName, UserType.DynamicUser, request.NationalCode, request.Phone, request.Email, request.FatherName, request.PersonalNumber,
                                        request.Gender, request.BirthDate, request.IdentityNumber, request.IsActive, request.EmployeementDate, request.WorkingHoursRate, request.ImageUrl, request.DigitalSignatureUrl,request.OrganizationalPost, postCount);

                        var newEmpId = await _uow.PersonRepository.Create(employee);
                        await _uow.PersonRepository.PersonJuncPostCreate(request.PostIds, newEmpId);
                        var result = OperationResult<Response>
                            .BuildSuccessResult(new Response
                            {
                                PersonId = newEmpId
                            });

                        await Task.CompletedTask;
                        return result;
                    }

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
