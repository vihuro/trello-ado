namespace Model.Trello.Application.UseCases.TasksList.GetListTasks
{
    public record class GetTaskListResponse
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<ListTasks> Tasks { get; set; }
    }
    public class ListTasks
    {
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public int Position { get; set; }
    }
}
