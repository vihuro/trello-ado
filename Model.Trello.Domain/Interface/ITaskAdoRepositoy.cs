using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface ITaskAdoRepositoy
    {
        Task<TaskEntity> Create(TaskEntity entity);
        Task<List<TaskEntity>> GetAll();
        Task<TaskEntity> GetById(int id);
        Task<TaskEntity> UpdateForDelayed(int taskId);
        Task<TaskEntity> UpdateForEnd(int taskId);
        Task<TaskEntity> UpdateForInProcess(int taskId);
    }
}
