using AutoMapper;
using Model.Trello.Domain.Entities;
using static BCrypt.Net.BCrypt;


namespace Model.Trello.Application.UseCases.User.CreateUser
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper() 
        {
            CreateMap<CreateUserRequest, UserEntity>()
                .ForMember(x => x.DateCreated, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.Password, map => map.MapFrom(src => HashPassword(src.Password))) ;
            CreateMap<UserEntity, CreateUserResponse>();
        }
    }
}
