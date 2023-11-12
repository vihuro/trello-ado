using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Trello.Domain.Entities
{
    [Table("tab_task_list")]
    public sealed class TaskListEntity
    {
        
        public int Id { get; set; }
        public List<TaskEntity> Task { get; set; }
        public int UserId { get;set; }
        public UserEntity User { get; set; }
        public int Order { get; set; }
    }
}
