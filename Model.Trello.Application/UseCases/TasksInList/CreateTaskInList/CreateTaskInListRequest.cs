using MediatR;

namespace Model.Trello.Application.UseCases.TasksInList.CreateTaskInList
{
    public record class CreateTaskInListRequest(int TaskId, int TaskListId): IRequest<CreateTaskInListResponse>;
}
