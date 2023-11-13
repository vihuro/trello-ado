

namespace Model.Trello.Application.UseCases.TasksList.CreateTaskList
{
    public sealed record  CreateTaskListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
