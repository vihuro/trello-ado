using Microsoft.EntityFrameworkCore;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;

namespace Model.Trello.Persistence.Repositories
{
    public class TaskListRepository : ITaskListEntity
    {
        private readonly AppDbContext _context;

        public TaskListRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(TaskListEntity entity)
        {
            _context.TasksList.Add(entity);

        }

        public async Task<List<TaskListEntity>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.TasksList
                            .ToListAsync(cancellationToken);

            return list;
        }
    }
}
