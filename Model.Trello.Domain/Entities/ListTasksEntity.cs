namespace Model.Trello.Domain.Entities
{
    public sealed class ListTasksEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskInListEntity> List { get; set; }
    }
}
