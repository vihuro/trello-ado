using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Trello.Application.UseCases.TasksInList.CreateTaskInList;
using Model.Trello.Application.UseCases.TasksInList.GetByTaskId;
using Model.Trello.Application.UseCases.TasksInList.UpdataPostionTaskInList;

namespace Model.Trello.Api.Controller
{
    [ApiController]
    [Route("api/v1/tasks-in-list")]
    public class TasksInListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksInListController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreateTaskInListResponse>> InsertTaskInList(CreateTaskInListRequest request,
                                                                                    CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                return Created("","");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetByTaskIdResponse>> GetById(int Id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetByTaskIdRequest(Id), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<UpdatePostionTaskInListResponse>> UpdatePostion(UpdatePostionTaskInListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
