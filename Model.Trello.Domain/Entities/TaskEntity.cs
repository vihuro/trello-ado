using Model.Trello.Domain.Entities.Enun;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Trello.Domain.Entities
{
    [Table("tab_task")]
    public sealed class TaskEntity : BaseEntity
    {
        public string Name { get; set; }
        public EStatusTask Status { get; set; }
    }
}
