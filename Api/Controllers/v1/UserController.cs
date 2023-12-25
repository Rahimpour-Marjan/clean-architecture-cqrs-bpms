using Api.Authorization;
using Api.Enum;
using Api.Model.User;
using Application.Helpers;
using Application.Services;
using Application.User.Commands;
using Application.User.Queries.FindAll;
using Application.User.Queries.FindAllUserGroups;
using Application.User.Queries.FindById;
using Application.UserGroup.Queries.FindFormTree;
using Application.UserLogApplication.Queries.FindAll;
using Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public UserController(IMediator mediator, IConfiguration configuration, IUriService uriService)
        {
            _mediator = mediator;
            _configuration = configuration;
            _uriService = uriService;
        }

        [CustomAuthorize(SiteAction.Users_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllUsersQuery
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

        [CustomAuthorize(SiteAction.Users_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindUserByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [CustomAuthorize(SiteAction.Users_View)]
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = ((UserInfo)(HttpContext.Items["User"]))?.Id;
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = userId,
            });
        }

        [CustomAuthorize(SiteAction.Users_View)]
        [HttpGet("GetUserGroup/{id}")]
        public async Task<IActionResult> GetUserGroup(int id)
        {
            var model = await _mediator.Send(new FindAllUserGroupsQuery { UserId = id });

            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [CustomAuthorize(SiteAction.Users_View)]
        [HttpGet("GetAccess/{id}")]
        public async Task<IActionResult> GetAccess(int id)
        {
            var UserAccess = await _mediator.Send(new FindAllFormTreeQuery { UserId = id, IsSelected = true });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = UserAccess,
            });
        }

        [CustomAuthorize(SiteAction.UserLog_View)]
        [HttpGet("GetUserLog/{id}")]
        public async Task<IActionResult> GetUserLog(int? id, [FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllUserLogQuery
            {
                UserId = id,
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

        [CustomAuthorize(SiteAction.Users_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UserCreate.Command
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    IsActive = model.IsActive,
                    AccountId = model.AccountId
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
                        Data = result.Result.UserId,
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

        [CustomAuthorize(SiteAction.Users_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UserUpdate.Command
                {
                    UserId = id,
                    UserName = model.UserName,
                    AccountId = model.AccountId,
                    IsActive = model.IsActive,
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
                        Data = result.Result.UserId,
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

        [CustomAuthorize(SiteAction.Users_ChangePassword)]
        [HttpPut("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] UserEditPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UserUpdatePassword.Command
                {
                    UserId = id,
                    OldPassword = model.OldPassword,
                    Password = model.Password
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
                        Data = result.Result.UserId,
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

        [CustomAuthorize(SiteAction.Users_ChangePassword)]
        [HttpPut("ChangePasswordByAdmin/{id}")]
        public async Task<IActionResult> ChangePasswordByAdmin(int id, [FromBody] UserEditPasswordByAdminModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UserUpdatePasswordByAdmin.Command
                {
                    UserId = id,
                    Password = model.Password
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
                        Data = result.Result.UserId,
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

        [CustomAuthorize(SiteAction.Users_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new UserDelete.Command
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
                    Data = result.Result.UserId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Users_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new UserDeleteAll.Command
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
