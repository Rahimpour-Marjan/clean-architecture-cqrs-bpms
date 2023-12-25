using Api.Authorization;
using Api.Enum;
using Api.Model.UserGroup;
using Application.Helpers;
using Application.Services;
using Application.UserGroup.Commands;
using Application.UserGroup.Queries.FindAll;
using Application.UserGroup.Queries.FindById;
using Application.UserGroup.Queries.FindFormTree;
using Application.UserGroupApplication.Queries.FilterData;
using Application.UserGroupApplication.Queries.FindUserGroupTree;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public UserGroupController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.Groups_View, SiteAction.Account_View, SiteAction.Users_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllUserGroupQuery
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

        [CustomAuthorize(SiteAction.Groups_View, SiteAction.Account_View, SiteAction.Users_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), nameof(Domain.Post).ToLower()))
                {
                    var model = await _mediator.Send(new Post.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "UserGroupParent".ToLower()))
                {
                    var model = await _mediator.Send(new Parent.Query
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
        [CustomAuthorize(SiteAction.Groups_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindUserGroupByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [CustomAuthorize(SiteAction.Groups_View, SiteAction.Account_View, SiteAction.Users_View)]
        [HttpGet("GetTree")]
        public async Task<IActionResult> GetTree()
        {
            var model = await _mediator.Send(new FindUserGroupTreeQuery
            {
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        //GET api/<UserController>/5
        [CustomAuthorize(SiteAction.Groups_Access)]
        [HttpGet("Access/{id}")]
        public async Task<IActionResult> Access(int id)
        {
            var model = await _mediator.Send(new FindAllFormTreeQuery { UserGroupId = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Groups_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserGroupCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UserGroupCreate.Command
                {
                    Title = model.Title,
                    IsActive = model.IsActive,
                    IsEditable = true,
                    UserGroupParentId = model.UserGroupParentId,
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
                        Data = result.Result.UserGroupId,
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

        [CustomAuthorize(SiteAction.Groups_Access)]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PostUserGroupPrivilage([FromBody] UserGroupPrivilageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UserGroupPrivilageCreate.Command
                {
                    UserGroupId = model.UserGroupId,
                    Ids = model.Ids
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
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
            }
        }


        // PUT api/<UserController>/5
        [CustomAuthorize(SiteAction.Groups_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserGroupCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UserGroupUpdate.Command
                {
                    Id = id,
                    Title = model.Title,
                    IsActive = model.IsActive,
                    IsEditable = true,
                    UserGroupParentId = model.UserGroupParentId,
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
                        Data = result.Result.UserGroupId,
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

        [CustomAuthorize(SiteAction.Groups_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new UserGroupDelete.Command
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
                    Data = result.Result.UserGroupId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Groups_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new UserGroupDeleteAll.Command
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
