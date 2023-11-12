using MediatR;

namespace Model.Trello.Application.UseCases.TasksList.CreateTaskList
{
    public sealed record CreateTaskListRequest(int UserId) : IRequest<CreateTaskListResponse>;
}
