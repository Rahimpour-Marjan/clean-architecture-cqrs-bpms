using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api.Model.Ticket;
using Application.Ticket.Commands;
using Application.Ticket.Queries.FindAll;
using System.Net;
using Application.Users.Models;
using Domain.Enums;
using Application.Helpers;
using Application.Services;
using Application.Ticket.Queries.FindById;
using Api.Authorization;
using Api.Enum;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public TicketController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [CustomAuthorize(SiteAction.Ticket_View, SiteAction.TicketManagement_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var currentUserId = (int)HttpContext.Items["UserId"];
            var model = await _mediator.Send(new FindAllTicketQuery
            {
                UserId=currentUserId,
                Query = apiQuery.Query
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

        [CustomAuthorize(SiteAction.Ticket_Details, SiteAction.TicketManagement_Details)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindTicketByIdQuery { Id = id });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Ticket_Add, SiteAction.TicketManagement_Details)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = ((UserInfo)(HttpContext.Items["User"])).Id;

                var errors = new List<string>();

                var result = await _mediator.Send(new TicketCreate.Command
                {
                    Title = model.Title,
                    TicketParentId = model.TicketParentId,
                    WorkRequestId = model.WorkRequestId,
                    TicketText = model.TicketText,
                    Status = TicketStatus.AwaitingReview,
                    TicketPriority = model.TicketPriority,
                    TicketType = model.TicketType,
                    TicketCreatorId = userId
                });

                if (!result.Success)
                {
                    errors.Add(result.Exception != null ? result.Exception.Message : result.ErrorMessage);
                }
                else
                {
                    if (model.TicketAttachments != null && model.TicketAttachments.Any())
                    {
                        foreach (var item in model.TicketAttachments)
                        {
                            var ticketAttachmentResult = await _mediator.Send(new TicketAttachmentCreate.Command
                            {
                                TicketId = result.Result.TicketId,
                                Title = item.Title,
                                FileUrl = item.FileUrl,
                                Size = item.Size
                            });

                            if (!ticketAttachmentResult.Success)
                            {
                                errors.Add(result.Exception != null ? result.Exception.Message : result.ErrorMessage);
                            }
                        }
                    }

                    if (errors.Any())
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                        {
                            Errors = errors.ToArray(),
                        });
                    }

                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = result.Result.TicketId,
                    });
                }

                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
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
        [CustomAuthorize(SiteAction.Ticket_Add, SiteAction.TicketManagement_Details)]
        [HttpPost("TicketReply/")]
        public async Task<IActionResult> TicketReply([FromBody] TicketReplyCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = ((UserInfo)(HttpContext.Items["User"])).Id;

                var errors = new List<string>();
                var ticket = await _mediator.Send(new FindTicketByIdQuery
                {
                    Id = model.TicketParentId
                });

                if (ticket != null)
                {
                    if (model.Status == null)
                    {
                        if (ticket.TicketCreator.Id == userId)
                            model.Status = TicketStatus.AwaitingReview;
                        else
                            model.Status = TicketStatus.Answered;
                    }
                    

                    var result = await _mediator.Send(new TicketCreate.Command
                    {
                        Title = ticket.Title,
                        TicketParentId = model.TicketParentId,
                        WorkRequestId = ticket.WorkRequestId,
                        TicketText = model.TicketText,
                        Status = model.Status?? TicketStatus.AwaitingReview,
                        TicketPriority = ticket.TicketPriority,
                        TicketType = ticket.TicketType,
                        TicketCreatorId = userId
                    });

                    if (!result.Success)
                    {
                        errors.Add(result.Exception != null ? result.Exception.Message : result.ErrorMessage);
                    }
                    else
                    {
                        if (model.TicketAttachments != null && model.TicketAttachments.Any())
                        {
                            foreach (var item in model.TicketAttachments)
                            {
                                var ticketAttachmentResult = await _mediator.Send(new TicketAttachmentCreate.Command
                                {
                                    TicketId = result.Result.TicketId,
                                    Title = item.Title,
                                    FileUrl = item.FileUrl,
                                    Size = item.Size
                                });

                                if (!ticketAttachmentResult.Success)
                                {
                                    errors.Add(result.Exception != null ? result.Exception.Message : result.ErrorMessage);
                                }
                            }
                        }

                        if (errors.Any())
                        {
                            return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                            {
                                Errors = errors.ToArray(),
                            });
                        }

                        return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                        {
                            Data = result.Result.TicketId,
                        });
                    }
                }
                

                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
            }
        }

        //PUT api/<UserController>/5
        [CustomAuthorize(SiteAction.Ticket_Add)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TicketUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new TicketUpdate.Command
                {
                    Id = id,
                    TicketParentId = model.TicketParentId,
                    TicketText = model.TicketText,
                    Status = model.TicketStatus,
                    TicketPriority = model.TicketPriority,
                    TicketType = model.TicketType,
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
                        Data = result.Result.TicketId,
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

        //PUT api/<UserController>/5
        [CustomAuthorize(SiteAction.TicketManagement_Close)]
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> Put(int id, TicketStatus status)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new TicketChangeStatus.Command
                {
                    Id = id,
                    Status = status,
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
                        Data = result.Result.TicketId,
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

        [CustomAuthorize(SiteAction.TicketManagement_Close)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var result = await _mediator.Send(new TicketDelete.Command
            {
                Id = id,
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
                    Data = result.Result.TicketId,
                });
            }
        }

        [CustomAuthorize(SiteAction.TicketManagement_Close)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var userId = ((UserInfo)(HttpContext.Items["User"])).Id;
            var result = await _mediator.Send(new TicketDeleteAll.Command
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