using Api.Model.QuickAccess;
using Application.Common;
using Application.QuickAccess.Commands;
using Application.QuickAccess.Queries.FindAll;
using Application.QuickAccess.Queries.FindByKey;
using Application.Services;
using Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickAccessController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public QuickAccessController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var model = await _mediator.Send(new FindAllQuickAccessQuery
            {
                UserId = userId,
                Query = apiQuery.Query,
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model.Result,
            });
            //var route = Request.Path.Value;
            //var pagedReponse = PaginationHelper.CreatePagedResponse(model.Result, model.PageNumber, model.PageSize, model.ResultCount, _uriService, route, null);

            //return StatusCode((int)HttpStatusCode.OK, pagedReponse);
        }

        //GET api/<UserController>/5
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var model = await _mediator.Send(new FindQuickAccessByKeyQuery { Key = key, UserId = userId });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuickAccessCreateModel model)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];
                OperationResult<QuickAccessCreate.Response> result = new OperationResult<QuickAccessCreate.Response>();

                foreach (var key in model.SitePageKeys)
                {
                    result = await _mediator.Send(new QuickAccessCreate.Command
                    {
                        UserId = userId,
                        SitePageKey = key,
                        DisplayPriority = 1,
                        CreatorId=currentUserId,
                    });
                }

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
                        Data = result.Result.QuickAccessId,
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
        /*
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
       public async Task<IActionResult> Put(int id, [FromBody] QuickAccessCreateModel model)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new QuickAccessUpdate.Command
                {
                    Id = id,
                    UserId = userId,
                    SitePageKey = model.SitePageKey,
                    DisplayPriority = model.DisplayPriority
                }); ;

                if (!result.Success)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { result.ErrorMessage },
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = result.Result.QuickAccessId,
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
        */
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;

            var result = await _mediator.Send(new QuickAccessDelete.Command
            {
                key = key,
                UserId = userId
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
                    Data = result.Result.QuickAccessKey,
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] QuickAccessDeleteModel model)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;

            var result = await _mediator.Send(new QuickAccessDeleteAll.Command
            {
                keys = model.SitePageKeys,
                UserId = userId
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