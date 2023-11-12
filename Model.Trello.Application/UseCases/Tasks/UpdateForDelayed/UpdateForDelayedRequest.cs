

using MediatR;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForDelayed
{
    public sealed record class UpdateForDelayedRequest(int Id) : IRequest<TasksDefault>;
}
