using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    internal class UpdateForInProcessHandle :
        IRequestHandler<UpdateForInProcessRequest, TasksDefault>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public UpdateForInProcessHandle(IUnitOfWork unitOfWork, IMapper mapper, ITaskRepository taskRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<TasksDefault> Handle(UpdateForInProcessRequest request, CancellationToken cancellationToken)
        {
            var entity = await _taskRepository
                                .UpdateForInProcess(request.Id, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<TasksDefault>(entity);
        }
    }
}
