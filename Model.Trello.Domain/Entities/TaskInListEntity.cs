namespace Model.Trello.Domain.Entities
{
    public sealed class TaskInListEntity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public int TaskListId { get; set; }
        public ListTasksEntity TaskList { get; set; }
        public int Order { get; set; }
    }
}
