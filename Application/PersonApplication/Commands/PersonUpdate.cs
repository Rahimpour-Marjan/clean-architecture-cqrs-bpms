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
            public string? PersonalNumber { get; set; }
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
                    var person = await _uow.PersonRepository.FindById(request.Id);
                    if (person == null)
                        return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                    if (request.PostIds.Count > 1)
                        return OperationResult<Response>.BuildFailure("تعداد پست سازمانی انتخاب شده غیر مجاز می باشد.");

                    person.FirstName = request.FirstName;
                    person.LastName = request.LastName;
                    person.Gender = request.Gender;
                    person.BirthDate = request.BirthDate;
                    person.NationalCode = request.NationalCode;
                    person.Phone = request.Phone;
                    person.ExtraPhone1 = request.ExtraPhone1;
                    person.ExtraPhone2 = request.ExtraPhone2;
                    person.ExtraPhone3 = request.ExtraPhone3;
                    person.Email = request.Email;
                    person.ExtraEmail = request.ExtraEmail;
                    person.Fax = request.Fax;
                    person.Website = request.Website;
                    person.Instagram = request.Instagram;
                    person.Telegram = request.Telegram;
                    person.WhatsApp = request.WhatsApp;
                    person.Linkedin = request.Linkedin;
                    person.Facebook = request.Facebook;
                    person.CountryId = request.CountryId;
                    person.StateId = request.StateId;
                    person.CityId = request.CityId;
                    person.ZoneId = request.ZoneId;
                    person.Address = request.Address;
                    person.LocationLong = request.LocationLong;
                    person.LocationLat = request.LocationLat;
                    person.Job = request.Job;
                    person.Company = request.Company;
                    person.CompanyNo = request.CompanyNo;
                    person.FatherName = request.FatherName;
                    person.PersonalNumber = request.PersonalNumber;
                    person.IsActive = request.IsActive;
                    person.WorkingHoursRate = request.WorkingHoursRate;
                    person.ReagentName = request.ReagentName;
                    person.ReagentCode = request.ReagentCode;
                    person.ImageUrl = request.ImageUrl;
                    person.DigitalSignatureUrl = request.DigitalSignatureUrl;
                    person.ResumeUrl = request.ResumeUrl;
                    person.SpacialAccount = request.SpacialAccount;
                    person.IsPublic = request.IsPublic;
                    person.PackageId = request.PackageId;
                    person.EducationSubFieldId = request.EducationSubFieldId;
                    person.EducationLevelId = request.EducationLevelId;
                    person.EmployeementDate = request.EmployeementDate;
                    person.ModifiedDate = DateTime.Now;

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