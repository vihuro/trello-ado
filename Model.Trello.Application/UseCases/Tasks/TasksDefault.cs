

namespace Model.Trello.Application.UseCases.Tasks
{
    public sealed record  TasksDefault
    {
        public int Id { get; set; }
        public string Name {get;set; }
        public string Status { get; set; }
    }
}
