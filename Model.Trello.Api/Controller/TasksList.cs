using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Trello.Application.UseCases.TasksList.CreateTaskList;
using Model.Trello.Application.UseCases.TasksList.GetListTasks;

namespace Model.Trello.Api.Controller
{
    [ApiController]
    [Route("api/v1/tasks/list")]
    public class TasksList : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksList(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreateTaskListResponse>> Create(string Name, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new CreateTaskListRequest(Name), cancellationToken);

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<GetTaskListResponse>>> GetList(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetTaskListRequest(), cancellationToken);

                return result;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
