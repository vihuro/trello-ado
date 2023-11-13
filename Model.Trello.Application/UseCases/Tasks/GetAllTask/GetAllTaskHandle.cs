using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;


namespace Model.Trello.Application.UseCases.Tasks.GetAllTask
{
    public class GetAllTaskHandle :
        IRequestHandler<GetAllTaskRequest, List<GetAllTaskResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly ITaskAdoRepositoy _taskRepository;

        public GetAllTaskHandle(IMapper mapper, 
                                IUnitOfWorkADO unitOfWork, 
                                ITaskAdoRepositoy taskRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
        }

        public async Task<List<GetAllTaskResponse>> Handle(GetAllTaskRequest request,
                                                            CancellationToken cancellationToken)
        {
            using var unitOfWork = _unitOfWork.BeginTrasaction();


            var taksList = await _taskRepository.GetAll();


            return _mapper.Map<List<GetAllTaskResponse>>(taksList);
        }
    }
}
