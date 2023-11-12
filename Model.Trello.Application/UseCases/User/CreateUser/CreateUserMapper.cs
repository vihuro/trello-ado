using AutoMapper;
using Model.Trello.Domain.Entities;

namespace Model.Trello.Application.UseCases.User.CreateUser
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper() 
        {
            CreateMap<CreateUserRequest, UserEntity>();
            CreateMap<UserEntity, CreateUserResponse>();
        }
    }
}
