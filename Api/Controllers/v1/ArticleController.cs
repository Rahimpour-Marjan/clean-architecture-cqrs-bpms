using Api.Authorization;
using Api.Enum;
using Api.Model.Article;
using Application.ArticleApplication.Commands;
using Application.ArticleApplication.Queries.FilterData;
using Application.ArticleApplication.Queries.FindAll;
using Application.ArticleApplication.Queries.FindById;
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
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public ArticleController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.Article_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllArticleQuery
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
        [CustomAuthorize(SiteAction.Article_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindArticleByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [CustomAuthorize(SiteAction.Article_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), "Category".ToLower()))
                {
                    var model = await _mediator.Send(new Category.Query
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
        [CustomAuthorize(SiteAction.Article_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticleInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new ArticleCreate.Command
                {
                    Title = model.Title,
                    CategoryId = model.CategoryId,
                    Keywords = model.Keywords,
                    Summary = model.Summary,
                    Body = model.Body,
                    VisitCount = 0,
                    IsSlider = model.IsSlider,
                    Active = model.Active,
                    Url = model.Url,
                    H1 = model.H1,
                    Writer = model.Writer,
                    WriterPosition = model.WriterPosition,
                    WriterImageUrl = model.WriterImageUrl,
                    Aparat = model.Aparat,
                    Canonical = model.Canonical,
                    NoFollow = model.NoFollow,
                    NoIndex = model.NoIndex,
                    PostLabel = model.PostLabel,
                    ImageUrl = model.ImageUrl,
                    ShowDateTime = model.ShowDateTime,
                    ExpireDateTime = model.ExpireDateTime,
                    CreatorId =currentUserId,
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
                        Data = result.Result.ArticleId,
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
        [CustomAuthorize(SiteAction.Article_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ArticleInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new ArticleUpdate.Command
                {
                    ArticleId = id,
                    Title = model.Title,
                    CategoryId = model.CategoryId,
                    Keywords = model.Keywords,
                    Summary = model.Summary,
                    Body = model.Body,
                    VisitCount = 0,
                    IsSlider = model.IsSlider,
                    Active = model.Active,
                    Url = model.Url,
                    H1 = model.H1,
                    Writer = model.Writer,
                    WriterPosition = model.WriterPosition,
                    WriterImageUrl = model.WriterImageUrl,
                    Aparat = model.Aparat,
                    Canonical = model.Canonical,
                    NoFollow = model.NoFollow,
                    NoIndex = model.NoIndex,
                    PostLabel = model.PostLabel,
                    ImageUrl = model.ImageUrl,
                    ShowDateTime = model.ShowDateTime,
                    ExpireDateTime = model.ExpireDateTime,
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
                        Data = result.Result.ArticleId,
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

        [CustomAuthorize(SiteAction.Article_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new ArticleDelete.Command
            {
                ArticleId = id
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
                    Data = result.Result.ArticleId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Article_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new ArticleDeleteAll.Command
            {
                ArticleIds = ids
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
