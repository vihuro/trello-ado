using Microsoft.EntityFrameworkCore;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;

namespace Model.Trello.Persistence.Repositories
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<TaskEntity> UpdateDelayed(int Id, CancellationToken cancellationToken)
        {
            var entity = await Context.Tasks
                                .SingleOrDefaultAsync(x =>
                                x.Id == Id, cancellationToken) ??
                                throw new Exception("not found");

            entity.Status = Domain.Entities.Enun.EStatusTask.DELAYED;
            entity.DateUpdated = DateTime.UtcNow;

            return entity;
        }

        public async Task<TaskEntity> UpdateForEnd(int Id, CancellationToken cancellationToken)
        {
            var entity = await Context.Tasks
                                .SingleOrDefaultAsync(x =>
                                x.Id == Id, cancellationToken) ??
                                throw new Exception("not found");

            entity.Status = Domain.Entities.Enun.EStatusTask.END;
            entity.DateUpdated = DateTime.UtcNow;


            return entity;


        }

        public async Task<TaskEntity> UpdateForInProcess(int Id ,
                                        CancellationToken cancellationToken)
        {
            var entity = await Context.Tasks
                                .SingleOrDefaultAsync(x =>
                                x.Id == Id, cancellationToken) ??
                                throw new Exception("not found");

            entity.Status = Domain.Entities.Enun.EStatusTask.IN_PROCESS;
            entity.DateUpdated = DateTime.UtcNow;


            return entity;
        }

    }
}
