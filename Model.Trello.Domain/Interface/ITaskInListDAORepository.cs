

using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface ITaskInListDAORepository
    {
        Task InsertTaskInList(int TaskId, int ListId);
        Task<TaskInListEntity> GetByTaskId(int TaskId);
        Task<TaskInListEntity> UpdatePostion(int TaskId, int Position,int ListTaskId);
    }
}
