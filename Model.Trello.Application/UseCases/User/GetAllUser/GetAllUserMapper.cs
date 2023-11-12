using AutoMapper;
using Model.Trello.Domain.Entities;

namespace Model.Trello.Application.UseCases.User.GetAllUser
{
    public class GetAllUserMapper : Profile
    {
        public GetAllUserMapper() 
        {
            CreateMap<UserEntity, GetAllUserResponse>();
        }
    }
}
