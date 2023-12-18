using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api.Model.EducationSubField;
using Application.EducationSubFieldApplication.Commands;
using Application.EducationSubFieldApplication.Queries.FindById;
using Application.EducationSubFieldApplication.Queries.FindAll;
using System.Net;
using Application.EducationSubFieldApplication.Queries.FilterData;
using Application.Helpers;
using Application.Services;
using Api.Enum;
using Api.Authorization;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationSubFieldController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public EducationSubFieldController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.EducationSubField_View, SiteAction.Account_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery,int? educationFieldId)
        {
            var model = await _mediator.Send(new FindAllEducationSubFieldQuery
            {
                Query = apiQuery.Query,
                EducationFieldId= educationFieldId
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

        //GET api/<UserController>/5
        [CustomAuthorize(SiteAction.EducationSubField_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _mediator.Send(new FindEducationSubFieldByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });

        }

        [CustomAuthorize(SiteAction.EducationSubField_View, SiteAction.Account_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), nameof(EducationField).ToLower()))
                {
                    var model = await _mediator.Send(new EducationField.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                        ColumName = columnName
                    });
                    return StatusCode((int)HttpStatusCode.OK, model.Result);
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

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.EducationSubField_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EducationSubFieldCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new EducationSubFieldCreate.Command
                {
                    Title = model.Title,
                    EducationFieldId=model.EducationFieldId
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
                        Data = result.Result.EducationSubFieldId
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
        [CustomAuthorize(SiteAction.EducationSubField_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EducationSubFieldCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new EducationSubFieldUpdate.Command
                {
                    Id = id,
                    Title = model.Title,
                    EducationFieldId = model.EducationFieldId
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
                        Data = result.Result.EducationSubFieldId,
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

        [CustomAuthorize(SiteAction.EducationSubField_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new EducationSubFieldDelete.Command
            {
                Id = id
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
                    Data = result.Result.EducationSubFieldId
                });
            }
        }

        [CustomAuthorize(SiteAction.EducationSubField_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new EducationSubFieldDeleteAll.Command
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