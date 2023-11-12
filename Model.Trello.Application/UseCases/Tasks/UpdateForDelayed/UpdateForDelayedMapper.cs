using AutoMapper;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Entities.Enun;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForDelayed
{
    public class UpdateForDelayedMapper : Profile
    {
        public UpdateForDelayedMapper()
        {
            CreateMap<TaskEntity, TasksDefault>()
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
                    return "FINALIZADO";
                default:
                    return "STATUS NÃO MAPEADO";
            }
        }
    }
}
