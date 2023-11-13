using MediatR;

namespace Model.Trello.Application.UseCases.TasksList.CreateTaskList
{
    public sealed record CreateTaskListRequest(string Name) : IRequest<CreateTaskListResponse>;
}
