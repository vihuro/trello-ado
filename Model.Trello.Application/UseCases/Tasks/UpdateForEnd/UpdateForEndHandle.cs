using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    public class UpdateForEndHandle :
        IRequestHandler<UpdateForEndRequest, TasksDefault>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public UpdateForEndHandle(IUnitOfWork unitOfWork, IMapper mapper, ITaskRepository taskRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<TasksDefault> Handle(UpdateForEndRequest request, CancellationToken cancellationToken)
        {
            var entity = await _taskRepository.UpdateForEnd(request.Id,cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<TasksDefault>(entity);
        }
    }
}
