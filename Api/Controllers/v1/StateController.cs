using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.StateApplication.Commands;
using Api.Model.State;
using Application.StateApplication.Queries.FindAll;
using Application.StateApplication.Queries.FindById;
using System.Net;
using Application.Helpers;
using Application.Services;
using Api.Enum;
using Api.Authorization;
using Application.StateApplication.Queries.FilterData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public StateController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.State_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllStateQuery
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

        //GET api/<UserController>/5
        [CustomAuthorize(SiteAction.State_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindStateByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [CustomAuthorize(SiteAction.State_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), "Country".ToLower()))
                {
                    var model = await _mediator.Send(new Country.Query
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

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.State_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StateInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new StateCreate.Command
                {
                    Title = model.Title,
                    CountryId=model.CountryId,
                    Code = model.Code,
                    ZipCode = model.ZipCode,
                    PostalCode = model.PostalCode,
                    LocationLat = model.LocationLat,
                    LocationLong = model.LocationLong,
                    ImageUrl = model.ImageUrl,
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
                        Data = result.Result.StateId,
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
        [CustomAuthorize(SiteAction.State_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StateInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new StateUpdate.Command
                {
                    StateId = id,
                    Title = model.Title,
                    CountryId=model.CountryId,
                    Code = model.Code,
                    ZipCode = model.ZipCode,
                    PostalCode = model.PostalCode,
                    LocationLat = model.LocationLat,
                    LocationLong = model.LocationLong,
                    ImageUrl = model.ImageUrl,
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
                        Data = result.Result.StateId,
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

        [CustomAuthorize(SiteAction.State_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new StateDelete.Command
            {
                StateId = id
            });

            if (!result.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage)??"" },
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                {
                    Data = result.Result.StateId,
                });
            }
        }

        [CustomAuthorize(SiteAction.State_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new StateDeleteAll.Command
            {
                StateIds = ids
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
                    Data = result.Result.Result,
                });
            }
        }
    }
}
