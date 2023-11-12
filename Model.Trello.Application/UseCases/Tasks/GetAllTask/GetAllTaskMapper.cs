using AutoMapper;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Entities.Enun;

namespace Model.Trello.Application.UseCases.Tasks.GetAllTask
{
    public class GetAllTaskMapper : Profile
    {
        public GetAllTaskMapper() 
        {
            CreateMap<TaskEntity, GetAllTaskResponse>()
                .ForMember(x => x.Status, map => map.MapFrom(src => ValidateStatus(src.Status)));
        }

        private static string ValidateStatus(EStatusTask status)
        {
            switch (status)
            {
                case EStatusTask.AWAIT:
                    return "AGUARDANDO";
                case EStatusTask.IN_PROCESS:
                    return "EM PROCESSO";
                case EStatusTask.DELAYED:
                    return "ATRASADO";
                case EStatusTask.END:
                    return "FINALIADO";
                default:
                    return "STATUS NÃO MAPEADO";
            }
        }
    }
}
