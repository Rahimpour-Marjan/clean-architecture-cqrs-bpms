using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.CountryApplication.Commands;
using Api.Model.Country;
using Application.CountryApplication.Queries.FindAll;
using Application.CountryApplication.Queries.FindById;
using System.Net;
using Application.Helpers;
using Application.Services;
using Api.Enum;
using Api.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public CountryController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.Country_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllCountryQuery
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
        [CustomAuthorize(SiteAction.Country_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindCountryByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Country_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CountryCreate.Command
                {
                    Title = model.Title,
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
                        Data = result.Result.CountryId,
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
        [CustomAuthorize(SiteAction.Country_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CountryInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CountryUpdate.Command
                {
                    CountryId = id,
                    Title = model.Title,
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
                        Data = result.Result.CountryId,
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

        [CustomAuthorize(SiteAction.Country_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new CountryDelete.Command
            {
                CountryId = id
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
                    Data = result.Result.CountryId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Country_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new CountryDeleteAll.Command
            {
                CountryIds = ids
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
