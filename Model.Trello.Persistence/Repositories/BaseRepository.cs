using Microsoft.EntityFrameworkCore;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;

namespace Model.Trello.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            Context.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await Context.Set<T>()
                                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity;
        }

        public async Task<List<T>> GetList(CancellationToken cancellationToken)
        {
            var listEntity = await Context.Set<T>().ToListAsync(cancellationToken);

            return listEntity;
        }

        public void Update(T entity)
        {
            Context.Update(entity);
        }
    }
}
