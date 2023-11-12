using MediatR;


namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    public sealed record class UpdateForInProcessRequest(int Id) : IRequest<TasksDefault>;
}
