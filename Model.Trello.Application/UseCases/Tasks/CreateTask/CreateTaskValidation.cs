using FluentValidation;

namespace Model.Trello.Application.UseCases.Tasks.CreateTask
{
    public class CreateTaskValidation : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
