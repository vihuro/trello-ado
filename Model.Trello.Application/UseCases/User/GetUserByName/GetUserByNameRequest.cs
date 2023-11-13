using MediatR;


namespace Model.Trello.Application.UseCases.User.GetUserByName
{
    public record class GetUserByNameRequest(string Name) : IRequest<GetUserByNameResponse>;
}
