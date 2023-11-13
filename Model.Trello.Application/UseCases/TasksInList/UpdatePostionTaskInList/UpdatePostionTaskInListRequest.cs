using MediatR;

namespace Model.Trello.Application.UseCases.TasksInList.UpdataPostionTaskInList
{
    public record class UpdatePostionTaskInListRequest(int TaskId, int Position,int ListTaskId) : IRequest<UpdatePostionTaskInListResponse>;
}
