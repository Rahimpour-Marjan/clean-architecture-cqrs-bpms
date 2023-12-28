using Application.Common;
using Domain.Enums;
using FluentValidation;
using Infrastructure.Persistance.Repositories;
using MediatR;


namespace Application.Account.Commands
{
    public class AccountCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Gender? Gender { get; set; }
            public DateTime? BirthDate { get; set; }
            public string? NationalCode { get; set; }
            public string? Phone { get; set; }
            public string? ExtraPhone1 { get; set; }
            public string? ExtraPhone2 { get; set; }
            public string? ExtraPhone3 { get; set; }
            public string? Email { get; set; }
            public string? ExtraEmail { get; set; }
            public string? Fax { get; set; }
            public string? Website { get; set; }
            public string? Instagram { get; set; }
            public string? Telegram { get; set; }
            public string? WhatsApp { get; set; }
            public string? Linkedin { get; set; }
            public string? Facebook { get; set; }
            public int? CountryId { get; set; }
            public int? StateId { get; set; }
            public int? CityId { get; set; }
            public int? ZoneId { get; set; }
            public string? Address { get; set; }
            public string? LocationLong { get; set; }
            public string? LocationLat { get; set; }
            public string? Job { get; set; }
            public string? Company { get; set; }
            public string? CompanyNo { get; set; }
            public string? FatherName { get; set; }
            public string? AccountalNumber { get; set; }
            public bool IsActive { get; set; }
            public decimal? WorkingHoursRate { get; set; }
            public string? ReagentName { get; set; }
            public string? ReagentCode { get; set; }
            public string? ImageUrl { get; set; }
            public string? DigitalSignatureUrl { get; set; }
            public string? ResumeUrl { get; set; }
            public bool SpacialAccount { get; set; }
            public bool IsPublic { get; set; }
            public int? PackageId { get; set; }
            public int? EducationSubFieldId { get; set; }
            public int? EducationLevelId { get; set; }
            public DateTime? EmployeementDate { get; set; }
            public List<int> PostIds { get; set; }
            public int CreatorId { get; set; }
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
                    if (request.PostIds.Count > 1)
                    {
                        return OperationResult<Response>.BuildFailure("تعداد پست سازمانی انتخاب شده غیر مجاز می باشد.");
                    }
                    else
                    {
                        var account = new Domain.Account(request.FirstName, request.LastName, UserType.DynamicUser, request.Gender, request.BirthDate, request.NationalCode, request.Phone, request.ExtraPhone1, request.ExtraPhone2, request.ExtraPhone3,
                                        request.Email, request.ExtraEmail, request.Fax, request.Website, request.Instagram, request.Telegram, request.WhatsApp, request.Linkedin, request.Facebook,
                                        request.CountryId, request.StateId, request.CityId, request.ZoneId, request.Address, request.LocationLong, request.LocationLat, request.Job, request.Company, request.CompanyNo,
                                        request.FatherName, request.AccountalNumber, request.IsActive, request.WorkingHoursRate, request.ReagentName, request.ReagentCode, request.ImageUrl, request.DigitalSignatureUrl, request.ResumeUrl, request.SpacialAccount,
                                        request.IsPublic, request.PackageId, request.EducationSubFieldId, request.EducationLevelId, request.EmployeementDate, request.CreatorId);

                        var newAccountId = await _uow.AccountRepository.Create(account);

                        await _uow.AccountRepository.AccountJuncPostCreate(request.PostIds, newAccountId);

                        var result = OperationResult<Response>
                            .BuildSuccessResult(new Response
                            {
                                AccountId = 0
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
            public int AccountId { get; set; }
        }
    }
}
