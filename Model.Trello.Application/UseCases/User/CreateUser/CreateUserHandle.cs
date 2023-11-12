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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserEntityRepository _userEntity;

        private readonly IUserEntityRepositoryADO _userEntityAdo;

        public CreateUserHandle(IMapper mapper, 
                                IUnitOfWork unitOfWork,
                                IUserEntityRepositoryADO userEntity)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userEntityAdo = userEntity;

        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, 
                                                CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserEntity>(request);
            await _userEntityAdo.AddUser(user);

            //await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
