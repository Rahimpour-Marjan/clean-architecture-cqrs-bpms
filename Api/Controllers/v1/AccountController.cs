using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Account.Commands;
using Api.Model.Employee;
using Application.Account.Queries.FindAll;
using Application.Account.Queries.FindById;
using System.Net;
using Application.Helpers;
using Application.Services;
using Application.AccountApplication.Queries.FilterData;
using Api.Enum;
using Api.Authorization;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public AccountController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [CustomAuthorize(SiteAction.Account_View, SiteAction.Users_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            try
            {
                var model = await _mediator.Send(new FindAllAccountQuery
                {
                    Query = apiQuery.Query,
                });

                if (apiQuery.Query == null)
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = model.Result,
                    });

                var route = Request.Path.Value;
                var pagedReponse = PaginationHelper.CreatePagedResponse(model.Result, model.PageNumber, model.PageSize, model.ResultCount, _uriService, route, null);

                return StatusCode((int)HttpStatusCode.OK, pagedReponse);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { (ex.Message) },
                });
            }
        }

        [CustomAuthorize(SiteAction.Account_View, SiteAction.Users_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), "Posts".ToLower()))
                {
                    var model = await _mediator.Send(new Post.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "Country".ToLower()))
                {
                    var model = await _mediator.Send(new Country.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "State".ToLower()))
                {
                    var model = await _mediator.Send(new State.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "City".ToLower()))
                {
                    var model = await _mediator.Send(new City.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "Zone".ToLower()))
                {
                    var model = await _mediator.Send(new Zone.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "Package".ToLower()))
                {
                    var model = await _mediator.Send(new Package.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "EducationField".ToLower()))
                {
                    var model = await _mediator.Send(new EducationField.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "EducationSubField".ToLower()))
                {
                    var model = await _mediator.Send(new EducationSubField.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "EducationLevel".ToLower()))
                {
                    var model = await _mediator.Send(new EducationLevel.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { "لطفا نام ستون را درست وارد نمایید." },
                    });
                }
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { "لطفا نام ستون را وارد نمایید." },
                });
            }
        }

        //GET api/<UserController>/5
        [CustomAuthorize(SiteAction.Account_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindAccountByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Account_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AccountCreate.Command
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    NationalCode = model.NationalCode,
                    Phone = model.Phone,
                    ExtraPhone1 = model.ExtraPhone1,
                    ExtraPhone2 = model.ExtraPhone2,
                    ExtraPhone3 = model.ExtraPhone3,
                    Email = model.Email,
                    ExtraEmail = model.ExtraEmail,
                    Fax = model.Fax,
                    Website = model.Website,
                    Instagram = model.Instagram,
                    Telegram = model.Telegram,
                    WhatsApp = model.WhatsApp,
                    Linkedin = model.Linkedin,
                    Facebook = model.Facebook,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId,
                    ZoneId = model.ZoneId,
                    Address = model.Address,
                    LocationLong = model.LocationLong,
                    LocationLat = model.LocationLat,
                    Job = model.Job,
                    Company = model.Company,
                    CompanyNo = model.CompanyNo,
                    FatherName = model.FatherName,
                    AccountalNumber = model.AccountalNumber,
                    IsActive = model.IsActive,
                    WorkingHoursRate = model.WorkingHoursRate,
                    ReagentName = model.ReagentName,
                    ReagentCode = model.ReagentCode,
                    ImageUrl = model.ImageUrl,
                    DigitalSignatureUrl = model.DigitalSignatureUrl,
                    ResumeUrl = model.ResumeUrl,
                    SpacialAccount = model.SpacialAccount,
                    IsPublic = model.IsPublic,
                    PackageId = model.PackageId,
                    EducationSubFieldId = model.EducationSubFieldId,
                    EducationLevelId = model.EducationLevelId,
                    EmployeementDate = model.EmployeementDate,
                    PostIds = model.PostIds,
                });

                if (!result.Success)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) },
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = result.Result.AccountId,
                    });
                }
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
            }
        }

        // PUT api/<UserController>/5
        [CustomAuthorize(SiteAction.Account_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccountUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AccountUpdate.Command
                {
                    Id = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    NationalCode = model.NationalCode,
                    Phone = model.Phone,
                    ExtraPhone1 = model.ExtraPhone1,
                    ExtraPhone2 = model.ExtraPhone2,
                    ExtraPhone3 = model.ExtraPhone3,
                    Email = model.Email,
                    ExtraEmail = model.ExtraEmail,
                    Fax = model.Fax,
                    Website = model.Website,
                    Instagram = model.Instagram,
                    Telegram = model.Telegram,
                    WhatsApp = model.WhatsApp,
                    Linkedin = model.Linkedin,
                    Facebook = model.Facebook,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId,
                    ZoneId = model.ZoneId,
                    Address = model.Address,
                    LocationLong = model.LocationLong,
                    LocationLat = model.LocationLat,
                    Job = model.Job,
                    Company = model.Company,
                    CompanyNo = model.CompanyNo,
                    FatherName = model.FatherName,
                    AccountalNumber = model.AccountalNumber,
                    IsActive = model.IsActive,
                    WorkingHoursRate = model.WorkingHoursRate,
                    ReagentName = model.ReagentName,
                    ReagentCode = model.ReagentCode,
                    ImageUrl = model.ImageUrl,
                    DigitalSignatureUrl = model.DigitalSignatureUrl,
                    ResumeUrl = model.ResumeUrl,
                    SpacialAccount = model.SpacialAccount,
                    IsPublic = model.IsPublic,
                    PackageId = model.PackageId,
                    EducationSubFieldId = model.EducationSubFieldId,
                    EducationLevelId = model.EducationLevelId,
                    EmployeementDate = model.EmployeementDate,
                    PostIds = model.PostIds,
                });

                if (!result.Success)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) },
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = result.Result.AccountId,
                    });
                }
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
            }
        }

        [CustomAuthorize(SiteAction.Account_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new AccountDelete.Command
            {
                EmpId = id
            }); ;

            if (!result.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) },
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                {
                    Data = result.Result.AccountId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Account_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new AccountDeleteAll.Command
            {
                Ids = ids
            }); ;

            if (!result.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) },
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                {
                    Data = result.Result.Result,
                });
            }
        }
    }
}