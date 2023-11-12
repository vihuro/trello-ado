using MediatR;

namespace Model.Trello.Application.UseCases.Tasks.CreateTask
{
    public sealed record class CreateTaskRequest(string Name) : IRequest<CreateTaskResponse>;
}
