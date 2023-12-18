using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.PersonAddressApplication.Commands;
using Api.Model.PersonAddress;
using Application.PersonAddressApplication.Queries.FindAll;
using Application.PersonAddressApplication.Queries.FindById;
using System.Net;
using Application.Helpers;
using Application.Services;
using Api.Enum;
using Api.Authorization;
using Application.PersonAddressApplication.Queries.FilterData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonAddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public PersonAddressController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.PersonAddress_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllPersonAddressQuery
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
        [CustomAuthorize(SiteAction.PersonAddress_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindPersonAddressByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [CustomAuthorize(SiteAction.PersonAddress_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), "Person".ToLower()))
                {
                    var model = await _mediator.Send(new Person.Query
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
        [CustomAuthorize(SiteAction.PersonAddress_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonAddressInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new PersonAddressCreate.Command
                {
                    PersonId = model.PersonId,
                    Title = model.Title,
                    FullName=model.FullName,
                    Phone = model.Phone,
                    ExtraPhone = model.ExtraPhone,
                    CountryId =model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId,
                    ZoneId = model.ZoneId,
                    Address = model.Address,
                    ZipCode = model.ZipCode,
                    PostalCode = model.PostalCode,
                    LocationLat = model.LocationLat,
                    LocationLong = model.LocationLong,
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
                        Data = result.Result.PersonAddressId,
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
        [CustomAuthorize(SiteAction.PersonAddress_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonAddressInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new PersonAddressUpdate.Command
                {
                    PersonAddressId = id,
                    Title = model.Title,
                    FullName = model.FullName,
                    Phone = model.Phone,
                    ExtraPhone = model.ExtraPhone,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId,
                    ZoneId = model.ZoneId,
                    Address = model.Address,
                    ZipCode = model.ZipCode,
                    PostalCode = model.PostalCode,
                    LocationLat = model.LocationLat,
                    LocationLong = model.LocationLong,
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
                        Data = result.Result.PersonAddressId,
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

        [CustomAuthorize(SiteAction.PersonAddress_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new PersonAddressDelete.Command
            {
                PersonAddressId = id
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
                    Data = result.Result.PersonAddressId,
                });
            }
        }

        [CustomAuthorize(SiteAction.PersonAddress_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new PersonAddressDeleteAll.Command
            {
                PersonAddressIds = ids
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
