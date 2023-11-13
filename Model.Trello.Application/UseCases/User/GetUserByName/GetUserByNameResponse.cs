namespace Model.Trello.Application.UseCases.User.GetUserByName
{
    public record class GetUserByNameResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
