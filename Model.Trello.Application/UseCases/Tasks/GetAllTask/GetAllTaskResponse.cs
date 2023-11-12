

namespace Model.Trello.Application.UseCases.Tasks.GetAllTask
{
    public sealed record GetAllTaskResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
