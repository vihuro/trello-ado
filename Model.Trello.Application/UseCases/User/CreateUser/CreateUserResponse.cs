namespace Model.Trello.Application.UseCases.User.CreateUser
{
    public record class CreateUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
