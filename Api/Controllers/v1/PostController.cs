using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Post.Commands;
using Api.Model.Post;
using Application.Post.Queries.FindById;
using Application.Post.Queries.FindAll;
using System.Net;
using Application.PostApplication.Queries.FindPostTree;
using Application.Helpers;
using Application.Services;
using Application.PostApplication.Queries.FilterData;
using Application.UserGroup.Queries.FindFormTree;
using Api.Authorization;
using Api.Enum;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public PostController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [CustomAuthorize(SiteAction.Post_View, SiteAction.Person_View)]
        [HttpGet("GetTree")]
        public async Task<IActionResult> GetTree()
        {
            var model = await _mediator.Send(new FindPostTreeQuery());
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.Post_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery,int? parentId)
        {
            var model = await _mediator.Send(new FindAllPostQuery
            {
                ParentId = parentId,
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

        [CustomAuthorize(SiteAction.Post_View, SiteAction.Person_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), "PostParent".ToLower()))
                {
                    var model = await _mediator.Send(new PostParent.Query
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
        [CustomAuthorize(SiteAction.Post_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindPostByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Post_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new PostCreate.Command
                {
                    Title = model.Title,
                    PostParentId = model.PostParentId,
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
                        Data = result.Result.postId,
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
        
        // POST api/<UserController>
        [HttpPost]
        [CustomAuthorize(SiteAction.Post_Add)]
        [Route("[action]")]
        public async Task<IActionResult> PostJuncUserGroup([FromBody] PostJuncUserGroupCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new PostJuncUserGroupCreate.Command
                {
                    PostId = model.PostId,
                    UserGroupIds = model.UserGroupIds
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
        [CustomAuthorize(SiteAction.Post_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new PostUpdate.Command
                {
                    Id = id,
                    Title = model.Title,
                    PostParentId = model.PostParentId,
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
                        Data = result.Result.PostId,
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

        [CustomAuthorize(SiteAction.Post_Delete)]
        [HttpDelete("DeleteByUserGroup/{postId}")]
        public async Task<IActionResult> DeleteByUserGroup(int postId, [FromBody] int[] userGroupIds)
        {
            var result = await _mediator.Send(new PostJuncUserGroupDelete.Command
            {
                PostId = postId,
                UserGroupIds= userGroupIds,
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
                    Data = result.Result.PostId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Post_Access)]
        [HttpGet("GetAccess/{id}")]
        public async Task<IActionResult> GetAccess(int id)
        {
            var UserAccess = await _mediator.Send(new FindAllFormTreeQuery { PostId = id, IsSelected = true });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = UserAccess,
            });
        }

        [CustomAuthorize(SiteAction.Post_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new PostDelete.Command
            {
                PostId = id
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
                    Data = result.Result.PostId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Post_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new PostDeleteAll.Command
            {
                Ids = ids
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
