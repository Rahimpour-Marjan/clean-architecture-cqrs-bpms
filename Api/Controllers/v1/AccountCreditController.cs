using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.AccountCreditApplication.Commands;
using Api.Model.AccountCredit;
using Application.AccountCreditApplication.Queries.FindAll;
using Application.AccountCreditApplication.Queries.FindById;
using System.Net;
using Application.Helpers;
using Application.Services;
using Api.Enum;
using Api.Authorization;
using Application.AccountCreditApplication.Queries.FilterData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCreditController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public AccountCreditController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.AccountCredit_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllAccountCreditQuery
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

        [CustomAuthorize(SiteAction.AccountCredit_View)]
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
                else if (string.Equals(columnName.ToLower(), "AccountCheck".ToLower()))
                {
                    var model = await _mediator.Send(new AccountCheck.Query
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
        [CustomAuthorize(SiteAction.AccountCredit_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindAccountCreditByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.AccountCredit_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountCreditInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AccountCreditCreate.Command
                {
                    AccountId = model.AccountId,
                    Description = model.Description,
                    Amount = model.Amount,
                    Remain = model.Remain,
                    AccountCheckId = model.AccountCheckId,
                    IsActive = model.IsActive,
                    CreditType = model.CreditType,
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
                        Data = result.Result.AccountCreditId,
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
        [CustomAuthorize(SiteAction.AccountCredit_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccountCreditInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AccountCreditUpdate.Command
                {
                    AccountCreditId = id,
                    AccountId = model.AccountId,
                    Description = model.Description,
                    Amount = model.Amount,
                    Remain = model.Remain,
                    AccountCheckId = model.AccountCheckId,
                    IsActive = model.IsActive,
                    CreditType = model.CreditType,
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
                        Data = result.Result.AccountCreditId,
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

        [CustomAuthorize(SiteAction.AccountCredit_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new AccountCreditDelete.Command
            {
                AccountCreditId = id
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
                    Data = result.Result.AccountCreditId,
                });
            }
        }

        [CustomAuthorize(SiteAction.AccountCredit_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new AccountCreditDeleteAll.Command
            {
                AccountCreditIds = ids
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
