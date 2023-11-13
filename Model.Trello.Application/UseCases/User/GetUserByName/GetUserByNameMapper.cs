using AutoMapper;
using Model.Trello.Domain.Entities;


namespace Model.Trello.Application.UseCases.User.GetUserByName
{
    public class GetUserByNameMapper : Profile
    {
        public GetUserByNameMapper() 
        {
            CreateMap<UserEntity, GetUserByNameResponse>();
        }
    }
}
