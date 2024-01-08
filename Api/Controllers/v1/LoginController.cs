using Api.Model.Login;
using Application.LoginApplication.Commands;
using Application.User.Queries.FindByAuthInfo;
using Application.User.Queries.FindById;
using Application.UserLogApplication.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Wangkanai.Detection.Services;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IDetectionService _detectionService;
        public LoginController(IMediator mediator, IDetectionService detectionService)
        {
            _mediator = mediator;
            _detectionService = detectionService;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> LoginAsync([FromBody] Command login)
        //return result != null ? Created("", result) : BadRequest(result);
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new Login.Command
                {
                    UserName = model.UserName,
                    Password = model.Password
                });

                if (result.Success)
                {
                    var user = await _mediator.Send(new FindUserByUserNameQuery
                    {
                        UserName = model.UserName,
                    });
                    if (user != null)
                    {
                        var userId = user.Id;
                        string ipAddress = "";
                        if (Dns.GetHostAddresses(Dns.GetHostName()).Length > 0)
                        {
                            ipAddress = Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();
                        }
                        string device = "";
                        if (_detectionService != null)
                            device = _detectionService.UserAgent.ToString();
                        await _mediator.Send(new UserLogCreate.Command
                        {
                            Type = Domain.Enums.UserLogType.Login,
                            IP = ipAddress,
                            Device = device,
                            CreatorId = userId,
                        });
                    }
                    return Ok(result.Result);
                }
                else
                {
                    //return BadRequest(result.Exception.Message);
                    ModelState.AddModelError("خطا", (result.Exception != null ? result.Exception.Message : result.ErrorMessage));
                    //foreach (var errorItem in result.Result.Errors)
                    //{
                    //ModelState.AddModelError("خطا", errorItem);
                    //}
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("getuser/{userid}")]
        public async Task<IActionResult> FindUserByIdAsync([FromRoute] int userid)
        {
            var date = DateTime.Now;
            var result = await _mediator.Send(new FindUserByIdQuery { Id = userid });
            return result != null ? Ok(result) : NotFound();
        }
    }
}
