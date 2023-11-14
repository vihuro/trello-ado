using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.TasksInList.GetByTaskId
{
    internal class GetByTaskIdHandle :
        IRequestHandler<GetByTaskIdRequest, GetByTaskIdResponse>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskInListDAORepository _taskInListDAORepository;

        public GetByTaskIdHandle(IUnitOfWorkADO unitOfWork, 
                                IMapper mapper, 
                                ITaskInListDAORepository taskInListDAORepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _taskInListDAORepository = taskInListDAORepository;
        }

        public async Task<GetByTaskIdResponse> Handle(GetByTaskIdRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();

            var TaskInList = await _taskInListDAORepository.GetByTaskId(request.Id);


            return _mapper.Map<GetByTaskIdResponse>(TaskInList);
        }
    }
}
