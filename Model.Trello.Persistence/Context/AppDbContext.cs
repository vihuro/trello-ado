using Microsoft.EntityFrameworkCore;
using Model.Trello.Domain.Entities;

namespace Model.Trello.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskListEntity> TasksList { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
