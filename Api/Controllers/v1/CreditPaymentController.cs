using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.CreditPaymentApplication.Commands;
using Api.Model.CreditPayment;
using Application.CreditPaymentApplication.Queries.FindAll;
using Application.CreditPaymentApplication.Queries.FindById;
using System.Net;
using Application.Helpers;
using Application.Services;
using Api.Enum;
using Api.Authorization;
using Application.CreditPaymentApplication.Queries.FilterData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditPaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public CreditPaymentController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.CreditPayment_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllCreditPaymentQuery
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

        [CustomAuthorize(SiteAction.CreditPayment_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), "Account".ToLower()))
                {
                    var model = await _mediator.Send(new Account.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "AccountCredit".ToLower()))
                {
                    var model = await _mediator.Send(new AccountCredit.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "CurrencyType".ToLower()))
                {
                    var model = await _mediator.Send(new CurrencyType.Query
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
        [CustomAuthorize(SiteAction.CreditPayment_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindCreditPaymentByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.CreditPayment_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditPaymentInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreditPaymentCreate.Command
                {
                    AccountId = model.AccountId,
                    AccountCreditId = model.AccountCreditId,
                    Status = model.Status,
                    RefNumber = model.RefNumber,
                    ExternalInfo1 = model.ExternalInfo1,
                    ExternalInfo2 = model.ExternalInfo2,
                    Amount = model.Amount,
                    IpAddress = model.IpAddress,
                    Description = model.Description,
                    CurrencyTypeId = model.CurrencyTypeId,
                    IsInPlace = model.IsInPlace,
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
                        Data = result.Result.CreditPaymentId,
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
        [CustomAuthorize(SiteAction.CreditPayment_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreditPaymentInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreditPaymentUpdate.Command
                {
                    CreditPaymentId = id,
                    AccountId = model.AccountId,
                    AccountCreditId = model.AccountCreditId,
                    Status = model.Status,
                    RefNumber = model.RefNumber,
                    ExternalInfo1 = model.ExternalInfo1,
                    ExternalInfo2 = model.ExternalInfo2,
                    Amount = model.Amount,
                    IpAddress = model.IpAddress,
                    Description = model.Description,
                    CurrencyTypeId = model.CurrencyTypeId,
                    IsInPlace = model.IsInPlace,
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
                        Data = result.Result.CreditPaymentId,
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

        [CustomAuthorize(SiteAction.CreditPayment_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new CreditPaymentDelete.Command
            {
                CreditPaymentId = id
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
                    Data = result.Result.CreditPaymentId,
                });
            }
        }

        [CustomAuthorize(SiteAction.CreditPayment_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new CreditPaymentDeleteAll.Command
            {
                CreditPaymentIds = ids
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
