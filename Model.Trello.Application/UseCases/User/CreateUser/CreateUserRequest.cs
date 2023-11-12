using MediatR;

namespace Model.Trello.Application.UseCases.User.CreateUser
{
    public record class CreateUserRequest(string Name, string Password) : IRequest<CreateUserResponse>
    {
    }
}
