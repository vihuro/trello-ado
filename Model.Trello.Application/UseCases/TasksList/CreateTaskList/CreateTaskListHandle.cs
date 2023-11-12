using AutoMapper;
using MediatR;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.TasksList.CreateTaskList
{
    public class CreateTaskListHandle
        : IRequestHandler<CreateTaskListRequest, CreateTaskListResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITaskListEntity _listEntity;

        public CreateTaskListHandle(IUnitOfWork unitOfWork, IMapper mapper, ITaskListEntity listEntity)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _listEntity = listEntity;
        }

        public async Task<CreateTaskListResponse> Handle(CreateTaskListRequest request, 
                                                    CancellationToken cancellationToken)
        {
            var list = _mapper.Map<TaskListEntity>(request);

            _listEntity.Create(list);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateTaskListResponse>(list);

        }
    }
}
