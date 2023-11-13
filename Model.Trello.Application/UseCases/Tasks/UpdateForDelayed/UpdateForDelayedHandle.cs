using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;


namespace Model.Trello.Application.UseCases.Tasks.UpdateForDelayed
{
    public class UpdateForDelayedHandle :
        IRequestHandler<UpdateForDelayedRequest, TasksDefault>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskAdoRepositoy _taskRepository;

        public UpdateForDelayedHandle(IUnitOfWorkADO unitOfWork, IMapper mapper, ITaskAdoRepositoy taskRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<TasksDefault> Handle(UpdateForDelayedRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();

            var entity = await _taskRepository.UpdateForDelayed(request.Id);

            _unitOfWork.Commit();

            return _mapper.Map<TasksDefault>(entity);
        }
    }
}
