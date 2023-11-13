using FluentValidation;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    public class UpdateForEndValidation : AbstractValidator<UpdateForEndRequest>
    {
        private readonly ITaskAdoRepositoy _taskRepository;
        private readonly IUnitOfWorkADO _unitOfWork;

        public UpdateForEndValidation(ITaskAdoRepositoy taskRepository, IUnitOfWorkADO unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Id)
                .MustAsync(ValidateTask)
                .WithMessage("Task not found!");
        }

        private Task<bool> ValidateTask(int taskId, CancellationToken token)
        {
            return ValidationTask.ValidateExisingTask(taskId, _taskRepository, _unitOfWork);
        }
    }
}
