using FluentValidation;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForDelayed
{
    public class UpdateForDelayedValidation : AbstractValidator<UpdateForDelayedRequest>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateForDelayedValidation(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            RuleFor(x => x)
                .MustAsync(ValidateTask)
                .WithMessage("Task not found!");
        }
        private async Task<bool> ValidateTask(UpdateForDelayedRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.Id, cancellationToken);

            if (task != null) return true;
            return false;
        }
    }
}
