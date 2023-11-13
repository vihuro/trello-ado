

namespace Model.Trello.Application.UseCases.TasksInList.GetByTaskId
{
    public record class GetByTaskIdResponse
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int TaskListId { get; set; }
    }
}
