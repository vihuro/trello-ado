using Model.Trello.Domain.Entities;


namespace Model.Trello.Domain.Interface
{
    public interface ITaskRepository : IBaseEntityRepository<TaskEntity>
    {
        Task<TaskEntity> UpdateForEnd(int Id, CancellationToken cancellationToken);
        Task<TaskEntity> UpdateForInProcess(int Id, CancellationToken cancellationToken);
        Task<TaskEntity> UpdateDelayed(int Id, CancellationToken cancellationToken);



    }
}
