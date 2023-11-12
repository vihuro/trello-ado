using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface ITaskListEntity
    {
        void Create(TaskListEntity entity);
        Task<List<TaskListEntity>> GetAll(CancellationToken cancellationToken);
    }
}
