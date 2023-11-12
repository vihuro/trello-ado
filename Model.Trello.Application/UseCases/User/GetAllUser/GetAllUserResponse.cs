

namespace Model.Trello.Application.UseCases.User.GetAllUser
{
    public sealed record GetAllUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
