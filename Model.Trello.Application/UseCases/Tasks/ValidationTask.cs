using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks
{
    public static class ValidationTask
    {
        
        public static async Task<bool> ValidateExisingTask(int taskId, 
                                                            ITaskAdoRepositoy respotirory,
                                                            IUnitOfWorkADO unitOfWorkADO)
        {
            using var unit = unitOfWorkADO.BeginTrasaction();

            var task = await respotirory.GetById(taskId);

            if(task == null) return false;

            return true;
        }
    }
}
