using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.User.GetAllUser
{
    public class GetAllUserhandle :
            IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
    {
        private readonly IUserEntityRepositoryADO _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkADO _unitOfWork;
        public GetAllUserhandle(IUserEntityRepositoryADO userRepository, IMapper mapper, IUnitOfWorkADO unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTrasaction();
            var listUsers = await _userRepository.GetAllUsers();


            return _mapper.Map<List<GetAllUserResponse>>(listUsers);
        }
    }
}
