

using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface ITaskInListDAORepository
    {
        Task InsertTaskInList(int TaskId, int ListId);
        Task<TaskInListEntity> GetById(int TaskId);
        Task<TaskInListEntity> UpdatePostion(int TaskId, int Position,int ListTaskId);
    }
}
