using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api.Model.SitePage;
using Application.SitePage.Commands;
using Application.SitePage.Queries.FindById;
using Application.SitePage.Queries.FindAll;
using System.Net;
using Application.Helpers;
using Application.Services;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitePageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public SitePageController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllSitePageQuery
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var model = await _mediator.Send(new FindSitePageByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SitePageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var sitepage = await _mediator.Send(new SitePageCreate.Command
                {
                    Title = model.Title,
                    Url = model.Url,
                    Icon = model.Icon,
                    MenuId = model.MenuId,
                    Priority = model.Priority,
                    Key = model.Key

                });

                if (!sitepage.Success)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { (sitepage.Exception != null ? sitepage.Exception.Message : sitepage.ErrorMessage) },
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = sitepage.Result.SitePageId,
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] SitePageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new SitePageUpdate.Command
                {
                    Id = id,
                    Title = model.Title,
                    Url = model.Url,
                    Icon = model.Icon,
                    MenuId = model.MenuId,
                    Priority = model.Priority,
                    Key = model.Key
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
                        Data = result.Result.SitePageId,
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new SitePageDelete.Command
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
                    Data = result.Result.SitePageId,
                });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long[] ids)
        {
            var result = await _mediator.Send(new SitePageDeleteAll.Command
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
