using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface IListTasksDAORepository
    {
        Task<ListTasksEntity> CreateTaskList(string Name);
        Task<List<ListTasksEntity>> GetList();
    }
}
