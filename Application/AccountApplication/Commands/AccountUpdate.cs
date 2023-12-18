using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Account.Commands
{
    public class AccountUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
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
                    var account = await _uow.AccountRepository.FindById(request.Id);
                    if (account == null)
                        return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                    if (request.PostIds.Count > 1)
                        return OperationResult<Response>.BuildFailure("تعداد پست سازمانی انتخاب شده غیر مجاز می باشد.");

                    account.FirstName = request.FirstName;
                    account.LastName = request.LastName;
                    account.Gender = request.Gender;
                    account.BirthDate = request.BirthDate;
                    account.NationalCode = request.NationalCode;
                    account.Phone = request.Phone;
                    account.ExtraPhone1 = request.ExtraPhone1;
                    account.ExtraPhone2 = request.ExtraPhone2;
                    account.ExtraPhone3 = request.ExtraPhone3;
                    account.Email = request.Email;
                    account.ExtraEmail = request.ExtraEmail;
                    account.Fax = request.Fax;
                    account.Website = request.Website;
                    account.Instagram = request.Instagram;
                    account.Telegram = request.Telegram;
                    account.WhatsApp = request.WhatsApp;
                    account.Linkedin = request.Linkedin;
                    account.Facebook = request.Facebook;
                    account.CountryId = request.CountryId;
                    account.StateId = request.StateId;
                    account.CityId = request.CityId;
                    account.ZoneId = request.ZoneId;
                    account.Address = request.Address;
                    account.LocationLong = request.LocationLong;
                    account.LocationLat = request.LocationLat;
                    account.Job = request.Job;
                    account.Company = request.Company;
                    account.CompanyNo = request.CompanyNo;
                    account.FatherName = request.FatherName;
                    account.AccountalNumber = request.AccountalNumber;
                    account.IsActive = request.IsActive;
                    account.WorkingHoursRate = request.WorkingHoursRate;
                    account.ReagentName = request.ReagentName;
                    account.ReagentCode = request.ReagentCode;
                    account.ImageUrl = request.ImageUrl;
                    account.DigitalSignatureUrl = request.DigitalSignatureUrl;
                    account.ResumeUrl = request.ResumeUrl;
                    account.SpacialAccount = request.SpacialAccount;
                    account.IsPublic = request.IsPublic;
                    account.PackageId = request.PackageId;
                    account.EducationSubFieldId = request.EducationSubFieldId;
                    account.EducationLevelId = request.EducationLevelId;
                    account.EmployeementDate = request.EmployeementDate;
                    account.ModifiedDate = DateTime.Now;

                    await _uow.AccountRepository.Update(account);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            AccountId = request.Id
                        });

                    await _uow.AccountRepository.AccountJuncPostDelete(request.Id);
                    await _uow.AccountRepository.AccountJuncPostCreate(request.PostIds, request.Id);
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
            public int AccountId { get; set; }
        }
    }
}