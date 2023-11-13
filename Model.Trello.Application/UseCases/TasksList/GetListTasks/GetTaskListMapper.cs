using AutoMapper;
using Model.Trello.Domain.Entities;

namespace Model.Trello.Application.UseCases.TasksList.GetListTasks
{
    partial class GetTaskListMapper : Profile
    {
        public GetTaskListMapper() 
        {
            CreateMap<ListTasksEntity, GetTaskListResponse>()
                .ForMember(x => x.ListName, map => map.MapFrom(src => src.Name))
                .ForMember(x => x.Tasks, map => map.MapFrom(src => src.List.Select(c => new ListTasks
                {
                    Position = c.Order,
                    TaskName = c.Task.Name,
                    TaskStatus = c.Task.Status.ToString(),
                })));
        }
    }
}
