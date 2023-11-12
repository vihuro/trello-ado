using FluentValidation;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    public class UpdateForEndValidation : AbstractValidator<UpdateForEndRequest>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateForEndValidation(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            RuleFor(x => x)
                .MustAsync(ValidateTask)
                .WithMessage("Task not found!");
        }

        private async Task<bool> ValidateTask(UpdateForEndRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.Id, cancellationToken);

            if (task != null) return true;
            return false;        
        }
    }
}
