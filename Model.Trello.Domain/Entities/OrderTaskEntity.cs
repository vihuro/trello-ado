using System.ComponentModel.DataAnnotations.Schema;


namespace Model.Trello.Domain.Entities
{
    [Table("tab_oder_entity")]
    public class OrderTaskEntity
    {
        public int Id { get; set; }
        public int TaskListId { get; set; }
        public ListTasksEntity TaskList { get; set; }
        public int Order { get; set; }
    }
}
