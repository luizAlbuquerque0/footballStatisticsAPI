using FootballStatistics.Application.Commands.CreateUser;
using FootballStatistics.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballStatistics.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = id}, command);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
    }
}
