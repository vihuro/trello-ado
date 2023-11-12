using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Trello.Application.UseCases.Tasks;
using Model.Trello.Application.UseCases.Tasks.CreateTask;
using Model.Trello.Application.UseCases.Tasks.GetAllTask;
using Model.Trello.Application.UseCases.Tasks.UpdateForDelayed;
using Model.Trello.Application.UseCases.Tasks.UpdateForEnd;

namespace Model.Trello.Api.Controller
{
    [ApiController]
    [Route("api/v1")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreateTaskResponse>> CreateTask(CreateTaskRequest request,
                                                                        CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllTaskResponse>>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var listTasks = await _mediator.Send(new GetAllTaskRequest(), cancellationToken);

                return Ok(listTasks);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("end/{id}")]
        public async Task<ActionResult<TasksDefault>> UpdateForStatusEnd(int id,
                                                                        CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new UpdateForEndRequest(id), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("in-process/{id}")]
        public async Task<ActionResult<TasksDefault>> UpdateForStatusInProcess(int id,
                                                                CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new UpdateForInProcessRequest(id), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delay/{id}")]
        public async Task<ActionResult<TasksDefault>> UpdateForDelay(int id,
                                                                      CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new UpdateForDelayedRequest(id), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
