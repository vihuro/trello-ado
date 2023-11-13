using MediatR;

namespace Model.Trello.Application.UseCases.TasksInList.GetByTaskId
{
    public record class GetByTaskIdRequest(int Id) : IRequest<GetByTaskIdResponse>;
}
