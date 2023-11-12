using MediatR;

namespace Model.Trello.Application.UseCases.User.GetAllUser
{
    public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;
}
