using Api.Model.Notification;
using Application.Helpers;
using Application.Notification.Commands;
using Application.Notification.Queries.FindAll;
using Application.Notification.Queries.FindById;
using Application.Services;
using Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public NotificationController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var model = await _mediator.Send(new FindAllNotificationQuery
            {
                UserId = userId,
                Query = apiQuery.Query,
            });

            var route = Request.Path.Value;
            var pagedReponse = PaginationHelper.CreatePagedResponse(model.Result, model.PageNumber, model.PageSize, model.ResultCount, _uriService, route, null);

            return StatusCode((int)HttpStatusCode.OK, pagedReponse);
        }

        //GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var model = await _mediator.Send(new FindNotificationByIdQuery { Id = id, UserId = userId });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NotificationCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = (int)HttpContext.Items["UserId"];
                bool _IsRead = false;
                bool _IsStar = false;
                bool _IsArchive = false;
                bool _IsDeleted = false;
                var result = await _mediator.Send(new NotificationCreate.Command
                {
                    Title = model.Title,
                    Text = model.Text,
                    ReceiverId = model.ReceiverId,
                    SenderId = userId,
                    Icon = model.Icon,
                    Link = model.Link,
                    IsRead = _IsRead,
                    IsStar = _IsStar,
                    IsDeleted = _IsDeleted,
                    IsArchive = _IsArchive

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
                        Data = result.Result.NotificationId,
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
        public async Task<IActionResult> Put(int id, [FromBody] NotificationCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
                var result = await _mediator.Send(new NotificationUpdate.Command
                {
                    Id = id,
                    Title = model.Title,
                    Text = model.Text,
                    SenderId = userId,
                    ReceiverId = model.ReceiverId,
                    Link = model.Link,
                    Icon = model.Icon

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
                        Data = result.Result.NotificationId,
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

        [HttpPut("IsRead/{id},{isRead}")]
        public async Task<IActionResult> IsRead(int id, bool isRead)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var result = await _mediator.Send(new NotificationIsReadUpdate.Command
            {
                Id = id,
                IsRead = isRead,
                UserId = userId
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
                    Data = result.Result.NotificationId,
                });
            }
        }
        [HttpPut("IsStart/{id},{isStar}")]
        public async Task<IActionResult> IsStart(int id, bool isStar)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var result = await _mediator.Send(new NotificationIsStarUpdate.Command
            {
                Id = id,
                IsStar = isStar,
                UserId = userId
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
                    Data = result.Result.NotificationId,
                });
            }
        }
        [HttpPut("IsArchive/{id},{isArchive}")]
        public async Task<IActionResult> IsArchive(int id, bool isArchive)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var result = await _mediator.Send(new NotificationIsArchiveUpdate.Command
            {
                Id = id,
                IsArchive = isArchive,
                UserId = userId
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
                    Data = result.Result.NotificationId,
                });
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var result = await _mediator.Send(new NotificationDelete.Command
            {
                Id = id,
                UserId = userId
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
                    Data = result.Result.NotificationId,
                });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var result = await _mediator.Send(new NotificationDeleteAll.Command
            {
                Ids = ids,
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