using FluentValidation;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    public class UpdateForInProcessValidation : AbstractValidator<UpdateForInProcessRequest>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateForInProcessValidation(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            RuleFor(x => x)
                .MustAsync(ValidateTask)
                .WithMessage("Task not found!");
        }

        private async Task<bool> ValidateTask(UpdateForInProcessRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.Id, cancellationToken);

            if (task != null) return true;
            return false;        }
    }
}
