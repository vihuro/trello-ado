using MediatR;

namespace Model.Trello.Application.UseCases.Tasks.GetAllTask
{
    public sealed record class GetAllTaskRequest : IRequest<List<GetAllTaskResponse>>;
}
