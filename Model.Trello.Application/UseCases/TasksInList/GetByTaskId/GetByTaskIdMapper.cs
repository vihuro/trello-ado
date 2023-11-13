using AutoMapper;
using Model.Trello.Domain.Entities;

namespace Model.Trello.Application.UseCases.TasksInList.GetByTaskId
{
    public class GetByTaskIdMapper : Profile
    {
        public GetByTaskIdMapper() 
        {
            CreateMap<TaskInListEntity, GetByTaskIdResponse>();
        }
    }
}
