using AutoMapper;
using MediatR;
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.User.CreateUser
{
    public class CreateUserHandle :
        IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IUserEntityRepositoryADO _userEntityAdo;

        public CreateUserHandle(IMapper mapper, 
                                IUnitOfWorkADO unitOfWork,
                                IUserEntityRepositoryADO userEntity)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userEntityAdo = userEntity;

        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, 
                                                CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();

            var user = _mapper.Map<UserEntity>(request);
            await _userEntityAdo.AddUser(user);

            _unitOfWork.Commit();

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
