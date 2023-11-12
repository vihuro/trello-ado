using FluentValidation;

namespace Model.Trello.Application.UseCases.Tasks.GetAllTask
{
    public class GetAllTaskValidation : AbstractValidator<GetAllTaskRequest>
    {
        public GetAllTaskValidation() { }
    }
}
