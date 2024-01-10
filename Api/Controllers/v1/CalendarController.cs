using Api.Authorization;
using Api.Enum;
using Api.Model.Calendar;
using Application.Calendar.Commands;
using Application.Calendar.Queries.FindAll;
using Application.Calendar.Queries.FindById;
using Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CalendarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [CustomAuthorize(SiteAction.CalenderMaker_View)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _mediator.Send(new FindAllCalendarQuery());
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        //GET api/<UserController>/5
        [CustomAuthorize(SiteAction.CalenderMaker_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindCalendarByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalendarCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new CalendarCreate.Command
                {
                    Subject = model.Subject,
                    Description = model.Description,
                    EventDate = model.EventDate,
                    EventTime = model.EventTime,
                    SenderId = currentUserId,
                    NotificationDate = model.NotificationDate,
                    NotificationTime = model.NotificationTime,
                    HasTwoStepNotification = model.HasTwoStepNotification,
                    ReceiversId = model.ReceiversId,
                    CreatorId=currentUserId,
                });

                if (!result.Success)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { result.Exception.Message },
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = result.Result.CalendarId,
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

        [HttpPost("{calendarId}")]
        public async Task<IActionResult> Post(int calendarId, [FromBody] CalendarAttachmentCreateModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _mediator.Send(new TicketAttachmentCreate.Command
                {
                    CalendarId = calendarId,
                    File = model.File,
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
                        Data = result.Result.CalendarAttachmentId,
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
        public async Task<IActionResult> Put(int id, [FromBody] CalendarCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new CalendarUpdate.Command
                {
                    Id = id,
                    Subject = model.Subject,
                    Description = model.Description,
                    EventDate = model.EventDate,
                    EventTime = model.EventTime,
                    //SenderId = model.SenderId,
                    NotificationDate = model.NotificationDate,
                    NotificationTime = model.NotificationTime,
                    HasTwoStepNotification = model.HasTwoStepNotification,
                    ReceiversId = model.ReceiversId,
                    ModifireId=currentUserId,
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
                        Data = result.Result.CalendarId,
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
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new CalendarDelete.Command
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
                    Data = result.Result.CalendarId,
                });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new CalendarDeleteAll.Command
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