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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskRepository _taskRepository;

        public CreateTaskHandle(IMapper mapper, IUnitOfWork unitOfWork, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
        }

        public async Task<CreateTaskResponse> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<TaskEntity>(request);

            _taskRepository.Create(task);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateTaskResponse>(task);
        }
    }
}
