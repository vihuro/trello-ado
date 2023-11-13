using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;


namespace Model.Trello.Application.UseCases.TasksList.GetListTasks
{
    public class GetTaskListHandle :
        IRequestHandler<GetTaskListRequest, List<GetTaskListResponse>>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IListTasksDAORepository _taskInListDAORepository;
        private readonly IMapper _mapper;

        public GetTaskListHandle(IUnitOfWorkADO unitOfWork, IListTasksDAORepository taskInListDAORepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _taskInListDAORepository = taskInListDAORepository;
            _mapper = mapper;
        }

        public async Task<List<GetTaskListResponse>> Handle(GetTaskListRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();

            var result = await _taskInListDAORepository.GetList();

            return _mapper.Map<List<GetTaskListResponse>>(result);
        }
    }
}
