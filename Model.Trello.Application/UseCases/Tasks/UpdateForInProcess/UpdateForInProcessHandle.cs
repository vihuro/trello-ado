using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.Tasks.UpdateForEnd
{
    internal class UpdateForInProcessHandle :
        IRequestHandler<UpdateForInProcessRequest, TasksDefault>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskAdoRepositoy _taskRepository;

        public UpdateForInProcessHandle(IUnitOfWorkADO unitOfWork, IMapper mapper, ITaskAdoRepositoy taskRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<TasksDefault> Handle(UpdateForInProcessRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();

            var entity = await _taskRepository
                                .UpdateForInProcess(request.Id);

            _unitOfWork.Commit();

            return _mapper.Map<TasksDefault>(entity);
        }
    }
}
