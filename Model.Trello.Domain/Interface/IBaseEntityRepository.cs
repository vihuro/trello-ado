using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface IBaseEntityRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetList(CancellationToken cancellationToken);
        Task<T> GetById(int id,CancellationToken cancellationToken);
    }
}
