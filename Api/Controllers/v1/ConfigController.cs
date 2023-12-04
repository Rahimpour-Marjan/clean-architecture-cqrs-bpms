using Application.Menu.Queries.FindAll;
using Application.QuickAccess.Queries.FindAll;
using Application.User.Queries.FindById;
using Application.UserGroup.Queries.FindFormTree;
using Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConfigController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId =  ((UserInfo)(HttpContext.Items["User"])).Id;
            var quickAccess = await _mediator.Send(new FindAllQuickAccessQuery { UserId = userId });
            var currentUser = await _mediator.Send(new FindUserByIdQuery { Id = userId });
            var UserAccess = await _mediator.Send(new FindAllFormTreeQuery { UserId = userId });
            return Ok(new
            {
                QuickAccess = quickAccess.Result,
                CurrentUser= currentUser,
                UserAccess = UserAccess,
            });
        }

    }
}
