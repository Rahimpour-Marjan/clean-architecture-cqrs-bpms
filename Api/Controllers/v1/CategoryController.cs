using Api.Authorization;
using Api.Enum;
using Api.Model.Category;
using Application.CategoryApplication.Commands;
using Application.CategoryApplication.Queries.FindAll;
using Application.CategoryApplication.Queries.FindById;
using Application.Helpers;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public CategoryController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.Category_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllCategoryQuery
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
        [CustomAuthorize(SiteAction.Category_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindCategoryByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Category_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new CategoryCreate.Command
                {
                    Title = model.Title,
                    CategoryParentId = model.CategoryParentId,
                    Type = model.Type,
                    IsActive = model.IsActive,
                    Url = model.Url,
                    Body = model.Body,
                    ImageUrl = model.ImageUrl,
                    CreatorId=currentUserId,
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
                        Data = result.Result.CategoryId,
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
        [CustomAuthorize(SiteAction.Category_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new CategoryUpdate.Command
                {
                    CategoryId = id,
                    Title = model.Title,
                    CategoryParentId=model.CategoryParentId,
                    Type = model.Type,
                    IsActive = model.IsActive,
                    Url = model.Url,
                    Body = model.Body,
                    ImageUrl = model.ImageUrl,
                    ModifireId =currentUserId,
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
                        Data = result.Result.CategoryId,
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

        [CustomAuthorize(SiteAction.Category_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new CategoryDelete.Command
            {
                CategoryId = id
            });

            if (!result.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) ?? "" },
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                {
                    Data = result.Result.CategoryId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Category_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new CategoryDeleteAll.Command
            {
                CategoryIds = ids
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
