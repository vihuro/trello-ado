using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;


namespace Model.Trello.Application.UseCases.Tasks.UpdateForDelayed
{
    public class UpdateForDelayedHandle :
        IRequestHandler<UpdateForDelayedRequest, TasksDefault>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public UpdateForDelayedHandle(IUnitOfWork unitOfWork, IMapper mapper, ITaskRepository taskRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<TasksDefault> Handle(UpdateForDelayedRequest request, CancellationToken cancellationToken)
        {
            var entity = await _taskRepository.UpdateDelayed(request.Id, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<TasksDefault>(entity);
        }
    }
}
