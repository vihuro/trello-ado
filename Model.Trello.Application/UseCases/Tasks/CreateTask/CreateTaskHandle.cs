using AutoMapper;
using MediatR;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.CreateTask
{
    public class CreateTaskHandle :
        IRequestHandler<CreateTaskRequest, CreateTaskResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly ITaskAdoRepositoy _taskRepository;

        public CreateTaskHandle(IMapper mapper, IUnitOfWorkADO unitOfWork, ITaskAdoRepositoy taskRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
        }

        public async Task<CreateTaskResponse> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<TaskEntity>(request);

            _unitOfWork.BeginTrasaction();

            await _taskRepository.Create(task);

            _unitOfWork.Commit();

            return _mapper.Map<CreateTaskResponse>(task);
        }
    }
}
