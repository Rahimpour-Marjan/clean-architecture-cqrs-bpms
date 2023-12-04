using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Person.Commands;
using Api.Model.Employee;
using Application.Person.Queries.FindAll;
using Application.Person.Queries.FindById;
using System.Net;
using Application.Helpers;
using Application.Services;
using Application.PersonApplication.Queries.FilterData;
using Api.Enum;
using Api.Authorization;
using Application.User.Queries.FindAllByPerson;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        private readonly IConfiguration _configuration;
        public PersonController(IMediator mediator, IUriService uriService, IConfiguration configuration)
        {
            _mediator = mediator;
            _uriService = uriService;
            _configuration = configuration;
        }

        [CustomAuthorize(SiteAction.Person_View, SiteAction.Users_View, SiteAction.WorkRequestCartable_SkillsTabView)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            try
            {
                var model = await _mediator.Send(new FindAllPersonQuery
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

        [CustomAuthorize(SiteAction.Person_View, SiteAction.Users_View, SiteAction.WorkRequestCartable_SkillsTabView)]
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
        [CustomAuthorize(SiteAction.Person_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindPersonByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Person_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new PersonCreate.Command
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    NationalCode = model.NationalCode,
                    Phone = model.Phone,
                    Email = model.Email,
                    FatherName = model.FatherName,
                    PersonalNumber = model.PersonalNumber,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    IdentityNumber = model.IdentityNumber,
                    IsActive = model.IsActive,
                    EmployeementDate = model.EmployeementDate,
                    WorkingHoursRate = model.WorkingHoursRate,
                    ImageUrl = model.ImageUrl,
                    DigitalSignatureUrl = model.DigitalSignatureUrl,
                    OrganizationalPost = model.OrganizationalPost,
                    PostIds = model.PostId,
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
                        Data = result.Result.PersonId,
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
        [CustomAuthorize(SiteAction.Person_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new PersonUpdate.Command
                {
                    Id = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    NationalCode = model.NationalCode,
                    Phone = model.Phone,
                    Email = model.Email,
                    FatherName = model.FatherName,
                    PersonalNumber = model.PersonalNumber,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    IdentityNumber = model.IdentityNumber,
                    IsActive = model.IsActive,
                    EmployeementDate = model.EmployeementDate,
                    WorkingHoursRate = model.WorkingHoursRate,
                    ImageUrl = model.ImageUrl,
                    DigitalSignatureUrl = model.DigitalSignatureUrl,
                    PostIds = model.PostId,
                    OrganizationalPost = model.OrganizationalPost,
                    PostCount = 1,
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
                        Data = result.Result.PersonId,
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

        [CustomAuthorize(SiteAction.Person_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new PersonDelete.Command
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
                    Data = result.Result.PersonId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Person_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new PersonDeleteAll.Command
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