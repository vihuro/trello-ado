using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    public class UpdateForEndHandle :
        IRequestHandler<UpdateForEndRequest, TasksDefault>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskAdoRepositoy _taskRepository;

        public UpdateForEndHandle(IUnitOfWorkADO unitOfWork, IMapper mapper, ITaskAdoRepositoy taskRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<TasksDefault> Handle(UpdateForEndRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();

            var entity = await _taskRepository.UpdateForEnd(request.Id);

            _unitOfWork.Commit();

            return _mapper.Map<TasksDefault>(entity);
        }
    }
}
