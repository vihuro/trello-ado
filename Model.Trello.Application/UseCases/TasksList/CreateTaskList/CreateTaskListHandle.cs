using AutoMapper;
using MediatR;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.TasksList.CreateTaskList
{
    public class CreateTaskListHandle
        : IRequestHandler<CreateTaskListRequest, CreateTaskListResponse>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IListTasksDAORepository _listEntity;

        public CreateTaskListHandle(IUnitOfWorkADO unitOfWork, IMapper mapper, IListTasksDAORepository listEntity)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _listEntity = listEntity;
        }

        public async Task<CreateTaskListResponse> Handle(CreateTaskListRequest request, 
                                                    CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();

            var entity = await _listEntity.CreateTaskList(request.Name);

            _unitOfWork.Commit();

            return _mapper.Map<CreateTaskListResponse>(entity);

        }
    }
}
