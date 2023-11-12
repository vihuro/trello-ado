using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;


namespace Model.Trello.Application.UseCases.Tasks.GetAllTask
{
    public class GetAllTaskHandle :
        IRequestHandler<GetAllTaskRequest, List<GetAllTaskResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public GetAllTaskHandle(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<List<GetAllTaskResponse>> Handle(GetAllTaskRequest request,
                                                            CancellationToken cancellationToken)
        {
            var taksList = await _taskRepository.GetList(cancellationToken);

            return _mapper.Map<List<GetAllTaskResponse>>(taksList);
        }
    }
}
