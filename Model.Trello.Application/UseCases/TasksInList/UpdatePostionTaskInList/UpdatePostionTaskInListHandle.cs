using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.TasksInList.UpdataPostionTaskInList
{
    public class UpdatePostionTaskInListHandle :
        IRequestHandler<UpdatePostionTaskInListRequest, UpdatePostionTaskInListResponse>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly ITaskInListDAORepository _taskInListRepository;
        private readonly IMapper _mapper;
        

        public UpdatePostionTaskInListHandle(IUnitOfWorkADO unitOfWork, 
                                                ITaskInListDAORepository taskInListRepository, 
                                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _taskInListRepository = taskInListRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePostionTaskInListResponse> Handle(UpdatePostionTaskInListRequest request, CancellationToken cancellationToken)
        {
            int validateId = 0;
            using (var unit = _unitOfWork.BeginTrasaction())
            {
                var validate = await _taskInListRepository.GetByTaskId(request.TaskId);

                if (validate != null) { }
                validateId = validate.Id;
            }

            using (var unit = _unitOfWork.BeginTrasaction())
            {

                var updatePostion = await _taskInListRepository.UpdatePostion(validateId, request.Position, request.ListTaskId);

                unit.Commit();

                return _mapper.Map<UpdatePostionTaskInListResponse>(updatePostion);
            }

        }
    }
}
