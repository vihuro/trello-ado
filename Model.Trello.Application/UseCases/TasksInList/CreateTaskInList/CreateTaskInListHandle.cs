using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.TasksInList.CreateTaskInList
{
    public class CreateTaskInListHandle :
        IRequestHandler<CreateTaskInListRequest, CreateTaskInListResponse>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly ITaskInListDAORepository _taskInListDAORepository;

        public CreateTaskInListHandle(IUnitOfWorkADO unitOfWork, ITaskInListDAORepository taskInListDAORepository)
        {
            _unitOfWork = unitOfWork;
            _taskInListDAORepository = taskInListDAORepository;
        }

        public async Task<CreateTaskInListResponse> Handle(CreateTaskInListRequest request, CancellationToken cancellationToken)
        {
            using (var unit = _unitOfWork.BeginTrasaction())
            {
                await _taskInListDAORepository.InsertTaskInList(request.TaskId, request.TaskListId);
                _unitOfWork.Commit();

            }

            return new CreateTaskInListResponse();

        }
    }
}
