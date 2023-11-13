using MediatR;


namespace Model.Trello.Application.UseCases.TasksList.GetListTasks
{
    public record class GetTaskListRequest : IRequest<List<GetTaskListResponse>>;
}
