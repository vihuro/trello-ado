using MediatR;


namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    public sealed record class UpdateForEndRequest(int Id) : IRequest<TasksDefault>;
}
