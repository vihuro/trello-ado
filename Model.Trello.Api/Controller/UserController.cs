using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Trello.Application.UseCases.User.CreateUser;
using Model.Trello.Application.UseCases.User.GetAllUser;
using Model.Trello.Application.UseCases.User.GetUserByName;

namespace Model.Trello.Api.Controller
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, 
                                                    CancellationToken cancellationToken)
        {
            try
            {
                var item = await _mediator.Send(request, cancellationToken);

                return Created("", item);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<GetUserByNameResponse>> GetUserByName(string name,CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByNameRequest(name), cancellationToken);

                if (result == null) return NotFound("User not found");

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>> GetUsersList(CancellationToken cancellationToken)
        {
            try
            {
                var listUsers = await _mediator.Send(new GetAllUserRequest(), cancellationToken);

                return Ok(listUsers);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
